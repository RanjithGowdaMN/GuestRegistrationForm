using Caliburn.Micro;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDesktopUI.Library.Models;
using GuestRegistrationDeskUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;

namespace GuestRegistrationDeskUI.ViewModels
{
    public class MainScreenViewModel : Screen, INotifyPropertyChanged
    {
        private ICentralHub _centralHub;
        private SimpleContainer _container;
        private IEventAggregator _events;
        private int _idType;
        

        public UIbindingModel cmdData;
        public BitmapImage ImageToShow { get; set; }

        public event EventHandler<string> DocumentGeneratedEvent; //MentionFileGeneration

        public MainScreenViewModel(ICentralHub centralHub, SimpleContainer container, IEventAggregator events)
        {
            cmdData = new UIbindingModel();
            LoadData();
            _centralHub = centralHub;
            _container = container;
            _events = events;
            //load default/dummy image
            resetDefaultImage();
            _centralHub.CanonImageDownload += UpdatePhotoImage;
            DocumentGeneratedEvent += sendFileForUpdate;

        }
        ~MainScreenViewModel()
        {
        }


        public void resetDefaultImage()
        {
            ImagePath = new BitmapImage(new Uri("D:\\VisitorData\\Photos\\photo00001.jpg"));
            ImagePathfront = new BitmapImage(new Uri("D:\\VisitorData\\temp\\IDCardFront.jpg"));
            ImagePathBack = new BitmapImage(new Uri("D:\\VisitorData\\temp\\IDCardBack.jpg"));
        }

        public void PrintVisitorIdCard()
        {
            if (MessageForPhoto())
            {
                _centralHub.PrintIdCard(visitorName, "VISITOR");
                ResetOrClearAllFields();
                MessageBox.Show("File Created!");
            }

            return;
        }

        public void PrintContractIdCard()
        {
            if (MessageForPhoto())
            {
                _centralHub.PrintIdCard(visitorName, "CONTRACTOR");
                ResetOrClearAllFields();
                MessageBox.Show("File Created!");
            }
            return;
        }
       
        public void GenerateVisitorDocument()
        {
            if (MessageForPhoto())
            {
                //ConvertPdfToImages("", "");
                GeneratedDocumentName = sendDetails("visitor");
                MessageBox.Show("File Created!");
                // raise event here
                //DocumentGeneratedEvent?.Invoke(this, GeneratedFileName);

            }
            return;
        }

        public void sendFileForUpdate(object obj, string fileName)
        {
            //ConvertPdfToImages("", "");
        }

        public void GenerateContractDocument()
        {
            if (MessageForPhoto())
            {
                GeneratedDocumentName = sendDetails("contract");
                MessageBox.Show("File Created!");
            }
            return;
        }

