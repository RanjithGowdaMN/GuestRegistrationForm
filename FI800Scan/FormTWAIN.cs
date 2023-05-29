using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace fiScanTest
{
    /// <summary>
    /// Summary description for FormTWAIN.
    /// </summary>
    public class FormTWAIN : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstTemplate;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FormTWAIN()
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
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstTemplate = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(288, 16);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(72, 24);
            this.ButtonOK.TabIndex = 0;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(288, 48);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(72, 24);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "Cancel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTemplate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 168);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Template List:";
            // 
            // lstTemplate
            // 
            this.lstTemplate.ItemHeight = 12;
            this.lstTemplate.Location = new System.Drawing.Point(16, 40);
            this.lstTemplate.Name = "lstTemplate";
            this.lstTemplate.Size = new System.Drawing.Size(224, 112);
            this.lstTemplate.TabIndex = 1;
            // 
            // FormTWAIN
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(368, 190);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTWAIN";
            this.Text = "TWAIN Template";
            this.Load += new System.EventHandler(this.FormTWAIN_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.Closed += new System.EventHandler(this.FormTWAIN_Closed);

        }
        #endregion

        //----------------------------------------------------------------------------
        //   Function    : The form was loaded
        //   Return code : Nothing
        //----------------------------------------------------------------------------
        private void FormTWAIN_Load(object sender, System.EventArgs e)
        {
            int count;
            int Index = 0;
            int IndexCount = 0;
            string strName;

            //1) When a template exists
            //    A template list is created.
            //    The current template is chosen.
            //2) When a template does not exist
            //    The OK button and tempalte list are disabled.
            count = FormScan.CurrentInstance.axFiScn1.GetTWAINTemplateCount();
            if( count < 1 )
            {
                this.ButtonOK.Enabled = false;
                this.lstTemplate.Enabled = false;
                return;
            }
            while (IndexCount < count)
            {
                strName = FormScan.CurrentInstance.axFiScn1.GetTWAINTemplateName(Index);
                if (!strName.Equals(""))
                {
                    Array.Resize(ref ModuleScan.intProfileNum, IndexCount + 1);
                    ModuleScan.intProfileNum[IndexCount] = Index;
                    this.lstTemplate.Items.Add((strName));
                    IndexCount++;
                }
                Index++;
            }

            Index = FormScan.CurrentInstance.axFiScn1.GetTWAINTemplateSelect();
            this.lstTemplate.SelectedIndex = Index;
        }

        //----------------------------------------------------------------------------
        //    Function    : The "OK" button was pushed
        //    Return code : Nothing
        //----------------------------------------------------------------------------
        private void ButtonOK_Click(object sender, System.EventArgs e)
        {
            int result;
            int Index;

            FormScan.CurrentInstance.axFiScn1.SourceCurrentScan = FormScan.CurrentInstance.MenuItemSourceCurrentScan.Checked;
            //The selected template is set up

            Index = ModuleScan.intProfileNum[this.lstTemplate.SelectedIndex];
            result = FormScan.CurrentInstance.axFiScn1.SetTWAINTemplateSelect(Index);
            if (result == -1) {
                MessageBox.Show("Failed to set the selected template.", "fiScanTest");
            }
            else {
                this.Close();
            }
        }

        //----------------------------------------------------------------------------
        //  Function    : The form was closed
        //  Return code : Nothing
        //----------------------------------------------------------------------------
        private void FormTWAIN_Closed(object sender, System.EventArgs e)
        {
        }

    }
}
