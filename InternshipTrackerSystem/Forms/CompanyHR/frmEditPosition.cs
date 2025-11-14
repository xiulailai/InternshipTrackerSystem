using InternshipTrackerSystem.Class;
using InternshipTrackerSystem.Model;
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
        private InternshipPositionModel originalPosition;
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

        private void SetupNumericControls()
        {
            // Setup Duration (in weeks)
            numDuration.Minimum = 1;
            numDuration.Maximum = 52; // Up to 1 year
            numDuration.DecimalPlaces = 0;

            // Setup Available Slots
            numAvailableSlots.Minimum = 1;
            numAvailableSlots.Maximum = 100;
            numAvailableSlots.DecimalPlaces = 0;
        }

        private void SetupDatePickers()
        {
            dtpApplicationDeadline.Format = DateTimePickerFormat.Short;
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Format = DateTimePickerFormat.Short;
        }

        private void LoadPositionData()
        {
            try
            {
                // Load position using model
                originalPosition = CompanyHRClass.GetPositionById(positionId);

                if (originalPosition != null)
                {
                    // Populate form fields from model
                    txtPositionId.Text = originalPosition.PositionId.ToString();
                    txtTitle.Text = originalPosition.Title;
                    txtDescription.Text = originalPosition.Description;
                    txtRequirements.Text = originalPosition.Requirements;
                    txtLocation.Text = originalPosition.Location;
                    numDuration.Value = originalPosition.Duration;
                    txtStipend.Text = originalPosition.Stipend;
                    dtpStartDate.Value = originalPosition.StartDate;
                    dtpEndDate.Value = originalPosition.EndDate;
                    dtpApplicationDeadline.Value = originalPosition.ApplicationDeadline;
                    numAvailableSlots.Value = originalPosition.AvailableSlots;
                    cboStatus.SelectedItem = originalPosition.Status;
                    lblPostedDate.Text = $"Posted Date: {originalPosition.PostedDate:dd/MM/yyyy hh:mm tt}";

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

            // Validate location
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                errorMessage += "• Location is required\n";
                isValid = false;
            }

            // Validate stipend
            if (string.IsNullOrWhiteSpace(txtStipend.Text))
            {
                errorMessage += "• Stipend is required\n";
                isValid = false;
            }

            // Validate status
            if (cboStatus.SelectedIndex == -1)
            {
                errorMessage += "• Status must be selected\n";
                isValid = false;
            }

            // Validate dates
            if (dtpApplicationDeadline.Value >= dtpStartDate.Value)
            {
                errorMessage += "• Application deadline must be before start date\n";
                isValid = false;
            }

            if (dtpStartDate.Value >= dtpEndDate.Value)
            {
                errorMessage += "• End date must be after start date\n";
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
            return txtTitle.Text.Trim() != originalPosition.Title ||
                   txtDescription.Text.Trim() != originalPosition.Description ||
                   txtRequirements.Text.Trim() != originalPosition.Requirements ||
                   txtLocation.Text.Trim() != originalPosition.Location ||
                   (int)numDuration.Value != originalPosition.Duration ||
                   txtStipend.Text.Trim() != originalPosition.Stipend ||
                   dtpStartDate.Value.Date != originalPosition.StartDate.Date ||
                   dtpEndDate.Value.Date != originalPosition.EndDate.Date ||
                   dtpApplicationDeadline.Value.Date != originalPosition.ApplicationDeadline.Date ||
                   (int)numAvailableSlots.Value != originalPosition.AvailableSlots ||
                   (cboStatus.SelectedItem != null && cboStatus.SelectedItem.ToString() != originalPosition.Status);
        }

        private void frmEditPosition_Load(object sender, EventArgs e)
        {
            try
            {
                // Load company name
                LoadCompanyName();

                // Setup status combo box
                SetupStatusComboBox();

                // Setup numeric controls
                SetupNumericControls();

                // Setup date pickers
                SetupDatePickers();

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

                // Create updated position model from form inputs
                InternshipPositionModel updatedPosition = new InternshipPositionModel
                {
                    Title = txtTitle.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Requirements = txtRequirements.Text.Trim(),
                    Location = txtLocation.Text.Trim(),
                    Duration = (int)numDuration.Value,
                    Stipend = txtStipend.Text.Trim(),
                    StartDate = dtpStartDate.Value,
                    EndDate = dtpEndDate.Value,
                    ApplicationDeadline = dtpApplicationDeadline.Value,
                    AvailableSlots = (int)numAvailableSlots.Value,
                    Status = cboStatus.SelectedItem.ToString()
                };

                // Confirm update
                DialogResult confirmResult = MessageBox.Show(
                    $"Update position:\n\n" +
                    $"Title: {updatedPosition.Title}\n" +
                    $"Location: {updatedPosition.Location}\n" +
                    $"Duration: {updatedPosition.Duration} weeks\n" +
                    $"Stipend: {updatedPosition.Stipend}\n" +
                    $"Available Slots: {updatedPosition.AvailableSlots}\n" +
                    $"Status: {updatedPosition.Status}\n\n" +
                    $"Are you sure you want to update this position?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    // Disable button to prevent double-click
                    btnUpdate.Enabled = false;
                    Cursor = Cursors.WaitCursor;

                    // Call the method to update position with model
                    bool success = CompanyHRClass.UpdatePosition(positionId, updatedPosition);

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
