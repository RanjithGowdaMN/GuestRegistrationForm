
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
            this.btnfront = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.pbphoto = new System.Windows.Forms.PictureBox();
            this.pbfront = new System.Windows.Forms.PictureBox();
            this.pbback = new System.Windows.Forms.PictureBox();
            this.btnphoto = new System.Windows.Forms.Button();
            this.panelScan = new System.Windows.Forms.Panel();
            this.SearchVisitor = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pbphoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbback)).BeginInit();
            this.panelScan.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblname
            // 
            this.lblname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(469, 39);
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
            this.lblid.Location = new System.Drawing.Point(469, 100);
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
            this.lbldob.Location = new System.Drawing.Point(469, 160);
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
            this.lblexp.Location = new System.Drawing.Point(469, 220);
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
            this.lblnationality.Location = new System.Drawing.Point(469, 281);
            this.lblnationality.Name = "lblnationality";
            this.lblnationality.Size = new System.Drawing.Size(116, 20);
            this.lblnationality.TabIndex = 4;
            this.lblnationality.Text = "NATIONALITY";
            // 
            // txtname
            // 
            this.txtname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtname.Location = new System.Drawing.Point(629, 39);
            this.txtname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(281, 22);
            this.txtname.TabIndex = 1;
            // 
            // txtid
            // 
            this.txtid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtid.Location = new System.Drawing.Point(629, 100);
            this.txtid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(183, 22);
            this.txtid.TabIndex = 2;
            // 
            // txtnationality
            // 
            this.txtnationality.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtnationality.Location = new System.Drawing.Point(629, 281);
            this.txtnationality.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnationality.Name = "txtnationality";
            this.txtnationality.Size = new System.Drawing.Size(183, 22);
            this.txtnationality.TabIndex = 6;
            // 
            // txtexpiry
            // 
            this.txtexpiry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtexpiry.Location = new System.Drawing.Point(629, 220);
            this.txtexpiry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtexpiry.Name = "txtexpiry";
            this.txtexpiry.Size = new System.Drawing.Size(183, 22);
            this.txtexpiry.TabIndex = 5;
            // 
            // txtdob
            // 
            this.txtdob.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtdob.Location = new System.Drawing.Point(629, 160);
            this.txtdob.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdob.Name = "txtdob";
            this.txtdob.Size = new System.Drawing.Size(183, 22);
            this.txtdob.TabIndex = 4;
            // 
            // rbid
            // 
            this.rbid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbid.AutoSize = true;
            this.rbid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbid.Location = new System.Drawing.Point(545, 340);
            this.rbid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbid.Name = "rbid";
            this.rbid.Size = new System.Drawing.Size(47, 24);
            this.rbid.TabIndex = 7;
            this.rbid.TabStop = true;
            this.rbid.Tag = "IDTypeTag";
            this.rbid.Text = "ID";
            this.rbid.UseVisualStyleBackColor = true;
            // 
            // rbpass
            // 
            this.rbpass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbpass.AutoSize = true;
            this.rbpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbpass.Location = new System.Drawing.Point(677, 340);
            this.rbpass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbpass.Name = "rbpass";
            this.rbpass.Size = new System.Drawing.Size(120, 24);
            this.rbpass.TabIndex = 8;
            this.rbpass.TabStop = true;
            this.rbpass.Tag = "IDTypeTag";
            this.rbpass.Text = "PASSPORT";
            this.rbpass.UseVisualStyleBackColor = true;
            this.rbpass.Click += new System.EventHandler(this.rbpass_Click);
            // 
            // btnfront
            // 
            this.btnfront.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnfront.BackColor = System.Drawing.Color.DarkGreen;
            this.btnfront.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfront.ForeColor = System.Drawing.Color.White;
            this.btnfront.Location = new System.Drawing.Point(511, 400);
            this.btnfront.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnfront.Name = "btnfront";
            this.btnfront.Size = new System.Drawing.Size(143, 33);
            this.btnfront.TabIndex = 9;
            this.btnfront.Text = "SCAN FRONT";
            this.btnfront.UseVisualStyleBackColor = false;
            this.btnfront.Click += new System.EventHandler(this.btnScanIdFront_Click);
            // 
            // btnback
            // 
            this.btnback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnback.BackColor = System.Drawing.Color.DarkGreen;
            this.btnback.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.ForeColor = System.Drawing.Color.White;
            this.btnback.Location = new System.Drawing.Point(771, 400);
            this.btnback.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(143, 33);
            this.btnback.TabIndex = 10;
            this.btnback.Text = "SCAN BACK";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // pbphoto
            // 
            this.pbphoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbphoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbphoto.Location = new System.Drawing.Point(1029, 42);
            this.pbphoto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbphoto.MaximumSize = new System.Drawing.Size(219, 208);
            this.pbphoto.Name = "pbphoto";
            this.pbphoto.Size = new System.Drawing.Size(219, 208);
            this.pbphoto.TabIndex = 14;
            this.pbphoto.TabStop = false;
            // 
            // pbfront
            // 
            this.pbfront.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbfront.Location = new System.Drawing.Point(289, 452);
            this.pbfront.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbfront.MaximumSize = new System.Drawing.Size(480, 190);
            this.pbfront.MinimumSize = new System.Drawing.Size(480, 190);
            this.pbfront.Name = "pbfront";
            this.pbfront.Size = new System.Drawing.Size(480, 190);
            this.pbfront.TabIndex = 15;
            this.pbfront.TabStop = false;
            // 
            // pbback
            // 
            this.pbback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbback.Location = new System.Drawing.Point(791, 452);
            this.pbback.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbback.MaximumSize = new System.Drawing.Size(480, 190);
            this.pbback.MinimumSize = new System.Drawing.Size(480, 190);
            this.pbback.Name = "pbback";
            this.pbback.Size = new System.Drawing.Size(480, 190);
            this.pbback.TabIndex = 16;
            this.pbback.TabStop = false;
            // 
            // btnphoto
            // 
            this.btnphoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnphoto.BackColor = System.Drawing.Color.DarkGreen;
            this.btnphoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnphoto.ForeColor = System.Drawing.Color.White;
            this.btnphoto.Location = new System.Drawing.Point(1095, 276);
            this.btnphoto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnphoto.Name = "btnphoto";
            this.btnphoto.Size = new System.Drawing.Size(104, 33);
            this.btnphoto.TabIndex = 11;
            this.btnphoto.Text = "PHOTO";
            this.btnphoto.UseVisualStyleBackColor = false;
            this.btnphoto.Click += new System.EventHandler(this.btnPhoto_Click);
            // 
            // panelScan
            // 
            this.panelScan.Controls.Add(this.SearchVisitor);
            this.panelScan.Controls.Add(this.lblname);
            this.panelScan.Controls.Add(this.pbback);
            this.panelScan.Controls.Add(this.btnphoto);
            this.panelScan.Controls.Add(this.pbfront);
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
            this.panelScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScan.Location = new System.Drawing.Point(0, 0);
            this.panelScan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelScan.Name = "panelScan";
            this.panelScan.Size = new System.Drawing.Size(1528, 677);
            this.panelScan.TabIndex = 18;
            this.panelScan.AutoSizeChanged += new System.EventHandler(this.panelScan_AutoSizeChanged);
            // 
            // SearchVisitor
            // 
            this.SearchVisitor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchVisitor.BackColor = System.Drawing.Color.DarkGreen;
            this.SearchVisitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchVisitor.ForeColor = System.Drawing.Color.White;
            this.SearchVisitor.Location = new System.Drawing.Point(867, 100);
            this.SearchVisitor.Margin = new System.Windows.Forms.Padding(4);
            this.SearchVisitor.Name = "SearchVisitor";
            this.SearchVisitor.Size = new System.Drawing.Size(100, 28);
            this.SearchVisitor.TabIndex = 3;
            this.SearchVisitor.Text = "SEARCH";
            this.SearchVisitor.UseVisualStyleBackColor = false;
            this.SearchVisitor.Click += new System.EventHandler(this.SearchVisitor_Click);
            // 
            // FormScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1528, 677);
            this.Controls.Add(this.panelScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormScan";
            this.Text = "FormScan";
            ((System.ComponentModel.ISupportInitialize)(this.pbphoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbfront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbback)).EndInit();
            this.panelScan.ResumeLayout(false);
            this.panelScan.PerformLayout();
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
    }
}