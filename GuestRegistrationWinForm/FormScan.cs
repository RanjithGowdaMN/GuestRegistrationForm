//using GuestRegistrationDeskUI.ViewModels;
using GenerateDocument.Library;
using GuestDataManager.Library.DataAccess;
using GuestRegistrationDesktopUI.Library;
using GuestRegistrationDesktopUI.Library.Api;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDesktopUI.Library.Models;
using GuestRegistrationDesktopUI.Library.OCR;
//using GuestRegistrationDeskUI.Models;
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
    public partial class FormScan : Form, INotifyPropertyChanged
    {
        public ICentralHub _centralHub;
        private ScannedFileModel _scannedFileInfo;
        private ScannedData _scannedData;
        private CameraStatus _cameraStatus;
        private ConsultantApplicationForm _consultantApplicationForm;
        private VisitorDataSheet _visitorDataSheet;
        public event PropertyChangedEventHandler PropertyChanged;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        //private IAPIconnector _apiHelper;
        public FormScan(ICentralHub centralHub, ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
                            ConsultantApplicationForm consultantApplicationForm, VisitorDataSheet visitorDataSheet)
        {
            _centralHub = centralHub;
            _centralHub.CanonImageDownload += UpdatePhotoImage;

            InitializeComponent();
            //panelPass.Visible = false;
            _scannedFileInfo = ScannedFileModel.Instance;
            _cameraStatus = CameraStatus.Instance;
            _consultantApplicationForm = ConsultantApplicationForm.Instance;
            _visitorDataSheet = VisitorDataSheet.Instance;
            _scannedData = scannedData;
            //_apiHelper = apiHelper;
            txtname.TextChanged += TextChanged;
            txtdob.TextChanged += TextChanged;
            txtexpiry.TextChanged += TextChanged;
            txtid.TextChanged += TextChanged;
            txtnationality.TextChanged += TextChanged;

            txtname.Text = _scannedData.Name;
            txtid.Text = _scannedData.IdNumber;
            txtexpiry.Text = _scannedData.Expiry;
            txtdob.Text = _scannedData.DateOfBirth;
            txtnationality.Text = _scannedData.Nationality;
        
            UpdatePhotoImage(_cameraStatus.ImagePath);
            updatePictures(pbfront, _scannedFileInfo.FrontSideFileName);
            updatePictures(pbback, _scannedFileInfo.BackSideFileName);
            updatePictures(pbPassportScan, _scannedFileInfo.FrontSideFileName);
            updateRadioButtons();
        }

        private void updateRadioButtons()
        {
            if (_scannedData.IdType == 2)
            {
                rbpass.Checked = true;
            }
            else {
                rbid.Checked = true;
            }
        }
        
        private void btnScanIdFront_Click(object sender, EventArgs e)
        {
            try
            {
                _scannedData.isDataFromDb[0] = false;
                if (rbid.Checked)
                {
                    //rbpass.Visible = false;
                    (var result, string fileName) = _centralHub.StartScanning(1);
                    txtname.Text = result.Name?.ToString();
                    txtid.Text = result.IDno?.ToString();
                    txtdob.Text = result.DateOfBirth?.ToString();
                    txtexpiry.Text = result.Expiry?.ToString();
                    txtnationality.Text = result.Nationality?.ToString();
                    _scannedData.IdType = 1;
                    _scannedFileInfo.FrontSideFileName = fileName;
                    updatePictures(pbfront, fileName);
                }
                else if (rbpass.Checked)
                {
                    
                    (var result, string fileName) = _centralHub.StartScanning(2);
                    txtname.Text = result.Name?.ToString();
                    txtid.Text = result.IDno?.ToString();
                    txtdob.Text = result.DateOfBirth?.ToString();
                    txtexpiry.Text = result.Expiry?.ToString();
                    txtnationality.Text = result.Nationality?.ToString();
                    _scannedData.IdType = 2;
                    _scannedFileInfo.FrontSideFileName = fileName;
                    updatePictures(pbPassportScan, fileName);
                }
                else
                {
                    MessageBox.Show("Please select the ID Type");
                }
                this.AutoScaleDimensions = Program.originalSize;
                this.Size = Program.originalSize;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check the scanner!");
                Logger.Error("scan error", ex.Message);
            }
        }

        private void updatePictures(PictureBox pictureBox, string filePath)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = Image.FromFile(filePath);
        }
        private void btnback_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Please check the scanner!");
                Logger.Error("scan error", ex.Message);
            }
        }
        private void btnPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                _cameraStatus = _centralHub.TakePhoto();
                if (!_cameraStatus.CameraSessionActive)
                {
                    MessageBox.Show($"Camera is off or not connected!! \n photo not taken!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, Please check the camera");
            }
        }
        public void UpdatePhotoImage(string path)
        {
            _cameraStatus.ImagePath = path;
            // Resize the image to fit the PictureBox
            Bitmap resizedImage = new Bitmap(pbphoto.Width, pbphoto.Height);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(Image.FromFile(path), 0, 0, pbphoto.Width, pbphoto.Height);
            }

            // Set the PictureBox properties
            pbphoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbphoto.Image = resizedImage;
        }
        public void UpdatePhotoImageFromDb(Image image)
        {
            // Resize the image to fit the PictureBox
            Bitmap resizedImage = new Bitmap(pbphoto.Width, pbphoto.Height);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, pbphoto.Width, pbphoto.Height);
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
                _scannedData.IdNumber = txtid.Text;
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
        private void SearchVisitor_Click(object sender, EventArgs e)
        {
            RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
            try
            {
               VisitorInformation visitor = retriveDBinfo.GetVisitorByIdNumber(txtid.Text);
               ReloadDataToUi(visitor);
               //_scannedData.isDataFromDb[0] = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No Previous Visit Information!!");
            }
             //List<List<string>> CompanyNames = 

        }
        public void ReloadDataToUi(VisitorInformation visitor)
        {
            if (!string.IsNullOrEmpty(visitor.IdNumber))
            {
                //scannedData
                txtname.Text = _scannedData.Name = visitor.Name?.ToString();
                txtid.Text = _scannedData.IdNumber = visitor.IdNumber?.ToString();
                txtdob.Text = _scannedData.DateOfBirth = visitor.Dob?.ToString();
                txtexpiry.Text = _scannedData.Expiry  = visitor.IdExpiry?.ToString();
                txtnationality.Text = _scannedData.Nationality  =  visitor.RFU9?.ToString();
                rbid.Checked = _scannedData.IdType == 1 ? true: rbpass.Checked = true;

                _scannedData.isDataFromDb[0] = true;
                if (visitor.RFU10 == "contract")
                {
                    //consultantApplicationForm
                    _consultantApplicationForm.Title = visitor.Title ?? string.Empty;
                    _consultantApplicationForm.Address = visitor.Address ?? string.Empty;
                    _consultantApplicationForm.Alias = visitor.AliasName ?? string.Empty;
                    _consultantApplicationForm.CellPhone = visitor.CellPhone ?? string.Empty;
                    _consultantApplicationForm.City = visitor.City ?? string.Empty;
                    _consultantApplicationForm.CompanyName = visitor.CompanyName ?? string.Empty;
                    _consultantApplicationForm.Email = visitor.Email;
                    _consultantApplicationForm.EmergencyContactNo = visitor.EmergencyContact;
                    _consultantApplicationForm.HomePhoneNo = visitor.HomePhoneNo;
                    _consultantApplicationForm.PassportNumber = visitor.PassportNumber;
                    _consultantApplicationForm.SocialSecurityNumber = visitor.SocialSecurityNumber;
                    _consultantApplicationForm.Zip = visitor.Zip;
                    _consultantApplicationForm.Title = visitor.Title;
                    _consultantApplicationForm.Previous7YrResidency = visitor.Previous7YrResidency;
                    _consultantApplicationForm.State = visitor.State;
                    _consultantApplicationForm.PurposeOfVisit = visitor.PurposeOfVisit;
                    _consultantApplicationForm.ConvictedFelony = Convert.ToBoolean(visitor.Convicted);
                    _consultantApplicationForm.PlaceofIssue = visitor.PassportIssuePlace;
                    pbfront.Image = ConvertBinaryToImage(Convert.FromBase64String(visitor.IdFrontSide));
                    pbback.Image = ConvertBinaryToImage(Convert.FromBase64String(visitor.IdBackSide));
                    UpdatePhotoImageFromDb(ConvertBinaryToImage(Convert.FromBase64String(visitor.Photo)));

                    UpdateImageDetails(visitor);
                    //Passport IssuedData etc...
                }
                else if(visitor.RFU10 == "visitor") {
                    //visitorDataSheet
                    _visitorDataSheet.Title = visitor.Title;
                    _visitorDataSheet.AreaVisited = visitor.AreaToBeVisited;
                    _visitorDataSheet.CompanyName = visitor.CompanyName;
                    _visitorDataSheet.DepartmentManager = visitor.DepartmentManager;
                    _visitorDataSheet.PersonToBeVisited = visitor.PersonToBeVisited;
                    _visitorDataSheet.ProductionManager = visitor.ProductionManager;
                    _visitorDataSheet.SecurityController = visitor.SecurityController;
                    _visitorDataSheet.PurposeOfVisit = visitor.PurposeOfVisit;
                    pbfront.Image = ConvertBinaryToImage(Convert.FromBase64String(visitor.IdFrontSide));
                    pbback.Image = ConvertBinaryToImage(Convert.FromBase64String(visitor.IdBackSide));
                    UpdatePhotoImageFromDb(ConvertBinaryToImage(Convert.FromBase64String(visitor.Photo)));

                    UpdateImageDetails(visitor);
                    //TBD 
                } else
                {
                    MessageBox.Show("No information matched in Database!");
                }
            }
        }
        public void UpdateImageDetails(VisitorInformation visitor)
        {
            
            if (visitor.IdFrontSide.Length > 100)
            {
                _scannedData.isDataFromDb[1] = true;
                File.WriteAllBytes(gCONSTANTS.TEMPIDFRONTFILEPATH, Convert.FromBase64String(visitor.IdFrontSide));
            }
            if (visitor.IdBackSide.Length > 100)
            {
                _scannedData.isDataFromDb[2] = true;
                File.WriteAllBytes(gCONSTANTS.TEMPIDBACKSIDEFILEPATH, Convert.FromBase64String(visitor.IdBackSide));
            }
            if (visitor.Photo.Length > 100)
            {
                _scannedData.isDataFromDb[2] = true;
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

        private void panelScan_AutoSizeChanged(object sender, EventArgs e)
        {
            this.Size = Program.originalSize;
        }

        private void rbpass_Click(object sender, EventArgs e)
        {
            _scannedData.IdType = 2;
            
        }

        private void rbpass_CheckedChanged(object sender, EventArgs e)
        {

            if (rbpass.Checked)
            {
                panelId.Visible = false;
                panelPass.Visible = true;
            }
        }

        private void rbid_CheckedChanged(object sender, EventArgs e)
        {
            if (rbid.Checked)
            {
                panelId.Visible = true;
                panelPass.Visible = false;
            }
        }
    }
}

