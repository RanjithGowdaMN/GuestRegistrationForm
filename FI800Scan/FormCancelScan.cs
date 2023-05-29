//****************************************************************************
//
//   Scanner Control SDK Test Program
//
//   Copyright PFU Limited 2011-2021
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
    /// Summary description for FormCancelScan.
    /// </summary>
    public class FormCancelScan : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button buttonCancelScan;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FormCancelScan()
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
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
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
            this.buttonCancelScan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCancelScan
            // 
            this.buttonCancelScan.Location = new System.Drawing.Point(49, 32);
            this.buttonCancelScan.Name = "buttonCancelScan";
            this.buttonCancelScan.TabIndex = 0;
            this.buttonCancelScan.Text = "CancelScan";
            this.buttonCancelScan.Click += new System.EventHandler(this.buttonCancelScan_Click);
            // 
            // FormCancelScan
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(172, 86);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancelScan);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCancelScan";
            this.Text = "CancelScan";
            this.ResumeLayout(false);

        }
        #endregion

        //----------------------------------------------------------------------------
        //   Function    : CancelScan button processing
        //   Argument    : Nothing
        //   Return code : Nothing
        //----------------------------------------------------------------------------
        private void buttonCancelScan_Click(object sender, System.EventArgs e)
        {
            ModuleScan.bCancelScan = true;
        }
    }
}
