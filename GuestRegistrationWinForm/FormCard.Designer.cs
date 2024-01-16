
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
            this.panelCard = new System.Windows.Forms.Panel();
            this.txtCardId = new System.Windows.Forms.TextBox();
            this.panelCardDemo = new System.Windows.Forms.Panel();
            this.pbCardDemo = new System.Windows.Forms.PictureBox();
            this.lblCardType = new System.Windows.Forms.Label();
            this.lblCardName = new System.Windows.Forms.Label();
            this.lblCardIdno = new System.Windows.Forms.Label();
            this.btnCardSearch = new System.Windows.Forms.Button();
            this.btnCardPrint = new System.Windows.Forms.Button();
            this.panelCard.SuspendLayout();
            this.panelCardDemo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardDemo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.Controls.Add(this.btnCardPrint);
            this.panelCard.Controls.Add(this.btnCardSearch);
            this.panelCard.Controls.Add(this.lblCardIdno);
            this.panelCard.Controls.Add(this.panelCardDemo);
            this.panelCard.Controls.Add(this.txtCardId);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(0, 0);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(1379, 735);
            this.panelCard.TabIndex = 0;
            // 
            // txtCardId
            // 
            this.txtCardId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCardId.Location = new System.Drawing.Point(129, 212);
            this.txtCardId.Name = "txtCardId";
            this.txtCardId.Size = new System.Drawing.Size(316, 22);
            this.txtCardId.TabIndex = 0;
            // 
            // panelCardDemo
            // 
            this.panelCardDemo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelCardDemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCardDemo.Controls.Add(this.lblCardName);
            this.panelCardDemo.Controls.Add(this.lblCardType);
            this.panelCardDemo.Controls.Add(this.pbCardDemo);
            this.panelCardDemo.Location = new System.Drawing.Point(600, 159);
            this.panelCardDemo.Name = "panelCardDemo";
            this.panelCardDemo.Size = new System.Drawing.Size(733, 339);
            this.panelCardDemo.TabIndex = 1;
            // 
            // pbCardDemo
            // 
            this.pbCardDemo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbCardDemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCardDemo.Location = new System.Drawing.Point(476, 20);
            this.pbCardDemo.Name = "pbCardDemo";
            this.pbCardDemo.Size = new System.Drawing.Size(215, 236);
            this.pbCardDemo.TabIndex = 0;
            this.pbCardDemo.TabStop = false;
            // 
            // lblCardType
            // 
            this.lblCardType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardType.AutoSize = true;
            this.lblCardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardType.Location = new System.Drawing.Point(174, 52);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(194, 29);
            this.lblCardType.TabIndex = 1;
            this.lblCardType.Text = "CONTRACTOR";
            // 
            // lblCardName
            // 
            this.lblCardName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardName.AutoSize = true;
            this.lblCardName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardName.Location = new System.Drawing.Point(56, 294);
            this.lblCardName.Name = "lblCardName";
            this.lblCardName.Size = new System.Drawing.Size(74, 25);
            this.lblCardName.TabIndex = 2;
            this.lblCardName.Text = "NAME";
            this.lblCardName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblCardIdno
            // 
            this.lblCardIdno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCardIdno.AutoSize = true;
            this.lblCardIdno.Location = new System.Drawing.Point(65, 216);
            this.lblCardIdno.Name = "lblCardIdno";
            this.lblCardIdno.Size = new System.Drawing.Size(43, 17);
            this.lblCardIdno.TabIndex = 2;
            this.lblCardIdno.Text = "ID No";
            // 
            // btnCardSearch
            // 
            this.btnCardSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCardSearch.Location = new System.Drawing.Point(486, 210);
            this.btnCardSearch.Name = "btnCardSearch";
            this.btnCardSearch.Size = new System.Drawing.Size(75, 23);
            this.btnCardSearch.TabIndex = 3;
            this.btnCardSearch.Text = "Search";
            this.btnCardSearch.UseVisualStyleBackColor = true;
            this.btnCardSearch.Click += new System.EventHandler(this.btnCardSearch_Click);
            // 
            // btnCardPrint
            // 
            this.btnCardPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCardPrint.Location = new System.Drawing.Point(204, 363);
            this.btnCardPrint.Name = "btnCardPrint";
            this.btnCardPrint.Size = new System.Drawing.Size(75, 23);
            this.btnCardPrint.TabIndex = 4;
            this.btnCardPrint.Text = "Print";
            this.btnCardPrint.UseVisualStyleBackColor = true;
            // 
            // FormCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 735);
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
    }
}