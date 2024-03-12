
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
            this.label1 = new System.Windows.Forms.Label();
            this.rbVisitHistoryDate = new System.Windows.Forms.RadioButton();
            this.dtVisitHistoryDate = new System.Windows.Forms.DateTimePicker();
            this.rbVisitHistoryName = new System.Windows.Forms.RadioButton();
            this.rbVisitHistoryId = new System.Windows.Forms.RadioButton();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btnVisitHistorySearch = new System.Windows.Forms.Button();
            this.txtVisitHistoryIdNo = new System.Windows.Forms.TextBox();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.panelVisitHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelVisitHistory
            // 
            this.panelVisitHistory.BackColor = System.Drawing.Color.White;
            this.panelVisitHistory.Controls.Add(this.rbAll);
            this.panelVisitHistory.Controls.Add(this.label1);
            this.panelVisitHistory.Controls.Add(this.rbVisitHistoryDate);
            this.panelVisitHistory.Controls.Add(this.dtVisitHistoryDate);
            this.panelVisitHistory.Controls.Add(this.rbVisitHistoryName);
            this.panelVisitHistory.Controls.Add(this.rbVisitHistoryId);
            this.panelVisitHistory.Controls.Add(this.dgvHistory);
            this.panelVisitHistory.Controls.Add(this.btnVisitHistorySearch);
            this.panelVisitHistory.Controls.Add(this.txtVisitHistoryIdNo);
            this.panelVisitHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVisitHistory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelVisitHistory.Location = new System.Drawing.Point(0, 0);
            this.panelVisitHistory.Name = "panelVisitHistory";
            this.panelVisitHistory.Size = new System.Drawing.Size(1810, 823);
            this.panelVisitHistory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(750, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select The Field To Be Searched";
            // 
            // rbVisitHistoryDate
            // 
            this.rbVisitHistoryDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbVisitHistoryDate.AutoSize = true;
            this.rbVisitHistoryDate.Location = new System.Drawing.Point(1089, 80);
            this.rbVisitHistoryDate.Name = "rbVisitHistoryDate";
            this.rbVisitHistoryDate.Size = new System.Drawing.Size(84, 27);
            this.rbVisitHistoryDate.TabIndex = 9;
            this.rbVisitHistoryDate.TabStop = true;
            this.rbVisitHistoryDate.Text = "DATE";
            this.rbVisitHistoryDate.UseVisualStyleBackColor = true;
            // 
            // dtVisitHistoryDate
            // 
            this.dtVisitHistoryDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtVisitHistoryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtVisitHistoryDate.Location = new System.Drawing.Point(960, 150);
            this.dtVisitHistoryDate.Name = "dtVisitHistoryDate";
            this.dtVisitHistoryDate.Size = new System.Drawing.Size(280, 30);
            this.dtVisitHistoryDate.TabIndex = 8;
            // 
            // rbVisitHistoryName
            // 
            this.rbVisitHistoryName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbVisitHistoryName.AutoSize = true;
            this.rbVisitHistoryName.Location = new System.Drawing.Point(893, 80);
            this.rbVisitHistoryName.Name = "rbVisitHistoryName";
            this.rbVisitHistoryName.Size = new System.Drawing.Size(90, 27);
            this.rbVisitHistoryName.TabIndex = 7;
            this.rbVisitHistoryName.TabStop = true;
            this.rbVisitHistoryName.Text = "NAME";
            this.rbVisitHistoryName.UseVisualStyleBackColor = true;
            // 
            // rbVisitHistoryId
            // 
            this.rbVisitHistoryId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbVisitHistoryId.AutoSize = true;
            this.rbVisitHistoryId.Location = new System.Drawing.Point(743, 80);
            this.rbVisitHistoryId.Name = "rbVisitHistoryId";
            this.rbVisitHistoryId.Size = new System.Drawing.Size(52, 27);
            this.rbVisitHistoryId.TabIndex = 6;
            this.rbVisitHistoryId.TabStop = true;
            this.rbVisitHistoryId.Text = "ID";
            this.rbVisitHistoryId.UseVisualStyleBackColor = true;
            // 
            // dgvHistory
            // 
            this.dgvHistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(266, 415);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.RowTemplate.Height = 24;
            this.dgvHistory.Size = new System.Drawing.Size(1320, 316);
            this.dgvHistory.TabIndex = 3;
            // 
            // btnVisitHistorySearch
            // 
            this.btnVisitHistorySearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVisitHistorySearch.BackColor = System.Drawing.Color.IndianRed;
            this.btnVisitHistorySearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVisitHistorySearch.FlatAppearance.BorderSize = 0;
            this.btnVisitHistorySearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisitHistorySearch.Location = new System.Drawing.Point(815, 233);
            this.btnVisitHistorySearch.Name = "btnVisitHistorySearch";
            this.btnVisitHistorySearch.Size = new System.Drawing.Size(138, 42);
            this.btnVisitHistorySearch.TabIndex = 2;
            this.btnVisitHistorySearch.Text = "SEARCH";
            this.btnVisitHistorySearch.UseVisualStyleBackColor = false;
            this.btnVisitHistorySearch.Click += new System.EventHandler(this.btnVisitHistorySearch_Click);
            // 
            // txtVisitHistoryIdNo
            // 
            this.txtVisitHistoryIdNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtVisitHistoryIdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVisitHistoryIdNo.Location = new System.Drawing.Point(550, 150);
            this.txtVisitHistoryIdNo.Name = "txtVisitHistoryIdNo";
            this.txtVisitHistoryIdNo.Size = new System.Drawing.Size(275, 30);
            this.txtVisitHistoryIdNo.TabIndex = 0;
            // 
            // rbAll
            // 
            this.rbAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(559, 80);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(71, 27);
            this.rbAll.TabIndex = 11;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "ALL";
            this.rbAll.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.TextBox txtVisitHistoryIdNo;
        private System.Windows.Forms.RadioButton rbVisitHistoryName;
        private System.Windows.Forms.RadioButton rbVisitHistoryId;
        private System.Windows.Forms.DateTimePicker dtVisitHistoryDate;
        private System.Windows.Forms.RadioButton rbVisitHistoryDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbAll;
    }
}