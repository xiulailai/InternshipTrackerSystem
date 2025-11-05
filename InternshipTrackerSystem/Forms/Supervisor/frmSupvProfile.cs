using InternshipTrackerSystem.Forms.Supervisor;
using InternshipTrackerSystem.Models;
using InternshipTrackerSystem.Service;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InternshipTrackerSystem
{
    public partial class frmSupvProfile : Form
    {
        private int userId;
        private SupervisorModel supervisor;
        private bool hasChanges = false;
        public frmSupvProfile(int userId)
        {
            InitializeComponent();
            this.userId = userId;

            ConfigureForm();
        }
        private void ConfigureForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void frmSupvProfile_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSupervisorProfile();
                SetupTextChangedEvents();
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profile: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadSupervisorProfile()
        {
            try
            {
                // Show loading message
                this.Cursor = Cursors.WaitCursor;

                // Fetch supervisor data
                supervisor = SupervisorService.GetSupervisorByUserId(userId);

                if (supervisor == null)
                {
                    MessageBox.Show("Supervisor profile not found!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Populate form fields
                PopulateFields();

                // Update form title
                this.Text = $"Profile - {supervisor.FullName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading supervisor profile: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void PopulateFields()
        {
            if (supervisor == null)
                return;

            // Read-only fields
            lblSupervisorId.Text = supervisor.SupervisorId.ToString();
            lblUsername.Text = supervisor.Username;
            lblEmail.Text = supervisor.Email;
            lblUserRole.Text = supervisor.UserRole;
            lblCreatedDate.Text = supervisor.CreatedDate.ToString("dd/MM/yyyy");
            lblStatus.Text = supervisor.IsActive ? "Active" : "Inactive";
            lblStatus.ForeColor = supervisor.IsActive ? Color.Green : Color.Red;

            // Editable fields
            txtName.Text = supervisor.FullName;
            txtDepartment.Text = supervisor.Department ?? "";
            txtContacts.Text = supervisor.ContactNumber ?? "";
            txtSpecialization.Text = supervisor.Specialization ?? "";

            // Reset change tracking
            hasChanges = false;
        }

        private void SetupTextChangedEvents()
        {
            txtName.TextChanged += TextBox_TextChanged;
            txtDepartment.TextChanged += TextBox_TextChanged;
            txtContacts.TextChanged += TextBox_TextChanged;
            txtSpecialization.TextChanged += TextBox_TextChanged;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmSupvProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (hasChanges)
            {
                DialogResult result = MessageBox.Show(
                    "You have unsaved changes. Do you want to save before closing?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    btnUpdate_Click(sender, e);
                    // Check if save was successful
                    if (hasChanges)
                    {
                        e.Cancel = true; // Cancel closing if save failed
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; // Cancel closing
                }
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            hasChanges = true;
            UpdateButtonStates();
        }

        private bool ValidateInput()
        {
            // Clear any previous error indicators
            ClearErrorIndicators();

            bool isValid = true;
            string errorMessage = "";

            // Validate Full Name (required)
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorMessage += "• Full Name is required.\n";
                HighlightError(txtName);
                isValid = false;
            }
            else if (txtName.Text.Trim().Length < 3)
            {
                errorMessage += "• Full Name must be at least 3 characters long.\n";
                HighlightError(txtName);
                isValid = false;
            }

            // Validate Contact Number (optional but must be valid format if provided)
            if (!string.IsNullOrWhiteSpace(txtContacts.Text))
            {
                if (!IsValidPhoneNumber(txtContacts.Text))
                {
                    errorMessage += "• Contact Number is invalid. Use format: +60123456789 or 0123456789\n";
                    HighlightError(txtContacts);
                    isValid = false;
                }
            }

            // Validate Department (optional but recommended)
            if (string.IsNullOrWhiteSpace(txtDepartment.Text))
            {
                DialogResult result = MessageBox.Show(
                    "Department is not specified. Do you want to continue?",
                    "Missing Department",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    txtDepartment.Focus();
                    return false;
                }
            }

            // Validate Specialization (optional)
            if (string.IsNullOrWhiteSpace(txtSpecialization.Text))
            {
                DialogResult result = MessageBox.Show(
                    "Specialization is not specified. Do you want to continue?",
                    "Missing Specialization",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    txtSpecialization.Focus();
                    return false;
                }
            }

            // Show validation errors
            if (!isValid)
            {
                MessageBox.Show("Please correct the following errors:\n\n" + errorMessage,
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            return isValid;
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return true; // Optional field

            // Remove spaces and dashes
            string cleaned = phoneNumber.Replace(" ", "").Replace("-", "");

            // Pattern for Malaysian phone numbers
            // Accepts: +60123456789, 60123456789, 0123456789, 123456789
            string pattern = @"^(\+?60|0)?[0-9]{9,10}$";

            return Regex.IsMatch(cleaned, pattern);
        }

        private void HighlightError(Control control)
        {
            if (control is TextBox textBox)
            {
                textBox.BackColor = Color.LightCoral;
            }
        }

        private void ClearErrorIndicators()
        {
            txtName.BackColor = Color.White;
            txtDepartment.BackColor = Color.White;
            txtContacts.BackColor = Color.White;
            txtSpecialization.BackColor = Color.White;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (!ValidateInput())
                    return;

                // Check if there are changes
                if (!hasChanges)
                {
                    MessageBox.Show("No changes to save.",
                        "No Changes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // Confirm update
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to update your profile?",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                // Update supervisor model with new values
                supervisor.FullName = txtName.Text.Trim();
                supervisor.Department = txtDepartment.Text.Trim();
                supervisor.ContactNumber = txtContacts.Text.Trim();
                supervisor.Specialization = txtSpecialization.Text.Trim();

                // Save to database
                bool success = SupervisorService.UpdateSupervisorProfile(supervisor);

                if (success)
                {
                    MessageBox.Show(
                        "Profile updated successfully!\n\n" +
                        $"Name: {supervisor.FullName}\n" +
                        $"Department: {supervisor.Department}\n" +
                        $"Contact: {supervisor.ContactNumber}",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Reset change tracking
                    hasChanges = false;
                    UpdateButtonStates();

                    // Reload profile to ensure consistency
                    LoadSupervisorProfile();
                }
                else
                {
                    MessageBox.Show("Failed to update profile. Please try again.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating profile: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (hasChanges)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to discard all changes?",
                    "Discard Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    PopulateFields();
                    hasChanges = false;
                    UpdateButtonStates();
                    MessageBox.Show("Changes discarded.",
                        "Cancelled",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }
        private void UpdateButtonStates()
        {
            btnUpdate.Enabled = hasChanges;

            // Visual feedback for unsaved changes
            if (hasChanges)
            {
                btnUpdate.BackColor = Color.Orange;
                btnUpdate.ForeColor = Color.White;
                btnUpdate.Font = new Font(btnUpdate.Font, FontStyle.Bold);
            }
            else
            {
                btnUpdate.BackColor = SystemColors.Control;
                btnUpdate.ForeColor = SystemColors.ControlText;
                btnUpdate.Font = new Font(btnUpdate.Font, FontStyle.Regular);
            }
        }

        private string FormatPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return "";

            // Remove all non-numeric characters except +
            string cleaned = Regex.Replace(phoneNumber, @"[^\d+]", "");

            // Format Malaysian numbers: +60 12-345 6789
            if (cleaned.StartsWith("+60") && cleaned.Length == 12)
            {
                return $"+60 {cleaned.Substring(3, 2)}-{cleaned.Substring(5, 3)} {cleaned.Substring(8)}";
            }
            else if (cleaned.StartsWith("0") && cleaned.Length == 10)
            {
                return $"{cleaned.Substring(0, 3)}-{cleaned.Substring(3, 3)} {cleaned.Substring(6)}";
            }

            return phoneNumber; // Return as-is if doesn't match pattern
        }

        private void txtContacts_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = txtContacts.SelectionStart;

            // Remove formatting
            string cleaned = Regex.Replace(txtContacts.Text, @"[^\d+]", "");

            // Reformat if valid
            if (cleaned.Length > 0)
            {
                // Auto-format will be applied on blur/leave
                // Real-time formatting can be complex and interfere with typing
            }

            // Restore cursor position
            txtContacts.SelectionStart = cursorPosition;
        }

        private void txtContacts_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtContacts.Text))
            {
                txtContacts.Text = FormatPhoneNumber(txtContacts.Text);
            }
        }

        private void txtContacts_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtContacts.Text))
            {
                if (!IsValidPhoneNumber(txtContacts.Text))
                {
                    errorProvider1.SetError(txtContacts, "Invalid phone number format");
                }
                else
                {
                    errorProvider1.SetError(txtContacts, "");
                }
            }
            else
            {
                errorProvider1.SetError(txtContacts, "");
            }
        }
    }
}
