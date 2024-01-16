using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using GenerateDocument.Library;
using GuestDataManager.Library.DataAccess;
using GuestRegistrationDesktopUI.Library;
using GuestRegistrationDesktopUI.Library.Api;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDesktopUI.Library.Models;
using GuestRegistrationDesktopUI.Library.OCR;
using GuestRegistrationWinForm;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesseractOCR.Library;

namespace gui
{
    public partial class FormCard : Form
    {

        public ICentralHub _centralHub;
        private ScannedFileModel _scannedFileInfo;
        private ScannedData _scannedData;
        private CameraStatus _cameraStatus;
        private ConsultantApplicationForm _consultantApplicationForm;
        private VisitorDataSheet _visitorDataSheet;
        public event PropertyChangedEventHandler PropertyChanged;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public FormCard()
        {
            InitializeComponent();
        }

        private void btnCardSearch_Click(object sender, EventArgs e)
        {
            RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
            try
            {
                VisitorInformation visitor = retriveDBinfo.GetVisitorByIdNumber(txtCardId.Text);
                ReloadDataToUi(visitor);
                //_scannedData.isDataFromDb[0] = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No Previous Visit Information!!");
            }
        }
        public void ReloadDataToUi(VisitorInformation visitor)
        {
            if (!string.IsNullOrEmpty(visitor.IdNumber))
            {
                //scannedData
                lblCardName.Text =  visitor.Name?.ToString();
                //_scannedData.isDataFromDb[0] = true;
                UpdatePhotoImageFromDb(ConvertBinaryToImage(Convert.FromBase64String(visitor.Photo)));

                UpdateImageDetails(visitor);

            }
            else
            {
                MessageBox.Show("No information matched in Database!");
            }

        }

        public void UpdateImageDetails(VisitorInformation visitor)
        {
            if (visitor.Photo.Length > 100)
            {
               // _scannedData.isDataFromDb[2] = true;
                File.WriteAllBytes(gCONSTANTS.TEMPPHOTOFILEPATH, Convert.FromBase64String(visitor.Photo));
            }
        }
        public Image ConvertBinaryToImage(byte[] binaryData)
        {

            using (MemoryStream memoryStream = new MemoryStream(binaryData))
            {
                // Create Image from binary data
                Image image = Image.FromStream(memoryStream);
                return image;
            }
        }
        public void UpdatePhotoImageFromDb(Image image)
        {
            // Resize the image to fit the PictureBox
            Bitmap resizedImage = new Bitmap(pbCardDemo.Width, pbCardDemo.Height);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, pbCardDemo.Width, pbCardDemo.Height);
            }

            // Set the PictureBox properties
            pbCardDemo.SizeMode = PictureBoxSizeMode.Zoom;
            pbCardDemo.Image = resizedImage;
        }
    }
}