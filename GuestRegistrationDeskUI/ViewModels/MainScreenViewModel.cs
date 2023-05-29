using Caliburn.Micro;
using GuestRegistrationDesktopUI.Library.FiScanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDeskUI.ViewModels
{
    public class MainScreenViewModel : Screen
    {
        public IFiScan _fiScan;
        public MainScreenViewModel(IFiScan fiScan)
        {
            _fiScan = fiScan;
        }

        public void ScanIDCard()
        {
            _fiScan.LoadScanner();
        }
    }
}
