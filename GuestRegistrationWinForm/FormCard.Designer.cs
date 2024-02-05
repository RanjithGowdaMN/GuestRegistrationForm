
namespace gui
{
    partial class FormCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCard));
            this.panelCard = new System.Windows.Forms.Panel();
            this.lblCardNo = new System.Windows.Forms.Label();
            this.cmbCardNo = new System.Windows.Forms.ComboBox();
            this.cmbCardSelectPrinter = new System.Windows.Forms.ComboBox();
            this.lblCardPrinter = new System.Windows.Forms.Label();
            this.btnCardPrint = new System.Windows.Forms.Button();
            this.btnCardSearch = new System.Windows.Forms.Button();
            this.lblCardIdno = new System.Windows.Forms.Label();
            this.panelCardDemo = new System.Windows.Forms.Panel();
            this.panelCardClr = new System.Windows.Forms.Panel();
            this.lblCardName = new System.Windows.Forms.Label();
            this.lblCardType = new System.Windows.Forms.Label();
            this.pbCardDemo = new System.Windows.Forms.PictureBox();
            this.txtCardId = new System.Windows.Forms.TextBox();
            this.panelCard.SuspendLayout();
            this.panelCardDemo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardDemo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.Controls.Add(this.lblCardNo);
            this.panelCard.Controls.Add(this.cmbCardNo);
            this.panelCard.Controls.Add(this.cmbCardSelectPrinter);
            this.panelCard.Controls.Add(this.lblCardPrinter);
            this.panelCard.Controls.Add(this.btnCardPrint);
            this.panelCard.Controls.Add(this.btnCardSearch);
            this.panelCard.Controls.Add(this.lblCardIdno);
            this.panelCard.Controls.Add(this.panelCardDemo);
            this.panelCard.Controls.Add(this.txtCardId);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(0, 0);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(1565, 735);
            this.panelCard.TabIndex = 0;
            // 
            // lblCardNo
            // 
            this.lblCardNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardNo.AutoSize = true;
            this.lblCardNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardNo.Location = new System.Drawing.Point(52, 412);
            this.lblCardNo.Name = "lblCardNo";
            this.lblCardNo.Size = new System.Drawing.Size(81, 23);
            this.lblCardNo.TabIndex = 8;
            this.lblCardNo.Text = "Card No";
            // 
            // cmbCardNo
            // 
            this.cmbCardNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCardNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCardNo.FormattingEnabled = true;
            this.cmbCardNo.Location = new System.Drawing.Point(244, 406);
            this.cmbCardNo.Name = "cmbCardNo";
            this.cmbCardNo.Size = new System.Drawing.Size(316, 33);
            this.cmbCardNo.TabIndex = 7;
            // 
            // cmbCardSelectPrinter
            // 
            this.cmbCardSelectPrinter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCardSelectPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCardSelectPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCardSelectPrinter.FormattingEnabled = true;
            this.cmbCardSelectPrinter.Location = new System.Drawing.Point(244, 313);
            this.cmbCardSelectPrinter.Name = "cmbCardSelectPrinter";
            this.cmbCardSelectPrinter.Size = new System.Drawing.Size(316, 33);
            this.cmbCardSelectPrinter.TabIndex = 6;
            // 
            // lblCardPrinter
            // 
            this.lblCardPrinter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardPrinter.AutoSize = true;
            this.lblCardPrinter.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardPrinter.Location = new System.Drawing.Point(52, 323);
            this.lblCardPrinter.Name = "lblCardPrinter";
            this.lblCardPrinter.Size = new System.Drawing.Size(127, 23);
            this.lblCardPrinter.TabIndex = 5;
            this.lblCardPrinter.Text = "Select Printer";
            // 
            // btnCardPrint
            // 
            this.btnCardPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCardPrint.BackColor = System.Drawing.Color.IndianRed;
            this.btnCardPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCardPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCardPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCardPrint.ForeColor = System.Drawing.Color.White;
            this.btnCardPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnCardPrint.Image")));
            this.btnCardPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCardPrint.Location = new System.Drawing.Point(317, 499);
            this.btnCardPrint.Name = "btnCardPrint";
            this.btnCardPrint.Size = new System.Drawing.Size(152, 46);
            this.btnCardPrint.TabIndex = 4;
            this.btnCardPrint.Text = "Print";
            this.btnCardPrint.UseVisualStyleBackColor = false;
            this.btnCardPrint.Click += new System.EventHandler(this.btnCardPrint_Click);
            // 
            // btnCardSearch
            // 
            this.btnCardSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCardSearch.BackColor = System.Drawing.Color.IndianRed;
            this.btnCardSearch.BackgroundImage = global::GuestRegistrationWinForm.Properties.Resources.iconsSearch;
            this.btnCardSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCardSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCardSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCardSearch.ForeColor = System.Drawing.Color.White;
            this.btnCardSearch.Location = new System.Drawing.Point(600, 213);
            this.btnCardSearch.Name = "btnCardSearch";
            this.btnCardSearch.Size = new System.Drawing.Size(36, 39);
            this.btnCardSearch.TabIndex = 3;
            this.btnCardSearch.UseVisualStyleBackColor = false;
            this.btnCardSearch.Click += new System.EventHandler(this.btnCardSearch_Click);
            // 
            // lblCardIdno
            // 
            this.lblCardIdno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardIdno.AutoSize = true;
            this.lblCardIdno.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardIdno.Location = new System.Drawing.Point(60, 229);
            this.lblCardIdno.Name = "lblCardIdno";
            this.lblCardIdno.Size = new System.Drawing.Size(60, 23);
            this.lblCardIdno.TabIndex = 2;
            this.lblCardIdno.Text = "ID No";
            // 
            // panelCardDemo
            // 
            this.panelCardDemo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelCardDemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCardDemo.Controls.Add(this.panelCardClr);
            this.panelCardDemo.Controls.Add(this.lblCardName);
            this.panelCardDemo.Controls.Add(this.lblCardType);
            this.panelCardDemo.Controls.Add(this.pbCardDemo);
            this.panelCardDemo.Location = new System.Drawing.Point(706, 162);
            this.panelCardDemo.Name = "panelCardDemo";
            this.panelCardDemo.Size = new System.Drawing.Size(733, 397);
            this.panelCardDemo.TabIndex = 1;
            // 
            // panelCardClr
            // 
            this.panelCardClr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelCardClr.BackColor = System.Drawing.Color.Sienna;
            this.panelCardClr.Location = new System.Drawing.Point(-1, 351);
            this.panelCardClr.Name = "panelCardClr";
            this.panelCardClr.Size = new System.Drawing.Size(733, 41);
            this.panelCardClr.TabIndex = 3;
            // 
            // lblCardName
            // 
            this.lblCardName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardName.AutoSize = true;
            this.lblCardName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardName.Location = new System.Drawing.Point(12, 309);
            this.lblCardName.Name = "lblCardName";
            this.lblCardName.Size = new System.Drawing.Size(74, 25);
            this.lblCardName.TabIndex = 2;
            this.lblCardName.Text = "NAME";
            this.lblCardName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblCardType
            // 
            this.lblCardType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardType.AutoSize = true;
            this.lblCardType.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardType.Location = new System.Drawing.Point(338, 52);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(255, 37);
            this.lblCardType.TabIndex = 1;
            this.lblCardType.Text = "CONTRACTOR";
            // 
            // pbCardDemo
            // 
            this.pbCardDemo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbCardDemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCardDemo.Image = ((System.Drawing.Image)(resources.GetObject("pbCardDemo.Image")));
            this.pbCardDemo.Location = new System.Drawing.Point(17, 17);
            this.pbCardDemo.Name = "pbCardDemo";
            this.pbCardDemo.Size = new System.Drawing.Size(215, 236);
            this.pbCardDemo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCardDemo.TabIndex = 0;
            this.pbCardDemo.TabStop = false;
            // 
            // txtCardId
            // 
            this.txtCardId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCardId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardId.Location = new System.Drawing.Point(244, 222);
            this.txtCardId.Name = "txtCardId";
            this.txtCardId.Size = new System.Drawing.Size(316, 30);
            this.txtCardId.TabIndex = 0;
            // 
            // FormCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1565, 735);
            this.Controls.Add(this.panelCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCard";
            this.Text = "FormCard";
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.panelCardDemo.ResumeLayout(false);
            this.panelCardDemo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardDemo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Button btnCardPrint;
        private System.Windows.Forms.Button btnCardSearch;
        private System.Windows.Forms.Label lblCardIdno;
        private System.Windows.Forms.Panel panelCardDemo;
        private System.Windows.Forms.Label lblCardName;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.PictureBox pbCardDemo;
        private System.Windows.Forms.TextBox txtCardId;
        private System.Windows.Forms.Panel panelCardClr;
        private System.Windows.Forms.ComboBox cmbCardSelectPrinter;
        private System.Windows.Forms.Label lblCardPrinter;
        private System.Windows.Forms.Label lblCardNo;
        private System.Windows.Forms.ComboBox cmbCardNo;
    }
}