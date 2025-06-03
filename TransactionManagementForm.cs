using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Mnagement_system
{
    public partial class TransactionManagementForm : Form
    {
        public TransactionManagementForm()
        {
            InitializeComponent();
            LoadTransactions(); // Load transaction data when the form is initialized
        }

        private void ClearFields()
        {
            txtSaleID.Clear();
            txtTransactionDate.Value = DateTime.Now;
            txtAmount.Clear();
            txtPaymentMethod.Clear();
            txtSaleIDU.Clear();
            txtTransactionDateU.Value = DateTime.Now;
            txtAmountU.Clear();
            txtPaymentMethodU.Clear();
            txtTransactionIDU.Clear();
            txtTransactionIDD.Clear();
        }

        // Method to load transactions from the database
        private void LoadTransactions()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM transactions";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewTransactions.DataSource = dt; // Bind the DataTable to the DataGridView
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

        private void TransactionManagement_FormClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TransactionManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddTransaction_Click_1(object sender, EventArgs e)
        {
            string saleID = txtSaleID.Text;
            DateTime transactionDate = DateTime.Parse(txtTransactionDate.Text);
            string amount = txtAmount.Text;
            string paymentMethod = txtPaymentMethod.Text;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO transactions (SaleID, TransactionDate, Amount, PaymentMethod) VALUES (@saleID, @transactionDate, @amount, @paymentMethod)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@saleID", saleID);
                    cmd.Parameters.AddWithValue("@transactionDate", transactionDate);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Transaction added successfully!");

                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add transaction.");

                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpdateTransaction_Click(object sender, EventArgs e)
        {
            string saleID = txtSaleIDU.Text;
            DateTime transactionDate = DateTime.Parse(txtTransactionDateU.Text);
            decimal amount = decimal.Parse(txtAmountU.Text);
            string paymentMethod = txtPaymentMethodU.Text;
            string transactionID = txtTransactionIDU.Text;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE transactions SET SaleID = @saleID, TransactionDate = @transactionDate, Amount = @amount, PaymentMethod = @paymentMethod WHERE TransactionID = @transactionID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@saleID", saleID);
                    cmd.Parameters.AddWithValue("@transactionDate", transactionDate);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@transactionID", transactionID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Transaction updated successfully!");

                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update transaction.");

                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDeleteTransaction_Click(object sender, EventArgs e)
        {
            string transactionID = txtTransactionIDD.Text;
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM transactions WHERE TransactionID = @transactionID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@transactionID", transactionID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Transaction deleted successfully!");

                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete transaction.");
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
                    LoadTransactions();
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
            autoRefreshTimer.Tick += (s, e) => SafeRefresh(LoadTransactions);
            autoRefreshTimer.Start();
        }
    }
}
