namespace RT880_FWFlasher
{
    partial class UI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MainGrid = new TableLayoutPanel();
            label1 = new Label();
            FileNameLabel = new Label();
            BrowseButton = new Button();
            StatusPanel = new TableLayoutPanel();
            StatusLabel = new Label();
            StartButton = new Button();
            AbortButton = new Button();
            ProgressBar = new TrackBar();
            ComPorts = new ComboBox();
            MainGrid.SuspendLayout();
            StatusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ProgressBar).BeginInit();
            SuspendLayout();
            // 
            // MainGrid
            // 
            MainGrid.BackColor = Color.Black;
            MainGrid.ColumnCount = 3;
            MainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            MainGrid.ColumnStyles.Add(new ColumnStyle());
            MainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000076F));
            MainGrid.Controls.Add(label1, 0, 0);
            MainGrid.Controls.Add(FileNameLabel, 0, 1);
            MainGrid.Controls.Add(BrowseButton, 0, 2);
            MainGrid.Controls.Add(StatusPanel, 0, 5);
            MainGrid.Controls.Add(StartButton, 0, 3);
            MainGrid.Controls.Add(AbortButton, 1, 3);
            MainGrid.Controls.Add(ProgressBar, 0, 4);
            MainGrid.Controls.Add(ComPorts, 2, 3);
            MainGrid.Dock = DockStyle.Fill;
            MainGrid.Location = new Point(0, 0);
            MainGrid.Name = "MainGrid";
            MainGrid.RowCount = 6;
            MainGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            MainGrid.RowStyles.Add(new RowStyle());
            MainGrid.RowStyles.Add(new RowStyle());
            MainGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            MainGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            MainGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            MainGrid.Size = new Size(1066, 391);
            MainGrid.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            MainGrid.SetColumnSpan(label1, 3);
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(391, 12);
            label1.Name = "label1";
            label1.Size = new Size(284, 38);
            label1.TabIndex = 1;
            label1.Text = "Firmware Image File";
            // 
            // FileNameLabel
            // 
            FileNameLabel.AutoSize = true;
            FileNameLabel.BackColor = Color.FromArgb(64, 0, 64);
            FileNameLabel.BorderStyle = BorderStyle.FixedSingle;
            MainGrid.SetColumnSpan(FileNameLabel, 3);
            FileNameLabel.Dock = DockStyle.Fill;
            FileNameLabel.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FileNameLabel.ForeColor = Color.White;
            FileNameLabel.Location = new Point(15, 60);
            FileNameLabel.Margin = new Padding(15, 10, 15, 0);
            FileNameLabel.Name = "FileNameLabel";
            FileNameLabel.Padding = new Padding(3);
            FileNameLabel.Size = new Size(1036, 36);
            FileNameLabel.TabIndex = 1;
            FileNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BrowseButton
            // 
            BrowseButton.Anchor = AnchorStyles.None;
            BrowseButton.AutoSize = true;
            BrowseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BrowseButton.BackColor = Color.FromArgb(64, 64, 64);
            MainGrid.SetColumnSpan(BrowseButton, 3);
            BrowseButton.FlatStyle = FlatStyle.Flat;
            BrowseButton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BrowseButton.ForeColor = Color.White;
            BrowseButton.Location = new Point(482, 101);
            BrowseButton.Margin = new Padding(3, 5, 3, 3);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(102, 40);
            BrowseButton.TabIndex = 2;
            BrowseButton.Text = " Browse ";
            BrowseButton.UseVisualStyleBackColor = false;
            BrowseButton.Click += BrowseButton_Click;
            // 
            // StatusPanel
            // 
            StatusPanel.BackColor = Color.FromArgb(0, 0, 64);
            StatusPanel.ColumnCount = 1;
            MainGrid.SetColumnSpan(StatusPanel, 3);
            StatusPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            StatusPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            StatusPanel.Controls.Add(StatusLabel, 0, 0);
            StatusPanel.Dock = DockStyle.Fill;
            StatusPanel.Location = new Point(3, 344);
            StatusPanel.Name = "StatusPanel";
            StatusPanel.RowCount = 1;
            StatusPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            StatusPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            StatusPanel.Size = new Size(1060, 44);
            StatusPanel.TabIndex = 0;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Dock = DockStyle.Fill;
            StatusLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StatusLabel.ForeColor = Color.White;
            StatusLabel.Location = new Point(3, 0);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(1054, 44);
            StatusLabel.TabIndex = 0;
            StatusLabel.Text = "Ready";
            StatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StartButton
            // 
            StartButton.Anchor = AnchorStyles.Right;
            StartButton.AutoSize = true;
            StartButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            StartButton.BackColor = Color.FromArgb(0, 64, 0);
            StartButton.Enabled = false;
            StartButton.FlatStyle = FlatStyle.Flat;
            StartButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StartButton.ForeColor = Color.White;
            StartButton.Location = new Point(376, 185);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(97, 44);
            StartButton.TabIndex = 2;
            StartButton.Text = " Flash ";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButton_Click;
            // 
            // AbortButton
            // 
            AbortButton.Anchor = AnchorStyles.None;
            AbortButton.AutoSize = true;
            AbortButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AbortButton.BackColor = Color.FromArgb(64, 0, 0);
            AbortButton.Enabled = false;
            AbortButton.FlatStyle = FlatStyle.Flat;
            AbortButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AbortButton.ForeColor = Color.White;
            AbortButton.Location = new Point(479, 185);
            AbortButton.Name = "AbortButton";
            AbortButton.Size = new Size(107, 44);
            AbortButton.TabIndex = 2;
            AbortButton.Text = " Abort ";
            AbortButton.UseVisualStyleBackColor = false;
            AbortButton.Click += AbortButton_Click;
            // 
            // ProgressBar
            // 
            MainGrid.SetColumnSpan(ProgressBar, 3);
            ProgressBar.Dock = DockStyle.Fill;
            ProgressBar.Enabled = false;
            ProgressBar.Location = new Point(3, 274);
            ProgressBar.Maximum = 100;
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(1060, 64);
            ProgressBar.TabIndex = 3;
            ProgressBar.TickFrequency = 10;
            ProgressBar.TickStyle = TickStyle.Both;
            // 
            // ComPorts
            // 
            ComPorts.Anchor = AnchorStyles.Left;
            ComPorts.BackColor = Color.Black;
            ComPorts.FlatStyle = FlatStyle.Flat;
            ComPorts.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ComPorts.ForeColor = Color.White;
            ComPorts.FormattingEnabled = true;
            ComPorts.Location = new Point(592, 187);
            ComPorts.Name = "ComPorts";
            ComPorts.Size = new Size(147, 40);
            ComPorts.TabIndex = 4;
            ComPorts.DropDown += ComPorts_DropDown;
            // 
            // UI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 391);
            Controls.Add(MainGrid);
            Name = "UI";
            Text = "RT-880 Firmware Flasher";
            MainGrid.ResumeLayout(false);
            MainGrid.PerformLayout();
            StatusPanel.ResumeLayout(false);
            StatusPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ProgressBar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel MainGrid;
        private TableLayoutPanel StatusPanel;
        private Label StatusLabel;
        private Label label1;
        private Label FileNameLabel;
        private Button BrowseButton;
        private Button StartButton;
        private Button AbortButton;
        private TrackBar ProgressBar;
        private ComboBox ComPorts;
    }
}
