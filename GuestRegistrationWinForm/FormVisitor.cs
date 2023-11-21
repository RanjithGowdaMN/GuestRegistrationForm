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
        public  ICentralHub _centralHub;
        private ScannedFileModel _scannedFileInfo;
        private ScannedData _scannedData;
        private CameraStatus _cameraStatus;
        private ConsultantApplicationForm _consultantApplicationForm;
        private VisitorDataSheet _visitorDataSheet;
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

        }
    }
}
