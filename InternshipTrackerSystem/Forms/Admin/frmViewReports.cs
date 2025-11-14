using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InternshipTrackerSystem.Forms.Admin
{
    public partial class frmViewReports : Form
    {
        private string connectionString;

        public frmViewReports(string connStr)
        {
            InitializeComponent();
            connectionString = connStr;
        }

        private void frmViewReports_Load(object sender, EventArgs e)
        {
            lblReportsTitle.Text = "View Reports";
            LoadReports();
        }

        private void LoadReports()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // 使用视图 vw_AllStudents / vw_AllCompaniesWithPositions / vw_AllApplications
                    DataTable report = new DataTable();

                    // 示例：统计学生总数
                    string studentQuery = "SELECT COUNT(*) AS TotalStudents FROM Students";
                    SqlDataAdapter da = new SqlDataAdapter(studentQuery, conn);
                    da.Fill(report);

                    dgvReports.DataSource = report;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reports: " + ex.Message);
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report generated (demo only).");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exported to CSV (demo only).");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
