using GuestDataManager.Library.DataAccess;
using GuestRegistrationDesktopUI.Library.Api;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDesktopUI.Library.Models;
using GuestRegistrationDeskUI.Models;
using GuestRegistrationWinForm;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public partial class FormVisitor : Form
    {
        public string title = "Instant Card printing";
        public ICentralHub _centralHub;
        private ScannedFileModel _scannedFileInfo;
        private ScannedData _scannedData;
        private CameraStatus _cameraStatus;
        private ConsultantApplicationForm _consultantApplicationForm;
        private VisitorDataSheet _visitorDataSheet;
        private FormScan _formScan;
        string VisitorGeneratedFile = string.Empty;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        //private IAPIconnector _apiHelper;
        public FormVisitor(ICentralHub centralHub, ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
                            ConsultantApplicationForm consultantApplicationForm, VisitorDataSheet visitorDataSheet, FormScan formScan)
        {
            _centralHub = centralHub;
            InitializeComponent();
         //  dtVisitorVisitDate.MinDate = DateTime.Now;
            _scannedFileInfo = ScannedFileModel.Instance;
            _cameraStatus = CameraStatus.Instance;
            _consultantApplicationForm = ConsultantApplicationForm.Instance;
            _visitorDataSheet = VisitorDataSheet.Instance;
            _scannedData = scannedData;
            _formScan = formScan;
            //_apiHelper = apiHelper;
            Initialize();
            //txtVisitorTitle.TextChanged += TextChanged;
            txtVisitorComp.TextChanged += TextChanged;
            //txtVisitorSecutityController.TextChanged += TextChanged;
        }

        private void Initialize()
        {
            //  txtVisitorTitle.Text = _visitorDataSheet.Title;
            txtVisitorComp.Text = _visitorDataSheet.CompanyName;
            //txtVisitorSecutityController.Text = _visitorDataSheet.SecurityController;
            // dtVisitorVisitDate.Text = _visitorDataSheet.VisitDateFrom;
            // _visitorDataSheet.VisitDuration = dtVisitorVisitDuration.Text;
            LoadComboxBoxData();
        }
        private void CmbVisitorComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            if (cmbVisitorComp.SelectedItem.ToString() == "other")
            {
                txtVisitorComp.Visible = true;
            }
            else
            {
                txtVisitorComp.Visible = false;
                _visitorDataSheet.CompanyName = cmbVisitorComp.SelectedItem.ToString();
            }
        }
        public void LoadComboxBoxData()
        {

            RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
            List<string> CompanyNames = retriveDBinfo.GetCompanyname().Select(x => x.CompanyNames).ToList();
            cmbVisitorComp.DataSource = CompanyNames;

            cmbVistorReasonForVisit.DataSource = retriveDBinfo.GetVisitorVisitPurpose().Select(x => x.Purpose).ToList();
            cmbVistorReasonForVisit.Text = _visitorDataSheet.PurposeOfVisit;

            cmbVisitorProductionManager.DataSource = retriveDBinfo.GetProductionManagers().Select(x => x.ProductionManager).ToList();
            cmbVisitorProductionManager.Text = _visitorDataSheet.ProductionManager;

            cmbVisitorTitle.DataSource = retriveDBinfo.GetVisitorTitle().Select(x => x.Title).ToList();
            cmbVisitorTitle.Text = _visitorDataSheet.Title;

            cmbVisitorAreaVisited.DataSource = retriveDBinfo.GetAreatobeVisited().Select(x => x.Area).ToList();
            cmbVisitorAreaVisited.Text = _visitorDataSheet.AreaVisited;

            cmbvisitorDeptManager.DataSource = retriveDBinfo.GetDepartmentManager().Select(x => x.Managers).ToList();
            cmbvisitorDeptManager.Text = _visitorDataSheet.DepartmentManager;

            cmbVisitorPersonToVisited.DataSource = retriveDBinfo.GetPersontobeVisited().Select(x => x.EmployeeNames).ToList();
            cmbVisitorPersonToVisited.Text = _visitorDataSheet.PersonToBeVisited;

            cmbVisitorSecurityController.DataSource = retriveDBinfo.GetSecurityController().Select(x => x.Name).ToList();
            cmbVisitorSecurityController.Text = _visitorDataSheet.SecurityController;

            if ((!CompanyNames.Contains(_visitorDataSheet.CompanyName) && (_visitorDataSheet.CompanyName != null)))
            {
                txtVisitorComp.Text = _visitorDataSheet.CompanyName;
                cmbVisitorComp.Text = "other";
            }
            else
            {
                cmbVisitorComp.Text = _visitorDataSheet.CompanyName;
            }
            //load dates
            if (_visitorDataSheet.VisitDateFrom != null)
            {
                dtVisitorVisitDate.Value = DateTime.Parse(_visitorDataSheet.VisitDateFrom);
            }
            if (_visitorDataSheet.VisitDuration != null)
            {
                dtVisitorVisitDuration.Value = DateTime.Parse(_visitorDataSheet.VisitDuration);
            }

            cmbVisitTimeFromHr.Text = (_visitorDataSheet.VisitTimeHrFrom != "00") ? _visitorDataSheet.VisitTimeHrFrom : "00";
            cmbVisitTimeFromMinutes.Text = (_visitorDataSheet.VisitTimeMinFrom != "00") ? _visitorDataSheet.VisitTimeMinFrom : "00";
            cmbVisitorVisitTimeToHr.Text = (_visitorDataSheet.VisitTimeHrTo != "00") ? _visitorDataSheet.VisitTimeHrTo : "00";
            cmbVisitorVisitTimeToMinutes.Text = (_visitorDataSheet.VisitTimeMinTo != "00") ? _visitorDataSheet.VisitTimeMinTo : "00";
        }
        private void TextChanged(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
          
            if (tb.Name == txtVisitorComp.Name)
            {
                _visitorDataSheet.CompanyName = txtVisitorComp.Text;
            }          
            if (tb.Name == dtVisitorVisitDate.Name)
            {
                _visitorDataSheet.VisitDateFrom = dtVisitorVisitDate.Value.Date.ToString("dd/MM/yyyy");
            }
            if (tb.Name == dtVisitorVisitDuration.Name)
            {
                _visitorDataSheet.VisitDuration = dtVisitorVisitDuration.Value.Date.ToString("dd/MM/yyyy");
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (cmbVisitorComp.Text == "other")
            {
                txtVisitorComp.Visible = true;
            } else
            {
                txtVisitorComp.Visible = false;
            }
        }
        private void FormVisitor_Load(object sender, EventArgs e)
        {
            txtVisitorComp.Visible = false;
            cmbVisitorComp.SelectedIndexChanged += CmbVisitorComp_SelectedIndexChanged;
            cmbVisitorAreaVisited.SelectedIndexChanged += CmbVisitorAreaVisited_SelectedIndexChanged;
            cmbvisitorDeptManager.SelectedIndexChanged += CmbvisitorDeptManager_SelectedIndexChanged;
            cmbVisitorPersonToVisited.SelectedIndexChanged += CmbVisitorPersonToVisited_SelectedIndexChanged;
            cmbVisitorProductionManager.SelectedIndexChanged += CmbVisitorProductionManager_SelectedIndexChanged;
            cmbVisitorTitle.SelectedIndexChanged += cmbVisitorTitle_SelectedIndexChanged;
            cmbVistorReasonForVisit.SelectedIndexChanged += CmbVistorReasonForVisit_SelectedIndexChanged;
        }
        private void cmbVisitorTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVisitorTitle != null)
            {
                _visitorDataSheet.Title = cmbVisitorTitle.SelectedItem.ToString();
            }
        }
        private void CmbVistorReasonForVisit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  throw new NotImplementedException();
            if (cmbVistorReasonForVisit != null)
            {
                _visitorDataSheet.PurposeOfVisit = cmbVistorReasonForVisit.SelectedItem.ToString();
            }
        }
        private void CmbVisitorProductionManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVisitorProductionManager != null)
            {
                _visitorDataSheet.ProductionManager = cmbVisitorProductionManager.SelectedItem.ToString();
            }
        }
        private void CmbVisitorPersonToVisited_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (cmbVisitorPersonToVisited != null)
            {
                _visitorDataSheet.PersonToBeVisited = cmbVisitorPersonToVisited.SelectedItem.ToString();
            }
        }
        private void CmbvisitorDeptManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (cmbvisitorDeptManager != null)
            {
                _visitorDataSheet.DepartmentManager = cmbvisitorDeptManager.SelectedItem.ToString();
            }
        }

        private void CmbVisitorAreaVisited_SelectedIndexChanged(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
            if (cmbVisitorAreaVisited != null)
            {
                _visitorDataSheet.AreaVisited = cmbVisitorAreaVisited.SelectedItem.ToString();
            }
        }
        private void dtVisitorVisitDate_ValueChanged(object sender, EventArgs e)
        {
            _visitorDataSheet.VisitDateFrom = dtVisitorVisitDate.Value.Date.ToString("dd/MM/yyyy");
        }
        //  private void dtVisitorDuration_ValueChanged(object sender, EventArgs e)
        //{
        //  _visitorDataSheet.VisitDuration = dtVisitorVisitDuration.Value.ToString();
        // }
        public bool ErrorValidation()
        {
            bool ErrorFlag = false;
            if (string.IsNullOrEmpty(cmbVisitorTitle.Text))
            {
                errorProvider1.SetError(cmbVisitorTitle, " Select the Title");
                ErrorFlag = true;
            }
            else
            {
                errorProvider1.SetError(cmbVisitorTitle, string.Empty);
            }

            if (string.IsNullOrEmpty(cmbVisitorComp.Text))
            {
                errorProvider1.SetError(cmbVisitorComp, "Select the Company name");
                ErrorFlag = true;
            }
            else
            {
                errorProvider1.SetError(cmbVisitorComp, string.Empty);
            }
            if (string.IsNullOrEmpty(cmbVistorReasonForVisit.Text))
            {
                errorProvider1.SetError(cmbVistorReasonForVisit, "Select the reason for visit");
                ErrorFlag = true;
            }
            else
            {
                errorProvider1.SetError(cmbVistorReasonForVisit, string.Empty);
            }
            if (string.IsNullOrEmpty(cmbVisitorPersonToVisited.Text))
            {
                errorProvider1.SetError(cmbVisitorPersonToVisited, "Select the person to be visited");
                ErrorFlag = true;
            }
            else
            {
                errorProvider1.SetError(cmbVisitorPersonToVisited, string.Empty);
            }
            if (string.IsNullOrEmpty(cmbVisitorAreaVisited.Text))
            {
                errorProvider1.SetError(cmbVisitorAreaVisited, "Select the area tp be visited");
                ErrorFlag = true;
            }
            else
            {
                errorProvider1.SetError(cmbVisitorAreaVisited, string.Empty);
            }
            if (string.IsNullOrEmpty(cmbvisitorDeptManager.Text))
            {
                errorProvider1.SetError(cmbvisitorDeptManager, "Select the Department Manager");
                ErrorFlag = true;
            }
            else
            {
                errorProvider1.SetError(cmbvisitorDeptManager, string.Empty);
            }
            if (string.IsNullOrEmpty(cmbVisitorProductionManager.Text))
            {
                errorProvider1.SetError(cmbVisitorProductionManager, "Select the Production manager");
                ErrorFlag = true;
            }
            else
            {
                errorProvider1.SetError(cmbVisitorProductionManager, string.Empty);
            }
            if (string.IsNullOrEmpty(cmbVisitorSecurityController.Text))
            {
                errorProvider1.SetError(cmbVisitorSecurityController, "Select the Security controller");
                ErrorFlag = true;
            }
            else
            {
                errorProvider1.SetError(cmbVisitorSecurityController, string.Empty);
            }
            return ErrorFlag;
        }
        private void btnVisitorDocument_Click(object sender, EventArgs e)
        {
            if (!ErrorValidation())
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Save the data and Clear fiels ?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //Insert record to DB
                        try
                        {
                            ConcatenatedDataBinding concatenatedDataBinding = new ConcatenatedDataBinding();
                            VisitorDataModel visitorDataModel = VisitorDataModel.Instance;
                            visitorDataModel.Name = _scannedData.Name;
                            visitorDataModel.Expiry = _scannedData.Expiry;
                            visitorDataModel.DateOfBirth = _scannedData.DateOfBirth;
                            visitorDataModel.IDno = _scannedData.IdNumber;
                            visitorDataModel.Nationality = _scannedData.Nationality;
                            visitorDataModel.isDataFromDb = _scannedData.isDataFromDb;
                            _visitorDataSheet.VisitDuration = CalculateDuration(_visitorDataSheet.VisitDateFrom, _visitorDataSheet.VisitDateTo, _visitorDataSheet.VisitTimeHrFrom,
                                                                                _visitorDataSheet.VisitTimeHrTo, _visitorDataSheet.VisitTimeMinFrom, _visitorDataSheet.VisitTimeMinTo);
                            if (_scannedData.IdType == 2)
                            {
                                visitorDataModel.IsPassport = true;
                            }
                            _scannedFileInfo.VisitorType = "visitor";
                            concatenatedDataBinding.visitorDataSheet = _visitorDataSheet;

                            ConfidentialityAgreementForVisitor CAforVisitor = new ConfidentialityAgreementForVisitor();
                            VisitorsLogBook vlBook = new VisitorsLogBook();
                            HighlySecurityControlAreaLog hsaLog = new HighlySecurityControlAreaLog();
                            concatenatedDataBinding.CAforVisitor = CAforVisitor;
                            concatenatedDataBinding.hsaLog = hsaLog;
                            concatenatedDataBinding.vlBook = vlBook;
                            // concatenatedDataBinding.visitorDataSheet = new VisitorDataSheet();
                            //concatenatedDataBinding.consultantApplicationForm = new ConsultantApplicationForm();
                            concatenatedDataBinding.consultantApplicationForm = ConsultantApplicationForm.Instance;
                            VisitorGeneratedFile = _centralHub.GenerateDocument(visitorDataModel, concatenatedDataBinding);

                            InsertData insertData = new InsertData();
                            insertData.InsertVisitorRecord(_scannedFileInfo, _scannedData, _cameraStatus, _consultantApplicationForm, _visitorDataSheet);
                            if (!string.IsNullOrEmpty(txtVisitorComp.Text))
                            {
                                insertNewCompnayNameToList(txtVisitorComp.Text);
                            }
                            MessageBox.Show("Data Inserted",title,MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error in Data Insert",title,MessageBoxButtons.OK,MessageBoxIcon.Error);
                            Logger.Error($"Error Data Insert {ex.Message}");
                        }
                        _scannedFileInfo = ScannedFileModel.reset();
                        _scannedData = new ScannedData();
                        _visitorDataSheet = VisitorDataSheet.reset();
                        _consultantApplicationForm = ConsultantApplicationForm.reset();
                        _cameraStatus = CameraStatus.reset();
                        Initialize();
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Generating File:", ex.Message);
                }
                //Open Generated PDF File
                try
                {
                    if (!string.IsNullOrEmpty(VisitorGeneratedFile))
                    {
                        System.Diagnostics.Process.Start(VisitorGeneratedFile);
                    }
                    else
                    {
                        MessageBox.Show("File is Not Generated",title,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        Logger.Error("File Not Generated");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Opening PDF",title,MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Logger.Error($"Error in Opening PDF {ex.Message}");
                }
                _formScan.txtname.Clear();
                _formScan.txtid.Clear();
                _formScan.txtdob.Clear();
                _formScan.txtexpiry.Clear();
                _formScan.txtnationality.Clear();
                _formScan.rbid.Checked = true;
                _formScan.rbpass.Checked = false;
            }
        }
        private string CalculateDuration(string FromDate, string Todate, string FromHrTime, string ToHrTime, string FromMinTime, string ToMinTime)
        {
                FromDate = FromDate == null ? DateTime.Now.ToString("dd/MM/yyyy") : FromDate;
                Todate = Todate == null ? DateTime.Now.ToString("dd/MM/yyyy") : Todate;
                var DateDiff = (DateTime.ParseExact(Todate, "dd/mm/yyyy", CultureInfo.InvariantCulture) - DateTime.ParseExact(FromDate, "dd/mm/yyyy", CultureInfo.InvariantCulture)).Days;
                return $"{DateDiff.ToString()} Days & {(int.Parse(ToHrTime) - int.Parse(FromHrTime)).ToString()} : {(int.Parse(ToMinTime) - int.Parse(FromMinTime)).ToString()} Hrs";
         }
        private void cmbVisitTimeFromHr_SelectedValueChanged(object sender, EventArgs e)
        {
                _visitorDataSheet.VisitTimeHrFrom = cmbVisitTimeFromHr.Text;
        }
        private void cmbVisitTimeFromMinutes_SelectedValueChanged(object sender, EventArgs e)
        {
                _visitorDataSheet.VisitTimeMinFrom = cmbVisitTimeFromMinutes.Text;
        }
        private void cmbVisitorVisitTimeToHr_SelectedValueChanged(object sender, EventArgs e)
        {
                _visitorDataSheet.VisitTimeHrTo = cmbVisitorVisitTimeToHr.Text;
        }
        private void cmbVisitorVisitTimeToMinutes_SelectedValueChanged(object sender, EventArgs e)
        {
                _visitorDataSheet.VisitTimeMinTo = cmbVisitorVisitTimeToMinutes.Text;
        }
        private void dtVisitorVisitDuration_ValueChanged(object sender, EventArgs e)
        {
                _visitorDataSheet.VisitDateTo = dtVisitorVisitDuration.Value.Date.ToString("dd/MM/yyyy");
        }
        public void insertNewCompnayNameToList(string compnayName)
        {
           try
           {
                    InsertData insertData = new InsertData();
                    insertData.InsertNewCompanyNames(compnayName);
           }
           catch (Exception ex)
           {
                    Logger.Error($"{ex.Message}", "Error in inserting new company!");
           }
         }
     }
    
}
