namespace FalconICPServer
{
    partial class KeystrokeGetter
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelKeystroke = new System.Windows.Forms.Panel();
            this.lblKeystroke = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.panelKeystroke.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMessage.Location = new System.Drawing.Point(4, 14);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(183, 13);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "Press new keystroke for {0} callback.";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(151, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelKeystroke
            // 
            this.panelKeystroke.Controls.Add(this.lblKeystroke);
            this.panelKeystroke.Location = new System.Drawing.Point(-6, 33);
            this.panelKeystroke.Name = "panelKeystroke";
            this.panelKeystroke.Size = new System.Drawing.Size(307, 40);
            this.panelKeystroke.TabIndex = 2;
            // 
            // lblKeystroke
            // 
            this.lblKeystroke.BackColor = System.Drawing.SystemColors.Control;
            this.lblKeystroke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeystroke.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKeystroke.Location = new System.Drawing.Point(0, 0);
            this.lblKeystroke.Name = "lblKeystroke";
            this.lblKeystroke.Size = new System.Drawing.Size(307, 40);
            this.lblKeystroke.TabIndex = 2;
            this.lblKeystroke.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(70, 80);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // KeystrokeGetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 114);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panelKeystroke);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KeystrokeGetter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panelKeystroke.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelKeystroke;
        private System.Windows.Forms.Label lblKeystroke;
        private System.Windows.Forms.Button btnOK;
    }
}