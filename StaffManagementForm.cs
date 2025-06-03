using MimeKit;
using MailKit.Net.Smtp;
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
    public partial class StaffManagementForm : Form
    {
        public class EmailService
        {
            private const string SmtpServer = "smtp.gmail.com";
            private const int SmtpPort = 587;
            private const string SmtpUsername = "cybermetrics1@gmail.com";
            private const string SmtpPassword = "twyl stsx zkws njvv";
            private const string FromName = "Car Dealership";

            public void SendWelcomeEmail(string email, string fullName, string role, string password)
            {
                try
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(FromName, SmtpUsername));
                    message.To.Add(new MailboxAddress(fullName, email));
                    message.Subject = "Welcome to Our Dealership Team!";

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = $@"Dear {fullName},

                                Welcome to Car Dealership! 

                                You are now part of our team as: {role}
                                Your temporary password is: {password}

                                Please log in to the system and change your password immediately for security reasons.

                                Best regards,
                                The Management Team";

                    bodyBuilder.HtmlBody = $@"
                                <html>
                                <body>
                                    <h2>Welcome to Car Dealership!</h2>
                                    <p>Dear {fullName},</p>
                                    <p>You are now part of our team as: <strong>{role}</strong></p>
                                    <p>Your temporary password is: <strong>{password}</strong></p>
                                    <p style='color: red;'>Please log in to the system and change your password immediately for security reasons.</p>
                                    <p>Best regards,<br>The Management Team</p>
                                </body>
                                </html>";

                    message.Body = bodyBuilder.ToMessageBody();

                    using (var client = new SmtpClient())
                    {
                        client.Connect(SmtpServer, SmtpPort, false);
                        client.Authenticate(SmtpUsername, SmtpPassword);
                        client.Send(message);
                        client.Disconnect(true);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                    throw;
                }
            }

            // ✅ Move SendApprovalEmail to EmailService
            public void SendApprovalEmail(string staffName, string email, string status)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Car Dealership", SmtpUsername));
                message.To.Add(new MailboxAddress(staffName, email));

                if (status == "approved")
                {
                    message.Subject = "Your Staff Account Has Been Approved";

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = $@"Dear {staffName},

                                Welcome to Car Dealership! 

                                Your staff account has been approved. You can now log in to the system.

                                Best regards,
                                The Management Team";

                    bodyBuilder.HtmlBody = $@"
                                <html>
                                <body>
                                    <h2>Welcome to Car Dealership!</h2>
                                    <p>Dear {staffName},</p>
                                    <p>Your staff account has been approved. You can now log in to the system.</p>
                                    <p>Best regards,<br>Car Dealership Administration</p>
                                </body>
                                </html>";

                    message.Body = bodyBuilder.ToMessageBody();
                }
                else
                {
                    message.Subject = "Regarding Your Staff Account Application";

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = $@"Dear {staffName},

                                Car Dealership! 

                                We regret to inform you that your staff account application has not been approved.

                                Best regards,
                                The Management Team";

                    bodyBuilder.HtmlBody = $@"
                                <html>
                                <body>
                                    <h2>Welcome to Car Dealership!</h2>
                                    <p>Dear {staffName},</p>
                                    <p>We regret to inform you that your staff account application has not been approved</p>
                                    <p>Best regards,<br>Car Dealership Administration</p>
                                </body>
                                </html>";

                    message.Body = bodyBuilder.ToMessageBody();
                    
                }

                using (var client = new SmtpClient())
                {
                    client.Connect(SmtpServer, SmtpPort, false);
                    client.Authenticate(SmtpUsername, SmtpPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
        }

        public void SendNewStaffNotification(string staffName, string role, string adminEmail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Dealership System", "cybermetrics1@gmail.com"));
            message.To.Add(new MailboxAddress("Admin", adminEmail));
            message.Subject = "New Staff Requires Approval";

            message.Body = new TextPart("plain")
            {
                Text = $"Dear Admin,\n\n" +
                       $"A new staff member ({staffName} - {role}) has been added and requires your approval.\n\n" +
                       "Please review in the dashboard.\n\n" +
                       "System Notification"
            };

            // ... send email ...
        }

        public StaffManagementForm()
        {
            InitializeComponent();
            LoadStaff(); // Load staff data when the form is initialized
        }

        private void ClearFields()
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtRole.Clear();
            txtPhone.Clear();
            txtHireDate.Value = DateTime.Now;
            txtStaffID.Clear();
            txtStaffIDD.Clear();
            txtFullNameU.Clear();
            txtEmailU.Clear();
            txtPasswordU.Clear();
            txtRoleU.Clear();
            txtPhoneU.Clear();
            txtHireDateU.Value = DateTime.Now;

        }

        // Method to load staff from the database
        private void LoadStaff()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM staff";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewStaff.DataSource = dt; // Bind the DataTable to the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.Show();
        }

        private void StaffManagementForm_FormClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StaffManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddStaff_Click_1(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string role = txtRole.Text;
            string phone = txtPhone.Text;
            DateTime hireDate = DateTime.Parse(txtHireDate.Text);

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO staff (FullName, Email, Password, Role, Phone, HireDate, IsApproved)  VALUES (@fullName, @email, @password, @role, @phone, @hireDate, FALSE)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fullName", fullName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@hireDate", hireDate);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        try
                        {
                            EmailService emailService = new EmailService(); // Create an instance
                            emailService.SendWelcomeEmail(email, fullName, role, password);
                            MessageBox.Show("Staff added successfully! Waiting for admin approval.");
                        }
                        catch (Exception emailEx)
                        {
                            MessageBox.Show($"Staff added successfully but email failed to send: {emailEx.Message}");

                            ClearFields();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Failed to add staff.");
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            string staffID = txtStaffIDD.Text;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM staff WHERE StaffID = @staffID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@staffID", staffID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Staff member deleted successfully!");

                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete staff member.");

                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {
            string staffID = txtStaffID.Text;
            string fullName = txtFullNameU.Text;
            string email = txtEmailU.Text;
            string password = txtPasswordU.Text;
            string role = txtRoleU.Text;
            string phone = txtPhoneU.Text;
            DateTime hireDate = DateTime.Parse(txtHireDateU.Text);

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE staff SET FullName = @fullName, Email = @email, Password = @password, Role = @role, Phone = @phone, HireDate = @hireDate WHERE StaffID = @staffID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fullName", fullName);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@hireDate", hireDate);
                    cmd.Parameters.AddWithValue("@staffID", staffID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Staff member updated successfully!");

                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update staff member.");

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
                    LoadStaff();
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
            autoRefreshTimer.Tick += (s, e) => SafeRefresh(LoadStaff);
            autoRefreshTimer.Start();
        }
    }
}
