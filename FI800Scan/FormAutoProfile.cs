//****************************************************************************
//
//   Scanner Control SDK Test Program
//
//   Copyright PFU Limited 2019
//
//****************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace fiScanTest
{
    /// <summary>
    /// Summary description for FormAutoProfile.
    /// </summary>
    public partial class FormAutoProfile : Form
    {
        public FormAutoProfile()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        //   Function    : The form was loaded
        //   Return code : Nothing
        //----------------------------------------------------------------------------
        private void FormAutoProfile_Load(object sender, EventArgs e)
        {
        }

        //----------------------------------------------------------------------------
        //    Function    : The "Close" button was pushed
        //    Return code : Nothing
        //----------------------------------------------------------------------------
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //----------------------------------------------------------------------------
        //  Function    : The form was closed
        //  Return code : Nothing
        //----------------------------------------------------------------------------
        private void FormAutoProfile_Closed(object sender, EventArgs e)
        {
        }

        //----------------------------------------------------------------------------
        //  Function    : The state of a "AutoProfileSensitivity" input value was changed
        //  Return code : Nothing
        //----------------------------------------------------------------------------
        private void txtAutoProfileSensitivity_TextChanged(object sender, EventArgs e)
        {
            int count;

            //An initial value is set to 3
            if (this.txtAutoProfileSensitivity.Text.Length == 0)
            {
                this.txtAutoProfileSensitivity.Text = "3";
            }

            //An input value is checked and an invalid value is stored within effective limits
            if (new Regex(@"^-?\d+$").IsMatch(this.txtAutoProfileSensitivity.Text) == true)
            {
                try
                {
                    count = System.Int32.Parse(this.txtAutoProfileSensitivity.Text);
                }
                catch (System.Exception)
                {
                    count = 3;
                }
            }
            else
            {
                count = 3;
            }

            if (count > 5)
            {
                this.txtAutoProfileSensitivity.Text = "5";
            }
            else if (count < 1)
            {
                this.txtAutoProfileSensitivity.Text = "1";
            }
            else
            {
                this.txtAutoProfileSensitivity.Text = count.ToString();
            }
        }
    }
}
