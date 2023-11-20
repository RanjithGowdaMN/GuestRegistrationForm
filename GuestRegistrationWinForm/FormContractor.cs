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
            rtxtContractorPreResidence.TextChanged += TextChanged;

        }

        private void Contractor_Load(object sender, EventArgs e)
        {

        }

        private void panelcontrator_Paint(object sender, PaintEventArgs e)
        {

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
            if (tb.Name == rtxtContractorPreResidence.Name)
            {
                _consultantApplicationForm.PResidence = rtxtContractorPreResidence.Text;

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