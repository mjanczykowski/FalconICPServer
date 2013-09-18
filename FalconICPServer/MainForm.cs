using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Microsoft.Win32;
using Microsoft.VisualBasic.Devices;
using NLog;
using FalconICPServer.Properties;
using F4KeyFile;

namespace FalconICPServer
{
    public partial class MainForm : Form
    {
        private ICPServer icpServer;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private KeyfileState keyfileState = new KeyfileState();
        private Dictionary<string, TextBox> callbackToTextBox = new Dictionary<string, TextBox>();

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads saved settings.
        /// </summary>
        private void LoadSettings()
        {
            Settings.Default.Reload();
            chkLaunchAtStartup.Checked = Settings.Default.LaunchAtWindowsStartup;
            chkLaunchMinimized.Checked = Settings.Default.LaunchMinimized;
            chkMinimizeToSystemTray.Checked = Settings.Default.MinimizeToSystemTray;
            chkRunServerOnLaunch.Checked = Settings.Default.RunServerOnLaunch;
            tbServerPort.Text = Settings.Default.ServerPort;
            nudUpdatePeriod.Value = Settings.Default.UpdatePeriod;
            cbPriority.SelectedItem = Enum.GetName(typeof(ThreadPriority), Settings.Default.Priority);
        }

        /// <summary>
        /// Closes application.
        /// </summary>
        private void Exit()
        {
            logger.Info("Application Exit");
            nfyTrayIcon.Visible = false;
            Application.Exit();
        }

        private void MinimizeToSystemTray()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            nfyTrayIcon.Visible = true;
        }

