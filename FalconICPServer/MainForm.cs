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
using NLog;
using FalconICPServer.Properties;

namespace FalconICPServer
{
    public partial class MainForm : Form
    {
        private ICPServer icpServer;
        private Logger logger = LogManager.GetCurrentClassLogger();

        public MainForm()
        {
            InitializeComponent();
        }

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

        private void tsbStart_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void tsbStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private string getLocalIpAddress()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress ip in host.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
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
        }

        private void IcpServer_ConnectionEstablished(object sender, ConnectionEventArgs e)
        {
            lbClientIP.Invoke((MethodInvoker)(() => lbClientIP.Text = e.IpAddress));
        }

        private void IcpServer_ConnectionLost(object sender, ConnectionEventArgs e)
        {
            lbClientIP.Invoke((MethodInvoker)(() => lbClientIP.Text = "-"));
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
    }
}
