﻿using System;
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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesseractOCR.Library;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Diagnostics;


namespace GuestRegistrationWinForm
{
    public partial class FormCardRecovery : Form
    {

        public string title = "VISMA";
        public ICentralHub _centralHub;
        private ScannedFileModel _scannedFileInfo;
        private ScannedData _scannedData;
        private CameraStatus _cameraStatus;
        private ConsultantApplicationForm _consultantApplicationForm;
        private VisitorDataSheet _visitorDataSheet;
        public event PropertyChangedEventHandler PropertyChanged;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        // private FormScan _formScan;
        string CardGeneratedFile = string.Empty;
        public FormCardRecovery(ICentralHub centralHub, ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
                            ConsultantApplicationForm consultantApplicationForm, VisitorDataSheet visitorDataSheet)
        {
            _centralHub = centralHub;
            InitializeComponent();
            _centralHub.CanonImageDownload += UpdatePhotoImage;

            _scannedFileInfo = ScannedFileModel.Instance;
            _cameraStatus = CameraStatus.Instance;
            _consultantApplicationForm = ConsultantApplicationForm.Instance;
            _visitorDataSheet = VisitorDataSheet.Instance;
            _scannedData = scannedData;
            
            //  LoadComboBoxData();

            Initialize();
        }

        public void Initialize()
        {
            LoadComboBoxData();
        }
      /*  private void btnCardRecovSearch_Click(object sender, EventArgs e)
        {
            RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
            try
            {
                VisitorInformation visitor = retriveDBinfo.GetVisitorByIdNumber(txtCardRecovId.Text);
                ReloadDataToUi(visitor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No Previous Visit Information!!");
            }
        }*/
        public void ReloadDataToUi(VisitorInformation visitor)
        {
            if (!string.IsNullOrEmpty(visitor.IdNumber))
            {
                //scannedData
                lblCardRecovName.Text = visitor.Name?.ToString();
                lblCradRecovNum.Text = visitor.CardNumber?.ToString();
                // lblCard.Visible = true;
                pbCardRecov.Image = ConvertBinaryToImage(Convert.FromBase64String(visitor.Photo));
                UpdatePhotoImageFromDb(ConvertBinaryToImage(Convert.FromBase64String(visitor.Photo)));
                // CameraStatus.Instance.ImagePath = visitor.Photo?.ToString();
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
                _scannedData.isDataFromDb[3] = true;

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
        public void UpdatePhotoImage(string path)
        {
            _cameraStatus.ImagePath = path;
            // Resize the image to fit the PictureBox
            Bitmap resizedImage = new Bitmap(pbCardRecov.Width, pbCardRecov.Height);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(Image.FromFile(path), 0, 0, pbCardRecov.Width, pbCardRecov.Height);
            }

            // Set the PictureBox properties
            pbCardRecov.SizeMode = PictureBoxSizeMode.Zoom;
            pbCardRecov.Image = resizedImage;
        }
        public void UpdatePhotoImageFromDb(Image image)
        {
            // Resize the image to fit the PictureBox
            Bitmap resizedImage = new Bitmap(pbCardRecov.Width, pbCardRecov.Height);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, pbCardRecov.Width, pbCardRecov.Height);
            }

            // Set the PictureBox properties
            pbCardRecov.SizeMode = PictureBoxSizeMode.Zoom;
            pbCardRecov.Image = resizedImage;
        }

        private void btnCardRecov_Click(object sender, EventArgs e)
        {
            try
            {

                _consultantApplicationForm.CardNumber = lblCradRecovNum.Text;
                UpdateData updateData = new UpdateData();
                updateData.RecoverCardStatus(_consultantApplicationForm.CardNumber);
                updateData.UpdateContractorStatus(_consultantApplicationForm.CardNumber);
                MessageBox.Show("Card Recovered", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //_formScan.txtname.Clear();
               // Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Card Recovery", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error($"Error Card Recovery{ex.Message}");
            }
            //Initialize();
        }

        private void FormCardRecovery_Load(object sender, EventArgs e)
        {
           //cmbCardNum.SelectedIndexChanged += CmbCardNum_SelectedIndexChanged;
        }

       private void CmbCardNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  throw new NotImplementedException();
          /*  if (cmbCardNum != null)
            {
                RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
                try
                {
                    VisitorInformation visitor = retriveDBinfo.GetVisitorbyCard(cmbCardNum.SelectedItem.ToString());
                    ReloadDataToUi(visitor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No Previous Visit Information!!");
                }
            }*/
        }
        public void LoadComboBoxData()
        {
            RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
            List<string> CardNo = retriveDBinfo.GetCards().Select(x => x.CardNumber).ToList();
            cmbCardNum.DataSource = CardNo;

        }

        private void Card_Load(object sender, EventArgs e)
        {
            //cmbCardNum.SelectedIndexChanged += CmbCardNum_SelectedIndexChanged;
            //cmbCardNum.SelectedIndex = -1;
            cmbCardNum.SelectedIndexChanged += CmbCardNum_SelectedIndexChanged1;
        }

        private void CmbCardNum_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (cmbCardNum != null)
            {
                RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
                try
                {
                    VisitorInformation visitor = retriveDBinfo.GetVisitorbyCard(cmbCardNum.SelectedItem.ToString());
                    ReloadDataToUi(visitor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No Previous Visit Information!!",title,MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
        
    }
}
