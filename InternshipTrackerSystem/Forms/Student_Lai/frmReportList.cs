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
    public partial class frmReportList : Form
    {
        private int studentId;

        public frmReportList(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            cmbStatusFilter.SelectedIndex = 0;
            LoadReports();

            // Wire up event handlers
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            btnRefresh.Click += btnRefresh_Click;
            dgvReports.CellContentClick += dgvReports_CellContentClick;
        }

        private void LoadReports()
        {
            try
            {
                string status = cmbStatusFilter.SelectedItem?.ToString() ?? "All";
                DataTable reports = StudentClass.GetStudentReports(studentId, status);

                dgvReports.Rows.Clear();
                foreach (DataRow row in reports.Rows)
                {
                    int index = dgvReports.Rows.Add();
                    dgvReports.Rows[index].Cells["colType"].Value = row["reporttype"];
                    dgvReports.Rows[index].Cells["colCompany"].Value = row["companyname"];
                    dgvReports.Rows[index].Cells["colPosition"].Value = row["positiontitle"];
                    dgvReports.Rows[index].Cells["colSubmittedOn"].Value = Convert.ToDateTime(row["submissiondate"]).ToString("MMM dd, yyyy");
                    dgvReports.Rows[index].Cells["colStatus"].Value = row["status"];
                    dgvReports.Rows[index].Tag = row["reportid"];

                    // Color code status
                    string reportStatus = row["status"].ToString();
                    if (reportStatus == "Approved")
                        dgvReports.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    else if (reportStatus == "Rejected")
                        dgvReports.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                    else if (reportStatus == "Submitted")
                        dgvReports.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reports: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void dgvReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvReports.Columns[e.ColumnIndex].Name == "colAction")
            {
                int reportId = Convert.ToInt32(dgvReports.Rows[e.RowIndex].Tag);
                frmReportDetails detailsForm = new frmReportDetails(reportId, studentId);
                detailsForm.ShowDialog();
                LoadReports(); // Refresh after viewing
            }
        }
    }
}
