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
        /// <summary>
        /// Falcon SharedMemory reader
        /// </summary>
        private Reader _smReader;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private volatile bool _running;
        private volatile bool _disposed;

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

            while (_running)
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
                Application.DoEvents();
            }
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

        /// <summary>
        /// Stops ICP Server
        /// </summary>
        public void Stop()
        {
            _running = false;
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
