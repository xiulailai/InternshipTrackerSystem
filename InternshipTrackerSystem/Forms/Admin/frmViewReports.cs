using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InternshipTrackerSystem.Forms.Admin
{
    public partial class frmViewReports : Form
    {
        private string connectionString = @"Server=localhost\SQLEXPRESS;Database=InternshipTracker;Trusted_Connection=True;";

        public frmViewReports()
        {
            InitializeComponent();
        }

        private void frmViewReports_Load(object sender, EventArgs e)
        {
            lblReportsTitle.Text = "Reports";
            LoadReports();
        }

        private void LoadReports()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM vw_ApplicationStatistics";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvReports.DataSource = dt;
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
