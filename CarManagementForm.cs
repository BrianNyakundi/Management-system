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
    public partial class CarManagementForm : Form
    {
        public CarManagementForm()
        {
            InitializeComponent();
            LoadCars();
        }

        private void ClearFields()
        {
            txtCarIDD.Clear();
            txtModel.Clear();
            txtYear.Clear();
            txtMake.Clear();
            txtBrand.Clear();
            txtStatus.Clear();
            txtPrice.Clear();
            txtCarID.Clear();



        }

        private void LoadCars()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM cars";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewCars.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCarForm addCarForm = new AddCarForm();
            addCarForm.FormClosed += (s, args) => LoadCars(); // Refresh the car list after adding
            addCarForm.ShowDialog();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
        }
        private void CarManagementForm_FormClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            String carID = txtCarID.Text;
            string model = txtModel.Text;
            String year = txtYear.Text;
            string make = txtMake.Text;
            string brand = txtBrand.Text;
            string status = txtStatus.Text;
            string price = txtPrice.Text;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE cars SET Model = @model, Year = @year, Make = @make, Brand = @brand, Status = @status, Price = @price WHERE CarID = @carID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@carID", carID);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@make", make);
                    cmd.Parameters.AddWithValue("@brand", brand);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@price", price);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Car updated successfully!");
                        
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update car.");

                        ClearFields() ;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            string carID = txtCarIDD.Text;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM cars WHERE CarID = @carID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@carID", carID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Car deleted successfully!");

                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete car.");

                        ClearFields() ;
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
                    LoadCars();
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
            autoRefreshTimer.Tick += (s, e) => SafeRefresh(LoadCars);
            autoRefreshTimer.Start();
        }
    }
}
