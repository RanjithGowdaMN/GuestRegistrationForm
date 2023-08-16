using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract.Library;

namespace GuestRegistrationDesktopUI.Library.OCR
{
    public class OCRhelper : IOCRhelper
    {
        private ITesseractLib _tesseract;
        public OCRhelper(ITesseractLib tesseract)
        {
            _tesseract = tesseract;
        }

        public string ExtractText(string imagePath, int idType)
        {
            return _tesseract.ProcessImageAndExtractText(imagePath, idType);
            //return _tesseract.ExtractTextFromImage(imagePath);
        }
    }
}
