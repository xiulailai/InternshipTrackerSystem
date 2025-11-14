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

                // Setup numeric controls
                SetupNumericControls();

                // Setup date pickers
                SetupDatePickers();

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
        private void SetupNumericControls()
        {
            // Setup Duration (in weeks)
            numDuration.Minimum = 1;
            numDuration.Maximum = 52; // Up to 1 year
            numDuration.Value = 12; // Default 12 weeks
            numDuration.DecimalPlaces = 0;

            // Setup Available Slots
            numAvailableSlots.Minimum = 1;
            numAvailableSlots.Maximum = 100;
            numAvailableSlots.Value = 1; // Default 1 slot
            numAvailableSlots.DecimalPlaces = 0;
        }
        private void SetupDatePickers()
        {
            // Set MinDate FIRST before setting Value
            dtpApplicationDeadline.MinDate = DateTime.Now.Date;
            dtpStartDate.MinDate = DateTime.Now.Date;
            dtpEndDate.MinDate = DateTime.Now.Date;

            // Set format
            dtpApplicationDeadline.Format = DateTimePickerFormat.Short;
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Format = DateTimePickerFormat.Short;
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

            if (dtpApplicationDeadline.Value < DateTime.Now.Date)
            {
                errorMessage += "• Application deadline cannot be in the past\n";
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

                // Create position model from form inputs
                InternshipPositionModel newPosition = new InternshipPositionModel
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

                // Confirm creation
                DialogResult confirmResult = MessageBox.Show(
                    $"Create new position:\n\n" +
                    $"Title: {newPosition.Title}\n" +
                    $"Location: {newPosition.Location}\n" +
                    $"Duration: {newPosition.Duration} weeks\n" +
                    $"Stipend: {newPosition.Stipend}\n" +
                    $"Available Slots: {newPosition.AvailableSlots}\n" +
                    $"Status: {newPosition.Status}\n\n" +
                    $"Are you sure you want to create this position?",
                    "Confirm Creation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    // Disable button to prevent double-click
                    btnSave.Enabled = false;
                    Cursor = Cursors.WaitCursor;

                    // Call the method to create position with model
                    bool success = CompanyHRClass.CreatePosition(companyId, hrId, newPosition);

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
                txtLocation.Clear();
                txtStipend.Clear();

                numDuration.Value = 12;
                numAvailableSlots.Value = 1;

                dtpApplicationDeadline.Value = DateTime.Now.AddDays(30);
                dtpStartDate.Value = DateTime.Now.AddDays(60);
                dtpEndDate.Value = DateTime.Now.AddDays(150);

                cboStatus.SelectedIndex = 0;

                txtTitle.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Check if any data has been entered
            bool hasData = !string.IsNullOrWhiteSpace(txtTitle.Text) ||
               (!string.IsNullOrWhiteSpace(txtDescription.Text)) ||
               (!string.IsNullOrWhiteSpace(txtRequirements.Text)) ||
               (!string.IsNullOrWhiteSpace(txtLocation.Text)) ||
               (!string.IsNullOrWhiteSpace(txtStipend.Text));

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
