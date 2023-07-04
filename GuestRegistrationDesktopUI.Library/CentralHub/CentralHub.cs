
using GuestRegistrationDesktopUI.Library.FiScanner;
using GuestRegistrationDesktopUI.Library.Models;
using GuestRegistrationDesktopUI.Library.OCR;
using GuestRegistrationDesktopUI.Library.PhotoHandler;
using GuestRegistrationDesktopUI.Library.TextProcessing;
using IronOCR.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.CentralHub
{
    public class CentralHub : IFiScan, ICanonSDKHelper
    {
        private FiScanHelper _fiScanHelper;
        private CanonSDKHelper _canonSDKHelper;

        private string ImageDir = "D:\\Images\\";
        private IOCRhelper _iOCRhelper;
        private IIronOCR _ironOCR;
        private VisitorDataModel vistorData;

        //private ICameraOperations _cameraOperations;

        public CentralHub(IOCRhelper iOCRhelper, IIronOCR ironOCR)//, ICameraOperations cameraOperations)
        {
            //initialize Fi Scanner
            _fiScanHelper = FiScanHelper.GetFormInstance;
            _fiScanHelper.ScanCompleted += OnScanCompleted;
            _fiScanHelper.FormScan_Load();
            _fiScanHelper.OpenScanner();
            _fiScanHelper.InitialFileRead();
            _fiScanHelper.cboFileType_SelectedIndexChanged();

            //Initialize OCR
            _iOCRhelper = iOCRhelper;
            _ironOCR = ironOCR;

            //initialize Camera
            _canonSDKHelper = CanonSDKHelper.GetFormInstance;
            //_canonSDKHelper = new CanonSDKHelper();
            



            //_canonSDKHelper.Load();
            //_cameraOperations = cameraOperations;

            //_cameraOperations.TakePhoto();
        }

        ~CentralHub()
        {
            _fiScanHelper.FormScan_Closed();
            //_fiScanHelper.Dispose();

            _canonSDKHelper.CloseSession();
            _canonSDKHelper.Dispose();
        }

        public VisitorDataModel StartScanning()
        {
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
            vistorData = new VisitorDataModel();
            //scannedData = _iOCRhelper.ExtractTextFromImage(fileName);
            ProcessTextData processText = new ProcessTextData();
            vistorData = processText.ProcessTextFromBlob(_iOCRhelper.ExtractTextFromImage(fileName));
            TakePhoto();
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

        public void TakePhoto()
        {
            //throw new NotImplementedException();
            //_canonSDKHelper.TakePhoto();

            _canonSDKHelper.OpenSession();

            _canonSDKHelper.TakePhotoButton_Click(_canonSDKHelper, EventArgs.Empty);

            _canonSDKHelper.CloseSession();
        }
    }
}
