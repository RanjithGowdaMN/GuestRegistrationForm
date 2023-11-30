using gui;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuestRegistrationWinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogManager.LoadConfiguration("NLog.config");
            Logger.Info("Application started");
            Application.Run(new FormMain());
        }
    }
}
