using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ClosedXML.Excel;
using static Mnagement_system.StaffManagementForm;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using DocumentFormat.OpenXml.Vml;
using System.Text;
using System.IO;
using Path = System.IO.Path;

namespace Mnagement_system
{
    public partial class DashboardForm : Form
    {

        private Chart reportChart;


        public DashboardForm()
        {
            InitializeComponent();
            LoadRealTimeData(); // Load real-time data when the form is initialized
            SetupNavigationButtons(); // Set up navigation button event handlers ;
            InitializeReportChart(); // Initialize the chart control
            InitializeRefreshTimer(); // Initialize the refresh timer
            LoadLowStockParts(); // Load low stock parts
            LoadPendingApprovals(); // Load pending staff approvals

        }

        // Add a Timer control to your form
        private Timer refreshTimer;

        private void InitializeReportChart()
        {
            // Create a new Chart control
            reportChart = new Chart();
            reportChart.Size = new Size(580, 200);
            reportChart.Location = new Point(10, 310);
            reportChart.BackColor = Color.LightGray;
            reportChart.BorderlineColor = Color.Black;
            reportChart.BorderlineDashStyle = ChartDashStyle.Solid;
            reportChart.BorderlineWidth = 1;
            reportChart.Palette = ChartColorPalette.BrightPastel;

            // Add a ChartArea
            ChartArea chartArea = new ChartArea("MainChartArea");
            chartArea.AxisX.Title = "Category";
            chartArea.AxisY.Title = "Value";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.BackColor = Color.White;
            reportChart.ChartAreas.Add(chartArea);

            // Add a Legend
            Legend legend = new Legend("MainLegend");
            legend.Docking = Docking.Bottom;
            reportChart.Legends.Add(legend);

            // Add the Chart to the panel
            panel1.Controls.Add(reportChart);
            reportChart.Visible = false; // Hide initially until a report is generated
        }

        private void InitializeRefreshTimer()
        {
            refreshTimer = new Timer
            {
                Interval = 300000, // 5 minutes (300,000 ms)
                Enabled = true
            };
            refreshTimer.Tick += (s, e) =>
            {
                LoadLowStockParts();
                LoadPendingApprovals();
            };
            refreshTimer.Start();
        }


        private void LoadLowStockParts()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT PartNumber, PartName, QuantityInStock, 
                           MinimumStockLevel, Supplier 
                           FROM car_parts 
                           WHERE QuantityInStock < MinimumStockLevel
                           ORDER BY (MinimumStockLevel - QuantityInStock) DESC";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvLowStockParts.DataSource = dt;

