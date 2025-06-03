using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MimeKit;
using MailKit.Net.Smtp;

namespace Mnagement_system
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void btnRetrievePassword_Click(object sender, EventArgs e)
        {
            string staffID = txtStaffID.Text;
            string username = txtUsername.Text;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT s.Email, u.Password FROM staff s INNER JOIN users u ON s.StaffID = u.StaffID WHERE s.StaffID = @staffID AND u.Username = @username";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@staffID", staffID);
                    cmd.Parameters.AddWithValue("@username", username);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string email = reader["Email"].ToString();
                        string password = reader["Password"].ToString();

                        EmailService emailService = new EmailService(); // Create an instance
                        emailService.SendEmail(email, password, username);
                        MessageBox.Show("Password sent to your email!");

                        this.Close();

                        // Optionally, show the LoginForm again
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Staff ID or Username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public class EmailService
        {
            private const string SmtpServer = "smtp.gmail.com";
            private const int SmtpPort = 587;
            private const string SmtpUsername = "cybermetrics1@gmail.com";
            private const string SmtpPassword = "twyl stsx zkws njvv";
            private const string FromName = "Car Dealership";
            internal void SendEmail(string Email, string password, string username)
            {
                try
                {

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(FromName, username));
                    message.To.Add(new MailboxAddress(username, Email));
                    message.Subject = "Password Recovery";
                    var bodyBuilder = new BodyBuilder();

                    bodyBuilder.TextBody = $@"Dear {username},

                                Recover Password! 

                                Your password is: {password}

                                Please Don't share your Password for security reasons.

                                Best regards,
                                The Car Dealership";

                    bodyBuilder.HtmlBody = $@"
                                <html>
                                <body>
                                    <h2>Recover Password!</h2>
                                    <p>Dear {username},</p>
                                    <p>Your password is: <strong>{password}</strong></p>
                                    <p style='color: red;'>Please Don't share your Password for security reasons.</p>
                                    <p>Best regards,<br>The Car Dealership</p>
                                </body>
                                </html>";

                    message.Body = bodyBuilder.ToMessageBody();

                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        client.Connect(SmtpServer, SmtpPort, false);
                        client.Authenticate(SmtpUsername, SmtpPassword);
                        client.Send(message);
                        client.Disconnect(true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to send email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
