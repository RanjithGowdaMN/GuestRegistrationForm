//****************************************************************************
//
//   Scanner Control SDK Test Program
//
//   Copyright PFU Limited 2009-2022
//
//****************************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace fiScanTest
{
    /// <summary>
    /// Summary description for FormAbout.
    /// </summary>
    public class FormAbout : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonOCXVer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblInformation;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FormAbout()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected 
            void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    try
                    {
                        components.Dispose();
                    }
                    catch (Exception)
                    {

                        components = null;
                    }
                    
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonOCXVer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonOK
            // 
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonOK.Location = new System.Drawing.Point(320, 16);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(88, 24);
            this.ButtonOK.TabIndex = 0;
            this.ButtonOK.Text = "OK";
            // 
            // ButtonOCXVer
            // 
            this.ButtonOCXVer.Location = new System.Drawing.Point(320, 48);
            this.ButtonOCXVer.Name = "ButtonOCXVer";
            this.ButtonOCXVer.Size = new System.Drawing.Size(88, 24);
            this.ButtonOCXVer.TabIndex = 1;
            this.ButtonOCXVer.Text = "OCX Version";
            this.ButtonOCXVer.Click += new System.EventHandler(this.ButtonOCXVer_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fujitsu Scanner Control SDK";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(96, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Visual C# Sample Program";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.Location = new System.Drawing.Point(32, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "fiScanTest";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.Location = new System.Drawing.Point(160, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Version : 2.3";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(360, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Copyright PFU Limited 2009-2022";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInformation
            // 
            this.lblInformation.Location = new System.Drawing.Point(24, 120);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(360, 16);
            this.lblInformation.TabIndex = 7;
            this.lblInformation.Text = "Information :";
            // 
            // FormAbout
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.CancelButton = this.ButtonOK;
            this.ClientSize = new System.Drawing.Size(414, 148);
            this.ControlBox = false;
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonOCXVer);
            this.Controls.Add(this.ButtonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "About";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.ResumeLayout(false);

        }
        #endregion
        
        //----------------------------------------------------------------------------
        //  Function    : The form was loaded
        //  Return code : Nothing
        //----------------------------------------------------------------------------
        private void FormAbout_Load(object sender, System.EventArgs e)
        {
            //An image scanner name and flatbed existence are displayed.
            //'When the scanner is not yet opened, it is displayed as "Not OpenScanner".
            if(ModuleScan.blnOpenScanner == false)
            {
                this.lblInformation.Text = "Information : Not OpenScanner";
                return;
            }
            
            if(FormScan.CurrentInstance.axFiScn1.IsExistsFB == false)
            {
                if(ModuleScan.blnFjtwn == true)
                {
                    this.lblInformation.Text = "Information : " 
                        + FormScan.CurrentInstance.axFiScn1.ImageScanner + " Not Flatbed";
                }
                else
                {
                    this.lblInformation.Text = "Information : " + "  Not TWAIN Driver  " + " : (Not Flatbed)";
                }
            }
            else
            {
                if(ModuleScan.blnFjtwn == true)
                {
                    this.lblInformation.Text = "Information : " + FormScan.CurrentInstance.axFiScn1.ImageScanner + " With Flatbed";
                }
                else
                {
                    this.lblInformation.Text = "Information : " + "  Not TWAIN Driver  " + " : (With Flatbed)";
                }
            }
        }

        //----------------------------------------------------------------------------
        //  Function    : The "OCX Version" button was pushed
        //  Return code : Nothing
        //----------------------------------------------------------------------------
        private void ButtonOCXVer_Click(object sender, System.EventArgs e)
        {
            FormScan.CurrentInstance.axFiScn1.AboutBox();
        }
    }
}
