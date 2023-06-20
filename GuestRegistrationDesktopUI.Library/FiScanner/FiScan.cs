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

namespace GuestRegistrationDesktopUI.Library.FiScanner
{
    public class FiScan : IFiScan
    {
        private FiScanHelper _fiScanHelper;
        private string ImageDir = "D:\\Images\\";
        private IOCRhelper _iOCRhelper;
        private IIronOCR _ironOCR;
        private VisitorDataModel vistorData;

        public FiScan(IOCRhelper iOCRhelper, IIronOCR ironOCR)
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

        ~FiScan()
        {
            _fiScanHelper.FormScan_Closed();
            //_fiScanHelper.Dispose();
        }

        public VisitorDataModel StartScanning()
        {
            
            _fiScanHelper.ScanModeSet(FileHelper.GetImageFileName(ImageDir));
            _fiScanHelper.StartScan();

            while(vistorData is null)
            {
                Thread.Sleep(100);

            }
            return vistorData;

        }



        public void OnScanCompleted(EventArgs e, string fileName)
        {
            //ProcessImageAgain:
            vistorData = new VisitorDataModel();
            //scannedData = _iOCRhelper.ExtractTextFromImage(fileName);
            ProcessTextData processText = new ProcessTextData();
            
            vistorData = processText.ProcessTextFromBlob(_iOCRhelper.ExtractTextFromImage(fileName));

            //check for null values in fields
            //foreach (PropertyInfo pi in vistorData.GetType().GetProperties())
            //{
            //    if (pi.PropertyType == typeof(string))
            //    {
            //        string value = (string)pi.GetValue(vistorData);
            //        if (string.IsNullOrEmpty(value))
            //        {
            //            goto ProcessImageAgain;
            //        }
            //    }
            //}
            
            
            
            //var Result = _ironOCR.GetTextFromImage(fileName);
            //File.WriteAllText("D:\\Images\\Extracted.txt", result);
        }
    }
}
