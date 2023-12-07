using GuestRegistrationDesktopUI.Library.Api;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDesktopUI.Library.Models;
using GuestRegistrationDeskUI.Models;
using GuestRegistrationWinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        //private IAPIconnector _apiHelper;
        public FormDoc(ICentralHub centralHub, ScannedFileModel scannedFileInfo, ScannedData scannedData, CameraStatus cameraStatus,
                            ConsultantApplicationForm consultantApplicationForm, VisitorDataSheet visitorDataSheet)
        {
            _centralHub = centralHub;
            InitializeComponent();

            _scannedFileInfo = ScannedFileModel.Instance;
            _scannedData = scannedData;
            _cameraStatus = CameraStatus.Instance;
            _consultantApplicationForm = ConsultantApplicationForm.Instance;
            _visitorDataSheet = VisitorDataSheet.Instance;
            //_apiHelper = apiHelper;
        }

        public void testMethod() {
            
        }

        private void GenerateContractDoc_Click(object sender, EventArgs e)
        {
            /* ConcatenatedDataBinding concatenatedDataBinding = new ConcatenatedDataBinding();
             VisitorDataModel visitorDataModel = new VisitorDataModel();
             visitorDataModel.Name = _scannedData.Name;
             visitorDataModel.Expiry = _scannedData.Expiry;
             visitorDataModel.DateOfBirth = _scannedData.DateOfBirth;
             visitorDataModel.IDno = _scannedData.IdNumber;
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
             _centralHub.GenerateContractDocument(visitorDataModel, concatenatedDataBinding);*/
           
            try
            {
                // Replace the file path with the path to your form

                
                string filePath = @"D:\VisitorData\GeneratedDocument\\"; // Example path to a form file

                // Open the form using the default associated application
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void GenerateVisitorDoc_Click(object sender, EventArgs e)
        {

            try
            {
                // Replace the file path with the path to your form
                string filePath = @"D:\VisitorData\GeneratedDocument\\"; // Example path to a form file

                // Open the form using the default associated application
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            /* ConcatenatedDataBinding concatenatedDataBinding = new ConcatenatedDataBinding();
             VisitorDataModel visitorDataModel = new VisitorDataModel();
             visitorDataModel.Name = _scannedData.Name;
             visitorDataModel.Expiry = _scannedData.Expiry;
             visitorDataModel.DateOfBirth = _scannedData.DateOfBirth;
             visitorDataModel.IDno = _scannedData.IdNumber;
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
             _centralHub.GenerateDocument(visitorDataModel, concatenatedDataBinding);*/

        }

        private void panelDoc_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}