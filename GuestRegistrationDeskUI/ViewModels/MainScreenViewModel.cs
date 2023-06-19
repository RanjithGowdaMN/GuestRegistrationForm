using Caliburn.Micro;
using GuestRegistrationDesktopUI.Library.FiScanner;
using GuestRegistrationDeskUI.Models;
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
        public VisitorData visitorData;

        public MainScreenViewModel(IFiScan fiScan)
        {
            _fiScan = fiScan;
            //VisitorDetailsValue = "Scanned Data: ...";
            visitorName = "test Data...";
        }

        public void ScanIDCard()
        {

            //_fiScan.StartScanning();
            var result = _fiScan.StartScanning();
            //VisitorDetailsValue = "Scanned Data: " + result.ToString();
            visitorName = result.Name == null ? "Error/ please rescan" : result.Name;
            visitorIDNo = result.IDno == null ? "Error/ please rescan" : result.IDno;
            visitorDOB = result.DateOfBirth == null ? "Error/ please rescan" : result.DateOfBirth;
            visitorIDExpiry = result.Expiry == null ? "Error/ please rescan" : result.Expiry;
            visitorNationality = result.Nationality == null ? "Error/ please rescan" : result.Nationality;
        }

        private string _visitorName;

        public string visitorName
        {
            get { return _visitorName; }
            set
            {
                if (_visitorName != value)
                {
                    _visitorName = value;
                    OnPropertyChanged(nameof(visitorName));
                }
            }
        }

        private string _visitorIDNo;

        public string visitorIDNo
        {
            get { return _visitorIDNo; }
            set
            {
                if (_visitorIDNo != value)
                {
                    _visitorIDNo = value;
                    OnPropertyChanged(nameof(visitorIDNo));
                }
            }
        }

        private string _visitorDOB;

        public string visitorDOB
        {
            get { return _visitorDOB; }
            set
            {
                if (_visitorDOB != value)
                {
                    _visitorDOB = value;
                    OnPropertyChanged(nameof(visitorDOB));
                }
            }
        }

        private string _visitorIDExpiry;

        public string visitorIDExpiry
        {
            get { return _visitorIDExpiry; }
            set
            {
                if (_visitorIDExpiry != value)
                {
                    _visitorIDExpiry = value;
                    OnPropertyChanged(nameof(visitorIDExpiry));
                }
            }
        }

        private string _visitorNationality;

        public string visitorNationality
        {
            get { return _visitorNationality; }
            set
            {
                if (_visitorNationality != value)
                {
                    _visitorNationality = value;
                    OnPropertyChanged(nameof(visitorNationality));
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
