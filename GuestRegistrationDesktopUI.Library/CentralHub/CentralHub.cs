using GuestRegistrationDesktopUI.Library.FiScanner;
using GuestRegistrationDesktopUI.Library.Models;
using GuestRegistrationDesktopUI.Library.OCR;
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
    public class CentralHub : IFiScan
    {
        private FiScanHelper _fiScanHelper;
        private string ImageDir = "D:\\Images\\";
        private IOCRhelper _iOCRhelper;
        private IIronOCR _ironOCR;
        private VisitorDataModel vistorData;

        public CentralHub(IOCRhelper iOCRhelper, IIronOCR ironOCR)
        {
            _fiScanHelper = FiScanHelper.GetFormInstance;
            _fiScanHelper.ScanCompleted += OnScanCompleted;
            _fiScanHelper.FormScan_Load();
            _fiScanHelper.OpenScanner();
            _fiScanHelper.InitialFileRead();
            _fiScanHelper.cboFileType_SelectedIndexChanged();
            _iOCRhelper = iOCRhelper;
            _ironOCR = ironOCR;
        }

        ~CentralHub()
        {
            _fiScanHelper.FormScan_Closed();
            //_fiScanHelper.Dispose();
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
    }
}
