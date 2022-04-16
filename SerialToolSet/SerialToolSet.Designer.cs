
namespace SerialToolSet
{
    partial class SerialToolSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSerialSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmboPort = new System.Windows.Forms.ToolStripComboBox();
            this.namedPipesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmboBaud = new System.Windows.Forms.ToolStripComboBox();
            this.parityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmboParity = new System.Windows.Forms.ToolStripComboBox();
            this.dataBitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmboDataBits = new System.Windows.Forms.ToolStripComboBox();
            this.stopBitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmboStopBits = new System.Windows.Forms.ToolStripComboBox();
            this.loggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoggingEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEncoding = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuASCII = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuData8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checksumsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.txtRecieve = new System.Windows.Forms.TextBox();
            this.txtChecksum = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.statConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.mnuByteOrder = new System.Windows.Forms.ToolStripComboBox();
            this.checksumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmboChecksum = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statConnection});
            this.statusStrip1.Location = new System.Drawing.Point(0, 474);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(712, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(712, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnect,
            this.mnuDisconnect,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnuConnect
            // 
            this.mnuConnect.Name = "mnuConnect";
            this.mnuConnect.Size = new System.Drawing.Size(133, 22);
            this.mnuConnect.Text = "&Connect";
            this.mnuConnect.Click += new System.EventHandler(this.mnuConnect_Click);
            // 
            // mnuDisconnect
            // 
            this.mnuDisconnect.Enabled = false;
            this.mnuDisconnect.Name = "mnuDisconnect";
            this.mnuDisconnect.Size = new System.Drawing.Size(133, 22);
            this.mnuDisconnect.Text = "&Disconnect";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(133, 22);
            this.mnuExit.Text = "&Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSerialSettings,
            this.loggingToolStripMenuItem,
            this.mnuEncoding,
            this.checksumToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // mnuSerialSettings
            // 
            this.mnuSerialSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portToolStripMenuItem,
            this.baudToolStripMenuItem,
            this.parityToolStripMenuItem,
            this.dataBitsToolStripMenuItem,
            this.stopBitsToolStripMenuItem});
            this.mnuSerialSettings.Name = "mnuSerialSettings";
            this.mnuSerialSettings.Size = new System.Drawing.Size(180, 22);
            this.mnuSerialSettings.Text = "Serial &Port";
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmboPort,
            this.namedPipesToolStripMenuItem,
            this.mnuRefresh});
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.portToolStripMenuItem.Text = "&Com Port";
            // 
            // cmboPort
            // 
            this.cmboPort.Name = "cmboPort";
            this.cmboPort.Size = new System.Drawing.Size(121, 23);
            // 
            // namedPipesToolStripMenuItem
            // 
            this.namedPipesToolStripMenuItem.Name = "namedPipesToolStripMenuItem";
            this.namedPipesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.namedPipesToolStripMenuItem.Text = "&Named Pipes...";
            // 
            // baudToolStripMenuItem
            // 
            this.baudToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmboBaud});
            this.baudToolStripMenuItem.Name = "baudToolStripMenuItem";
            this.baudToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.baudToolStripMenuItem.Text = "&Baud";
            // 
            // cmboBaud
            // 
            this.cmboBaud.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmboBaud.Name = "cmboBaud";
            this.cmboBaud.Size = new System.Drawing.Size(121, 23);
            // 
            // parityToolStripMenuItem
            // 
            this.parityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmboParity});
            this.parityToolStripMenuItem.Name = "parityToolStripMenuItem";
            this.parityToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.parityToolStripMenuItem.Text = "&Parity";
            // 
            // cmboParity
            // 
            this.cmboParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cmboParity.Name = "cmboParity";
            this.cmboParity.Size = new System.Drawing.Size(121, 23);
            // 
            // dataBitsToolStripMenuItem
            // 
            this.dataBitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmboDataBits});
            this.dataBitsToolStripMenuItem.Name = "dataBitsToolStripMenuItem";
            this.dataBitsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dataBitsToolStripMenuItem.Text = "&Data Bits";
            // 
            // cmboDataBits
            // 
            this.cmboDataBits.Items.AddRange(new object[] {
            "8"});
            this.cmboDataBits.Name = "cmboDataBits";
            this.cmboDataBits.Size = new System.Drawing.Size(121, 23);
            // 
            // stopBitsToolStripMenuItem
            // 
            this.stopBitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmboStopBits});
            this.stopBitsToolStripMenuItem.Name = "stopBitsToolStripMenuItem";
            this.stopBitsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopBitsToolStripMenuItem.Text = "&Stop Bits";
            // 
            // cmboStopBits
            // 
            this.cmboStopBits.Name = "cmboStopBits";
            this.cmboStopBits.Size = new System.Drawing.Size(121, 23);
            // 
            // loggingToolStripMenuItem
            // 
            this.loggingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogSettings,
            this.mnuLoggingEnabled});
            this.loggingToolStripMenuItem.Name = "loggingToolStripMenuItem";
            this.loggingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loggingToolStripMenuItem.Text = "&Logging";
            // 
            // mnuLogSettings
            // 
            this.mnuLogSettings.Name = "mnuLogSettings";
            this.mnuLogSettings.Size = new System.Drawing.Size(141, 22);
            this.mnuLogSettings.Text = "Log &Details...";
            this.mnuLogSettings.Click += new System.EventHandler(this.mnuLogSettings_Click);
            // 
            // mnuLoggingEnabled
            // 
            this.mnuLoggingEnabled.CheckOnClick = true;
            this.mnuLoggingEnabled.Name = "mnuLoggingEnabled";
            this.mnuLoggingEnabled.Size = new System.Drawing.Size(141, 22);
            this.mnuLoggingEnabled.Text = "&Enabled";
            // 
            // mnuEncoding
            // 
            this.mnuEncoding.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuASCII,
            this.mnuData8,
            this.mnuByteOrder});
            this.mnuEncoding.Name = "mnuEncoding";
            this.mnuEncoding.Size = new System.Drawing.Size(180, 22);
            this.mnuEncoding.Text = "&Encoding";
            // 
            // mnuASCII
            // 
            this.mnuASCII.Checked = true;
            this.mnuASCII.CheckOnClick = true;
            this.mnuASCII.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuASCII.Name = "mnuASCII";
            this.mnuASCII.Size = new System.Drawing.Size(181, 22);
            this.mnuASCII.Text = "&ASCII";
            // 
            // mnuData8
            // 
            this.mnuData8.CheckOnClick = true;
            this.mnuData8.Name = "mnuData8";
            this.mnuData8.Size = new System.Drawing.Size(181, 22);
            this.mnuData8.Text = "&8-bit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checksumsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // checksumsToolStripMenuItem
            // 
            this.checksumsToolStripMenuItem.Name = "checksumsToolStripMenuItem";
            this.checksumsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.checksumsToolStripMenuItem.Text = "&Checksums...";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // txtRecieve
            // 
            this.txtRecieve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecieve.Location = new System.Drawing.Point(12, 27);
            this.txtRecieve.Multiline = true;
            this.txtRecieve.Name = "txtRecieve";
            this.txtRecieve.ReadOnly = true;
            this.txtRecieve.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRecieve.Size = new System.Drawing.Size(692, 414);
            this.txtRecieve.TabIndex = 3;
            this.txtRecieve.TabStop = false;
            // 
            // txtChecksum
            // 
            this.txtChecksum.Location = new System.Drawing.Point(582, 447);
            this.txtChecksum.Name = "txtChecksum";
            this.txtChecksum.ReadOnly = true;
            this.txtChecksum.Size = new System.Drawing.Size(57, 20);
            this.txtChecksum.TabIndex = 17;
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(645, 445);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(59, 23);
            this.btnSend.TabIndex = 16;
            this.btnSend.Text = "&Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend.Enabled = false;
            this.txtSend.Location = new System.Drawing.Point(12, 447);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(564, 20);
            this.txtSend.TabIndex = 15;
            this.txtSend.TextChanged += new System.EventHandler(this.txtSend_TextChanged);
            this.txtSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSend_KeyDown);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(181, 22);
            this.mnuRefresh.Text = "&Refresh";
            // 
            // statConnection
            // 
            this.statConnection.Name = "statConnection";
            this.statConnection.Size = new System.Drawing.Size(79, 17);
            this.statConnection.Text = "Disconnected";
            // 
            // mnuByteOrder
            // 
            this.mnuByteOrder.Items.AddRange(new object[] {
            "MSB First",
            "LSB First"});
            this.mnuByteOrder.Name = "mnuByteOrder";
            this.mnuByteOrder.Size = new System.Drawing.Size(121, 23);
            // 
            // checksumToolStripMenuItem
            // 
            this.checksumToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmboChecksum});
            this.checksumToolStripMenuItem.Name = "checksumToolStripMenuItem";
            this.checksumToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.checksumToolStripMenuItem.Text = "&Checksum";
            // 
            // cmboChecksum
            // 
            this.cmboChecksum.Items.AddRange(new object[] {
            "None",
            "7-bit 2\'s comp sum"});
            this.cmboChecksum.Name = "cmboChecksum";
            this.cmboChecksum.Size = new System.Drawing.Size(121, 23);
            // 
            // SerialToolSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 496);
            this.Controls.Add(this.txtChecksum);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.txtRecieve);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SerialToolSet";
            this.Text = "Serial Tool Set";
            this.Load += new System.EventHandler(this.SerialToolSet_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSerialSettings;
        private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baudToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ToolStripComboBox cmboPort;
        private System.Windows.Forms.ToolStripMenuItem namedPipesToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cmboBaud;
        private System.Windows.Forms.ToolStripMenuItem mnuConnect;
        private System.Windows.Forms.ToolStripMenuItem mnuDisconnect;
        private System.Windows.Forms.ToolStripMenuItem parityToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cmboParity;
        private System.Windows.Forms.ToolStripMenuItem dataBitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopBitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cmboStopBits;
        private System.Windows.Forms.ToolStripMenuItem checksumsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loggingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuLogSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuLoggingEnabled;
        private System.Windows.Forms.ToolStripMenuItem mnuEncoding;
        private System.Windows.Forms.ToolStripMenuItem mnuASCII;
        private System.Windows.Forms.ToolStripMenuItem mnuData8;
        private System.Windows.Forms.TextBox txtRecieve;
        private System.Windows.Forms.ToolStripComboBox cmboDataBits;
        private System.Windows.Forms.TextBox txtChecksum;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripStatusLabel statConnection;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripComboBox mnuByteOrder;
        private System.Windows.Forms.ToolStripMenuItem checksumToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cmboChecksum;
    }
}

