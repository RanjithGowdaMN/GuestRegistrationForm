using IronOcr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRLibrary
{
    public class ExtractTextFromImage : IExtractTextFromImage
    {
        public ExtractTextFromImage()
        {

        }

        public bool ReadImageBasic(string path)
        {
            AutoOcr Ocr = new AutoOcr() { ReadBarCodes = false };
            var Results = Ocr.Read(path);
            return true;
        }

        public bool ReadImageHighQualityScan(string path)
        {
            var Ocr = new AdvancedOcr()
            {
                CleanBackgroundNoise = false,
                EnhanceContrast = true,
                EnhanceResolution = false,
                Language = IronOcr.Languages.English.OcrLanguagePack,
                Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                ColorSpace = AdvancedOcr.OcrColorSpace.Color,
                DetectWhiteTextOnDarkBackgrounds = false,
                InputImageType = AdvancedOcr.InputTypes.Document,
                RotateAndStraighten = false,
                ReadBarCodes = false,
                ColorDepth = 4
            };

            var Results = Ocr.Read(path);
            return true;
        }

        public bool ReadImageLowQualityScan(string path)
        {
            var Ocr = new AdvancedOcr()
            {
                CleanBackgroundNoise = true,
                EnhanceContrast = true,
                EnhanceResolution = true,
                Language = IronOcr.Languages.English.OcrLanguagePack,
                Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
                DetectWhiteTextOnDarkBackgrounds = false,
                InputImageType = AdvancedOcr.InputTypes.Document,
                RotateAndStraighten = true,
                ReadBarCodes = false,
                ColorDepth = 4
            };

            var Results = Ocr.Read(path);
            return true;
        }

        public bool ReadImageForArabic(string path)
        {
            var Ocr = new AutoOcr()
            {
                Language = IronOcr.Languages.Arabic.OcrLanguagePack
            };
            return true;
        }

        public bool SaveToText(string path, string text)
        {
            File.WriteAllText(path, text);
            return true;
        }

    }
}
