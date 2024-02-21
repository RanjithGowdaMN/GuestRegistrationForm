
namespace GuestRegistrationWinForm
{
    partial class FormVisitHistory
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
            this.panelVisitHistory = new System.Windows.Forms.Panel();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btnVisitHistorySearch = new System.Windows.Forms.Button();
            this.lblVisitHistoryIdNo = new System.Windows.Forms.Label();
            this.txtVisitHistoryIdNo = new System.Windows.Forms.TextBox();
            this.panelVisitHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelVisitHistory
            // 
            this.panelVisitHistory.BackColor = System.Drawing.Color.White;
            this.panelVisitHistory.Controls.Add(this.dgvHistory);
            this.panelVisitHistory.Controls.Add(this.btnVisitHistorySearch);
            this.panelVisitHistory.Controls.Add(this.lblVisitHistoryIdNo);
            this.panelVisitHistory.Controls.Add(this.txtVisitHistoryIdNo);
            this.panelVisitHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVisitHistory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelVisitHistory.Location = new System.Drawing.Point(0, 0);
            this.panelVisitHistory.Name = "panelVisitHistory";
            this.panelVisitHistory.Size = new System.Drawing.Size(1810, 823);
            this.panelVisitHistory.TabIndex = 0;
            // 
            // dgvHistory
            // 
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(190, 358);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.RowTemplate.Height = 24;
            this.dgvHistory.Size = new System.Drawing.Size(1497, 396);
            this.dgvHistory.TabIndex = 3;
            // 
            // btnVisitHistorySearch
            // 
            this.btnVisitHistorySearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVisitHistorySearch.BackColor = System.Drawing.Color.IndianRed;
            this.btnVisitHistorySearch.FlatAppearance.BorderSize = 0;
            this.btnVisitHistorySearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisitHistorySearch.Location = new System.Drawing.Point(828, 192);
            this.btnVisitHistorySearch.Name = "btnVisitHistorySearch";
            this.btnVisitHistorySearch.Size = new System.Drawing.Size(138, 42);
            this.btnVisitHistorySearch.TabIndex = 2;
            this.btnVisitHistorySearch.Text = "SEARCH";
            this.btnVisitHistorySearch.UseVisualStyleBackColor = false;
            this.btnVisitHistorySearch.Click += new System.EventHandler(this.btnVisitHistorySearch_Click);
            // 
            // lblVisitHistoryIdNo
            // 
            this.lblVisitHistoryIdNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVisitHistoryIdNo.AutoSize = true;
            this.lblVisitHistoryIdNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitHistoryIdNo.Location = new System.Drawing.Point(653, 81);
            this.lblVisitHistoryIdNo.Name = "lblVisitHistoryIdNo";
            this.lblVisitHistoryIdNo.Size = new System.Drawing.Size(103, 23);
            this.lblVisitHistoryIdNo.TabIndex = 1;
            this.lblVisitHistoryIdNo.Text = "ID Number";
            // 
            // txtVisitHistoryIdNo
            // 
            this.txtVisitHistoryIdNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtVisitHistoryIdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVisitHistoryIdNo.Location = new System.Drawing.Point(866, 74);
            this.txtVisitHistoryIdNo.Name = "txtVisitHistoryIdNo";
            this.txtVisitHistoryIdNo.Size = new System.Drawing.Size(297, 30);
            this.txtVisitHistoryIdNo.TabIndex = 0;
            // 
            // FormVisitHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1810, 823);
            this.Controls.Add(this.panelVisitHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVisitHistory";
            this.Text = "FormVisitHistory";
            this.panelVisitHistory.ResumeLayout(false);
            this.panelVisitHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelVisitHistory;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnVisitHistorySearch;
        private System.Windows.Forms.Label lblVisitHistoryIdNo;
        private System.Windows.Forms.TextBox txtVisitHistoryIdNo;
    }
}