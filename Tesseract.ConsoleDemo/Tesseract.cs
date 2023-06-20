using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace Tesseract.Library
{
    public class TesseractLib : ITesseractLib
    {

        //public static void Main()
        //{
        //    TesseractLib tesseractLib = new TesseractLib();
        //    tesseractLib.ExtractTextFromImage("D:\\Images\\image00108_Processed.jpg");
        //}

        public string ExtractTextFromImage(string imagePath)
        {
            string extractedText = string.Empty;
            //var imagePath = "C:\\Users\\Ranji\\source\\repos\\tesseract-samples\\src\\Tesseract.ConsoleDemo\\image00001.jpg";

            try
            {
                using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(imagePath))
                    {
                        // Do not change this value
                        img.BinarizeOtsuAdaptiveThreshold(50, 75, 75, 75, 0.5f);
                        

                        //var processedImage = PreprocessImage(image);
                        //img.BinarizeOtsuAdaptiveThreshold(0, 0, 75, 75, 0.5f);
                        using (var page = engine.Process(img))
                        {
                            var text = page.GetText();
                            extractedText = text;
                            
                            Console.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());

                            Console.WriteLine("Text (GetText): \r\n{0}", text);
                            
                            Console.WriteLine("Text (iterator):");
                            //using (var iter = page.GetIterator())
                            //{
                            //    iter.Begin();

                            //    do
                            //    {
                            //        do
                            //        {
                            //            do
                            //            {
                            //                do
                            //                {
                            //                    if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
                            //                    {
                            //                        Console.WriteLine("<BLOCK>");
                            //                    }

                            //                    Console.Write(iter.GetText(PageIteratorLevel.Word));
                            //                    Console.Write(" ");

                            //                    if (iter.IsAtFinalOf(PageIteratorLevel.TextLine, PageIteratorLevel.Word))
                            //                    {
                            //                        Console.WriteLine();
                            //                    }
                            //                } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));

                            //                if (iter.IsAtFinalOf(PageIteratorLevel.Para, PageIteratorLevel.TextLine))
                            //                {
                            //                    Console.WriteLine();
                            //                }
                            //            } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                            //        } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                            //    } while (iter.Next(PageIteratorLevel.Block));
                            //}
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

        private Bitmap PreprocessImage(Image image)
        {
            // Convert the image to grayscale
            var grayscaleImage = ConvertToGrayscale(image);

            // Apply additional noise reduction techniques
            var denoisedImage = ApplyDenoisingFilters(grayscaleImage);

            // Apply binarization to convert to black and white
            var binarizedImage = ApplyBinarization(denoisedImage);

            return binarizedImage;
        }

        private Bitmap ConvertToGrayscale(Image image)
        {
            var grayscaleImage = new Bitmap(image.Width, image.Height);

            using (var g = Graphics.FromImage(grayscaleImage))
            {
                var grayscaleMatrix = new ColorMatrix(new float[][]
                {
                new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
                });

                var attributes = new ImageAttributes();
                attributes.SetColorMatrix(grayscaleMatrix);

                g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }

            return grayscaleImage;
        }

        private Bitmap ApplyDenoisingFilters(Bitmap image)
        {
            // Apply denoising filters such as Gaussian blur, median filter, etc.
            // You can use libraries like AForge.NET or OpenCvSharp for these operations.

            // Example: Apply Gaussian blur
            var denoisedImage = new Bitmap(image);
            AForge.Imaging.Filters.GaussianBlur filter = new AForge.Imaging.Filters.GaussianBlur();
            filter.ApplyInPlace(denoisedImage);

            return denoisedImage;
        }

        private Bitmap ApplyBinarization(Bitmap image)
        {
            // Apply binarization techniques to convert the image to black and white.
            // You can experiment with different thresholding methods.

            // Example: Apply Simple Thresholding
            var binarizedImage = new Bitmap(image);
            AForge.Imaging.Filters.Threshold filter = new AForge.Imaging.Filters.Threshold(128);
            filter.ApplyInPlace(binarizedImage);

            return binarizedImage;
        }
    }
}