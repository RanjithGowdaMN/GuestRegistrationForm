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
        public  ICentralHub _centralHub;
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

            txtCaddrs.TextChanged += TextChanged;
            txtCalias.TextChanged += TextChanged;
            txtCcelphn.TextChanged += TextChanged;
            txtCcity.TextChanged += TextChanged;
            txtCcompname.TextChanged += TextChanged;
            txtCemail.TextChanged += TextChanged;
            txtCemergency.TextChanged += TextChanged;
            txtChomephn.TextChanged += TextChanged;
            txtCpassno.TextChanged += TextChanged;
            txtCpassplace.TextChanged += TextChanged;
            txtCssno.TextChanged += TextChanged;
            txtCtitle.TextChanged += TextChanged;
            txtCzip.TextChanged += TextChanged;
            rtxtCpreres.TextChanged += TextChanged;
            
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
            if (tb.Name == txtCcompname.Name)
            {
                _consultantApplicationForm.CompanyName = txtCcompname.Text;
            }
        }
    }
}
