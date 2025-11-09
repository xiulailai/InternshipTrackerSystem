using InternshipTrackerSystem.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternshipTrackerSystem.Forms.CompanyHR
{
    public partial class frmReviewApplications : Form
    {
        private int hrId;
        private int companyId;
        private string companyName;
        private int selectedApplicationId = 0;

        public frmReviewApplications(int hrId, int companyId)
        {
            InitializeComponent();
            this.hrId = hrId;
            this.companyId = companyId;

            // Set form properties
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void frmReviewApplications_Load(object sender, EventArgs e)
        {
            try
            {
                // Load company name
                LoadCompanyName();

                // Setup filters
                SetupStatusFilter();
                SetupPositionFilter();

                // Setup DataGridView
                SetupDataGridView();

                // Load applications
                LoadApplications();

                // Disable action controls initially
                DisableActionControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void LoadCompanyName()
        {
            try
            {
                companyName = CompanyHRClass.GetCompanyName(companyId);
                lblCompanyName.Text = $"Company: {companyName}";
                this.Text = $"Review Applications - {companyName}";
            }
            catch (Exception ex)
            {
                lblCompanyName.Text = "Company: Unknown";
                MessageBox.Show($"Error loading company name: {ex.Message}",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        private void SetupStatusFilter()
        {
            cboStatusFilter.Items.Clear();
            cboStatusFilter.Items.Add("All");
            cboStatusFilter.Items.Add("Pending");
            cboStatusFilter.Items.Add("Accepted");
            cboStatusFilter.Items.Add("Rejected");
            cboStatusFilter.SelectedIndex = 1; // Default to "Pending"
        }
        private void SetupPositionFilter()
        {
            try
            {
                cboPositionFilter.Items.Clear();
                cboPositionFilter.Items.Add("All");

                DataTable positions = CompanyHRClass.GetCompanyPositionsList(companyId);
                foreach (DataRow row in positions.Rows)
                {
                    cboPositionFilter.Items.Add(row["title"].ToString());
                }

                cboPositionFilter.SelectedIndex = 0; // Default to "All"
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading positions filter: {ex.Message}",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        private void SetupDataGridView()
        {
            dgvApplications.AutoGenerateColumns = true;
            dgvApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApplications.MultiSelect = false;
            dgvApplications.ReadOnly = true;
            dgvApplications.AllowUserToAddRows = false;
            dgvApplications.AllowUserToDeleteRows = false;
            dgvApplications.RowHeadersVisible = false;
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvApplications.BackgroundColor = Color.White;
            dgvApplications.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }
        private void LoadApplications()
        {
            try
            {
                string statusFilter = cboStatusFilter.SelectedItem.ToString();
                string positionFilter = cboPositionFilter.SelectedItem.ToString();

                DataTable dt = CompanyHRClass.GetApplicationsByCompany(companyId, statusFilter, positionFilter);

                dgvApplications.DataSource = dt;

                // Format columns
                if (dgvApplications.Columns.Count > 0)
                {
                    dgvApplications.Columns["applicationid"].HeaderText = "Application ID";
                    dgvApplications.Columns["applicationid"].Width = 100;
                    dgvApplications.Columns["studentname"].HeaderText = "Student Name";
                    dgvApplications.Columns["studentname"].Width = 150;
                    dgvApplications.Columns["positiontitle"].HeaderText = "Position Title";
                    dgvApplications.Columns["positiontitle"].Width = 180;
                    dgvApplications.Columns["applieddate"].HeaderText = "Applied Date";
                    dgvApplications.Columns["applieddate"].Width = 120;
                    dgvApplications.Columns["status"].HeaderText = "Status";
                    dgvApplications.Columns["status"].Width = 100;

                    // Hide IDs
                    if (dgvApplications.Columns.Contains("studentid"))
                        dgvApplications.Columns["studentid"].Visible = false;
                    if (dgvApplications.Columns.Contains("positionid"))
                        dgvApplications.Columns["positionid"].Visible = false;

                    // Color code status
                    FormatStatusColumn();
                }

                // Clear details panel
                ClearDetailsPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading applications: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void FormatStatusColumn()
        {
            foreach (DataGridViewRow row in dgvApplications.Rows)
            {
                if (row.Cells["status"].Value != null)
                {
                    string status = row.Cells["status"].Value.ToString();
                    if (status == "Pending")
                    {
                        row.Cells["status"].Style.ForeColor = Color.Orange;
                        row.Cells["status"].Style.Font = new Font(dgvApplications.Font, FontStyle.Bold);
                    }
                    else if (status == "Accepted")
                    {
                        row.Cells["status"].Style.ForeColor = Color.Green;
                        row.Cells["status"].Style.Font = new Font(dgvApplications.Font, FontStyle.Bold);
                    }
                    else if (status == "Rejected")
                    {
                        row.Cells["status"].Style.ForeColor = Color.Red;
                    }
                }
            }
        }
        private void dgvApplications_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count > 0)
            {
                LoadApplicationDetails();
                EnableActionControls();
            }
            else
            {
                ClearDetailsPanel();
                DisableActionControls();
            }
        }
        private void LoadApplicationDetails()
        {
            try
            {
                selectedApplicationId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["applicationid"].Value);

                DataTable dt = CompanyHRClass.GetApplicationDetails(selectedApplicationId);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Student information
                    lblStudent.Text = $"Student: {row["studentname"]}";
                    lblStudentID.Text = $"Student ID: {row["matricno"]}";
                    lblProgram.Text = $"Program: {row["program"]}";
                    lblCGPA.Text = $"CGPA: {row["cgpa"]}";
                    lblContact.Text = $"Contact: {row["contactno"]}";
                    lblEmail.Text = $"Email: {row["email"]}";

                    // Application information
                    lblPositionApplied.Text = $"Position Applied: {row["positiontitle"]}";
                    lblAppliedDate.Text = $"Applied Date: {Convert.ToDateTime(row["applieddate"]):dd/MM/yyyy hh:mm tt}";

                    // Skills
                    lblSkills.Text = $"Skills: {row["skills"]}";

                    // Previous remarks
                    lblRemarks.Text = row["remarks"] != DBNull.Value ?
                        $"Remarks: {row["remarks"]}" :
                        "Remarks: No previous remarks";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading application details: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ClearDetailsPanel()
        {
            lblStudent.Text = "Student: -";
            lblStudentID.Text = "Student ID: -";
            lblProgram.Text = "Program: -";
            lblCGPA.Text = "CGPA: -";
            lblContact.Text = "Contact: -";
            lblEmail.Text = "Email: -";
            lblPositionApplied.Text = "Position Applied: -";
            lblAppliedDate.Text = "Applied Date: -";
            lblSkills.Text = "Skills: -";
            lblRemarks.Text = "Remarks: -";
        }
        private void EnableActionControls()
        {
            btnAccept.Enabled = true;
            btnReject.Enabled = true;
        }
        private void DisableActionControls()
        {
            btnAccept.Enabled = false;
            btnReject.Enabled = false;
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedApplicationId == 0)
                {
                    MessageBox.Show("Please select an application to accept.",
                        "No Selection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Get current application data
                string studentName = lblStudent.Text.Replace("Student: ", "");
                string positionTitle = lblPositionApplied.Text.Replace("Position Applied: ", "");

                // Open the accept application popup form
                frmAcceptApplication acceptForm = new frmAcceptApplication(
                    selectedApplicationId,
                    hrId,
                    studentName,
                    positionTitle);

                DialogResult result = acceptForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Reload applications after successful acceptance
                    LoadApplications();
                    ClearDetailsPanel();
                    DisableActionControls();

                    MessageBox.Show("Application accepted successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error accepting application: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedApplicationId == 0)
                {
                    MessageBox.Show("Please select an application to reject.",
                        "No Selection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Get current application data
                string studentName = lblStudent.Text.Replace("Student: ", "");
                string positionTitle = lblPositionApplied.Text.Replace("Position Applied: ", "");

                // Open the reject application popup form
                frmRejectApplication rejectForm = new frmRejectApplication(
                    selectedApplicationId,
                    hrId,
                    studentName,
                    positionTitle);

                DialogResult result = rejectForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    // Reload applications after successful rejection
                    LoadApplications();
                    ClearDetailsPanel();
                    DisableActionControls();

                    MessageBox.Show("Application rejected successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error rejecting application: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadApplications();
        }

        private void cboStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadApplications();
        }

        private void cboPositionFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadApplications();
        }

        private void dgvApplications_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadApplicationDetails();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
