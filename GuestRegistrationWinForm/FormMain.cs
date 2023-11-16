using GenerateDocument.Library;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDesktopUI.Library.Models;
using GuestRegistrationDesktopUI.Library.OCR;
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
using TesseractOCR.Library;

namespace gui
{
    

    public partial class FormMain : Form
    {
        public static DependencyInjectionContainer _container;
        private Form activeForm;

        private CameraStatus cameraStatus;
        private ScannedFileModel scannedFileInfo;

        public ICentralHub centralHub;

        public FormMain()
        {
            _container = new DependencyInjectionContainer();
            _container.Register<ITesseractHelper>(new TesseractLib());
            _container.Register<IOCRhelper>(new OCRhelper(_container.Resolve<ITesseractHelper>()));
            _container.Register<IGenerateWordDocument>(new GenerateWordDocument());
            _container.Register<IGeneratePDFdocument>(new GeneratePDFdocument());
            _container.Register<IGenerateCardPrintDoc>(new GenerateCardPrintDoc());
            _container.Register<ICentralHub>(new CentralHub(_container.Resolve<IOCRhelper>(),
                                            _container.Resolve<IGenerateWordDocument>(),
                                            _container.Resolve<IGeneratePDFdocument>(),
                                            _container.Resolve<IGenerateCardPrintDoc>()));
            
            InitializeComponent();

            cameraStatus = new CameraStatus();
            scannedFileInfo = new ScannedFileModel();

            centralHub = _container.Resolve<ICentralHub>();
            //(var result, string fileName) = centalHub.StartScanning(1);

        }


        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
          
            activeForm = childForm;
          childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelform.Controls.Add(childForm);
            this.panelform.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btnscan_Click(object sender, EventArgs e)
        {

            OpenChildForm(new FormScan(centralHub), sender);

            

        }

        private void btncontractor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormContractor(centralHub), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormVisitor(centralHub), sender);
        }

        private void btndoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDoc(centralHub), sender);
        }

        private void btnlgt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btncard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCard(), sender);
        }
    }
}