                    // Highlight the entire row if no items found
                    if (dt.Rows.Count == 0)
                    {
                        lblLowStockHeader.Text = "No low stock parts";
                        lblLowStockHeader.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblLowStockHeader.Text = $"⚠ Low Stock Parts ({dt.Rows.Count} items need restocking)";
                        lblLowStockHeader.ForeColor = Color.DarkRed;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading low stock parts: " + ex.Message);
                }
            }
        }

        private void ApproveStaff(int staffId, string staffName)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE staff SET IsApproved = TRUE WHERE StaffID = @staffId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@staffId", staffId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"{staffName} has been approved!");
                        LoadPendingApprovals();

                        // Inside ApproveStaff method
                        EmailService emailService = new EmailService();
                        emailService.SendApprovalEmail(staffName, GetStaffEmail(staffId), "approved");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error approving staff: " + ex.Message);
                }
            }
        }

        private void LoadPendingApprovals()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT StaffID, FullName, Email, Role, Phone, HireDate FROM staff WHERE IsApproved = FALSE";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvPendingApprovals.DataSource = dt;

                    // Update the label with count
                    lblPendingApprovals.Text = $"Staff Awaiting Approval ({dt.Rows.Count})";

                    // Enable/disable approval buttons based on whether there are pending approvals
                    btnApprove.Enabled = dt.Rows.Count > 0;
                    btnReject.Enabled = dt.Rows.Count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading pending approvals: " + ex.Message);
                }
            }
        }

        private void RejectStaff(int staffId, string staffName)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    string staffEmail = GetStaffEmail(staffId);

                    conn.Open();
                    string query = "DELETE FROM staff WHERE StaffID = @staffId AND IsApproved = FALSE";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@staffId", staffId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"{staffName} has been rejected.");
                        LoadPendingApprovals();

                        // Inside RejectStaff method
                        EmailService emailService = new EmailService();
                        emailService.SendApprovalEmail(staffName, staffEmail, "rejected");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error rejecting staff: " + ex.Message);
                }
            }
        }

        private string GetStaffEmail(int staffId)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Email FROM staff WHERE StaffID = @staffId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@staffId", staffId);
                return cmd.ExecuteScalar()?.ToString();
            }
        }

        // Method to load real-time data
        private void LoadRealTimeData()
        {
            if (lblCustomersCount == null || lblPendingCount == null || lblCarsSoldCount == null || lblBestModel == null)
            {
                MessageBox.Show("One or more UI components are not initialized.");
                return;
            }

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    string queryCustomers = "SELECT COUNT(*) FROM customers";
                    MySqlCommand cmdCustomers = new MySqlCommand(queryCustomers, conn);
                    lblCustomersCount.Text = cmdCustomers.ExecuteScalar().ToString();

                    string queryPending = "SELECT COUNT(*) FROM orders WHERE Status = 'Pending'";
                    MySqlCommand cmdPending = new MySqlCommand(queryPending, conn);
                    lblPendingCount.Text = cmdPending.ExecuteScalar().ToString();

                    string queryCarsSold = "SELECT COUNT(*) FROM sales WHERE MONTH(SaleDate) = MONTH(CURRENT_DATE())";
                    MySqlCommand cmdCarsSold = new MySqlCommand(queryCarsSold, conn);
                    lblCarsSoldCount.Text = cmdCarsSold.ExecuteScalar().ToString();

                    string queryBestModel = "SELECT Model FROM cars WHERE CarID = (SELECT CarID FROM sales GROUP BY CarID ORDER BY COUNT(*) DESC LIMIT 1)";
                    MySqlCommand cmdBestModel = new MySqlCommand(queryBestModel, conn);
                    lblBestModel.Text = cmdBestModel.ExecuteScalar()?.ToString() ?? "N/A";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Method to set up navigation button event handlers
        private void SetupNavigationButtons()
        {
            if (btnCarManagement != null) btnCarManagement.Click += (s, e) => OpenForm(new CarManagementForm());
            if (btnCustomerManagement != null) btnCustomerManagement.Click += (s, e) => OpenForm(new CustomerManagementForm());
            if (btnSalesManagement != null) btnSalesManagement.Click += (s, e) => OpenForm(new SalesManagementForm());
            if (btnOrderManagement != null) btnOrderManagement.Click += (s, e) => OpenForm(new OrderManagementForm());
            if (btnTransactionManagement != null) btnTransactionManagement.Click += (s, e) => OpenForm(new TransactionManagementForm());
            if (btnStaffManagement != null) btnStaffManagement.Click += (s, e) => OpenForm(new StaffManagementForm());
            if (btnInventoryManagement != null) btnInventoryManagement.Click += (s, e) => OpenForm(new PartsInventoryForm());
            if (btnRestock != null) btnRestock.Click += (s, e) => CreateRestockOrder();
            if (btnLogout != null) btnLogout.Click += (s, e) => OpenForm(new LoginForm());
        }

        // Method to open a new form
        private void OpenForm(Form form)
        {

            form.Show();
            this.Hide(); // Hide the dashboard when navigating to another form
        }

        private void DashboardForm_FormClose(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            btnExportReport.Enabled = false;
            btnPrintReport.Enabled = false;

            // Set default report type
            if (cmbReportType.Items.Count > 0)
            {
                cmbReportType.SelectedIndex = 0;
            }

            // Set date range defaults (current month)
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;
        }



        private void GenerateReportChart(DataTable reportData, string reportType)
        {
            if (reportData == null || reportData.Rows.Count == 0)
            {
                reportChart.Visible = false;
                return;
            }

            // Clear existing series
            reportChart.Series.Clear();

            // Create a new series
            Series series = new Series(reportType);
            series.ChartType = SeriesChartType.Column; // Default chart type

            switch (reportType)
            {
                case "Sales Summary":
                    // Group by month if date range spans multiple months
                    if ((dtpEndDate.Value - dtpStartDate.Value).TotalDays > 31)
                    {
                        var monthlySales = reportData.AsEnumerable()
                            .GroupBy(r => new DateTime(
                                ((DateTime)r["SaleDate"]).Year,
                                ((DateTime)r["SaleDate"]).Month, 1))
                            .Select(g => new {
                                Month = g.Key.ToString("MMM yyyy"),
                                Total = g.Sum(r => Convert.ToDecimal(r["SaleAmount"]))
                            })
                            .OrderBy(x => DateTime.ParseExact(x.Month, "MMM yyyy", null))
                            .ToList();

                        foreach (var item in monthlySales)
                        {
                            series.Points.AddXY(item.Month, (double)item.Total);
                        }

                        series.ChartType = SeriesChartType.Column;
                        reportChart.ChartAreas[0].AxisX.Title = "Month";
                        reportChart.ChartAreas[0].AxisY.Title = "Sales Amount ($)";
                    }
                    else
                    {
                        // Daily sales for shorter periods
                        var dailySales = reportData.AsEnumerable()
                            .GroupBy(r => ((DateTime)r["SaleDate"]).Date)
                            .Select(g => new {
                                Date = g.Key.ToString("MM/dd"),
                                Total = g.Sum(r => Convert.ToDecimal(r["SaleAmount"]))
                            })
                            .OrderBy(x => DateTime.ParseExact(x.Date, "MM/dd", null))
                            .ToList();

                        foreach (var item in dailySales)
                        {
                            series.Points.AddXY(item.Date, (double)item.Total);
                        }

                        series.ChartType = SeriesChartType.Line;
                        reportChart.ChartAreas[0].AxisX.Title = "Date";
                        reportChart.ChartAreas[0].AxisY.Title = "Sales Amount ($)";
                    }
                    break;

                case "Inventory Status":
                    // Group by status
                    var statusGroups = reportData.AsEnumerable()
                        .GroupBy(r => r["Status"].ToString())
                        .Select(g => new {
                            Status = g.Key,
                            Count = g.Count()
                        })
                        .OrderByDescending(x => x.Count)
                        .ToList();

                    foreach (var item in statusGroups)
                    {
                        series.Points.AddXY(item.Status, item.Count);
                    }

                    series.ChartType = SeriesChartType.Pie;
                    series.IsValueShownAsLabel = true;
                    series.Label = "#PERCENT{P0}";
                    series.LegendText = "#VALX";
                    reportChart.ChartAreas[0].AxisX.Title = "";
                    reportChart.ChartAreas[0].AxisY.Title = "";
                    break;

                case "Staff Performance":
                    // Top 5 staff by sales
                    var topStaff = reportData.AsEnumerable()
                        .OrderByDescending(r => r["TotalSales"] == DBNull.Value ? 0 : Convert.ToDecimal(r["TotalSales"]))
                        .Take(5)
                        .Select(r => new {
                            Name = r["FullName"].ToString(),
                            Sales = r["TotalSales"] == DBNull.Value ? 0 : Convert.ToDecimal(r["TotalSales"])
                        })
                        .ToList();

                    foreach (var item in topStaff)
                    {
                        series.Points.AddXY(item.Name, (double)item.Sales);
                    }

                    series.ChartType = SeriesChartType.Bar;
                    reportChart.ChartAreas[0].AxisX.Title = "Staff";
                    reportChart.ChartAreas[0].AxisY.Title = "Total Sales ($)";
                    break;

                case "Customer Activity":
                    // Customer activity by type
                    var activityTypes = reportData.AsEnumerable()
                        .GroupBy(r => r["ActivityType"].ToString())
                        .Select(g => new {
                            Type = g.Key,
                            Count = g.Count()
                        })
                        .OrderByDescending(x => x.Count)
                        .ToList();

                    foreach (var item in activityTypes)
                    {
                        series.Points.AddXY(item.Type, item.Count);
                    }

                    series.ChartType = SeriesChartType.Doughnut;
                    series.IsValueShownAsLabel = true;
                    series.Label = "#PERCENT{P0}";
                    series.LegendText = "#VALX";
                    reportChart.ChartAreas[0].AxisX.Title = "";
                    reportChart.ChartAreas[0].AxisY.Title = "";
                    break;

                case "Financial Overview":
                    // Monthly revenue vs expenses
                    Series revenueSeries = new Series("Revenue");
                    Series expenseSeries = new Series("Expenses");
                    Series profitSeries = new Series("Profit");

                    revenueSeries.ChartType = SeriesChartType.Column;
                    expenseSeries.ChartType = SeriesChartType.Column;
                    profitSeries.ChartType = SeriesChartType.Line;

                    var financialData = reportData.AsEnumerable()
                        .Select(r => new {
                            Month = r["Month"].ToString(),
                            Revenue = Convert.ToDecimal(r["Revenue"]),
                            Expenses = Convert.ToDecimal(r["Expenses"]),
                            Profit = Convert.ToDecimal(r["Profit"])
                        })
                        .OrderBy(x => DateTime.ParseExact(x.Month, "MMM yyyy", null))
                        .ToList();

                    foreach (var item in financialData)
                    {
                        revenueSeries.Points.AddXY(item.Month, (double)item.Revenue);
                        expenseSeries.Points.AddXY(item.Month, (double)item.Expenses);
                        profitSeries.Points.AddXY(item.Month, (double)item.Profit);
                    }

                    reportChart.Series.Add(revenueSeries);
                    reportChart.Series.Add(expenseSeries);
                    reportChart.Series.Add(profitSeries);

                    reportChart.ChartAreas[0].AxisX.Title = "Month";
                    reportChart.ChartAreas[0].AxisY.Title = "Amount ($)";

                    // Skip adding the default series since we added multiple series
                    series = null;
                    break;
            }

            // Add the series to the chart if not null
            if (series != null)
            {
                reportChart.Series.Add(series);
            }

            // Make the chart visible
            reportChart.Visible = true;
        }

        private void AddSummaryStatistics(DataTable reportData)
        {
            // Clear any existing summary controls
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.Tag?.ToString() == "summary")
                {
                    this.Controls.Remove(ctrl);
                }
            }

            if (reportData.Rows.Count == 0) return;

            var summaryPanel = new Panel
            {
                Tag = "summary"
            };
            this.Controls.Add(summaryPanel);

            switch (cmbReportType.SelectedItem.ToString())
            {
                case "Sales Summary":
                    decimal totalSales = Convert.ToDecimal(reportData.Compute("SUM(SaleAmount)", ""));
                    var salesLabel = new Label
                    {
                        Text = $"Total Sales: {totalSales:C} | Count: {reportData.Rows.Count}",
                        Location = new Point(10, 5),
                        AutoSize = true
                    };
                    summaryPanel.Controls.Add(salesLabel);
                    break;

                case "Inventory Status":
                    int availableCount = Convert.ToInt32(reportData.Compute("COUNT(CarID)", "Status = 'Available'"));
                    var inventoryLabel = new Label
                    {
                        Text = $"Available: {availableCount} | Total: {reportData.Rows.Count}",
                        Location = new Point(10, 5),
                        AutoSize = true
                    };
                    summaryPanel.Controls.Add(inventoryLabel);
                    break;

                case "Staff Performance":
                    decimal totalPerformance = Convert.ToDecimal(reportData.Compute("SUM(TotalSales)", ""));
                    var performanceLabel = new Label
                    {
                        Text = $"Total Sales: {totalPerformance:C} | Staff Count: {reportData.Rows.Count}",
                        Location = new Point(10, 5),
                        AutoSize = true
                    };
                    summaryPanel.Controls.Add(performanceLabel);
                    break;

                case "Customer Activity":
                    int totalActivities = reportData.Rows.Count;
                    var activityLabel = new Label
                    {
                        Text = $"Total Activities: {totalActivities}",
                        Location = new Point(10, 5),
                        AutoSize = true
                    };
                    summaryPanel.Controls.Add(activityLabel);
                    break;

                case "Financial Overview":
                    decimal totalRevenue = Convert.ToDecimal(reportData.Compute("SUM(Revenue)", ""));
                    decimal totalExpenses = Convert.ToDecimal(reportData.Compute("SUM(Expenses)", ""));
                    decimal totalProfit = Convert.ToDecimal(reportData.Compute("SUM(Profit)", ""));
                    var financeLabel = new Label
                    {
                        Text = $"Total Revenue: {totalRevenue:C} | Expenses: {totalExpenses:C} | Profit: {totalProfit:C}",
                        Location = new Point(10, 5),
                        AutoSize = true
                    };
                    summaryPanel.Controls.Add(financeLabel);
                    break;

                    // Add cases for other report types
            }
        }
        private DataTable GetSalesReport(MySqlConnection conn, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT s.SaleID, s.SaleDate, c.FullName AS Customer, 
                    car.Make, car.Model, car.Year, s.SaleAmount, s.PaymentMethod
                    FROM sales s
                    JOIN customers c ON s.CustomerID = c.CustomerID
                    JOIN cars car ON s.CarID = car.CarID
                    WHERE s.SaleDate BETWEEN @startDate AND @endDate
                    ORDER BY s.SaleDate DESC";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        private DataTable GetStaffPerformanceReport(MySqlConnection conn, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT st.StaffID, st.FullName, COUNT(s.SaleID) AS SalesCount, 
                    SUM(s.SaleAmount) AS TotalSales
                    FROM staff st
                    LEFT JOIN sales s ON st.StaffID = s.StaffID
                    AND s.SaleDate BETWEEN @startDate AND @endDate
                    GROUP BY st.StaffID, st.FullName
                    ORDER BY TotalSales DESC";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        private DataTable GetInventoryReport(MySqlConnection conn)
        {
            string query = @"SELECT CarID, Make, Model, Year, Status, Price,
                    DATEDIFF(CURRENT_DATE(), DateAdded) AS DaysInInventory
                    FROM cars 
                    ORDER BY Status, Make, Model";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        private DataTable GetCustomerActivityReport(MySqlConnection conn, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT c.CustomerID, c.FullName, c.Email, c.Phone,
                    CASE 
                        WHEN s.SaleID IS NOT NULL THEN 'Purchase'
                        WHEN o.OrderID IS NOT NULL THEN 'Order'
                        ELSE 'Inquiry'
                    END AS ActivityType,
                    COALESCE(s.SaleDate, o.OrderDate, c.LastContact) AS ActivityDate,
                    COALESCE(s.SaleAmount, o.TotalAmount, 0) AS Amount
                    FROM customers c
                    LEFT JOIN sales s ON c.CustomerID = s.CustomerID AND s.SaleDate BETWEEN @startDate AND @endDate
                    LEFT JOIN orders o ON c.CustomerID = o.CustomerID AND o.OrderDate BETWEEN @startDate AND @endDate
                    WHERE s.SaleID IS NOT NULL OR o.OrderID IS NOT NULL OR c.LastContact BETWEEN @startDate AND @endDate
                    ORDER BY ActivityDate DESC";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        private DataTable GetFinancialOverviewReport(MySqlConnection conn, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT 
                    DATE_FORMAT(MonthYear, '%b %Y') AS Month,
                    SUM(Revenue) AS Revenue,
                    SUM(Expenses) AS Expenses,
                    SUM(Revenue - Expenses) AS Profit
                    FROM (
                        SELECT 
                            DATE_FORMAT(s.SaleDate, '%Y-%m-01') AS MonthYear,
                            SUM(s.SaleAmount) AS Revenue,
                            0 AS Expenses
                        FROM sales s
                        WHERE s.SaleDate BETWEEN @startDate AND @endDate
                        GROUP BY DATE_FORMAT(s.SaleDate, '%Y-%m-01')
                        
                        UNION ALL
                        
                        SELECT 
                            DATE_FORMAT(e.ExpenseDate, '%Y-%m-01') AS MonthYear,
                            0 AS Revenue,
                            SUM(e.Amount) AS Expenses
                        FROM expenses e
                        WHERE e.ExpenseDate BETWEEN @startDate AND @endDate
                        GROUP BY DATE_FORMAT(e.ExpenseDate, '%Y-%m-01')
                    ) AS combined
                    GROUP BY MonthYear
                    ORDER BY MonthYear";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@startDate", startDate);
            cmd.Parameters.AddWithValue("@endDate", endDate);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        private void BtnExportReport_Click(object sender, EventArgs e)
        {
            if (dgvReportResults.DataSource == null || dgvReportResults.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx|PDF Files|*.pdf|CSV Files|*.csv",
                Title = "Save Report",
                FileName = $"{cmbReportType.SelectedItem}_{DateTime.Now:yyyyMMdd}"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable data = (DataTable)dgvReportResults.DataSource;
                    string fileExtension = Path.GetExtension(saveDialog.FileName).ToLower();

                    switch (fileExtension)
                    {
                        case ".xlsx":
                            ExportToExcel(data, saveDialog.FileName);
                            break;
                        case ".pdf":
                            ExportToPdf(data, saveDialog.FileName);
                            break;
                        case ".csv":
                            ExportToCsv(data, saveDialog.FileName);
                            break;
                    }

                    MessageBox.Show("Report exported successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting report: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        

        private void ExportToExcel(DataTable data, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Report");

                // Add title
                worksheet.Cell(1, 1).Value = $"{cmbReportType.SelectedItem} - {DateTime.Now:yyyy-MM-dd}";
                worksheet.Cell(1, 1).Style.Font.Bold = true;
                worksheet.Cell(1, 1).Style.Font.FontSize = 14;
                worksheet.Range(1, 1, 1, data.Columns.Count).Merge();

                // Add date range
                worksheet.Cell(2, 1).Value = $"Period: {dtpStartDate.Value:yyyy-MM-dd} to {dtpEndDate.Value:yyyy-MM-dd}";
                worksheet.Range(2, 1, 2, data.Columns.Count).Merge();

                // Add headers
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    worksheet.Cell(4, i + 1).Value = data.Columns[i].ColumnName;
                    worksheet.Cell(4, i + 1).Style.Font.Bold = true;
                    worksheet.Cell(4, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                // Add data
                for (int row = 0; row < data.Rows.Count; row++)
                {
                    for (int col = 0; col < data.Columns.Count; col++)
                    {
                        worksheet.Cell(row + 5, col + 1).Value = data.Rows[row][col].ToString();
                    }
                }

                // Auto-fit columns and add borders
                worksheet.Columns().AdjustToContents();
                worksheet.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                // Add summary at the bottom
                int summaryRow = data.Rows.Count + 6;
                worksheet.Cell(summaryRow, 1).Value = "Summary";
                worksheet.Cell(summaryRow, 1).Style.Font.Bold = true;

                // Add report-specific summaries
                switch (cmbReportType.SelectedItem.ToString())
                {
                    case "Sales Summary":
                        decimal totalSales = data.AsEnumerable().Sum(row => Convert.ToDecimal(row["SaleAmount"]));
                        worksheet.Cell(summaryRow + 1, 1).Value = $"Total Sales: {totalSales:C}";
                        worksheet.Cell(summaryRow + 2, 1).Value = $"Number of Sales: {data.Rows.Count}";
                        break;

                    case "Inventory Status":
                        int availableCount = data.AsEnumerable().Count(row => row["Status"].ToString() == "Available");
                        worksheet.Cell(summaryRow + 1, 1).Value = $"Available Cars: {availableCount}";
                        worksheet.Cell(summaryRow + 2, 1).Value = $"Total Inventory: {data.Rows.Count}";
                        break;

                    case "Staff Performance":
                        decimal totalPerformance = data.AsEnumerable()
                            .Sum(row => row["TotalSales"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TotalSales"]));
                        worksheet.Cell(summaryRow + 1, 1).Value = $"Total Sales: {totalPerformance:C}";
                        worksheet.Cell(summaryRow + 2, 1).Value = $"Number of Staff: {data.Rows.Count}";
                        break;
                }

                // Add chart if available
                if (reportChart.Visible)
                {
                    // Save chart as image
                    string tempImagePath = Path.Combine(Path.GetTempPath(), "chart.png");
                    reportChart.SaveImage(tempImagePath, ChartImageFormat.Png);

                    // Add image to worksheet
                    var chartRow = summaryRow + 4;
                    var image = worksheet.AddPicture(tempImagePath);
                    image.MoveTo(worksheet.Cell(chartRow, 1));

                    // Delete temp file
                    try { File.Delete(tempImagePath); } catch { }
                }

                workbook.SaveAs(filePath);
            }
        }

        private void ExportToPdf(DataTable data, string filePath)
        {
            // Implementation for PDF export
            // This would typically use a library like iTextSharp or similar
            MessageBox.Show("PDF export is not implemented in this version.");
        }

        private void ExportToCsv(DataTable data, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            // Add headers
            for (int i = 0; i < data.Columns.Count; i++)
            {
                sb.Append(data.Columns[i].ColumnName);
                if (i < data.Columns.Count - 1)
                    sb.Append(",");
            }
            sb.AppendLine();

            // Add data
            foreach (DataRow row in data.Rows)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    string value = row[i].ToString();
                    // Escape commas and quotes
                    if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
                    {
                        value = "\"" + value.Replace("\"", "\"\"") + "\"";
                    }
                    sb.Append(value);

                    if (i < data.Columns.Count - 1)
                        sb.Append(",");
                }
                sb.AppendLine();
            }

            File.WriteAllText(filePath, sb.ToString());
        }

        private void GenerateVisualSummary(DataTable reportData, string reportType)
        {
            pnlReportSummary.Controls.Clear();

            // Create summary title
            var lblTitle = new Label
            {
                Text = $"{reportType} Summary",
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            pnlReportSummary.Controls.Add(lblTitle);

            // Report-specific summaries
            switch (reportType)
            {
                case "Sales Summary":
                    decimal totalSales = reportData.AsEnumerable()
                        .Sum(row => row.Field<decimal>("SaleAmount"));

                    var salesLabel = new Label
                    {
                        Text = $"Total Sales: {totalSales:C}",
                        Location = new Point(10, 40),
                        AutoSize = true
                    };
                    pnlReportSummary.Controls.Add(salesLabel);

                    // Add top selling models
                    var topModels = reportData.AsEnumerable()
                        .GroupBy(row => $"{row.Field<string>("Make")} {row.Field<string>("Model")}")
                        .Select(g => new { Model = g.Key, Count = g.Count() })
                        .OrderByDescending(x => x.Count)
                        .Take(3)
                        .ToList();

                    if (topModels.Any())
                    {
                        var topModelLabel = new Label
                        {
                            Text = "Top Selling Models:",
                            Location = new Point(10, 70),
                            AutoSize = true,
                            Font = new Font("Arial", 10, FontStyle.Bold)
                        };
                        pnlReportSummary.Controls.Add(topModelLabel);

                        for (int i = 0; i < topModels.Count; i++)
                        {
                            var modelLabel = new Label
                            {
                                Text = $"{i + 1}. {topModels[i].Model} ({topModels[i].Count} sales)",
                                Location = new Point(20, 100 + i * 25),
                                AutoSize = true
                            };
                            pnlReportSummary.Controls.Add(modelLabel);
                        }
                    }
                    break;

                case "Staff Performance":
                    var topPerformer = reportData.AsEnumerable()
                        .OrderByDescending(row => row.Field<decimal>("TotalSales"))
                        .FirstOrDefault();

                    if (topPerformer != null)
                    {
                        var perfLabel = new Label
                        {
                            Text = $"Top Performer: {topPerformer["FullName"]} ({topPerformer["TotalSales"]:C})",
                            Location = new Point(10, 40),
                            AutoSize = true
                        };
                        pnlReportSummary.Controls.Add(perfLabel);

                        // Add performance distribution
                        var totalStaffSales = reportData.AsEnumerable()
                            .Sum(row => Convert.ToDecimal(row["TotalSales"]));

                        var topPerformers = reportData.AsEnumerable()
                            .OrderByDescending(row => Convert.ToDecimal(row["TotalSales"]))
                            .Take(3)
                            .ToList();

                        var distributionLabel = new Label
                        {
                            Text = "Sales Distribution:",
                            Location = new Point(10, 70),
                            AutoSize = true,
                            Font = new Font("Arial", 10, FontStyle.Bold)
                        };
                        pnlReportSummary.Controls.Add(distributionLabel);

                        for (int i = 0; i < topPerformers.Count; i++)
                        {
                            decimal sales = Convert.ToDecimal(topPerformers[i]["TotalSales"]);
                            decimal percentage = totalStaffSales > 0 ? (sales / totalStaffSales) * 100 : 0;

                            var staffLabel = new Label
                            {
                                Text = $"{topPerformers[i]["FullName"]} - {sales:C} ({percentage:F1}%)",
                                Location = new Point(20, 100 + i * 25),
                                AutoSize = true
                            };
                            pnlReportSummary.Controls.Add(staffLabel);
                        }
                    }
                    break;

                case "Inventory Status":
                    // Count by status
                    var statusCounts = reportData.AsEnumerable()
                        .GroupBy(row => row.Field<string>("Status"))
                        .Select(g => new { Status = g.Key, Count = g.Count() })
                        .OrderByDescending(x => x.Count)
                        .ToList();

                    var statusLabel = new Label
                    {
                        Text = "Inventory by Status:",
                        Location = new Point(10, 40),
                        AutoSize = true,
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };
                    pnlReportSummary.Controls.Add(statusLabel);

                    for (int i = 0; i < statusCounts.Count; i++)
                    {
                        var countLabel = new Label
                        {
                            Text = $"{statusCounts[i].Status}: {statusCounts[i].Count} cars",
                            Location = new Point(20, 70 + i * 25),
                            AutoSize = true
                        };
                        pnlReportSummary.Controls.Add(countLabel);
                    }

                    // Average days in inventory
                    var avgDays = reportData.AsEnumerable()
                        .Average(row => Convert.ToInt32(row["DaysInInventory"]));

                    var daysLabel = new Label
                    {
                        Text = $"Average Days in Inventory: {avgDays:F1} days",
                        Location = new Point(10, 70 + statusCounts.Count * 25 + 10),
                        AutoSize = true,
                        Font = new Font("Arial", 10)
                    };
                    pnlReportSummary.Controls.Add(daysLabel);
                    break;

                case "Customer Activity":
                    // Activity by type
                    var activityTypes = reportData.AsEnumerable()
                        .GroupBy(row => row.Field<string>("ActivityType"))
                        .Select(g => new { Type = g.Key, Count = g.Count() })
                        .OrderByDescending(x => x.Count)
                        .ToList();

                    var activityLabel = new Label
                    {
                        Text = "Activities by Type:",
                        Location = new Point(10, 40),
                        AutoSize = true,
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };
                    pnlReportSummary.Controls.Add(activityLabel);

                    for (int i = 0; i < activityTypes.Count; i++)
                    {
                        var typeLabel = new Label
                        {
                            Text = $"{activityTypes[i].Type}: {activityTypes[i].Count} activities",
                            Location = new Point(20, 70 + i * 25),
                            AutoSize = true
                        };
                        pnlReportSummary.Controls.Add(typeLabel);
                    }

                    // Total amount
                    var totalAmount = reportData.AsEnumerable()
                        .Sum(row => Convert.ToDecimal(row["Amount"]));

                    var amountLabel = new Label
                    {
                        Text = $"Total Activity Amount: {totalAmount:C}",
                        Location = new Point(10, 70 + activityTypes.Count * 25 + 10),
                        AutoSize = true,
                        Font = new Font("Arial", 10)
                    };
                    pnlReportSummary.Controls.Add(amountLabel);
                    break;

                case "Financial Overview":
                    // Total revenue, expenses, profit
                    decimal totalRevenue = reportData.AsEnumerable()
                        .Sum(row => Convert.ToDecimal(row["Revenue"]));

                    decimal totalExpenses = reportData.AsEnumerable()
                        .Sum(row => Convert.ToDecimal(row["Expenses"]));

                    decimal totalProfit = reportData.AsEnumerable()
                        .Sum(row => Convert.ToDecimal(row["Profit"]));

                    var revenueLabel = new Label
                    {
                        Text = $"Total Revenue: {totalRevenue:C}",
                        Location = new Point(10, 40),
                        AutoSize = true
                    };
                    pnlReportSummary.Controls.Add(revenueLabel);

                    var expensesLabel = new Label
                    {
                        Text = $"Total Expenses: {totalExpenses:C}",
                        Location = new Point(10, 70),
                        AutoSize = true
                    };
                    pnlReportSummary.Controls.Add(expensesLabel);

                    var profitLabel = new Label
                    {
                        Text = $"Total Profit: {totalProfit:C}",
                        Location = new Point(10, 100),
                        AutoSize = true,
                        Font = new Font("Arial", 10, FontStyle.Bold)
                    };
                    pnlReportSummary.Controls.Add(profitLabel);

                    // Profit margin
                    decimal profitMargin = totalRevenue > 0 ? (totalProfit / totalRevenue) * 100 : 0;

                    var marginLabel = new Label
                    {
                        Text = $"Profit Margin: {profitMargin:F1}%",
                        Location = new Point(10, 130),
                        AutoSize = true
                    };
                    pnlReportSummary.Controls.Add(marginLabel);
                    break;
            }
        }

        private void CreateRestockOrder()
        {
            // Implement your restock logic here add the email to send Order to the supplier
            MessageBox.Show("Restock order created for all low stock items!");
        }


        private void dgvReportResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPendingApprovals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Select the row when a cell is clicked
            if (e.RowIndex >= 0)
            {
                dgvPendingApprovals.ClearSelection();
                dgvPendingApprovals.Rows[e.RowIndex].Selected = true;
            }

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM staff WHERE IsApproved = FALSE";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvPendingApprovals.DataSource = dt;

                    lblPendingApprovals.Text = $"Staff Awaiting Approval ({dt.Rows.Count})";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading pending approvals: " + ex.Message);
                }
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            if (dgvReportResults.DataSource == null || dgvReportResults.Rows.Count == 0)
            {
                MessageBox.Show("No data to print.");
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                // Print title
                string title = $"{cmbReportType.SelectedItem} - {DateTime.Now:yyyy-MM-dd}";
                Font titleFont = new Font("Arial", 16, FontStyle.Bold);
                ev.Graphics.DrawString(title, titleFont, Brushes.Black, 100, 100);

                // Print date range
                string dateRange = $"Period: {dtpStartDate.Value:yyyy-MM-dd} to {dtpEndDate.Value:yyyy-MM-dd}";
                Font dateFont = new Font("Arial", 12);
                ev.Graphics.DrawString(dateRange, dateFont, Brushes.Black, 100, 130);

                // Print table headers
                DataTable data = (DataTable)dgvReportResults.DataSource;
                Font headerFont = new Font("Arial", 10, FontStyle.Bold);
                Font dataFont = new Font("Arial", 10);
                int y = 170;
                int x = 100;

                // Calculate column widths
                int[] colWidths = new int[data.Columns.Count];
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    colWidths[i] = Math.Min(150, Math.Max(100, data.Columns[i].ColumnName.Length * 10));
                }

                // Draw headers
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    ev.Graphics.DrawString(data.Columns[i].ColumnName, headerFont, Brushes.Black, x, y);
                    x += colWidths[i];
                }

                // Draw data (limited to first page)
                y += 25;
                int maxRows = Math.Min(data.Rows.Count, 20); // Limit to 20 rows for first page

                for (int row = 0; row < maxRows; row++)
                {
                    x = 100;
                    for (int col = 0; col < data.Columns.Count; col++)
                    {
                        ev.Graphics.DrawString(data.Rows[row][col].ToString(), dataFont, Brushes.Black, x, y);
                        x += colWidths[col];
                    }
                    y += 20;

                    // Check if we're running out of page space
                    if (y > ev.MarginBounds.Bottom - 50)
                    {
                        ev.Graphics.DrawString("(Continued on next page...)", dataFont, Brushes.Black, 100, y);
                        ev.HasMorePages = true;
                        return;
                    }
                }

                // Add summary at the bottom
                y += 20;
                ev.Graphics.DrawString("Summary:", headerFont, Brushes.Black, 100, y);
                y += 25;

                // Add report-specific summaries
                switch (cmbReportType.SelectedItem.ToString())
                {
                    case "Sales Summary":
                        decimal totalSales = data.AsEnumerable().Sum(row => Convert.ToDecimal(row["SaleAmount"]));
                        ev.Graphics.DrawString($"Total Sales: {totalSales:C}", dataFont, Brushes.Black, 100, y);
                        y += 20;
                        ev.Graphics.DrawString($"Number of Sales: {data.Rows.Count}", dataFont, Brushes.Black, 100, y);
                        break;

                    case "Inventory Status":
                        int availableCount = data.AsEnumerable().Count(row => row["Status"].ToString() == "Available");
                        ev.Graphics.DrawString($"Available Cars: {availableCount}", dataFont, Brushes.Black, 100, y);
                        y += 20;
                        ev.Graphics.DrawString($"Total Inventory: {data.Rows.Count}", dataFont, Brushes.Black, 100, y);
                        break;
                }

                // Add page number
                ev.Graphics.DrawString($"Page 1", dataFont, Brushes.Black, ev.MarginBounds.Right - 50, ev.MarginBounds.Bottom - 20);
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }



        private void btnApprove_Click_1(object sender, EventArgs e)
        {
            if (dgvPendingApprovals.SelectedRows.Count > 0)
            {
                int staffId = Convert.ToInt32(dgvPendingApprovals.SelectedRows[0].Cells["StaffID"].Value);
                string staffName = dgvPendingApprovals.SelectedRows[0].Cells["FullName"].Value.ToString();
                ApproveStaff(staffId, staffName);

                MessageBox.Show("Staff Member selected approved");
            }
            else
            {
                MessageBox.Show("Please select a staff member to approve.");
            }
        }

        private void btnReject_Click_1(object sender, EventArgs e)
        {
            if (dgvPendingApprovals.SelectedRows.Count > 0)
            {
                int staffId = Convert.ToInt32(dgvPendingApprovals.SelectedRows[0].Cells["StaffID"].Value);
                string staffName = dgvPendingApprovals.SelectedRows[0].Cells["FullName"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to reject {staffName}? This action cannot be undone.",
                    "Confirm Rejection",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    RejectStaff(staffId, staffName);
                }
            }
            else
            {
                MessageBox.Show("Please select a staff member to reject.");
            }
        }

        private void btnGenerateReport_Click_1(object sender, EventArgs e)
        {
            string selectedReport = cmbReportType.SelectedItem?.ToString();
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            if (string.IsNullOrEmpty(selectedReport))
            {
                MessageBox.Show("Please select a report type.");
                return;
            }

            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    DataTable reportData = new DataTable();

                    switch (selectedReport)
                    {
                        case "Sales Summary":
                            reportData = GetSalesReport(conn, startDate, endDate);
                            break;
                        case "Inventory Status":
                            reportData = GetInventoryReport(conn);
                            break;
                        case "Staff Performance":
                            reportData = GetStaffPerformanceReport(conn, startDate, endDate);
                            break;
                        case "Customer Activity":
                            reportData = GetCustomerActivityReport(conn, startDate, endDate);
                            break;
                        case "Financial Overview":
                            reportData = GetFinancialOverviewReport(conn, startDate, endDate);
                            break;

                    }

                    dgvReportResults.DataSource = reportData;
                    btnExportReport.Enabled = reportData.Rows.Count > 0;
                    btnPrintReport.Enabled = reportData.Rows.Count > 0;

                    // Generate visual summary
                    GenerateVisualSummary(reportData, selectedReport);

                    // Generate chart visualization
                    GenerateReportChart(reportData, selectedReport);

                    AddSummaryStatistics(reportData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}");
            }
        }
    }
}
