
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
            this.GenerateVisitorDoc = new System.Windows.Forms.Button();
            this.GenerateContractDoc = new System.Windows.Forms.Button();
            this.panelDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDoc
            // 
            this.panelDoc.BackColor = System.Drawing.Color.White;
            this.panelDoc.Controls.Add(this.GenerateVisitorDoc);
            this.panelDoc.Controls.Add(this.GenerateContractDoc);
            this.panelDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelDoc.Location = new System.Drawing.Point(0, 0);
            this.panelDoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDoc.Name = "panelDoc";
            this.panelDoc.Size = new System.Drawing.Size(800, 450);
            this.panelDoc.TabIndex = 0;
            this.panelDoc.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDoc_Paint);
            // 
            // GenerateVisitorDoc
            // 
            this.GenerateVisitorDoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GenerateVisitorDoc.BackColor = System.Drawing.Color.Gray;
            this.GenerateVisitorDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GenerateVisitorDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateVisitorDoc.ForeColor = System.Drawing.Color.Transparent;
            this.GenerateVisitorDoc.Image = global::GuestRegistrationWinForm.Properties.Resources.iconsDocument;
            this.GenerateVisitorDoc.Location = new System.Drawing.Point(289, 223);
            this.GenerateVisitorDoc.Margin = new System.Windows.Forms.Padding(4);
            this.GenerateVisitorDoc.Name = "GenerateVisitorDoc";
            this.GenerateVisitorDoc.Size = new System.Drawing.Size(192, 50);
            this.GenerateVisitorDoc.TabIndex = 1;
            this.GenerateVisitorDoc.Text = "Visitor";
            this.GenerateVisitorDoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.GenerateVisitorDoc.UseVisualStyleBackColor = false;
            this.GenerateVisitorDoc.Click += new System.EventHandler(this.GenerateVisitorDoc_Click);
            // 
            // GenerateContractDoc
            // 
            this.GenerateContractDoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GenerateContractDoc.BackColor = System.Drawing.Color.Brown;
            this.GenerateContractDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GenerateContractDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerateContractDoc.ForeColor = System.Drawing.Color.Transparent;
            this.GenerateContractDoc.Image = global::GuestRegistrationWinForm.Properties.Resources.iconsDocument;
            this.GenerateContractDoc.Location = new System.Drawing.Point(289, 108);
            this.GenerateContractDoc.Margin = new System.Windows.Forms.Padding(4);
            this.GenerateContractDoc.Name = "GenerateContractDoc";
            this.GenerateContractDoc.Size = new System.Drawing.Size(192, 50);
            this.GenerateContractDoc.TabIndex = 0;
            this.GenerateContractDoc.Text = "Contractor";
            this.GenerateContractDoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.GenerateContractDoc.UseVisualStyleBackColor = false;
            this.GenerateContractDoc.Click += new System.EventHandler(this.GenerateContractDoc_Click);
            // 
            // FormDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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