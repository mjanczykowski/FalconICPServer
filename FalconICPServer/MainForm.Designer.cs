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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
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
            this.toolStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabConnection.SuspendLayout();
            this.gbGeneral.SuspendLayout();
            this.gbPerformance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUpdatePeriod)).BeginInit();
            this.gbConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbStart,
            this.tsbStop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(319, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbStart
            // 
            this.tsbStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbStart.Image")));
            this.tsbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStart.Name = "tsbStart";
            this.tsbStart.Size = new System.Drawing.Size(86, 22);
            this.tsbStart.Text = "Start Server";
            this.tsbStart.Click += new System.EventHandler(this.tsbStart_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.Enabled = false;
            this.tsbStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbStop.Image")));
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
            this.tabControl.Size = new System.Drawing.Size(319, 332);
            this.tabControl.TabIndex = 1;
            // 
            // tabConnection
            // 
            this.tabConnection.Controls.Add(this.gbGeneral);
            this.tabConnection.Controls.Add(this.gbPerformance);
            this.tabConnection.Controls.Add(this.gbConnection);
            this.tabConnection.Location = new System.Drawing.Point(4, 22);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnection.Size = new System.Drawing.Size(311, 306);
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
            this.gbGeneral.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbGeneral.Location = new System.Drawing.Point(3, 191);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(305, 112);
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
            this.gbPerformance.Size = new System.Drawing.Size(305, 75);
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
            // 
            // cbPriority
            // 
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.Location = new System.Drawing.Point(109, 41);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(79, 21);
            this.cbPriority.TabIndex = 7;
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
            this.gbConnection.Size = new System.Drawing.Size(305, 100);
            this.gbConnection.TabIndex = 0;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection";
            // 
            // lbClientIP
            // 
            this.lbClientIP.AutoSize = true;
            this.lbClientIP.Location = new System.Drawing.Point(107, 71);
            this.lbClientIP.Name = "lbClientIP";
            this.lbClientIP.Size = new System.Drawing.Size(31, 13);
            this.lbClientIP.TabIndex = 6;
            this.lbClientIP.Text = "none";
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
            this.tabKeystrokes.Location = new System.Drawing.Point(4, 22);
            this.tabKeystrokes.Name = "tabKeystrokes";
            this.tabKeystrokes.Padding = new System.Windows.Forms.Padding(3);
            this.tabKeystrokes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabKeystrokes.Size = new System.Drawing.Size(311, 306);
            this.tabKeystrokes.TabIndex = 1;
            this.tabKeystrokes.Text = "Keystrokes";
            this.tabKeystrokes.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 357);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Falcon ICP Server";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
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
    }
}