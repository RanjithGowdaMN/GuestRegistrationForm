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
            this.lblhome = new System.Windows.Forms.Label();
            this.panelbuttons = new System.Windows.Forms.Panel();
            this.btndoc = new System.Windows.Forms.Button();
            this.btnlgt = new System.Windows.Forms.Button();
            this.btncard = new System.Windows.Forms.Button();
            this.btnvisitor = new System.Windows.Forms.Button();
            this.btncontractor = new System.Windows.Forms.Button();
            this.btnscan = new System.Windows.Forms.Button();
            this.panelform = new System.Windows.Forms.Panel();
            this.btnWindowClsoe = new System.Windows.Forms.Button();
            this.btnWindowMin = new System.Windows.Forms.Button();
            this.btnWindowMax = new System.Windows.Forms.Button();
            this.panelhome.SuspendLayout();
            this.panelbuttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelhome
            // 
            this.panelhome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelhome.Controls.Add(this.btnWindowMax);
            this.panelhome.Controls.Add(this.btnWindowMin);
            this.panelhome.Controls.Add(this.btnWindowClsoe);
            this.panelhome.Controls.Add(this.lblhome);
            this.panelhome.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelhome.ForeColor = System.Drawing.Color.White;
            this.panelhome.Location = new System.Drawing.Point(0, 0);
            this.panelhome.Name = "panelhome";
            this.panelhome.Size = new System.Drawing.Size(1765, 73);
            this.panelhome.TabIndex = 0;
            this.panelhome.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelhome_MouseDown);
            // 
            // lblhome
            // 
            this.lblhome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblhome.AutoSize = true;
            this.lblhome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblhome.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhome.Location = new System.Drawing.Point(712, 23);
            this.lblhome.Name = "lblhome";
            this.lblhome.Size = new System.Drawing.Size(354, 37);
            this.lblhome.TabIndex = 0;
            this.lblhome.Text = "SECURITY PRINTING PRESS";
            this.lblhome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelbuttons
            // 
            this.panelbuttons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelbuttons.Controls.Add(this.btndoc);
            this.panelbuttons.Controls.Add(this.btnlgt);
            this.panelbuttons.Controls.Add(this.btncard);
            this.panelbuttons.Controls.Add(this.btnvisitor);
            this.panelbuttons.Controls.Add(this.btncontractor);
            this.panelbuttons.Controls.Add(this.btnscan);
            this.panelbuttons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelbuttons.Location = new System.Drawing.Point(0, 73);
            this.panelbuttons.Name = "panelbuttons";
            this.panelbuttons.Size = new System.Drawing.Size(1765, 67);
            this.panelbuttons.TabIndex = 1;
            // 
            // btndoc
            // 
            this.btndoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btndoc.FlatAppearance.BorderSize = 0;
            this.btndoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndoc.ForeColor = System.Drawing.Color.White;
            this.btndoc.Location = new System.Drawing.Point(901, 0);
            this.btndoc.Name = "btndoc";
            this.btndoc.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btndoc.Size = new System.Drawing.Size(175, 65);
            this.btndoc.TabIndex = 3;
            this.btndoc.Text = "Document";
            this.btndoc.UseVisualStyleBackColor = true;
            this.btndoc.Click += new System.EventHandler(this.btndoc_Click);
            // 
            // btnlgt
            // 
            this.btnlgt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnlgt.FlatAppearance.BorderSize = 0;
            this.btnlgt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlgt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlgt.ForeColor = System.Drawing.Color.White;
            this.btnlgt.Location = new System.Drawing.Point(1239, 0);
            this.btnlgt.Name = "btnlgt";
            this.btnlgt.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnlgt.Size = new System.Drawing.Size(175, 65);
            this.btnlgt.TabIndex = 5;
            this.btnlgt.Text = "Logout";
            this.btnlgt.UseVisualStyleBackColor = true;
            this.btnlgt.Click += new System.EventHandler(this.btnlgt_Click);
            // 
            // btncard
            // 
            this.btncard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncard.FlatAppearance.BorderSize = 0;
            this.btncard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncard.ForeColor = System.Drawing.Color.White;
            this.btncard.Location = new System.Drawing.Point(1068, 0);
            this.btncard.Name = "btncard";
            this.btncard.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btncard.Size = new System.Drawing.Size(175, 65);
            this.btncard.TabIndex = 4;
            this.btncard.Text = "Card";
            this.btncard.UseVisualStyleBackColor = true;
            this.btncard.Click += new System.EventHandler(this.btncard_Click);
            // 
            // btnvisitor
            // 
            this.btnvisitor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnvisitor.FlatAppearance.BorderSize = 0;
            this.btnvisitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvisitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvisitor.ForeColor = System.Drawing.Color.White;
            this.btnvisitor.Location = new System.Drawing.Point(729, 0);
            this.btnvisitor.Name = "btnvisitor";
            this.btnvisitor.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnvisitor.Size = new System.Drawing.Size(175, 65);
            this.btnvisitor.TabIndex = 2;
            this.btnvisitor.Text = "Visitor";
            this.btnvisitor.UseVisualStyleBackColor = true;
            this.btnvisitor.Click += new System.EventHandler(this.button1_Click);
            // 
            // btncontractor
            // 
            this.btncontractor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btncontractor.FlatAppearance.BorderSize = 0;
            this.btncontractor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncontractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncontractor.ForeColor = System.Drawing.Color.White;
            this.btncontractor.Location = new System.Drawing.Point(557, 0);
            this.btncontractor.Name = "btncontractor";
            this.btncontractor.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btncontractor.Size = new System.Drawing.Size(175, 65);
            this.btncontractor.TabIndex = 1;
            this.btncontractor.Text = "Contractor";
            this.btncontractor.UseVisualStyleBackColor = true;
            this.btncontractor.Click += new System.EventHandler(this.btncontractor_Click);
            // 
            // btnscan
            // 
            this.btnscan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnscan.FlatAppearance.BorderSize = 0;
            this.btnscan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnscan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnscan.ForeColor = System.Drawing.Color.White;
            this.btnscan.Location = new System.Drawing.Point(386, 0);
            this.btnscan.Name = "btnscan";
            this.btnscan.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnscan.Size = new System.Drawing.Size(175, 65);
            this.btnscan.TabIndex = 0;
            this.btnscan.Text = "Scan";
            this.btnscan.UseVisualStyleBackColor = true;
            this.btnscan.Click += new System.EventHandler(this.btnscan_Click);
            // 
            // panelform
            // 
            this.panelform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelform.Location = new System.Drawing.Point(0, 140);
            this.panelform.Name = "panelform";
            this.panelform.Size = new System.Drawing.Size(1765, 813);
            this.panelform.TabIndex = 2;
            // 
            // btnWindowClsoe
            // 
            this.btnWindowClsoe.FlatAppearance.BorderSize = 0;
            this.btnWindowClsoe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowClsoe.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWindowClsoe.Location = new System.Drawing.Point(1471, 12);
            this.btnWindowClsoe.Name = "btnWindowClsoe";
            this.btnWindowClsoe.Size = new System.Drawing.Size(30, 35);
            this.btnWindowClsoe.TabIndex = 1;
            this.btnWindowClsoe.Text = "X";
            this.btnWindowClsoe.UseVisualStyleBackColor = true;
            this.btnWindowClsoe.Click += new System.EventHandler(this.btnWindowClsoe_Click);
            // 
            // btnWindowMin
            // 
            this.btnWindowMin.FlatAppearance.BorderSize = 0;
            this.btnWindowMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowMin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWindowMin.Location = new System.Drawing.Point(1399, 12);
            this.btnWindowMin.Name = "btnWindowMin";
            this.btnWindowMin.Size = new System.Drawing.Size(30, 35);
            this.btnWindowMin.TabIndex = 2;
            this.btnWindowMin.Text = "-";
            this.btnWindowMin.UseVisualStyleBackColor = true;
            this.btnWindowMin.Click += new System.EventHandler(this.btnWindowMin_Click);
            // 
            // btnWindowMax
            // 
            this.btnWindowMax.FlatAppearance.BorderSize = 0;
            this.btnWindowMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowMax.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWindowMax.Location = new System.Drawing.Point(1435, 12);
            this.btnWindowMax.Name = "btnWindowMax";
            this.btnWindowMax.Size = new System.Drawing.Size(30, 35);
            this.btnWindowMax.TabIndex = 3;
            this.btnWindowMax.Text = "0";
            this.btnWindowMax.UseVisualStyleBackColor = true;
            this.btnWindowMax.Click += new System.EventHandler(this.btnWindowMax_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1765, 953);
            this.Controls.Add(this.panelform);
            this.Controls.Add(this.panelbuttons);
            this.Controls.Add(this.panelhome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.panelhome.ResumeLayout(false);
            this.panelhome.PerformLayout();
            this.panelbuttons.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnWindowMax;
        private System.Windows.Forms.Button btnWindowMin;
        private System.Windows.Forms.Button btnWindowClsoe;
    }
}