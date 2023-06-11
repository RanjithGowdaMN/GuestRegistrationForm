using GuestRegistrationDesktopUI.Library.OCR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.FiScanner
{
    public class FiScan : IFiScan
    {
        private FiScanHelper _fiScanHelper;
        private string ImageDir = "D:\\Images\\";
        private IOCRhelper _iOCRhelper;


        public FiScan(IOCRhelper iOCRhelper)
        {
            _fiScanHelper = FiScanHelper.GetFormInstance;
            _fiScanHelper.ScanCompleted += OnScanCompleted;
            _fiScanHelper.FormScan_Load();
            _fiScanHelper.OpenScanner();
            _fiScanHelper.InitialFileRead();
            _fiScanHelper.cboFileType_SelectedIndexChanged();
            _iOCRhelper = iOCRhelper;


        }

        ~FiScan()
        {
            _fiScanHelper.FormScan_Closed();
            //_fiScanHelper.Dispose();
        }

        public void StartScanning()
        {
            _fiScanHelper.ScanModeSet(FileHelper.GetImageFileName(ImageDir));
            _fiScanHelper.StartScan();

        }

        public void OnScanCompleted(object source, EventArgs e, string fileName)
        {
            var result = _iOCRhelper.ExtractTextFromImage(fileName);
        }
    }
}
