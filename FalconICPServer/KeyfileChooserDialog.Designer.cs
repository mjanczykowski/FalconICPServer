namespace FalconICPServer
{
    partial class KeyfileChooserDialog
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
            this.labelChooseFile = new System.Windows.Forms.Label();
            this.cbKeyFile = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelChooseFile
            // 
            this.labelChooseFile.AutoSize = true;
            this.labelChooseFile.Location = new System.Drawing.Point(8, 9);
            this.labelChooseFile.Name = "labelChooseFile";
            this.labelChooseFile.Size = new System.Drawing.Size(175, 13);
            this.labelChooseFile.TabIndex = 0;
            this.labelChooseFile.Text = "Please choose your active Key File:";
            // 
            // cbKeyFile
            // 
            this.cbKeyFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKeyFile.FormattingEnabled = true;
            this.cbKeyFile.Location = new System.Drawing.Point(11, 29);
            this.cbKeyFile.Name = "cbKeyFile";
            this.cbKeyFile.Size = new System.Drawing.Size(167, 21);
            this.cbKeyFile.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(58, 56);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // KeyfileChooserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 87);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbKeyFile);
            this.Controls.Add(this.labelChooseFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KeyfileChooserDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose Key File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChooseFile;
        private System.Windows.Forms.ComboBox cbKeyFile;
        private System.Windows.Forms.Button btnOK;
    }
}