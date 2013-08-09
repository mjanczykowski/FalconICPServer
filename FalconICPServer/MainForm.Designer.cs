namespace FalconICPServer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tsToolbar = new System.Windows.Forms.ToolStrip();
            this.tsbStart = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabConnection = new System.Windows.Forms.TabPage();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.chkMinimizeToSystemTray = new System.Windows.Forms.CheckBox();
            this.chkLaunchMinimized = new System.Windows.Forms.CheckBox();
            this.chkRunServerOnLaunch = new System.Windows.Forms.CheckBox();
            this.chkLaunchAtStartup = new System.Windows.Forms.CheckBox();
            this.gbPerformance = new System.Windows.Forms.GroupBox();
            this.nudUpdatePeriod = new System.Windows.Forms.NumericUpDown();
            this.cbPriority = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelMilliseconds = new System.Windows.Forms.Label();
            this.labelUpdatePeriod = new System.Windows.Forms.Label();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.lbClientIP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbServerIP = new System.Windows.Forms.Label();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.labelServerPort = new System.Windows.Forms.Label();
            this.labelServerIP = new System.Windows.Forms.Label();
            this.tabKeystrokes = new System.Windows.Forms.TabPage();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.labelENTR = new System.Windows.Forms.Label();
            this.labelICSDown = new System.Windows.Forms.Label();
            this.labelICSUp = new System.Windows.Forms.Label();
            this.labelICP0 = new System.Windows.Forms.Label();
            this.labelICP9 = new System.Windows.Forms.Label();
            this.labelICP8 = new System.Windows.Forms.Label();
            this.labelICP7 = new System.Windows.Forms.Label();
            this.labelICP6 = new System.Windows.Forms.Label();
            this.labelICP5 = new System.Windows.Forms.Label();
            this.labelICP4 = new System.Windows.Forms.Label();
            this.tbSimICPEnter = new System.Windows.Forms.TextBox();
            this.tbSimICPPrevious = new System.Windows.Forms.TextBox();
            this.tbSimICPNext = new System.Windows.Forms.TextBox();
            this.tbSimICPZERO = new System.Windows.Forms.TextBox();
            this.tbSimICPNINE = new System.Windows.Forms.TextBox();
            this.tbSimICPEIGHT = new System.Windows.Forms.TextBox();
            this.tbSimICPMark = new System.Windows.Forms.TextBox();
            this.tbSimICPSIX = new System.Windows.Forms.TextBox();
            this.tbSimICPCrus = new System.Windows.Forms.TextBox();
            this.tbSimICPStpt = new System.Windows.Forms.TextBox();
            this.tbSimICPTHREE = new System.Windows.Forms.TextBox();
            this.tbSimICPALOW = new System.Windows.Forms.TextBox();
            this.labelICP3 = new System.Windows.Forms.Label();
            this.tbSimICPTILS = new System.Windows.Forms.TextBox();
            this.labelICP2 = new System.Windows.Forms.Label();
            this.labelICP1 = new System.Windows.Forms.Label();
            this.labelNorm = new System.Windows.Forms.Label();
            this.labelWarnReset = new System.Windows.Forms.Label();
            this.labelDriftCO = new System.Windows.Forms.Label();
            this.labelRCL = new System.Windows.Forms.Label();
            this.labelCOM1 = new System.Windows.Forms.Label();
            this.labelDCSSeq = new System.Windows.Forms.Label();
            this.labelDCSRet = new System.Windows.Forms.Label();
            this.labelDCSDown = new System.Windows.Forms.Label();
            this.labelDCSUp = new System.Windows.Forms.Label();
            this.labelAG = new System.Windows.Forms.Label();
            this.labelAA = new System.Windows.Forms.Label();
            this.tbSimWarnReset = new System.Windows.Forms.TextBox();
            this.tbSimDriftCOOff = new System.Windows.Forms.TextBox();
            this.tbSimDriftCOOn = new System.Windows.Forms.TextBox();
            this.tbSimICPDEDSEQ = new System.Windows.Forms.TextBox();
            this.tbSimICPResetDED = new System.Windows.Forms.TextBox();
            this.tbSimICPDEDDOWN = new System.Windows.Forms.TextBox();
            this.tbSimICPDEDUP = new System.Windows.Forms.TextBox();
            this.tbSimICPAG = new System.Windows.Forms.TextBox();
            this.tbSimICPAA = new System.Windows.Forms.TextBox();
            this.tbSimICPLIST = new System.Windows.Forms.TextBox();
            this.tbSimICPCom2 = new System.Windows.Forms.TextBox();
            this.tbSimICPCom1 = new System.Windows.Forms.TextBox();
            this.tbSimICPCLEAR = new System.Windows.Forms.TextBox();
            this.labelLIST = new System.Windows.Forms.Label();
            this.labelCOM2 = new System.Windows.Forms.Label();
            this.panelKeyfile = new System.Windows.Forms.Panel();
            this.tbKeyfile = new System.Windows.Forms.TextBox();
            this.btnSaveKeyfile = new System.Windows.Forms.Button();
            this.btnOpenKeyfile = new System.Windows.Forms.Button();
            this.labelKeyfile = new System.Windows.Forms.Label();
            this.nfyTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuTrayNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miNotifyStart = new System.Windows.Forms.ToolStripMenuItem();
            this.miNotifyStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miNotifySettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miNotifyExit = new System.Windows.Forms.ToolStripMenuItem();
            this.labelVersion = new System.Windows.Forms.Label();
            this.lbProductVersion = new System.Windows.Forms.Label();
            this.tsToolbar.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabConnection.SuspendLayout();
            this.gbGeneral.SuspendLayout();
            this.gbPerformance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdatePeriod)).BeginInit();
            this.gbConnection.SuspendLayout();
            this.tabKeystrokes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelKeyfile.SuspendLayout();
            this.mnuTrayNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsToolbar
            // 
            this.tsToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbStart,
            this.tsbStop});
            this.tsToolbar.Location = new System.Drawing.Point(0, 0);
            this.tsToolbar.Name = "tsToolbar";
            this.tsToolbar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsToolbar.Size = new System.Drawing.Size(331, 25);
            this.tsToolbar.TabIndex = 0;
            this.tsToolbar.Text = "toolStrip1";
            // 
            // tsbStart
            // 
            this.tsbStart.Image = global::FalconICPServer.Properties.Resources.start;
            this.tsbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStart.Name = "tsbStart";
            this.tsbStart.Size = new System.Drawing.Size(86, 22);
            this.tsbStart.Text = "Start Server";
            this.tsbStart.Click += new System.EventHandler(this.tsbStart_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.Enabled = false;
            this.tsbStop.Image = global::FalconICPServer.Properties.Resources.stop;
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(86, 22);
            this.tsbStop.Text = "Stop Server";
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabConnection);
            this.tabControl.Controls.Add(this.tabKeystrokes);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(331, 363);
            this.tabControl.TabIndex = 1;
            // 
            // tabConnection
            // 
            this.tabConnection.Controls.Add(this.lbProductVersion);
            this.tabConnection.Controls.Add(this.labelVersion);
            this.tabConnection.Controls.Add(this.gbGeneral);
            this.tabConnection.Controls.Add(this.gbPerformance);
            this.tabConnection.Controls.Add(this.gbConnection);
            this.tabConnection.Location = new System.Drawing.Point(4, 22);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnection.Size = new System.Drawing.Size(323, 337);
            this.tabConnection.TabIndex = 0;
            this.tabConnection.Text = "Connection Settings";
            this.tabConnection.UseVisualStyleBackColor = true;
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.chkMinimizeToSystemTray);
            this.gbGeneral.Controls.Add(this.chkLaunchMinimized);
            this.gbGeneral.Controls.Add(this.chkRunServerOnLaunch);
            this.gbGeneral.Controls.Add(this.chkLaunchAtStartup);
            this.gbGeneral.Location = new System.Drawing.Point(3, 190);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(317, 112);
            this.gbGeneral.TabIndex = 2;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "General Settings";
            // 
            // chkMinimizeToSystemTray
            // 
            this.chkMinimizeToSystemTray.AutoSize = true;
            this.chkMinimizeToSystemTray.Location = new System.Drawing.Point(6, 88);
            this.chkMinimizeToSystemTray.Name = "chkMinimizeToSystemTray";
            this.chkMinimizeToSystemTray.Size = new System.Drawing.Size(139, 17);
            this.chkMinimizeToSystemTray.TabIndex = 3;
            this.chkMinimizeToSystemTray.Text = "Minimize to System Tray";
            this.chkMinimizeToSystemTray.UseVisualStyleBackColor = true;
            this.chkMinimizeToSystemTray.CheckedChanged += new System.EventHandler(this.chkMinimizeToSystemTray_CheckedChanged);
            // 
            // chkLaunchMinimized
            // 
            this.chkLaunchMinimized.AutoSize = true;
            this.chkLaunchMinimized.Location = new System.Drawing.Point(6, 65);
            this.chkLaunchMinimized.Name = "chkLaunchMinimized";
            this.chkLaunchMinimized.Size = new System.Drawing.Size(110, 17);
            this.chkLaunchMinimized.TabIndex = 2;
            this.chkLaunchMinimized.Text = "Launch minimized";
            this.chkLaunchMinimized.UseVisualStyleBackColor = true;
            this.chkLaunchMinimized.CheckedChanged += new System.EventHandler(this.chkLaunchMinimized_CheckedChanged);
            // 
            // chkRunServerOnLaunch
            // 
            this.chkRunServerOnLaunch.AutoSize = true;
            this.chkRunServerOnLaunch.Location = new System.Drawing.Point(6, 42);
            this.chkRunServerOnLaunch.Name = "chkRunServerOnLaunch";
            this.chkRunServerOnLaunch.Size = new System.Drawing.Size(128, 17);
            this.chkRunServerOnLaunch.TabIndex = 1;
            this.chkRunServerOnLaunch.Text = "Run server on launch";
            this.chkRunServerOnLaunch.UseVisualStyleBackColor = true;
            this.chkRunServerOnLaunch.CheckedChanged += new System.EventHandler(this.chkRunServerOnLaunch_CheckedChanged);
            // 
            // chkLaunchAtStartup
            // 
            this.chkLaunchAtStartup.AutoSize = true;
            this.chkLaunchAtStartup.Location = new System.Drawing.Point(6, 19);
            this.chkLaunchAtStartup.Name = "chkLaunchAtStartup";
            this.chkLaunchAtStartup.Size = new System.Drawing.Size(148, 17);
            this.chkLaunchAtStartup.TabIndex = 0;
            this.chkLaunchAtStartup.Text = "Launch at System Startup";
            this.chkLaunchAtStartup.UseVisualStyleBackColor = true;
            this.chkLaunchAtStartup.CheckedChanged += new System.EventHandler(this.chkLaunchAtStartup_CheckedChanged);
            // 
            // gbPerformance
            // 
            this.gbPerformance.Controls.Add(this.nudUpdatePeriod);
            this.gbPerformance.Controls.Add(this.cbPriority);
            this.gbPerformance.Controls.Add(this.label5);
            this.gbPerformance.Controls.Add(this.labelMilliseconds);
            this.gbPerformance.Controls.Add(this.labelUpdatePeriod);
            this.gbPerformance.Location = new System.Drawing.Point(3, 109);
            this.gbPerformance.Name = "gbPerformance";
            this.gbPerformance.Size = new System.Drawing.Size(317, 75);
            this.gbPerformance.TabIndex = 1;
            this.gbPerformance.TabStop = false;
            this.gbPerformance.Text = "Performance";
            // 
            // nudUpdatePeriod
            // 
            this.nudUpdatePeriod.Location = new System.Drawing.Point(109, 19);
            this.nudUpdatePeriod.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudUpdatePeriod.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudUpdatePeriod.Name = "nudUpdatePeriod";
            this.nudUpdatePeriod.Size = new System.Drawing.Size(53, 20);
            this.nudUpdatePeriod.TabIndex = 8;
            this.nudUpdatePeriod.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudUpdatePeriod.ValueChanged += new System.EventHandler(this.nudUpdatePeriod_ValueChanged);
            // 
            // cbPriority
            // 
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.Location = new System.Drawing.Point(109, 41);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(79, 21);
            this.cbPriority.TabIndex = 7;
            this.cbPriority.SelectedIndexChanged += new System.EventHandler(this.cbPriority_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Thread priority:";
            // 
            // labelMilliseconds
            // 
            this.labelMilliseconds.AutoSize = true;
            this.labelMilliseconds.Location = new System.Drawing.Point(168, 21);
            this.labelMilliseconds.Name = "labelMilliseconds";
            this.labelMilliseconds.Size = new System.Drawing.Size(20, 13);
            this.labelMilliseconds.TabIndex = 5;
            this.labelMilliseconds.Text = "ms";
            // 
            // labelUpdatePeriod
            // 
            this.labelUpdatePeriod.AutoSize = true;
            this.labelUpdatePeriod.Location = new System.Drawing.Point(3, 21);
            this.labelUpdatePeriod.Name = "labelUpdatePeriod";
            this.labelUpdatePeriod.Size = new System.Drawing.Size(77, 13);
            this.labelUpdatePeriod.TabIndex = 2;
            this.labelUpdatePeriod.Text = "Update period:";
            // 
            // gbConnection
            // 
            this.gbConnection.AutoSize = true;
            this.gbConnection.Controls.Add(this.lbClientIP);
            this.gbConnection.Controls.Add(this.label2);
            this.gbConnection.Controls.Add(this.lbServerIP);
            this.gbConnection.Controls.Add(this.tbServerPort);
            this.gbConnection.Controls.Add(this.labelServerPort);
            this.gbConnection.Controls.Add(this.labelServerIP);
            this.gbConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbConnection.Location = new System.Drawing.Point(3, 3);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(317, 100);
            this.gbConnection.TabIndex = 0;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection";
            // 
            // lbClientIP
            // 
            this.lbClientIP.AutoSize = true;
            this.lbClientIP.Location = new System.Drawing.Point(107, 71);
            this.lbClientIP.Name = "lbClientIP";
            this.lbClientIP.Size = new System.Drawing.Size(10, 13);
            this.lbClientIP.TabIndex = 6;
            this.lbClientIP.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Connected client:";
            // 
            // lbServerIP
            // 
            this.lbServerIP.AutoSize = true;
            this.lbServerIP.Location = new System.Drawing.Point(107, 21);
            this.lbServerIP.Name = "lbServerIP";
            this.lbServerIP.Size = new System.Drawing.Size(88, 13);
            this.lbServerIP.TabIndex = 4;
            this.lbServerIP.Text = "255.255.255.255";
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(109, 43);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(40, 20);
            this.tbServerPort.TabIndex = 3;
            this.tbServerPort.Text = "30456";
            this.tbServerPort.Leave += new System.EventHandler(this.tbServerPort_Leave);
            // 
            // labelServerPort
            // 
            this.labelServerPort.AutoSize = true;
            this.labelServerPort.Location = new System.Drawing.Point(3, 46);
            this.labelServerPort.Name = "labelServerPort";
            this.labelServerPort.Size = new System.Drawing.Size(63, 13);
            this.labelServerPort.TabIndex = 2;
            this.labelServerPort.Text = "Server Port:";
            // 
            // labelServerIP
            // 
            this.labelServerIP.AutoSize = true;
            this.labelServerIP.Location = new System.Drawing.Point(3, 21);
            this.labelServerIP.Name = "labelServerIP";
            this.labelServerIP.Size = new System.Drawing.Size(79, 13);
            this.labelServerIP.TabIndex = 1;
            this.labelServerIP.Text = "Server local IP:";
            // 
            // tabKeystrokes
            // 
            this.tabKeystrokes.Controls.Add(this.splitContainer);
            this.tabKeystrokes.Controls.Add(this.panelKeyfile);
            this.tabKeystrokes.Location = new System.Drawing.Point(4, 22);
            this.tabKeystrokes.Name = "tabKeystrokes";
            this.tabKeystrokes.Padding = new System.Windows.Forms.Padding(3);
            this.tabKeystrokes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabKeystrokes.Size = new System.Drawing.Size(323, 337);
            this.tabKeystrokes.TabIndex = 1;
            this.tabKeystrokes.Text = "Keystrokes";
            this.tabKeystrokes.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(3, 33);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.labelENTR);
            this.splitContainer.Panel1.Controls.Add(this.labelICSDown);
            this.splitContainer.Panel1.Controls.Add(this.labelICSUp);
            this.splitContainer.Panel1.Controls.Add(this.labelICP0);
            this.splitContainer.Panel1.Controls.Add(this.labelICP9);
            this.splitContainer.Panel1.Controls.Add(this.labelICP8);
            this.splitContainer.Panel1.Controls.Add(this.labelICP7);
            this.splitContainer.Panel1.Controls.Add(this.labelICP6);
            this.splitContainer.Panel1.Controls.Add(this.labelICP5);
            this.splitContainer.Panel1.Controls.Add(this.labelICP4);
            this.splitContainer.Panel1.Controls.Add(this.tbSimICPEnter);
            this.splitContainer.Panel1.Controls.Add(this.tbSimICPPrevious);
            this.splitContainer.Panel1.Controls.Add(this.tbSimICPNext);
            this.splitContainer.Panel1.Controls.Add(this.tbSimICPZERO);
            this.splitContainer.Panel1.Controls.Add(this.tbSimICPNINE);
            this.splitContainer.Panel1.Controls.Add(this.tbSimICPEIGHT);
            this.splitContainer.Panel1.Controls.Add(this.tbSimICPMark);
            this.splitContainer.Panel1.Controls.Add(this.tbSimICPSIX);
            this.splitContainer.Panel1.Controls.Add(this.tbSimICPCrus);
            this.splitContainer.Panel1.Controls.Add(this.tbSimICPStpt);
            this.splitContainer.Panel1.Controls.Add(this.tbSimICPTHREE);
            this.splitContainer.Panel1.Controls.Add(this.tbSimICPALOW);
            this.splitContainer.Panel1.Controls.Add(this.labelICP3);
            this.splitContainer.Panel1.Controls.Add(this.tbSimICPTILS);
            this.splitContainer.Panel1.Controls.Add(this.labelICP2);
            this.splitContainer.Panel1.Controls.Add(this.labelICP1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.labelNorm);
            this.splitContainer.Panel2.Controls.Add(this.labelWarnReset);
            this.splitContainer.Panel2.Controls.Add(this.labelDriftCO);
            this.splitContainer.Panel2.Controls.Add(this.labelRCL);
            this.splitContainer.Panel2.Controls.Add(this.labelCOM1);
            this.splitContainer.Panel2.Controls.Add(this.labelDCSSeq);
            this.splitContainer.Panel2.Controls.Add(this.labelDCSRet);
            this.splitContainer.Panel2.Controls.Add(this.labelDCSDown);
            this.splitContainer.Panel2.Controls.Add(this.labelDCSUp);
            this.splitContainer.Panel2.Controls.Add(this.labelAG);
            this.splitContainer.Panel2.Controls.Add(this.labelAA);
            this.splitContainer.Panel2.Controls.Add(this.tbSimWarnReset);
            this.splitContainer.Panel2.Controls.Add(this.tbSimDriftCOOff);
            this.splitContainer.Panel2.Controls.Add(this.tbSimDriftCOOn);
            this.splitContainer.Panel2.Controls.Add(this.tbSimICPDEDSEQ);
            this.splitContainer.Panel2.Controls.Add(this.tbSimICPResetDED);
            this.splitContainer.Panel2.Controls.Add(this.tbSimICPDEDDOWN);
            this.splitContainer.Panel2.Controls.Add(this.tbSimICPDEDUP);
            this.splitContainer.Panel2.Controls.Add(this.tbSimICPAG);
            this.splitContainer.Panel2.Controls.Add(this.tbSimICPAA);
            this.splitContainer.Panel2.Controls.Add(this.tbSimICPLIST);
            this.splitContainer.Panel2.Controls.Add(this.tbSimICPCom2);
            this.splitContainer.Panel2.Controls.Add(this.tbSimICPCom1);
            this.splitContainer.Panel2.Controls.Add(this.tbSimICPCLEAR);
            this.splitContainer.Panel2.Controls.Add(this.labelLIST);
            this.splitContainer.Panel2.Controls.Add(this.labelCOM2);
            this.splitContainer.Size = new System.Drawing.Size(317, 301);
            this.splitContainer.SplitterDistance = 156;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 5;
            // 
            // labelENTR
            // 
            this.labelENTR.AutoSize = true;
            this.labelENTR.Location = new System.Drawing.Point(-3, 283);
            this.labelENTR.Name = "labelENTR";
            this.labelENTR.Size = new System.Drawing.Size(40, 13);
            this.labelENTR.TabIndex = 34;
            this.labelENTR.Text = "ENTR:";
            // 
            // labelICSDown
            // 
            this.labelICSDown.AutoSize = true;
            this.labelICSDown.Location = new System.Drawing.Point(-3, 261);
            this.labelICSDown.Name = "labelICSDown";
            this.labelICSDown.Size = new System.Drawing.Size(58, 13);
            this.labelICSDown.TabIndex = 33;
            this.labelICSDown.Text = "ICP Down:";
            // 
            // labelICSUp
            // 
            this.labelICSUp.AutoSize = true;
            this.labelICSUp.Location = new System.Drawing.Point(-3, 237);
            this.labelICSUp.Name = "labelICSUp";
            this.labelICSUp.Size = new System.Drawing.Size(44, 13);
            this.labelICSUp.TabIndex = 32;
            this.labelICSUp.Text = "ICP Up:";
            // 
            // labelICP0
            // 
            this.labelICP0.AutoSize = true;
            this.labelICP0.Location = new System.Drawing.Point(-3, 215);
            this.labelICP0.Name = "labelICP0";
            this.labelICP0.Size = new System.Drawing.Size(36, 13);
            this.labelICP0.TabIndex = 31;
            this.labelICP0.Text = "ICP 0:";
            // 
            // labelICP9
            // 
            this.labelICP9.AutoSize = true;
            this.labelICP9.Location = new System.Drawing.Point(-3, 192);
            this.labelICP9.Name = "labelICP9";
            this.labelICP9.Size = new System.Drawing.Size(36, 13);
            this.labelICP9.TabIndex = 30;
            this.labelICP9.Text = "ICP 9:";
            // 
            // labelICP8
            // 
            this.labelICP8.AutoSize = true;
            this.labelICP8.Location = new System.Drawing.Point(-3, 169);
            this.labelICP8.Name = "labelICP8";
            this.labelICP8.Size = new System.Drawing.Size(36, 13);
            this.labelICP8.TabIndex = 29;
            this.labelICP8.Text = "ICP 8:";
            // 
            // labelICP7
            // 
            this.labelICP7.AutoSize = true;
            this.labelICP7.Location = new System.Drawing.Point(-3, 146);
            this.labelICP7.Name = "labelICP7";
            this.labelICP7.Size = new System.Drawing.Size(36, 13);
            this.labelICP7.TabIndex = 28;
            this.labelICP7.Text = "ICP 7:";
            // 
            // labelICP6
            // 
            this.labelICP6.AutoSize = true;
            this.labelICP6.Location = new System.Drawing.Point(-3, 122);
            this.labelICP6.Name = "labelICP6";
            this.labelICP6.Size = new System.Drawing.Size(36, 13);
            this.labelICP6.TabIndex = 27;
            this.labelICP6.Text = "ICP 6:";
            // 
            // labelICP5
            // 
            this.labelICP5.AutoSize = true;
            this.labelICP5.Location = new System.Drawing.Point(-3, 99);
            this.labelICP5.Name = "labelICP5";
            this.labelICP5.Size = new System.Drawing.Size(36, 13);
            this.labelICP5.TabIndex = 26;
            this.labelICP5.Text = "ICP 5:";
            // 
            // labelICP4
            // 
            this.labelICP4.AutoSize = true;
            this.labelICP4.Location = new System.Drawing.Point(-3, 76);
            this.labelICP4.Name = "labelICP4";
            this.labelICP4.Size = new System.Drawing.Size(36, 13);
            this.labelICP4.TabIndex = 25;
            this.labelICP4.Text = "ICP 4:";
            // 
            // tbSimICPEnter
            // 
            this.tbSimICPEnter.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPEnter.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPEnter.Location = new System.Drawing.Point(61, 280);
            this.tbSimICPEnter.Name = "tbSimICPEnter";
            this.tbSimICPEnter.ReadOnly = true;
            this.tbSimICPEnter.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPEnter.TabIndex = 24;
            this.tbSimICPEnter.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPPrevious
            // 
            this.tbSimICPPrevious.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPPrevious.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPPrevious.Location = new System.Drawing.Point(61, 258);
            this.tbSimICPPrevious.Name = "tbSimICPPrevious";
            this.tbSimICPPrevious.ReadOnly = true;
            this.tbSimICPPrevious.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPPrevious.TabIndex = 23;
            this.tbSimICPPrevious.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPNext
            // 
            this.tbSimICPNext.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPNext.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPNext.Location = new System.Drawing.Point(61, 235);
            this.tbSimICPNext.Name = "tbSimICPNext";
            this.tbSimICPNext.ReadOnly = true;
            this.tbSimICPNext.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPNext.TabIndex = 22;
            this.tbSimICPNext.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPZERO
            // 
            this.tbSimICPZERO.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPZERO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPZERO.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPZERO.Location = new System.Drawing.Point(61, 212);
            this.tbSimICPZERO.Name = "tbSimICPZERO";
            this.tbSimICPZERO.ReadOnly = true;
            this.tbSimICPZERO.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPZERO.TabIndex = 21;
            this.tbSimICPZERO.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPNINE
            // 
            this.tbSimICPNINE.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPNINE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPNINE.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPNINE.Location = new System.Drawing.Point(61, 189);
            this.tbSimICPNINE.Name = "tbSimICPNINE";
            this.tbSimICPNINE.ReadOnly = true;
            this.tbSimICPNINE.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPNINE.TabIndex = 20;
            this.tbSimICPNINE.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPEIGHT
            // 
            this.tbSimICPEIGHT.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPEIGHT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPEIGHT.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPEIGHT.Location = new System.Drawing.Point(61, 166);
            this.tbSimICPEIGHT.Name = "tbSimICPEIGHT";
            this.tbSimICPEIGHT.ReadOnly = true;
            this.tbSimICPEIGHT.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPEIGHT.TabIndex = 19;
            this.tbSimICPEIGHT.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPMark
            // 
            this.tbSimICPMark.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPMark.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPMark.Location = new System.Drawing.Point(61, 143);
            this.tbSimICPMark.Name = "tbSimICPMark";
            this.tbSimICPMark.ReadOnly = true;
            this.tbSimICPMark.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPMark.TabIndex = 18;
            this.tbSimICPMark.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPSIX
            // 
            this.tbSimICPSIX.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPSIX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPSIX.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPSIX.Location = new System.Drawing.Point(61, 120);
            this.tbSimICPSIX.Name = "tbSimICPSIX";
            this.tbSimICPSIX.ReadOnly = true;
            this.tbSimICPSIX.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPSIX.TabIndex = 17;
            this.tbSimICPSIX.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPCrus
            // 
            this.tbSimICPCrus.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPCrus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPCrus.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPCrus.Location = new System.Drawing.Point(61, 97);
            this.tbSimICPCrus.Name = "tbSimICPCrus";
            this.tbSimICPCrus.ReadOnly = true;
            this.tbSimICPCrus.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPCrus.TabIndex = 16;
            this.tbSimICPCrus.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPStpt
            // 
            this.tbSimICPStpt.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPStpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPStpt.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPStpt.Location = new System.Drawing.Point(61, 74);
            this.tbSimICPStpt.Name = "tbSimICPStpt";
            this.tbSimICPStpt.ReadOnly = true;
            this.tbSimICPStpt.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPStpt.TabIndex = 15;
            this.tbSimICPStpt.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPTHREE
            // 
            this.tbSimICPTHREE.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPTHREE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPTHREE.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPTHREE.Location = new System.Drawing.Point(61, 51);
            this.tbSimICPTHREE.Name = "tbSimICPTHREE";
            this.tbSimICPTHREE.ReadOnly = true;
            this.tbSimICPTHREE.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPTHREE.TabIndex = 14;
            this.tbSimICPTHREE.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPALOW
            // 
            this.tbSimICPALOW.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPALOW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPALOW.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPALOW.Location = new System.Drawing.Point(61, 28);
            this.tbSimICPALOW.Name = "tbSimICPALOW";
            this.tbSimICPALOW.ReadOnly = true;
            this.tbSimICPALOW.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPALOW.TabIndex = 13;
            this.tbSimICPALOW.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // labelICP3
            // 
            this.labelICP3.AutoSize = true;
            this.labelICP3.Location = new System.Drawing.Point(-3, 54);
            this.labelICP3.Name = "labelICP3";
            this.labelICP3.Size = new System.Drawing.Size(36, 13);
            this.labelICP3.TabIndex = 12;
            this.labelICP3.Text = "ICP 3:";
            // 
            // tbSimICPTILS
            // 
            this.tbSimICPTILS.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPTILS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPTILS.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPTILS.Location = new System.Drawing.Point(61, 5);
            this.tbSimICPTILS.Name = "tbSimICPTILS";
            this.tbSimICPTILS.ReadOnly = true;
            this.tbSimICPTILS.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPTILS.TabIndex = 11;
            this.tbSimICPTILS.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // labelICP2
            // 
            this.labelICP2.AutoSize = true;
            this.labelICP2.Location = new System.Drawing.Point(-3, 30);
            this.labelICP2.Name = "labelICP2";
            this.labelICP2.Size = new System.Drawing.Size(36, 13);
            this.labelICP2.TabIndex = 10;
            this.labelICP2.Text = "ICP 2:";
            // 
            // labelICP1
            // 
            this.labelICP1.AutoSize = true;
            this.labelICP1.Location = new System.Drawing.Point(-3, 9);
            this.labelICP1.Name = "labelICP1";
            this.labelICP1.Size = new System.Drawing.Size(36, 13);
            this.labelICP1.TabIndex = 9;
            this.labelICP1.Text = "ICP 1:";
            // 
            // labelNorm
            // 
            this.labelNorm.AutoSize = true;
            this.labelNorm.Location = new System.Drawing.Point(-2, 261);
            this.labelNorm.Name = "labelNorm";
            this.labelNorm.Size = new System.Drawing.Size(35, 13);
            this.labelNorm.TabIndex = 48;
            this.labelNorm.Text = "Norm:";
            // 
            // labelWarnReset
            // 
            this.labelWarnReset.AutoSize = true;
            this.labelWarnReset.Location = new System.Drawing.Point(-2, 283);
            this.labelWarnReset.Name = "labelWarnReset";
            this.labelWarnReset.Size = new System.Drawing.Size(67, 13);
            this.labelWarnReset.TabIndex = 47;
            this.labelWarnReset.Text = "Warn Reset:";
            // 
            // labelDriftCO
            // 
            this.labelDriftCO.AutoSize = true;
            this.labelDriftCO.Location = new System.Drawing.Point(-2, 238);
            this.labelDriftCO.Name = "labelDriftCO";
            this.labelDriftCO.Size = new System.Drawing.Size(62, 13);
            this.labelDriftCO.TabIndex = 46;
            this.labelDriftCO.Text = "DRIFT/CO:";
            // 
            // labelRCL
            // 
            this.labelRCL.AutoSize = true;
            this.labelRCL.Location = new System.Drawing.Point(-2, 8);
            this.labelRCL.Name = "labelRCL";
            this.labelRCL.Size = new System.Drawing.Size(31, 13);
            this.labelRCL.TabIndex = 45;
            this.labelRCL.Text = "RCL:";
            // 
            // labelCOM1
            // 
            this.labelCOM1.AutoSize = true;
            this.labelCOM1.Location = new System.Drawing.Point(-2, 31);
            this.labelCOM1.Name = "labelCOM1";
            this.labelCOM1.Size = new System.Drawing.Size(40, 13);
            this.labelCOM1.TabIndex = 44;
            this.labelCOM1.Text = "COM1:";
            // 
            // labelDCSSeq
            // 
            this.labelDCSSeq.AutoSize = true;
            this.labelDCSSeq.Location = new System.Drawing.Point(-2, 215);
            this.labelDCSSeq.Name = "labelDCSSeq";
            this.labelDCSSeq.Size = new System.Drawing.Size(54, 13);
            this.labelDCSSeq.TabIndex = 43;
            this.labelDCSSeq.Text = "DCS Seq:";
            // 
            // labelDCSRet
            // 
            this.labelDCSRet.AutoSize = true;
            this.labelDCSRet.Location = new System.Drawing.Point(-2, 192);
            this.labelDCSRet.Name = "labelDCSRet";
            this.labelDCSRet.Size = new System.Drawing.Size(52, 13);
            this.labelDCSRet.TabIndex = 42;
            this.labelDCSRet.Text = "DCS Ret:";
            // 
            // labelDCSDown
            // 
            this.labelDCSDown.AutoSize = true;
            this.labelDCSDown.Location = new System.Drawing.Point(-2, 169);
            this.labelDCSDown.Name = "labelDCSDown";
            this.labelDCSDown.Size = new System.Drawing.Size(63, 13);
            this.labelDCSDown.TabIndex = 41;
            this.labelDCSDown.Text = "DCS Down:";
            // 
            // labelDCSUp
            // 
            this.labelDCSUp.AutoSize = true;
            this.labelDCSUp.Location = new System.Drawing.Point(-2, 146);
            this.labelDCSUp.Name = "labelDCSUp";
            this.labelDCSUp.Size = new System.Drawing.Size(49, 13);
            this.labelDCSUp.TabIndex = 40;
            this.labelDCSUp.Text = "DCS Up:";
            // 
            // labelAG
            // 
            this.labelAG.AutoSize = true;
            this.labelAG.Location = new System.Drawing.Point(-2, 123);
            this.labelAG.Name = "labelAG";
            this.labelAG.Size = new System.Drawing.Size(28, 13);
            this.labelAG.TabIndex = 39;
            this.labelAG.Text = "A-G:";
            // 
            // labelAA
            // 
            this.labelAA.AutoSize = true;
            this.labelAA.Location = new System.Drawing.Point(-2, 100);
            this.labelAA.Name = "labelAA";
            this.labelAA.Size = new System.Drawing.Size(27, 13);
            this.labelAA.TabIndex = 38;
            this.labelAA.Text = "A-A:";
            // 
            // tbSimWarnReset
            // 
            this.tbSimWarnReset.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimWarnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimWarnReset.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimWarnReset.Location = new System.Drawing.Point(66, 280);
            this.tbSimWarnReset.Name = "tbSimWarnReset";
            this.tbSimWarnReset.ReadOnly = true;
            this.tbSimWarnReset.Size = new System.Drawing.Size(90, 20);
            this.tbSimWarnReset.TabIndex = 36;
            this.tbSimWarnReset.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimDriftCOOff
            // 
            this.tbSimDriftCOOff.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimDriftCOOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimDriftCOOff.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimDriftCOOff.Location = new System.Drawing.Point(66, 258);
            this.tbSimDriftCOOff.Name = "tbSimDriftCOOff";
            this.tbSimDriftCOOff.ReadOnly = true;
            this.tbSimDriftCOOff.Size = new System.Drawing.Size(90, 20);
            this.tbSimDriftCOOff.TabIndex = 35;
            this.tbSimDriftCOOff.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimDriftCOOn
            // 
            this.tbSimDriftCOOn.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimDriftCOOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimDriftCOOn.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimDriftCOOn.Location = new System.Drawing.Point(66, 235);
            this.tbSimDriftCOOn.Name = "tbSimDriftCOOn";
            this.tbSimDriftCOOn.ReadOnly = true;
            this.tbSimDriftCOOn.Size = new System.Drawing.Size(90, 20);
            this.tbSimDriftCOOn.TabIndex = 34;
            this.tbSimDriftCOOn.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPDEDSEQ
            // 
            this.tbSimICPDEDSEQ.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPDEDSEQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPDEDSEQ.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPDEDSEQ.Location = new System.Drawing.Point(66, 212);
            this.tbSimICPDEDSEQ.Name = "tbSimICPDEDSEQ";
            this.tbSimICPDEDSEQ.ReadOnly = true;
            this.tbSimICPDEDSEQ.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPDEDSEQ.TabIndex = 33;
            this.tbSimICPDEDSEQ.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPResetDED
            // 
            this.tbSimICPResetDED.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPResetDED.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPResetDED.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPResetDED.Location = new System.Drawing.Point(66, 189);
            this.tbSimICPResetDED.Name = "tbSimICPResetDED";
            this.tbSimICPResetDED.ReadOnly = true;
            this.tbSimICPResetDED.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPResetDED.TabIndex = 32;
            this.tbSimICPResetDED.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPDEDDOWN
            // 
            this.tbSimICPDEDDOWN.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPDEDDOWN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPDEDDOWN.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPDEDDOWN.Location = new System.Drawing.Point(66, 166);
            this.tbSimICPDEDDOWN.Name = "tbSimICPDEDDOWN";
            this.tbSimICPDEDDOWN.ReadOnly = true;
            this.tbSimICPDEDDOWN.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPDEDDOWN.TabIndex = 31;
            this.tbSimICPDEDDOWN.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPDEDUP
            // 
            this.tbSimICPDEDUP.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPDEDUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPDEDUP.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPDEDUP.Location = new System.Drawing.Point(66, 143);
            this.tbSimICPDEDUP.Name = "tbSimICPDEDUP";
            this.tbSimICPDEDUP.ReadOnly = true;
            this.tbSimICPDEDUP.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPDEDUP.TabIndex = 30;
            this.tbSimICPDEDUP.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPAG
            // 
            this.tbSimICPAG.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPAG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPAG.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPAG.Location = new System.Drawing.Point(66, 120);
            this.tbSimICPAG.Name = "tbSimICPAG";
            this.tbSimICPAG.ReadOnly = true;
            this.tbSimICPAG.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPAG.TabIndex = 29;
            this.tbSimICPAG.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPAA
            // 
            this.tbSimICPAA.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPAA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPAA.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPAA.Location = new System.Drawing.Point(66, 97);
            this.tbSimICPAA.Name = "tbSimICPAA";
            this.tbSimICPAA.ReadOnly = true;
            this.tbSimICPAA.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPAA.TabIndex = 28;
            this.tbSimICPAA.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPLIST
            // 
            this.tbSimICPLIST.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPLIST.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPLIST.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPLIST.Location = new System.Drawing.Point(66, 74);
            this.tbSimICPLIST.Name = "tbSimICPLIST";
            this.tbSimICPLIST.ReadOnly = true;
            this.tbSimICPLIST.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPLIST.TabIndex = 27;
            this.tbSimICPLIST.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPCom2
            // 
            this.tbSimICPCom2.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPCom2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPCom2.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPCom2.Location = new System.Drawing.Point(66, 51);
            this.tbSimICPCom2.Name = "tbSimICPCom2";
            this.tbSimICPCom2.ReadOnly = true;
            this.tbSimICPCom2.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPCom2.TabIndex = 26;
            this.tbSimICPCom2.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPCom1
            // 
            this.tbSimICPCom1.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPCom1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPCom1.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPCom1.Location = new System.Drawing.Point(66, 28);
            this.tbSimICPCom1.Name = "tbSimICPCom1";
            this.tbSimICPCom1.ReadOnly = true;
            this.tbSimICPCom1.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPCom1.TabIndex = 25;
            this.tbSimICPCom1.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // tbSimICPCLEAR
            // 
            this.tbSimICPCLEAR.BackColor = System.Drawing.SystemColors.Window;
            this.tbSimICPCLEAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbSimICPCLEAR.ForeColor = System.Drawing.Color.DarkGray;
            this.tbSimICPCLEAR.Location = new System.Drawing.Point(66, 5);
            this.tbSimICPCLEAR.Name = "tbSimICPCLEAR";
            this.tbSimICPCLEAR.ReadOnly = true;
            this.tbSimICPCLEAR.Size = new System.Drawing.Size(90, 20);
            this.tbSimICPCLEAR.TabIndex = 14;
            this.tbSimICPCLEAR.Click += new System.EventHandler(this.tbCallback_Click);
            // 
            // labelLIST
            // 
            this.labelLIST.AutoSize = true;
            this.labelLIST.Location = new System.Drawing.Point(-2, 77);
            this.labelLIST.Name = "labelLIST";
            this.labelLIST.Size = new System.Drawing.Size(33, 13);
            this.labelLIST.TabIndex = 13;
            this.labelLIST.Text = "LIST:";
            // 
            // labelCOM2
            // 
            this.labelCOM2.AutoSize = true;
            this.labelCOM2.Location = new System.Drawing.Point(-2, 54);
            this.labelCOM2.Name = "labelCOM2";
            this.labelCOM2.Size = new System.Drawing.Size(40, 13);
            this.labelCOM2.TabIndex = 12;
            this.labelCOM2.Text = "COM2:";
            // 
            // panelKeyfile
            // 
            this.panelKeyfile.BackColor = System.Drawing.Color.Transparent;
            this.panelKeyfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKeyfile.Controls.Add(this.tbKeyfile);
            this.panelKeyfile.Controls.Add(this.btnSaveKeyfile);
            this.panelKeyfile.Controls.Add(this.btnOpenKeyfile);
            this.panelKeyfile.Controls.Add(this.labelKeyfile);
            this.panelKeyfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKeyfile.Location = new System.Drawing.Point(3, 3);
            this.panelKeyfile.Name = "panelKeyfile";
            this.panelKeyfile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelKeyfile.Size = new System.Drawing.Size(317, 30);
            this.panelKeyfile.TabIndex = 4;
            // 
            // tbKeyfile
            // 
            this.tbKeyfile.Location = new System.Drawing.Point(49, 5);
            this.tbKeyfile.Name = "tbKeyfile";
            this.tbKeyfile.ReadOnly = true;
            this.tbKeyfile.Size = new System.Drawing.Size(141, 20);
            this.tbKeyfile.TabIndex = 7;
            // 
            // btnSaveKeyfile
            // 
            this.btnSaveKeyfile.Enabled = false;
            this.btnSaveKeyfile.Location = new System.Drawing.Point(256, 3);
            this.btnSaveKeyfile.Name = "btnSaveKeyfile";
            this.btnSaveKeyfile.Size = new System.Drawing.Size(55, 23);
            this.btnSaveKeyfile.TabIndex = 6;
            this.btnSaveKeyfile.Text = "Save";
            this.btnSaveKeyfile.UseVisualStyleBackColor = true;
            this.btnSaveKeyfile.Click += new System.EventHandler(this.btnSaveKeyfile_Click);
            // 
            // btnOpenKeyfile
            // 
            this.btnOpenKeyfile.Location = new System.Drawing.Point(196, 3);
            this.btnOpenKeyfile.Name = "btnOpenKeyfile";
            this.btnOpenKeyfile.Size = new System.Drawing.Size(55, 23);
            this.btnOpenKeyfile.TabIndex = 5;
            this.btnOpenKeyfile.Text = "Open...";
            this.btnOpenKeyfile.UseVisualStyleBackColor = true;
            this.btnOpenKeyfile.Click += new System.EventHandler(this.btnOpenKeyfile_Click);
            // 
            // labelKeyfile
            // 
            this.labelKeyfile.AutoSize = true;
            this.labelKeyfile.Location = new System.Drawing.Point(1, 8);
            this.labelKeyfile.Name = "labelKeyfile";
            this.labelKeyfile.Size = new System.Drawing.Size(41, 13);
            this.labelKeyfile.TabIndex = 4;
            this.labelKeyfile.Text = "Keyfile:";
            // 
            // nfyTrayIcon
            // 
            this.nfyTrayIcon.ContextMenuStrip = this.mnuTrayNotify;
            this.nfyTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nfyTrayIcon.Icon")));
            this.nfyTrayIcon.Text = "Falcon ICP Server";
            this.nfyTrayIcon.DoubleClick += new System.EventHandler(this.nfyTrayIcon_DoubleClick);
            // 
            // mnuTrayNotify
            // 
            this.mnuTrayNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNotifyStart,
            this.miNotifyStop,
            this.toolStripSeparator1,
            this.miNotifySettings,
            this.toolStripSeparator2,
            this.miNotifyExit});
            this.mnuTrayNotify.Name = "mnuNotify";
            this.mnuTrayNotify.Size = new System.Drawing.Size(134, 104);
            // 
            // miNotifyStart
            // 
            this.miNotifyStart.Image = global::FalconICPServer.Properties.Resources.start;
            this.miNotifyStart.Name = "miNotifyStart";
            this.miNotifyStart.Size = new System.Drawing.Size(133, 22);
            this.miNotifyStart.Text = "Start Server";
            this.miNotifyStart.Click += new System.EventHandler(this.miNotifyStart_Click);
            // 
            // miNotifyStop
            // 
            this.miNotifyStop.Enabled = false;
            this.miNotifyStop.Image = global::FalconICPServer.Properties.Resources.stop;
            this.miNotifyStop.Name = "miNotifyStop";
            this.miNotifyStop.Size = new System.Drawing.Size(133, 22);
            this.miNotifyStop.Text = "Stop Server";
            this.miNotifyStop.Click += new System.EventHandler(this.miNotifyStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // miNotifySettings
            // 
            this.miNotifySettings.Name = "miNotifySettings";
            this.miNotifySettings.Size = new System.Drawing.Size(133, 22);
            this.miNotifySettings.Text = "Settings";
            this.miNotifySettings.Click += new System.EventHandler(this.miNotifySettings_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(130, 6);
            // 
            // miNotifyExit
            // 
            this.miNotifyExit.Name = "miNotifyExit";
            this.miNotifyExit.Size = new System.Drawing.Size(133, 22);
            this.miNotifyExit.Text = "Exit";
            this.miNotifyExit.Click += new System.EventHandler(this.miNotifyExit_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(6, 313);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(84, 13);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "Product version:";
            // 
            // lbProductVersion
            // 
            this.lbProductVersion.AutoSize = true;
            this.lbProductVersion.Location = new System.Drawing.Point(104, 313);
            this.lbProductVersion.Name = "lbProductVersion";
            this.lbProductVersion.Size = new System.Drawing.Size(0, 13);
            this.lbProductVersion.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 388);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.tsToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Falcon ICP Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tsToolbar.ResumeLayout(false);
            this.tsToolbar.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabConnection.ResumeLayout(false);
            this.tabConnection.PerformLayout();
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            this.gbPerformance.ResumeLayout(false);
            this.gbPerformance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdatePeriod)).EndInit();
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.tabKeystrokes.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelKeyfile.ResumeLayout(false);
            this.panelKeyfile.PerformLayout();
            this.mnuTrayNotify.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsToolbar;
        private System.Windows.Forms.ToolStripButton tsbStart;
        private System.Windows.Forms.ToolStripButton tsbStop;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabConnection;
        private System.Windows.Forms.TabPage tabKeystrokes;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Label labelServerPort;
        private System.Windows.Forms.Label labelServerIP;
        private System.Windows.Forms.Label lbServerIP;
        private System.Windows.Forms.Label lbClientIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbPerformance;
        private System.Windows.Forms.ComboBox cbPriority;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelMilliseconds;
        private System.Windows.Forms.Label labelUpdatePeriod;
        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.CheckBox chkMinimizeToSystemTray;
        private System.Windows.Forms.CheckBox chkLaunchMinimized;
        private System.Windows.Forms.CheckBox chkRunServerOnLaunch;
        private System.Windows.Forms.CheckBox chkLaunchAtStartup;
        private System.Windows.Forms.NumericUpDown nudUpdatePeriod;
        private System.Windows.Forms.Panel panelKeyfile;
        private System.Windows.Forms.TextBox tbKeyfile;
        private System.Windows.Forms.Button btnSaveKeyfile;
        private System.Windows.Forms.Button btnOpenKeyfile;
        private System.Windows.Forms.Label labelKeyfile;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox tbSimICPTILS;
        private System.Windows.Forms.Label labelICP2;
        private System.Windows.Forms.Label labelICP1;
        private System.Windows.Forms.TextBox tbSimICPCLEAR;
        private System.Windows.Forms.Label labelLIST;
        private System.Windows.Forms.Label labelCOM2;
        private System.Windows.Forms.TextBox tbSimICPEnter;
        private System.Windows.Forms.TextBox tbSimICPPrevious;
        private System.Windows.Forms.TextBox tbSimICPNext;
        private System.Windows.Forms.TextBox tbSimICPZERO;
        private System.Windows.Forms.TextBox tbSimICPNINE;
        private System.Windows.Forms.TextBox tbSimICPEIGHT;
        private System.Windows.Forms.TextBox tbSimICPMark;
        private System.Windows.Forms.TextBox tbSimICPSIX;
        private System.Windows.Forms.TextBox tbSimICPCrus;
        private System.Windows.Forms.TextBox tbSimICPStpt;
        private System.Windows.Forms.TextBox tbSimICPTHREE;
        private System.Windows.Forms.Label labelICP3;
        private System.Windows.Forms.TextBox tbSimWarnReset;
        private System.Windows.Forms.TextBox tbSimDriftCOOff;
        private System.Windows.Forms.TextBox tbSimDriftCOOn;
        private System.Windows.Forms.TextBox tbSimICPDEDSEQ;
        private System.Windows.Forms.TextBox tbSimICPResetDED;
        private System.Windows.Forms.TextBox tbSimICPDEDDOWN;
        private System.Windows.Forms.TextBox tbSimICPDEDUP;
        private System.Windows.Forms.TextBox tbSimICPAG;
        private System.Windows.Forms.TextBox tbSimICPAA;
        private System.Windows.Forms.TextBox tbSimICPLIST;
        private System.Windows.Forms.TextBox tbSimICPCom2;
        private System.Windows.Forms.TextBox tbSimICPCom1;
        private System.Windows.Forms.Label labelICP8;
        private System.Windows.Forms.Label labelICP7;
        private System.Windows.Forms.Label labelICP6;
        private System.Windows.Forms.Label labelICP5;
        private System.Windows.Forms.Label labelICP4;
        private System.Windows.Forms.Label labelENTR;
        private System.Windows.Forms.Label labelICSDown;
        private System.Windows.Forms.Label labelICSUp;
        private System.Windows.Forms.Label labelICP0;
        private System.Windows.Forms.Label labelICP9;
        private System.Windows.Forms.Label labelDCSSeq;
        private System.Windows.Forms.Label labelDCSRet;
        private System.Windows.Forms.Label labelDCSDown;
        private System.Windows.Forms.Label labelDCSUp;
        private System.Windows.Forms.Label labelAG;
        private System.Windows.Forms.Label labelAA;
        private System.Windows.Forms.Label labelCOM1;
        private System.Windows.Forms.Label labelWarnReset;
        private System.Windows.Forms.Label labelDriftCO;
        private System.Windows.Forms.Label labelRCL;
        private System.Windows.Forms.TextBox tbSimICPALOW;
        private System.Windows.Forms.Label labelNorm;
        private System.Windows.Forms.NotifyIcon nfyTrayIcon;
        private System.Windows.Forms.ContextMenuStrip mnuTrayNotify;
        private System.Windows.Forms.ToolStripMenuItem miNotifyStart;
        private System.Windows.Forms.ToolStripMenuItem miNotifyStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miNotifySettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miNotifyExit;
        private System.Windows.Forms.Label lbProductVersion;
        private System.Windows.Forms.Label labelVersion;
    }
}