using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NLog;

namespace FalconICPServer
{
    public partial class KeyfileChooserDialog : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private string[] Keyfiles;

        public string Result { get; private set; }

        public KeyfileChooserDialog(string[] files)
        {
            Keyfiles = files;

            InitializeComponent();

            int selected = 0;

            for(int i = 0; i < Keyfiles.Length; i++)
            {
                var keyfile = Keyfiles[i];

                logger.Debug("keyfile: {0}", keyfile);

                var filename = Path.GetFileName(keyfile);

                if(filename.Equals("BMS.key"))
                {
                    filename += " (default)";
                    selected = i;
                }

                this.cbKeyFile.Items.Add(filename);
                this.cbKeyFile.SelectedIndex = selected;
            }
        }

        public static string Show(string bmsPath)
        {
            string configPath = bmsPath + "\\User\\Config";

            string[] files;

            try
            {
                files = Directory.GetFiles(configPath, "*.key");
            }
            catch (Exception e)
            {
                if (e is IOException || e is UnauthorizedAccessException || e is PathTooLongException
                    || e is DirectoryNotFoundException || e is ArgumentException || e is ArgumentNullException)
                {
                    logger.Debug(e.Message);
                    return null;
                }
                throw;
            }

            if (files == null)
            {
                return null;
            }

            if (files.Length == 1)
            {
                return files[0];
            }

            var dialog = new KeyfileChooserDialog(files);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.Result;
            }

            return null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Result = Keyfiles[cbKeyFile.SelectedIndex];
            this.DialogResult = DialogResult.OK;
        }
    }
}
