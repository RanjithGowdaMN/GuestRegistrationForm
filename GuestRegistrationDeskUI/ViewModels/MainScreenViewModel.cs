using Caliburn.Micro;
using GuestRegistrationDesktopUI.Library.CentralHub;
using System.ComponentModel;
using System.Windows;


namespace GuestRegistrationDeskUI.ViewModels
{
    public class MainScreenViewModel : Screen, INotifyPropertyChanged
    {
        private ICentralHub _centralHub;

        public MainScreenViewModel(ICentralHub centralHub)
        {
            _centralHub = centralHub;
        }
        ~MainScreenViewModel()
        {
            
        }
        //Scan Button clicked
        public void ScanIDCard()
        {
            //_fiScan.StartScanning();
            //var result = _fiScan.StartScanning();
            var result = _centralHub.StartScanning();
            //VisitorDetailsValue = "Scanned Data: " + result.ToString();
            visitorName = result.Name == null ? "Error/ please rescan" : result.Name;
            visitorIDNo = result.IDno == null ? "Error/ please rescan" : result.IDno;
            visitorDOB = result.DateOfBirth == null ? "Error/ please rescan" : result.DateOfBirth;
            visitorIDExpiry = result.Expiry == null ? "Error/ please rescan" : result.Expiry;
            visitorNationality = result.Nationality == null ? "Error/ please rescan" : result.Nationality;
        }

        //Take Photo Button Clicked
        public void TakePhoto()
        {
            var result = _centralHub.TakePhoto();
            if (!result.CameraSessionActive)
            {
                MessageBox.Show(result.ErrorMessage);
            }
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