        public void UpdatePhotoImage(string path)
        {
            //ImagePath.Freeze();
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    ImagePath = new BitmapImage(new Uri(path));
                }
                catch (Exception)
                {
                }
            });
        }

        public bool MessageForPhoto()
        {
            if (ImagePath.UriSource.AbsoluteUri == "file:///D:/VisitorData/Photos/photo00001.jpg")
            {
                var Result = MessageBox.Show("Photo Not Taken, Proceed without photo", "Guest Photo !!", MessageBoxButton.YesNo);
                if (Result.ToString() == "No")
                {
                    return false;
                }
            }
            return true;
        }

        //Scan Button clicked
        public void ScanIDCard()
        {
            string scannedFileNameFront = string.Empty;
            _idType = _isPassport ? 2 : 1;
            Application.Current.Dispatcher.Invoke(() =>
            {
                (var result, string fileName) = _centralHub.StartScanning(_idType);
                Thread.Sleep(1000);
                visitorName = result.Name == null ? "Error/ please rescan" : result.Name;
                visitorIDNo = result.IDno == null ? "Error/ please rescan" : result.IDno;
                visitorDOB = result.DateOfBirth == null ? "Error/ please rescan" : result.DateOfBirth;
                visitorIDExpiry = result.Expiry == null ? "Error/ please rescan" : result.Expiry;
                visitorNationality = result.Nationality == null ? "Error/ please rescan" : result.Nationality;
                scannedFileNameFront = fileName;
            }, System.Windows.Threading.DispatcherPriority.Normal);

            Application.Current.Dispatcher.Invoke(() =>
            {
                ImagePathfront = new BitmapImage(new Uri(scannedFileNameFront));

            });
        }

        public void ScanIDBackSide()
        {
            _idType = _isPassport ? 2 : 1;
            string scannedFileNameBack = string.Empty;
            scannedFileNameBack = _centralHub.ScanBackSide(_idType);
            Application.Current.Dispatcher.Invoke(() =>
            {
                ImagePathBack = new BitmapImage(new Uri(scannedFileNameBack));
            });
        }

        public static void ShowMessages(string message)
        {
            MessageBox.Show(message);
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

        private string sendDetails(string visitorType)
        {
            #region DataTransfer
            VisitorDataModel visitorDataFromUI = new VisitorDataModel();
            visitorDataFromUI.IDno = visitorIDNo;
            visitorDataFromUI.Name = visitorName;
            visitorDataFromUI.DateOfBirth = visitorDOB;
            visitorDataFromUI.Expiry = visitorIDExpiry;
            visitorDataFromUI.Nationality = visitorNationality;
            visitorDataFromUI.IsPassport = IsPassport;

            VisitorDataSheet visitorDataSheet = new VisitorDataSheet();
            visitorDataSheet.AreaVisited = AreaVisited;
            visitorDataSheet.Company = Company;
            visitorDataSheet.Date = vdsDate;
            visitorDataSheet.DepartmentManager = DepartmentManager;
            visitorDataSheet.PersontobeVisited = PersontobeVisited;
            visitorDataSheet.ProductionManager = ProductionManager;
            visitorDataSheet.ReasonForVisit = ReasonForVisit;
            visitorDataSheet.SecurityController = SecurityController;
            visitorDataSheet.VisitDateTime = VisitDateTime;
            visitorDataSheet.VisitDuration = VisitDuration;
            visitorDataSheet.VisitorIdNo = VisitorIdNo;
            visitorDataSheet.VisitorName = vdsVisitorName;


            ConfidentialityAgreementForVisitor confidentialityAgreementForVisitor = new ConfidentialityAgreementForVisitor();
            confidentialityAgreementForVisitor.Name = caForvName;
            confidentialityAgreementForVisitor.Company = cavCompany;
            confidentialityAgreementForVisitor.Date = cavDate;
            confidentialityAgreementForVisitor.Title = Title;

            VisitorsLogBook visitorsLogBook = new VisitorsLogBook();
            visitorsLogBook.IdDateOfIssue = IdDateOfIssue;
            visitorsLogBook.ArrivalTime = ArrivalTime;
            visitorsLogBook.Date = Date;
            visitorsLogBook.DepartureTime = DepartureTime;
            visitorsLogBook.EmployeetobeVisited = EmployeetobeVisited;
            visitorsLogBook.PlaceOfIssue = PlaceOfIssue;
            visitorsLogBook.PurposeOfVisit = PurposeOfVisit;
            visitorsLogBook.VisitorAndCompanyName = VisitorAndCompanyName;
            visitorsLogBook.VisitorsBadgeNo = VisitorsBadgeNo;


            HighlySecurityControlAreaLog highlySecurityControlAreaLog = new HighlySecurityControlAreaLog();
            highlySecurityControlAreaLog.VistorsAndCompanyName = VistorsAndCompanyName;
            highlySecurityControlAreaLog.ArrivalTime = hscArrivalTime;
            highlySecurityControlAreaLog.Date = hscDate;
            highlySecurityControlAreaLog.DepartureTime = hscDepartureTime;
            highlySecurityControlAreaLog.PurposeoftheVisit = PurposeoftheVisit;
            highlySecurityControlAreaLog.VisitorsBadgeNo = hscVisitorsBadgeNo;


            ConsultantApplicationForm consultantApplicationForm = new ConsultantApplicationForm();
            consultantApplicationForm.Address = Address;
            consultantApplicationForm.CellPhone = CellPhone;
            consultantApplicationForm.City = City;
            consultantApplicationForm.CompanyName = CompanyName;
            consultantApplicationForm.DateandPlaceofIssue = DateandPlaceofIssue;
            consultantApplicationForm.Duration = Duration;
            consultantApplicationForm.Email = Email;
            consultantApplicationForm.EmergencyContactNo = EmergencyContactNo;
            consultantApplicationForm.FirstName = caFirstName;
            consultantApplicationForm.Homephone = Homephone;
            consultantApplicationForm.IdNo = IdNo;
            consultantApplicationForm.IsNo = IsNo;
            consultantApplicationForm.IsYes = IsYes;
            consultantApplicationForm.LastName = caLastName;
            consultantApplicationForm.MiddleName = caMiddleName;
            consultantApplicationForm.PassportNo = PassportNo;
            consultantApplicationForm.PassportValidity = PassportValidity;
            consultantApplicationForm.PurposeOfVisit = caPurposeOfVisit;
            consultantApplicationForm.SecurityNo = SecurityNo;
            consultantApplicationForm.State = State;
            consultantApplicationForm.Zip = Zip;

            ConcatenatedDataBinding concatenatedDataBinding = new ConcatenatedDataBinding();
            concatenatedDataBinding.visitorDataSheet = visitorDataSheet;
            concatenatedDataBinding.CAforVisitor = confidentialityAgreementForVisitor;
            concatenatedDataBinding.vlBook = visitorsLogBook;
            concatenatedDataBinding.hsaLog = highlySecurityControlAreaLog;
            concatenatedDataBinding.consultantApplicationForm = consultantApplicationForm;
            # endregion
            if (visitorType == "visitor")
            {
                return _centralHub.GenerateDocument(visitorDataFromUI, concatenatedDataBinding);
            }
            else if (visitorType == "contract")
            {
                return _centralHub.GenerateContractDocument(visitorDataFromUI, concatenatedDataBinding);
            }
            return "D:\\VisitorData\\BaseDocument\\Visitor.pdf";
        }

        private void ResetOrClearAllFields()
        {
            #region default    
            _visitorName = "";
            _visitorIDNo = "";
            _visitorDOB = "";
            _visitorIDExpiry = "";
            _visitorNationality = "";
            _vdsvisitorName = "";
            _vdsDate = "";
            _company = "";
            _visitorIdNo = "";
            _reasonForVisit = "";
            _persontobeVisited = "";
            _areaVisited = "";
            _visitDateTime = "";
            _visitDuration = "";
            _departmentManager = "";
            _productionManager = "";
            _securityController = "";
            _caForvName = "";
            _title = "";
            _cavCompany = "";
            _cavDate = "";
            _idDateOfIssue = "";
            _placeOfIssue = "";
            _visitorAndCompanyName = "";
            _visitorsBadgeNo = "";
            _purposeOfVisit = "";
            _date = "";
            _arrivalTime = "";
            _departureTime = "";
            _employeetobeVisited = "";
            _vistorsAndCompanyName = "";
            _purposeoftheVisit = "";
            _hscVisitorsBadgeNo = "";
            _hscDate = "";
            _hscArrivalTime = "";
            _hscDepartureTime = "";
            _caFirstName = "";
            _caMiddleName = "";
            _caLastName = "";
            _address = "";
            _city = "";
            _state = "";
            _zip = "";
            _email = "";
            _cellPhone = "";
            _homephone = "";
            _securityNo = "";
            _companyName = "";
            _idNo = "";
            _passportNo = "";
            _dateandPlaceofIssue = "";
            _passportValidity = "";
            _caPurposeOfVisit = "";
            _duration = "";
            _emergencyContactNo = "";

            visitorName = "";
            visitorIDNo = "";
            visitorDOB = "";
            visitorIDExpiry = "";
            visitorNationality = "";
            vdsVisitorName = "";
            vdsDate = "";
            Company = "";
            VisitorIdNo = "";
            ReasonForVisit = "";
            PersontobeVisited = "";
            AreaVisited = "";
            VisitDateTime = "";
            VisitDuration = "";
            DepartmentManager = "";
            ProductionManager = "";
            SecurityController = "";
            caForvName = "";
            Title = "";
            cavCompany = "";
            cavDate = "";
            IdDateOfIssue = "";
            PlaceOfIssue = "";
            VisitorAndCompanyName = "";
            VisitorsBadgeNo = "";
            PurposeOfVisit = "";
            Date = "";
            ArrivalTime = "";
            DepartureTime = "";
            EmployeetobeVisited = "";
            VistorsAndCompanyName = "";
            PurposeoftheVisit = "";
            hscVisitorsBadgeNo = "";
            hscDate = "";
            hscArrivalTime = "";
            hscDepartureTime = "";
            caFirstName = "";
            caMiddleName = "";
            caLastName = "";
            Address = "";
            City = "";
            State = "";
            Zip = "";
            Email = "";
            CellPhone = "";
            Homephone = "";
            SecurityNo = "";
            CompanyName = "";
            IdNo = "";
            PassportNo = "";
            DateandPlaceofIssue = "";
            PassportValidity = "";
            caPurposeOfVisit = "";
            Duration = "";
            EmergencyContactNo = "";
            #endregion
            resetDefaultImage();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        private string _generatedDocumentName;
        public string GeneratedDocumentName
        {
            get { return _generatedDocumentName; }
            set
            {
                if (_generatedDocumentName != value)
                {
                    _generatedDocumentName = value;
                    OnPropertyChanged(nameof(GeneratedDocumentName));
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

        private BitmapImage _imagePathfront;
        public BitmapImage ImagePathfront
        {
            get { return _imagePathfront; }
            set
            {
                _imagePathfront = value;
                OnPropertyChanged(nameof(ImagePathfront));
            }
        }

        private BitmapImage _imagePathBack;
        public BitmapImage ImagePathBack
        {
            get { return _imagePathBack; }
            set
            {
                _imagePathBack = value;
                OnPropertyChanged(nameof(ImagePathBack));
            }
        }
        private bool _isPassport = true;
        public bool IsPassport
        {
            get { return _isPassport; }
            set
            {
                if (IsPassport != value)
                {
                    _isPassport = value;
                    OnPropertyChanged(nameof(_isPassport));
                    ResetOrClearAllFields();
                }
            }
        }

        private bool _isOther;
        public bool IsOther
        {
            get { return _isOther; }
            set
            {
                if (IsOther != value)
                {
                    _isOther = value;
                    OnPropertyChanged(nameof(_isOther));
                    //ResetOrClearAllFields();
                }
            }
        }
        private bool _isIDcard;
        public bool IsIDcard
        {
            get { return _isIDcard; }
            set
            {
                if (IsIDcard != value)
                {
                    _isIDcard = value;
                    OnPropertyChanged(nameof(_isIDcard));
                    ResetOrClearAllFields();
                }
            }
        }

        //VisitorDataSheet
        #region property
        private string _vdsvisitorName; public string vdsVisitorName { get { return _vdsvisitorName; } set { if (_vdsvisitorName != value) { _vdsvisitorName = value; } } }
        private string _vdsDate; public string vdsDate { get { return _vdsDate; } set { if (_vdsDate != value) { _vdsDate = value; } } }
        private string _company; public string Company { get { return _company; } set { if (_company != value) { _company = value; } } }
        private string _visitorIdNo; public string VisitorIdNo { get { return _visitorIdNo; } set { if (_visitorIdNo != value) { _visitorIdNo = value; } } }
        private string _reasonForVisit; public string ReasonForVisit { get { return _reasonForVisit; } set { if (_reasonForVisit != value) { _reasonForVisit = value; } } }
        private string _persontobeVisited; public string PersontobeVisited { get { return _persontobeVisited; } set { if (_persontobeVisited != value) { _persontobeVisited = value; } } }
        private string _areaVisited; public string AreaVisited { get { return _areaVisited; } set { if (_areaVisited != value) { _areaVisited = value; } } }
        private string _visitDateTime; public string VisitDateTime { get { return _visitDateTime; } set { if (_visitDateTime != value) { _visitDateTime = value; } } }
        private string _visitDuration; public string VisitDuration { get { return _visitDuration; } set { if (_visitDuration != value) { _visitDuration = value; } } }
        private string _departmentManager; public string DepartmentManager { get { return _departmentManager; } set { if (_departmentManager != value) { _departmentManager = value; } } }
        private string _productionManager; public string ProductionManager { get { return _productionManager; } set { if (_productionManager != value) { _productionManager = value; } } }
        private string _securityController; public string SecurityController { get { return _securityController; } set { if (_securityController != value) { _securityController = value; } } }

        //ConfidentialityAgreementForVisitor
        private string _caForvName; public string caForvName { get { return _caForvName; } set { if (_caForvName != value) { _caForvName = value; } } }
        private string _title; public string Title { get { return _title; } set { if (_title != value) { _title = value; } } }
        private string _cavCompany; public string cavCompany { get { return _cavCompany; } set { if (_cavCompany != value) { _cavCompany = value; } } }
        private string _cavDate; public string cavDate { get { return _cavDate; } set { if (_cavDate != value) { _cavDate = value; } } }

        // Visitor Log Book
        private string _idDateOfIssue; public string IdDateOfIssue { get { return _idDateOfIssue; } set { if (IdDateOfIssue != value) { _idDateOfIssue = value; OnPropertyChanged(nameof(_idDateOfIssue)); } } }
        private string _placeOfIssue; public string PlaceOfIssue { get { return _placeOfIssue; } set { if (_placeOfIssue != value) { _placeOfIssue = value; OnPropertyChanged(nameof(_idDateOfIssue)); } } }
        private string _visitorAndCompanyName; public string VisitorAndCompanyName { get { return _visitorAndCompanyName; } set { _visitorAndCompanyName = value; } }
        private string _visitorsBadgeNo; public string VisitorsBadgeNo { get { return _visitorsBadgeNo; } set { if (_visitorsBadgeNo != value) { _visitorsBadgeNo = value; } } }
        private string _purposeOfVisit; public string PurposeOfVisit { get { return _purposeOfVisit; } set { if (_purposeOfVisit != value) { _purposeOfVisit = value; } } }
        private string _date; public string Date { get { return _date; } set { if (_date != value) { _date = value; } } }
        private string _arrivalTime; public string ArrivalTime { get { return _arrivalTime; } set { if (_arrivalTime != value) { _arrivalTime = value; } } }
        private string _departureTime; public string DepartureTime { get { return _departureTime; } set { if (_departureTime != value) { _departureTime = value; } } }
        private string _employeetobeVisited; public string EmployeetobeVisited { get { return _employeetobeVisited; } set { if (_employeetobeVisited != value) { _employeetobeVisited = value; } } }

        //HighlySecurityControlAreaLog
        private string _vistorsAndCompanyName; public string VistorsAndCompanyName { get { return _vistorsAndCompanyName; } set { if (_vistorsAndCompanyName != value) { _vistorsAndCompanyName = value; } } }
        private string _purposeoftheVisit; public string PurposeoftheVisit { get { return _purposeoftheVisit; } set { if (_purposeoftheVisit != value) { _purposeoftheVisit = value; } } }
        private string _hscVisitorsBadgeNo; public string hscVisitorsBadgeNo { get { return _hscVisitorsBadgeNo; } set { if (_hscVisitorsBadgeNo != value) { _hscVisitorsBadgeNo = value; } } }
        private string _hscDate; public string hscDate { get { return _hscDate; } set { if (_hscDate != value) { _hscDate = value; } } }
        private string _hscArrivalTime; public string hscArrivalTime { get { return _hscArrivalTime; } set { if (_hscArrivalTime != value) { _hscArrivalTime = value; } } }
        private string _hscDepartureTime; public string hscDepartureTime { get { return _hscDepartureTime; } set { if (_hscDepartureTime != value) { _hscDepartureTime = value; } } }
        //private string _hscName; public string hscName { get { return _hscName; } set { if (_hscName != value) { _hscName = value; } } }


        //ConsultantApplicationForm
        private string _caFirstName; public string caFirstName { get { return _caFirstName; } set { if (_caFirstName != value) { _caFirstName = value; } } }
        private string _caMiddleName; public string caMiddleName { get { return _caMiddleName; } set { if (_caMiddleName != value) { _caMiddleName = value; } } }
        private string _caLastName; public string caLastName { get { return _caLastName; } set { if (_caLastName != value) { _caLastName = value; } } }
        private string _address; public string Address { get { return _address; } set { if (_address != value) { _address = value; } } }
        private string _city; public string City { get { return _city; } set { if (_city != value) { _city = value; } } }
        private string _state; public string State { get { return _state; } set { if (_state != value) { _state = value; } } }
        private string _zip; public string Zip { get { return _zip; } set { if (_zip != value) { _zip = value; } } }
        private string _email; public string Email { get { return _email; } set { if (_email != value) { _email = value; } } }
        private string _cellPhone; public string CellPhone { get { return _cellPhone; } set { if (_cellPhone != value) { _cellPhone = value; } } }
        private string _homephone; public string Homephone { get { return _homephone; } set { if (_homephone != value) { _homephone = value; } } }
        private string _securityNo; public string SecurityNo { get { return _securityNo; } set { if (_securityNo != value) { _securityNo = value; } } }
        private bool _isYes; public bool IsYes { get { return _isYes; } set { if (_isYes != value) { _isYes = value; } } }
        private bool _isNo; public bool IsNo { get { return _isNo; } set { if (_isNo != value) { _isNo = value; } } }
        private string _companyName; public string CompanyName { get { return _companyName; } set { if (_companyName != value) { _companyName = value; } } }
        private string _idNo; public string IdNo { get { return _idNo; } set { if (_idNo != value) { _idNo = value; } } }
        private string _passportNo; public string PassportNo { get { return _passportNo; } set { if (_passportNo != value) { _passportNo = value; } } }
        private string _dateandPlaceofIssue; public string DateandPlaceofIssue { get { return _dateandPlaceofIssue; } set { if (_dateandPlaceofIssue != value) { _dateandPlaceofIssue = value; } } }
        private string _passportValidity; public string PassportValidity { get { return _passportValidity; } set { if (_passportValidity != value) { _passportValidity = value; } } }
        private string _caPurposeOfVisit; public string caPurposeOfVisit { get { return _caPurposeOfVisit; } set { if (_caPurposeOfVisit != value) { _caPurposeOfVisit = value; } } }
        private string _duration; public string Duration { get { return _duration; } set { if (_duration != value) { _duration = value; } } }
        private string _emergencyContactNo; public string EmergencyContactNo { get { return _emergencyContactNo; } set { if (_emergencyContactNo != value) { _emergencyContactNo = value; } } }
        #endregion
        private void LoadData()
        {
            try
            {
                string jsonFilePath = "D:\\VisitorData\\Data\\DataConfiguration.json"; // Provide the path to your JSON file
                string jsonData = File.ReadAllText(jsonFilePath);

                cmdData = JsonConvert.DeserializeObject<UIbindingModel>(jsonData);
                VisitorCompanyName = cmdData.VisitorCompanyName;
                VisitorVisitPurpose = cmdData.VisitorVisitPurpose;
                DepartmentNames = cmdData.DepartmentNames;

            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., file not found, JSON parsing error
            }
            string pdfUrl = "https://example.com/your-pdf-file.pdf";
            //pdfViewer.Navigate(new Uri(pdfUrl));
        }
        private List<string> _visitorCompanyName;
        public List<string> VisitorCompanyName
        {
            get { return _visitorCompanyName; }
            set
            {
                _visitorCompanyName = value;
                NotifyOfPropertyChange(() => VisitorCompanyName);
            }
        }

        private List<string> _visitorVisitPurpose;

        public List<string> VisitorVisitPurpose
        {
            get { return _visitorVisitPurpose; }
            set
            {
                _visitorVisitPurpose = value;
                NotifyOfPropertyChange(() => VisitorVisitPurpose);
            }
        }

        private List<string> _departmentNames;
        public List<string> DepartmentNames
        {
            get { return _departmentNames; }
            set
            {
                if (DepartmentNames != value)
                {
                    _departmentNames = value;
                    OnPropertyChanged(nameof(_departmentNames));
                    //filterEmployeeName(DepartmentNames[0]);
                }

            }
        }
        public List<string> _employeeToBeVisited;
        public List<string> EmpToBeVisited
        {
            get { return _employeeToBeVisited; }
            set
            {
                if (EmpToBeVisited != value)
                {
                    _employeeToBeVisited = value;
                    OnPropertyChanged(nameof(_employeeToBeVisited));
                }
            }
        }

        //public delegate void MentionFileGeneration(string subTotal);

        //public void GenerateTotal(MentionFileGeneration mentionSubtotal)
        //{
        //    mentionSubtotal("");
        //}

    }
}