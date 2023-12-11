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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static gui.FormScan;

namespace gui
{
    public partial class FormContractor : Form
    {
        public ICentralHub _centralHub;
        private ScannedFileModel _scannedFileInfo;
        private ScannedData _scannedData;
        private CameraStatus _cameraStatus;
        private ConsultantApplicationForm _consultantApplicationForm;
        private VisitorDataSheet _visitorDataSheet;
        string ContractorGeneratedFile = string.Empty;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        //private IAPIconnector _apiHelper;
        private FormScan _formScan;
        public FormContractor(ICentralHub centralHub, ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
                            ConsultantApplicationForm consultantApplicationForm, VisitorDataSheet visitorDataSheet, FormScan formScan)
        {
            _centralHub = centralHub;
            InitializeComponent();

            _scannedFileInfo = ScannedFileModel.Instance;
            _cameraStatus = CameraStatus.Instance;
            _consultantApplicationForm = ConsultantApplicationForm.Instance;
            _visitorDataSheet = VisitorDataSheet.Instance;

            _scannedData = scannedData;
            _formScan = formScan;
            //_apiHelper = apiHelper;
            Initialize();
            txtContractorAddress.TextChanged += TextChanged;
            txtContractorAliasName.TextChanged += TextChanged;
            txtContractorCellPhn.TextChanged += TextChanged;
            txtContractorCity.TextChanged += TextChanged;
            txtContractorCompName.TextChanged += TextChanged;
            txtContractorEmail.TextChanged += TextChanged;
            txtContractorEmergencyNo.TextChanged += TextChanged;
            txtContractorHomePhn.TextChanged += TextChanged;
            txtContractorPassportNo.TextChanged += TextChanged;
            txtContractorPassportPlaceOfIssue.TextChanged += TextChanged;
            txtContractorSecurityNo.TextChanged += TextChanged;
            txtContratorTitle.TextChanged += TextChanged;
            txtContractorZip.TextChanged += TextChanged;
            txtContractorState.TextChanged += TextChanged;
            rtxtContractorPreResidence.TextChanged += RichTextChanged;
        }

        private void Initialize()
        {
            txtContractorCompName.Text = _consultantApplicationForm.CompanyName;
            txtContractorAddress.Text = _consultantApplicationForm.Address;
            txtContractorAliasName.Text = _consultantApplicationForm.Alias;
            txtContractorCellPhn.Text = _consultantApplicationForm.CellPhone;
            txtContractorCity.Text = _consultantApplicationForm.City;
            txtContractorEmail.Text = _consultantApplicationForm.Email;
            txtContractorEmergencyNo.Text = _consultantApplicationForm.EmergencyContactNo;
            txtContractorHomePhn.Text = _consultantApplicationForm.HomePhoneNo;
            txtContractorPassportNo.Text = _consultantApplicationForm.PassportNumber;
            txtContractorPassportPlaceOfIssue.Text = _consultantApplicationForm.PlaceofIssue;
            txtContractorSecurityNo.Text = _consultantApplicationForm.SocialSecurityNumber;
            txtContractorZip.Text = _consultantApplicationForm.Zip;
            txtContratorTitle.Text = _consultantApplicationForm.Title;
            rtxtContractorPreResidence.Text = _consultantApplicationForm.Previous7YrResidency;
            txtContractorState.Text = _consultantApplicationForm.State;
            //dtContractorDuration.Text.ToString() = _consultantApplicationForm.Duration;
            //dtContractorPassportDateOfIssue.Text.ToString() = _consultantApplicationForm.PDateofIssue;
            //dtContractorPassportValid.Text.ToString() = _consultantApplicationForm.PassportValidity;

            LoadComboxBoxData();
        }

