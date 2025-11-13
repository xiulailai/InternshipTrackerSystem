using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternshipTrackerSystem.Forms.Admin
{
    public partial class frmViewReports : Form
    {
        public frmViewReports()
        {
            InitializeComponent();
        }

        private void frmViewReports_Load(object sender, EventArgs e)
        {
            lblReportsTitle.Text = "View Reports";

            // Create demo table (no database yet)
            var table = new System.Data.DataTable();
            table.Columns.Add("Category");
            table.Columns.Add("Count");

            table.Rows.Add("Total Students", "120");
            table.Rows.Add("Total Companies", "35");
            table.Rows.Add("Total Applications", "210");
            table.Rows.Add("Approved Applications", "180");

            dgvReports.DataSource = table;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report generated (demo only).");
            // TODO: Generate actual report from database
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exported to CSV (demo only).");
            // TODO: Export logic when database available
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}