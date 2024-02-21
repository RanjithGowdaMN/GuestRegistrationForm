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
    public partial class FormVisitHistory : Form
    {
        public string title = "VISMA";
        public ICentralHub _centralHub;
      
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public FormVisitHistory()
        {
            InitializeComponent();
        }

        private void btnVisitHistorySearch_Click(object sender, EventArgs e)
        {

             RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
             try
             {

                List<VisitorInformation> visitors = retriveDBinfo.GetHistoryByIdNumber(txtVisitHistoryIdNo.Text);
                // dgvHistory.DataSource = visitors;
                dgvHistory.AutoGenerateColumns = false;

                // Clear existing columns
                dgvHistory.Columns.Clear();

                // Add column for the Name property
                DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
                nameColumn.HeaderText = "Name"; // Set the column header text
                nameColumn.DataPropertyName = "Name"; // Set the data property name
                dgvHistory.Columns.Add(nameColumn);

                DataGridViewTextBoxColumn companyCol = new DataGridViewTextBoxColumn();
                companyCol.HeaderText = "Company Name";
                companyCol.DataPropertyName = "CompanyName";
                dgvHistory.Columns.Add(companyCol);

                DataGridViewTextBoxColumn purposeCol = new DataGridViewTextBoxColumn();
                purposeCol.HeaderText = "Purpose Of Visit";
                purposeCol.DataPropertyName = "PurposeOfVisit";
                dgvHistory.Columns.Add(purposeCol);

                // Set DataSource
                dgvHistory.DataSource = visitors;


            }
             catch (Exception ex)
             {
                 MessageBox.Show($"No Previous Visit Information!!");
             }
          


        }
    }
}
