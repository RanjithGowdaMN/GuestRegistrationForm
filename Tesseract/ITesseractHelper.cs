using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesseractOCR.Library
{
    public interface ITesseractHelper
    {
        string ExtractTxtFromImg(string imagePath, int id_Type, int RFU1, int RFU2, int RFU3, string RFU4, string RFU5, string RFU6);
    }
}
