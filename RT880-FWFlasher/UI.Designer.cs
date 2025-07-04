﻿namespace RT880_FWFlasher
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
            StatusPanel = new TableLayoutPanel();
            StatusLabel = new Label();
            StartButton = new Button();
            AbortButton = new Button();
            ProgressBar = new TrackBar();
            BinFileBox = new TextBox();
            BrowseButton = new Button();
            MonitorBox = new TextBox();
            label2 = new Label();
            MonitorTextMode = new CheckBox();
            ComPorts = new ComboBox();
            MonitorButton = new Button();
            SpiBackupButton = new Button();
            MainGrid.SuspendLayout();
            StatusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ProgressBar).BeginInit();
            SuspendLayout();
            // 
            // MainGrid
            // 
            MainGrid.BackColor = Color.Black;
            MainGrid.ColumnCount = 6;
            MainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            MainGrid.ColumnStyles.Add(new ColumnStyle());
            MainGrid.ColumnStyles.Add(new ColumnStyle());
            MainGrid.ColumnStyles.Add(new ColumnStyle());
            MainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            MainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            MainGrid.Controls.Add(label1, 0, 0);
            MainGrid.Controls.Add(StatusPanel, 0, 5);
            MainGrid.Controls.Add(StartButton, 0, 3);
            MainGrid.Controls.Add(AbortButton, 1, 3);
            MainGrid.Controls.Add(ProgressBar, 0, 4);
            MainGrid.Controls.Add(BinFileBox, 0, 1);
            MainGrid.Controls.Add(BrowseButton, 4, 0);
            MainGrid.Controls.Add(MonitorBox, 5, 3);
            MainGrid.Controls.Add(label2, 5, 0);
            MainGrid.Controls.Add(MonitorTextMode, 5, 1);
            MainGrid.Controls.Add(ComPorts, 2, 3);
            MainGrid.Controls.Add(MonitorButton, 3, 3);
            MainGrid.Controls.Add(SpiBackupButton, 4, 3);
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
            MainGrid.Size = new Size(1504, 362);
            MainGrid.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(9, 6);
            label1.Margin = new Padding(9, 0, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(284, 38);
            label1.TabIndex = 1;
            label1.Text = "Firmware Image File";
            // 
            // StatusPanel
            // 
            StatusPanel.BackColor = Color.FromArgb(0, 0, 64);
            StatusPanel.ColumnCount = 1;
            MainGrid.SetColumnSpan(StatusPanel, 5);
            StatusPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            StatusPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            StatusPanel.Controls.Add(StatusLabel, 0, 0);
            StatusPanel.Dock = DockStyle.Fill;
            StatusPanel.Location = new Point(3, 315);
            StatusPanel.Name = "StatusPanel";
            StatusPanel.RowCount = 1;
            StatusPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            StatusPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            StatusPanel.Size = new Size(1058, 44);
            StatusPanel.TabIndex = 0;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Dock = DockStyle.Fill;
            StatusLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StatusLabel.ForeColor = Color.FromArgb(192, 255, 192);
            StatusLabel.Location = new Point(3, 0);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(1052, 44);
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
            StartButton.Location = new Point(229, 145);
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
            AbortButton.Location = new Point(332, 145);
            AbortButton.Name = "AbortButton";
            AbortButton.Size = new Size(107, 44);
            AbortButton.TabIndex = 2;
            AbortButton.Text = " Abort ";
            AbortButton.UseVisualStyleBackColor = false;
            AbortButton.Click += AbortButton_Click;
            // 
            // ProgressBar
            // 
            ProgressBar.BackColor = Color.FromArgb(0, 0, 64);
            MainGrid.SetColumnSpan(ProgressBar, 5);
            ProgressBar.Dock = DockStyle.Fill;
            ProgressBar.Enabled = false;
            ProgressBar.Location = new Point(3, 245);
            ProgressBar.Maximum = 100;
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(1058, 64);
            ProgressBar.TabIndex = 3;
            ProgressBar.TickFrequency = 10;
            ProgressBar.TickStyle = TickStyle.Both;
            // 
            // BinFileBox
            // 
            BinFileBox.BackColor = Color.FromArgb(64, 64, 0);
            MainGrid.SetColumnSpan(BinFileBox, 5);
            BinFileBox.Dock = DockStyle.Fill;
            BinFileBox.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BinFileBox.ForeColor = Color.Gold;
            BinFileBox.Location = new Point(13, 53);
            BinFileBox.Margin = new Padding(13, 3, 13, 3);
            BinFileBox.Name = "BinFileBox";
            BinFileBox.Size = new Size(1038, 36);
            BinFileBox.TabIndex = 5;
            // 
            // BrowseButton
            // 
            BrowseButton.Anchor = AnchorStyles.Right;
            BrowseButton.AutoSize = true;
            BrowseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BrowseButton.BackColor = Color.FromArgb(64, 64, 64);
            BrowseButton.FlatStyle = FlatStyle.Flat;
            BrowseButton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BrowseButton.ForeColor = Color.White;
            BrowseButton.Location = new Point(948, 6);
            BrowseButton.Margin = new Padding(3, 5, 14, 3);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(102, 40);
            BrowseButton.TabIndex = 2;
            BrowseButton.Text = " Browse ";
            BrowseButton.UseVisualStyleBackColor = false;
            BrowseButton.Click += BrowseButton_Click;
            // 
            // MonitorBox
            // 
            MonitorBox.BackColor = Color.FromArgb(32, 32, 32);
            MonitorBox.BorderStyle = BorderStyle.FixedSingle;
            MonitorBox.Dock = DockStyle.Fill;
            MonitorBox.ForeColor = Color.White;
            MonitorBox.Location = new Point(1067, 95);
            MonitorBox.Multiline = true;
            MonitorBox.Name = "MonitorBox";
            MainGrid.SetRowSpan(MonitorBox, 3);
            MonitorBox.ScrollBars = ScrollBars.Vertical;
            MonitorBox.Size = new Size(434, 264);
            MonitorBox.TabIndex = 6;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1073, 6);
            label2.Margin = new Padding(9, 0, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(236, 38);
            label2.TabIndex = 1;
            label2.Text = "Monitor Console";
            // 
            // MonitorTextMode
            // 
            MonitorTextMode.AutoSize = true;
            MonitorTextMode.ForeColor = Color.White;
            MonitorTextMode.Location = new Point(1084, 53);
            MonitorTextMode.Margin = new Padding(20, 3, 3, 3);
            MonitorTextMode.Name = "MonitorTextMode";
            MonitorTextMode.Size = new Size(120, 29);
            MonitorTextMode.TabIndex = 7;
            MonitorTextMode.Text = "Text Mode";
            MonitorTextMode.UseVisualStyleBackColor = true;
            // 
            // ComPorts
            // 
            ComPorts.Anchor = AnchorStyles.Left;
            ComPorts.BackColor = Color.Black;
            ComPorts.DropDownStyle = ComboBoxStyle.DropDownList;
            ComPorts.FlatStyle = FlatStyle.Flat;
            ComPorts.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ComPorts.ForeColor = Color.White;
            ComPorts.FormattingEnabled = true;
            ComPorts.Location = new Point(445, 147);
            ComPorts.Name = "ComPorts";
            ComPorts.Size = new Size(147, 40);
            ComPorts.TabIndex = 4;
            ComPorts.DropDown += ComPorts_DropDown;
            // 
            // MonitorButton
            // 
            MonitorButton.Anchor = AnchorStyles.Left;
            MonitorButton.AutoSize = true;
            MonitorButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            MonitorButton.BackColor = Color.FromArgb(0, 64, 64);
            MonitorButton.FlatStyle = FlatStyle.Flat;
            MonitorButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MonitorButton.ForeColor = Color.White;
            MonitorButton.Location = new Point(598, 145);
            MonitorButton.Name = "MonitorButton";
            MonitorButton.Size = new Size(134, 44);
            MonitorButton.TabIndex = 2;
            MonitorButton.Text = " Monitor ";
            MonitorButton.UseVisualStyleBackColor = false;
            MonitorButton.Click += MonitorButton_Click;
            // 
            // SpiBackupButton
            // 
            SpiBackupButton.Anchor = AnchorStyles.Left;
            SpiBackupButton.AutoSize = true;
            SpiBackupButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SpiBackupButton.BackColor = Color.FromArgb(64, 0, 64);
            SpiBackupButton.FlatStyle = FlatStyle.Flat;
            SpiBackupButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SpiBackupButton.ForeColor = Color.White;
            SpiBackupButton.Location = new Point(738, 145);
            SpiBackupButton.Name = "SpiBackupButton";
            SpiBackupButton.Size = new Size(166, 44);
            SpiBackupButton.TabIndex = 2;
            SpiBackupButton.Text = " SPI Backup ";
            SpiBackupButton.UseVisualStyleBackColor = false;
            SpiBackupButton.Click += SpiBackupButton_Click;
            // 
            // UI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1504, 362);
            Controls.Add(MainGrid);
            Name = "UI";
            Text = "RT-880 Firmware Flasher V1.2";
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
        private Button BrowseButton;
        private Button StartButton;
        private Button AbortButton;
        private TrackBar ProgressBar;
        private ComboBox ComPorts;
        private TextBox BinFileBox;
        private Button MonitorButton;
        private TextBox MonitorBox;
        private Label label2;
        private CheckBox MonitorTextMode;
        private Button SpiBackupButton;
    }
}
