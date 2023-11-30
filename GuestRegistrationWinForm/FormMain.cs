using GenerateDocument.Library;
using GuestDataManager.Library.DataAccess;
using GuestRegistrationDesktopUI.Library.Api;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDesktopUI.Library.Models;
using GuestRegistrationDesktopUI.Library.OCR;
using GuestRegistrationDeskUI.Models;
using GuestRegistrationWinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesseractOCR.Library;
using System.Runtime.InteropServices;
using NLog;
using System.Diagnostics;

namespace gui
{
    public partial class FormMain : Form
    {
        public static DependencyInjectionContainer _container;
        private Form activeForm;
        private Process myProcess;
        public CameraStatus cameraStatus;
        public ScannedFileModel scannedFileInfo;
        public ScannedData scannedData;
        public VisitorDataSheet visitorDataSheet;
        public ConsultantApplicationForm consultantApplicationForm;
        public IGeneratePDFdocument _generatePDFdocument;

        public ICentralHub centralHub;
        private IAPIconnector _apiHelper;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormMain()
        {
            Logger.Info("Initialization Of Services,");
            _container = new DependencyInjectionContainer();
            _container.Register<ITesseractHelper>(new TesseractLib());
            _container.Register<IOCRhelper>(new OCRhelper(_container.Resolve<ITesseractHelper>()));
            _container.Register<IGenerateWordDocument>(new GenerateWordDocument());
            _container.Register<IGeneratePDFdocument>(new GeneratePDFdocument());
            _container.Register<IGenerateCardPrintDoc>(new GenerateCardPrintDoc());
            _container.Register<IAPIconnector>(new APIconnector());
            _container.Register<ICentralHub>(new CentralHub(_container.Resolve<IOCRhelper>(),
                                            _container.Resolve<IGenerateWordDocument>(),
                                            _container.Resolve<IGeneratePDFdocument>(),
                                            _container.Resolve<IGenerateCardPrintDoc>()));
            _apiHelper = _container.Resolve<IAPIconnector>();
            InitializeComponent();

            cameraStatus = new CameraStatus();
            scannedFileInfo = new ScannedFileModel();
            visitorDataSheet = new VisitorDataSheet();
            consultantApplicationForm = new ConsultantApplicationForm();
            scannedData = new ScannedData();
            centralHub = _container.Resolve<ICentralHub>();
            //(var result, string fileName) = centalHub.StartScanning(1);

            //HandleProcess();
            LoadComponentsData();
        }

        private void HandleProcess()
        {
            string processName = "GuestRegistrationWinForm.exe";

            // Check if the process is already running
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
            {
                // Start the process if it's not already running
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = processName,
                    // Add any additional settings if needed
                };

                myProcess = Process.Start(startInfo);
            }
            else
            {
                // Use the existing process if it's already running
                myProcess = processes[0];
            }

            // Subscribe to the FormClosing event to stop the process when the form is closed
            this.FormClosing += btnWindowClsoe_Click;
        }

        private void LoadComponentsData()
        {
            
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            
              activeForm = childForm;
            childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelform.Controls.Add(childForm);
            this.panelform.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void ClearData() { 
        
        
        }
        private void btnscan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormScan(centralHub, scannedFileInfo, scannedData, cameraStatus, consultantApplicationForm, visitorDataSheet), sender);
        }

        private void btncontractor_Click(object sender, EventArgs e)
        {
            Form formContractor = new FormContractor(centralHub, scannedFileInfo, scannedData, cameraStatus, consultantApplicationForm, visitorDataSheet);
            OpenChildForm(formContractor, sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormVisitor(centralHub, scannedFileInfo, scannedData, cameraStatus, consultantApplicationForm, visitorDataSheet), sender);
        }

        private void btndoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDoc(centralHub, scannedFileInfo, scannedData, cameraStatus, consultantApplicationForm, visitorDataSheet), sender);
        }

        private void btnlgt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCard(), sender);
        }

        private void panelhome_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void btnWindowClsoe_Click(object sender, EventArgs e)
        {

            string processName = "GuestRegistrationWinForm";

            if (!string.IsNullOrEmpty(processName))
            {
                // Get all processes with the specified name
                Process[] processes = Process.GetProcessesByName(processName);

                if (processes.Length > 0)
                {
                    foreach (Process process in processes)
                    {
                        try
                        {
                            // Kill the process
                            process.Kill();
                            MessageBox.Show($"Process '{process.ProcessName}' with ID {process.Id} killed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error killing process: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"No processes found with the name '{processName}'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid process name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Application.Exit();
            //this.Close();
        }
//Minimize
        private void btnWindowMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        //maximize
        private void btnWindowMin_Click(object sender, EventArgs e)
        {
           
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
    }
}
