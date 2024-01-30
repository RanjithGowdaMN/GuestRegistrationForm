using EOSDigital.API;
using GenerateDocument.Library;
using GuestRegistrationDesktopUI.Library.FiScanner;
using GuestRegistrationDesktopUI.Library.Models;
using GuestRegistrationDesktopUI.Library.OCR;
using GuestRegistrationDesktopUI.Library.PhotoHandler;
using GuestRegistrationDesktopUI.Library.TextProcessing;
using IronOCR.Library;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using NLog;
using GuestRegistrationDesktopUI.Library.ImageCrop;
using System.Collections.Generic;
using EOSDigital.SDK;
using fiScanTest;

namespace GuestRegistrationDesktopUI.Library.CentralHub
{
    public class CentralHub : IFiScan, ICentralHub, IDisposable //, INotifyPropertyChanged
    {
        public FiScanHelper _fiScanHelper;
        public CanonSDKHelper _canonSDKHelper;
        public CanonAPI APIHandler;
        List<Camera> CamList;

        private IGenerateWordDocument _generateWordDocument;
        private IGeneratePDFdocument _generatePDFdocument;
        private IGenerateCardPrintDoc _generateCardPrintDoc;

        private string ImageDir = "D:\\VisitorData\\ScannedID\\";
        private string PhotoDir = "D:\\VisitorData\\Photos\\";
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public string GeneratedDocument = string.Empty;

        private IOCRhelper _iOCRhelper;
        //private IIronOCR _ironOCR;
        private VisitorDataModel vistorData;
        private CameraStatus cameraStatus;
        private ScannedFileModel scannedFileInfo;

        public int IdType;
        public bool IsBackSide;
        public string gScannedFileName = string.Empty;

        public string generatedVisitorIDNumber = string.Empty;
        public string fullImageFileName = string.Empty;
        public string IDcardFileName = string.Empty;

        public CentralHub(IOCRhelper iOCRhelper, IGenerateWordDocument generateWordDocument, 
            IGeneratePDFdocument generatePDFdocument, IGenerateCardPrintDoc generateCardPrintDoc)//, IIronOCR ironOCR)
        {
            _generateWordDocument = generateWordDocument;
            _generatePDFdocument = generatePDFdocument;
            _generateCardPrintDoc = generateCardPrintDoc;
            //initialize Fi Scanner and Camera
            Parallel.Invoke(
                    () => _fiScanHelper = FiScanHelper.GetFormInstance,
                    ()=> _canonSDKHelper = CanonSDKHelper.GetFormInstance
                );

            //initialize Fi Scanner
            _fiScanHelper.AutoSize = false;
            _fiScanHelper.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            
            _fiScanHelper.ScanCompleted += OnScanCompleted;
            _fiScanHelper.FormScan_Load();
            var test = _fiScanHelper.OpenScanner();
            _fiScanHelper.InitialFileRead();
            _fiScanHelper.cboFileType_SelectedIndexChanged();

            //Initialize OCR
            _iOCRhelper = iOCRhelper;
            //_ironOCR = ironOCR;

            _canonSDKHelper.InitializeLifetimeService();
            _canonSDKHelper.OpenSession();

            _canonSDKHelper.CanonImageToFiles += DownloadImageToFile;

            vistorData = VisitorDataModel.Instance;
            cameraStatus = CameraStatus.Instance;
            scannedFileInfo = ScannedFileModel.Instance;

            APIHandler = new CanonAPI();
            //APIHandler.CameraAdded += APIHandler_CameraAdded;

        }

        public void AddCameraToMainThread()
        {
            CamList = APIHandler.GetCameraList();
            _canonSDKHelper.MainCamera = CamList[0];
            //_canonSDKHelper.MainCamera.StateChanged += CamStateChanged;
        }

        private void CamStateChanged(Camera sender, StateEventID eventID, int parameter)
        {
            //throw new NotImplementedException();
        }
        public bool ScannerHeartbeat()
        {
            
            if (_fiScanHelper.OpenScanner())
            {
                return true;
            }
            else {
                return false;
            }
        }

        ~CentralHub()
        {
            _fiScanHelper.FormScan_Closed();
            //_fiScanHelper.Dispose();
            _canonSDKHelper.CloseSession();
            //_canonSDKHelper.Dispose();
            //_canonSDKHelper.MainForm_FormClosing();
        }

