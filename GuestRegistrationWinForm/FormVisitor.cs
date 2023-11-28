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

            txtVisitorTitle.Text = _visitorDataSheet.Title;
            txtVisitorComp.Text = _visitorDataSheet.CompanyName;
            txtVisitorSecutityController.Text = _visitorDataSheet.SecurityController;
            dtVisitorVisitDate.Text = _visitorDataSheet.VisitDateTime;
            _visitorDataSheet.VisitDuration = dtVisitorDuration.Text;

            txtVisitorTitle.TextChanged += TextChanged;
            txtVisitorComp.TextChanged += TextChanged;
            txtVisitorSecutityController.TextChanged += TextChanged;

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
                _visitorDataSheet.CompanyName = cmbVisitorComp.SelectedItem.ToString();

            }
        }

        public void LoadComboxBoxData()
        {
            RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
            List<string>CompanyNames=retriveDBinfo.GetCompanyname().Select(x => x.CompanyNames).ToList();
            cmbVisitorComp.DataSource = CompanyNames;

            cmbVistorReasonForVisit.DataSource = retriveDBinfo.GetVisitorVisitPurpose().Select(x => x.Purpose).ToList(); ;
            cmbVistorReasonForVisit.Text = _visitorDataSheet.PurposeOfVisit;

            cmbVisitorProductionManager.DataSource = retriveDBinfo.GetProductionManagers().Select(x => x.ProductionManager).ToList(); ;
            cmbVisitorProductionManager.Text = _visitorDataSheet.ProductionManager;

            cmbVisitorAreaVisited.DataSource = retriveDBinfo.GetAreatobeVisited().Select(x => x.Area).ToList(); ;
            cmbVisitorAreaVisited.Text = _visitorDataSheet.AreaVisited;

            cmbvisitorDeptManager.DataSource = retriveDBinfo.GetDepartmentManager().Select(x => x.Managers).ToList(); ;
            cmbvisitorDeptManager.Text = _visitorDataSheet.DepartmentManager;

            cmbVisitorPersonToVisited.DataSource = retriveDBinfo.GetPersontobeVisited().Select(x => x.EmployeeNames).ToList();
            cmbVisitorPersonToVisited.Text = _visitorDataSheet.PersonToBeVisited;

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

            if(_visitorDataSheet.VisitDateTime!=null)
            {
                dtVisitorVisitDate.Value = DateTime.Parse(_visitorDataSheet.VisitDateTime);
            }
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
                _visitorDataSheet.CompanyName = txtVisitorComp.Text;

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
            cmbVistorReasonForVisit.SelectedIndexChanged += CmbVistorReasonForVisit_SelectedIndexChanged;
        }
        private void CmbVistorReasonForVisit_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  throw new NotImplementedException();
          if(cmbVistorReasonForVisit!=null)
            {
                _visitorDataSheet.PurposeOfVisit = cmbVistorReasonForVisit.SelectedItem.ToString();
            }
        }
        private void CmbVisitorProductionManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbVisitorProductionManager!=null)
            {
                _visitorDataSheet.ProductionManager = cmbVisitorProductionManager.SelectedItem.ToString();
            }
        }
        private void CmbVisitorPersonToVisited_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(cmbVisitorPersonToVisited!=null)
            {
                _visitorDataSheet.PersonToBeVisited = cmbVisitorPersonToVisited.SelectedItem.ToString();

            }
        }
        private void CmbvisitorDeptManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(cmbvisitorDeptManager!=null)
            {
                _visitorDataSheet.DepartmentManager = cmbvisitorDeptManager.SelectedItem.ToString();
            }
        }

        private void CmbVisitorAreaVisited_SelectedIndexChanged(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
           if(cmbVisitorAreaVisited!=null)
            {
                _visitorDataSheet.AreaVisited = cmbVisitorAreaVisited.SelectedItem.ToString();

            }
        }
        private void dtVisitorVisitDate_ValueChanged(object sender, EventArgs e)
        {
            _visitorDataSheet.VisitDuration = dtVisitorVisitDate.Value.ToString();
        }
        private void dtVisitorDuration_ValueChanged(object sender, EventArgs e)
        {
            _visitorDataSheet.VisitDuration = dtVisitorDuration.Value.ToString();
        }
        private void btnVisitorDocument_Click(object sender, EventArgs e)
        {
            ConcatenatedDataBinding concatenatedDataBinding = new ConcatenatedDataBinding();
            VisitorDataModel visitorDataModel = new VisitorDataModel();
            visitorDataModel.Name = _scannedData.Name;
            visitorDataModel.Expiry = _scannedData.Expiry;
            visitorDataModel.DateOfBirth = _scannedData.DateOfBirth;
            visitorDataModel.IDno = _scannedData.IDno;
            visitorDataModel.Nationality = _scannedData.Nationality;

            concatenatedDataBinding.visitorDataSheet = _visitorDataSheet;

            ConsultantApplicationForm consultantApplicationForm = new ConsultantApplicationForm();
            //VisitorDataSheet visitorDataSheet = new VisitorDataSheet();
            ConfidentialityAgreementForVisitor CAforVisitor = new ConfidentialityAgreementForVisitor();
            VisitorsLogBook vlBook = new VisitorsLogBook();
            HighlySecurityControlAreaLog hsaLog = new HighlySecurityControlAreaLog();
            concatenatedDataBinding.CAforVisitor = CAforVisitor;
            concatenatedDataBinding.hsaLog = hsaLog;
            concatenatedDataBinding.vlBook = vlBook;
            // concatenatedDataBinding.visitorDataSheet = new VisitorDataSheet();
            concatenatedDataBinding.consultantApplicationForm = new ConsultantApplicationForm();
            _centralHub.GenerateDocument(visitorDataModel, concatenatedDataBinding);

            InsertData insertData = new InsertData();
            insertData.InsertVisitorRecord(_scannedFileInfo, _scannedData, _cameraStatus, _consultantApplicationForm, _visitorDataSheet);
        }
    }
}
