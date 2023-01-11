using Fi800ScanLibrary.Scanner;
using OCRLibrary;

namespace GuestRegistrationDesktopUI.ViewModels
{
    public class ShellViewModel
    {
        private IScanDocument _scanDocument;
        private IExtractTextFromImage _extractTextFromImage;
        public ShellViewModel(IScanDocument scanDocument, IExtractTextFromImage extractTextFromImage)
        {
            _scanDocument = scanDocument;
            scanDocument.OpenScanner();
            scanDocument.StartScan();

            _extractTextFromImage = extractTextFromImage;
            extractTextFromImage.ReadImageBasic("");
        }


    }
}
