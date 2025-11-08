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
    public partial class frmEditPosition : Form
    {
        private int positionId;
        private int hrId;
        private int companyId;
        private string companyName;
        private string originalTitle;
        private string originalDescription;
        private string originalRequirements;
        private string originalStatus;
        private DateTime postedDate;

        public frmEditPosition(int positionId, int hrId, int companyId)
        {
            InitializeComponent();
            this.positionId = positionId;
            this.hrId = hrId;
            this.companyId = companyId;

            // Set form properties
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void LoadCompanyName()
        {
            try
            {
                companyName = CompanyHRClass.GetCompanyName(companyId);
                lblCompanyName.Text = $"Company: {companyName}";
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

        private void SetupStatusComboBox()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Open");
            cboStatus.Items.Add("Closed");
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadPositionData()
        {
            try
            {
                DataTable dt = CompanyHRClass.GetPositionById(positionId);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Store original values for comparison
                    originalTitle = row["title"].ToString();
                    originalDescription = row["description"].ToString();
                    originalRequirements = row["requirements"].ToString();
                    originalStatus = row["status"].ToString();
                    postedDate = Convert.ToDateTime(row["posteddate"]);

                    // Populate form fields
                    txtPositionId.Text = positionId.ToString();
                    txtTitle.Text = originalTitle;
                    txtDescription.Text = originalDescription;
                    txtRequirements.Text = originalRequirements;
                    cboStatus.SelectedItem = originalStatus;
                    lblPostedDate.Text = $"Posted Date: {postedDate:dd/MM/yyyy hh:mm tt}";

                    // Disable position ID field
                    txtPositionId.Enabled = false;
                    txtPositionId.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Position not found!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading position data: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;
            string errorMessage = "Please correct the following errors:\n\n";

            // Validate title
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorMessage += "• Position Title is required\n";
                isValid = false;
            }


            // Validate description
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                errorMessage += "• Job Description is required\n";
                isValid = false;
            }


            // Validate requirements
            if (string.IsNullOrWhiteSpace(txtRequirements.Text))
            {
                errorMessage += "• Requirements/Qualifications are required\n";
                isValid = false;
            }


            // Validate status
            if (cboStatus.SelectedIndex == -1)
            {
                errorMessage += "• Status must be selected\n";
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        private bool HasChanges()
        {
            // Check if any field has been modified
            return txtTitle.Text.Trim() != originalTitle ||
                   txtDescription.Text.Trim() != originalDescription ||
                   txtRequirements.Text.Trim() != originalRequirements ||
                   (cboStatus.SelectedItem != null && cboStatus.SelectedItem.ToString() != originalStatus);
        }

        private void frmEditPosition_Load(object sender, EventArgs e)
        {
            try
            {
                // Load company name
                LoadCompanyName();

                // Setup status combo box
                SetupStatusComboBox();

                // Load position data
                LoadPositionData();

                // Focus on title field
                txtTitle.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (!ValidateInputs())
                {
                    return;
                }

                // Check if there are any changes
                if (!HasChanges())
                {
                    MessageBox.Show("No changes detected.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // Get values
                string title = txtTitle.Text.Trim();
                string description = txtDescription.Text.Trim();
                string requirements = txtRequirements.Text.Trim();
                string status = cboStatus.SelectedItem.ToString();

                // Confirm update
                DialogResult confirmResult = MessageBox.Show(
                    $"Update position:\n\n" +
                    $"Title: {title}\n" +
                    $"Status: {status}\n\n" +
                    $"Are you sure you want to update this position?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    // Disable button to prevent double-click
                    btnUpdate.Enabled = false;
                    Cursor = Cursors.WaitCursor;

                    // Call the method to update position
                    bool success = CompanyHRClass.UpdatePosition(
                        positionId,
                        title,
                        description,
                        requirements,
                        status);

                    Cursor = Cursors.Default;
                    btnUpdate.Enabled = true;

                    if (success)
                    {
                        MessageBox.Show(
                            "Position updated successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Failed to update position. Please try again.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                btnUpdate.Enabled = true;
                MessageBox.Show($"Error updating position: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Check if any changes have been made
            if (HasChanges())
            {
                DialogResult result = MessageBox.Show(
                    "You have unsaved changes. Are you sure you want to cancel?",
                    "Confirm Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
