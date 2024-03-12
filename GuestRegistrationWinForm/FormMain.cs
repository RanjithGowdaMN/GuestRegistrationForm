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
using EOSDigital.API;
using System.Threading;
using System.Management;
using System.Reflection;

namespace gui
{
    public partial class FormMain : Form
    {
        public static DependencyInjectionContainer _container;
        private BackgroundWorker backgroundWorker;
        private System.Threading.Timer timer;
        private Form activeForm;
        private Process myProcess;
        public CameraStatus cameraStatus;
        public ScannedFileModel scannedFileInfo;
        public ScannedData scannedData;
        public VisitorDataSheet visitorDataSheet;
        public ConsultantApplicationForm consultantApplicationForm;
        public IGeneratePDFdocument _generatePDFdocument;
        public FormScan scanForm;
        public FormContractor FormContractor;
        public ICentralHub centralHub;
        private IAPIconnector _apiHelper;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private ManagementEventWatcher watcher;
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
         
            //rbCameraStatus.CheckedChanged += new EventHandler(backColor_ColorChanged);
            //rbScannerStatus.CheckedChanged += new EventHandler(backColor_ColorChanged);

            cameraStatus = CameraStatus.Instance;
            scannedFileInfo = ScannedFileModel.Instance;
            visitorDataSheet = VisitorDataSheet.Instance;
            consultantApplicationForm = ConsultantApplicationForm.Instance;
            scannedData = new ScannedData();
            centralHub = _container.Resolve<ICentralHub>();
            LoadComponentsData();
            lblCamera.ForeColor = Color.Red;
            lblScanner.ForeColor = Color.Red;

            MaximizeWindow();
           
            

            try
            {
                // Create a WMI event query to detect creation or deletion of Win32_PnPEntity instances
                WqlEventQuery query = new WqlEventQuery(
                    "SELECT * FROM __InstanceOperationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_PnPEntity'");

                // Initialize the watcher
                watcher = new ManagementEventWatcher(query);
                watcher.EventArrived += HardwareChangeEventArrived;

                // Start listening for events
                watcher.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing scanner detection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HardwareChangeEventArrived(object sender, EventArrivedEventArgs e)
        {
            //string DeviceName = string.Empty;
            //bool status = false;
            //try
            //{
            //    PropertyData propertyData = e.NewEvent.Properties["TargetInstance"];
            //    if (propertyData != null && propertyData.Value is ManagementBaseObject)
            //    {
            //        ManagementBaseObject targetInstance = (ManagementBaseObject)propertyData.Value;
            //        var test = targetInstance.Properties;

            //        foreach (var item in test)
            //        {
            //            if (item.Name == "Present") {
            //                status = (bool)item.Value;
            //            }
            //            if (item.Name == "Description") {
            //                DeviceName = item.Value.ToString();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error handling hardware change event: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //UpdateDeviceStatus(DeviceName, status);
        }

        private void UpdateDeviceStatus(string deviceName, bool status)
        {

            if (deviceName == "Canon EOS 4000D")
            {
                if (status)
                {
                    lblCamera.ForeColor = Color.Green;
                } else
                {
                    lblCamera.ForeColor = Color.Red;
                }
            }
            else if (deviceName == "fi-800R")
            {
                if (status)
                {
                    lblScanner.ForeColor = Color.Green;
                }
                else
                {
                    lblScanner.ForeColor = Color.Red;
                }
            }
        }

        private void BackgroudTimer_Tick(object sender, EventArgs e)
        {
            if (centralHub.ScannerHeartbeat())
            {
                lblScanner.ForeColor = Color.Green;
            }
            else
            {
                lblScanner.ForeColor = Color.Red;
            }
        }
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(10000);
            while (true)
            {
                Thread.Sleep(3000);
                if (centralHub.ScannerHeartbeat())
                {
                    lblScanner.ForeColor = Color.Green;
                }
                else
                {
                    lblScanner.ForeColor = Color.Red;
                }
            }
        }
       
        public async Task<bool> checkScannerHearbeat()
        {
            Thread.Sleep(10000);
            while (true)
            {
                await Task.Delay(3000);
                if (centralHub.ScannerHeartbeat())
                {
                    lblScanner.ForeColor = Color.Green;
                }
                else
                {
                    lblScanner.ForeColor = Color.Red;
                }
            }
            //checkScannerHearbeat();
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
            //if (activeForm != null)
            //    activeForm.Close();
            
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
        private void btnScan_Click(object sender, EventArgs e)
        {
            scanForm = new FormScan(centralHub, scannedFileInfo, scannedData, cameraStatus, consultantApplicationForm, visitorDataSheet);
            scanForm.AutoScaleMode = AutoScaleMode.None;
            OpenChildForm(scanForm, sender);
        }

        private void btncontractor_Click(object sender, EventArgs e)
        {
            Form formContractor = new FormContractor(centralHub, scannedFileInfo, scannedData, cameraStatus, consultantApplicationForm, visitorDataSheet, scanForm);
            OpenChildForm(formContractor, sender);
        }

        private void btnVisitorTab_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormVisitor(centralHub, scannedFileInfo, scannedData, cameraStatus, consultantApplicationForm, visitorDataSheet, scanForm), sender);
        }

        private void btndoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDoc(centralHub, scannedFileInfo, scannedData, cameraStatus, consultantApplicationForm, visitorDataSheet), sender);
        }

        private void btnlgt_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCardRecovery(centralHub, scannedFileInfo, scannedData, cameraStatus, consultantApplicationForm, visitorDataSheet), sender);
        }

        private void btncard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCard(centralHub, scannedFileInfo, scannedData, cameraStatus, consultantApplicationForm, visitorDataSheet, scanForm,FormContractor), sender);
        }
        private void btnContactorHistory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormContractorHistory(), sender);
        }
        private void panelhome_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        private void btnVisitorsHistory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormVisitHistory(), sender);
        }
        private void btnWindowClsoe_Click(object sender, EventArgs e)
        {

            string processName = "GuestRegistrationWinForm";
            string title = "VISMA";
            DialogResult dialogResult = MessageBox.Show("Are you want to exit the application?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
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
                                //MessageBox.Show($"Process '{process.ProcessName}' with ID {process.Id} killed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                Logger.Error("Error", $"Error killing process: {ex.Message}");
                            }
                        }
                    }
                    else
                    {
                        //MessageBox.Show($"No processes found with the name '{processName}'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else
                {
                    //MessageBox.Show("Please enter a valid process name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Application.Exit();
            }
            //this.Close();
        }
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
               CenterToScreen();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
          //  Reset();
        }

        private void SetVersionInfo()
        {
            
            Version versionInfo = Assembly.GetExecutingAssembly().GetName().Version;
            //string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            string productName = Application.ProductName;

            string majorMinorVersion = $"{versionInfo.Major}.{versionInfo.Minor}";
            lblversion.Text = $"{productName} - {majorMinorVersion}";
        }
        private void panelStatus_Paint(object sender, PaintEventArgs e)
        {
            SetVersionInfo();
        }
        private void MaximizeWindow()
        {
            var rectangle = Screen.FromControl(this).Bounds;
            this.FormBorderStyle = FormBorderStyle.None;
            Size = new Size(rectangle.Width, rectangle.Height);
            Location = new Point(0, 0);
            Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Size = new Size(workingRectangle.Width, workingRectangle.Height);
        }

      
    }
}
