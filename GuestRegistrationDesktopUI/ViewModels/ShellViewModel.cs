using Fi800ScanLibrary.Scanner;
using OCRLibrary;

namespace GuestRegistrationDesktopUI.ViewModels
{
    public class ShellViewModel
    {
        //private IScanDocument _scanDocument;
        private ScanDocument ScanDocument;
        //private IExtractTextFromImage _extractTextFromImage;
        public ShellViewModel(ScanDocument scanDocument, IExtractTextFromImage extractTextFromImage)
        {
            scanDocument = ScanDocument;
            
            //_scanDocument = scanDocument;
            //scanDocument.OpenScanner();
            //scanDocument.StartScan();

            //_extractTextFromImage = extractTextFromImage;
            //string imPath = string.Empty;
            //extractTextFromImage.ReadImageBasic("C:\\Users\\Ranji\\Downloads\\test\\test001.tif");
            //extractTextFromImage.ReadImageForArabic("C:\\Users\\Ranji\\Downloads\\test\\test001.tif");
        }


    }
}
