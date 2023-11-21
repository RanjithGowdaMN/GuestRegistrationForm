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
    public partial class FormDoc : Form
    {
        public  ICentralHub _centralHub;
        private ScannedFileModel _scannedFileInfo;
        private ScannedData _scannedData;
        private CameraStatus _cameraStatus;
        private ConsultantApplicationForm _consultantApplicationForm;
        private VisitorDataSheet _visitorDataSheet;
        public FormDoc(ICentralHub centralHub, ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
                            ConsultantApplicationForm consultantApplicationForm, VisitorDataSheet visitorDataSheet)
        {
            _centralHub = centralHub;
            InitializeComponent();

            _scannedFileInfo = scannedFileInfo;
            _scannedData = scannedData;
            _cameraStatus = cameraStatus;
            _consultantApplicationForm = consultantApplicationForm;
            _visitorDataSheet = visitorDataSheet;
        }

        public void testMethod() {
            
        }

        private void GenerateContractDoc_Click(object sender, EventArgs e)
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

        private void GenerateVisitorDoc_Click(object sender, EventArgs e)
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
            _centralHub.GenerateDocument(visitorDataModel, concatenatedDataBinding);
        }
    }
}
//public string GenerateVisitorDocument(
//GuestDataModel guestDataModel,
//gScannedFileModel gScannedFileModel,
//gConcatenatedDataBinding gConcatenatedDataBinding,
//string inputFilePath,
//string outputFilePath,
//string imagePath)

//public string GenerateContractDocument(
//GuestDataModel guestDataModel,
//gScannedFileModel gScannedFileModel,
//gConcatenatedDataBinding gConcatenatedDataBinding,
//string inputFilePath,
//string outputFilePath,
//string imagePath)