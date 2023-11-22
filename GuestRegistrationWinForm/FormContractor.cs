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
        private IAPIconnector _apiHelper;
        public FormContractor(ICentralHub centralHub, ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
                            ConsultantApplicationForm consultantApplicationForm, VisitorDataSheet visitorDataSheet, IAPIconnector apiHelper)
        {
            _centralHub = centralHub;
            InitializeComponent();

            _scannedFileInfo = scannedFileInfo;
            _cameraStatus = cameraStatus;
            _consultantApplicationForm = consultantApplicationForm;
            _visitorDataSheet = visitorDataSheet;
            _scannedData = scannedData;
            _apiHelper = apiHelper;
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
            rtxtContractorPreResidence.TextChanged += RichTextChanged;

        }

        private void Contractor_Load(object sender, EventArgs e)
        {
            getCompanyName();
        }

        private async Task getCompanyName()
        {
            await _apiHelper.GetRegistredCompanyNames();
        }

        private void panelcontrator_Paint(object sender, PaintEventArgs e)
        {

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
            if(tb.Name ==dtContractorPassportValid.Name)
            {
                _consultantApplicationForm.PassportValidity = dtContractorPassportValid.Text.ToString();
            }
        }
    }
}