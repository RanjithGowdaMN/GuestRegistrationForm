using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesseract.Library
{
    public static class ImageThresholding
    {
        public static Bitmap ThresholdImage(Bitmap image, int threshold)
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
            return image;
        }

        public static Bitmap CreateNonIndexedImage(Bitmap src)
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
