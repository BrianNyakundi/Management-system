using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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
    public partial class OrderManagementForm : Form
    {
        public OrderManagementForm()
        {
            InitializeComponent();
            LoadOrders(); // Load order data when the form is initialized
        }

        private void ClearFieds()
        {
            txtCustomerID.Clear();
            txtCarID.Clear();
            txtOrderDate.Value = DateTime.Now;
            txtOrderType.Clear();
            txtStatus.Clear();
            txtOrderIDD.Clear();
            txtCustomerIDU.Clear();
            txtCarIDU.Clear();
            txtOrderDateU.Value = DateTime.Now;
            txtOrderTypeU.Clear();
            txtStatusU.Clear();
            txtOrderIDU.Clear();

        }

        // Method to load orders from the database
        private void LoadOrders()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM orders";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewOrders.DataSource = dt; // Bind the DataTable to the DataGridView
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

        private void OrderManagementForm_FormClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OrderManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddOrder_Click_1(object sender, EventArgs e)
        {
            int customerID = int.Parse(txtCustomerID.Text);
            int carID = int.Parse(txtCarID.Text);
            DateTime orderDate = DateTime.Parse(txtOrderDate.Text);
            string orderType = txtOrderType.Text;
            string status = txtStatus.Text;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO orders (CustomerID, CarID, OrderDate, OrderType, Status) VALUES (@customerID, @carID, @orderDate, @orderType, @status)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@customerID", customerID);
                    cmd.Parameters.AddWithValue("@carID", carID);
                    cmd.Parameters.AddWithValue("@orderDate", orderDate);
                    cmd.Parameters.AddWithValue("@orderType", orderType);
                    cmd.Parameters.AddWithValue("@status", status);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Order added successfully!");

                        ClearFieds();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add order.");
                        ClearFieds();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            string orderID = txtOrderIDD.Text;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM orders WHERE OrderID = @orderID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderID", orderID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Order deleted successfully!");

                        ClearFieds();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete order.");
                        ClearFieds();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            string orderID = txtOrderIDU.Text;
            
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM orders WHERE OrderID = @orderID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@orderID", orderID);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtCustomerIDU.Text = reader["CustomerID"].ToString();
                        txtCarIDU.Text = reader["CarID"].ToString();
                        txtOrderDateU.Text = reader["OrderDate"].ToString();
                        txtOrderTypeU.Text = reader["OrderType"].ToString();
                        txtStatusU.Text = reader["Status"].ToString();

                        ClearFieds();
                    }
                    else
                    {
                        MessageBox.Show("Order not found.");
                        ClearFieds();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnRefresh.Text = "Refreshing...";

            await Task.Run(() => {
                this.Invoke((MethodInvoker)delegate {
                    LoadOrders();
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
            autoRefreshTimer.Tick += (s, e) => SafeRefresh(LoadOrders);
            autoRefreshTimer.Start();
        }
    }
}
