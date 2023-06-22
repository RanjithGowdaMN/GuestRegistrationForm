using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesseract.Library
{
    public static class ApplyBinarizations
    {
        public static Bitmap ApplyBinarization(Bitmap image, int threshold)
        {
            // Apply binarization techniques to convert the image to black and white.
            // You can experiment with different thresholding methods.

            // Example: Apply Simple Thresholding
            var binarizedImage = new Bitmap(image);

            Threshold filter = new Threshold(threshold);

            filter.ApplyInPlace(binarizedImage);

            return binarizedImage;
        }
    }
}
