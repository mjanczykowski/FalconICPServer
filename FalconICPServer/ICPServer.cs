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
        public event EventHandler<ConnectionEventArgs> ConnectionEstablished;
        public event EventHandler<ConnectionEventArgs> ConnectionLost;

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
        private Thread clientThread;

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

            var serverPort = Settings.Default.ServerPort;
            var port = 30456;
            Int32.TryParse(Settings.Default.ServerPort, out port);

            IPAddress ip = IPAddress.Parse("0.0.0.0");

            tcpListener = new TcpListener(ip, port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(AcceptTcpClientCallback), tcpListener);
        }


        /// <summary>
        /// Stops ICP Server
        /// </summary>
        public void Stop()
        {
            logger.Debug("Stop()");

            if (clientThread != null)
            {
                StopClientThread();
            }

            _running = false;
            
            tcpListener.Stop();

            lock (_locker)
            {
                if (tcpClient != null)
                {
                    tcpClient.Client.Disconnect(false);
                    tcpClient.Close();
                    tcpClient = null;
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
                // Close connection if we're still connected or it's broken
                if (clientThread != null)
                {
                    StopClientThread();
                }

                lock (_locker)
                {
                    tcpClient = listener.EndAcceptTcpClient(asyncResult);

                    var ipAddress = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                    this.OnConnected(new ConnectionEventArgs(ipAddress));
                }

                logger.Debug("connection established");

                // Run new client thread
                _running = true;
                clientThread = new Thread(RunClientThread);
                clientThread.Start();

                // Listen for next connection (in case the current gets broken, etc.)
                listener.BeginAcceptTcpClient(new AsyncCallback(AcceptTcpClientCallback), listener);
            }
            catch (SocketException e) { logger.Debug(e); }
            catch (ObjectDisposedException e) { logger.Debug(e); }
            catch (Exception e) { logger.Error(e); }

            logger.Debug("AcceptTCPClientCallback exit");
        }

        private void RunClientThread()
        {
            Thread.CurrentThread.Priority = Settings.Default.Priority;

            if (_smReader != null)
            {
                throw new InvalidOperationException();
            }
            _smReader = new Reader();

            var ded = new byte[130];
            var inverted = new byte[130];

            while (_running)
            {
                //TODO: send data to client and get messages

                var rawFlightData = _smReader.GetRawPrimaryFlightData();

                if (rawFlightData != null)
                {
                    Array.Copy(rawFlightData, 236, ded, 0, 130);
                    Array.Copy(rawFlightData, 236 + 130, inverted, 0, 130);

                    for (int i = 0; i < 130; i++)
                    {
                        if (inverted[i] == 2)
                        {
                            ded[i] += 128;
                        }
                    }
                }               
                
                Thread.Sleep(Settings.Default.UpdatePeriod);
            }

            tcpClient.Client.Disconnect(false);
            tcpClient.Close();
            tcpClient = null;
            _smReader.Dispose();
            _smReader = null;

            logger.Debug("client thread finished");
        }

        /// <summary>
        /// Disconnects client and closes current thread to avoid having two active connections
        /// </summary>
        private void StopClientThread()
        {
            _running = false;
            clientThread.Join();
            clientThread = null;
            this.OnDisconnected(new ConnectionEventArgs(null));
        }

        /// <summary>
        /// Merges dedLines into one 250-char string to send it.
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

        private void OnConnected(ConnectionEventArgs e)
        {
            if (ConnectionEstablished != null)
            {
                ConnectionEstablished(this, e);
            }
        }

        private void OnDisconnected(ConnectionEventArgs e)
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
                        //_smReader.Dispose();
                    }
                    catch(Exception) {}
                }
                _disposed = true;
        }
    }

    public class ConnectionEventArgs : EventArgs
    {
        private readonly string ipAddress;

        public ConnectionEventArgs(string ipAddress)
        {
            this.ipAddress = ipAddress;
        }

        public string IpAddress
        {
            get { return ipAddress; }
        }
    }
}
