using InternshipTrackerSystem.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternshipTrackerSystem.Forms.Student_Lai
{
    public partial class frmSearchInternship : Form
    {
        private int studentId;

        public frmSearchInternship(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            LoadFilters();
            SearchInternships();

            // Wire up event handlers
            btnSearch.Click += btnSearch_Click;
            dgvInternships.CellContentClick += dgvInternships_CellContentClick;
        }

        private void LoadFilters()
        {
            try
            {
                // Load locations
                cmbLocation.Items.Clear();
                cmbLocation.Items.Add("All");
                DataTable locations = StudentClass.GetAvailableLocations();
                foreach (DataRow row in locations.Rows)
                {
                    cmbLocation.Items.Add(row["location"].ToString());
                }
                cmbLocation.SelectedIndex = 0;

                // Load companies
                cmbCompany.Items.Clear();
                cmbCompany.Items.Add("All");
                DataTable companies = StudentClass.GetAvailableCompanies();
                foreach (DataRow row in companies.Rows)
                {
                    cmbCompany.Items.Add(row["companyname"].ToString());
                }
                cmbCompany.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading filters: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchInternships()
        {
            try
            {
                string searchText = txtSearch.Text.Trim();
                string location = cmbLocation.SelectedItem?.ToString() ?? "All";
                string company = cmbCompany.SelectedItem?.ToString() ?? "All";

                DataTable results = StudentClass.SearchInternships(searchText, location, company);

                dgvInternships.Rows.Clear();
                foreach (DataRow row in results.Rows)
                {
                    int index = dgvInternships.Rows.Add();
                    dgvInternships.Rows[index].Cells["colPosition"].Value = row["title"];
                    dgvInternships.Rows[index].Cells["colCompany"].Value = row["companyname"];
                    dgvInternships.Rows[index].Cells["colLocation"].Value = row["location"];
                    dgvInternships.Rows[index].Cells["colDeadline"].Value = Convert.ToDateTime(row["applicationdeadline"]).ToString("MMM dd, yyyy");
                    dgvInternships.Rows[index].Tag = row["positionid"]; // Store position ID
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching internships: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchInternships();
        }

        private void dgvInternships_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvInternships.Columns[e.ColumnIndex].Name == "colView")
            {
                int positionId = Convert.ToInt32(dgvInternships.Rows[e.RowIndex].Tag);
                frmInternDetails detailsForm = new frmInternDetails(positionId, studentId);
                detailsForm.ShowDialog();
                SearchInternships(); // Refresh after viewing
            }
        }
    }
}
