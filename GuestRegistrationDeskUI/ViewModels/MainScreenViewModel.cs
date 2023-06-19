using Caliburn.Micro;
using GuestRegistrationDesktopUI.Library.FiScanner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace GuestRegistrationDeskUI.ViewModels
{
    public class MainScreenViewModel : Screen, INotifyPropertyChanged
    {
        private IFiScan _fiScan;
        public string visitorDetails = "Scanned Information: ";

        public MainScreenViewModel(IFiScan fiScan)
        {
            _fiScan = fiScan;
            VisitorDetailsValue = "Scanned Data: ...";
        }

        public void ScanIDCard()
        {
            //_fiScan.StartScanning();
            string result = _fiScan.StartScanning();
            VisitorDetailsValue = "Scanned Data: " + result;
        }


        private string _visitorDetails;

        public string VisitorDetailsValue
        {
            get { return _visitorDetails; }
            set
            {
                if (_visitorDetails != value)
                {
                    _visitorDetails = value;
                    OnPropertyChanged(nameof(VisitorDetailsValue));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
