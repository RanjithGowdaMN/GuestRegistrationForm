
namespace gui
{
    partial class FormDoc
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
            this.panelDoc = new System.Windows.Forms.Panel();
            this.GenerateContractDoc = new System.Windows.Forms.Button();
            this.GenerateVisitorDoc = new System.Windows.Forms.Button();
            this.panelDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDoc
            // 
            this.panelDoc.Controls.Add(this.GenerateVisitorDoc);
            this.panelDoc.Controls.Add(this.GenerateContractDoc);
            this.panelDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDoc.Location = new System.Drawing.Point(0, 0);
            this.panelDoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelDoc.Name = "panelDoc";
            this.panelDoc.Size = new System.Drawing.Size(600, 366);
            this.panelDoc.TabIndex = 0;
            // 
            // GenerateContractDoc
            // 
            this.GenerateContractDoc.Location = new System.Drawing.Point(94, 91);
            this.GenerateContractDoc.Name = "GenerateContractDoc";
            this.GenerateContractDoc.Size = new System.Drawing.Size(144, 41);
            this.GenerateContractDoc.TabIndex = 0;
            this.GenerateContractDoc.Text = "Generate Contract Document";
            this.GenerateContractDoc.UseVisualStyleBackColor = true;
            this.GenerateContractDoc.Click += new System.EventHandler(this.GenerateContractDoc_Click);
            // 
            // GenerateVisitorDoc
            // 
            this.GenerateVisitorDoc.Location = new System.Drawing.Point(275, 91);
            this.GenerateVisitorDoc.Name = "GenerateVisitorDoc";
            this.GenerateVisitorDoc.Size = new System.Drawing.Size(144, 41);
            this.GenerateVisitorDoc.TabIndex = 1;
            this.GenerateVisitorDoc.Text = "Generate Visitor Document";
            this.GenerateVisitorDoc.UseVisualStyleBackColor = true;
            // 
            // FormDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.panelDoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormDoc";
            this.Text = "FormDoc";
            this.panelDoc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDoc;
        private System.Windows.Forms.Button GenerateVisitorDoc;
        private System.Windows.Forms.Button GenerateContractDoc;
    }
}