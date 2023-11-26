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
    public partial class FormVisitor : Form
    {
        public ICentralHub _centralHub;
        private ScannedFileModel _scannedFileInfo;
        private ScannedData _scannedData;
        private CameraStatus _cameraStatus;
        private ConsultantApplicationForm _consultantApplicationForm;
        private VisitorDataSheet _visitorDataSheet;
        //private IAPIconnector _apiHelper;
        public FormVisitor(ICentralHub centralHub, ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
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

            txtVisitorTitle.TextChanged += TextChanged;
            txtVisitorComp.TextChanged += TextChanged;
            txtVisitorSecutityController.TextChanged += TextChanged;

            txtVisitorTitle.Text = _visitorDataSheet.Title;
            txtVisitorComp.Text = _visitorDataSheet.Company;
            txtVisitorSecutityController.Text = _visitorDataSheet.SecurityController;
            dtVisitorVisitDate.Text = _visitorDataSheet.VisitDateTime;
            _visitorDataSheet.VisitDuration = dtVisitorDuration.Text;

            LoadComboxBoxData();
        }

     

        private void CmbVisitorComp_SelectedIndexChanged(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
           if(cmbVisitorComp.SelectedItem.ToString()=="other")
            {
                txtVisitorComp.Visible = true;

            }
            else
            {
                txtVisitorComp.Visible = false;

            }
        }

        public void LoadComboxBoxData()
        {
            RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
            cmbVisitorComp.DataSource = retriveDBinfo.GetCompanyname().Select(x => x.CompanyNames).ToList();
            cmbVistorReasonForVisit.DataSource = retriveDBinfo.GetVisitorVisitPurpose().Select(x => x.Purpose).ToList();
            cmbVisitorProductionManager.DataSource = retriveDBinfo.GetProductionManagers().Select(x => x.ProductionManager).ToList();
            cmbVisitorAreaVisited.DataSource = retriveDBinfo.GetAreatobeVisited().Select(x => x.Area).ToList();
            cmbvisitorDeptManager.DataSource = retriveDBinfo.GetDepartmentManager().Select(x => x.Managers).ToList();
            cmbVisitorPersonToVisited.DataSource = retriveDBinfo.GetPersontobeVisited().Select(x => x.EmployeeNames).ToList();
        }
        private void TextChanged(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Name == txtVisitorTitle.Name)
            {
                _visitorDataSheet.Title = txtVisitorTitle.Text;
            }
            if (tb.Name == txtVisitorComp.Name)
            {
                _visitorDataSheet.Company = txtVisitorComp.Text;

            }
            if (tb.Name == txtVisitorSecutityController.Name)
            {
                _visitorDataSheet.SecurityController = txtVisitorSecutityController.Text;
            }
            if (tb.Name == dtVisitorVisitDate.Name)
            {
                _visitorDataSheet.VisitDateTime = dtVisitorVisitDate.Text.ToString();

            }
            if (tb.Name == dtVisitorDuration.Name)
            {
                _visitorDataSheet.VisitDuration = dtVisitorDuration.Text.ToString();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormVisitor_Load(object sender, EventArgs e)
        {
            txtVisitorComp.Visible = false;
            cmbVisitorComp.SelectedIndexChanged += CmbVisitorComp_SelectedIndexChanged;
        }
    }
}
