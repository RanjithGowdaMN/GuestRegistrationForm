using GuestDataManager.Library.DataAccess;
using GuestRegistrationDesktopUI.Library.Api;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDesktopUI.Library.Models;
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
        //private IAPIconnector _apiHelper;
        public FormContractor(ICentralHub centralHub, ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
                            ConsultantApplicationForm consultantApplicationForm, VisitorDataSheet visitorDataSheet)
        {
            _centralHub = centralHub;
            InitializeComponent();

            _scannedFileInfo = scannedFileInfo;
            _cameraStatus = cameraStatus;
            _consultantApplicationForm = consultantApplicationForm;
            _visitorDataSheet = visitorDataSheet;
            _scannedData = scannedData;
            //_apiHelper = apiHelper;
            txtContractorCompName.Text = _consultantApplicationForm.CompanyName;
            txtContractorAddress.Text = _consultantApplicationForm.Address;
            txtContractorAliasName.Text = _consultantApplicationForm.Alias;
            txtContractorCellPhn.Text = _consultantApplicationForm.CellPhone;
            txtContractorCity.Text = _consultantApplicationForm.City;
            txtContractorEmail.Text = _consultantApplicationForm.Email;
            txtContractorEmergencyNo.Text = _consultantApplicationForm.EmergencyContactNo;
            txtContractorHomePhn.Text = _consultantApplicationForm.Homephone;
            txtContractorPassportNo.Text = _consultantApplicationForm.PassportNo;
            txtContractorPassportPlaceOfIssue.Text = _consultantApplicationForm.PlaceofIssue;
            txtContractorSecurityNo.Text = _consultantApplicationForm.SecurityNo;
            txtContractorZip.Text = _consultantApplicationForm.Zip;
            txtContratorTitle.Text = _consultantApplicationForm.Title;
            rtxtContractorPreResidence.Text = _consultantApplicationForm.PResidence;
            txtContractorState.Text = _consultantApplicationForm.State;
            //dtContractorDuration.Text.ToString() = _consultantApplicationForm.Duration;
            //dtContractorPassportDateOfIssue.Text.ToString() = _consultantApplicationForm.PDateofIssue;
            //dtContractorPassportValid.Text.ToString() = _consultantApplicationForm.PassportValidity;

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

            LoadComboxBoxData();


        }

        private void Contractor_Load(object sender, EventArgs e)
        {
            getCompanyName();
            getPurpose();
            txtContractorCompName.Visible = false;
            cmbContractorCompName.SelectedIndexChanged += CmbContractorCompName_SelectedIndexChanged;
            cmbContractorPurposeOfVisit.SelectedIndexChanged += CmbContractorPurposeOfVisit_SelectedIndexChanged;
        }

       private void CmbContractorPurposeOfVisit_SelectedIndexChanged(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
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





            //load passport validity previous value
            if (_consultantApplicationForm.PassportValidity != null)
            {
                dtContractorPassportValid.Value = DateTime.Parse(_consultantApplicationForm.PassportValidity);
            }
            if (_consultantApplicationForm.PDateofIssue != null)
            {
                dtContractorPassportDateOfIssue.Value = DateTime.Parse(_consultantApplicationForm.PDateofIssue);
            }
            if (_consultantApplicationForm.Duration != null)
            {
                dtContractorDuration.Value = DateTime.Parse(_consultantApplicationForm.Duration);
            }
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

        private async Task getPurpose()
        {

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
                _consultantApplicationForm.PResidence = rtxtContractorPreResidence.Text;
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
                _consultantApplicationForm.Homephone = txtContractorHomePhn.Text;

            }
            if (tb.Name == txtContractorPassportNo.Name)
            {
                _consultantApplicationForm.PassportNo = txtContractorPassportNo.Text;
            }
            if (tb.Name == txtContractorPassportPlaceOfIssue.Name)
            {
                _consultantApplicationForm.PlaceofIssue = txtContractorPassportPlaceOfIssue.Text;
            }
            if (tb.Name == txtContractorSecurityNo.Name)
            {
                _consultantApplicationForm.SecurityNo = txtContractorSecurityNo.Text;
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
                _consultantApplicationForm.PDateofIssue = dtContractorPassportDateOfIssue.Text.ToString();

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
            _consultantApplicationForm.PassportValidity = dtContractorPassportValid.Value.ToString();
        }

        private void dtContractorPassportDateOfIssue_ValueChanged(object sender, EventArgs e)
        {
            _consultantApplicationForm.PDateofIssue = dtContractorPassportDateOfIssue.Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void dtContractorDuration_ValueChanged(object sender, EventArgs e)
        {
            _consultantApplicationForm.Duration = dtContractorDuration.Value.ToString();
        }

        private void btContractorPdf_Click(object sender, EventArgs e)
        {
            ConcatenatedDataBinding concatenatedDataBinding = new ConcatenatedDataBinding();
            VisitorDataModel visitorDataModel = new VisitorDataModel();
            visitorDataModel.Name = _scannedData.Name;
            visitorDataModel.Expiry = _scannedData.Expiry;
            visitorDataModel.DateOfBirth = _scannedData.DateOfBirth;
            visitorDataModel.IDno = _scannedData.IDno;
            visitorDataModel.Nationality = _scannedData.Nationality;

            concatenatedDataBinding.consultantApplicationForm = _consultantApplicationForm;

            VisitorDataSheet visitorDataSheet = new VisitorDataSheet();
            ConfidentialityAgreementForVisitor CAforVisitor = new ConfidentialityAgreementForVisitor();
            VisitorsLogBook vlBook = new VisitorsLogBook();
            HighlySecurityControlAreaLog hsaLog = new HighlySecurityControlAreaLog();
            concatenatedDataBinding.CAforVisitor = CAforVisitor;
            concatenatedDataBinding.hsaLog = hsaLog;
            concatenatedDataBinding.vlBook = vlBook;
            concatenatedDataBinding.visitorDataSheet = new VisitorDataSheet();
            _centralHub.GenerateContractDocument(visitorDataModel, concatenatedDataBinding);
        }

        private void txtContractorCompName_TextChanged(object sender, EventArgs e)
        {
            _consultantApplicationForm.CompanyName = txtContractorCompName.Text;
        }
       
       
      
    }
    }
