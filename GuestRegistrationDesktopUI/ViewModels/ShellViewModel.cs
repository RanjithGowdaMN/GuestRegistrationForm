using Fi800ScanLibrary.Scanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.ViewModels
{
    public class ShellViewModel
    {
        private IScanDocument _scanDocument;
        public ShellViewModel(IScanDocument scanDocument)
        {
            _scanDocument = scanDocument;
            scanDocument.OpenScanner();
            scanDocument.StartScan();
        }


    }
}
