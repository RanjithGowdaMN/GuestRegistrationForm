
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
            this.components = new System.ComponentModel.Container();
            this.lblVtitle = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblVrsnvst = new System.Windows.Forms.Label();
            this.lblVcomp = new System.Windows.Forms.Label();
            this.panelVisitor = new System.Windows.Forms.Panel();
            this.cmbVisitorTitle = new System.Windows.Forms.ComboBox();
            this.cmbVisitorSecurityController = new System.Windows.Forms.ComboBox();
            this.dtVisitorVisitDuration = new System.Windows.Forms.DateTimePicker();
            this.cmbVisitorVisitTimeToMinutes = new System.Windows.Forms.ComboBox();
            this.cmbVisitorVisitTimeToHr = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVisitTimeFromMinutes = new System.Windows.Forms.ComboBox();
            this.cmbVisitTimeFromHr = new System.Windows.Forms.ComboBox();
            this.lblVisitorVisitTime = new System.Windows.Forms.Label();
            this.btnVisitorDocument = new System.Windows.Forms.Button();
            this.dtVisitorVisitDate = new System.Windows.Forms.DateTimePicker();
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelVisitor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVtitle
            // 
            this.lblVtitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVtitle.AutoSize = true;
            this.lblVtitle.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVtitle.Location = new System.Drawing.Point(350, 20);
            this.lblVtitle.Name = "lblVtitle";
            this.lblVtitle.Size = new System.Drawing.Size(57, 19);
            this.lblVtitle.TabIndex = 0;
            this.lblVtitle.Text = "TITLE";
            this.lblVtitle.Click += new System.EventHandler(this.lblVtitle_Click);
            // 
            // lblVrsnvst
            // 
            this.lblVrsnvst.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVrsnvst.AutoSize = true;
            this.lblVrsnvst.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVrsnvst.Location = new System.Drawing.Point(350, 140);
            this.lblVrsnvst.Name = "lblVrsnvst";
            this.lblVrsnvst.Size = new System.Drawing.Size(201, 19);
            this.lblVrsnvst.TabIndex = 1;
            this.lblVrsnvst.Text = "REASON FOR THE VISIT";
            // 
            // lblVcomp
            // 
            this.lblVcomp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVcomp.AutoSize = true;
            this.lblVcomp.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVcomp.Location = new System.Drawing.Point(350, 80);
            this.lblVcomp.Name = "lblVcomp";
            this.lblVcomp.Size = new System.Drawing.Size(94, 19);
            this.lblVcomp.TabIndex = 2;
            this.lblVcomp.Text = "COMPANY";
            // 
            // panelVisitor
            // 
            this.panelVisitor.BackColor = System.Drawing.Color.White;
            this.panelVisitor.Controls.Add(this.cmbVisitorTitle);
            this.panelVisitor.Controls.Add(this.cmbVisitorSecurityController);
            this.panelVisitor.Controls.Add(this.dtVisitorVisitDuration);
            this.panelVisitor.Controls.Add(this.cmbVisitorVisitTimeToMinutes);
            this.panelVisitor.Controls.Add(this.cmbVisitorVisitTimeToHr);
            this.panelVisitor.Controls.Add(this.label1);
            this.panelVisitor.Controls.Add(this.cmbVisitTimeFromMinutes);
            this.panelVisitor.Controls.Add(this.cmbVisitTimeFromHr);
            this.panelVisitor.Controls.Add(this.lblVisitorVisitTime);
            this.panelVisitor.Controls.Add(this.btnVisitorDocument);
            this.panelVisitor.Controls.Add(this.dtVisitorVisitDate);
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
            this.panelVisitor.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelVisitor.Location = new System.Drawing.Point(0, 0);
            this.panelVisitor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelVisitor.Name = "panelVisitor";
            this.panelVisitor.Size = new System.Drawing.Size(1583, 722);
            this.panelVisitor.TabIndex = 3;
            this.panelVisitor.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmbVisitorTitle
            // 
            this.cmbVisitorTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbVisitorTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisitorTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVisitorTitle.FormattingEnabled = true;
            this.cmbVisitorTitle.Location = new System.Drawing.Point(800, 20);
            this.cmbVisitorTitle.Name = "cmbVisitorTitle";
            this.cmbVisitorTitle.Size = new System.Drawing.Size(334, 30);
            this.cmbVisitorTitle.TabIndex = 1;
            this.cmbVisitorTitle.SelectedIndexChanged += new System.EventHandler(this.cmbVisitorTitle_SelectedIndexChanged_1);
            // 
            // cmbVisitorSecurityController
            // 
            this.cmbVisitorSecurityController.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbVisitorSecurityController.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisitorSecurityController.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVisitorSecurityController.FormattingEnabled = true;
            this.cmbVisitorSecurityController.Location = new System.Drawing.Point(800, 560);
            this.cmbVisitorSecurityController.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbVisitorSecurityController.Name = "cmbVisitorSecurityController";
            this.cmbVisitorSecurityController.Size = new System.Drawing.Size(332, 30);
            this.cmbVisitorSecurityController.TabIndex = 15;
            this.cmbVisitorSecurityController.SelectedIndexChanged += new System.EventHandler(this.cmbVisitorSecurityController_SelectedIndexChanged);
            // 
            // dtVisitorVisitDuration
            // 
            this.dtVisitorVisitDuration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtVisitorVisitDuration.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtVisitorVisitDuration.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVisitorVisitDuration.Location = new System.Drawing.Point(800, 380);
            this.dtVisitorVisitDuration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtVisitorVisitDuration.MinDate = new System.DateTime(2023, 12, 5, 0, 0, 0, 0);
            this.dtVisitorVisitDuration.Name = "dtVisitorVisitDuration";
            this.dtVisitorVisitDuration.Size = new System.Drawing.Size(332, 30);
            this.dtVisitorVisitDuration.TabIndex = 10;
            this.dtVisitorVisitDuration.ValueChanged += new System.EventHandler(this.dtVisitorVisitDuration_ValueChanged);
            // 
            // cmbVisitorVisitTimeToMinutes
            // 
            this.cmbVisitorVisitTimeToMinutes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbVisitorVisitTimeToMinutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisitorVisitTimeToMinutes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVisitorVisitTimeToMinutes.FormattingEnabled = true;
            this.cmbVisitorVisitTimeToMinutes.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60"});
            this.cmbVisitorVisitTimeToMinutes.Location = new System.Drawing.Point(1385, 380);
            this.cmbVisitorVisitTimeToMinutes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbVisitorVisitTimeToMinutes.Name = "cmbVisitorVisitTimeToMinutes";
            this.cmbVisitorVisitTimeToMinutes.Size = new System.Drawing.Size(64, 30);
            this.cmbVisitorVisitTimeToMinutes.TabIndex = 12;
            this.cmbVisitorVisitTimeToMinutes.SelectedIndexChanged += new System.EventHandler(this.cmbVisitorVisitTimeToMinutes_SelectedIndexChanged);
            this.cmbVisitorVisitTimeToMinutes.SelectedValueChanged += new System.EventHandler(this.cmbVisitorVisitTimeToMinutes_SelectedValueChanged);
            // 
            // cmbVisitorVisitTimeToHr
            // 
            this.cmbVisitorVisitTimeToHr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbVisitorVisitTimeToHr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisitorVisitTimeToHr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVisitorVisitTimeToHr.FormattingEnabled = true;
            this.cmbVisitorVisitTimeToHr.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cmbVisitorVisitTimeToHr.Location = new System.Drawing.Point(1280, 380);
            this.cmbVisitorVisitTimeToHr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbVisitorVisitTimeToHr.Name = "cmbVisitorVisitTimeToHr";
            this.cmbVisitorVisitTimeToHr.Size = new System.Drawing.Size(64, 30);
            this.cmbVisitorVisitTimeToHr.TabIndex = 11;
            this.cmbVisitorVisitTimeToHr.SelectedIndexChanged += new System.EventHandler(this.cmbVisitorVisitTimeToHr_SelectedIndexChanged);
            this.cmbVisitorVisitTimeToHr.SelectedValueChanged += new System.EventHandler(this.cmbVisitorVisitTimeToHr_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1180, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "TIME";
            // 
            // cmbVisitTimeFromMinutes
            // 
            this.cmbVisitTimeFromMinutes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbVisitTimeFromMinutes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisitTimeFromMinutes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVisitTimeFromMinutes.FormattingEnabled = true;
            this.cmbVisitTimeFromMinutes.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60"});
            this.cmbVisitTimeFromMinutes.Location = new System.Drawing.Point(1385, 320);
            this.cmbVisitTimeFromMinutes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbVisitTimeFromMinutes.Name = "cmbVisitTimeFromMinutes";
            this.cmbVisitTimeFromMinutes.Size = new System.Drawing.Size(64, 30);
            this.cmbVisitTimeFromMinutes.TabIndex = 9;
            this.cmbVisitTimeFromMinutes.SelectedIndexChanged += new System.EventHandler(this.cmbVisitTimeFromMinutes_SelectedIndexChanged);
            this.cmbVisitTimeFromMinutes.SelectedValueChanged += new System.EventHandler(this.cmbVisitTimeFromMinutes_SelectedValueChanged);
            // 
            // cmbVisitTimeFromHr
            // 
            this.cmbVisitTimeFromHr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbVisitTimeFromHr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisitTimeFromHr.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVisitTimeFromHr.FormattingEnabled = true;
            this.cmbVisitTimeFromHr.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cmbVisitTimeFromHr.Location = new System.Drawing.Point(1280, 320);
            this.cmbVisitTimeFromHr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbVisitTimeFromHr.Name = "cmbVisitTimeFromHr";
            this.cmbVisitTimeFromHr.Size = new System.Drawing.Size(64, 30);
            this.cmbVisitTimeFromHr.TabIndex = 8;
            this.cmbVisitTimeFromHr.SelectedIndexChanged += new System.EventHandler(this.cmbVisitTimeFromHr_SelectedIndexChanged);
            this.cmbVisitTimeFromHr.SelectedValueChanged += new System.EventHandler(this.cmbVisitTimeFromHr_SelectedValueChanged);
            // 
            // lblVisitorVisitTime
            // 
            this.lblVisitorVisitTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVisitorVisitTime.AutoSize = true;
            this.lblVisitorVisitTime.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVisitorVisitTime.Location = new System.Drawing.Point(1180, 320);
            this.lblVisitorVisitTime.Name = "lblVisitorVisitTime";
            this.lblVisitorVisitTime.Size = new System.Drawing.Size(56, 19);
            this.lblVisitorVisitTime.TabIndex = 19;
            this.lblVisitorVisitTime.Text = "TIME ";
            // 
            // btnVisitorDocument
            // 
            this.btnVisitorDocument.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVisitorDocument.BackColor = System.Drawing.Color.IndianRed;
            this.btnVisitorDocument.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVisitorDocument.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnVisitorDocument.FlatAppearance.BorderSize = 0;
            this.btnVisitorDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisitorDocument.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisitorDocument.ForeColor = System.Drawing.Color.White;
            this.btnVisitorDocument.Image = global::GuestRegistrationWinForm.Properties.Resources.iconsDocument;
            this.btnVisitorDocument.Location = new System.Drawing.Point(674, 661);
            this.btnVisitorDocument.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVisitorDocument.Name = "btnVisitorDocument";
            this.btnVisitorDocument.Size = new System.Drawing.Size(280, 50);
            this.btnVisitorDocument.TabIndex = 16;
            this.btnVisitorDocument.Text = "PRINT DOCUMENT";
            this.btnVisitorDocument.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVisitorDocument.UseVisualStyleBackColor = false;
            this.btnVisitorDocument.Click += new System.EventHandler(this.btnVisitorDocument_Click);
            // 
            // dtVisitorVisitDate
            // 
            this.dtVisitorVisitDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtVisitorVisitDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtVisitorVisitDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVisitorVisitDate.Location = new System.Drawing.Point(800, 320);
            this.dtVisitorVisitDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtVisitorVisitDate.Name = "dtVisitorVisitDate";
            this.dtVisitorVisitDate.Size = new System.Drawing.Size(334, 30);
            this.dtVisitorVisitDate.TabIndex = 7;
            this.dtVisitorVisitDate.Value = new System.DateTime(2023, 12, 11, 6, 43, 52, 0);
            this.dtVisitorVisitDate.ValueChanged += new System.EventHandler(this.dtVisitorVisitDate_ValueChanged);
            // 
            // lblVsc
            // 
            this.lblVsc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVsc.AutoSize = true;
            this.lblVsc.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVsc.Location = new System.Drawing.Point(350, 560);
            this.lblVsc.Name = "lblVsc";
            this.lblVsc.Size = new System.Drawing.Size(212, 19);
            this.lblVsc.TabIndex = 18;
            this.lblVsc.Text = "SECURITY CONTROLLER";
            // 
            // cmbVisitorProductionManager
            // 
            this.cmbVisitorProductionManager.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbVisitorProductionManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisitorProductionManager.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVisitorProductionManager.FormattingEnabled = true;
            this.cmbVisitorProductionManager.Location = new System.Drawing.Point(800, 500);
            this.cmbVisitorProductionManager.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbVisitorProductionManager.Name = "cmbVisitorProductionManager";
            this.cmbVisitorProductionManager.Size = new System.Drawing.Size(332, 30);
            this.cmbVisitorProductionManager.TabIndex = 14;
            this.cmbVisitorProductionManager.SelectedIndexChanged += new System.EventHandler(this.cmbVisitorProductionManager_SelectedIndexChanged_1);
            // 
            // cmbVisitorPersonToVisited
            // 
            this.cmbVisitorPersonToVisited.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbVisitorPersonToVisited.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisitorPersonToVisited.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVisitorPersonToVisited.FormattingEnabled = true;
            this.cmbVisitorPersonToVisited.Location = new System.Drawing.Point(800, 200);
            this.cmbVisitorPersonToVisited.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbVisitorPersonToVisited.Name = "cmbVisitorPersonToVisited";
            this.cmbVisitorPersonToVisited.Size = new System.Drawing.Size(332, 30);
            this.cmbVisitorPersonToVisited.TabIndex = 5;
            this.cmbVisitorPersonToVisited.SelectedIndexChanged += new System.EventHandler(this.cmbVisitorPersonToVisited_SelectedIndexChanged_1);
            // 
            // cmbVisitorAreaVisited
            // 
            this.cmbVisitorAreaVisited.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbVisitorAreaVisited.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisitorAreaVisited.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVisitorAreaVisited.FormattingEnabled = true;
            this.cmbVisitorAreaVisited.Location = new System.Drawing.Point(800, 260);
            this.cmbVisitorAreaVisited.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbVisitorAreaVisited.Name = "cmbVisitorAreaVisited";
            this.cmbVisitorAreaVisited.Size = new System.Drawing.Size(334, 30);
            this.cmbVisitorAreaVisited.TabIndex = 6;
            this.cmbVisitorAreaVisited.SelectedIndexChanged += new System.EventHandler(this.cmbVisitorAreaVisited_SelectedIndexChanged_1);
            // 
            // cmbvisitorDeptManager
            // 
            this.cmbvisitorDeptManager.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbvisitorDeptManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbvisitorDeptManager.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbvisitorDeptManager.FormattingEnabled = true;
            this.cmbvisitorDeptManager.Location = new System.Drawing.Point(800, 440);
            this.cmbvisitorDeptManager.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbvisitorDeptManager.Name = "cmbvisitorDeptManager";
            this.cmbvisitorDeptManager.Size = new System.Drawing.Size(332, 30);
            this.cmbvisitorDeptManager.TabIndex = 13;
            this.cmbvisitorDeptManager.SelectedIndexChanged += new System.EventHandler(this.cmbvisitorDeptManager_SelectedIndexChanged_1);
            // 
            // lblVprodmangr
            // 
            this.lblVprodmangr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVprodmangr.AutoSize = true;
            this.lblVprodmangr.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVprodmangr.Location = new System.Drawing.Point(350, 500);
            this.lblVprodmangr.Name = "lblVprodmangr";
            this.lblVprodmangr.Size = new System.Drawing.Size(285, 19);
            this.lblVprodmangr.TabIndex = 12;
            this.lblVprodmangr.Text = "PRODUCTION MANAGER/DEPUTY";
            // 
            // lblVdeptmang
            // 
            this.lblVdeptmang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVdeptmang.AutoSize = true;
            this.lblVdeptmang.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVdeptmang.Location = new System.Drawing.Point(350, 440);
            this.lblVdeptmang.Name = "lblVdeptmang";
            this.lblVdeptmang.Size = new System.Drawing.Size(214, 19);
            this.lblVdeptmang.TabIndex = 11;
            this.lblVdeptmang.Text = "DEPARTMENT MANAGER";
            // 
            // lblVduration
            // 
            this.lblVduration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVduration.AutoSize = true;
            this.lblVduration.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVduration.Location = new System.Drawing.Point(350, 380);
            this.lblVduration.Name = "lblVduration";
            this.lblVduration.Size = new System.Drawing.Size(169, 19);
            this.lblVduration.TabIndex = 10;
            this.lblVduration.Text = "VISIT DURATION TO";
            // 
            // lblVdate
            // 
            this.lblVdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVdate.AutoSize = true;
            this.lblVdate.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVdate.Location = new System.Drawing.Point(350, 320);
            this.lblVdate.Name = "lblVdate";
            this.lblVdate.Size = new System.Drawing.Size(154, 19);
            this.lblVdate.TabIndex = 9;
            this.lblVdate.Text = "VISIT DATE FROM";
            // 
            // lblVarea
            // 
            this.lblVarea.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVarea.AutoSize = true;
            this.lblVarea.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVarea.Location = new System.Drawing.Point(350, 260);
            this.lblVarea.Name = "lblVarea";
            this.lblVarea.Size = new System.Drawing.Size(176, 19);
            this.lblVarea.TabIndex = 8;
            this.lblVarea.Text = "AREA TO BE VISITED";
            // 
            // lblVprsnvisit
            // 
            this.lblVprsnvisit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVprsnvisit.AutoSize = true;
            this.lblVprsnvisit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVprsnvisit.Location = new System.Drawing.Point(350, 200);
            this.lblVprsnvisit.Name = "lblVprsnvisit";
            this.lblVprsnvisit.Size = new System.Drawing.Size(200, 19);
            this.lblVprsnvisit.TabIndex = 7;
            this.lblVprsnvisit.Text = "PERSON TO BE VISITED";
            // 
            // cmbVistorReasonForVisit
            // 
            this.cmbVistorReasonForVisit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbVistorReasonForVisit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVistorReasonForVisit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVistorReasonForVisit.FormattingEnabled = true;
            this.cmbVistorReasonForVisit.Location = new System.Drawing.Point(800, 140);
            this.cmbVistorReasonForVisit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbVistorReasonForVisit.Name = "cmbVistorReasonForVisit";
            this.cmbVistorReasonForVisit.Size = new System.Drawing.Size(334, 30);
            this.cmbVistorReasonForVisit.TabIndex = 4;
            this.cmbVistorReasonForVisit.SelectedIndexChanged += new System.EventHandler(this.cmbVistorReasonForVisit_SelectedIndexChanged_1);
            // 
            // cmbVisitorComp
            // 
            this.cmbVisitorComp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbVisitorComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisitorComp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVisitorComp.FormattingEnabled = true;
            this.cmbVisitorComp.Location = new System.Drawing.Point(800, 80);
            this.cmbVisitorComp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbVisitorComp.Name = "cmbVisitorComp";
            this.cmbVisitorComp.Size = new System.Drawing.Size(334, 30);
            this.cmbVisitorComp.TabIndex = 2;
            this.cmbVisitorComp.SelectedIndexChanged += new System.EventHandler(this.cmbVisitorComp_SelectedIndexChanged_1);
            // 
            // txtVisitorComp
            // 
            this.txtVisitorComp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtVisitorComp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVisitorComp.Location = new System.Drawing.Point(1174, 80);
            this.txtVisitorComp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVisitorComp.Name = "txtVisitorComp";
            this.txtVisitorComp.Size = new System.Drawing.Size(334, 30);
            this.txtVisitorComp.TabIndex = 3;
            this.txtVisitorComp.TextChanged += new System.EventHandler(this.txtVisitorComp_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormVisitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1583, 722);
            this.Controls.Add(this.panelVisitor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormVisitor";
            this.Text = "FormVisitor";
            this.Load += new System.EventHandler(this.FormVisitor_Load);
            this.panelVisitor.ResumeLayout(false);
            this.panelVisitor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.Button btnVisitorDocument;
        private System.Windows.Forms.ComboBox cmbVisitorVisitTimeToMinutes;
        private System.Windows.Forms.ComboBox cmbVisitorVisitTimeToHr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVisitTimeFromMinutes;
        private System.Windows.Forms.ComboBox cmbVisitTimeFromHr;
        private System.Windows.Forms.Label lblVisitorVisitTime;
        private System.Windows.Forms.DateTimePicker dtVisitorVisitDuration;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cmbVisitorSecurityController;
        private System.Windows.Forms.ComboBox cmbVisitorTitle;
    }
}