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

namespace GuestRegistrationDesktopUI.Library.CentralHub
{
    public class CentralHub : IFiScan, ICentralHub, IDisposable //, INotifyPropertyChanged
    {
        private FiScanHelper _fiScanHelper;
        private CanonSDKHelper _canonSDKHelper;

        private IGenerateWordDocument _generateWordDocument;
        private IGeneratePDFdocument _generatePDFdocument;

        private string ImageDir = "D:\\VisitorData\\ScannedID\\";
        private string PhotoDir = "D:\\VisitorData\\Photos\\";
        private string ProcessedImageDir = "D:\\VisitorData\\ProcessedImage\\";
        private string BaseDocumentPath = "D:\\VisitorData\\BaseDocument\\";
        private string GeneratedDocPath = "D:\\VisitorData\\GeneratedDocument\\";
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private string fullImageFileName = string.Empty;

        private IOCRhelper _iOCRhelper;
        //private IIronOCR _ironOCR;
        private VisitorDataModel vistorData;
        private CameraStatus cameraStatus;
        private ScannedFileModel scannedFileInfo;

        public int IdType;
        public bool IsBackSide;

        public CentralHub(IOCRhelper iOCRhelper, IGenerateWordDocument generateWordDocument, IGeneratePDFdocument generatePDFdocument)//, IIronOCR ironOCR)
        {
            _generateWordDocument = generateWordDocument;
            _generatePDFdocument = generatePDFdocument;

            //initialize Fi Scanner and Camera
            Parallel.Invoke(
                    () => _fiScanHelper = FiScanHelper.GetFormInstance,
                    ()=> _canonSDKHelper = CanonSDKHelper.GetFormInstance
                );
            
            //initialize Fi Scanner
            _fiScanHelper.ScanCompleted += OnScanCompleted;
            _fiScanHelper.FormScan_Load();
            _fiScanHelper.OpenScanner();
            _fiScanHelper.InitialFileRead();
            _fiScanHelper.cboFileType_SelectedIndexChanged();

            //Initialize OCR
            _iOCRhelper = iOCRhelper;
            //_ironOCR = ironOCR;

            _canonSDKHelper.InitializeLifetimeService();
            _canonSDKHelper.OpenSession();

            _canonSDKHelper.CanonImageToFiles += DownloadImageToFile;

            vistorData = new VisitorDataModel();
            cameraStatus = new CameraStatus();
            scannedFileInfo = new ScannedFileModel();

        }

        ~CentralHub()
        {
            _fiScanHelper.FormScan_Closed();
            //_fiScanHelper.Dispose();
            _canonSDKHelper.CloseSession();
            //_canonSDKHelper.Dispose();
            //_canonSDKHelper.MainForm_FormClosing();
        }

        public void GenerateDocument(VisitorDataModel visitorDataFromUI)
        {
            GuestDataModel guestDataModel = new GuestDataModel();
            guestDataModel.IDno = visitorDataFromUI.IDno;
            guestDataModel.Name = visitorDataFromUI.Name;
            guestDataModel.DateOfBirth = visitorDataFromUI.DateOfBirth;
            guestDataModel.Expiry = visitorDataFromUI.Expiry;
            guestDataModel.Nationality = visitorDataFromUI.Nationality;
            guestDataModel.IsPassport = visitorDataFromUI.IsPassport;
            //_generateWordDocument.GenerateWordDoc(guestDataModel, "", "", cameraStatus.ImagePath);
            _generatePDFdocument.GeneratePdfDoc(guestDataModel, "", "", cameraStatus.ImagePath, "visitor");
        }
        public void GenerateContractDocument(VisitorDataModel visitorDataFromUI)
        {
            GuestDataModel guestDataModel = new GuestDataModel();
            guestDataModel.IDno = visitorDataFromUI.IDno;
            guestDataModel.Name = visitorDataFromUI.Name;
            guestDataModel.DateOfBirth = visitorDataFromUI.DateOfBirth;
            guestDataModel.Expiry = visitorDataFromUI.Expiry;
            guestDataModel.Nationality = visitorDataFromUI.Nationality;
            guestDataModel.IsPassport = visitorDataFromUI.IsPassport;
            //_generateWordDocument.GenerateWordDoc(guestDataModel, "", "", cameraStatus.ImagePath);
            _generatePDFdocument.GeneratePdfDoc(guestDataModel, "", "", cameraStatus.ImagePath, "contract");

        }
        public (VisitorDataModel, string) StartScanning(int idType)
        {
            IdType = idType;
            string fileCouter = FileHelper.GetImageFileName(ImageDir);
            _fiScanHelper.ScanModeSet(fileCouter);
            _fiScanHelper.StartScan();
            scannedFileInfo.FrontSideFileName = fileCouter;
            while (vistorData is null)
            {
                Thread.Sleep(100);
            }
            return (vistorData, "");
        }

        public string ScanBackSide()
        {
            string fileCouter = FileHelper.GetImageFileName(ImageDir);
            _fiScanHelper.ScanModeSet(fileCouter);
            _fiScanHelper.StartScan();
            scannedFileInfo.BackSideFileName = fileCouter;
            scannedFileInfo.IsSecondSidePresent = true;
            
            //TBD return scannd File name
            return "";
        }

        public void OnScanCompleted(EventArgs e, string fileName)
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
                throw;
            }
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
            try
            {
                //Check for session access
                if (_canonSDKHelper.MainCamera?.SessionOpen == true)
                {
                    //_canonSDKHelper.OpenSession();
                    _canonSDKHelper.TakePhotoButton_Click(_canonSDKHelper.MainCamera, EventArgs.Empty);
                    cameraStatus.CameraSessionActive = true;
                    return cameraStatus;
                }
                else
                {
                    cameraStatus.CameraSessionActive = false;
                    cameraStatus.ErrorMessage = "Camera is in sleep mode or not connected!! \n photo not taken!";
                    return cameraStatus;

                }
            }
            catch (Exception)
            {
                logger.Error($"camera sleep mode!!");
                //throw;
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
