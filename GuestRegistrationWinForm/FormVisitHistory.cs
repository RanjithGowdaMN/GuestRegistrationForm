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
        public string date1;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public FormVisitHistory()
        {
            InitializeComponent();
        
        }
        /*   private void dtVisitHistoryDate_ValueChanged(object sender, EventArgs e)
           {
               date1 = dtVisitHistoryDate.Value.Date.ToString("dd/MM/yyyy");
           }*/


        private void btnVisitHistorySearch_Click(object sender, EventArgs e)
        {

            RetriveDBinfo retriveDBinfo = new RetriveDBinfo();
            List<VisitorInformation> visitors = null;
            //try
            //{
            string Type = "Visitor";
                /*  if (!string.IsNullOrEmpty(txtVisitHistoryIdNo.Text))
                  {
                      visitors = retriveDBinfo.GetHistoryByIdNumber(txtVisitHistoryIdNo.Text);
                  }
                  else if (!string.IsNullOrEmpty(txtVisitHistoryName.Text))
                  {
                      visitors = retriveDBinfo.GetHistoryByName(txtVisitHistoryName.Text);
                  }*/

                if (rbVisitHistoryId.Checked)
                {

                    visitors = retriveDBinfo.GetHistoryByIdNumber(txtVisitHistoryIdNo.Text);
                   loadview();

                }
                else if (rbVisitHistoryName.Checked)
                {
                    visitors = retriveDBinfo.GetHistoryByName(txtVisitHistoryIdNo.Text);
                loadview();
                }
                else if (rbVisitHistoryDate.Checked)
                {
                    // dtVisitHistoryDate.Visible = true;
                    date1 = dtVisitHistoryDate.Value.Date.ToString("dd/MM/yyyy");
                    visitors = retriveDBinfo.GetHistoryByDate(date1);
                loadview();
                    // visitors = retriveDBinfo.GetHistoryByDate(date1);
                }
                else if (rbAll.Checked)
                {
                    visitors = retriveDBinfo.GetVisitorHistoryByAll(Type);
                loadview();
                }

                else
            {
                MessageBox.Show("Please Select Any Option", title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            //}
            dgvHistory.DataSource = visitors;
        }
        public void loadview()
        {
            try
            {
                dgvHistory.AutoGenerateColumns = false;

                // Clear existing columns
                dgvHistory.Columns.Clear();

                // Add column for the Name property
                DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
                nameColumn.HeaderText = "Name"; // Set the column header text
                nameColumn.DataPropertyName = "Name"; // Set the data property name
                nameColumn.Width = 300;
                dgvHistory.Columns.Add(nameColumn);

                DataGridViewTextBoxColumn companyCol = new DataGridViewTextBoxColumn();
                companyCol.HeaderText = "Company Name";
                companyCol.DataPropertyName = "CompanyName";
                companyCol.Width = 150;
                dgvHistory.Columns.Add(companyCol);

                DataGridViewTextBoxColumn purposeCol = new DataGridViewTextBoxColumn();
                purposeCol.HeaderText = "Purpose Of Visit";
                purposeCol.DataPropertyName = "PurposeOfVisit";
                purposeCol.Width = 150;
                dgvHistory.Columns.Add(purposeCol);

                DataGridViewTextBoxColumn personCol = new DataGridViewTextBoxColumn();
                personCol.HeaderText = "Person To Visited";
                personCol.DataPropertyName = "PersonToBeVisited";
                personCol.Width = 200;
                dgvHistory.Columns.Add(personCol);

                DataGridViewTextBoxColumn dateCol = new DataGridViewTextBoxColumn();
                dateCol.HeaderText = "Visit Date";
                dateCol.DataPropertyName = "VisitDate";
                dateCol.Width = 150;
                dgvHistory.Columns.Add(dateCol);

                // Set DataSource


            }

            catch (Exception ex)
            {
                MessageBox.Show($"No Previous Visit Information!!", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 


    }

      
    
}
