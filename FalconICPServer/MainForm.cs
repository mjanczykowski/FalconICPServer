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

        #region server methods

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

            gbConnection.Enabled = false;
            gbPerformance.Enabled = false;
            gbGeneral.Enabled = false;

            if (chkLaunchMinimized.Checked)
            {
                if (chkMinimizeToSystemTray.Checked)
                {
                    //TODO Minimize to sysytem tray
                }
                else
                {
                    WindowState = FormWindowState.Minimized;
                }
            }

            tsbStop.Enabled = true;

            icpServer.Start();
        }

        private void StopServer()
        {
            // Revert to normal priority.
            Thread.CurrentThread.Priority = ThreadPriority.Normal;

            tsbStop.Enabled = false;

            icpServer.Stop();
            try
            {
                icpServer.Dispose();
                icpServer = null;
            }
            catch (Exception e)
            {
                logger.Debug(e);
            }

            gbConnection.Enabled = true;
            gbGeneral.Enabled = true;
            gbPerformance.Enabled = true;
            tsbStart.Enabled = true;
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

        #endregion

        private void tsbStart_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void tsbStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbServerIP.Text = getLocalIpAddress();
            foreach (var priority in Enum.GetNames(typeof (ThreadPriority)))
            {
                if (priority.ToLowerInvariant() != "highest")
                {
                    cbPriority.Items.Add(priority);
                }
            }
            LoadSettings();
            LoadKeyFile();
        }

        private void IcpServer_ConnectionEstablished(object sender, ConnectionEventArgs e)
        {
            lbClientIP.Invoke((MethodInvoker)(() => lbClientIP.Text = e.IpAddress));
        }

        private void IcpServer_ConnectionLost(object sender, ConnectionEventArgs e)
        {
            lbClientIP.Invoke((MethodInvoker)(() => lbClientIP.Text = "-"));
        }

        private void IcpServer_ButtonPressed(object sender, ButtonPressEventArgs e)
        {
            KeyBinding keystroke;
            if (keyfileState.bindings.TryGetValue(e.Callback, out keystroke))
            {
                KeyfileUtils.SendKeystroke(keystroke);
            }
        }

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

        private void LoadKeyFile()
        {
            if (string.IsNullOrEmpty(Settings.Default.KeyfilePath))
            {
                //TODO: try to load path from BMS path
                return;
            }

            try
            {
                LoadKeyFile(Settings.Default.KeyfilePath);
            }
            catch(Exception)
            {
                logger.Debug("Key file load error");
            }
        }

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
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("An error occured while loading key file.\n\n{0}", e.StackTrace),
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                logger.Info(e.Message);
                if (!string.IsNullOrEmpty(oldKeyfilePath))
                {
                    LoadKeyFile(oldKeyfilePath);
                }
            }

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
                #region adding callbacks
                callbackToTextBox.Add("SimWarnReset", tbSimWarnReset);
                callbackToTextBox.Add("SimICPCom1", tbSimICPCom1);
                callbackToTextBox.Add("SimICPCom2", tbSimICPCom2);
                //"SimICPIFF"
                callbackToTextBox.Add("SimICPLIST", tbSimICPLIST);
                callbackToTextBox.Add("SimICPAA", tbSimICPAA);
                callbackToTextBox.Add("SimICPAG", tbSimICPAG);
                callbackToTextBox.Add("SimICPDEDDOWN", tbSimICPDEDDOWN);
                callbackToTextBox.Add("SimICPDEDUP", tbSimICPDEDUP);
                callbackToTextBox.Add("SimICPDEDSEQ", tbSimICPDEDSEQ);
                callbackToTextBox.Add("SimICPResetDED", tbSimICPResetDED);
                callbackToTextBox.Add("SimICPCLEAR", tbSimICPCLEAR);
                callbackToTextBox.Add("OTWToggleFrameRate", tbSimICPTILS);
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

                    string desc = KeyfileUtils.GetKeyDescription(keyBinding);
                    if (desc == null)
                    {
                        pair.Value.BackColor = Color.LightCoral;
                        pair.Value.Text = "";
                    }
                    else
                    {
                        pair.Value.BackColor = (Color)System.Drawing.SystemColors.Window;
                        pair.Value.Text = desc;
                    }
                }
            }
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
            //TODO

            Settings.Default.LaunchAtWindowsStartup = chkLaunchAtStartup.Checked;
            Settings.Default.Save();
        }

        private class KeyfileState
        {
            public bool Changed;

            public KeyFile keyfile;
            public string keyfilePath;

            #region callbacks
            public static string[] Callbacks = {
                                                   "SimWarnReset",
                                                   "SimICPCom1",
                                                   "SimICPCom2",
                                                   //"SimICPIFF",
                                                   "SimICPLIST",
                                                   "SimICPNav",
                                                   "SimICPAA",
                                                   "SimICPAG",
                                                   "SimICPDEDDOWN",
                                                   "SimICPDEDUP",
                                                   "SimICPDEDSEQ",
                                                   "SimICPResetDED",
                                                   "SimICPCLEAR",
                                                   "SimICPTILS",
                                                   "SimICPALOW",
                                                   "SimICPTHREE",
                                                   "SimICPStpt",
                                                   "SimICPCrus",
                                                   "SimICPSIX",
                                                   "SimICPMark",
                                                   "SimICPEIGHT",
                                                   "SimICPNINE",
                                                   "SimICPZERO",
                                                   "SimICPEnter",
                                                   "SimICPNext",
                                                   "SimICPPrevious",
                                                   "SimDriftCOOn",
                                                   "SimDriftCOOff",
                                                   "OTWToggleFrameRate" };
            #endregion

            public Dictionary<string, KeyBinding> bindings = new Dictionary<string, KeyBinding>();
        }
    }
}
