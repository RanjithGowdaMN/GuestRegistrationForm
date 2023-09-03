using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationDesktopUI.Library.ImageCrop
{
    public static class CropImages
    {
        public static void CropImage(string fileName, int fileType) {

            string tempImageName = "D:\\VisitorData\\ScannedID\\temp.jpg";

            int cropX = 2000;
            int cropY = 0; 
            int cropWidth = 10000; 
            int cropHeight = 10000;

            if (fileType == 2)
            {
                //passport
                cropX = (int)Passport.x;
                cropY = (int)Passport.y;
                cropWidth = (int)Passport.xWidth;
                cropHeight = (int)Passport.yHeight;
            }
            else if(fileType == 1)
            {
                // ID card
                cropX = (int)IdCard.x;
                cropY = (int)IdCard.y;
                cropWidth = (int)IdCard.xWidth;
                cropHeight = (int)IdCard.yHeight;
            }
            else
            {

            }
            using (Bitmap inputImage = new Bitmap(fileName))
            {
                Rectangle cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                using (Bitmap croppedImage = inputImage.Clone(cropRect, inputImage.PixelFormat))
                {
                    croppedImage.Save(tempImageName);
                }
            }
            File.Delete(fileName);
            File.Move(tempImageName, fileName);
        }



        public enum Passport
        {
            x = 1700,
            y = 0,
            xWidth = 6800,
            yHeight = 8800
        }

        public enum IdCard
        {
            x = 2500,
            y = 0,
            xWidth = 4800,
            yHeight = 2800
        }
    }
}
