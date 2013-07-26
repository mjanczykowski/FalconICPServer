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
using KeyboardInput;

namespace FalconICPServer
{
    class ICPServer : IDisposable
    {
        public event EventHandler<ConnectionEventArgs> ConnectionEstablished;
        public event EventHandler<ConnectionEventArgs> ConnectionLost;
        public event EventHandler<ButtonPressEventArgs> ButtonPressed;

        /// <summary>
        /// Falcon SharedMemory reader
        /// </summary>
        private Reader _smReader;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private volatile bool _disposed;

        private TcpListener tcpListener;
        private TcpClient tcpClient;
        private Thread clientThread;

        private static readonly object _locker = new object();

        public ICPServer()
        {
            _smReader = new Reader();
        }

        /// <summary>
        /// Runs Server
        /// </summary>
        public void Start()
        {
            logger.Info("Running server");

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

            tcpListener.Stop();
            
            //Close client thread
            lock (_locker)
            {
                if (tcpClient != null)
                {
                    tcpClient.Client.Disconnect(false);
                    tcpClient.Close();
                    tcpClient = null;
                }
            }
            
            if (clientThread != null)
            {
                CloseClientThread();
            }

            
        }

        /// <summary>
        /// Callback for the accept tcpclient operation.
        /// </summary>
        /// <param name="result">The async result object</param>
        private void AcceptTcpClientCallback(IAsyncResult asyncResult)
        {
            logger.Debug("Incoming connection");

            var listener = (TcpListener)asyncResult.AsyncState;

            // If the listener has been closed during callback
            if (listener.Server == null || !listener.Server.IsBound)
            {
                return;
            }

            try
            {
                if (clientThread != null)
                {
                    CloseClientThread();
                }

                lock (_locker)
                {
                    tcpClient = listener.EndAcceptTcpClient(asyncResult);

                    var ipAddress = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                    this.OnConnected(new ConnectionEventArgs(ipAddress));
                }

                logger.Debug("Connection established");

                // Run new client thread
                clientThread = new Thread(RunClientThread);
                clientThread.Start();



                // Listen for next connection (in case the current gets broken, etc.)
                listener.BeginAcceptTcpClient(new AsyncCallback(AcceptTcpClientCallback), listener);
            }
            catch (SocketException e) { logger.Debug(e); }
            catch (ObjectDisposedException e) { logger.Debug(e); }
            catch (Exception e) { logger.Error(e); }
        }

        /*
        private void ReadCallback(IAsyncResult asyncResult)
        {
            var buffer = (byte[]) asyncResult.AsyncState;

            if (tcpClient == null)
                return;
            NetworkStream networkStream = tcpClient.GetStream();
            int read = networkStream.EndRead(asyncResult);
            if (read == 0)
            {
                logger.Debug("Read 0 bytes");
                return;
            }

            var encoding = Encoding.ASCII;
            string message = encoding.GetString(buffer, 0, read);
            logger.Debug(message + " " + message.Length);

            switch (message)
            {
                case "BYE":
                    logger.Info("Connection closed by client");
                    //close connection
                    return;
                case "DED":
                    logger.Debug("ded");
                    var rawFlightData = _smReader.GetRawPrimaryFlightData();

                    var ded = new byte[130];
                    var inverted = new byte[130];

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
                    networkStream.Write(ded, 0, ded.Length);

                    //SEND DED DATA
                    break;
                default:
                    //press_key(message)
                    break;
            }
            
            networkStream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReadCallback), buffer);
        }
        */

        private void RunClientThread()
        {
            Thread.CurrentThread.Priority = Settings.Default.Priority;
            Thread.CurrentThread.IsBackground = true;

            NetworkStream networkStream;

            lock (_locker)
            {
                networkStream = tcpClient.GetStream();
            }

            var ded = new byte[130];
            var inverted = new byte[130];
            var buffer = new byte[32];

            int readBytes = 0;

            try
            {
                while((readBytes = networkStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    logger.Debug("read {0} bytes", readBytes);

                    //TODO: send data to client and get messages

                    var encoding = Encoding.ASCII;
                    string message = encoding.GetString(buffer, 0, readBytes);
                    logger.Debug(message + " " + message.Length);

                    if (!message.Equals("ded"))
                    {
                        this.OnButtonPressed(new ButtonPressEventArgs(message));
                    }

                    //END TODO

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

                    networkStream.Write(ded, 0, ded.Length);
                }
                CloseConnection();
            }
            catch (System.IO.IOException) { logger.Debug("Connection closed IOException"); }

            this.OnDisconnected(new ConnectionEventArgs(null));
            logger.Debug("client thread finished");
        }
        
        /// <summary>
        /// Disconnects client and closes current thread to avoid having two active connections
        /// </summary>
        private void CloseConnection()
        {
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
        /// Closes running client thread.
        /// </summary>
        private void CloseClientThread()
        {
            CloseConnection();
            //clientThread.Join();
            clientThread = null;
        }

        /*
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
        */

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

        private void OnButtonPressed(ButtonPressEventArgs e)
        {
            if (ButtonPressed != null)
            {
                ButtonPressed(this, e);
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
                if (disposing && _smReader != null)
                {
                    try
                    {
                        _smReader.Dispose();
                    }
                    catch (Exception) { }
                }
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

    public class ButtonPressEventArgs : EventArgs
    {
        private readonly string callback;

        public ButtonPressEventArgs(string callback)
        {
            this.callback = callback;
        }

        public string Callback
        {
            get { return callback; }
        }
    }
}
