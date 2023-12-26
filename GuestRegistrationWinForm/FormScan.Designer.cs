﻿
namespace gui
{
    partial class FormScan
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
            this.lblname = new System.Windows.Forms.Label();
            this.lblid = new System.Windows.Forms.Label();
            this.lbldob = new System.Windows.Forms.Label();
            this.lblexp = new System.Windows.Forms.Label();
            this.lblnationality = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtnationality = new System.Windows.Forms.TextBox();
            this.txtexpiry = new System.Windows.Forms.TextBox();
            this.txtdob = new System.Windows.Forms.TextBox();
            this.rbid = new System.Windows.Forms.RadioButton();
            this.rbpass = new System.Windows.Forms.RadioButton();
            this.panelScan = new System.Windows.Forms.Panel();
            this.lblselect = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelId = new System.Windows.Forms.Panel();
            this.panelPass = new System.Windows.Forms.Panel();
            this.pbback = new System.Windows.Forms.PictureBox();
            this.pbfront = new System.Windows.Forms.PictureBox();
            this.SearchVisitor = new System.Windows.Forms.Button();
            this.btnphoto = new System.Windows.Forms.Button();
            this.pbphoto = new System.Windows.Forms.PictureBox();
            this.btnback = new System.Windows.Forms.Button();
            this.btnfront = new System.Windows.Forms.Button();
            this.pbPassportScan = new System.Windows.Forms.PictureBox();
            this.panelScan.SuspendLayout();
            this.panelId.SuspendLayout();
            this.panelPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbphoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassportScan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblname
            // 
            this.lblname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(10, 219);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(57, 20);
            this.lblname.TabIndex = 0;
            this.lblname.Text = "NAME";
            // 
            // lblid
            // 
            this.lblid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblid.AutoSize = true;
            this.lblid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblid.Location = new System.Drawing.Point(10, 289);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(104, 20);
            this.lblid.TabIndex = 1;
            this.lblid.Text = "ID NUMBER";
            // 
            // lbldob
            // 
            this.lbldob.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbldob.AutoSize = true;
            this.lbldob.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldob.Location = new System.Drawing.Point(10, 429);
            this.lbldob.Name = "lbldob";
            this.lbldob.Size = new System.Drawing.Size(138, 20);
            this.lbldob.TabIndex = 2;
            this.lbldob.Text = "DATE OF BIRTH";
            // 
            // lblexp
            // 
            this.lblexp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblexp.AutoSize = true;
            this.lblexp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblexp.Location = new System.Drawing.Point(10, 359);
            this.lblexp.Name = "lblexp";
            this.lblexp.Size = new System.Drawing.Size(90, 20);
            this.lblexp.TabIndex = 3;
            this.lblexp.Text = "ID EXPIRY";
            // 
            // lblnationality
            // 
            this.lblnationality.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblnationality.AutoSize = true;
            this.lblnationality.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnationality.Location = new System.Drawing.Point(10, 499);
            this.lblnationality.Name = "lblnationality";
            this.lblnationality.Size = new System.Drawing.Size(116, 20);
            this.lblnationality.TabIndex = 4;
            this.lblnationality.Text = "NATIONALITY";
            // 
            // txtname
            // 
            this.txtname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtname.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(180, 217);
            this.txtname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(420, 30);
            this.txtname.TabIndex = 6;
            // 
            // txtid
            // 
            this.txtid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtid.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(180, 289);
            this.txtid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(420, 30);
            this.txtid.TabIndex = 7;
            // 
            // txtnationality
            // 
            this.txtnationality.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtnationality.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnationality.Location = new System.Drawing.Point(180, 502);
            this.txtnationality.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnationality.Name = "txtnationality";
            this.txtnationality.Size = new System.Drawing.Size(420, 30);
            this.txtnationality.TabIndex = 11;
            // 
            // txtexpiry
            // 
            this.txtexpiry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtexpiry.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtexpiry.Location = new System.Drawing.Point(180, 359);
            this.txtexpiry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtexpiry.Name = "txtexpiry";
            this.txtexpiry.Size = new System.Drawing.Size(420, 30);
            this.txtexpiry.TabIndex = 9;
            // 
            // txtdob
            // 
            this.txtdob.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtdob.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdob.Location = new System.Drawing.Point(180, 429);
            this.txtdob.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdob.Name = "txtdob";
            this.txtdob.Size = new System.Drawing.Size(420, 30);
            this.txtdob.TabIndex = 10;
            // 
            // rbid
            // 
            this.rbid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbid.AutoSize = true;
            this.rbid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbid.Location = new System.Drawing.Point(180, 115);
            this.rbid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbid.Name = "rbid";
            this.rbid.Size = new System.Drawing.Size(47, 24);
            this.rbid.TabIndex = 1;
            this.rbid.TabStop = true;
            this.rbid.Tag = "IDTypeTag";
            this.rbid.Text = "ID";
            this.rbid.UseVisualStyleBackColor = true;
            this.rbid.CheckedChanged += new System.EventHandler(this.rbid_CheckedChanged);
            // 
            // rbpass
            // 
            this.rbpass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbpass.AutoSize = true;
            this.rbpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbpass.Location = new System.Drawing.Point(293, 115);
            this.rbpass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbpass.Name = "rbpass";
            this.rbpass.Size = new System.Drawing.Size(120, 24);
            this.rbpass.TabIndex = 2;
            this.rbpass.TabStop = true;
            this.rbpass.Tag = "IDTypeTag";
            this.rbpass.Text = "PASSPORT";
            this.rbpass.UseVisualStyleBackColor = true;
            this.rbpass.CheckedChanged += new System.EventHandler(this.rbpass_CheckedChanged);
            this.rbpass.Click += new System.EventHandler(this.rbpass_Click);
            // 
            // panelScan
            // 
            this.panelScan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelScan.Controls.Add(this.lblselect);
            this.panelScan.Controls.Add(this.SearchVisitor);
            this.panelScan.Controls.Add(this.lblname);
            this.panelScan.Controls.Add(this.btnphoto);
            this.panelScan.Controls.Add(this.lblid);
            this.panelScan.Controls.Add(this.lbldob);
            this.panelScan.Controls.Add(this.lblexp);
            this.panelScan.Controls.Add(this.pbphoto);
            this.panelScan.Controls.Add(this.lblnationality);
            this.panelScan.Controls.Add(this.txtnationality);
            this.panelScan.Controls.Add(this.txtexpiry);
            this.panelScan.Controls.Add(this.txtdob);
            this.panelScan.Controls.Add(this.btnback);
            this.panelScan.Controls.Add(this.rbid);
            this.panelScan.Controls.Add(this.btnfront);
            this.panelScan.Controls.Add(this.txtid);
            this.panelScan.Controls.Add(this.rbpass);
            this.panelScan.Controls.Add(this.txtname);
            this.panelScan.Location = new System.Drawing.Point(-2, 2);
            this.panelScan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelScan.Name = "panelScan";
            this.panelScan.Size = new System.Drawing.Size(932, 675);
            this.panelScan.TabIndex = 18;
            // 
            // lblselect
            // 
            this.lblselect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblselect.AutoSize = true;
            this.lblselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblselect.Location = new System.Drawing.Point(10, 115);
            this.lblselect.Name = "lblselect";
            this.lblselect.Size = new System.Drawing.Size(74, 20);
            this.lblselect.TabIndex = 15;
            this.lblselect.Text = "SELECT";
            // 
            // panelId
            // 
            this.panelId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelId.Controls.Add(this.pbback);
            this.panelId.Controls.Add(this.pbfront);
            this.panelId.Location = new System.Drawing.Point(927, 0);
            this.panelId.Name = "panelId";
            this.panelId.Size = new System.Drawing.Size(601, 677);
            this.panelId.TabIndex = 19;
            // 
            // panelPass
            // 
            this.panelPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelPass.BackColor = System.Drawing.Color.White;
            this.panelPass.Controls.Add(this.pbPassportScan);
            this.panelPass.Location = new System.Drawing.Point(952, 0);
            this.panelPass.Name = "panelPass";
            this.panelPass.Size = new System.Drawing.Size(584, 677);
            this.panelPass.TabIndex = 17;
            // 
            // pbback
            // 
            this.pbback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbback.Location = new System.Drawing.Point(25, 338);
            this.pbback.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbback.Name = "pbback";
            this.pbback.Size = new System.Drawing.Size(560, 300);
            this.pbback.TabIndex = 16;
            this.pbback.TabStop = false;
            // 
            // pbfront
            // 
            this.pbfront.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbfront.Location = new System.Drawing.Point(25, 11);
            this.pbfront.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbfront.Name = "pbfront";
            this.pbfront.Size = new System.Drawing.Size(560, 300);
            this.pbfront.TabIndex = 15;
            this.pbfront.TabStop = false;
            // 
            // SearchVisitor
            // 
            this.SearchVisitor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchVisitor.BackColor = System.Drawing.Color.ForestGreen;
            this.SearchVisitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SearchVisitor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchVisitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchVisitor.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchVisitor.ForeColor = System.Drawing.Color.White;
            this.SearchVisitor.Image = global::GuestRegistrationWinForm.Properties.Resources.iconsSearch;
            this.SearchVisitor.Location = new System.Drawing.Point(606, 280);
            this.SearchVisitor.Margin = new System.Windows.Forms.Padding(4);
            this.SearchVisitor.Name = "SearchVisitor";
            this.SearchVisitor.Size = new System.Drawing.Size(40, 44);
            this.SearchVisitor.TabIndex = 8;
            this.SearchVisitor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SearchVisitor.UseVisualStyleBackColor = false;
            this.SearchVisitor.Click += new System.EventHandler(this.SearchVisitor_Click);
            // 
            // btnphoto
            // 
            this.btnphoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnphoto.BackColor = System.Drawing.Color.ForestGreen;
            this.btnphoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnphoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnphoto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnphoto.ForeColor = System.Drawing.Color.White;
            this.btnphoto.Image = global::GuestRegistrationWinForm.Properties.Resources.iconCamera;
            this.btnphoto.Location = new System.Drawing.Point(719, 311);
            this.btnphoto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnphoto.Name = "btnphoto";
            this.btnphoto.Size = new System.Drawing.Size(160, 50);
            this.btnphoto.TabIndex = 5;
            this.btnphoto.Text = "PHOTO";
            this.btnphoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnphoto.UseVisualStyleBackColor = false;
            this.btnphoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // pbphoto
            // 
            this.pbphoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbphoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbphoto.Location = new System.Drawing.Point(673, 20);
            this.pbphoto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbphoto.Name = "pbphoto";
            this.pbphoto.Size = new System.Drawing.Size(250, 276);
            this.pbphoto.TabIndex = 14;
            this.pbphoto.TabStop = false;
            // 
            // btnback
            // 
            this.btnback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnback.BackColor = System.Drawing.Color.ForestGreen;
            this.btnback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnback.FlatAppearance.BorderSize = 0;
            this.btnback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnback.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.Color.White;
            this.btnback.Image = global::GuestRegistrationWinForm.Properties.Resources.iconScanner;
            this.btnback.Location = new System.Drawing.Point(362, 586);
            this.btnback.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(210, 50);
            this.btnback.TabIndex = 4;
            this.btnback.Text = "SCAN BACK";
            this.btnback.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btnfront
            // 
            this.btnfront.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnfront.BackColor = System.Drawing.Color.ForestGreen;
            this.btnfront.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfront.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfront.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfront.ForeColor = System.Drawing.Color.White;
            this.btnfront.Image = global::GuestRegistrationWinForm.Properties.Resources.iconScanner;
            this.btnfront.Location = new System.Drawing.Point(78, 586);
            this.btnfront.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnfront.Name = "btnfront";
            this.btnfront.Size = new System.Drawing.Size(210, 50);
            this.btnfront.TabIndex = 3;
            this.btnfront.Text = "SCAN FRONT";
            this.btnfront.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnfront.UseVisualStyleBackColor = false;
            this.btnfront.Click += new System.EventHandler(this.btnScanIdFront_Click);
            // 
            // pbPassportScan
            // 
            this.pbPassportScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPassportScan.BackColor = System.Drawing.Color.Transparent;
            this.pbPassportScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPassportScan.Location = new System.Drawing.Point(29, 52);
            this.pbPassportScan.Name = "pbPassportScan";
            this.pbPassportScan.Size = new System.Drawing.Size(502, 518);
            this.pbPassportScan.TabIndex = 0;
            this.pbPassportScan.TabStop = false;
            // 
            // FormScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1528, 677);
            this.Controls.Add(this.panelId);
            this.Controls.Add(this.panelScan);
            this.Controls.Add(this.panelPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormScan";
            this.Text = "FormScan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelScan.ResumeLayout(false);
            this.panelScan.PerformLayout();
            this.panelId.ResumeLayout(false);
            this.panelPass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbphoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassportScan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.Label lbldob;
        private System.Windows.Forms.Label lblexp;
        private System.Windows.Forms.Label lblnationality;
        public System.Windows.Forms.TextBox txtname;
        public System.Windows.Forms.TextBox txtid;
        public System.Windows.Forms.TextBox txtnationality;
        public System.Windows.Forms.TextBox txtexpiry;
        public System.Windows.Forms.TextBox txtdob;
        public System.Windows.Forms.RadioButton rbid;
        public System.Windows.Forms.RadioButton rbpass;
        public System.Windows.Forms.Button btnfront;
        public System.Windows.Forms.Button btnback;
        public System.Windows.Forms.PictureBox pbphoto;
        public System.Windows.Forms.PictureBox pbfront;
        public System.Windows.Forms.PictureBox pbback;
        public System.Windows.Forms.Button btnphoto;
        private System.Windows.Forms.Panel panelScan;
        private System.Windows.Forms.Button SearchVisitor;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelId;
        private System.Windows.Forms.Label lblselect;
        public System.Windows.Forms.PictureBox pbPassportScan;
        public System.Windows.Forms.Panel panelPass;
    }
}