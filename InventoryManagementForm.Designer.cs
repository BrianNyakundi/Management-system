namespace Mnagement_system
{
    partial class PartsInventoryForm
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
            this.btnBack = new System.Windows.Forms.Button();
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMinLevel = new System.Windows.Forms.TextBox();
            this.txtSellingPrice = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.ComboBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPartIDU = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblPartsList = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMinLevelU = new System.Windows.Forms.TextBox();
            this.txtSellingPriceU = new System.Windows.Forms.TextBox();
            this.txtPriceU = new System.Windows.Forms.TextBox();
            this.txtQuantityU = new System.Windows.Forms.TextBox();
            this.txtCategoryU = new System.Windows.Forms.ComboBox();
            this.txtPartNumberU = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescriptionU = new System.Windows.Forms.TextBox();
            this.txtPartNameU = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtSupplierU = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnClearU = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPartIDD = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnBack.Location = new System.Drawing.Point(1294, -2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 28);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dataGridViewInventory
            // 
            this.dataGridViewInventory.AllowDrop = true;
            this.dataGridViewInventory.AllowUserToAddRows = false;
            this.dataGridViewInventory.AllowUserToDeleteRows = false;
            this.dataGridViewInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory.EnableHeadersVisualStyles = false;
            this.dataGridViewInventory.Location = new System.Drawing.Point(5, 176);
            this.dataGridViewInventory.MultiSelect = false;
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.ReadOnly = true;
            this.dataGridViewInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInventory.Size = new System.Drawing.Size(744, 569);
            this.dataGridViewInventory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(536, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inventory Management";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.txtMinLevel);
            this.panel1.Controls.Add(this.txtSellingPrice);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.txtQuantity);
            this.panel1.Controls.Add(this.txtCategory);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.txtSupplier);
            this.panel1.Controls.Add(this.txtPartNumber);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.txtPartName);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(755, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 320);
            this.panel1.TabIndex = 3;
            // 
            // txtMinLevel
            // 
            this.txtMinLevel.Location = new System.Drawing.Point(443, 178);
            this.txtMinLevel.Name = "txtMinLevel";
            this.txtMinLevel.Size = new System.Drawing.Size(163, 29);
            this.txtMinLevel.TabIndex = 39;
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.Location = new System.Drawing.Point(146, 178);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(168, 29);
            this.txtSellingPrice.TabIndex = 38;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(443, 132);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(160, 29);
            this.txtPrice.TabIndex = 37;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(146, 132);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(168, 29);
            this.txtQuantity.TabIndex = 36;
            // 
            // txtCategory
            // 
            this.txtCategory.FormattingEnabled = true;
            this.txtCategory.Location = new System.Drawing.Point(443, 84);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(157, 30);
            this.txtCategory.TabIndex = 27;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(146, 226);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(168, 29);
            this.txtSupplier.TabIndex = 22;
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.Location = new System.Drawing.Point(146, 38);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(168, 29);
            this.txtPartNumber.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Part Number :";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(146, 84);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(168, 29);
            this.txtDescription.TabIndex = 17;
            // 
            // txtPartName
            // 
            this.txtPartName.Location = new System.Drawing.Point(443, 38);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(157, 29);
            this.txtPartName.TabIndex = 15;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnAdd.Location = new System.Drawing.Point(267, 271);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 38);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(335, 185);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 22);
            this.label11.TabIndex = 9;
            this.label11.Text = "Min Level :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 229);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 22);
            this.label10.TabIndex = 8;
            this.label10.Text = "Suppliers :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 22);
            this.label9.TabIndex = 7;
            this.label9.Text = "Selling Price :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(377, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 22);
            this.label8.TabIndex = 6;
            this.label8.Text = "Price :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 44);
            this.label7.TabIndex = 5;
            this.label7.Text = "Quantity\r\nIn Stock :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(341, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 22);
            this.label6.TabIndex = 4;
            this.label6.Text = "Category :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "Description :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Part Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 22);
            this.label2.TabIndex = 35;
            this.label2.Text = "PartID :";
            // 
            // txtPartIDU
            // 
            this.txtPartIDU.Location = new System.Drawing.Point(137, 22);
            this.txtPartIDU.Name = "txtPartIDU";
            this.txtPartIDU.Size = new System.Drawing.Size(168, 29);
            this.txtPartIDU.TabIndex = 34;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnClear.Location = new System.Drawing.Point(443, 271);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 38);
            this.btnClear.TabIndex = 32;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnDelete.Location = new System.Drawing.Point(171, 48);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 27);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnUpdate.Location = new System.Drawing.Point(267, 250);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(77, 36);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(95, 135);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(321, 29);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 138);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(77, 22);
            this.lblSearch.TabIndex = 5;
            this.lblSearch.Text = "Search :";
            // 
            // lblPartsList
            // 
            this.lblPartsList.AutoSize = true;
            this.lblPartsList.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartsList.Location = new System.Drawing.Point(12, 92);
            this.lblPartsList.Name = "lblPartsList";
            this.lblPartsList.Size = new System.Drawing.Size(266, 31);
            this.lblPartsList.TabIndex = 6;
            this.lblPartsList.Text = "Parts Invenntory List";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Gray;
            this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(-5, -2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(105, 28);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.btnClearU);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.txtSupplierU);
            this.panel2.Controls.Add(this.txtMinLevelU);
            this.panel2.Controls.Add(this.txtSellingPriceU);
            this.panel2.Controls.Add(this.txtPriceU);
            this.panel2.Controls.Add(this.txtQuantityU);
            this.panel2.Controls.Add(this.txtCategoryU);
            this.panel2.Controls.Add(this.txtPartNumberU);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.txtDescriptionU);
            this.panel2.Controls.Add(this.txtPartNameU);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.txtPartIDU);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(755, 372);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(603, 289);
            this.panel2.TabIndex = 36;
            // 
            // txtMinLevelU
            // 
            this.txtMinLevelU.Location = new System.Drawing.Point(434, 204);
            this.txtMinLevelU.Name = "txtMinLevelU";
            this.txtMinLevelU.Size = new System.Drawing.Size(163, 29);
            this.txtMinLevelU.TabIndex = 55;
            // 
            // txtSellingPriceU
            // 
            this.txtSellingPriceU.Location = new System.Drawing.Point(137, 204);
            this.txtSellingPriceU.Name = "txtSellingPriceU";
            this.txtSellingPriceU.Size = new System.Drawing.Size(168, 29);
            this.txtSellingPriceU.TabIndex = 54;
            // 
            // txtPriceU
            // 
            this.txtPriceU.Location = new System.Drawing.Point(434, 158);
            this.txtPriceU.Name = "txtPriceU";
            this.txtPriceU.Size = new System.Drawing.Size(160, 29);
            this.txtPriceU.TabIndex = 53;
            // 
            // txtQuantityU
            // 
            this.txtQuantityU.Location = new System.Drawing.Point(137, 158);
            this.txtQuantityU.Name = "txtQuantityU";
            this.txtQuantityU.Size = new System.Drawing.Size(168, 29);
            this.txtQuantityU.TabIndex = 52;
            // 
            // txtCategoryU
            // 
            this.txtCategoryU.FormattingEnabled = true;
            this.txtCategoryU.Location = new System.Drawing.Point(434, 110);
            this.txtCategoryU.Name = "txtCategoryU";
            this.txtCategoryU.Size = new System.Drawing.Size(157, 30);
            this.txtCategoryU.TabIndex = 51;
            // 
            // txtPartNumberU
            // 
            this.txtPartNumberU.Location = new System.Drawing.Point(137, 64);
            this.txtPartNumberU.Name = "txtPartNumberU";
            this.txtPartNumberU.Size = new System.Drawing.Size(168, 29);
            this.txtPartNumberU.TabIndex = 49;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 22);
            this.label12.TabIndex = 41;
            this.label12.Text = "Part Number :";
            // 
            // txtDescriptionU
            // 
            this.txtDescriptionU.Location = new System.Drawing.Point(137, 110);
            this.txtDescriptionU.Name = "txtDescriptionU";
            this.txtDescriptionU.Size = new System.Drawing.Size(168, 29);
            this.txtDescriptionU.TabIndex = 50;
            // 
            // txtPartNameU
            // 
            this.txtPartNameU.Location = new System.Drawing.Point(434, 64);
            this.txtPartNameU.Name = "txtPartNameU";
            this.txtPartNameU.Size = new System.Drawing.Size(157, 29);
            this.txtPartNameU.TabIndex = 48;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(326, 211);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 22);
            this.label13.TabIndex = 47;
            this.label13.Text = "Min Level :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 207);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 22);
            this.label14.TabIndex = 46;
            this.label14.Text = "Selling Price :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(368, 161);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 22);
            this.label15.TabIndex = 45;
            this.label15.Text = "Price :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(38, 143);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 44);
            this.label16.TabIndex = 44;
            this.label16.Text = "Quantity\r\nIn Stock :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(332, 112);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 22);
            this.label17.TabIndex = 43;
            this.label17.Text = "Category :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 113);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 22);
            this.label18.TabIndex = 42;
            this.label18.Text = "Description :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(319, 67);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(109, 22);
            this.label19.TabIndex = 40;
            this.label19.Text = "Part Name :";
            // 
            // txtSupplierU
            // 
            this.txtSupplierU.Location = new System.Drawing.Point(434, 22);
            this.txtSupplierU.Name = "txtSupplierU";
            this.txtSupplierU.Size = new System.Drawing.Size(157, 29);
            this.txtSupplierU.TabIndex = 56;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(335, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 22);
            this.label20.TabIndex = 57;
            this.label20.Text = "Suppliers :";
            // 
            // btnClearU
            // 
            this.btnClearU.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnClearU.Location = new System.Drawing.Point(443, 248);
            this.btnClearU.Name = "btnClearU";
            this.btnClearU.Size = new System.Drawing.Size(75, 38);
            this.btnClearU.TabIndex = 58;
            this.btnClearU.Text = "Clear";
            this.btnClearU.UseVisualStyleBackColor = false;
            this.btnClearU.Click += new System.EventHandler(this.btnClearU_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.txtPartIDD);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Location = new System.Drawing.Point(755, 667);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(386, 78);
            this.panel3.TabIndex = 37;
            // 
            // txtPartIDD
            // 
            this.txtPartIDD.Location = new System.Drawing.Point(146, 13);
            this.txtPartIDD.Name = "txtPartIDD";
            this.txtPartIDD.Size = new System.Drawing.Size(168, 29);
            this.txtPartIDD.TabIndex = 36;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(63, 13);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 22);
            this.label21.TabIndex = 37;
            this.label21.Text = "PartID :";
            // 
            // PartsInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblPartsList);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewInventory);
            this.Controls.Add(this.btnBack);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "PartsInventoryForm";
            this.Text = "InventoryManagementForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dataGridViewInventory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPartNumber;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox txtCategory;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblPartsList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPartIDU;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtMinLevel;
        private System.Windows.Forms.TextBox txtSellingPrice;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClearU;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtSupplierU;
        private System.Windows.Forms.TextBox txtMinLevelU;
        private System.Windows.Forms.TextBox txtSellingPriceU;
        private System.Windows.Forms.TextBox txtPriceU;
        private System.Windows.Forms.TextBox txtQuantityU;
        private System.Windows.Forms.ComboBox txtCategoryU;
        private System.Windows.Forms.TextBox txtPartNumberU;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDescriptionU;
        private System.Windows.Forms.TextBox txtPartNameU;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtPartIDD;
        private System.Windows.Forms.Label label21;
    }


}