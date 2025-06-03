namespace Mnagement_system
{
    partial class SalesManagementForm
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
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddSale = new System.Windows.Forms.Button();
            this.btnUpadateSale = new System.Windows.Forms.Button();
            this.btnDeleteSale = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSaleDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPaymentMethod = new System.Windows.Forms.TextBox();
            this.txtSaleAmount = new System.Windows.Forms.TextBox();
            this.txtCarID = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSaleDateU = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSaleAmountU = new System.Windows.Forms.TextBox();
            this.txtPaymentMethodU = new System.Windows.Forms.TextBox();
            this.txtSaleID = new System.Windows.Forms.TextBox();
            this.txtCarIDU = new System.Windows.Forms.TextBox();
            this.txtCustomerIDU = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSaleIDD = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtSaleIDR = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnGenerateReceipt = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSales
            // 
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.Location = new System.Drawing.Point(625, 64);
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.Size = new System.Drawing.Size(724, 666);
            this.dataGridViewSales.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(418, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "SALES MANAGEMENT";
            // 
            // btnAddSale
            // 
            this.btnAddSale.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnAddSale.Location = new System.Drawing.Point(444, 113);
            this.btnAddSale.Name = "btnAddSale";
            this.btnAddSale.Size = new System.Drawing.Size(109, 38);
            this.btnAddSale.TabIndex = 2;
            this.btnAddSale.Text = "Add Sale";
            this.btnAddSale.UseVisualStyleBackColor = false;
            this.btnAddSale.Click += new System.EventHandler(this.btnAddSale_Click_1);
            // 
            // btnUpadateSale
            // 
            this.btnUpadateSale.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnUpadateSale.Location = new System.Drawing.Point(292, 158);
            this.btnUpadateSale.Name = "btnUpadateSale";
            this.btnUpadateSale.Size = new System.Drawing.Size(127, 38);
            this.btnUpadateSale.TabIndex = 3;
            this.btnUpadateSale.Text = "Update Sale";
            this.btnUpadateSale.UseVisualStyleBackColor = false;
            this.btnUpadateSale.Click += new System.EventHandler(this.btnUpadateSale_Click);
            // 
            // btnDeleteSale
            // 
            this.btnDeleteSale.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnDeleteSale.Location = new System.Drawing.Point(79, 68);
            this.btnDeleteSale.Name = "btnDeleteSale";
            this.btnDeleteSale.Size = new System.Drawing.Size(116, 38);
            this.btnDeleteSale.TabIndex = 4;
            this.btnDeleteSale.Text = "Delete Sale";
            this.btnDeleteSale.UseVisualStyleBackColor = false;
            this.btnDeleteSale.Click += new System.EventHandler(this.btnDeleteSale_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkCyan;
            this.button1.Location = new System.Drawing.Point(1285, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.txtSaleDate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPaymentMethod);
            this.panel1.Controls.Add(this.txtSaleAmount);
            this.panel1.Controls.Add(this.txtCarID);
            this.panel1.Controls.Add(this.txtCustomerID);
            this.panel1.Controls.Add(this.btnAddSale);
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 172);
            this.panel1.TabIndex = 6;
            // 
            // txtSaleDate
            // 
            this.txtSaleDate.Location = new System.Drawing.Point(139, 111);
            this.txtSaleDate.Name = "txtSaleDate";
            this.txtSaleDate.Size = new System.Drawing.Size(155, 29);
            this.txtSaleDate.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(383, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 44);
            this.label6.TabIndex = 12;
            this.label6.Text = "Payment\r\nMethod :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(343, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "Sale Amount :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sale Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "CarID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "CustomerID :";
            // 
            // txtPaymentMethod
            // 
            this.txtPaymentMethod.Location = new System.Drawing.Point(472, 68);
            this.txtPaymentMethod.Name = "txtPaymentMethod";
            this.txtPaymentMethod.Size = new System.Drawing.Size(132, 29);
            this.txtPaymentMethod.TabIndex = 7;
            // 
            // txtSaleAmount
            // 
            this.txtSaleAmount.Location = new System.Drawing.Point(472, 24);
            this.txtSaleAmount.Name = "txtSaleAmount";
            this.txtSaleAmount.Size = new System.Drawing.Size(132, 29);
            this.txtSaleAmount.TabIndex = 6;
            // 
            // txtCarID
            // 
            this.txtCarID.Location = new System.Drawing.Point(139, 68);
            this.txtCarID.Name = "txtCarID";
            this.txtCarID.Size = new System.Drawing.Size(155, 29);
            this.txtCarID.TabIndex = 4;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(139, 24);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(155, 29);
            this.txtCustomerID.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.txtSaleDateU);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtSaleAmountU);
            this.panel2.Controls.Add(this.txtPaymentMethodU);
            this.panel2.Controls.Add(this.txtSaleID);
            this.panel2.Controls.Add(this.txtCarIDU);
            this.panel2.Controls.Add(this.txtCustomerIDU);
            this.panel2.Controls.Add(this.btnUpadateSale);
            this.panel2.Location = new System.Drawing.Point(0, 242);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(619, 208);
            this.panel2.TabIndex = 7;
            // 
            // txtSaleDateU
            // 
            this.txtSaleDateU.Location = new System.Drawing.Point(449, 20);
            this.txtSaleDateU.Name = "txtSaleDateU";
            this.txtSaleDateU.Size = new System.Drawing.Size(155, 29);
            this.txtSaleDateU.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(360, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 44);
            this.label12.TabIndex = 16;
            this.label12.Text = "Payment\r\nMethod :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(320, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 22);
            this.label11.TabIndex = 15;
            this.label11.Text = "Sale Amount :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(344, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 22);
            this.label10.TabIndex = 14;
            this.label10.Text = "Sale Date :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(60, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 22);
            this.label9.TabIndex = 13;
            this.label9.Text = "CarID :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 22);
            this.label8.TabIndex = 12;
            this.label8.Text = "CustomerID :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "SaleID :";
            // 
            // txtSaleAmountU
            // 
            this.txtSaleAmountU.Location = new System.Drawing.Point(449, 66);
            this.txtSaleAmountU.Name = "txtSaleAmountU";
            this.txtSaleAmountU.Size = new System.Drawing.Size(155, 29);
            this.txtSaleAmountU.TabIndex = 9;
            // 
            // txtPaymentMethodU
            // 
            this.txtPaymentMethodU.Location = new System.Drawing.Point(449, 110);
            this.txtPaymentMethodU.Name = "txtPaymentMethodU";
            this.txtPaymentMethodU.Size = new System.Drawing.Size(155, 29);
            this.txtPaymentMethodU.TabIndex = 8;
            // 
            // txtSaleID
            // 
            this.txtSaleID.Location = new System.Drawing.Point(139, 20);
            this.txtSaleID.Name = "txtSaleID";
            this.txtSaleID.Size = new System.Drawing.Size(155, 29);
            this.txtSaleID.TabIndex = 7;
            // 
            // txtCarIDU
            // 
            this.txtCarIDU.Location = new System.Drawing.Point(139, 110);
            this.txtCarIDU.Name = "txtCarIDU";
            this.txtCarIDU.Size = new System.Drawing.Size(155, 29);
            this.txtCarIDU.TabIndex = 6;
            // 
            // txtCustomerIDU
            // 
            this.txtCustomerIDU.Location = new System.Drawing.Point(139, 66);
            this.txtCustomerIDU.Name = "txtCustomerIDU";
            this.txtCustomerIDU.Size = new System.Drawing.Size(155, 29);
            this.txtCustomerIDU.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.txtSaleIDD);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.btnDeleteSale);
            this.panel3.Location = new System.Drawing.Point(0, 456);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(304, 118);
            this.panel3.TabIndex = 7;
            // 
            // txtSaleIDD
            // 
            this.txtSaleIDD.Location = new System.Drawing.Point(139, 23);
            this.txtSaleIDD.Name = "txtSaleIDD";
            this.txtSaleIDD.Size = new System.Drawing.Size(155, 29);
            this.txtSaleIDD.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(57, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 22);
            this.label13.TabIndex = 9;
            this.label13.Text = "SaleID :";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Controls.Add(this.txtSaleIDR);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.btnGenerateReceipt);
            this.panel4.Location = new System.Drawing.Point(0, 580);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(304, 122);
            this.panel4.TabIndex = 8;
            // 
            // txtSaleIDR
            // 
            this.txtSaleIDR.Location = new System.Drawing.Point(116, 17);
            this.txtSaleIDR.Name = "txtSaleIDR";
            this.txtSaleIDR.Size = new System.Drawing.Size(155, 29);
            this.txtSaleIDR.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(34, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 22);
            this.label14.TabIndex = 11;
            this.label14.Text = "SaleID :";
            // 
            // btnGenerateReceipt
            // 
            this.btnGenerateReceipt.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnGenerateReceipt.Location = new System.Drawing.Point(61, 61);
            this.btnGenerateReceipt.Name = "btnGenerateReceipt";
            this.btnGenerateReceipt.Size = new System.Drawing.Size(170, 39);
            this.btnGenerateReceipt.TabIndex = 0;
            this.btnGenerateReceipt.Text = "Generate Receipt";
            this.btnGenerateReceipt.UseVisualStyleBackColor = false;
            this.btnGenerateReceipt.Click += new System.EventHandler(this.btnGenerateReceipt_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Gray;
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(0, -3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(106, 31);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // SalesManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewSales);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "SalesManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalesManagementForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SalesManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddSale;
        private System.Windows.Forms.Button btnUpadateSale;
        private System.Windows.Forms.Button btnDeleteSale;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPaymentMethod;
        private System.Windows.Forms.TextBox txtSaleAmount;
        private System.Windows.Forms.TextBox txtCarID;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSaleAmountU;
        private System.Windows.Forms.TextBox txtPaymentMethodU;
        private System.Windows.Forms.TextBox txtSaleID;
        private System.Windows.Forms.TextBox txtCarIDU;
        private System.Windows.Forms.TextBox txtCustomerIDU;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker txtSaleDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSaleIDD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker txtSaleDateU;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnGenerateReceipt;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSaleIDR;
        private System.Windows.Forms.Label label14;
    }
}