        private void Contractor_Load(object sender, EventArgs e)
        {
            getCompanyName();
            txtContractorCompName.Visible = false;
            cmbContractorCompName.SelectedIndexChanged += CmbContractorCompName_SelectedIndexChanged;
            cmbContractorPurposeOfVisit.SelectedIndexChanged += CmbContractorPurposeOfVisit_SelectedIndexChanged;
            cmbContractorFelony.SelectedIndexChanged += CmbContractorFelony_SelectedIndexChanged;
        }
        private void CmbContractorFelony_SelectedIndexChanged(object sender, EventArgs e)
        {
          if(cmbContractorFelony!=null)
            {
                _consultantApplicationForm.ConvictedFelony = (cmbContractorFelony.SelectedItem.ToString() == "No" || string.IsNullOrEmpty(cmbContractorFelony.SelectedItem.ToString())) ?false:true;
            }
        }
        private void CmbContractorPurposeOfVisit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbContractorPurposeOfVisit != null)
            {
                _consultantApplicationForm.PurposeOfVisit = cmbContractorPurposeOfVisit.SelectedItem.ToString();
            }
        }
        public void LoadComboxBoxData()
        {
            RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
            List<string> CompanyNames = retriveDBinfo.GetCompanyname().Select(x => x.CompanyNames).ToList();
            cmbContractorCompName.DataSource = CompanyNames;
            
            
            List<string> PurposeOfVisits = retriveDBinfo.GetVisitorVisitPurpose().Select(x => x.Purpose).ToList();
            cmbContractorPurposeOfVisit.DataSource = PurposeOfVisits;
            cmbContractorPurposeOfVisit.Text = _consultantApplicationForm.PurposeOfVisit;

            cmbContractorFelony.Text = _consultantApplicationForm.ConvictedFelony? "Yes":"No";

            if ((!CompanyNames.Contains(_consultantApplicationForm.CompanyName) && (_consultantApplicationForm.CompanyName != null)))
            {
                txtContractorCompName.Visible = true;
                txtContractorCompName.Text = _consultantApplicationForm.CompanyName;
                cmbContractorCompName.Text = "other";
            } else
            {
                cmbContractorCompName.Text = _consultantApplicationForm.CompanyName;
            }
           /* if((PurposeOfVisits.Contains(_consultantApplicationForm.PurposeOfVisit)&&(_consultantApplicationForm.PurposeOfVisit!=null)))
                    {
                cmbContractorPurposeOfVisit.Text = _consultantApplicationForm.PurposeOfVisit;
            }*/
        }
        private async Task getCompanyName()
        {
            //await _apiHelper.GetRegistredCompanyNames();
        }
        private void panelcontrator_Paint(object sender, PaintEventArgs e)
        {
            if (cmbContractorCompName.Text == "other")
            {
                txtContractorCompName.Visible = true;
            }
            else
            {
                txtContractorCompName.Visible = false;
            }
        }
        private void CmbContractorCompName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (cmbContractorCompName.SelectedItem.ToString() == "other")
            {
                txtContractorCompName.Visible = true;
            }
            else
            {
                txtContractorCompName.Visible = false;
                _consultantApplicationForm.CompanyName = cmbContractorCompName.SelectedItem.ToString();
            }
        }
        private void RichTextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;
            if (rtb.Name == rtxtContractorPreResidence.Name)
            {
                _consultantApplicationForm.Previous7YrResidency = rtxtContractorPreResidence.Text;
            }
        }
        private void TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Name == txtContractorCompName.Name)
            {
                _consultantApplicationForm.CompanyName = txtContractorCompName.Text;
            }
            if (tb.Name == txtContractorAddress.Name)
            {
                _consultantApplicationForm.Address = txtContractorAddress.Text;
            }
            if (tb.Name == txtContractorAliasName.Name)
            {
                _consultantApplicationForm.Alias = txtContractorAliasName.Text;
            }
            if (tb.Name == txtContractorCellPhn.Name)
            {
                _consultantApplicationForm.CellPhone = txtContractorCellPhn.Text;
            }
            if (tb.Name == txtContractorCity.Name)
            {
                _consultantApplicationForm.City = txtContractorCity.Text;
            }
            if (tb.Name == txtContractorEmail.Name)
            {
                _consultantApplicationForm.Email = txtContractorEmail.Text;
            }
            if (tb.Name == txtContractorEmergencyNo.Name)
            {
                _consultantApplicationForm.EmergencyContactNo = txtContractorEmergencyNo.Text;
            }
            if (tb.Name == txtContractorHomePhn.Name)
            {
                _consultantApplicationForm.HomePhoneNo = txtContractorHomePhn.Text;

            }
            if (tb.Name == txtContractorPassportNo.Name)
            {
                _consultantApplicationForm.PassportNumber = txtContractorPassportNo.Text;
            }
            if (tb.Name == txtContractorPassportPlaceOfIssue.Name)
            {
                _consultantApplicationForm.PlaceofIssue = txtContractorPassportPlaceOfIssue.Text;
            }
            if (tb.Name == txtContractorSecurityNo.Name)
            {
                _consultantApplicationForm.SocialSecurityNumber = txtContractorSecurityNo.Text;
            }
            if (tb.Name == txtContractorZip.Name)
            {
                _consultantApplicationForm.Zip = txtContractorZip.Text;
            }
            if (tb.Name == txtContratorTitle.Name)
            {
                _consultantApplicationForm.Title = txtContratorTitle.Text;
            }
            if (tb.Name == dtContractorDuration.Name)
            {
                _consultantApplicationForm.Duration = dtContractorDuration.Text.ToString();

            }
            if (tb.Name == dtContractorPassportDateOfIssue.Name)
            {
                _consultantApplicationForm.PassportDateofIssue = dtContractorPassportDateOfIssue.Text.ToString();

            }
            if (tb.Name == dtContractorPassportValid.Name)
            {
                _consultantApplicationForm.PassportValidity = dtContractorPassportValid.Text.ToString();
            }
            if (tb.Name == txtContractorState.Name)
            {
                _consultantApplicationForm.State = txtContractorState.Text;
            }
        }

        private void dtContractorPassportValid_ValueChanged(object sender, EventArgs e)
        {
            _consultantApplicationForm.PassportValidity = dtContractorPassportValid.Value.Date.ToString("dd/MM/yyyy");
        }

        private void dtContractorPassportDateOfIssue_ValueChanged(object sender, EventArgs e)
        {
            _consultantApplicationForm.PassportDateofIssue = dtContractorPassportDateOfIssue.Value.Date.ToString("dd/MM/yyyy");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void dtContractorDuration_ValueChanged(object sender, EventArgs e)
        {
            _consultantApplicationForm.Duration = dtContractorDuration.Value.Date.ToString("dd/MM/yyyy");
        }

        private void btContractorPdf_Click(object sender, EventArgs e)
        {
          
            try
            {
               
                DialogResult dialogResult = MessageBox.Show("Save data to DB and Clear ?", "Clear Data", MessageBoxButtons.YesNo);
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
                        if (_scannedData.IdType == 2)
                        {
                            visitorDataModel.IsPassport = true;
                        }
                        _scannedFileInfo.VisitorType = "contract";
                        concatenatedDataBinding.consultantApplicationForm = _consultantApplicationForm;
                        concatenatedDataBinding.CAforVisitor = new ConfidentialityAgreementForVisitor(); ;
                        concatenatedDataBinding.hsaLog = new HighlySecurityControlAreaLog(); ;
                        concatenatedDataBinding.vlBook = new VisitorsLogBook();
                        concatenatedDataBinding.visitorDataSheet = VisitorDataSheet.Instance;

                        ContractorGeneratedFile = _centralHub.GenerateContractDocument(visitorDataModel, concatenatedDataBinding);
                        InsertData insertData = new InsertData();
                        insertData.InsertVisitorRecord(_scannedFileInfo, _scannedData, _cameraStatus, _consultantApplicationForm, _visitorDataSheet);
                        if (!string.IsNullOrEmpty(txtContractorCompName.Text))
                        {
                            insertNewCompnayNameToList(txtContractorCompName.Text);
                        }
                        MessageBox.Show("Recored Inserted to DB");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: in data insert to database !");
                        Logger.Error(ex.Message, "data insert error!");
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

                MessageBox.Show("Error in Generating File:");
                Logger.Error(ex.Message, "Error in generating Document:");
            }
            //Open Generated PDF File
            try
            {
                if (!string.IsNullOrEmpty(ContractorGeneratedFile))
                {
                    System.Diagnostics.Process.Start(ContractorGeneratedFile);
                }
                else
                {
                    MessageBox.Show("File Not Generated, Please check folder!!");
                    Logger.Error("File Not Generated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: in file generation");
                Logger.Error(ex.Message, "Error in file generation");
            }
            _formScan.txtname.Clear();
            _formScan.txtid.Clear();
            _formScan.txtdob.Clear();
            _formScan.txtexpiry.Clear();
            _formScan.txtnationality.Clear();
            _formScan.rbid.Checked = true;
            _formScan.rbpass.Checked = false;
            _consultantApplicationForm.PassportDateofIssue = DateTime.Now.ToString("dd/MM/yyyy");
            _consultantApplicationForm.PassportValidity = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void txtContractorCompName_TextChanged(object sender, EventArgs e)
        {
            _consultantApplicationForm.CompanyName = txtContractorCompName.Text;
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
