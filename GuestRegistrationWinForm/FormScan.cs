//using GuestRegistrationDeskUI.ViewModels;
using GenerateDocument.Library;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDesktopUI.Library.OCR;
using GuestRegistrationWinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesseractOCR.Library;

namespace gui
{
    public partial class FormScan : Form
    {
        public static ICentralHub _centralHub;
        public FormScan(ICentralHub centralHub)
        {
            _centralHub = centralHub;
            InitializeComponent();
        }

        private void btnfront_Click(object sender, EventArgs e)
        {
            //MainScreenViewModel mainscreenVM = new MainScreenViewModel();

            _centralHub.StartScanning(2);

        }
    }
}
