using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesseract.Library
{
    public static class PreprocessingImage
    {
        public static Bitmap PreprocessImage(Image image)
        {
            var grayscaleImage = ConvertToGrayScale.ConvertToGrayscale(image);

            // Apply additional noise reduction techniques
            var denoisedImage = ApplyDenoisingFilters.ApplyDenoisingFilter(grayscaleImage);

            // Apply binarization to convert to black and white
            var binarizedImage = ApplyBinarizations.ApplyBinarization(denoisedImage, 75);

            return binarizedImage;
        }
    }
}
