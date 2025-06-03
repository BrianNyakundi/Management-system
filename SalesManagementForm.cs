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
    public partial class SalesManagementForm : Form
    {
        public SalesManagementForm()
        {
            InitializeComponent();
            LoadSales(); // Load sales data when the form is initialized
        }

        private void ClearFields()
        {
            txtCustomerID.Clear();
            txtCarID.Clear();
            txtSaleDate.Value = DateTime.Today;
            txtSaleAmount.Clear();
            txtPaymentMethod.Clear();
            txtCustomerIDU.Clear();
            txtCarIDU.Clear();
            txtSaleDateU.Value = DateTime.Today;
            txtSaleAmountU.Clear();
            txtPaymentMethodU.Clear();
            txtSaleIDD.Clear();
            txtSaleID.Clear();
            txtSaleIDR.Clear();
        }

        // Method to load sales from the database
        private void LoadSales()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM sales";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewSales.DataSource = dt; // Bind the DataTable to the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
        }

        private void SalesManagementForm_FormClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SalesManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddSale_Click_1(object sender, EventArgs e)
        {
            string customerID = txtCustomerID.Text;
            string carID = txtCarID.Text;
            DateTime saleDate = DateTime.Parse(txtSaleDate.Text);
            string saleAmount = txtSaleAmount.Text;
            string paymentMethod = txtPaymentMethod.Text;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO sales (CustomerID, CarID, SaleDate, SaleAmount, PaymentMethod) VALUES (@customerID, @carID, @saleDate, @saleAmount, @paymentMethod)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@customerID", customerID);
                    cmd.Parameters.AddWithValue("@carID", carID);
                    cmd.Parameters.AddWithValue("@saleDate", saleDate);
                    cmd.Parameters.AddWithValue("@saleAmount", saleAmount);
                    cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sale added successfully!");

                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add sale.");
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDeleteSale_Click(object sender, EventArgs e)
        {
            string saleID = txtSaleIDD.Text;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM sales WHERE SaleID = @saleID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@saleID", saleID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sale deleted successfully!");

                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete sale.");
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpadateSale_Click(object sender, EventArgs e)
        {
            string saleID = txtSaleID.Text;
            int customerID = int.Parse(txtCustomerIDU.Text);
            int carID = int.Parse(txtCarIDU.Text);
            DateTime saleDate = DateTime.Parse(txtSaleDateU.Text);
            decimal saleAmount = decimal.Parse(txtSaleAmountU.Text);
            string paymentMethod = txtPaymentMethodU.Text;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE sales SET CustomerID = @customerID, CarID = @carID, SaleDate = @saleDate, SaleAmount = @saleAmount, PaymentMethod = @paymentMethod WHERE SaleID = @saleID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@customerID", customerID);
                    cmd.Parameters.AddWithValue("@carID", carID);
                    cmd.Parameters.AddWithValue("@saleDate", saleDate);
                    cmd.Parameters.AddWithValue("@saleAmount", saleAmount);
                    cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@saleID", saleID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sale updated successfully!");

                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update sale.");

                        ClearFields() ;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnGenerateReceipt_Click(object sender, EventArgs e)
        {
            // Validate if SaleID is entered
            if (string.IsNullOrWhiteSpace(txtSaleIDR.Text))
            {
                MessageBox.Show("Please enter a Sale ID.");
                return;
            }

            // Parse SaleID (handle invalid input)
            if (!int.TryParse(txtSaleIDR.Text, out int saleId))
            {
                MessageBox.Show("Invalid Sale ID. Please enter a numeric value.");
                return;
            }

            // Get sale, customer, and car details from database
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Get sale details
                    string saleQuery = "SELECT * FROM sales WHERE SaleID = @saleId";
                    MySqlCommand saleCmd = new MySqlCommand(saleQuery, conn);
                    saleCmd.Parameters.AddWithValue("@saleId", saleId);
                    MySqlDataReader saleReader = saleCmd.ExecuteReader();

                    if (saleReader.Read())
                    {
                        Sale sale = new Sale
                        {
                            SaleID = saleId,
                            CustomerID = Convert.ToInt32(saleReader["CustomerID"]),
                            CarID = Convert.ToInt32(saleReader["CarID"]),
                            SaleDate = Convert.ToDateTime(saleReader["SaleDate"]),
                            SaleAmount = Convert.ToDecimal(saleReader["SaleAmount"]),
                            PaymentMethod = saleReader["PaymentMethod"].ToString()
                        };
                        saleReader.Close();

                        // Get customer details
                        string customerQuery = "SELECT * FROM customers WHERE CustomerID = @customerId";
                        MySqlCommand customerCmd = new MySqlCommand(customerQuery, conn);
                        customerCmd.Parameters.AddWithValue("@customerId", sale.CustomerID);
                        MySqlDataReader customerReader = customerCmd.ExecuteReader();

                        Customer customer = null;
                        if (customerReader.Read())
                        {
                            customer = new Customer
                            {
                                CustomerID = sale.CustomerID,
                                FullName = customerReader["FullName"].ToString(),
                                Email = customerReader["Email"].ToString(),
                                Phone = customerReader["Phone"].ToString(),
                                Address = customerReader["Address"].ToString()
                            };
                        }
                        customerReader.Close();

                        // Get car details
                        string carQuery = "SELECT * FROM cars WHERE CarID = @carId";
                        MySqlCommand carCmd = new MySqlCommand(carQuery, conn);
                        carCmd.Parameters.AddWithValue("@carId", sale.CarID);
                        MySqlDataReader carReader = carCmd.ExecuteReader();

                        Car car = null;
                        if (carReader.Read())
                        {
                            car = new Car
                            {
                                CarID = sale.CarID,
                                Make = carReader["Make"].ToString(),
                                Model = carReader["Model"].ToString(),
                                Year = Convert.ToInt32(carReader["Year"]),
                                Price = Convert.ToDecimal(carReader["Price"])
                            };
                        }
                        carReader.Close();

                        if (customer != null && car != null)
                        {
                            ReceiptForm receiptForm = new ReceiptForm(sale, customer, car);
                            receiptForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Could not find customer or car details for this sale.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error generating receipt: {ex.Message}");
                }
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnRefresh.Text = "Refreshing...";

            await Task.Run(() => {
                this.Invoke((MethodInvoker)delegate {
                    LoadSales();
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
            autoRefreshTimer.Tick += (s, e) => SafeRefresh(LoadSales);
            autoRefreshTimer.Start();
        }
    }
 }