        public string GenerateVisitorIDnumber()
        {
            if (String.IsNullOrEmpty(fullImageFileName))
            {
                if (String.IsNullOrEmpty(generatedVisitorIDNumber) )
                {
                    generatedVisitorIDNumber = (Convert.ToInt32(FileHelper.GetImageFileName(PhotoDir).PadLeft(5, '0')) + 00).ToString().PadLeft(5, '0');
                    return generatedVisitorIDNumber;
                }

                generatedVisitorIDNumber = FileHelper.GetImageFileName(PhotoDir).PadLeft(5, '0').PadLeft(5, '0');

              fullImageFileName = Path.Combine("D:\\VisitorData\\Photos\\", "photo" + generatedVisitorIDNumber + ".jpg");
              File.Copy("D:\\VisitorData\\Photos\\photo00001.jpg", fullImageFileName, true);

                ////TBD
                //try
                //{
                //    File.Copy("D:\\VisitorData\\Photos\\photo00001.jpg", fullImageFileName);

                //}

                //catch (Exception)
                //{
                //    generatedVisitorIDNumber = (Convert.ToInt32(FileHelper.GetImageFileName(PhotoDir).PadLeft(5, '0')) + 01).ToString().PadLeft(5, '0');
                //    fullImageFileName = Path.Combine("D:\\VisitorData\\Photos\\", "photo" + generatedVisitorIDNumber + ".jpg");
                //    File.Copy("D:\\VisitorData\\Photos\\photo00001.jpg", fullImageFileName, true);

                //}
            }
            else
            {
                generatedVisitorIDNumber = fullImageFileName.Replace("D:\\VisitorData\\Photos\\photo", "").Replace(".jpg", "");
            }
            return generatedVisitorIDNumber;
        }
       

        public string PrintIdCard(string visitorName, string visitorType,string imagePath)
        {
            string outputPath =Path.Combine("D:\\VisitorData\\IdCard", visitorName+".pdf");
            string sppLogo = "D:\\VisitorData\\Logo\\SPP.png";
            string visitorNumber = FileHelper.GetImageFileName(PhotoDir).PadLeft(5, '0');
            // GenerateVisitorIDnumber();
         
            IDcardFileName = _generateCardPrintDoc.printCard(outputPath, sppLogo, cameraStatus.ImagePath, visitorName, generatedVisitorIDNumber, visitorType);
            //vistorData = VisitorDataModel.Instance;
          //  cameraStatus = CameraStatus.Instance;
            //scannedFileInfo = ScannedFileModel.Instance;
            //fullImageFileName = string.Empty;
            //generatedVisitorIDNumber = string.Empty;

            
            return IDcardFileName;
        }

        public string GenerateDocument(VisitorDataModel visitorDataFromUI, ConcatenatedDataBinding concatenatedDataBinding)
        {
            //GenerateVisitorIDnumber();
            return sendDataForDocGeneration("visitor", visitorDataFromUI, concatenatedDataBinding);

            //_generateWordDocument.GenerateWordDoc(guestDataModel, "", "", cameraStatus.ImagePath);
            //_generatePDFdocument.GeneratePdfDoc(guestDataModel, "", "", cameraStatus.ImagePath, "visitor");
        }
        public string GenerateContractDocument(VisitorDataModel visitorDataFromUI, ConcatenatedDataBinding concatenatedDataBinding)
        {
            //GenerateVisitorIDnumber();
            return sendDataForDocGeneration("contractor", visitorDataFromUI, concatenatedDataBinding);
            //_generateWordDocument.GenerateWordDoc(guestDataModel, "", "", cameraStatus.ImagePath);
            //_generatePDFdocument.GeneratePdfDoc(guestDataModel, "", "", cameraStatus.ImagePath, "contract");
        }

