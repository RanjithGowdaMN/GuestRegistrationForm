﻿
namespace gui
{
    partial class FormMain
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
            this.panelhome = new System.Windows.Forms.Panel();
            this.btnWindowMin = new System.Windows.Forms.Button();
            this.btnWindowMaxm = new System.Windows.Forms.Button();
            this.btnWindowClsoe = new System.Windows.Forms.Button();
            this.lblhome = new System.Windows.Forms.Label();
            this.panelbuttons = new System.Windows.Forms.Panel();
            this.btndoc = new System.Windows.Forms.Button();
            this.btnlgt = new System.Windows.Forms.Button();
            this.btncard = new System.Windows.Forms.Button();
            this.btnvisitor = new System.Windows.Forms.Button();
            this.btncontractor = new System.Windows.Forms.Button();
            this.btnscan = new System.Windows.Forms.Button();
            this.panelform = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lblScanner = new System.Windows.Forms.Label();
            this.lblCamera = new System.Windows.Forms.Label();
            this.panelhome.SuspendLayout();
            this.panelbuttons.SuspendLayout();
            this.panelform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelhome
            // 
            this.panelhome.BackColor = System.Drawing.Color.Brown;
            this.panelhome.Controls.Add(this.btnWindowMin);
            this.panelhome.Controls.Add(this.btnWindowMaxm);
            this.panelhome.Controls.Add(this.btnWindowClsoe);
            this.panelhome.Controls.Add(this.lblhome);
            this.panelhome.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelhome.ForeColor = System.Drawing.Color.White;
            this.panelhome.Location = new System.Drawing.Point(0, 0);
            this.panelhome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelhome.Name = "panelhome";
            this.panelhome.Size = new System.Drawing.Size(1789, 68);
            this.panelhome.TabIndex = 0;
            this.panelhome.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelhome_MouseDown);
            // 
            // btnWindowMin
            // 
            this.btnWindowMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnWindowMin.FlatAppearance.BorderSize = 0;
            this.btnWindowMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowMin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWindowMin.Location = new System.Drawing.Point(1648, 0);
            this.btnWindowMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWindowMin.Name = "btnWindowMin";
            this.btnWindowMin.Size = new System.Drawing.Size(43, 68);
            this.btnWindowMin.TabIndex = 2;
            this.btnWindowMin.Text = "-";
            this.btnWindowMin.UseVisualStyleBackColor = true;
            this.btnWindowMin.Click += new System.EventHandler(this.btnWindowMax_Click);
            // 
            // btnWindowMaxm
            // 
            this.btnWindowMaxm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnWindowMaxm.FlatAppearance.BorderSize = 0;
            this.btnWindowMaxm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowMaxm.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWindowMaxm.Location = new System.Drawing.Point(1691, 0);
            this.btnWindowMaxm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWindowMaxm.Name = "btnWindowMaxm";
            this.btnWindowMaxm.Size = new System.Drawing.Size(45, 68);
            this.btnWindowMaxm.TabIndex = 3;
            this.btnWindowMaxm.Text = "O";
            this.btnWindowMaxm.UseVisualStyleBackColor = true;
            this.btnWindowMaxm.Click += new System.EventHandler(this.btnWindowMin_Click);
            // 
            // btnWindowClsoe
            // 
            this.btnWindowClsoe.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnWindowClsoe.FlatAppearance.BorderSize = 0;
            this.btnWindowClsoe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowClsoe.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWindowClsoe.Location = new System.Drawing.Point(1736, 0);
            this.btnWindowClsoe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnWindowClsoe.Name = "btnWindowClsoe";
            this.btnWindowClsoe.Size = new System.Drawing.Size(53, 68);
            this.btnWindowClsoe.TabIndex = 1;
            this.btnWindowClsoe.Text = "X";
            this.btnWindowClsoe.UseVisualStyleBackColor = true;
            this.btnWindowClsoe.Click += new System.EventHandler(this.btnWindowClsoe_Click);
            // 
            // lblhome
            // 
            this.lblhome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblhome.AutoSize = true;
            this.lblhome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblhome.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhome.Location = new System.Drawing.Point(656, 1);
            this.lblhome.Name = "lblhome";
            this.lblhome.Size = new System.Drawing.Size(500, 54);
            this.lblhome.TabIndex = 0;
            this.lblhome.Text = "INSTANT CARD PRINTING";
            this.lblhome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelbuttons
            // 
            this.panelbuttons.BackColor = System.Drawing.Color.Maroon;
            this.panelbuttons.Controls.Add(this.btndoc);
            this.panelbuttons.Controls.Add(this.btnlgt);
            this.panelbuttons.Controls.Add(this.btncard);
            this.panelbuttons.Controls.Add(this.btnvisitor);
            this.panelbuttons.Controls.Add(this.btncontractor);
            this.panelbuttons.Controls.Add(this.btnscan);
            this.panelbuttons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelbuttons.Location = new System.Drawing.Point(0, 68);
            this.panelbuttons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelbuttons.Name = "panelbuttons";
            this.panelbuttons.Size = new System.Drawing.Size(1789, 66);
            this.panelbuttons.TabIndex = 1;
            // 
            // btndoc
            // 
            this.btndoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btndoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndoc.FlatAppearance.BorderSize = 0;
            this.btndoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndoc.ForeColor = System.Drawing.Color.White;
            this.btndoc.Image = global::GuestRegistrationWinForm.Properties.Resources.icons8_document_30__1_;
            this.btndoc.Location = new System.Drawing.Point(880, 1);
            this.btndoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btndoc.Name = "btndoc";
            this.btndoc.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btndoc.Size = new System.Drawing.Size(230, 65);
            this.btndoc.TabIndex = 3;
            this.btndoc.Text = "DOCUMENT";
            this.btndoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndoc.UseVisualStyleBackColor = true;
            this.btndoc.Click += new System.EventHandler(this.btndoc_Click);
            // 
            // btnlgt
            // 
            this.btnlgt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnlgt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlgt.FlatAppearance.BorderSize = 0;
            this.btnlgt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlgt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlgt.ForeColor = System.Drawing.Color.White;
            this.btnlgt.Image = global::GuestRegistrationWinForm.Properties.Resources.icons8_history_30;
            this.btnlgt.Location = new System.Drawing.Point(1340, 1);
            this.btnlgt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnlgt.Name = "btnlgt";
            this.btnlgt.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnlgt.Size = new System.Drawing.Size(265, 65);
            this.btnlgt.TabIndex = 5;
            this.btnlgt.Text = "VISIT HISTORY";
            this.btnlgt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlgt.UseVisualStyleBackColor = true;
            this.btnlgt.Click += new System.EventHandler(this.btnlgt_Click);
            // 
            // btncard
            // 
            this.btncard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncard.FlatAppearance.BorderSize = 0;
            this.btncard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncard.ForeColor = System.Drawing.Color.White;
            this.btncard.Image = global::GuestRegistrationWinForm.Properties.Resources.iconidcard;
            this.btncard.Location = new System.Drawing.Point(1110, 1);
            this.btncard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btncard.Name = "btncard";
            this.btncard.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btncard.Size = new System.Drawing.Size(230, 65);
            this.btncard.TabIndex = 4;
            this.btncard.Text = "CARD";
            this.btncard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncard.UseVisualStyleBackColor = true;
            this.btncard.Click += new System.EventHandler(this.btncard_Click);
            // 
            // btnvisitor
            // 
            this.btnvisitor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnvisitor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnvisitor.FlatAppearance.BorderSize = 0;
            this.btnvisitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvisitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvisitor.ForeColor = System.Drawing.Color.White;
            this.btnvisitor.Image = global::GuestRegistrationWinForm.Properties.Resources.icons8_user_30;
            this.btnvisitor.Location = new System.Drawing.Point(650, 1);
            this.btnvisitor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnvisitor.Name = "btnvisitor";
            this.btnvisitor.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnvisitor.Size = new System.Drawing.Size(230, 65);
            this.btnvisitor.TabIndex = 2;
            this.btnvisitor.Text = "VISITOR";
            this.btnvisitor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnvisitor.UseVisualStyleBackColor = true;
            this.btnvisitor.Click += new System.EventHandler(this.btnVisitorTab_Click);
            // 
            // btncontractor
            // 
            this.btncontractor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncontractor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncontractor.FlatAppearance.BorderSize = 0;
            this.btncontractor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncontractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncontractor.ForeColor = System.Drawing.Color.White;
            this.btncontractor.Image = global::GuestRegistrationWinForm.Properties.Resources.icons8_user_30;
            this.btncontractor.Location = new System.Drawing.Point(420, 1);
            this.btncontractor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btncontractor.Name = "btncontractor";
            this.btncontractor.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btncontractor.Size = new System.Drawing.Size(230, 65);
            this.btncontractor.TabIndex = 1;
            this.btncontractor.Text = "CONTRACTOR";
            this.btncontractor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncontractor.UseVisualStyleBackColor = true;
            this.btncontractor.Click += new System.EventHandler(this.btncontractor_Click);
            // 
            // btnscan
            // 
            this.btnscan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnscan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnscan.FlatAppearance.BorderSize = 0;
            this.btnscan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnscan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnscan.ForeColor = System.Drawing.Color.White;
            this.btnscan.Image = global::GuestRegistrationWinForm.Properties.Resources.icons8_scanner_30__1_;
            this.btnscan.Location = new System.Drawing.Point(190, 1);
            this.btnscan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnscan.Name = "btnscan";
            this.btnscan.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnscan.Size = new System.Drawing.Size(230, 65);
            this.btnscan.TabIndex = 0;
            this.btnscan.Text = "SCAN";
            this.btnscan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnscan.UseVisualStyleBackColor = true;
            this.btnscan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // panelform
            // 
            this.panelform.AutoSize = true;
            this.panelform.Controls.Add(this.pictureBox1);
            this.panelform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelform.Location = new System.Drawing.Point(0, 134);
            this.panelform.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelform.Name = "panelform";
            this.panelform.Size = new System.Drawing.Size(1789, 820);
            this.panelform.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::GuestRegistrationWinForm.Properties.Resources.SPP;
            this.pictureBox1.Location = new System.Drawing.Point(429, 133);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1059, 460);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelStatus.Controls.Add(this.lblScanner);
            this.panelStatus.Controls.Add(this.lblCamera);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 908);
            this.panelStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1789, 46);
            this.panelStatus.TabIndex = 3;
            // 
            // lblScanner
            // 
            this.lblScanner.AutoSize = true;
            this.lblScanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanner.ForeColor = System.Drawing.Color.Red;
            this.lblScanner.Location = new System.Drawing.Point(256, 10);
            this.lblScanner.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScanner.Name = "lblScanner";
            this.lblScanner.Size = new System.Drawing.Size(93, 25);
            this.lblScanner.TabIndex = 3;
            this.lblScanner.Text = "Scanner";
            // 
            // lblCamera
            // 
            this.lblCamera.AutoSize = true;
            this.lblCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamera.ForeColor = System.Drawing.Color.Red;
            this.lblCamera.Location = new System.Drawing.Point(113, 10);
            this.lblCamera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(88, 25);
            this.lblCamera.TabIndex = 2;
            this.lblCamera.Text = "Camera";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1789, 954);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.panelform);
            this.Controls.Add(this.panelbuttons);
            this.Controls.Add(this.panelhome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1789, 954);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelhome.ResumeLayout(false);
            this.panelhome.PerformLayout();
            this.panelbuttons.ResumeLayout(false);
            this.panelform.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelhome;
        private System.Windows.Forms.Panel panelbuttons;
        private System.Windows.Forms.Button btnscan;
        private System.Windows.Forms.Panel panelform;
        private System.Windows.Forms.Button btncontractor;
        private System.Windows.Forms.Button btnvisitor;
        private System.Windows.Forms.Label lblhome;
        private System.Windows.Forms.Button btndoc;
        private System.Windows.Forms.Button btnlgt;
        private System.Windows.Forms.Button btncard;
        private System.Windows.Forms.Button btnWindowMin;
        private System.Windows.Forms.Button btnWindowMaxm;
        private System.Windows.Forms.Button btnWindowClsoe;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label lblScanner;
        private System.Windows.Forms.Label lblCamera;
    }
}