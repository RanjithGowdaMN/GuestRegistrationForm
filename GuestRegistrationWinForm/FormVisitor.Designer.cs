
namespace gui
{
    partial class FormVisitor
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
            this.lblVtitle = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblVrsnvst = new System.Windows.Forms.Label();
            this.lblVcomp = new System.Windows.Forms.Label();
            this.panelVisitor = new System.Windows.Forms.Panel();
            this.txtVisitorTitle = new System.Windows.Forms.TextBox();
            this.dtVisitorVisitDate = new System.Windows.Forms.DateTimePicker();
            this.dtVisitorDuration = new System.Windows.Forms.DateTimePicker();
            this.txtVisitorSecutityController = new System.Windows.Forms.TextBox();
            this.lblVsc = new System.Windows.Forms.Label();
            this.cmbVisitorProductionManager = new System.Windows.Forms.ComboBox();
            this.cmbVisitorPersonToVisited = new System.Windows.Forms.ComboBox();
            this.cmbVisitorAreaVisited = new System.Windows.Forms.ComboBox();
            this.cmbvisitorDeptManager = new System.Windows.Forms.ComboBox();
            this.lblVprodmangr = new System.Windows.Forms.Label();
            this.lblVdeptmang = new System.Windows.Forms.Label();
            this.lblVduration = new System.Windows.Forms.Label();
            this.lblVdate = new System.Windows.Forms.Label();
            this.lblVarea = new System.Windows.Forms.Label();
            this.lblVprsnvisit = new System.Windows.Forms.Label();
            this.cmbVistorReasonForVisit = new System.Windows.Forms.ComboBox();
            this.cmbVisitorComp = new System.Windows.Forms.ComboBox();
            this.txtVisitorComp = new System.Windows.Forms.TextBox();
            this.panelVisitor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVtitle
            // 
            this.lblVtitle.AutoSize = true;
            this.lblVtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVtitle.Location = new System.Drawing.Point(605, 61);
            this.lblVtitle.Name = "lblVtitle";
            this.lblVtitle.Size = new System.Drawing.Size(41, 20);
            this.lblVtitle.TabIndex = 0;
            this.lblVtitle.Text = "Title";
            // 
            // lblVrsnvst
            // 
            this.lblVrsnvst.AutoSize = true;
            this.lblVrsnvst.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVrsnvst.Location = new System.Drawing.Point(605, 181);
            this.lblVrsnvst.Name = "lblVrsnvst";
            this.lblVrsnvst.Size = new System.Drawing.Size(167, 20);
            this.lblVrsnvst.TabIndex = 1;
            this.lblVrsnvst.Text = "Reason For The Visit";
            // 
            // lblVcomp
            // 
            this.lblVcomp.AutoSize = true;
            this.lblVcomp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVcomp.Location = new System.Drawing.Point(605, 121);
            this.lblVcomp.Name = "lblVcomp";
            this.lblVcomp.Size = new System.Drawing.Size(88, 20);
            this.lblVcomp.TabIndex = 2;
            this.lblVcomp.Text = "Comapany";
            // 
            // panelVisitor
            // 
            this.panelVisitor.BackColor = System.Drawing.Color.White;
            this.panelVisitor.Controls.Add(this.txtVisitorTitle);
            this.panelVisitor.Controls.Add(this.dtVisitorVisitDate);
            this.panelVisitor.Controls.Add(this.dtVisitorDuration);
            this.panelVisitor.Controls.Add(this.txtVisitorSecutityController);
            this.panelVisitor.Controls.Add(this.lblVsc);
            this.panelVisitor.Controls.Add(this.cmbVisitorProductionManager);
            this.panelVisitor.Controls.Add(this.cmbVisitorPersonToVisited);
            this.panelVisitor.Controls.Add(this.cmbVisitorAreaVisited);
            this.panelVisitor.Controls.Add(this.cmbvisitorDeptManager);
            this.panelVisitor.Controls.Add(this.lblVprodmangr);
            this.panelVisitor.Controls.Add(this.lblVdeptmang);
            this.panelVisitor.Controls.Add(this.lblVduration);
            this.panelVisitor.Controls.Add(this.lblVdate);
            this.panelVisitor.Controls.Add(this.lblVarea);
            this.panelVisitor.Controls.Add(this.lblVprsnvisit);
            this.panelVisitor.Controls.Add(this.cmbVistorReasonForVisit);
            this.panelVisitor.Controls.Add(this.cmbVisitorComp);
            this.panelVisitor.Controls.Add(this.txtVisitorComp);
            this.panelVisitor.Controls.Add(this.lblVtitle);
            this.panelVisitor.Controls.Add(this.lblVrsnvst);
            this.panelVisitor.Controls.Add(this.lblVcomp);
            this.panelVisitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVisitor.Location = new System.Drawing.Point(0, 0);
            this.panelVisitor.Name = "panelVisitor";
            this.panelVisitor.Size = new System.Drawing.Size(1583, 723);
            this.panelVisitor.TabIndex = 3;
            this.panelVisitor.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtVisitorTitle
            // 
            this.txtVisitorTitle.Location = new System.Drawing.Point(839, 59);
            this.txtVisitorTitle.Name = "txtVisitorTitle";
            this.txtVisitorTitle.Size = new System.Drawing.Size(214, 22);
            this.txtVisitorTitle.TabIndex = 22;
            // 
            // dtVisitorVisitDate
            // 
            this.dtVisitorVisitDate.Location = new System.Drawing.Point(839, 361);
            this.dtVisitorVisitDate.Name = "dtVisitorVisitDate";
            this.dtVisitorVisitDate.Size = new System.Drawing.Size(244, 22);
            this.dtVisitorVisitDate.TabIndex = 21;
            // 
            // dtVisitorDuration
            // 
            this.dtVisitorDuration.Location = new System.Drawing.Point(839, 421);
            this.dtVisitorDuration.Name = "dtVisitorDuration";
            this.dtVisitorDuration.Size = new System.Drawing.Size(244, 22);
            this.dtVisitorDuration.TabIndex = 20;
            // 
            // txtVisitorSecutityController
            // 
            this.txtVisitorSecutityController.Location = new System.Drawing.Point(839, 599);
            this.txtVisitorSecutityController.Name = "txtVisitorSecutityController";
            this.txtVisitorSecutityController.Size = new System.Drawing.Size(214, 22);
            this.txtVisitorSecutityController.TabIndex = 19;
            // 
            // lblVsc
            // 
            this.lblVsc.AutoSize = true;
            this.lblVsc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVsc.Location = new System.Drawing.Point(605, 601);
            this.lblVsc.Name = "lblVsc";
            this.lblVsc.Size = new System.Drawing.Size(148, 20);
            this.lblVsc.TabIndex = 18;
            this.lblVsc.Text = "Security Controller";
            // 
            // cmbVisitorProductionManager
            // 
            this.cmbVisitorProductionManager.FormattingEnabled = true;
            this.cmbVisitorProductionManager.Location = new System.Drawing.Point(839, 537);
            this.cmbVisitorProductionManager.Name = "cmbVisitorProductionManager";
            this.cmbVisitorProductionManager.Size = new System.Drawing.Size(214, 24);
            this.cmbVisitorProductionManager.TabIndex = 17;
            // 
            // cmbVisitorPersonToVisited
            // 
            this.cmbVisitorPersonToVisited.FormattingEnabled = true;
            this.cmbVisitorPersonToVisited.Location = new System.Drawing.Point(839, 237);
            this.cmbVisitorPersonToVisited.Name = "cmbVisitorPersonToVisited";
            this.cmbVisitorPersonToVisited.Size = new System.Drawing.Size(214, 24);
            this.cmbVisitorPersonToVisited.TabIndex = 16;
            // 
            // cmbVisitorAreaVisited
            // 
            this.cmbVisitorAreaVisited.FormattingEnabled = true;
            this.cmbVisitorAreaVisited.Location = new System.Drawing.Point(839, 297);
            this.cmbVisitorAreaVisited.Name = "cmbVisitorAreaVisited";
            this.cmbVisitorAreaVisited.Size = new System.Drawing.Size(214, 24);
            this.cmbVisitorAreaVisited.TabIndex = 14;
            // 
            // cmbvisitorDeptManager
            // 
            this.cmbvisitorDeptManager.FormattingEnabled = true;
            this.cmbvisitorDeptManager.Location = new System.Drawing.Point(839, 481);
            this.cmbvisitorDeptManager.Name = "cmbvisitorDeptManager";
            this.cmbvisitorDeptManager.Size = new System.Drawing.Size(214, 24);
            this.cmbvisitorDeptManager.TabIndex = 13;
            // 
            // lblVprodmangr
            // 
            this.lblVprodmangr.AutoSize = true;
            this.lblVprodmangr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVprodmangr.Location = new System.Drawing.Point(605, 541);
            this.lblVprodmangr.Name = "lblVprodmangr";
            this.lblVprodmangr.Size = new System.Drawing.Size(208, 20);
            this.lblVprodmangr.TabIndex = 12;
            this.lblVprodmangr.Text = "Production Maager/Deputy";
            // 
            // lblVdeptmang
            // 
            this.lblVdeptmang.AutoSize = true;
            this.lblVdeptmang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVdeptmang.Location = new System.Drawing.Point(605, 485);
            this.lblVdeptmang.Name = "lblVdeptmang";
            this.lblVdeptmang.Size = new System.Drawing.Size(167, 20);
            this.lblVdeptmang.TabIndex = 11;
            this.lblVdeptmang.Text = "Department Manager";
            // 
            // lblVduration
            // 
            this.lblVduration.AutoSize = true;
            this.lblVduration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVduration.Location = new System.Drawing.Point(605, 421);
            this.lblVduration.Name = "lblVduration";
            this.lblVduration.Size = new System.Drawing.Size(111, 20);
            this.lblVduration.TabIndex = 10;
            this.lblVduration.Text = "Visit Duration";
            // 
            // lblVdate
            // 
            this.lblVdate.AutoSize = true;
            this.lblVdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVdate.Location = new System.Drawing.Point(605, 361);
            this.lblVdate.Name = "lblVdate";
            this.lblVdate.Size = new System.Drawing.Size(159, 20);
            this.lblVdate.TabIndex = 9;
            this.lblVdate.Text = "Visit Date And Time";
            // 
            // lblVarea
            // 
            this.lblVarea.AutoSize = true;
            this.lblVarea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVarea.Location = new System.Drawing.Point(605, 301);
            this.lblVarea.Name = "lblVarea";
            this.lblVarea.Size = new System.Drawing.Size(150, 20);
            this.lblVarea.TabIndex = 8;
            this.lblVarea.Text = "Area To Be Visited";
            // 
            // lblVprsnvisit
            // 
            this.lblVprsnvisit.AutoSize = true;
            this.lblVprsnvisit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVprsnvisit.Location = new System.Drawing.Point(605, 241);
            this.lblVprsnvisit.Name = "lblVprsnvisit";
            this.lblVprsnvisit.Size = new System.Drawing.Size(189, 20);
            this.lblVprsnvisit.TabIndex = 7;
            this.lblVprsnvisit.Text = "Person(s) To Be Visited";
            // 
            // cmbVistorReasonForVisit
            // 
            this.cmbVistorReasonForVisit.FormattingEnabled = true;
            this.cmbVistorReasonForVisit.Location = new System.Drawing.Point(839, 177);
            this.cmbVistorReasonForVisit.Name = "cmbVistorReasonForVisit";
            this.cmbVistorReasonForVisit.Size = new System.Drawing.Size(214, 24);
            this.cmbVistorReasonForVisit.TabIndex = 6;
            // 
            // cmbVisitorComp
            // 
            this.cmbVisitorComp.FormattingEnabled = true;
            this.cmbVisitorComp.Location = new System.Drawing.Point(839, 117);
            this.cmbVisitorComp.Name = "cmbVisitorComp";
            this.cmbVisitorComp.Size = new System.Drawing.Size(214, 24);
            this.cmbVisitorComp.TabIndex = 5;
            // 
            // txtVisitorComp
            // 
            this.txtVisitorComp.Location = new System.Drawing.Point(1089, 119);
            this.txtVisitorComp.Name = "txtVisitorComp";
            this.txtVisitorComp.Size = new System.Drawing.Size(214, 22);
            this.txtVisitorComp.TabIndex = 4;
            // 
            // FormVisitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1583, 723);
            this.Controls.Add(this.panelVisitor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVisitor";
            this.Text = "FormVisitor";
            this.Load += new System.EventHandler(this.FormVisitor_Load);
            this.panelVisitor.ResumeLayout(false);
            this.panelVisitor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblVtitle;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblVrsnvst;
        private System.Windows.Forms.Label lblVcomp;
        private System.Windows.Forms.Panel panelVisitor;
        private System.Windows.Forms.TextBox txtVisitorComp;
        private System.Windows.Forms.DateTimePicker dtVisitorVisitDate;
        private System.Windows.Forms.DateTimePicker dtVisitorDuration;
        private System.Windows.Forms.TextBox txtVisitorSecutityController;
        private System.Windows.Forms.Label lblVsc;
        private System.Windows.Forms.ComboBox cmbVisitorProductionManager;
        private System.Windows.Forms.ComboBox cmbVisitorPersonToVisited;
        private System.Windows.Forms.ComboBox cmbVisitorAreaVisited;
        private System.Windows.Forms.ComboBox cmbvisitorDeptManager;
        private System.Windows.Forms.Label lblVprodmangr;
        private System.Windows.Forms.Label lblVdeptmang;
        private System.Windows.Forms.Label lblVduration;
        private System.Windows.Forms.Label lblVdate;
        private System.Windows.Forms.Label lblVarea;
        private System.Windows.Forms.Label lblVprsnvisit;
        private System.Windows.Forms.ComboBox cmbVistorReasonForVisit;
        private System.Windows.Forms.ComboBox cmbVisitorComp;
        private System.Windows.Forms.TextBox txtVisitorTitle;
    }
}