        public string sendDataForDocGeneration(string visitorType, VisitorDataModel visitorDataFromUI, ConcatenatedDataBinding concatenatedDataBinding) {

            GuestDataModel guestDataModel = new GuestDataModel();
            guestDataModel.IDno = visitorDataFromUI.IDno;
            guestDataModel.Name = visitorDataFromUI.Name;
            guestDataModel.DateOfBirth = visitorDataFromUI.DateOfBirth;
            guestDataModel.Expiry = visitorDataFromUI.Expiry;
            guestDataModel.Nationality = visitorDataFromUI.Nationality;
            guestDataModel.IsPassport = visitorDataFromUI.IsPassport;

            gScannedFileModel gscannedFileModel = new gScannedFileModel();

            if (visitorDataFromUI.isDataFromDb[0])
            {
                if (visitorDataFromUI.isDataFromDb[1])
                {
                    gscannedFileModel.FrontSideFileName = gCONSTANTS.TEMPIDFRONTFILEPATH;
                }
                if (visitorDataFromUI.isDataFromDb[2])
                {
                    gscannedFileModel.BackSideFileName = gCONSTANTS.TEMPIDBACKSIDEFILEPATH;
                }
                if (visitorDataFromUI.isDataFromDb[3])
                {
                    cameraStatus.ImagePath = gCONSTANTS.TEMPPHOTOFILEPATH;
                }
            } else
            {
                gscannedFileModel.BackSideFileName = scannedFileInfo.BackSideFileName;
                gscannedFileModel.FrontSideFileName = scannedFileInfo.FrontSideFileName;
                gscannedFileModel.IsSecondSide = scannedFileInfo.IsSecondSide;
            }

            

            gConcatenatedDataBinding guestDataBinding = new gConcatenatedDataBinding();
            guestDataBinding.visitorDataSheet.AreaVisited = concatenatedDataBinding.visitorDataSheet.AreaVisited;
            guestDataBinding.visitorDataSheet.Company = concatenatedDataBinding.visitorDataSheet.CompanyName;
            guestDataBinding.visitorDataSheet.Date = concatenatedDataBinding.visitorDataSheet.Date;
            guestDataBinding.visitorDataSheet.DepartmentManager = concatenatedDataBinding.visitorDataSheet.DepartmentManager;
            guestDataBinding.visitorDataSheet.PersontobeVisited = concatenatedDataBinding.visitorDataSheet.PersonToBeVisited;
            guestDataBinding.visitorDataSheet.ProductionManager = concatenatedDataBinding.visitorDataSheet.ProductionManager;
            guestDataBinding.visitorDataSheet.ReasonForVisit = concatenatedDataBinding.visitorDataSheet.PurposeOfVisit;
            guestDataBinding.visitorDataSheet.SecurityController = concatenatedDataBinding.visitorDataSheet.SecurityController;
            guestDataBinding.visitorDataSheet.VisitDateFrom = concatenatedDataBinding.visitorDataSheet.VisitDateFrom;
            guestDataBinding.visitorDataSheet.VisitDuration = concatenatedDataBinding.visitorDataSheet.VisitDuration;
            guestDataBinding.visitorDataSheet.Title = concatenatedDataBinding.visitorDataSheet.Title;

            if (String.IsNullOrEmpty(concatenatedDataBinding.visitorDataSheet.VisitorIdNo))
            {
                concatenatedDataBinding.visitorDataSheet.VisitorIdNo = generatedVisitorIDNumber;
            }

            guestDataBinding.visitorDataSheet.VisitorIdNo = concatenatedDataBinding.visitorDataSheet.VisitorIdNo;
            guestDataBinding.visitorDataSheet.VisitorName = concatenatedDataBinding.visitorDataSheet.VisitorName;

            guestDataBinding.CAforVisitor.Company = concatenatedDataBinding.CAforVisitor.Company;
            guestDataBinding.CAforVisitor.Date = concatenatedDataBinding.CAforVisitor.Date;
            guestDataBinding.CAforVisitor.Name = concatenatedDataBinding.CAforVisitor.Name;
            guestDataBinding.CAforVisitor.Title = concatenatedDataBinding.CAforVisitor.Title;

            guestDataBinding.vlBook.ArrivalTime = concatenatedDataBinding.vlBook.ArrivalTime;
            guestDataBinding.vlBook.Date = concatenatedDataBinding.vlBook.Date;
            guestDataBinding.vlBook.DepartureTime = concatenatedDataBinding.vlBook.DepartureTime;
            guestDataBinding.vlBook.EmployeetobeVisited = concatenatedDataBinding.vlBook.EmployeetobeVisited;
            guestDataBinding.vlBook.IdDateOfIssue = concatenatedDataBinding.vlBook.IdDateOfIssue;
            guestDataBinding.vlBook.PlaceOfIssue = concatenatedDataBinding.vlBook.PlaceOfIssue;
            guestDataBinding.vlBook.PurposeOfVisit = concatenatedDataBinding.vlBook.PurposeOfVisit;
            guestDataBinding.vlBook.VisitorAndCompanyName = concatenatedDataBinding.vlBook.VisitorAndCompanyName;
            guestDataBinding.vlBook.VisitorsBadgeNo = concatenatedDataBinding.vlBook.VisitorsBadgeNo;

            guestDataBinding.hsaLog.ArrivalTime = concatenatedDataBinding.hsaLog.ArrivalTime;
            guestDataBinding.hsaLog.Date = concatenatedDataBinding.hsaLog.Date;
            guestDataBinding.hsaLog.DepartureTime = concatenatedDataBinding.hsaLog.DepartureTime;
            guestDataBinding.hsaLog.PurposeoftheVisit = concatenatedDataBinding.hsaLog.PurposeoftheVisit;
            guestDataBinding.hsaLog.VisitorsBadgeNo = concatenatedDataBinding.hsaLog.VisitorsBadgeNo;
            guestDataBinding.hsaLog.VistorsAndCompanyName = concatenatedDataBinding.hsaLog.VistorsAndCompanyName;

           guestDataBinding.consultantApplicationForm.Address = concatenatedDataBinding.consultantApplicationForm.Address;
            guestDataBinding.consultantApplicationForm.CellPhone = concatenatedDataBinding.consultantApplicationForm.CellPhone;
            guestDataBinding.consultantApplicationForm.City = concatenatedDataBinding.consultantApplicationForm.City;
            guestDataBinding.consultantApplicationForm.CompanyName = concatenatedDataBinding.consultantApplicationForm.CompanyName;
            guestDataBinding.consultantApplicationForm.DateandPlaceofIssue = concatenatedDataBinding.consultantApplicationForm.DateOfIssue;
            guestDataBinding.consultantApplicationForm.DateandPlaceofIssue = concatenatedDataBinding.consultantApplicationForm.PlaceofIssue;
            guestDataBinding.consultantApplicationForm.Title = concatenatedDataBinding.consultantApplicationForm.Title;
            guestDataBinding.consultantApplicationForm.PassportIssuedOn = concatenatedDataBinding.consultantApplicationForm.PassportDateofIssue;
            guestDataBinding.consultantApplicationForm.Duration = concatenatedDataBinding.consultantApplicationForm.Duration;
           // guestDataBinding.consultantApplicationForm.Duration = concatenatedDataBinding.consultantApplicationForm.Durationto;
            guestDataBinding.consultantApplicationForm.Email = concatenatedDataBinding.consultantApplicationForm.Email;
            guestDataBinding.consultantApplicationForm.EmergencyContactNo = concatenatedDataBinding.consultantApplicationForm.EmergencyContactNo;
            guestDataBinding.consultantApplicationForm.PResidence = concatenatedDataBinding.consultantApplicationForm.Previous7YrResidency;
            guestDataBinding.consultantApplicationForm.Alias = concatenatedDataBinding.consultantApplicationForm.Alias;

            guestDataBinding.consultantApplicationForm.FirstName = concatenatedDataBinding.consultantApplicationForm.FirstName;
            guestDataBinding.consultantApplicationForm.Homephone = concatenatedDataBinding.consultantApplicationForm.HomePhoneNo;
            guestDataBinding.consultantApplicationForm.Zip = concatenatedDataBinding.consultantApplicationForm.Zip;
            guestDataBinding.consultantApplicationForm.IdNo = concatenatedDataBinding.consultantApplicationForm.IdNo;
            guestDataBinding.consultantApplicationForm.IsNo = concatenatedDataBinding.consultantApplicationForm.IsNo;
            guestDataBinding.consultantApplicationForm.IsYes = concatenatedDataBinding.consultantApplicationForm.IsYes;
            guestDataBinding.consultantApplicationForm.ConvictedFelony = concatenatedDataBinding.consultantApplicationForm.ConvictedFelony;
            guestDataBinding.consultantApplicationForm.LastName = concatenatedDataBinding.consultantApplicationForm.LastName;
            guestDataBinding.consultantApplicationForm.MiddleName = concatenatedDataBinding.consultantApplicationForm.MiddleName;
            guestDataBinding.consultantApplicationForm.PassportNo = concatenatedDataBinding.consultantApplicationForm.PassportNumber;
            guestDataBinding.consultantApplicationForm.PassportValidity = concatenatedDataBinding.consultantApplicationForm.PassportValidity;
            guestDataBinding.consultantApplicationForm.PurposeOfVisit = concatenatedDataBinding.consultantApplicationForm.PurposeOfVisit;
            guestDataBinding.consultantApplicationForm.SecurityNo = concatenatedDataBinding.consultantApplicationForm.SocialSecurityNumber;
            guestDataBinding.consultantApplicationForm.State = concatenatedDataBinding.consultantApplicationForm.State;

            return _generatePDFdocument.GeneratePdfDoc(guestDataModel, gscannedFileModel, guestDataBinding, "", "", cameraStatus.ImagePath, visitorType);
        }
        public (VisitorDataModel, string) StartScanning(int idType)
        {
            IdType = idType;
            string fileCouter = FileHelper.GetImageFileName(ImageDir);
            _fiScanHelper.ScanModeSet(fileCouter);
            _fiScanHelper.StartScan();
            scannedFileInfo.FrontSideFileName = fileCouter;
            scannedFileInfo.IsSecondSide = false;
            while (vistorData is null)
            {
                Thread.Sleep(100);
            }
            scannedFileInfo.FrontSideFileName = gScannedFileName;
            return (vistorData, gScannedFileName);
        }

