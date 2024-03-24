using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using GenerateDocument.Library;
using GuestDataManager.Library.DataAccess;
using GuestRegistrationDesktopUI.Library;
using GuestRegistrationDesktopUI.Library.Api;
using GuestRegistrationDesktopUI.Library.CentralHub;
using GuestRegistrationDesktopUI.Library.Models;
using GuestRegistrationDesktopUI.Library.OCR;
using GuestRegistrationWinForm;
using NLog;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesseractOCR.Library;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Data.SqlClient;
namespace GuestRegistrationWinForm
{
    public partial class FormContractorHistory : Form
    {

        public string title = "VISMA";
        public ICentralHub _centralHub;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public FormContractorHistory()
        {
            InitializeComponent();
        }

        private void btnSearchConHistory_Click(object sender, EventArgs e)
        {
            RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
            List<VisitorInformation> visitors = null;

            string Type = "contract";
            if (rbAllConHistory.Checked)
            {
                visitors = retriveDBinfo.GetContractorHistoryByAll(Type);
                loadview();
            }

            else if (rbCurrentContractor.Checked)
            {
                visitors = retriveDBinfo.GetCurrentContractor(Type);
                loadview();
            }

            else if (rbCardNumConHistory.Checked)
            {
                visitors = retriveDBinfo.GetContractorByCard(txtCardNumContractHistory.Text);
                loadview();
            }

            else
            {
                MessageBox.Show("Please Select Any Option", title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            // Set DataSource
            dgvContractorHistory.DataSource = visitors;
        }
        public void loadview()
        {
            try
            {
                dgvContractorHistory.AutoGenerateColumns = false;
                dgvContractorHistory.Columns.Clear();
                // Add column for the Name property
                DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
                nameColumn.HeaderText = "Name"; // Set the column header text
                nameColumn.DataPropertyName = "Name"; // Set the data property name
                nameColumn.Width = 200;
                dgvContractorHistory.Columns.Add(nameColumn);

                DataGridViewTextBoxColumn companyCol = new DataGridViewTextBoxColumn();
                companyCol.HeaderText = "Company Name";
                companyCol.DataPropertyName = "CompanyName";
                companyCol.Width = 200;
                dgvContractorHistory.Columns.Add(companyCol);

                DataGridViewTextBoxColumn cardCol = new DataGridViewTextBoxColumn();
                cardCol.HeaderText = "Card Number";
                cardCol.DataPropertyName = "CardNumber";
                cardCol.Width = 200;
                dgvContractorHistory.Columns.Add(cardCol);

                DataGridViewTextBoxColumn joindate = new DataGridViewTextBoxColumn();
                joindate.HeaderText = "Join Date";
                joindate.DataPropertyName = "DurationStart";
                joindate.Width = 200;
                dgvContractorHistory.Columns.Add(joindate);

                DataGridViewTextBoxColumn DurationCol = new DataGridViewTextBoxColumn();
                DurationCol.HeaderText = "Duration End Date";
                DurationCol.DataPropertyName = "DurationEnd";
                DurationCol.Width = 200;
                dgvContractorHistory.Columns.Add(DurationCol);             
            }

            catch (Exception ex)
            {
                MessageBox.Show($"No Previous Visit Information!!", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
