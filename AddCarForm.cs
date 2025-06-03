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
    public partial class AddCarForm : Form
    {
        public AddCarForm()
        {
            InitializeComponent();
        }

        private void ClearFields()
        {
           
            txtModel.Clear();
            txtYear.Clear();
            txtMake.Clear();
            txtBrand.Clear();
            txtStatus.Clear();
            txtPrice.Clear();
           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string model = txtModel.Text;
            int year = int.Parse(txtYear.Text);
            string make = txtMake.Text;
            string brand = txtBrand.Text;
            string status = txtStatus.Text;
            decimal price = decimal.Parse(txtPrice.Text);

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO cars (Model, Year, Make, Brand, Status, Price) VALUES (@model, @year, @make, @brand, @status, @price)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@model", model);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@make", make);
                    cmd.Parameters.AddWithValue("@brand", brand);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@price", price);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Car added successfully!");

                        ClearFields();

                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Failed to add car.");

                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
