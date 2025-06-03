using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mnagement_system
{
    public partial class ReceiptForm : Form
    {
        private Sale _sale;
        private Customer _customer;
        private Car _car;
        private string _receiptNumber;
        private decimal _taxRate = 0.08m; // 8% tax rate
        private decimal _subtotal;
        private decimal _taxAmount;
        private decimal _total;
        private string _companyName = "CAR DEALERSHIP";
        private string _companyAddress = "123 Auto Drive";
        private string _companyCity = "Anytown, ST 12345";
        private string _companyPhone = "555-123-4567";
        private string _companyEmail = "sales@cardealership.com";
        private string _companyWebsite = "www.cardealership.com";
        private string _transactionId;

        public ReceiptForm(Sale sale, Customer customer, Car car)
        {
            InitializeComponent();
            _sale = sale;
            _customer = customer;
            _car = car;
        }


        private void GenerateReceipt()
        {
            // Create receipt content
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("CAR DEALERSHIP RECEIPT");
            receipt.AppendLine("----------------------");
            receipt.AppendLine($"Date: {_sale.SaleDate.ToShortDateString()}");
            receipt.AppendLine($"Receipt #: {_sale.SaleID}");
            receipt.AppendLine();
            receipt.AppendLine("Customer Information:");
            receipt.AppendLine($"Name: {_customer.FullName}");
            receipt.AppendLine($"Email: {_customer.Email}");
            receipt.AppendLine($"Phone: {_customer.Phone}");
            receipt.AppendLine();
            receipt.AppendLine("Vehicle Details:");
            receipt.AppendLine($"Make: {_car.Make}");
            receipt.AppendLine($"Model: {_car.Model}");
            receipt.AppendLine($"Year: {_car.Year}");
            receipt.AppendLine($"VIN: {_car.VIN}");
            receipt.AppendLine();
            receipt.AppendLine("Sale Details:");
            receipt.AppendLine($"Sale Amount: {_sale.SaleAmount:C}");
            receipt.AppendLine($"Payment Method: {_sale.PaymentMethod}");
            receipt.AppendLine();
            receipt.AppendLine("Thank you for your business!");

            txtReceipt.Text = receipt.ToString();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, args) =>
            {
                args.Graphics.DrawString(txtReceipt.Text,
                                       txtReceipt.Font,
                                       Brushes.Black,
                                       new RectangleF(50, 50, 700, 1000));
            };

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.ShowDialog();
        }

        private void btnSavePDF_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PDF Files|*.pdf";
            saveDialog.Title = "Save Receipt as PDF";
            saveDialog.FileName = $"Receipt_{_sale.SaleID}_{DateTime.Now:yyyyMMdd}.pdf";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // You'll need to add a reference to iTextSharp for PDF generation
                // using iTextSharp.text;
                // using iTextSharp.text.pdf;

                try
                {
                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(saveDialog.FileName, FileMode.Create));
                    doc.Open();
                    doc.Add(new Paragraph(txtReceipt.Text));
                    doc.Close();

                    MessageBox.Show("Receipt saved successfully!", "Success",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving PDF: {ex.Message}", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtReceipt_TextChanged(object sender, EventArgs e)
        {
            GenerateReceipt();
        }
    }
}
