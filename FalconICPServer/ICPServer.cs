using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using F4SharedMem;
using FalconICPServer.Properties;

namespace FalconICPServer
{
    class ICPServer : IDisposable
    {
        /// <summary>
        /// Falcon SharedMemory reader
        /// </summary>
        private Reader _smReader;

        private volatile bool _running;
        private volatile bool _disposed;

        /// <summary>
        /// Runs Server
        /// </summary>
        public void RunServer()
        {
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
                var flightData = _smReader.GetRawPrimaryFlightData();
                Thread.Sleep(Settings.Default.PollingFrequencyMilliseconds);
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Stops ICP Server
        /// </summary>
        public void StopServer()
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
