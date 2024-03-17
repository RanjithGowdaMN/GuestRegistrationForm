using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuestRegistrationWinForm
{
    public partial class FormProgressBar : Form
    {
        public FormProgressBar()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        public void UpdateProgressBar(int progress)
        {
            progressBar1.Value = progress;
        }
    }
}
