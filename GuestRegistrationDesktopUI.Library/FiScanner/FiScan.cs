using GuestRegistrationDesktopUI.Library.OCR;
using IronOCR.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
        public string scannedData = string.Empty;

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

        public string StartScanning()
        {
            _fiScanHelper.ScanModeSet(FileHelper.GetImageFileName(ImageDir));
            _fiScanHelper.StartScan();

            while(scannedData == string.Empty)
            {
                Thread.Sleep(100);

            }
            return scannedData;

        }



        public void OnScanCompleted(EventArgs e, string fileName)
        {
            scannedData = _iOCRhelper.ExtractTextFromImage(fileName);

            //var Result = _ironOCR.GetTextFromImage(fileName);
            //File.WriteAllText("D:\\Images\\Extracted.txt", result);
        }
    }
}
