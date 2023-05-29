using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace fiScanTest
{
	/// <summary>
	/// Summary description for FormFeederLoaded.
	/// </summary>
	public class FormFeederLoaded : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button ButtonScan;
        private System.Windows.Forms.Label txtFeeder;
        private System.Windows.Forms.Timer timerCheckADF;
        private System.ComponentModel.IContainer components;

		public FormFeederLoaded()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
            this.components = new System.ComponentModel.Container();
            this.ButtonScan = new System.Windows.Forms.Button();
            this.txtFeeder = new System.Windows.Forms.Label();
            this.timerCheckADF = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ButtonScan
            // 
            this.ButtonScan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonScan.Location = new System.Drawing.Point(83, 72);
            this.ButtonScan.Name = "ButtonScan";
            this.ButtonScan.TabIndex = 0;
            this.ButtonScan.Text = "Scan";
            // 
            // txtFeeder
            // 
            this.txtFeeder.Location = new System.Drawing.Point(24, 16);
            this.txtFeeder.Name = "txtFeeder";
            this.txtFeeder.Size = new System.Drawing.Size(200, 48);
            this.txtFeeder.TabIndex = 1;
            this.txtFeeder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerCheckADF
            // 
            this.timerCheckADF.Tick += new System.EventHandler(this.timerCheckADF_Tick);
            // 
            // FormFeederLoaded
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(240, 110);
            this.Controls.Add(this.txtFeeder);
            this.Controls.Add(this.ButtonScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFeederLoaded";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CheckADF";
            this.Load += new System.EventHandler(this.FormFeederLoaded_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void FormFeederLoaded_Load(object sender, System.EventArgs e)
        {
            this.txtFeeder.Text = "Checking the status of the ADF...";
            this.ButtonScan.Enabled = false;
            timerCheckADF.Interval = 500;
            timerCheckADF.Enabled = true;
        }

        // Timer of ADF check
        private void timerCheckADF_Tick(object sender, System.EventArgs e)
        {
            int errorCode = 0;
            timerCheckADF.Enabled = false;

            if (FormScan.CurrentInstance.axFiScn1.FeederLoaded(this.Handle.ToInt32()))
            {
                this.txtFeeder.Text = "A document has been loaded.";
                this.ButtonScan.Enabled = true;
                return;
            }
            else
            {
                errorCode = FormScan.CurrentInstance.axFiScn1.ErrorCode;
                if(errorCode == 0x00000027)
                {
                    this.txtFeeder.Text = "Checking the status of the ADF...";
                    this.ButtonScan.Enabled = false;
                    timerCheckADF.Enabled = true;
                }
                else 
                {
                    MessageBox.Show("The scanner is unavailable, or an error ocurred.\n\terror code : " + FormScan.CurrentInstance.HexString(errorCode) + "\n\tCheckADF is ended.", "fiScanTest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    this.Dispose();
                    this.DialogResult = System.Windows.Forms.DialogResult.No;
                }
            }        
        }
	}
}
