using EOSDigital.API;
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

namespace GuestRegistrationDesktopUI.Library.CentralHub
{
    public class CentralHub : IFiScan, ICentralHub, IDisposable //, INotifyPropertyChanged
    {
        private FiScanHelper _fiScanHelper;
        private CanonSDKHelper _canonSDKHelper;

        private string ImageDir = "D:\\Images\\";
        private string PhotoDir = "D:\\Images\\Photos\\";
        private string fullImageFileName = string.Empty;

        private IOCRhelper _iOCRhelper;
        //private IIronOCR _ironOCR;
        private VisitorDataModel vistorData;
        private CameraStatus cameraStatus;

        public CentralHub(IOCRhelper iOCRhelper)//, IIronOCR ironOCR)
        {
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

        }

        ~CentralHub()
        {
            _fiScanHelper.FormScan_Closed();
            //_fiScanHelper.Dispose();
            _canonSDKHelper.CloseSession();
            //_canonSDKHelper.Dispose();
            //_canonSDKHelper.MainForm_FormClosing();
        }

        public VisitorDataModel StartScanning()
        {
            string fileCouter = FileHelper.GetImageFileName(ImageDir);
            _fiScanHelper.ScanModeSet(FileHelper.GetImageFileName(ImageDir));
            _fiScanHelper.StartScan();
            while (vistorData is null)
            {
                Thread.Sleep(100);
            }
            return vistorData;
        }

        public void OnScanCompleted(EventArgs e, string fileName)
        {
            //scannedData = _iOCRhelper.ExtractTextFromImage(fileName);
            ProcessTextData processText = new ProcessTextData();
            vistorData = processText.ProcessTextFromBlob(_iOCRhelper.ExtractTextFromImage(fileName));
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
