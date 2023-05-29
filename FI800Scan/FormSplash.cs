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
    /// Summary description for FormSplash.
    /// </summary>
    public class FormSplash : System.Windows.Forms.Form
    {
        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.Label lblProductName1;
        private System.Windows.Forms.Label lblProductName2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCopyright;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FormSplash()
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
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblProductName2 = new System.Windows.Forms.Label();
            this.lblProductName1 = new System.Windows.Forms.Label();
            this.GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox
            // 
            this.GroupBox.Controls.Add(this.lblCopyright);
            this.GroupBox.Controls.Add(this.lblVersion);
            this.GroupBox.Controls.Add(this.lblTitle);
            this.GroupBox.Controls.Add(this.lblProductName2);
            this.GroupBox.Controls.Add(this.lblProductName1);
            this.GroupBox.Location = new System.Drawing.Point(8, 8);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(368, 136);
            this.GroupBox.TabIndex = 5;
            this.GroupBox.TabStop = false;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Location = new System.Drawing.Point(32, 104);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(304, 16);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Text = "Copyright PFU Limited 2009-2022";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblVersion.Location = new System.Drawing.Point(184, 80);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(112, 16);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version: 2.3";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblTitle.Location = new System.Drawing.Point(72, 80);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(88, 16);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "fiScanTest";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductName2
            // 
            this.lblProductName2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblProductName2.Location = new System.Drawing.Point(16, 48);
            this.lblProductName2.Name = "lblProductName2";
            this.lblProductName2.Size = new System.Drawing.Size(336, 24);
            this.lblProductName2.TabIndex = 1;
            this.lblProductName2.Text = "Visual C# Sample Program";
            this.lblProductName2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductName1
            // 
            this.lblProductName1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblProductName1.Location = new System.Drawing.Point(16, 24);
            this.lblProductName1.Name = "lblProductName1";
            this.lblProductName1.Size = new System.Drawing.Size(336, 24);
            this.lblProductName1.TabIndex = 0;
            this.lblProductName1.Text = "Fujitsu Scanner Control SDK";
            this.lblProductName1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormSplash
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(384, 160);
            this.Controls.Add(this.GroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.GroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
    }
}
