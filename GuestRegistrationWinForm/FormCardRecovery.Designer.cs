
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
            this.lblSelect = new System.Windows.Forms.Label();
            this.rbVisitor = new System.Windows.Forms.RadioButton();
            this.rbContractor = new System.Windows.Forms.RadioButton();
            this.lblCardNum = new System.Windows.Forms.Label();
            this.cmbCardNum = new System.Windows.Forms.ComboBox();
            this.btnCardRecov = new System.Windows.Forms.Button();
            this.panelCardRecovDemo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCardRecovName = new System.Windows.Forms.Label();
            this.lblCradRecovNum = new System.Windows.Forms.Label();
            this.lblCardRecovType = new System.Windows.Forms.Label();
            this.pbCardRecov = new System.Windows.Forms.PictureBox();
            this.panelCardRecovery.SuspendLayout();
            this.panelCardRecovDemo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardRecov)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCardRecovery
            // 
            this.panelCardRecovery.BackColor = System.Drawing.Color.White;
            this.panelCardRecovery.Controls.Add(this.lblSelect);
            this.panelCardRecovery.Controls.Add(this.rbVisitor);
            this.panelCardRecovery.Controls.Add(this.rbContractor);
            this.panelCardRecovery.Controls.Add(this.lblCardNum);
            this.panelCardRecovery.Controls.Add(this.cmbCardNum);
            this.panelCardRecovery.Controls.Add(this.btnCardRecov);
            this.panelCardRecovery.Controls.Add(this.panelCardRecovDemo);
            this.panelCardRecovery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardRecovery.Location = new System.Drawing.Point(0, 0);
            this.panelCardRecovery.Name = "panelCardRecovery";
            this.panelCardRecovery.Size = new System.Drawing.Size(1676, 730);
            this.panelCardRecovery.TabIndex = 0;
            // 
            // lblSelect
            // 
            this.lblSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSelect.AutoSize = true;
            this.lblSelect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect.Location = new System.Drawing.Point(12, 171);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(87, 23);
            this.lblSelect.TabIndex = 9;
            this.lblSelect.Text = "SELECT";
            // 
            // rbVisitor
            // 
            this.rbVisitor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbVisitor.AutoSize = true;
            this.rbVisitor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbVisitor.Location = new System.Drawing.Point(478, 171);
            this.rbVisitor.Name = "rbVisitor";
            this.rbVisitor.Size = new System.Drawing.Size(113, 27);
            this.rbVisitor.TabIndex = 8;
            this.rbVisitor.TabStop = true;
            this.rbVisitor.Text = "VISITOR";
            this.rbVisitor.UseVisualStyleBackColor = true;
            // 
            // rbContractor
            // 
            this.rbContractor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbContractor.AutoSize = true;
            this.rbContractor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbContractor.Location = new System.Drawing.Point(265, 171);
            this.rbContractor.Name = "rbContractor";
            this.rbContractor.Size = new System.Drawing.Size(173, 27);
            this.rbContractor.TabIndex = 7;
            this.rbContractor.TabStop = true;
            this.rbContractor.Text = "CONTRACTOR";
            this.rbContractor.UseVisualStyleBackColor = true;
            // 
            // lblCardNum
            // 
            this.lblCardNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardNum.AutoSize = true;
            this.lblCardNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardNum.Location = new System.Drawing.Point(12, 276);
            this.lblCardNum.Name = "lblCardNum";
            this.lblCardNum.Size = new System.Drawing.Size(157, 23);
            this.lblCardNum.TabIndex = 6;
            this.lblCardNum.Text = "CARD NUMBER";
            // 
            // cmbCardNum
            // 
            this.cmbCardNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCardNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCardNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCardNum.FormattingEnabled = true;
            this.cmbCardNum.Location = new System.Drawing.Point(278, 266);
            this.cmbCardNum.Name = "cmbCardNum";
            this.cmbCardNum.Size = new System.Drawing.Size(364, 33);
            this.cmbCardNum.TabIndex = 5;
            this.cmbCardNum.SelectedIndexChanged += new System.EventHandler(this.CmbCardNum_SelectedIndexChanged);
            // 
            // btnCardRecov
            // 
            this.btnCardRecov.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCardRecov.BackColor = System.Drawing.Color.IndianRed;
            this.btnCardRecov.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCardRecov.FlatAppearance.BorderSize = 0;
            this.btnCardRecov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardRecov.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCardRecov.ForeColor = System.Drawing.Color.White;
            this.btnCardRecov.Image = ((System.Drawing.Image)(resources.GetObject("btnCardRecov.Image")));
            this.btnCardRecov.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCardRecov.Location = new System.Drawing.Point(278, 399);
            this.btnCardRecov.Name = "btnCardRecov";
            this.btnCardRecov.Size = new System.Drawing.Size(289, 51);
            this.btnCardRecov.TabIndex = 4;
            this.btnCardRecov.Text = "RECOVER CARD";
            this.btnCardRecov.UseVisualStyleBackColor = false;
            this.btnCardRecov.Click += new System.EventHandler(this.btnCardRecov_Click);
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
            this.panelCardRecovDemo.Location = new System.Drawing.Point(900, 100);
            this.panelCardRecovDemo.Name = "panelCardRecovDemo";
            this.panelCardRecovDemo.Size = new System.Drawing.Size(771, 374);
            this.panelCardRecovDemo.TabIndex = 3;
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
            // lblCardRecovType
            // 
            this.lblCardRecovType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardRecovType.AutoSize = true;
            this.lblCardRecovType.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardRecovType.Location = new System.Drawing.Point(394, 61);
            this.lblCardRecovType.Name = "lblCardRecovType";
            this.lblCardRecovType.Size = new System.Drawing.Size(255, 37);
            this.lblCardRecovType.TabIndex = 1;
            this.lblCardRecovType.Text = "CONTRACTOR";
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
            // FormCardRecovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1676, 730);
            this.Controls.Add(this.panelCardRecovery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCardRecovery";
            this.Text = "FormCardRecovery";
            this.Load += new System.EventHandler(this.Card_Load);
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
        private System.Windows.Forms.Button btnCardRecov;
        private System.Windows.Forms.Label lblCardRecovName;
        private System.Windows.Forms.Label lblCradRecovNum;
        private System.Windows.Forms.Label lblCardRecovType;
        private System.Windows.Forms.PictureBox pbCardRecov;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCardNum;
        private System.Windows.Forms.ComboBox cmbCardNum;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.RadioButton rbVisitor;
        private System.Windows.Forms.RadioButton rbContractor;
    }
}