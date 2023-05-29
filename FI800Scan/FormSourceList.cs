using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace fiScanTest
{
    public partial class FormSourceList : Form
    {
        public FormSourceList()
        {
            InitializeComponent();
        }
        //----------------------------------------------------------------------------
        //   Function    : The form was loaded
        //   Return code : Nothing
        //----------------------------------------------------------------------------
        private void FormSourceList_Load(object sender, System.EventArgs e)
        {
            int count;
            int Index;
            string strName;

            count = FormScan.CurrentInstance.axFiScn1.GetSourceCount();
            if (count < 1)
            {
                this.ButtonOK.Enabled = false;
                this.lstSource.Enabled = false;
                return;
            }
            for (Index = 0; Index <= count - 1; Index++)
            {
                strName = FormScan.CurrentInstance.axFiScn1.GetSourceName(Index);
                this.lstSource.Items.Add((strName));
            }
            Index = FormScan.CurrentInstance.axFiScn1.GetSourceSelect();
            this.lstSource.SelectedIndex = Index;
        }

        //----------------------------------------------------------------------------
        //    Function    : The "OK" button was pushed
        //    Return code : Nothing
        //----------------------------------------------------------------------------
        private void ButtonOK_Click(object sender, System.EventArgs e)
        {
            int result;
            result = FormScan.CurrentInstance.axFiScn1.SelectSourceName(lstSource.Text);
            if (result == -1)
            {
                MessageBox.Show("Failed to set the selected source.", "fiScanTest");
            }
            else
            {
                if (ModuleScan.blnOpenScanner == true)
                {
                    FormScan.CurrentInstance.axFiScn1.CloseScanner(this.Handle.ToInt32());
                }
                ModuleScan.blnFjtwn = true;
                ModuleScan.blnOpenScanner = true;
                FormScan.CurrentInstance.OpenScanner();
            }
            this.Close();
        }

        //----------------------------------------------------------------------------
        //  Function    : The form was closed
        //  Return code : Nothing
        //----------------------------------------------------------------------------
        private void FormSourceList_Closed(object sender, System.EventArgs e)
        {
        }

    }
}
