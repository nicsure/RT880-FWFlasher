using System.IO.Ports;

namespace RT880_FWFlasher
{
    public partial class UI : Form
    {
        private SerialPort? portInUse = null;
        private string progString = "0%";
        private const int flashSize = 1024 * 1024 * 4;


        private string SelectedPortName => ComPorts.SelectedItem?.ToString() ?? string.Empty;

        public UI()
        {
            InitializeComponent();
            EnumerateSerialPorts();
            DarkMode.EnableDarkMode(this.Handle);
        }

        private void EnumerateSerialPorts()
        {
            var selected = ComPorts.SelectedItem;
            ComPorts.Items.Clear();
            foreach (var portName in SerialPort.GetPortNames())
            {
                ComPorts.Items.Add(portName);
            }
            try { ComPorts.SelectedItem = selected; } catch { }
            if (ComPorts.SelectedIndex == -1 && ComPorts.Items.Count > 0)
                ComPorts.SelectedIndex = 0;
        }

        private static byte[] ConstructPacket(int type, int address, byte[] data, int offset, int count)
        {
            byte[] packet = new byte[count + 4];
            int cs = packet.Length - 1;
            packet[0] = (byte)type;
            packet[1] = (byte)((address >> 8) & 0xff);
            packet[2] = (byte)(address & 0xff);
            packet[cs] = 0x52;
            Array.Copy(data, offset, packet, 3, count);
            for (int i = 0; i < cs; i++)
            {
                packet[cs] += packet[i];
            }
            return packet;
        }

        private static void ClosePort(SerialPort? port)
        {
            using (port)
            {
                port?.Close();
            }
        }

        private static int ReadByte(SerialPort port)
        {
            try
            {
                return port.ReadByte();
            }
            catch (TimeoutException) { return -2; }
            catch { return -1; }
        }

        private bool GetAck(SerialPort port)
        {
            switch (ReadByte(port))
            {
                case 6: return true;
                case -1: SetStatus("COM Port Read Error/Abort"); break;
                case -2: SetStatus("COM Port Timeout"); break;
                default: SetStatus("Bad Acknowledgement"); break;
            }
            return false;
        }

        private bool WriteData(SerialPort port, byte[] data)
        {
            try
            {
                port.Write(data, 0, data.Length);
                return true;
            }
            catch { SetStatus("COM Port Write Error/Abort"); }
            return false;
        }


        private static SerialPort? OpenPort(string com, int baud, int timeout)
        {
            SerialPort? port = null;
            try
            {
                port = new SerialPort(com, baud, Parity.None, 8, StopBits.One)
                {
                    ReadTimeout = timeout
                };
                port.Open();
                return port;
            }
            catch { }
            ClosePort(port);
            return null;
        }


        private void Flash(string com, byte[] unpadded)
        {
            int len = (int)Math.Ceiling(unpadded.Length / 1024.0) * 1024;
            byte[] firmware = new byte[len];
            Array.Copy(unpadded, 0, firmware, 0, unpadded.Length);
            if (OpenPort(com, 115200, 20000) is SerialPort port)
            {
                portInUse = port;
                try
                {
                    SetStatus("Erasing Flash");
                    byte[] packet = ConstructPacket(0x39, 0x3305, [0x10], 0, 1);
                    if (!WriteData(port, packet)) return;
                    if (!GetAck(port)) return;
                    if (!WriteData(port, packet)) return;
                    if (!GetAck(port)) return;
                    packet = ConstructPacket(0x39, 0x3305, [0x55], 0, 1);
                    if (!WriteData(port, packet)) return;
                    if (!GetAck(port)) return;
                    for (int i = 0; i < len; i += 1024)
                    {
                        packet = ConstructPacket(0x57, i, firmware, i, 1024);
                        if (!WriteData(port, packet)) return;
                        if (!GetAck(port)) return;
                        SetProgress(i, len - 1024);
                    }
                    if (!GetAck(port)) return;
                    SetStatus("Firmware Flash Finished Okay");
                }
                finally { ClosePort(port); }
            }
            else
                SetStatus($"Cannot open port: {com}");

        }

        private void SetProgress(int now, int len)
        {
            Invoke(() =>
            {
                double d = (double)now / len;
                d *= 100;
                if (d < 0) d = 0; else if (d > 100) d = 100;
                ProgressBar.Value = (int)d;
                progString = $"{(int)d}%";
                SetStatus($"Progress: {progString}");
            });
        }