        private void RestoreFromSystemTray()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            nfyTrayIcon.Visible = false;
        }

        private void UpdateStartupRegistryKey()
        {
            if (chkLaunchAtStartup.Checked == true)
            {
                var c = new Computer();

                try
                {
                    using (var startupKey = c.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                    {
                        startupKey.SetValue(Application.ProductName, Application.ExecutablePath, RegistryValueKind.String);
                    }
                }
                catch (Exception e)
                {
                    logger.Warn(e);
                }
            }
            else
            {
                var c = new Computer();

                try
                {
                    using (var startupKey = c.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                    {
                        startupKey.DeleteValue(Application.ProductName, false);
                    }
                }
                catch (Exception e)
                {
                    logger.Warn(e);
                }
            }
            Settings.Default.LaunchAtWindowsStartup = chkLaunchAtStartup.Checked;
            Settings.Default.Save();
        }

        #region ICPServer methods

        /// <summary>
        /// Preparations for server startings + server start
        /// </summary>
        private void StartServer()
        {
            Thread.CurrentThread.Priority = Settings.Default.Priority;

            // Check if port number has been entered.
            if (String.IsNullOrEmpty(tbServerPort.Text.Trim()))
            {
                MessageBox.Show("Please enter the port number of the " + Application.ProductName, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TODO Restore from system tray
                tbServerPort.Focus();
                return;
            }

            var portNum = 30456;
            Int32.TryParse(Settings.Default.ServerPort, out portNum);

            if (icpServer != null)
            {
                StopServer();
            }

            icpServer = new ICPServer();
            icpServer.ConnectionEstablished += new EventHandler<ConnectionEventArgs>(IcpServer_ConnectionEstablished);
            icpServer.ConnectionLost += new EventHandler<ConnectionEventArgs>(IcpServer_ConnectionLost);
            icpServer.ButtonPressed += new EventHandler<ButtonPressEventArgs>(IcpServer_ButtonPressed);
            
            tsbStart.Enabled = false;
            miNotifyStart.Enabled = false;

            gbConnection.Enabled = false;
            gbPerformance.Enabled = false;
            gbGeneral.Enabled = false;

            try
            {
                icpServer.Start();
                tsbStop.Enabled = true;
                miNotifyStop.Enabled = true;

                if (chkLaunchMinimized.Checked)
                {
                    if (chkMinimizeToSystemTray.Checked)
                    {
                        MinimizeToSystemTray();
                    }
                    else
                    {
                        WindowState = FormWindowState.Minimized;
                    }
                }
            }
            catch (SocketException e)
            {
                logger.Warn("SocketException: " + e.Message);
                MessageBox.Show("Cannot run server. Try running it on another port. Error message: \n\n" + e.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                tsbStart.Enabled = true;
                miNotifyStart.Enabled = true;

                gbConnection.Enabled = true;
                gbPerformance.Enabled = true;
                gbGeneral.Enabled = true;
            }
        }

        private void StopServer()
        {
            // Revert to normal priority.
            Thread.CurrentThread.Priority = ThreadPriority.Normal;

            tsbStop.Enabled = false;
            miNotifyStop.Enabled = false;

            icpServer.Stop();
            try
            {
                icpServer.Dispose();
                icpServer = null;
            }
            catch (Exception e)
            {
                logger.Warn(e);
            }

            gbConnection.Enabled = true;
            gbGeneral.Enabled = true;
            gbPerformance.Enabled = true;
            tsbStart.Enabled = true;
            miNotifyStart.Enabled = true;
        }

        private string getLocalIpAddress()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        private void IcpServer_ConnectionEstablished(object sender, ConnectionEventArgs e)
        {
            lbClientIP.BeginInvoke((MethodInvoker)(() => lbClientIP.Text = e.IpAddress));
        }

        private void IcpServer_ConnectionLost(object sender, ConnectionEventArgs e)
        {
            lbClientIP.BeginInvoke((MethodInvoker)(() => lbClientIP.Text = "-"));
        }

        private void IcpServer_ButtonPressed(object sender, ButtonPressEventArgs e)
        {
            KeyBinding keystroke;
            if (keyfileState.bindings.TryGetValue(e.Callback, out keystroke))
            {
                KeyfileUtils.SendKeystroke(keystroke);
            }
        }

        #endregion

        #region KeyFile methods

        /// <summary>
        /// Loads KeyFile on application launch trying all possible ways.
        /// </summary>
        private void LoadKeyFile()
        {
            string path = null;

            if (string.IsNullOrEmpty(Settings.Default.KeyfilePath))
            {
                string keyname = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Benchmark Sims\\Falcon BMS 4.32";
                var dir = (string)Registry.GetValue(keyname, "baseDir", null);
                if (dir == null)
                {
                    keyname = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Benchmark Sims\\Falcon BMS 4.32";
                    dir = (string)Registry.GetValue(keyname, "baseDir", null);
                }
                if (dir != null)
                {
                    path = KeyfileChooserDialog.Show(dir);
                }

                if (dir == null || path == null)
                {
                    MessageBox.Show("Could not find Falcon BMS 4.32 location. Please load the .key file manually on Keystrokes tab.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            else
            {
                path = Settings.Default.KeyfilePath;
            }

            try
            {
                logger.Info("loading {0} keyfile", path);
                LoadKeyFile(path);
            }
            catch (Exception)
            {
                MessageBox.Show("Key file load error! Please load the .key file manually on Keystrokes tab.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                logger.Info("Key file load error");
            }
        }

        /// <summary>
        /// Loads given key file.
        /// </summary>
        /// <param name="path">Path to the key file</param>
        private void LoadKeyFile(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("keyfile_path");
            var keyfileFI = new FileInfo(path);
            if (!keyfileFI.Exists) throw new FileNotFoundException(path);

            string oldKeyfilePath = null;

            if (keyfileState.keyfilePath != null && !path.Equals(keyfileState.keyfilePath))
                oldKeyfilePath = keyfileState.keyfilePath;

            try
            {
                keyfileState.keyfilePath = path;
                keyfileState.keyfile = new KeyFile(keyfileFI);
                keyfileState.keyfile.Load();
                ParseKeyFile();
                keyfileState.Changed = false;

                tbKeyfile.Text = path;
                Settings.Default.KeyfilePath = path;
                Settings.Default.Save();

                btnSaveKeyfile.Enabled = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("An error occured while loading key file.\n\n{0}", e.Message),
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                logger.Error(e.Message);
                if (!string.IsNullOrEmpty(oldKeyfilePath))
                {
                    LoadKeyFile(oldKeyfilePath);
                }
                else
                {
                    keyfileState.keyfile = null;
                    keyfileState.keyfilePath = null;
                }
            }

        }

        /// <summary>
        /// Saves currently opened key file if it has changes.
        /// </summary>
        private void SaveKeyFile()
        {
            if (keyfileState.Changed == false)
            {
                return;
            }

            keyfileState.keyfile.Save();
            keyfileState.Changed = false;
            btnSaveKeyfile.Enabled = false;
        }

        /// <summary>
        /// Parses keyfile, sets text for TextBoxes and creates dictionaries.
        /// </summary>
        private void ParseKeyFile()
        {
            if (keyfileState.keyfile == null) throw new InvalidOperationException();

            // Initialize callbackToTextBox dictionary
            if (callbackToTextBox.Count == 0)
            {
                #region adding callbacks to dictionary
                callbackToTextBox.Add("SimWarnReset", tbSimWarnReset);
                callbackToTextBox.Add("SimICPCom1", tbSimICPCom1);
                callbackToTextBox.Add("SimICPCom2", tbSimICPCom2);
                //"SimICPIFF"
                callbackToTextBox.Add("SimICPIFF", null);
                callbackToTextBox.Add("SimICPLIST", tbSimICPLIST);
                callbackToTextBox.Add("SimICPAA", tbSimICPAA);
                callbackToTextBox.Add("SimICPAG", tbSimICPAG);
                callbackToTextBox.Add("SimICPDEDDOWN", tbSimICPDEDDOWN);
                callbackToTextBox.Add("SimICPDEDUP", tbSimICPDEDUP);
                callbackToTextBox.Add("SimICPDEDSEQ", tbSimICPDEDSEQ);
                callbackToTextBox.Add("SimICPResetDED", tbSimICPResetDED);
                callbackToTextBox.Add("SimICPCLEAR", tbSimICPCLEAR);
                callbackToTextBox.Add("SimICPTILS", tbSimICPTILS);
                callbackToTextBox.Add("SimICPALOW", tbSimICPALOW);
                callbackToTextBox.Add("SimICPTHREE", tbSimICPTHREE);
                callbackToTextBox.Add("SimICPStpt", tbSimICPStpt);
                callbackToTextBox.Add("SimICPCrus", tbSimICPCrus);
                callbackToTextBox.Add("SimICPSIX", tbSimICPSIX);
                callbackToTextBox.Add("SimICPMark", tbSimICPMark);
                callbackToTextBox.Add("SimICPEIGHT", tbSimICPEIGHT);
                callbackToTextBox.Add("SimICPNINE", tbSimICPNINE);
                callbackToTextBox.Add("SimICPZERO", tbSimICPZERO);
                callbackToTextBox.Add("SimICPEnter", tbSimICPEnter);
                callbackToTextBox.Add("SimICPNext", tbSimICPNext);
                callbackToTextBox.Add("SimICPPrevious", tbSimICPPrevious);
                callbackToTextBox.Add("SimDriftCOOn", tbSimDriftCOOn);
                callbackToTextBox.Add("SimDriftCOOff", tbSimDriftCOOff);
                #endregion
            }

            if (keyfileState.bindings.Count > 0) keyfileState.bindings.Clear();

            foreach (var pair in callbackToTextBox)
            {
                var binding = keyfileState.keyfile.FindBindingForCallback(pair.Key);
                if (binding is KeyBinding)
                {
                    var keyBinding = binding as KeyBinding;
                    keyfileState.bindings.Add(pair.Key, keyBinding);

                    if (pair.Value != null)
                    {
                        string desc = KeyfileUtils.GetKeyDescription(keyBinding);
                        if (desc == null)
                        {
                            pair.Value.BackColor = Color.LightCoral;
                            pair.Value.Text = "";
                        }
                        else
                        {
                            pair.Value.BackColor = (Color)System.Drawing.SystemColors.Window;
                            pair.Value.ForeColor = Color.DarkGray;
                            pair.Value.Text = desc;
                        }
                    }
                }
                else if (binding is DirectInputBinding)
                {
                    if (pair.Value != null)
                    {
                        pair.Value.BackColor = Color.LightCoral;
                        pair.Value.ForeColor = Color.Black;
                        pair.Value.Text = "DX input (not supported)";
                    }
                }
                else if(binding == null)
                {
                    if (pair.Value != null)
                    {
                        pair.Value.BackColor = Color.LightCoral;
                        pair.Value.Text = "";
                    }
                }
            }
        }

        private class KeyfileState
        {
            public bool Changed;

            public KeyFile keyfile;
            public string keyfilePath;

            public Dictionary<string, KeyBinding> bindings = new Dictionary<string, KeyBinding>();
        }

        #endregion

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbServerIP.Text = getLocalIpAddress();
            lbProductVersion.Text = Application.ProductVersion;

            foreach (var priority in Enum.GetNames(typeof(ThreadPriority)))
            {
                if (priority.ToLowerInvariant() != "highest")
                {
                    cbPriority.Items.Add(priority);
                }
            }
            LoadSettings();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoadKeyFile();

            if (Settings.Default.RunServerOnLaunch)
            {
                StartServer();
            }
        }

        private void tsbStart_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void tsbStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void cbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedPriority = (ThreadPriority)Enum.Parse(typeof(ThreadPriority), (string)cbPriority.SelectedItem);
            Settings.Default.Priority = selectedPriority;
            Settings.Default.Save();
        }

        private void nudUpdatePeriod_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.UpdatePeriod = (int)nudUpdatePeriod.Value;
            Settings.Default.Save();
        }

        private void tbServerPort_Leave(object sender, EventArgs e)
        {
            var serverPort = -1;
            var parsed = Int32.TryParse(tbServerPort.Text, out serverPort);
            if (!parsed || serverPort < 0 || serverPort > 65535)
            {
                MessageBox.Show(Properties.Resources.error_invalid_port, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbServerPort.Text = Settings.Default.ServerPort;
                tbServerPort.Focus();
            }
            else
            {
                Settings.Default.ServerPort = tbServerPort.Text;
                Settings.Default.Save();
            }
        }

        private void chkRunServerOnLaunch_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.RunServerOnLaunch = chkRunServerOnLaunch.Checked;
            Settings.Default.Save();
        }

        private void chkLaunchMinimized_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.LaunchMinimized = chkLaunchMinimized.Checked;
            Settings.Default.Save();
        }

        private void chkMinimizeToSystemTray_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.MinimizeToSystemTray = chkMinimizeToSystemTray.Checked;
            Settings.Default.Save();
        }

        private void chkLaunchAtStartup_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStartupRegistryKey();
        }

        private void btnOpenKeyfile_Click(object sender, EventArgs e)
        {
            string path = null;
            string keyname = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Benchmark Sims\\Falcon BMS 4.32";
            
            var dir = (string)Registry.GetValue(keyname, "baseDir", null);
            if (dir == null)
            {
                keyname = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Benchmark Sims\\Falcon BMS 4.32";
                dir = (string)Registry.GetValue(keyname, "baseDir", null);
            }
            if (dir != null)
            {
                path = KeyfileChooserDialog.Show(dir);
            }

            if (dir == null || path == null)
            {
                var openFileDialog = new OpenFileDialog
                                {
                                    AddExtension = true,
                                    AutoUpgradeEnabled = true,
                                    CheckFileExists = true,
                                    CheckPathExists = true,
                                    DefaultExt = ".key",
                                    Filter = "Falcon 4 Key File (*.key)|*.key",
                                    FilterIndex = 0,
                                    DereferenceLinks = true,
                                    Multiselect = false,
                                    ReadOnlyChecked = false,
                                    RestoreDirectory = true,
                                    ShowHelp = false,
                                    ShowReadOnly = false,
                                    SupportMultiDottedExtensions = true,
                                    Title = "Open Key File",
                                    ValidateNames = true
                                };
                var result = openFileDialog.ShowDialog(this);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                if (result == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                }
            }
            LoadKeyFile(path);
        }

        private void btnSaveKeyfile_Click(object sender, EventArgs e)
        {
            SaveKeyFile();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exit();
        }

        /// <summary>
        /// Callback for all callback text boxes.
        /// </summary>
        /// <param name="sender">TextBox</param>
        /// <param name="e"></param>
        private void tbCallback_Click(object sender, EventArgs e)
        {
            if (!(sender is TextBox)) throw new ArgumentException();

            if (keyfileState.keyfile == null)
            {
                return;
            }

            TextBox tbCallback = sender as TextBox;
            string callback = tbCallback.Name.Substring(2);

            var newBinding = KeystrokeGetter.Show(keyfileState.keyfile, callback);

            if (newBinding != null)
            {
                var bindings = keyfileState.keyfile.Bindings;
                bool found = false;
                for (int i = 0; i < bindings.Length; i++)
                {
                    if (callback.Equals(bindings[i].Callback))
                    {
                        bindings[i] = newBinding;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    // Add new callback entry
                    Array.Resize(ref bindings, bindings.Length + 1);
                    bindings[bindings.Length - 1] = newBinding;
                }
                keyfileState.keyfile.Bindings = bindings;

                ParseKeyFile();
                keyfileState.Changed = true;
                btnSaveKeyfile.Enabled = true;
            }
        }

        private void miNotifyExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void miNotifyStart_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void miNotifyStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (Settings.Default.MinimizeToSystemTray)
                {
                    MinimizeToSystemTray();
                }
            }
            else
            {
                RestoreFromSystemTray();
            }
        }

        private void miNotifySettings_Click(object sender, EventArgs e)
        {
            RestoreFromSystemTray();
        }

        private void nfyTrayIcon_DoubleClick(object sender, EventArgs e)
        {
            RestoreFromSystemTray();
        }

        #endregion
    }
}
