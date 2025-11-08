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

namespace InternshipTrackerSystem.Forms.CompanyHR
{
    public partial class frmManagePositions : Form
    {
        private int hrId;
        private int companyId;
        private string companyName;

        public frmManagePositions(int hrId, int companyId)
        {
            InitializeComponent();
            this.hrId = hrId;
            this.companyId = companyId;

            // Set form properties
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void LoadCompanyName()
        {
            try
            {
                companyName = CompanyHRClass.GetCompanyName(companyId);
                lblCompanyName.Text = $"Company: {companyName}";
                this.Text = $"Manage Positions - {companyName}";
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
            cboStatusFilter.Items.Add("Open");
            cboStatusFilter.Items.Add("Closed");
            cboStatusFilter.SelectedIndex = 0; // Default to "All"
        }

        private void SetupDataGridView()
        {
            // Configure DataGridView appearance
            dgvPositions.AutoGenerateColumns = true;
            dgvPositions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPositions.MultiSelect = false;
            dgvPositions.ReadOnly = true;
            dgvPositions.AllowUserToAddRows = false;
            dgvPositions.AllowUserToDeleteRows = false;
            dgvPositions.RowHeadersVisible = false;
            dgvPositions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPositions.BackgroundColor = Color.White;
            dgvPositions.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void LoadPositions()
        {
            try
            {
                string statusFilter = cboStatusFilter.SelectedItem.ToString();
                DataTable dt = CompanyHRClass.GetCompanyPositions(companyId, statusFilter);

                dgvPositions.DataSource = dt;

                // Format columns
                if (dgvPositions.Columns.Count > 0)
                {
                    dgvPositions.Columns["positionid"].Visible = false;
                    dgvPositions.Columns["title"].HeaderText = "Position Title";
                    dgvPositions.Columns["title"].Width = 200;
                    dgvPositions.Columns["description"].HeaderText = "Description";
                    dgvPositions.Columns["description"].Width = 250;
                    dgvPositions.Columns["requirements"].HeaderText = "Requirements";
                    dgvPositions.Columns["requirements"].Width = 200;
                    dgvPositions.Columns["status"].HeaderText = "Status";
                    dgvPositions.Columns["status"].Width = 80;
                    dgvPositions.Columns["posteddate"].HeaderText = "Posted Date";
                    dgvPositions.Columns["posteddate"].Width = 100;
                    dgvPositions.Columns["applications"].HeaderText = "Applications";
                    dgvPositions.Columns["applications"].Width = 100;

                    // Color code status
                    FormatStatusColumn();
                }

                // Enable/disable buttons based on selection
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading positions: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FormatStatusColumn()
        {
            foreach (DataGridViewRow row in dgvPositions.Rows)
            {
                if (row.Cells["status"].Value != null)
                {
                    string status = row.Cells["status"].Value.ToString();
                    if (status == "Open")
                    {
                        row.Cells["status"].Style.ForeColor = Color.Green;
                        row.Cells["status"].Style.Font = new Font(dgvPositions.Font, FontStyle.Bold);
                    }
                    else if (status == "Closed")
                    {
                        row.Cells["status"].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = dgvPositions.SelectedRows.Count > 0;
            btnView.Enabled = hasSelection;
            btnEdit.Enabled = hasSelection;
            btnToggleStatus.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;

            // Update toggle button text based on selected status
            if (hasSelection)
            {
                string status = dgvPositions.SelectedRows[0].Cells["status"].Value.ToString();
                btnToggleStatus.Text = status == "Open" ? "Close Position" : "Open Position";
            }
            else
            {
                btnToggleStatus.Text = "Toggle Status";
            }
        }

        private void frmManagePositions_Load(object sender, EventArgs e)
        {
            try
            {
                // Load company name
                LoadCompanyName();

                // Setup status filter combo box
                SetupStatusFilter();

                // Setup DataGridView
                SetupDataGridView();

                // Load positions
                LoadPositions();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmCreatePosition createForm = new frmCreatePosition(hrId, companyId, companyName);
                DialogResult result = createForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadPositions();
                    MessageBox.Show("Position created successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening create form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a position to view.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int positionId = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells["positionid"].Value);
                frmViewPosition viewForm = new frmViewPosition(positionId);
                viewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening view form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a position to edit.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int positionId = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells["positionid"].Value);
                frmEditPosition editForm = new frmEditPosition(positionId, hrId, companyId);
                DialogResult result = editForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadPositions();
                    MessageBox.Show("Position updated successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening edit form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a position to toggle status.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int positionId = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells["positionid"].Value);
                string currentStatus = dgvPositions.SelectedRows[0].Cells["status"].Value.ToString();
                string newStatus = currentStatus == "Open" ? "Closed" : "Open";
                string title = dgvPositions.SelectedRows[0].Cells["title"].Value.ToString();

                DialogResult confirmResult = MessageBox.Show(
                    $"Are you sure you want to {newStatus.ToLower()} the position:\n\"{title}\"?",
                    "Confirm Status Change",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    bool success = CompanyHRClass.UpdatePositionStatus(positionId, newStatus);

                    if (success)
                    {
                        LoadPositions();
                        MessageBox.Show($"Position status changed to {newStatus}!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update position status.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error toggling status: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a position to delete.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int positionId = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells["positionid"].Value);
                string title = dgvPositions.SelectedRows[0].Cells["title"].Value.ToString();
                int applicationCount = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells["applications"].Value);

                // Warn if position has applications
                if (applicationCount > 0)
                {
                    DialogResult warningResult = MessageBox.Show(
                        $"This position has {applicationCount} application(s).\n" +
                        $"Deleting it will also remove all related applications.\n\n" +
                        $"Are you sure you want to delete \"{title}\"?",
                        "Warning - Applications Exist",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (warningResult != DialogResult.Yes)
                        return;
                }
                else
                {
                    DialogResult confirmResult = MessageBox.Show(
                        $"Are you sure you want to delete the position:\n\"{title}\"?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmResult != DialogResult.Yes)
                        return;
                }

                bool success = CompanyHRClass.DeletePosition(positionId);

                if (success)
                {
                    LoadPositions();
                    MessageBox.Show("Position deleted successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete position.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting position: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPositions();
        }

        private void cboStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPositions();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPositions_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void dgvPositions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnView_Click(sender, e);
            }
        }
    }
}
