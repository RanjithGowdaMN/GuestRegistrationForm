
namespace GuestRegistrationWinForm
{
    partial class FormCardRecovery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCardRecovery));
            this.panelCardRecovery = new System.Windows.Forms.Panel();
            this.lblCardRecovId = new System.Windows.Forms.Label();
            this.txtCardRecovId = new System.Windows.Forms.TextBox();
            this.panelCardRecovDemo = new System.Windows.Forms.Panel();
            this.lblCardRecovType = new System.Windows.Forms.Label();
            this.lblCradRecovNum = new System.Windows.Forms.Label();
            this.lblCardRecovName = new System.Windows.Forms.Label();
            this.btnCardRecov = new System.Windows.Forms.Button();
            this.pbCardRecov = new System.Windows.Forms.PictureBox();
            this.btnCardRecovSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCardRecovery.SuspendLayout();
            this.panelCardRecovDemo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardRecov)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCardRecovery
            // 
            this.panelCardRecovery.BackColor = System.Drawing.Color.White;
            this.panelCardRecovery.Controls.Add(this.btnCardRecov);
            this.panelCardRecovery.Controls.Add(this.panelCardRecovDemo);
            this.panelCardRecovery.Controls.Add(this.btnCardRecovSearch);
            this.panelCardRecovery.Controls.Add(this.txtCardRecovId);
            this.panelCardRecovery.Controls.Add(this.lblCardRecovId);
            this.panelCardRecovery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardRecovery.Location = new System.Drawing.Point(0, 0);
            this.panelCardRecovery.Name = "panelCardRecovery";
            this.panelCardRecovery.Size = new System.Drawing.Size(1676, 730);
            this.panelCardRecovery.TabIndex = 0;
            // 
            // lblCardRecovId
            // 
            this.lblCardRecovId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardRecovId.AutoSize = true;
            this.lblCardRecovId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardRecovId.Location = new System.Drawing.Point(72, 293);
            this.lblCardRecovId.Name = "lblCardRecovId";
            this.lblCardRecovId.Size = new System.Drawing.Size(29, 23);
            this.lblCardRecovId.TabIndex = 0;
            this.lblCardRecovId.Text = "lD";
            // 
            // txtCardRecovId
            // 
            this.txtCardRecovId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCardRecovId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardRecovId.Location = new System.Drawing.Point(172, 286);
            this.txtCardRecovId.Name = "txtCardRecovId";
            this.txtCardRecovId.Size = new System.Drawing.Size(364, 30);
            this.txtCardRecovId.TabIndex = 1;
            // 
            // panelCardRecovDemo
            // 
            this.panelCardRecovDemo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelCardRecovDemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCardRecovDemo.Controls.Add(this.panel1);
            this.panelCardRecovDemo.Controls.Add(this.lblCardRecovName);
            this.panelCardRecovDemo.Controls.Add(this.lblCradRecovNum);
            this.panelCardRecovDemo.Controls.Add(this.lblCardRecovType);
            this.panelCardRecovDemo.Controls.Add(this.pbCardRecov);
            this.panelCardRecovDemo.Location = new System.Drawing.Point(799, 167);
            this.panelCardRecovDemo.Name = "panelCardRecovDemo";
            this.panelCardRecovDemo.Size = new System.Drawing.Size(771, 374);
            this.panelCardRecovDemo.TabIndex = 3;
            // 
            // lblCardRecovType
            // 
            this.lblCardRecovType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardRecovType.AutoSize = true;
            this.lblCardRecovType.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardRecovType.Location = new System.Drawing.Point(394, 61);
            this.lblCardRecovType.Name = "lblCardRecovType";
            this.lblCardRecovType.Size = new System.Drawing.Size(263, 38);
            this.lblCardRecovType.TabIndex = 1;
            this.lblCardRecovType.Text = "CONTRACTOR";
            // 
            // lblCradRecovNum
            // 
            this.lblCradRecovNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCradRecovNum.AutoSize = true;
            this.lblCradRecovNum.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCradRecovNum.Location = new System.Drawing.Point(454, 157);
            this.lblCradRecovNum.Name = "lblCradRecovNum";
            this.lblCradRecovNum.Size = new System.Drawing.Size(60, 26);
            this.lblCradRecovNum.TabIndex = 2;
            this.lblCradRecovNum.Text = "****";
            // 
            // lblCardRecovName
            // 
            this.lblCardRecovName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardRecovName.AutoSize = true;
            this.lblCardRecovName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardRecovName.Location = new System.Drawing.Point(14, 293);
            this.lblCardRecovName.Name = "lblCardRecovName";
            this.lblCardRecovName.Size = new System.Drawing.Size(69, 23);
            this.lblCardRecovName.TabIndex = 3;
            this.lblCardRecovName.Text = "NAME";
            // 
            // btnCardRecov
            // 
            this.btnCardRecov.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCardRecov.BackColor = System.Drawing.Color.IndianRed;
            this.btnCardRecov.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCardRecov.FlatAppearance.BorderSize = 0;
            this.btnCardRecov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardRecov.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCardRecov.ForeColor = System.Drawing.Color.White;
            this.btnCardRecov.Image = ((System.Drawing.Image)(resources.GetObject("btnCardRecov.Image")));
            this.btnCardRecov.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCardRecov.Location = new System.Drawing.Point(252, 422);
            this.btnCardRecov.Name = "btnCardRecov";
            this.btnCardRecov.Size = new System.Drawing.Size(191, 51);
            this.btnCardRecov.TabIndex = 4;
            this.btnCardRecov.Text = "Recover Card";
            this.btnCardRecov.UseVisualStyleBackColor = false;
            // 
            // pbCardRecov
            // 
            this.pbCardRecov.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbCardRecov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCardRecov.Image = ((System.Drawing.Image)(resources.GetObject("pbCardRecov.Image")));
            this.pbCardRecov.Location = new System.Drawing.Point(33, 15);
            this.pbCardRecov.Name = "pbCardRecov";
            this.pbCardRecov.Size = new System.Drawing.Size(243, 228);
            this.pbCardRecov.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCardRecov.TabIndex = 0;
            this.pbCardRecov.TabStop = false;
            // 
            // btnCardRecovSearch
            // 
            this.btnCardRecovSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCardRecovSearch.BackColor = System.Drawing.Color.IndianRed;
            this.btnCardRecovSearch.BackgroundImage = global::GuestRegistrationWinForm.Properties.Resources.iconsSearch;
            this.btnCardRecovSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCardRecovSearch.FlatAppearance.BorderSize = 0;
            this.btnCardRecovSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardRecovSearch.Location = new System.Drawing.Point(563, 277);
            this.btnCardRecovSearch.Name = "btnCardRecovSearch";
            this.btnCardRecovSearch.Size = new System.Drawing.Size(49, 39);
            this.btnCardRecovSearch.TabIndex = 2;
            this.btnCardRecovSearch.UseVisualStyleBackColor = false;
            this.btnCardRecovSearch.Click += new System.EventHandler(this.btnCardRecovSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Sienna;
            this.panel1.Location = new System.Drawing.Point(1, 329);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 43);
            this.panel1.TabIndex = 4;
            // 
            // FormCardRecovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1676, 730);
            this.Controls.Add(this.panelCardRecovery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCardRecovery";
            this.Text = "FormCardRecovery";
            this.panelCardRecovery.ResumeLayout(false);
            this.panelCardRecovery.PerformLayout();
            this.panelCardRecovDemo.ResumeLayout(false);
            this.panelCardRecovDemo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardRecov)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCardRecovery;
        private System.Windows.Forms.Panel panelCardRecovDemo;
        private System.Windows.Forms.Button btnCardRecovSearch;
        private System.Windows.Forms.TextBox txtCardRecovId;
        private System.Windows.Forms.Label lblCardRecovId;
        private System.Windows.Forms.Button btnCardRecov;
        private System.Windows.Forms.Label lblCardRecovName;
        private System.Windows.Forms.Label lblCradRecovNum;
        private System.Windows.Forms.Label lblCardRecovType;
        private System.Windows.Forms.PictureBox pbCardRecov;
        private System.Windows.Forms.Panel panel1;
    }
}