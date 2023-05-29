namespace fiScanTest
{
    partial class FormAutoProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // Required for Windows Form Designer support
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboAutoProfile = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAutoProfileSensitivity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboAutoProfile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAutoProfileSensitivity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 106);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // cboAutoProfile
            // 
            this.cboAutoProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAutoProfile.Items.AddRange(new object[] {
            "Disabled",
            "Enabled"});
            this.cboAutoProfile.Location = new System.Drawing.Point(155, 23);
            this.cboAutoProfile.MaxDropDownItems = 2;
            this.cboAutoProfile.Name = "cboAutoProfile";
            this.cboAutoProfile.Size = new System.Drawing.Size(125, 20);
            this.cboAutoProfile.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(193, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "(1-5)";
            // 
            // txtAutoProfileSensitivity
            // 
            this.txtAutoProfileSensitivity.Location = new System.Drawing.Point(155, 47);
            this.txtAutoProfileSensitivity.MaxLength = 1;
            this.txtAutoProfileSensitivity.Name = "txtAutoProfileSensitivity";
            this.txtAutoProfileSensitivity.Size = new System.Drawing.Size(36, 19);
            this.txtAutoProfileSensitivity.TabIndex = 3;
            this.txtAutoProfileSensitivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAutoProfileSensitivity.TextChanged += new System.EventHandler(this.txtAutoProfileSensitivity_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "AutoProfileSensitivity";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "AutoProfile";
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(148, 136);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(72, 24);
            this.ButtonClose.TabIndex = 0;
            this.ButtonClose.Text = "Close";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // FormAutoProfile
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(367, 172);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAutoProfile";
            this.Text = "AutoProfile";
            this.Closed += new System.EventHandler(this.FormAutoProfile_Closed);
            this.Load += new System.EventHandler(this.FormAutoProfile_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtAutoProfileSensitivity;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cboAutoProfile;
    }
}
