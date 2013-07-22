using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using F4SharedMem;
using FalconICPServer.Properties;
using NLog;

namespace FalconICPServer
{
    class ICPServer : IDisposable
    {
        public event EventHandler ConnectionEstablished;
        public event EventHandler ConnectionLost;

        /// <summary>
        /// Falcon SharedMemory reader
        /// </summary>
        private Reader _smReader;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private volatile bool _running;
        private volatile bool _connected;
        private volatile bool _disposed;

        private TcpListener tcpListener;
        private TcpClient tcpClient;

        private static readonly object _locker = new object();

        /// <summary>
        /// Runs Server
        /// </summary>
        public void Start()
        {
            logger.Info("Running server");

            if (_running)
            {
                throw new InvalidOperationException();
            }
            _running = true;
            _smReader = new Reader();

            var serverPort = Settings.Default.ServerPort;
            var port = 30456;
            Int32.TryParse(Settings.Default.ServerPort, out port);

            IPAddress ip = IPAddress.Parse("0.0.0.0");

            tcpListener = new TcpListener(ip, port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(AcceptTcpClientCallback), tcpListener);

            /*
            while (_running)
            {
                /*
                if (!listener.Pending)
                {
                    Thread.Sleep(50);
                    Application.DoEvents();
                    continue;
                }
                */
            /*
                using (TcpClient client = listener.AcceptTcpClient())
                {
                    //var flightData = _smReader.GetRawPrimaryFlightData();
                    var flightData = _smReader.GetCurrentData();
                    if (flightData == null)
                    {
                        logger.Debug("flightData is null");
                        flightData = new FlightData();
                    }

                    var dedLines = flightData.DEDLines;
                    var invertedDedLines = flightData.Invert;

                    string asd = MergeDEDLines(dedLines, invertedDedLines);

                    StringBuilder str = new StringBuilder();
                    for (int i = 0; i < asd.Length; i++)
                    {
                        str.Append((byte)asd[i]);
                        str.Append(" ");
                    }
                    logger.Debug(asd.Length);
                    logger.Debug(str.ToString());

                    Thread.Sleep(Settings.Default.UpdatePeriod);

                    client.Close();
                }
                //Application.DoEvents();
            }
            

            listener.Stop();
             */
        }


        /// <summary>
        /// Stops ICP Server
        /// </summary>
        public void Stop()
        {
            logger.Debug("Stop()");
            /*
            _running = false;
            listener.Stop();
            */

            tcpListener.Stop();

            lock (_locker)
            {
                if (tcpClient != null)
                {
                    tcpClient.Client.Disconnect(false);
                }
            }
        }

        /// <summary>
        /// Callback for the accept tcpclient operation.
        /// </summary>
        /// <param name="result">The async result object</param>
        private void AcceptTcpClientCallback(IAsyncResult asyncResult)
        {
            logger.Debug("AcceptTCPClientCallback(result)");

            var listener = (TcpListener)asyncResult.AsyncState;

            // If the listener has been closed during callback
            if (listener.Server == null || !listener.Server.IsBound)
            {
                return;
            }

            try
            {
                lock (_locker)
                {
                    // Close connection if we're still connected or it's broken
                    if (tcpClient != null)
                    {
                        tcpClient.Client.Disconnect(false);
                        tcpClient.Close();
                        tcpClient = null;
                    }
                    tcpClient = listener.EndAcceptTcpClient(asyncResult);
                    this.OnConnected(EventArgs.Empty);

                    logger.Debug("connection established");
                    /*
                    NetworkStream networkStream = tcpClient.GetStream();
                    networkStream.BeginRead(
                    */
                }
            }
            catch (SocketException e) { logger.Debug(e);  }
            catch (ObjectDisposedException e) { logger.Debug(e); }

            // Listen for next connection (in case the current gets broken, etc.)
            listener.BeginAcceptTcpClient(new AsyncCallback(AcceptTcpClientCallback), listener);

            logger.Debug("AcceptTCPClientCallback exit");
        }

        /// <summary>
        /// Merges dedLines into one 200-char string to send it.
        /// </summary>
        /// <param name="dedLines">DED Lines from Shared Memory</param>
        /// <param name="invertedDedLines">Inverted DED Lines from Shared Memory</param>
        /// <returns>Merged strings representing DED Lines + invert information</returns>
        private string MergeDEDLines(string[] dedLines, string[] invertedDedLines)
        {
            StringBuilder str = new StringBuilder(250);
            for (int i = 0; i < 5; i++)
            {
                if (dedLines[i] == null || invertedDedLines[i] == null || dedLines[i].Length != 25 || invertedDedLines[i].Length != 25)
                {
                    str.Clear();
                    str.Append(' ', 50);
                    str.Append(Resources.ded_info_connected);
                    str.Append(' ', 50 - Resources.ded_info_connected.Length);
                    str.Append(Resources.ded_info_no_flight_data);
                    str.Append(' ', 150 - Resources.ded_info_no_flight_data.Length);
                    return str.ToString();
                }
                else
                {
                    str.Append(dedLines[i] + invertedDedLines[i]);
                }
            }
            return str.ToString();
        }

        private void OnConnected(EventArgs e)
        {
            logger.Debug("OnConnected");
            if (ConnectionEstablished != null)
            {
                ConnectionEstablished(this, e);
            }
        }

        private void OnDisconnected(EventArgs e)
        {
            if (ConnectionLost != null)
            {
                ConnectionLost(this, e);
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        internal void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if(disposing && _smReader != null)
                    try
                    {
                        _smReader.Dispose();
                    }
                    catch(Exception) {}
                }
                _disposed = true;
        }
    }
}
