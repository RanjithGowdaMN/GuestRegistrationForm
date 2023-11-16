using GuestRegistrationDesktopUI.Library.CentralHub;
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
    

    public partial class FormMain : Form
    {
        private readonly DependencyInjectionContainer _container;
        private Form activeForm;
        public FormMain()
        {
            _container = new DependencyInjectionContainer();
            //_container.Register<ICentralHub>(new CentralHub());
            InitializeComponent();
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
            OpenChildForm(new FormScan(), sender);
        }

        private void btncontractor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormContractor(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormVisitor(), sender);
        }

        private void btndoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDoc(), sender);
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
