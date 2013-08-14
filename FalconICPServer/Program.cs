using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NLog;

namespace FalconICPServer
{
    static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Handler for UI Thread exceptions
            Application.ThreadException += UIThreadException;

            // Catch all Windows Forms exceptions
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Handler for non-UI Threads exceptions
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            // log the exception
            logger.Fatal(args.ExceptionObject.ToString());
            MessageBox.Show("Unhandled exception. Application will close", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            Environment.Exit(1);
        }

        private static void UIThreadException(object sender, ThreadExceptionEventArgs args)
        {
            // log the exception
            logger.Fatal(args.Exception.ToString());
            MessageBox.Show("Unhandled exception. Application will close", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            Environment.Exit(1);
        }
    }
}
