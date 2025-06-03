using System;
using System.Windows.Forms;

namespace Mnagement_system
{
    partial class DashboardForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelNav = new System.Windows.Forms.Panel();
            this.btnInventoryManagement = new System.Windows.Forms.Button();
            this.btnTransactionManagement = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnOrderManagement = new System.Windows.Forms.Button();
            this.btnStaffManagement = new System.Windows.Forms.Button();
            this.btnSalesManagement = new System.Windows.Forms.Button();
            this.btnCustomerManagement = new System.Windows.Forms.Button();
            this.btnCarManagement = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelUpdates = new System.Windows.Forms.Panel();
            this.panelBestModel = new System.Windows.Forms.Panel();
            this.lblBestModel = new System.Windows.Forms.Label();
            this.lblBestModelTitle = new System.Windows.Forms.Label();
            this.panelCarsSold = new System.Windows.Forms.Panel();
            this.lblCarsSoldCount = new System.Windows.Forms.Label();
            this.lblCarsSoldTitle = new System.Windows.Forms.Label();
            this.panelPending = new System.Windows.Forms.Panel();
            this.lblPendingCount = new System.Windows.Forms.Label();
            this.lblPendingTitle = new System.Windows.Forms.Label();
            this.panelCustomers = new System.Windows.Forms.Panel();
            this.lblCustomersCount = new System.Windows.Forms.Label();
            this.lblCustomersTitle = new System.Windows.Forms.Label();
            this.dgvLowStockParts = new System.Windows.Forms.DataGridView();
            this.lblLowStockHeader = new System.Windows.Forms.Label();
            this.btnRestock = new System.Windows.Forms.Button();
            this.dgvPendingApprovals = new System.Windows.Forms.DataGridView();
            this.lblPendingApprovals = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.dgvReportResults = new System.Windows.Forms.DataGridView();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.pnlReportSummary = new System.Windows.Forms.Panel();
            this.btnCreateRestock = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LoadLowStockPart = new System.Windows.Forms.DataGridView();
            this.panelNav.SuspendLayout();
            this.panelUpdates.SuspendLayout();
            this.panelBestModel.SuspendLayout();
            this.panelCarsSold.SuspendLayout();
            this.panelPending.SuspendLayout();
            this.panelCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStockParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingApprovals)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportResults)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlReportSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadLowStockPart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(602, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "DASHBOARD";
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.DimGray;
            this.panelNav.Controls.Add(this.btnInventoryManagement);
            this.panelNav.Controls.Add(this.btnTransactionManagement);
            this.panelNav.Controls.Add(this.btnLogout);
            this.panelNav.Controls.Add(this.btnOrderManagement);
            this.panelNav.Controls.Add(this.btnStaffManagement);
            this.panelNav.Controls.Add(this.btnSalesManagement);
            this.panelNav.Controls.Add(this.btnCustomerManagement);
            this.panelNav.Controls.Add(this.btnCarManagement);
            this.panelNav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelNav.Location = new System.Drawing.Point(0, 45);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(194, 701);
            this.panelNav.TabIndex = 1;
            // 
            // btnInventoryManagement
            // 
            this.btnInventoryManagement.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnInventoryManagement.Location = new System.Drawing.Point(0, 377);
            this.btnInventoryManagement.Name = "btnInventoryManagement";
            this.btnInventoryManagement.Size = new System.Drawing.Size(178, 54);
            this.btnInventoryManagement.TabIndex = 7;
            this.btnInventoryManagement.Text = "Inventory Management";
            this.btnInventoryManagement.UseVisualStyleBackColor = false;
            // 
            // btnTransactionManagement
            // 
            this.btnTransactionManagement.AutoEllipsis = true;
            this.btnTransactionManagement.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnTransactionManagement.Location = new System.Drawing.Point(0, 307);
            this.btnTransactionManagement.Name = "btnTransactionManagement";
            this.btnTransactionManagement.Size = new System.Drawing.Size(178, 54);
            this.btnTransactionManagement.TabIndex = 6;
            this.btnTransactionManagement.Text = "Transaction Management";
            this.btnTransactionManagement.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnLogout.Location = new System.Drawing.Point(4, 660);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(178, 29);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnOrderManagement
            // 
            this.btnOrderManagement.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnOrderManagement.Location = new System.Drawing.Point(0, 179);
            this.btnOrderManagement.Name = "btnOrderManagement";
            this.btnOrderManagement.Size = new System.Drawing.Size(181, 39);
            this.btnOrderManagement.TabIndex = 4;
            this.btnOrderManagement.Text = "Order Management";
            this.btnOrderManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnOrderManagement.UseVisualStyleBackColor = false;
            // 
            // btnStaffManagement
            // 
            this.btnStaffManagement.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnStaffManagement.Location = new System.Drawing.Point(3, 127);
            this.btnStaffManagement.Name = "btnStaffManagement";
            this.btnStaffManagement.Size = new System.Drawing.Size(178, 36);
            this.btnStaffManagement.TabIndex = 3;
            this.btnStaffManagement.Text = "Staff Management";
            this.btnStaffManagement.UseVisualStyleBackColor = false;
            // 
            // btnSalesManagement
            // 
            this.btnSalesManagement.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnSalesManagement.Location = new System.Drawing.Point(4, 74);
            this.btnSalesManagement.Name = "btnSalesManagement";
            this.btnSalesManagement.Size = new System.Drawing.Size(178, 38);
            this.btnSalesManagement.TabIndex = 2;
            this.btnSalesManagement.Text = "Sales Management";
            this.btnSalesManagement.UseVisualStyleBackColor = false;
            // 
            // btnCustomerManagement
            // 
            this.btnCustomerManagement.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCustomerManagement.Location = new System.Drawing.Point(4, 234);
            this.btnCustomerManagement.Name = "btnCustomerManagement";
            this.btnCustomerManagement.Size = new System.Drawing.Size(178, 54);
            this.btnCustomerManagement.TabIndex = 1;
            this.btnCustomerManagement.Text = "Customer Management";
            this.btnCustomerManagement.UseVisualStyleBackColor = false;
            // 
            // btnCarManagement
            // 
            this.btnCarManagement.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCarManagement.Location = new System.Drawing.Point(3, 22);
            this.btnCarManagement.Name = "btnCarManagement";
            this.btnCarManagement.Size = new System.Drawing.Size(179, 33);
            this.btnCarManagement.TabIndex = 0;
            this.btnCarManagement.Text = "Car Management";
            this.btnCarManagement.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1239, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Version 1.0.0";
            // 
            // panelUpdates
            // 
            this.panelUpdates.BackColor = System.Drawing.Color.DimGray;
            this.panelUpdates.Controls.Add(this.panelBestModel);
            this.panelUpdates.Controls.Add(this.panelCarsSold);
            this.panelUpdates.Controls.Add(this.panelPending);
            this.panelUpdates.Controls.Add(this.panelCustomers);
            this.panelUpdates.Location = new System.Drawing.Point(750, 51);
            this.panelUpdates.Name = "panelUpdates";
            this.panelUpdates.Size = new System.Drawing.Size(600, 172);
            this.panelUpdates.TabIndex = 4;
            // 
            // panelBestModel
            // 
            this.panelBestModel.BackColor = System.Drawing.Color.LightGray;
            this.panelBestModel.Controls.Add(this.lblBestModel);
            this.panelBestModel.Controls.Add(this.lblBestModelTitle);
            this.panelBestModel.Location = new System.Drawing.Point(457, 12);
            this.panelBestModel.Name = "panelBestModel";
            this.panelBestModel.Size = new System.Drawing.Size(131, 139);
            this.panelBestModel.TabIndex = 3;
            // 
            // lblBestModel
            // 
            this.lblBestModel.AutoSize = true;
            this.lblBestModel.Location = new System.Drawing.Point(32, 78);
            this.lblBestModel.Name = "lblBestModel";
            this.lblBestModel.Size = new System.Drawing.Size(20, 22);
            this.lblBestModel.TabIndex = 1;
            this.lblBestModel.Text = "0";
            // 
            // lblBestModelTitle
            // 
            this.lblBestModelTitle.AutoSize = true;
            this.lblBestModelTitle.Location = new System.Drawing.Point(16, 40);
            this.lblBestModelTitle.Name = "lblBestModelTitle";
            this.lblBestModelTitle.Size = new System.Drawing.Size(103, 22);
            this.lblBestModelTitle.TabIndex = 0;
            this.lblBestModelTitle.Text = "Best Model";
            // 
            // panelCarsSold
            // 
            this.panelCarsSold.BackColor = System.Drawing.Color.LightGray;
            this.panelCarsSold.Controls.Add(this.lblCarsSoldCount);
            this.panelCarsSold.Controls.Add(this.lblCarsSoldTitle);
            this.panelCarsSold.Location = new System.Drawing.Point(324, 12);
            this.panelCarsSold.Name = "panelCarsSold";
            this.panelCarsSold.Size = new System.Drawing.Size(117, 139);
            this.panelCarsSold.TabIndex = 2;
            // 
            // lblCarsSoldCount
            // 
            this.lblCarsSoldCount.AutoSize = true;
            this.lblCarsSoldCount.Location = new System.Drawing.Point(51, 78);
            this.lblCarsSoldCount.Name = "lblCarsSoldCount";
            this.lblCarsSoldCount.Size = new System.Drawing.Size(20, 22);
            this.lblCarsSoldCount.TabIndex = 1;
            this.lblCarsSoldCount.Text = "0";
            // 
            // lblCarsSoldTitle
            // 
            this.lblCarsSoldTitle.AutoSize = true;
            this.lblCarsSoldTitle.Location = new System.Drawing.Point(12, 40);
            this.lblCarsSoldTitle.Name = "lblCarsSoldTitle";
            this.lblCarsSoldTitle.Size = new System.Drawing.Size(91, 22);
            this.lblCarsSoldTitle.TabIndex = 0;
            this.lblCarsSoldTitle.Text = "Cars Sold";
            // 
            // panelPending
            // 
            this.panelPending.BackColor = System.Drawing.Color.LightGray;
            this.panelPending.Controls.Add(this.lblPendingCount);
            this.panelPending.Controls.Add(this.lblPendingTitle);
            this.panelPending.Location = new System.Drawing.Point(152, 12);
            this.panelPending.Name = "panelPending";
            this.panelPending.Size = new System.Drawing.Size(155, 139);
            this.panelPending.TabIndex = 1;
            // 
            // lblPendingCount
            // 
            this.lblPendingCount.AutoSize = true;
            this.lblPendingCount.Location = new System.Drawing.Point(78, 78);
            this.lblPendingCount.Name = "lblPendingCount";
            this.lblPendingCount.Size = new System.Drawing.Size(20, 22);
            this.lblPendingCount.TabIndex = 1;
            this.lblPendingCount.Text = "0";
            // 
            // lblPendingTitle
            // 
            this.lblPendingTitle.AutoSize = true;
            this.lblPendingTitle.Location = new System.Drawing.Point(10, 40);
            this.lblPendingTitle.Name = "lblPendingTitle";
            this.lblPendingTitle.Size = new System.Drawing.Size(139, 22);
            this.lblPendingTitle.TabIndex = 0;
            this.lblPendingTitle.Text = "Pending Orders";
            // 
            // panelCustomers
            // 
            this.panelCustomers.BackColor = System.Drawing.Color.LightGray;
            this.panelCustomers.Controls.Add(this.lblCustomersCount);
            this.panelCustomers.Controls.Add(this.lblCustomersTitle);
            this.panelCustomers.Location = new System.Drawing.Point(13, 12);
            this.panelCustomers.Name = "panelCustomers";
            this.panelCustomers.Size = new System.Drawing.Size(122, 139);
            this.panelCustomers.TabIndex = 0;
            // 
            // lblCustomersCount
            // 
            this.lblCustomersCount.AutoSize = true;
            this.lblCustomersCount.Location = new System.Drawing.Point(49, 78);
            this.lblCustomersCount.Name = "lblCustomersCount";
            this.lblCustomersCount.Size = new System.Drawing.Size(20, 22);
            this.lblCustomersCount.TabIndex = 1;
            this.lblCustomersCount.Text = "0";
            // 
            // lblCustomersTitle
            // 
            this.lblCustomersTitle.AutoSize = true;
            this.lblCustomersTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCustomersTitle.Location = new System.Drawing.Point(11, 40);
            this.lblCustomersTitle.Name = "lblCustomersTitle";
            this.lblCustomersTitle.Size = new System.Drawing.Size(98, 22);
            this.lblCustomersTitle.TabIndex = 0;
            this.lblCustomersTitle.Text = "Customers";
            // 
            // dgvLowStockParts
            // 
            this.dgvLowStockParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowStockParts.Location = new System.Drawing.Point(6, 47);
            this.dgvLowStockParts.Name = "dgvLowStockParts";
            this.dgvLowStockParts.Size = new System.Drawing.Size(535, 178);
            this.dgvLowStockParts.TabIndex = 6;
            // 
            // lblLowStockHeader
            // 
            this.lblLowStockHeader.AutoSize = true;
            this.lblLowStockHeader.Location = new System.Drawing.Point(28, 14);
            this.lblLowStockHeader.Name = "lblLowStockHeader";
            this.lblLowStockHeader.Size = new System.Drawing.Size(338, 22);
            this.lblLowStockHeader.TabIndex = 7;
            this.lblLowStockHeader.Text = "⚠ Low Stock Parts (Needs Restocking)";
            // 
            // btnRestock
            // 
            this.btnRestock.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnRestock.Location = new System.Drawing.Point(153, 231);
            this.btnRestock.Name = "btnRestock";
            this.btnRestock.Size = new System.Drawing.Size(213, 32);
            this.btnRestock.TabIndex = 8;
            this.btnRestock.Text = "Create Restock Order";
            this.btnRestock.UseVisualStyleBackColor = false;
            // 
            // dgvPendingApprovals
            // 
            this.dgvPendingApprovals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingApprovals.Location = new System.Drawing.Point(6, 27);
            this.dgvPendingApprovals.Name = "dgvPendingApprovals";
            this.dgvPendingApprovals.Size = new System.Drawing.Size(591, 124);
            this.dgvPendingApprovals.TabIndex = 9;
            this.dgvPendingApprovals.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPendingApprovals_CellContentClick);
            // 
            // lblPendingApprovals
            // 
            this.lblPendingApprovals.AutoSize = true;
            this.lblPendingApprovals.Location = new System.Drawing.Point(217, 2);
            this.lblPendingApprovals.Name = "lblPendingApprovals";
            this.lblPendingApprovals.Size = new System.Drawing.Size(20, 22);
            this.lblPendingApprovals.TabIndex = 10;
            this.lblPendingApprovals.Text = "0";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.dgvPendingApprovals);
            this.panel3.Controls.Add(this.lblPendingApprovals);
            this.panel3.Controls.Add(this.btnReject);
            this.panel3.Controls.Add(this.btnApprove);
            this.panel3.Location = new System.Drawing.Point(750, 224);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 198);
            this.panel3.TabIndex = 11;
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(379, 157);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 32);
            this.btnReject.TabIndex = 1;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click_1);
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(100, 157);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(88, 33);
            this.btnApprove.TabIndex = 0;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click_1);
            // 
            // cmbReportType
            // 
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "Sales Summary",
            "Inventory Status",
            "Customer Activity",
            "Staff Performance",
            "Financial Overview"});
            this.cmbReportType.Location = new System.Drawing.Point(10, 38);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(147, 30);
            this.cmbReportType.TabIndex = 0;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpStartDate.Location = new System.Drawing.Point(166, 38);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(103, 29);
            this.dtpStartDate.TabIndex = 1;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpEndDate.Location = new System.Drawing.Point(283, 38);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(112, 29);
            this.dtpEndDate.TabIndex = 2;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnGenerateReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateReport.Location = new System.Drawing.Point(424, 34);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(164, 34);
            this.btnGenerateReport.TabIndex = 3;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click_1);
            // 
            // dgvReportResults
            // 
            this.dgvReportResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportResults.Location = new System.Drawing.Point(10, 74);
            this.dgvReportResults.Name = "dgvReportResults";
            this.dgvReportResults.Size = new System.Drawing.Size(578, 193);
            this.dgvReportResults.TabIndex = 4;
            this.dgvReportResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReportResults_CellContentClick);
            // 
            // btnExportReport
            // 
            this.btnExportReport.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnExportReport.Location = new System.Drawing.Point(221, 273);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(151, 32);
            this.btnExportReport.TabIndex = 5;
            this.btnExportReport.Text = "Export Report";
            this.btnExportReport.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.btnPrintReport);
            this.panel1.Controls.Add(this.btnExportReport);
            this.panel1.Controls.Add(this.dgvReportResults);
            this.panel1.Controls.Add(this.btnGenerateReport);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Controls.Add(this.cmbReportType);
            this.panel1.Location = new System.Drawing.Point(750, 428);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 318);
            this.panel1.TabIndex = 5;
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackColor = System.Drawing.Color.DarkGray;
            this.btnPrintReport.Location = new System.Drawing.Point(424, 272);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(131, 33);
            this.btnPrintReport.TabIndex = 6;
            this.btnPrintReport.Text = "Print Report";
            this.btnPrintReport.UseVisualStyleBackColor = false;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // pnlReportSummary
            // 
            this.pnlReportSummary.BackColor = System.Drawing.Color.DimGray;
            this.pnlReportSummary.Controls.Add(this.btnCreateRestock);
            this.pnlReportSummary.Controls.Add(this.label3);
            this.pnlReportSummary.Controls.Add(this.LoadLowStockPart);
            this.pnlReportSummary.Location = new System.Drawing.Point(203, 45);
            this.pnlReportSummary.Name = "pnlReportSummary";
            this.pnlReportSummary.Size = new System.Drawing.Size(541, 244);
            this.pnlReportSummary.TabIndex = 12;
            // 
            // btnCreateRestock
            // 
            this.btnCreateRestock.Location = new System.Drawing.Point(168, 203);
            this.btnCreateRestock.Name = "btnCreateRestock";
            this.btnCreateRestock.Size = new System.Drawing.Size(215, 32);
            this.btnCreateRestock.TabIndex = 2;
            this.btnCreateRestock.Text = "Create Restock Order";
            this.btnCreateRestock.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(321, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "⚠Low Stock Parts (Need to Restock)";
            // 
            // LoadLowStockPart
            // 
            this.LoadLowStockPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LoadLowStockPart.Location = new System.Drawing.Point(14, 43);
            this.LoadLowStockPart.Name = "LoadLowStockPart";
            this.LoadLowStockPart.Size = new System.Drawing.Size(512, 150);
            this.LoadLowStockPart.TabIndex = 0;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1350, 749);
            this.Controls.Add(this.pnlReportSummary);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelUpdates);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelNav);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashboardForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panelNav.ResumeLayout(false);
            this.panelUpdates.ResumeLayout(false);
            this.panelBestModel.ResumeLayout(false);
            this.panelBestModel.PerformLayout();
            this.panelCarsSold.ResumeLayout(false);
            this.panelCarsSold.PerformLayout();
            this.panelPending.ResumeLayout(false);
            this.panelPending.PerformLayout();
            this.panelCustomers.ResumeLayout(false);
            this.panelCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStockParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingApprovals)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportResults)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlReportSummary.ResumeLayout(false);
            this.pnlReportSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadLowStockPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Button btnCustomerManagement;
        private System.Windows.Forms.Button btnCarManagement;
        private System.Windows.Forms.Button btnTransactionManagement;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnOrderManagement;
        private System.Windows.Forms.Button btnStaffManagement;
        private System.Windows.Forms.Button btnSalesManagement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelUpdates;
        private System.Windows.Forms.Panel panelCustomers;
        private System.Windows.Forms.Label lblCustomersCount;
        private System.Windows.Forms.Label lblCustomersTitle;
        private System.Windows.Forms.Panel panelCarsSold;
        private System.Windows.Forms.Panel panelPending;
        private System.Windows.Forms.Label lblPendingCount;
        private System.Windows.Forms.Label lblPendingTitle;
        private System.Windows.Forms.Panel panelBestModel;
        private System.Windows.Forms.Label lblCarsSoldCount;
        private System.Windows.Forms.Label lblCarsSoldTitle;
        private System.Windows.Forms.Label lblBestModel;
        private System.Windows.Forms.Label lblBestModelTitle;
        private Button btnInventoryManagement;
        private DataGridView dgvLowStockParts;
        private Label lblLowStockHeader;
        private Button btnRestock;
        private DataGridView dgvPendingApprovals;
        private Label lblPendingApprovals;
        private Panel panel3;
        private Button btnReject;
        private Button btnApprove;
        private ComboBox cmbReportType;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnGenerateReport;
        private DataGridView dgvReportResults;
        private Button btnExportReport;
        private Panel panel1;
        private Panel pnlReportSummary;
        private Button btnPrintReport;
        private Label label3;
        private DataGridView LoadLowStockPart;
        private Button btnCreateRestock;
    }
}