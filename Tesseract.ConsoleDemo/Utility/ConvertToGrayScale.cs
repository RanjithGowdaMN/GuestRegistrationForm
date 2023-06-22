using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesseract.Library
{
    public static class ConvertToGrayScale
    {
        public static Bitmap ConvertToGrayscale(Image image)
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
    }
}
