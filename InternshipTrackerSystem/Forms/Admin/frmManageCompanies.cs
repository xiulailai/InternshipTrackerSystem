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
    public partial class frmManageCompanies : Form
    {
        public frmManageCompanies()
        {
            InitializeComponent();
        }

        private void frmManageCompanies_Load(object sender, EventArgs e)
        {
            lblCompaniesTitle.Text = "Manage Companies";

            // Fake database table for demo
            DataTable table = new DataTable();
            table.Columns.Add("CompanyID");
            table.Columns.Add("CompanyName");
            table.Columns.Add("Industry");
            table.Columns.Add("ContactEmail");

            // Add sample rows
            table.Rows.Add("C001", "TechNova Sdn Bhd", "IT", "hr@technova.com");
            table.Rows.Add("C002", "GreenField Co", "Agriculture", "info@greenfield.com");
            table.Rows.Add("C003", "FinancePlus", "Banking", "jobs@financeplus.com");
            table.Rows.Add("C004", "MediCare", "Healthcare", "contact@medicare.com");

            // Bind to grid
            dgvCompanies.DataSource = table;
        }


        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Company clicked");
            // TODO: open Add Company form or dialog
        }

        private void btnEditCompany_Click(object sender, EventArgs e)
        {
            if (dgvCompanies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a company to edit.");
                return;
            }
            MessageBox.Show("Edit Company clicked for selected row");
            // TODO: open Edit Company form
        }

        private void btnDeleteCompany_Click(object sender, EventArgs e)
        {
            if (dgvCompanies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a company to delete.");
                return;
            }
            var confirm = MessageBox.Show(
                "Are you sure you want to delete this company?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (confirm == DialogResult.Yes)
            {
                MessageBox.Show("Company deleted (demo)");
                // TODO: perform actual delete when DB is ready
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditCompany_Click_1(object sender, EventArgs e)
        {

        }
    }
}