        public string ScanBackSide(int idType)
        {
            IdType = idType;
            string fileCouter = FileHelper.GetImageFileName(ImageDir);
            _fiScanHelper.ScanModeSet(fileCouter);
            scannedFileInfo.BackSideFileName = fileCouter;
            scannedFileInfo.IsSecondSide = true;
            _fiScanHelper.StartScan();

            scannedFileInfo.BackSideFileName = gScannedFileName;
            return gScannedFileName;
        }

        public void OnScanCompleted(EventArgs e, string fileName)
        {
            if (!scannedFileInfo.IsSecondSide)
            {
                try
                {
                    //scannedData = _iOCRhelper.ExtractTextFromImage(fileName);
                     ProcessTextData processText = new ProcessTextData();
                    vistorData = processText.ProcessTextFromBlob(_iOCRhelper.ExtractText(fileName, IdType));
                }
                catch (Exception ex)
                {
                    logger.Error($"Error OnScanCompleted {ex.Message}");
                    logger.Error($"Error OnScanCompleted {ex.InnerException}");
                    logger.Error($"Error OnScanCompleted {ex.StackTrace}");
                }
            }
            gScannedFileName = fileName;
            CropImages.CropImage(fileName, IdType);
        }

        public bool CheckNullForFields(object obj)
        {
            foreach (PropertyInfo pi in obj.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(vistorData);
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void DownloadImageToFile(DownloadInfo info)
        {
            string filename = "photo" + FileHelper.GetImageFileName(PhotoDir).PadLeft(5, '0') + ".jpg";
            fullImageFileName = Path.Combine(PhotoDir, filename);
            _canonSDKHelper.MainCamera.DownloadToFile(info, fullImageFileName);
            File.SetAttributes(fullImageFileName, FileAttributes.ReadOnly);

           
            OnPhotoDownloadCompleted(fullImageFileName);
            cameraStatus.ImagePath = fullImageFileName;
        }
             
 
        public delegate void OnPhotoDownloadCompletedEventHandler(string path);

        public event OnPhotoDownloadCompletedEventHandler CanonImageDownload;

        public void OnPhotoDownloadCompleted(string path)
        {
            //fileInfo.FileName = ScannedFileName;
            if (CanonImageDownload != null)
            {
                //ScannedFileName
                CanonImageDownload(path);
            }
        }
        public CameraStatus TakePhoto()
        {
            //if (_canonSDKHelper.MainCamera?.SessionOpen == true) _canonSDKHelper.CloseSession();
            //else _canonSDKHelper.OpenSession();

            try
            {
                //_canonSDKHelper.OpenSession();
                _canonSDKHelper.RefreshCamera();
                try
                {
                    _canonSDKHelper.OpenSession();
                }
                catch (Exception ex)
                {
                    cameraStatus.ErrorMessage = "Camera session not open!"; ;
                }
                //Check for session access
                if (_canonSDKHelper.MainCamera?.SessionOpen == true)
                {
                    
                    _canonSDKHelper.TakePhotoButton_Click(_canonSDKHelper.MainCamera, EventArgs.Empty);
                    cameraStatus.CameraSessionActive = true;
                    return cameraStatus;
                }
                else
                {
                    cameraStatus.CameraSessionActive = false;
                    cameraStatus.ErrorMessage = "Camera is off or not connected!! \n photo not taken!";
                    return cameraStatus;
                }
            }
            catch (Exception)
            {
                logger.Error($"camera sleep mode!!");
            }
            return cameraStatus;
        }

        public void Dispose()
        {
            _fiScanHelper.FormScan_Closed();
            //_fiScanHelper.Dispose();

            _canonSDKHelper.CloseSession();
            _canonSDKHelper.Dispose();
        }

        public void CloseAllSession()
        {
            _fiScanHelper.FormScan_Closed();
            //_fiScanHelper.Dispose();

            _canonSDKHelper.CloseSession();
            _canonSDKHelper.Dispose();
        }

    }
}
