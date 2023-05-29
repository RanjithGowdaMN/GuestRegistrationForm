//****************************************************************************
//
//   Scanner Control SDK Test Program
//
//   Copyright PFU Limited 2012-2014
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
	/// Summary description for FormResultOfDetect.
	/// </summary>
	public class FormResultOfDetect : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button ButtonClose;
        public ArrayList resultArray;
        private System.Windows.Forms.ListView resultListView;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormResultOfDetect()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			InitializeListView();
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
            this.ButtonClose = new System.Windows.Forms.Button();
            this.resultListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(327, 160);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonClose.TabIndex = 1;
            this.ButtonClose.Text = "Close";
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // resultListView
            // 
            this.resultListView.Location = new System.Drawing.Point(12, 16);
            this.resultListView.Name = "resultListView";
            this.resultListView.Size = new System.Drawing.Size(704, 128);
            this.resultListView.TabIndex = 0;
            this.resultListView.UseCompatibleStateImageBehavior = false;
            // 
            // FormResultOfDetect
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(728, 198);
            this.Controls.Add(this.resultListView);
            this.Controls.Add(this.ButtonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormResultOfDetect";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Result of Detect";
            this.ResumeLayout(false);

        }
		#endregion

        // Initialization of a list
        private void InitializeListView()
        {
            resultListView.Clear();
            resultListView.FullRowSelect = true;
            resultListView.GridLines = false;
            resultListView.Sorting = SortOrder.None;
            resultListView.View = View.Details;

            resultListView.Columns.Add("Page", 45, HorizontalAlignment.Right);
            resultListView.Columns.Add("BarcodeCount/Total", 120, HorizontalAlignment.Right);
            resultListView.Columns.Add("BarcodeType", 80, HorizontalAlignment.Left);
            resultListView.Columns.Add("BarcodeTextLength", 120, HorizontalAlignment.Right);
            resultListView.Columns.Add("BarcodeText", 145, HorizontalAlignment.Left);
            resultListView.Columns.Add("BarcodeX", 65, HorizontalAlignment.Right);
            resultListView.Columns.Add("BarcodeY", 65, HorizontalAlignment.Right);
            resultListView.Columns.Add("BarcodeRotation", 100, HorizontalAlignment.Right);
            resultListView.Columns.Add("Patch", 70, HorizontalAlignment.Left);
            resultListView.Columns.Add("AIQC", 80, HorizontalAlignment.Left);
            resultListView.Columns.Add("BlankPage", 100, HorizontalAlignment.Left);
            resultListView.Columns.Add("MultiFeed", 100, HorizontalAlignment.Left);
        }

        // Insert items in list
        public void InsertResultOfDetect()
        {
            for (int i = 0; i < resultArray.Count; i++) 
            {
                string[] results = (string[])resultArray[i];
                resultListView.Items.Add(new ListViewItem(results));
            }
        }

        private void ButtonClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
	}
}
