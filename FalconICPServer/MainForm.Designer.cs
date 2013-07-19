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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabConnection = new System.Windows.Forms.TabPage();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.lbServerIP = new System.Windows.Forms.Label();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.labelServerPort = new System.Windows.Forms.Label();
            this.labelServerIP = new System.Windows.Forms.Label();
            this.tabKeystrokes = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbPerformance = new System.Windows.Forms.GroupBox();
            this.labelUpdatePeriod = new System.Windows.Forms.Label();
            this.tbUpdatePeriod = new System.Windows.Forms.TextBox();
            this.labelMilliseconds = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.cbLaunchAtStartup = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabConnection.SuspendLayout();
            this.gbConnection.SuspendLayout();
            this.gbPerformance.SuspendLayout();
            this.gbGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip1.Size = new System.Drawing.Size(319, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(86, 22);
            this.toolStripButton1.Text = "Start Server";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(86, 22);
            this.toolStripButton2.Text = "Stop Server";
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
            // gbConnection
            // 
            this.gbConnection.AutoSize = true;
            this.gbConnection.Controls.Add(this.label1);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "none";
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
            // gbPerformance
            // 
            this.gbPerformance.Controls.Add(this.comboBox1);
            this.gbPerformance.Controls.Add(this.label5);
            this.gbPerformance.Controls.Add(this.labelMilliseconds);
            this.gbPerformance.Controls.Add(this.tbUpdatePeriod);
            this.gbPerformance.Controls.Add(this.labelUpdatePeriod);
            this.gbPerformance.Location = new System.Drawing.Point(3, 109);
            this.gbPerformance.Name = "gbPerformance";
            this.gbPerformance.Size = new System.Drawing.Size(305, 75);
            this.gbPerformance.TabIndex = 1;
            this.gbPerformance.TabStop = false;
            this.gbPerformance.Text = "Performance";
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
            // tbUpdatePeriod
            // 
            this.tbUpdatePeriod.Location = new System.Drawing.Point(109, 18);
            this.tbUpdatePeriod.Name = "tbUpdatePeriod";
            this.tbUpdatePeriod.Size = new System.Drawing.Size(40, 20);
            this.tbUpdatePeriod.TabIndex = 4;
            this.tbUpdatePeriod.Text = "50";
            // 
            // labelMilliseconds
            // 
            this.labelMilliseconds.AutoSize = true;
            this.labelMilliseconds.Location = new System.Drawing.Point(155, 21);
            this.labelMilliseconds.Name = "labelMilliseconds";
            this.labelMilliseconds.Size = new System.Drawing.Size(20, 13);
            this.labelMilliseconds.TabIndex = 5;
            this.labelMilliseconds.Text = "ms";
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(109, 41);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.checkBox3);
            this.gbGeneral.Controls.Add(this.checkBox2);
            this.gbGeneral.Controls.Add(this.checkBox1);
            this.gbGeneral.Controls.Add(this.cbLaunchAtStartup);
            this.gbGeneral.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbGeneral.Location = new System.Drawing.Point(3, 191);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(305, 112);
            this.gbGeneral.TabIndex = 2;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "General Settings";
            // 
            // cbLaunchAtStartup
            // 
            this.cbLaunchAtStartup.AutoSize = true;
            this.cbLaunchAtStartup.Location = new System.Drawing.Point(6, 19);
            this.cbLaunchAtStartup.Name = "cbLaunchAtStartup";
            this.cbLaunchAtStartup.Size = new System.Drawing.Size(148, 17);
            this.cbLaunchAtStartup.TabIndex = 0;
            this.cbLaunchAtStartup.Text = "Launch at System Startup";
            this.cbLaunchAtStartup.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Run server on launch";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 65);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(110, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Launch minimized";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 88);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(139, 17);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "Minimize to System Tray";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 357);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Falcon ICP Server";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabConnection.ResumeLayout(false);
            this.tabConnection.PerformLayout();
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.gbPerformance.ResumeLayout(false);
            this.gbPerformance.PerformLayout();
            this.gbGeneral.ResumeLayout(false);
            this.gbGeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabConnection;
        private System.Windows.Forms.TabPage tabKeystrokes;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Label labelServerPort;
        private System.Windows.Forms.Label labelServerIP;
        private System.Windows.Forms.Label lbServerIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbPerformance;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelMilliseconds;
        private System.Windows.Forms.TextBox tbUpdatePeriod;
        private System.Windows.Forms.Label labelUpdatePeriod;
        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox cbLaunchAtStartup;
    }
}