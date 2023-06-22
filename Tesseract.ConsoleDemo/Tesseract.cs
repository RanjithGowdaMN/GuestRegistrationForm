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

        public string ExtractTextFromImage(string imagePath)
        {
            string extractedText = string.Empty;

            imagePath = PythonHelper.ApplyImageThreshold(imagePath, 100).Trim();


            try
            {
                using (var OCRengine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(imagePath))
                    {

                        //img.BinarizeOtsuAdaptiveThreshold(50, 50, 70, 70, 0.75f);

                        Bitmap image = new Bitmap(imagePath);
                        using (var page = OCRengine.Process(image))
                        {
                            var text = page.GetText();
                            extractedText = text;

                            //PageIterator.PageIterators(page);

                            Console.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());

                            Console.WriteLine("Text (GetText): \r\n{0}", text);
                            
                            Console.WriteLine("Text (iterator):");
                            
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                Console.WriteLine("Unexpected Error: " + e.Message);
                Console.WriteLine("Details: ");
                Console.WriteLine(e.ToString());
            }
            Console.Write("Press any key to continue . . . ");
            //Console.ReadKey(true);
            return extractedText;
        }

        private Bitmap ThresholdImage(Bitmap image, int threshold)
        {
            image = CreateNonIndexedImage(image);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int grayValue = pixelColor.R; // Assuming the image is already grayscale
                    Color newColor = grayValue > threshold ? Color.White : Color.Black;


                    image.SetPixel(x, y, newColor);
                }

            }
            image.Save("D:\\Images\\Processed_image00123.jpg");
            return image;
        }

        public Bitmap CreateNonIndexedImage(Bitmap src)
        {
            Bitmap newBmp = new Bitmap(src.Width, src.Height, PixelFormat.Format32bppArgb);

            using (Graphics gfx = Graphics.FromImage(newBmp))
            {
                gfx.DrawImage(src, 0, 0);
            }

            return newBmp;
        }
    }
}