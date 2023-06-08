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
       
        public FiScan()
        {
            _fiScanHelper = FiScanHelper.GetFormInstance;
            _fiScanHelper.ScanCompleted += FiScan.OnScanCompleted;
            _fiScanHelper.FormScan_Load();
            _fiScanHelper.OpenScanner();
            _fiScanHelper.InitialFileRead();
            _fiScanHelper.cboFileType_SelectedIndexChanged();
        }

        ~FiScan()
        {
            _fiScanHelper.FormScan_Closed();
            _fiScanHelper.Dispose();
        }

        public void StartScanning()
        {

            _fiScanHelper.StartScan();
        }

        public static void OnScanCompleted(object source, EventArgs e)
        {
            //var formScanInstance = FiScanHelper.GetSingleton;
            

        }

        public string GetImageFileName()
        {
            //string directoryPath = "C:\\path\\to\\directory";

            // Check if the directory exists, and create it if it doesn't
            if (!Directory.Exists(ImageDir))
            {
                Directory.CreateDirectory(ImageDir);
                return "Image_00001";
            }

            // Get all files in the directory
            string[] files = Directory.GetFiles(ImageDir);

            if (files.Length == 0)
            {
                Console.WriteLine("No files found in the directory.");
                return "Image_00001";
            }

            // Initialize variables to store the last modified file information
            string lastModifiedFileName = string.Empty;
            DateTime lastModifiedTime = DateTime.MinValue;

            // Iterate through each file and compare the modified time
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (fileInfo.LastWriteTime > lastModifiedTime)
                {
                    lastModifiedTime = fileInfo.LastWriteTime;
                    lastModifiedFileName = fileInfo.Name;
                }
            }
            return lastModifiedFileName;
        }
    }
}
