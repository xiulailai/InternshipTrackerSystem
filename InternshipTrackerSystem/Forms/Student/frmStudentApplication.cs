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
    public partial class frmStudentApplication : Form
    {
        private int studentId;

        public frmStudentApplication(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            cmbFilterStatus.SelectedIndex = 0;
            LoadApplications();

            // Wire up event handlers
            cmbFilterStatus.SelectedIndexChanged += cmbFilterStatus_SelectedIndexChanged;
            btnRefresh.Click += btnRefresh_Click;
            dgvApplications.CellContentClick += dgvApplications_CellContentClick;
        }

        private void LoadApplications()
        {
            try
            {
                string status = cmbFilterStatus.SelectedItem?.ToString() ?? "All";
                DataTable applications = StudentClass.GetStudentApplications(studentId, status);

                dgvApplications.Rows.Clear();
                foreach (DataRow row in applications.Rows)
                {
                    int index = dgvApplications.Rows.Add();
                    dgvApplications.Rows[index].Cells["colTitle"].Value = row["positiontitle"];
                    dgvApplications.Rows[index].Cells["colCompany"].Value = row["companyname"];
                    dgvApplications.Rows[index].Cells["colDateApplied"].Value = Convert.ToDateTime(row["applicationdate"]).ToString("MMM dd, yyyy");
                    dgvApplications.Rows[index].Cells["colStatus"].Value = row["status"];
                    dgvApplications.Rows[index].Tag = row["applicationid"]; // Store application ID

                    // Color code status
                    string appStatus = row["status"].ToString();
                    if (appStatus == "Accepted")
                        dgvApplications.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    else if (appStatus == "Rejected")
                        dgvApplications.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                    else if (appStatus == "Pending")
                        dgvApplications.Rows[index].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading applications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadApplications();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadApplications();
        }

        private void dgvApplications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvApplications.Columns[e.ColumnIndex].Name == "colActions")
            {
                int applicationId = Convert.ToInt32(dgvApplications.Rows[e.RowIndex].Tag);
                string status = dgvApplications.Rows[e.RowIndex].Cells["colStatus"].Value.ToString();

                // Show options
                if (status == "Pending")
                {
                    DialogResult result = MessageBox.Show(
                        "Do you want to cancel this application?",
                        "Cancel Application",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        CancelApplication(applicationId);
                    }
                }
                else
                {
                    MessageBox.Show($"Application Status: {status}\n\nYou can only cancel pending applications.",
                        "Application Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CancelApplication(int applicationId)
        {
            try
            {
                bool success = StudentClass.CancelApplication(applicationId);
                if (success)
                {
                    MessageBox.Show("Application cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadApplications();
                }
                else
                {
                    MessageBox.Show("Failed to cancel application!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
