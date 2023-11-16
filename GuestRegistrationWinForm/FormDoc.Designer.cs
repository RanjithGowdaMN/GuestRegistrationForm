
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
            this.SuspendLayout();
            // 
            // panelDoc
            // 
            this.panelDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDoc.Location = new System.Drawing.Point(0, 0);
            this.panelDoc.Name = "panelDoc";
            this.panelDoc.Size = new System.Drawing.Size(800, 450);
            this.panelDoc.TabIndex = 0;
            // 
            // FormDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDoc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDoc";
            this.Text = "FormDoc";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDoc;
    }
}