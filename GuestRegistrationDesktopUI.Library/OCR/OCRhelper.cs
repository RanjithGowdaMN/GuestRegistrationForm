using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesseractOCR.Library;

namespace GuestRegistrationDesktopUI.Library.OCR
{
    public class OCRhelper : IOCRhelper
    {
        private ITesseractHelper _tesseract;
        public OCRhelper(ITesseractHelper tesseract)
        {
            _tesseract = tesseract;
        }

        public string ExtractText(string imagePath, int IdType)
        {
            return _tesseract.ExtractTxtFromImg(imagePath, IdType, 0,0,0,"","", "");

        }

    }
}
