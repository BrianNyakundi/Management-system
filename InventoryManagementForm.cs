using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mnagement_system
{
    public partial class PartsInventoryForm : Form
    {
        private int currentPartId = -1;

        public PartsInventoryForm()
        {
            InitializeComponent();
            SetupForm();
            LoadParts();
        }

        private void SetupForm()
        {
            // Form properties
            this.Text = "Car Parts Inventory Management";
            this.Size = new System.Drawing.Size(900, 600);

        }

        private void LoadParts()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM car_parts ORDER BY PartName";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewInventory.DataSource = dt;

                    if (dt.Rows.Count > 0)
                    {
                        dataGridViewInventory.Rows[0].Selected = true;
                    }
                    else
                    {
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading parts: " + ex.Message);
                }
            }
        }

        private void DgvParts_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewInventory.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewInventory.SelectedRows[0];
                currentPartId = Convert.ToInt32(row.Cells["colPartId"].Value);

                txtPartNumber.Text = row.Cells["colPartNumber"].Value.ToString();
                txtPartName.Text = row.Cells["colPartName"].Value.ToString();
                // Load other fields similarly
            }
        }

        private void ClearFields()
        {
            txtPartNumber.Clear();
            txtPartName.Clear();
            txtDescription.Clear();
            txtCategory.Items.Clear();
            txtQuantity.Clear();
            txtSellingPrice.Clear();
            txtSupplier.Clear();
            txtMinLevel.Clear();
            txtPartIDD.Clear();
            txtPartIDU.Clear();
            txtPartNameU.Clear();
            txtDescriptionU.Clear();
            txtPartNumberU.Clear();
            txtCategoryU.Items.Clear();
            txtQuantityU.Clear();
            txtSellingPriceU.Clear();
            txtMinLevelU.Clear();
            txtSupplierU.Clear();



        }

        private void AddParameters(MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@PartNumber", txtPartNumber.Text);
            cmd.Parameters.AddWithValue("@PartName", txtPartName.Text);
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
            cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
            cmd.Parameters.AddWithValue("@CostPrice", txtPrice.Text);
            cmd.Parameters.AddWithValue("@SellingPrice", txtSellingPrice.Text);
            cmd.Parameters.AddWithValue("@Supplier", txtSupplier.Text);
            cmd.Parameters.AddWithValue("@MinStock", txtMinLevel.Text);
            cmd.Parameters.AddWithValue("@RestockDate", DateTime.Today);
        }

        private void UpdateParameters(MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@PartNumberU", txtPartNumberU.Text);
            cmd.Parameters.AddWithValue("@PartNameU", txtPartNameU.Text);
            cmd.Parameters.AddWithValue("@DescriptionU", txtDescriptionU.Text);
            cmd.Parameters.AddWithValue("@CategoryU", txtCategoryU.Text);
            cmd.Parameters.AddWithValue("@QuantityU", txtQuantityU.Text);
            cmd.Parameters.AddWithValue("@CostPriceU", txtPriceU.Text);
            cmd.Parameters.AddWithValue("@SellingPriceU", txtSellingPriceU.Text);
            cmd.Parameters.AddWithValue("@SupplierU", txtSupplierU.Text);
            cmd.Parameters.AddWithValue("@MinStockU", txtMinLevelU.Text);
            cmd.Parameters.AddWithValue("@RestockDate", DateTime.Today);
            cmd.Parameters.AddWithValue("@PartIdU", txtPartIDU.Text);
        }

        
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtPartNumber.Text))
            {
                MessageBox.Show("Please enter a part number.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPartName.Text))
            {
                MessageBox.Show("Please enter a part name.");
                return false;
            }
            return true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dataGridViewInventory.DataSource is DataTable dt)
            {
                string filter = $"PartName LIKE '%{txtSearch.Text}%' OR PartNumber LIKE '%{txtSearch.Text}%'";
                dt.DefaultView.RowFilter = filter;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
        }

        private void InventoryManagementForm_FormClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            string filter = $"PartName LIKE '%{txtSearch.Text}%' OR PartNumber LIKE '%{txtSearch.Text}%'";
            using (MySqlConnection conn = DBConnection.GetConnection())
            { 
                try
                { 
                    string query = "SELECT * FROM car_parts ORDER BY PartName";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewInventory.DataSource = dt; // Binds data to grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The part not available: " + ex.Message);
                }
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnRefresh.Text = "Refreshing...";

            await Task.Run(() => {
                this.Invoke((MethodInvoker)delegate {
                    LoadParts();
                });
            });

            btnRefresh.Text = "Refresh";
            btnRefresh.Enabled = true;
        }

        public static void SafeRefresh(Action refreshAction)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                refreshAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Refresh error: {ex.Message}");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private Timer autoRefreshTimer;

        private void InitializeAutoRefresh()
        {
            autoRefreshTimer = new Timer { Interval = 300000 }; // 5 minutes
            autoRefreshTimer.Tick += (s, e) => SafeRefresh(LoadParts);
            autoRefreshTimer.Start();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnClearU_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
                if (string.IsNullOrWhiteSpace(txtPartIDD.Text))
                {
                    MessageBox.Show("Please enter a Part ID.");
                    return;
                }

                // Parse PartID (handle invalid input)
                if (!int.TryParse(txtPartIDD.Text, out int PartIDD))
                {
                    MessageBox.Show("Invalid Part ID. Please enter a numeric value.");
                    return;
                }

                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM car_parts WHERE PartID = @PartId";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@PartId", PartIDD);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Part deleted successfully!");
                            LoadParts();
                            ClearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting part: " + ex.Message);
                    }
                }

            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPartIDU.Text))
            {
                MessageBox.Show("Please enter a Part ID.");
                return;
            }

            // Parse PartID (handle invalid input)
            if (!int.TryParse(txtPartIDU.Text, out int PartID))
            {
                MessageBox.Show("Invalid Part ID. Please enter a numeric value.");
                return;
            }


            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE car_parts SET 
                            PartNumber = @PartNumberU,
                            PartName = @PartNameU,
                            Description = @DescriptionU,
                            Category = @CategoryU,
                            QuantityInStock = @QuantityU,
                            CostPrice = @CostPriceU,
                            SellingPrice = @SellingPriceU,
                            Supplier = @SupplierU,
                            MinimumStockLevel = @MinStockU,
                            LastRestockedDate = @RestockDate
                            WHERE PartID = @PartIdU";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    UpdateParameters(cmd);
                    cmd.Parameters.AddWithValue("@PartIdU", PartID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Part updated successfully!");
                        LoadParts();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating part: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = @"INSERT INTO car_parts 
                            (PartNumber, PartName, Description, Category, QuantityInStock, 
                             CostPrice, SellingPrice, Supplier, MinimumStockLevel, LastRestockedDate)
                            VALUES (@PartNumber, @PartName, @Description, @Category, @Quantity, 
                                    @CostPrice, @SellingPrice, @Supplier, @MinStock, @RestockDate)";

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        AddParameters(cmd);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Part added successfully!");
                            LoadParts();
                            ClearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding part: " + ex.Message);
                    }
                }
            }
        }
    }
}
