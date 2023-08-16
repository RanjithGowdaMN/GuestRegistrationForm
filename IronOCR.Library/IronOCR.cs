using IronOcr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronOCR.Library
{
    public class TessereactIronOCR : IIronOCR
    {
        public string GetTextFromImage(string imagePath)
        {
            var Ocr = new IronTesseract(); // nothing to configure
            Ocr.Language = OcrLanguage.English;
            //Ocr.Configuration.TesseractVersion = TesseractVersion.Tesseract5;
            using (var Input = new OcrInput())
            {
                Input.AddImage(imagePath);
                
                var Result = Ocr.Read(Input);
                return Result.Text;
                //Console.WriteLine(Result.Text);
            }
        }
    }
}
