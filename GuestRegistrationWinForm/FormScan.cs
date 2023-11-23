//using GuestRegistrationDeskUI.ViewModels;
using GenerateDocument.Library;
using GuestRegistrationDesktopUI.Library.Api;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDesktopUI.Library.Models;
using GuestRegistrationDesktopUI.Library.OCR;
//using GuestRegistrationDeskUI.Models;
using GuestRegistrationWinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesseractOCR.Library;

namespace gui
{
    public partial class FormScan : Form
    {
        public ICentralHub _centralHub;
        private ScannedFileModel _scannedFileInfo;
        private ScannedData _scannedData;
        private CameraStatus _cameraStatus;
        private ConsultantApplicationForm _consultantApplicationForm;
        private VisitorDataSheet _visitorDataSheet;
        //private IAPIconnector _apiHelper;
        public FormScan(ICentralHub centralHub, ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
                            ConsultantApplicationForm consultantApplicationForm, VisitorDataSheet visitorDataSheet)
        {
            _centralHub = centralHub;
            _centralHub.CanonImageDownload += UpdatePhotoImage;

            InitializeComponent();

            _scannedFileInfo = scannedFileInfo;
            _cameraStatus = cameraStatus;
            _consultantApplicationForm = consultantApplicationForm;
            _visitorDataSheet = visitorDataSheet;
            _scannedData = scannedData;
            //_apiHelper = apiHelper;
            txtname.TextChanged += TextChanged;
            txtdob.TextChanged += TextChanged;
            txtexpiry.TextChanged += TextChanged;
            txtid.TextChanged += TextChanged;
            txtnationality.TextChanged += TextChanged;

            txtname.Text = _scannedData.Name;
            txtid.Text = _scannedData.IDno;
            txtexpiry.Text = _scannedData.Expiry;
            txtdob.Text = _scannedData.DateOfBirth;
            txtnationality.Text = _scannedData.Nationality;
            UpdatePhotoImage(_cameraStatus.ImagePath);
            updatePictures(pbfront, _scannedFileInfo.FrontSideFileName);
            updatePictures(pbback, _scannedFileInfo.BackSideFileName);
        }



        private void btnfront_Click(object sender, EventArgs e)
        {
            //MainScreenViewModel mainscreenVM = new MainScreenViewModel();
            if (rbid.Checked)
            {
                //rbpass.Visible = false;
                (var result, string fileName) = _centralHub.StartScanning(1);
                txtname.Text = result.Name.ToString();
                txtid.Text = result.IDno.ToString();
                txtdob.Text = result.DateOfBirth.ToString();
                txtexpiry.Text = result.Expiry.ToString();
                txtnationality.Text = result.Nationality.ToString();

                _scannedFileInfo.FrontSideFileName = fileName;
                updatePictures(pbfront, fileName);


            }
            else if (rbpass.Checked)
            {
                (var result, string fileName) = _centralHub.StartScanning(2);
                txtname.Text = result.Name.ToString();
                txtid.Text = result.IDno.ToString();
                txtdob.Text = result.DateOfBirth.ToString();
                txtexpiry.Text = result.Expiry.ToString();
                txtnationality.Text = result.Nationality.ToString();

                _scannedFileInfo.FrontSideFileName = fileName;
                updatePictures(pbfront, fileName);
            }
            else
            {
                MessageBox.Show("Please select the ID Type");
            }
        }

        private void updatePictures(PictureBox pictureBox, string filePath)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = Image.FromFile(filePath);
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            if (rbid.Checked)
            {
                string fileName = _centralHub.ScanBackSide(1); // (var result, string fileName) =
                _scannedFileInfo.BackSideFileName = fileName;
                updatePictures(pbback, fileName);
            }
            else if (rbpass.Checked)
            {
                string fileName = _centralHub.ScanBackSide(2);
                _scannedFileInfo.BackSideFileName = fileName;
                updatePictures(pbback, fileName);
            }
            else
            {
                MessageBox.Show("Please select the ID type");
            }
        }

        private void btnphoto_Click(object sender, EventArgs e)
        {
            try
            {
                _centralHub.TakePhoto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, Please check the camera");
            }
        }

        public void UpdatePhotoImage(string path)
        {
            _cameraStatus.ImagePath = path;

            // Load the original image
            Image originalImage = Image.FromFile(path);

            // Resize the image to fit the PictureBox
            Bitmap resizedImage = new Bitmap(pbphoto.Width, pbphoto.Height);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, pbphoto.Width, pbphoto.Height);
            }

            // Set the PictureBox properties
            pbphoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbphoto.Image = resizedImage;
        }

        private void TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Name == txtname.Name)
            {
                _scannedData.Name = txtname.Text;
            }
            if (tb.Name == txtnationality.Name)
            {
                _scannedData.Nationality = txtnationality.Text;
            }
            if (tb.Name == txtid.Name)
            {
                _scannedData.IDno = txtid.Text;
            }
            if (tb.Name == txtexpiry.Name)
            {
                _scannedData.Expiry = txtexpiry.Text;
            }
            if (tb.Name == txtdob.Name)
            {
                _scannedData.DateOfBirth = txtdob.Text;
            }
        }
    }
}

