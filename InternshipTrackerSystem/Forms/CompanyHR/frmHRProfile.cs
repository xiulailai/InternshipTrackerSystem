using InternshipTrackerSystem.Class;
using InternshipTrackerSystem.Models;   // CompanyModel
using InternshipTrackerSystem.Model;    // CompanyHRModel
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InternshipTrackerSystem.Forms.CompanyHR
{
    public partial class frmHRProfile : Form
    {
        private readonly int _userId;

        // From CompanyHRModel (HR ↔ Company mapping)
        private CompanyHRModel _hr;

        // From CompanyModel (actual Companies table row)
        private CompanyModel _company;

        public frmHRProfile(int userId)
        {
            InitializeComponent();
            _userId = userId;

            this.Load += frmHRProfile_Load;
            btnSave.Click += btnSave_Click;
        }

        private void frmHRProfile_Load(object sender, EventArgs e)
        {
            try
            {
                // FORM → CompanyHRClass → CompanyHRModel
                _hr = CompanyHRClass.GetHRByUserId(_userId);
                if (_hr == null)
                {
                    MessageBox.Show(
                        "Human Resources profile not found.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    Close();
                    return;
                }

                // FORM → CompanyHRClass → CompanyModel
                _company = CompanyHRClass.GetCompanyById(_hr.CompanyId);
                if (_company == null)
                {
                    MessageBox.Show(
                        "Company record not found.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    Close();
                    return;
                }

                // Bind model → UI
                Set(txtCompanyName, _company.CompanyName);
                Set(txtIndustry, _company.Industry);
                Set(txtLocation, _company.Location);
                Set(txtContactEmail, _company.ContactEmail);
                Set(txtContactPhone, _company.ContactPhone);
                Set(txtWebsite, _company.Website);
                Set(txtDescription, _company.Description);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Load failed:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // ======= BASIC VALIDATION =======
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                Warn("Company Name is required.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtContactEmail.Text))
            {
                var emailOk = Regex.IsMatch(
                    txtContactEmail.Text.Trim(),
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

                if (!emailOk)
                {
                    Warn("Contact Email is not valid.");
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtWebsite.Text))
            {
                var url = txtWebsite.Text.Trim();
                if (!(url.StartsWith("http://") ||
                      url.StartsWith("https://") ||
                      url.Contains(".")))
                {
                    Warn("Website should be a valid address (for example: https://example.com).");
                    return;
                }
            }

            try
            {
                // Push UI → model
                _company.CompanyName = txtCompanyName.Text.Trim();
                _company.Industry = NullIfEmpty(txtIndustry.Text);
                _company.Location = NullIfEmpty(txtLocation.Text);
                _company.ContactEmail = NullIfEmpty(txtContactEmail.Text);
                _company.ContactPhone = NullIfEmpty(txtContactPhone.Text);
                _company.Website = NullIfEmpty(txtWebsite.Text);
                _company.Description = NullIfEmpty(txtDescription.Text);

                // FORM → CompanyHRClass → DatabaseHelper → DB
                bool saved = CompanyHRClass.UpdateCompanyProfile(_company);

                if (saved)
                {
                    MessageBox.Show(
                        "Company profile saved.",
                        "Saved",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "No changes were saved.",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Save failed:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ===== UI HELPERS =====
        private static void Set(TextBox tb, string value)
            => tb.Text = value ?? string.Empty;

        private static string NullIfEmpty(string s)
            => string.IsNullOrWhiteSpace(s) ? null : s.Trim();

        private static void Warn(string msg)
            => MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void txtWebsite_TextChanged(object sender, EventArgs e) { }
        private void txtPhone_TextChanged(object sender, EventArgs e) { }
        private void lblLocation_Click(object sender, EventArgs e) { }
        private void btnSave_Click_1(object sender, EventArgs e) { }
        private void txtContactEmail_TextChanged(object sender, EventArgs e) { }
    }
}
