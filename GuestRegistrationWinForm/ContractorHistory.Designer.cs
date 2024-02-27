
namespace GuestRegistrationWinForm
{
    partial class FormContractorHistory
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
            this.panelContractorHistory = new System.Windows.Forms.Panel();
            this.btnSearchConHistory = new System.Windows.Forms.Button();
            this.dgvContractorHistory = new System.Windows.Forms.DataGridView();
            this.rbCardNumConHistory = new System.Windows.Forms.RadioButton();
            this.rbCurrentContractor = new System.Windows.Forms.RadioButton();
            this.rbAllConHistory = new System.Windows.Forms.RadioButton();
            this.txtCardNumContractHistory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelContractorHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContractorHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContractorHistory
            // 
            this.panelContractorHistory.BackColor = System.Drawing.Color.White;
            this.panelContractorHistory.Controls.Add(this.label1);
            this.panelContractorHistory.Controls.Add(this.txtCardNumContractHistory);
            this.panelContractorHistory.Controls.Add(this.btnSearchConHistory);
            this.panelContractorHistory.Controls.Add(this.dgvContractorHistory);
            this.panelContractorHistory.Controls.Add(this.rbCardNumConHistory);
            this.panelContractorHistory.Controls.Add(this.rbCurrentContractor);
            this.panelContractorHistory.Controls.Add(this.rbAllConHistory);
            this.panelContractorHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContractorHistory.Location = new System.Drawing.Point(0, 0);
            this.panelContractorHistory.Name = "panelContractorHistory";
            this.panelContractorHistory.Size = new System.Drawing.Size(1410, 732);
            this.panelContractorHistory.TabIndex = 0;
            // 
            // btnSearchConHistory
            // 
            this.btnSearchConHistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearchConHistory.BackColor = System.Drawing.Color.IndianRed;
            this.btnSearchConHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchConHistory.FlatAppearance.BorderSize = 0;
            this.btnSearchConHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchConHistory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchConHistory.Location = new System.Drawing.Point(670, 190);
            this.btnSearchConHistory.Name = "btnSearchConHistory";
            this.btnSearchConHistory.Size = new System.Drawing.Size(117, 37);
            this.btnSearchConHistory.TabIndex = 5;
            this.btnSearchConHistory.Text = "SEARCH";
            this.btnSearchConHistory.UseVisualStyleBackColor = false;
            this.btnSearchConHistory.Click += new System.EventHandler(this.btnSearchConHistory_Click);
            // 
            // dgvContractorHistory
            // 
            this.dgvContractorHistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvContractorHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvContractorHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvContractorHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContractorHistory.Location = new System.Drawing.Point(155, 334);
            this.dgvContractorHistory.Name = "dgvContractorHistory";
            this.dgvContractorHistory.RowHeadersWidth = 51;
            this.dgvContractorHistory.RowTemplate.Height = 24;
            this.dgvContractorHistory.Size = new System.Drawing.Size(1140, 256);
            this.dgvContractorHistory.TabIndex = 4;
            // 
            // rbCardNumConHistory
            // 
            this.rbCardNumConHistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbCardNumConHistory.AutoSize = true;
            this.rbCardNumConHistory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCardNumConHistory.Location = new System.Drawing.Point(842, 100);
            this.rbCardNumConHistory.Name = "rbCardNumConHistory";
            this.rbCardNumConHistory.Size = new System.Drawing.Size(178, 27);
            this.rbCardNumConHistory.TabIndex = 3;
            this.rbCardNumConHistory.TabStop = true;
            this.rbCardNumConHistory.Text = "CARD NUMBER";
            this.rbCardNumConHistory.UseVisualStyleBackColor = true;
            // 
            // rbCurrentContractor
            // 
            this.rbCurrentContractor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbCurrentContractor.AutoSize = true;
            this.rbCurrentContractor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCurrentContractor.Location = new System.Drawing.Point(502, 100);
            this.rbCurrentContractor.Name = "rbCurrentContractor";
            this.rbCurrentContractor.Size = new System.Drawing.Size(285, 27);
            this.rbCurrentContractor.TabIndex = 1;
            this.rbCurrentContractor.TabStop = true;
            this.rbCurrentContractor.Text = "CURRENT CONTRACTORS";
            this.rbCurrentContractor.UseVisualStyleBackColor = true;
            // 
            // rbAllConHistory
            // 
            this.rbAllConHistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbAllConHistory.AutoSize = true;
            this.rbAllConHistory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbAllConHistory.Location = new System.Drawing.Point(342, 100);
            this.rbAllConHistory.Name = "rbAllConHistory";
            this.rbAllConHistory.Size = new System.Drawing.Size(71, 27);
            this.rbAllConHistory.TabIndex = 0;
            this.rbAllConHistory.TabStop = true;
            this.rbAllConHistory.Text = "ALL";
            this.rbAllConHistory.UseVisualStyleBackColor = true;
            // 
            // txtCardNumContractHistory
            // 
            this.txtCardNumContractHistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCardNumContractHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNumContractHistory.Location = new System.Drawing.Point(1062, 100);
            this.txtCardNumContractHistory.Name = "txtCardNumContractHistory";
            this.txtCardNumContractHistory.Size = new System.Drawing.Size(201, 30);
            this.txtCardNumContractHistory.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(604, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select The Field To Be Searched";
            // 
            // FormContractorHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 732);
            this.Controls.Add(this.panelContractorHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormContractorHistory";
            this.Text = "ContractorHistory";
            this.panelContractorHistory.ResumeLayout(false);
            this.panelContractorHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContractorHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContractorHistory;
        private System.Windows.Forms.RadioButton rbCurrentContractor;
        private System.Windows.Forms.RadioButton rbAllConHistory;
        private System.Windows.Forms.Button btnSearchConHistory;
        private System.Windows.Forms.DataGridView dgvContractorHistory;
        private System.Windows.Forms.RadioButton rbCardNumConHistory;
        private System.Windows.Forms.TextBox txtCardNumContractHistory;
        private System.Windows.Forms.Label label1;
    }
}