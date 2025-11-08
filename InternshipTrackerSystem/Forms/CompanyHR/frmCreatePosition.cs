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
    public partial class frmCreatePosition : Form
    {
        private int hrId;
        private int companyId;
        private string companyName;

        public frmCreatePosition(int hrId, int companyId, string companyName)
        {
            InitializeComponent();
            this.hrId = hrId;
            this.companyId = companyId;
            this.companyName = companyName;

            // Set form properties
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void frmCreatePosition_Load(object sender, EventArgs e)
        {
            try
            {
                // Display company name
                lblCompanyName.Text = $"Company: {companyName}";
                this.Text = $"Create Position - {companyName}";

                // Setup status combo box
                SetupStatusComboBox();


                // Focus on title field
                txtTitle.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SetupStatusComboBox()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Open");
            cboStatus.Items.Add("Closed");
            cboStatus.SelectedIndex = 0; // Default to "Open"
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate inputs
                if (!ValidateInputs())
                {
                    return;
                }

                // Get values
                string title = txtTitle.Text.Trim();
                string description = txtDescription.Text.Trim();
                string requirements = txtRequirements.Text.Trim();
                string status = cboStatus.SelectedItem.ToString();

                // Confirm creation
                DialogResult confirmResult = MessageBox.Show(
                    $"Create new position:\n\n" +
                    $"Title: {title}\n" +
                    $"Status: {status}\n\n" +
                    $"Are you sure you want to create this position?",
                    "Confirm Creation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    // Disable button to prevent double-click
                    btnSave.Enabled = false;
                    Cursor = Cursors.WaitCursor;

                    // Call the method to create position
                    bool success = CompanyHRClass.CreatePosition(
                        companyId,
                        hrId,
                        title,
                        description,
                        requirements,
                        status);

                    Cursor = Cursors.Default;
                    btnSave.Enabled = true;

                    if (success)
                    {
                        MessageBox.Show(
                            "Position created successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Failed to create position. Please try again.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                btnSave.Enabled = true;
                MessageBox.Show($"Error creating position: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear all fields?",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                txtTitle.Clear();
                txtDescription.Clear();
                txtRequirements.Clear();
                cboStatus.SelectedIndex = 0;

                txtTitle.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Check if any data has been entered
            bool hasData = !string.IsNullOrWhiteSpace(txtTitle.Text) ||
                          (!string.IsNullOrWhiteSpace(txtDescription.Text)) ||
                          (!string.IsNullOrWhiteSpace(txtRequirements.Text));

            if (hasData)
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
