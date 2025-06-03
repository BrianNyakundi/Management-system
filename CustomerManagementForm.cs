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
    public partial class CustomerManagementForm : Form
    {
        public CustomerManagementForm()
        {
            InitializeComponent();
            LoadCustomers(); // Load customer data when the form is initialized
        }

        private void ClearFields()
        {
            txtCustomerID.Clear();          
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();    
            txtAddress.Clear();
            txtPurchaseHistory.Clear();
            txtCustomerIDU.Clear();
            txtFullNameU.Clear();
            txtEmailU.Clear();
            txtPhoneU.Clear();
            txtAddressU.Clear();
            txtPurchaseHistoryU.Clear();
        }

        // Method to load customers from the database
        private void LoadCustomers()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM customers";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewCustomers.DataSource = dt; // Bind the DataTable to the DataGridView
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
            dashboardForm.ShowDialog();
        }

        private void CustomerManagementForm_FormClose(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string purchaseHistory = txtPurchaseHistory.Text;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO customers (FullName, Email, Phone, Address, PurchaseHistory) VALUES (@fullName, @email, @phone, @address, @purchaseHistory)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fullName", fullName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@purchaseHistory", purchaseHistory);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer added successfully!");

                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add customer.");
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            string customerID = txtCustomerID.Text;
            string fullName = txtFullNameU.Text;
            string email = txtEmailU.Text;
            string phone = txtPhoneU.Text;
            string address = txtAddressU.Text;
            string purchaseHistory = txtPurchaseHistoryU.Text;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE customers SET FullName = @fullName, Email = @email, Phone = @phone, Address = @address, PurchaseHistory = @purchaseHistory WHERE CustomerID = @customerID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fullName", fullName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@purchaseHistory", purchaseHistory);
                    cmd.Parameters.AddWithValue("@customerID", customerID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer updated successfully!");

                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update customer.");

                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            string customerID = txtCustomerIDU.Text;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM customers WHERE CustomerID = @customerID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@customerID", customerID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer deleted successfully!");


                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete customer.");
                        ClearFields();
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
                    LoadCustomers();
                });
            });

            btnRefresh.Text = "Refresh";
            btnRefresh.Enabled = true;
        }

        public void SafeRefresh(Action refreshAction)
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
            autoRefreshTimer.Tick += (s, e) => SafeRefresh(LoadCustomers);
            autoRefreshTimer.Start();
        }
    }
}
