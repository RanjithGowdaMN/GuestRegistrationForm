using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace fiScanTest
{
    partial class FormSourceList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // Required for Windows Form Designer support
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstSource = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstSource);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 168);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // lstSource
            // 
            this.lstSource.ItemHeight = 12;
            this.lstSource.Location = new System.Drawing.Point(16, 40);
            this.lstSource.Name = "lstSource";
            this.lstSource.Size = new System.Drawing.Size(224, 112);
            this.lstSource.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source List:";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(288, 48);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(72, 24);
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "Cancel";
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(288, 16);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(72, 24);
            this.ButtonOK.TabIndex = 3;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // FormSourceList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(367, 190);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSourceList";
            this.Text = "Source List";
            this.Load += new System.EventHandler(this.FormSourceList_Load);
            this.Closed += new System.EventHandler(this.FormSourceList_Closed);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonOK;

    }
}
