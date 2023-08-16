using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using AForge.Imaging.Filters;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
namespace Tesseract.Library
{
    public class TesseractLib : ITesseractLib
    {
        //public static void Main()
        //{
        //    TesseractLib tesseractLib = new TesseractLib();
        //    tesseractLib.ExtractTextFromImage("D:\\Images\\image00123.jpg");
        //}

        public string ProcessImageAndExtractText(string imagePath, int idType)
        {
            string extractedText = string.Empty;

            imagePath = PythonHelper.ApplyImageThreshold(imagePath, 105, idType).Trim();
            try
            {
                using (var OCRengine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(imagePath))
                    {
                        Bitmap image = new Bitmap(imagePath);
                        using (var page = OCRengine.Process(image))
                        {
                            var text = page.GetText();
                            extractedText = text;

                            //PageIterator.PageIterators(page);
                            //Console.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());
                            //Console.WriteLine("Text (GetText): \r\n{0}", text);
                            //Console.WriteLine("Text (iterator):");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                Debug.WriteLine("Unexpected Error: " + e.Message);
                Debug.WriteLine("Details: ");
                Debug.WriteLine(e.ToString());
            }
            //Debug.Write("Press any key to continue . . . ");
            return extractedText;
        }
    }
}