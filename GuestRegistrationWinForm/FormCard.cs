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

namespace gui
{
    public partial class FormCard : Form
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
        private FormScan _formScan;
        string CardGeneratedFile = string.Empty;
        public FormCard(ICentralHub centralHub, ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
                            ConsultantApplicationForm consultantApplicationForm, VisitorDataSheet visitorDataSheet, FormScan formScan)
        {
            _centralHub = centralHub;
            _centralHub.CanonImageDownload += UpdatePhotoImage;

            _scannedFileInfo = ScannedFileModel.Instance;
            _cameraStatus = CameraStatus.Instance;
            _consultantApplicationForm = ConsultantApplicationForm.Instance;
            _visitorDataSheet = VisitorDataSheet.Instance;
            _scannedData = scannedData;
            _formScan = formScan;
            InitializeComponent();
            // Check if the necessary data is available
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                cmbCardSelectPrinter .Items.Add(printer);
            }
            if (_formScan != null && _formScan.txtname != null)
            {
                // Load the value from the scan form
                lblCardName.Text = _formScan.txtname.Text.ToString();
                pbCardDemo.Image = _formScan.pbphoto.Image;
            }
            //  UpdatePhotoImage(_cameraStatus.ImagePath);
           
            Initialize();
        }

        private void Initialize()
        {
            LoadComboBox();
            lblCard.Visible = false;
           

        }

        public void LoadComboBox()
        {
            RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
            cmbCardNo.DataSource = retriveDBinfo.GetCardIds().Select(x => x.CardNumber).ToList();
            cmbCardNo.Text = _consultantApplicationForm.CardNumber;
            
        }
      
        private void btnCardSearch_Click(object sender, EventArgs e)
        {
            RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
            try
            {
                VisitorInformation visitor = retriveDBinfo.GetVisitorByIdNumber(txtCardId.Text);
                ReloadDataToUi(visitor);
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
                lblCardName.Text = visitor.Name?.ToString();
                pbCardDemo.Image = ConvertBinaryToImage(Convert.FromBase64String(visitor.Photo));
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
            Bitmap resizedImage = new Bitmap(pbCardDemo.Width, pbCardDemo.Height);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(Image.FromFile(path), 0, 0, pbCardDemo.Width, pbCardDemo.Height);
            }

            // Set the PictureBox properties
            pbCardDemo.SizeMode = PictureBoxSizeMode.Zoom;
            pbCardDemo.Image = resizedImage;
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
        private void btnCardPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ConcatenatedDataBinding concatenatedDataBinding = new ConcatenatedDataBinding();
                VisitorDataModel visitorDataModel = VisitorDataModel.Instance;
                visitorDataModel.Name = _scannedData.Name;
                visitorDataModel.IDno = _scannedData.IdNumber;
                concatenatedDataBinding.consultantApplicationForm = _consultantApplicationForm;

                // VisitorDataSheet visitorDataSheet = new VisitorDataSheet();
                ConfidentialityAgreementForVisitor CAforVisitor = new ConfidentialityAgreementForVisitor();
                VisitorsLogBook vlBook = new VisitorsLogBook();
                HighlySecurityControlAreaLog hsaLog = new HighlySecurityControlAreaLog();
                concatenatedDataBinding.CAforVisitor = CAforVisitor;
                concatenatedDataBinding.hsaLog = hsaLog;
                concatenatedDataBinding.vlBook = vlBook;
                concatenatedDataBinding.visitorDataSheet = VisitorDataSheet.Instance;


                if (visitorDataModel.Name == null && txtCardId != null)
                {
                    visitorDataModel.Name = lblCardName.Text;
                    
                    //CameraStatus.Instance.ImagePath = pbCardDemo.Image.ToString();
                    _cameraStatus.ImagePath = gCONSTANTS.TEMPPHOTOFILEPATH;
                    CardGeneratedFile = _centralHub.PrintIdCard(visitorDataModel.Name, "CONTRACTOR", CameraStatus.Instance.ImagePath,_consultantApplicationForm.CardNumber);
                    //_formScan.txtname.Clear();

                }

                else

                    // Assign the string to CameraStatus.Instance.ImagePath

                    CardGeneratedFile = _centralHub.PrintIdCard(visitorDataModel.Name, "CONTRACTOR", CameraStatus.Instance.ImagePath,_consultantApplicationForm.CardNumber);
                                 //_formScan.txtname.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Data Insert", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error($"Error Data Insert {ex.Message}");
            }

            _cameraStatus = CameraStatus.reset();
            try
            {
                if (!string.IsNullOrEmpty(CardGeneratedFile))
                {
                    System.Diagnostics.Process.Start(CardGeneratedFile);
                }
                else
                {
                    MessageBox.Show("Card is Not Generated", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.Error("Card Not Generated");
                }

                string selectedPrinter = cmbCardSelectPrinter.SelectedItem as string;

                if (!string.IsNullOrEmpty(selectedPrinter) && !string.IsNullOrEmpty(CardGeneratedFile))
                {
                    // Print the generated PDF file
                    PrintDocument(CardGeneratedFile, selectedPrinter);
                }
                else
                {
                    MessageBox.Show("Please select a printer and generate the card first.",title,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }

                // Open the generated PDF file
                if (!string.IsNullOrEmpty(CardGeneratedFile))
                {
                    System.Diagnostics.Process.Start(CardGeneratedFile);
                }
                else
                {
                    MessageBox.Show("Card is not generated.",title,MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Opening PDF", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error($"Error in Opening PDF {ex.Message}");
            }
        }
        private void PrintDocument(string filePath, string printerName)
        {
            try
            {
                // Create ProcessStartInfo for printing
                ProcessStartInfo psi = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    Verb = "printto",
                    FileName = filePath, // Path to the document you want to print
                    Arguments = "\"" + printerName + "\"" // Printer name to which you want to print
                };

                // Start the process for printing
                Process p = new Process();
                p.StartInfo = psi;
                p.Start();

                // Wait for the process to finish printing
                p.WaitForExit(2000); // Wait for 2 seconds
                if (!p.HasExited)
                {
                    // If the process has not exited after waiting, kill it
                    p.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error($"Error: {ex.Message}");
            }
        }
        private void cmbCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCardNo!=null)
            {
                _consultantApplicationForm.CardNumber = cmbCardNo.SelectedItem.ToString();
            }
            lblCard.Text = _consultantApplicationForm.CardNumber;
            lblCard.Visible = true;
        }

        private void FormCard_Load(object sender, EventArgs e)
        {
            cmbCardNo.SelectedIndexChanged += cmbCardNo_SelectedIndexChanged;
        }
    }
}

    