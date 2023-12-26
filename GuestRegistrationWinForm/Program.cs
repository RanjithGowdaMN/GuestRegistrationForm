using gui;
using NLog;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public static Size originalSize;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogManager.LoadConfiguration("NLog.config");
            Logger.Info("Application started");

            //Form.ActiveForm..AutoScaleDimensions = Size.Empty;
            Form formMain = new FormMain();
            formMain.AutoScaleMode = AutoScaleMode.None;
            formMain.AutoSize = false;
            formMain.AutoScaleDimensions = originalSize;
            formMain.AutoSizeMode = AutoSizeMode.GrowOnly;
            formMain.AutoScaleMode = AutoScaleMode.Dpi;
            formMain.Resize += FormMain_Resize;
            originalSize = formMain.Size;
            
            Application.Run(formMain);

        }

        private static void FormMain_Resize(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
