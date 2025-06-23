using System.IO.Ports;

namespace RT880_FWFlasher
{
    public partial class UI : Form
    {
        private SerialPort? flashingPort = null;

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


        private static SerialPort? OpenPort(string com)
        {
            SerialPort? port = null;
            try
            {
                port = new SerialPort(com, 115200, Parity.None, 8, StopBits.One)
                {
                    ReadTimeout = 20000
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
            if (OpenPort(com) is SerialPort port)
            {
                flashingPort = port;
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
                SetStatus($"Progress: {(int)d}%");
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
            BrowseButton.Enabled = false;
            StartButton.Enabled = false;
            AbortButton.Enabled = true;
            ComPorts.Enabled = false;
            BinFileBox.Enabled = false;
            string portName = ComPorts.SelectedItem?.ToString() ?? string.Empty;
            using var task = Task.Run(() =>
            {
                Flash(portName, firmware);
            });
            await task;
            BrowseButton.Enabled = true;
            StartButton.Enabled = true;
            AbortButton.Enabled = false;
            ComPorts.Enabled = true;
            BinFileBox.Enabled = true;
        }

        private void ComPorts_DropDown(object sender, EventArgs e)
        {
            EnumerateSerialPorts();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            ClosePort(flashingPort);
        }
    }
}
