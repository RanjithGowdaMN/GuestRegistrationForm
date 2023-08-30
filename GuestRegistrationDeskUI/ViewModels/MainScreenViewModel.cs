using Caliburn.Micro;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDesktopUI.Library.Models;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GuestRegistrationDeskUI.ViewModels
{
    public class MainScreenViewModel : Screen, INotifyPropertyChanged
    {
        private ICentralHub _centralHub;
        private SimpleContainer _container;
        private bool _isPassport = true;
        private bool _isIDcard;
        private bool _isOther;
        private int _idType;
        public BitmapImage ImageToShow { get; set; }

        public MainScreenViewModel(ICentralHub centralHub, SimpleContainer container)
        {
            _centralHub = centralHub;
            _container = container;

            //load default/dummy image
            ImagePath = new BitmapImage(new Uri("D:\\VisitorData\\Photos\\photo00001.jpg"));

            _centralHub.CanonImageDownload += UpdatePhotoImage;
        }
        ~MainScreenViewModel()
        {
        }

        public void GenerateVisitorDocument()
        {
            VisitorDataModel visitorDataFromUI = new VisitorDataModel();
            visitorDataFromUI.IDno = visitorIDNo;
            visitorDataFromUI.Name = visitorName;
            visitorDataFromUI.DateOfBirth = visitorDOB;
            visitorDataFromUI.Expiry = visitorIDExpiry;
            visitorDataFromUI.Nationality = visitorNationality;
            visitorDataFromUI.IsPassport = IsPassport;
            _centralHub.GenerateDocument(visitorDataFromUI);
            
        }

        public void GenerateContractDocument()
        {
            VisitorDataModel visitorDataFromUI = new VisitorDataModel();
            visitorDataFromUI.IDno = visitorIDNo;
            visitorDataFromUI.Name = visitorName;
            visitorDataFromUI.DateOfBirth = visitorDOB;
            visitorDataFromUI.Expiry = visitorIDExpiry;
            visitorDataFromUI.Nationality = visitorNationality;
            visitorDataFromUI.IsPassport = IsPassport;
            _centralHub.GenerateContractDocument(visitorDataFromUI);
        }

        public void UpdatePhotoImage(string path)
        {
            //ImagePath.Freeze();
            Application.Current.Dispatcher.Invoke(() =>
            {
                ImagePath = new BitmapImage(new Uri(path));
            });
        }

        //Scan Button clicked
        public void ScanIDCard()
        {
            string scannedFileNameFront = string.Empty;
            _idType = _isPassport ? 2 : 1;
            Application.Current.Dispatcher.Invoke(() =>
            {
                (var result, string fileName) = _centralHub.StartScanning(_idType);
                visitorName = result.Name == null ? "Error/ please rescan" : result.Name;
                visitorIDNo = result.IDno == null ? "Error/ please rescan" : result.IDno;
                visitorDOB = result.DateOfBirth == null ? "Error/ please rescan" : result.DateOfBirth;
                visitorIDExpiry = result.Expiry == null ? "Error/ please rescan" : result.Expiry;
                visitorNationality = result.Nationality == null ? "Error/ please rescan" : result.Nationality;
                scannedFileNameFront = fileName;
            });

            Application.Current.Dispatcher.Invoke(() =>
            {
                //scannedFileNameFront
            });
        }

        public void ScanIDBackSide() {
            _idType = _isPassport ? 2 : 1;
            _centralHub.ScanBackSide(_idType);
            Application.Current.Dispatcher.Invoke(() =>
            {
                //TDB Dispatch image to UI
            });
        }

        //Take Photo Button Clicked
        public void TakePhoto()
        {
            var result = _centralHub.TakePhoto();
            if (!result.CameraSessionActive)
            {
                MessageBox.Show(result.ErrorMessage);
                //_centralHub = _container.GetInstance<ICentralHub>();
            }
            else
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    ImagePath = new BitmapImage(new Uri("D:\\VisitorData\\Photos\\photo00003.jpg"));
                });
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

        private BitmapImage _imagePath;
        public BitmapImage ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        public bool IsPassport
        {
            get { return _isPassport; }
            set
            {
                if (IsPassport != value)
                {
                    _isPassport = value;
                    OnPropertyChanged(nameof(_isPassport));
                }
            }
        }
        public bool IsOther
        {
            get { return _isOther; }
            set
            {
                if (IsOther != value)
                {
                    _isOther = value;
                    OnPropertyChanged(nameof(_isOther));
                }
            }
        }
        public bool IsIDcard
        {
            get { return _isIDcard; }
            set
            {
                if (IsIDcard != value)
                {
                    _isIDcard = value;
                    OnPropertyChanged(nameof(_isIDcard));
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