        private void SetStatus(string status)
        {
            Invoke(() =>
            {
                StatusLabel.Text = status;
            });
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new()
            {
                Title = "Open RT-880 Firmware Binary Image",
                Filter = "BIN Files|*.bin|All Files|*.*"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StartButton.Enabled = true;
                BinFileBox.Text = ofd.FileName;
            }
        }

        private void Busy(bool busy)
        {
            BrowseButton.Enabled = !busy;
            StartButton.Enabled = BinFileBox.Text.Length != 0 && !busy;
            AbortButton.Enabled = busy;
            ComPorts.Enabled = !busy;
            SpiBackupButton.Enabled = !busy;
            BinFileBox.Enabled = !busy;
            MonitorButton.Enabled = !busy;
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            byte[] firmware;
            try
            {
                firmware = File.ReadAllBytes(BinFileBox.Text);
            }
            catch
            {
                SetStatus("Cannot read firmware bin file");
                return;
            }
            Busy(true);
            string portName = SelectedPortName;
            SetProgress(0, 100);
            using var task = Task.Run(() =>
            {
                Flash(portName, firmware);
            });
            await task;
            Busy(false);
        }

        private void ComPorts_DropDown(object sender, EventArgs e)
        {
            EnumerateSerialPorts();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            ClosePort(portInUse);
        }

        private async void MonitorButton_Click(object sender, EventArgs e)
        {
            Busy(true);
            MonitorBox.BorderStyle = BorderStyle.Fixed3D;
            if (OpenPort(SelectedPortName, 115200, 100000000) is SerialPort port)
            {
                portInUse = port;
                SetStatus($"Monitoring Port {SelectedPortName}");
                using var task = Task.Run(() =>
                {
                    while (true)
                    {
                        int b = ReadByte(port);
                        if (b < 0)
                            break;
                        Invoke(() =>
                        {
                            if (MonitorTextMode.Checked)
                            {
                                if (b == 0)
                                    MonitorBox.AppendText("\r\n");
                                else
                                {
                                    if (b < 32 || b > 126)
                                        b = '.';
                                    MonitorBox.AppendText(((char)b).ToString());
                                }
                            }
                            else
                            {
                                MonitorBox.AppendText($"{b:X2} ");
                            }
                        });
                    }
                });
                await task;
                SetStatus($"Monitoring Stopped");
            }
            Busy(false);
            MonitorBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private static bool TryReadByte(SerialPort port, out int b)
        {
            b = ReadByte(port);
            return b >= 0;
        }

        private async void SpiBackupButton_Click(object sender, EventArgs e)
        {
            byte[] spi = new byte[flashSize];
            Busy(true);
            SetProgress(0, 100);
            if (OpenPort(SelectedPortName, 230400, 100000000) is SerialPort port)
            {
                portInUse = port;
                SetStatus("Waiting for Radio");
                using var task = Task.Run(() =>
                {
                    int raddr, addr, i;
                    byte cs, rcs;
                    addr = 0;
                    while(true)
                    {
                        if (!TryReadByte(port, out int b)) break;
                        if (b != 0xaa) continue;
                        if (!TryReadByte(port, out b)) break;
                        if (b != 0x30) continue;
                        raddr = 0;
                        cs = 0;

                        for (i = 0; i < 4; i++)
                        {
                            if (!TryReadByte(port, out b)) break;
                            raddr |= b << (i * 8);
                            cs += (byte)b;
                        }
                        if (addr != raddr)
                            continue;

                        for (i = 0; i < 1024; i++)
                        {
                            if (!TryReadByte(port, out b)) break;
                            spi[addr + i] = (byte)b;
                            cs += (byte)b;
                        }
                        if (i < 1024)
                            continue;

                        if (!TryReadByte(port, out b)) break;
                        rcs = (byte)b;
                        if (!TryReadByte(port, out b)) break;
                        if (b != 0x55)
                            continue;
                        if (cs != rcs)
                            continue;
                        addr += 1024;
                        Invoke(() => 
                        {
                            SetProgress(addr, flashSize);
                            SetStatus($"Got Block 0x{raddr:X8}  {progString}");
                            while (addr >= flashSize)
                            {
                                using SaveFileDialog sfd = new()
                                {
                                    Title = "Save SPI Flash Backup Image",
                                    Filter = "880SPI Files|*.880spi"
                                };
                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    try
                                    {
                                        File.WriteAllBytes(sfd.FileName, spi);
                                    }
                                    catch
                                    {
                                        SetStatus("Unable to write to file, try again.");
                                        continue;
                                    }
                                }
                                break;
                            }
                        });
                        if (addr >= flashSize) break;

                    }
                });
                await task;
                ClosePort(port);
            }
            Busy(false);
        }
    }
}
