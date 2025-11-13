using InternshipTrackerSystem.Class;
using InternshipTrackerSystem.Data;
using InternshipTrackerSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace InternshipTrackerSystem.Forms.CompanyHR
{
    public partial class frmHRProfile : Form
    {
        private readonly int _userId;
        private int _companyId;
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
                // Get HR -> CompanyID using existing CompanyHRClass
                var hr = CompanyHRClass.GetHRByUserId(_userId);
                if (hr == null)
                {
                    MessageBox.Show("Human Resources profile not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                _companyId = hr.CompanyId;

                // Load company record directly from the database (matches schema)
                _company = GetCompanyById(_companyId);
                if (_company == null)
                {
                    MessageBox.Show("Company record not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                // Bind to UI
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
                MessageBox.Show($"Load failed:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Simple validations aligned with table lengths
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
                // allow bare domains or http(s) — DB uses varchar(200)
                var url = txtWebsite.Text.Trim();
                if (!(url.StartsWith("http://") || url.StartsWith("https://") || url.Contains(".")))
                {
                    Warn("Website should be a valid address (for example: https://example.com).");
                    return;
                }
            }

            try
            {
                // Update Companies table — columns match script exactly
                const string sql = @"
UPDATE dbo.Companies
SET CompanyName  = @CompanyName,
    Industry     = @Industry,
    Location     = @Location,
    ContactEmail = @ContactEmail,
    ContactPhone = @ContactPhone,
    Website      = @Website,
    Description  = @Description
WHERE CompanyID  = @CompanyID;";

                var p = new Dictionary<string, object>
                {
                    { "@CompanyID",   _companyId },
                    { "@CompanyName", NullIfEmpty(txtCompanyName.Text) ?? (object)DBNull.Value },
                    { "@Industry",    NullIfEmpty(txtIndustry.Text)    ?? (object)DBNull.Value },
                    { "@Location",    NullIfEmpty(txtLocation.Text)    ?? (object)DBNull.Value },
                    { "@ContactEmail",NullIfEmpty(txtContactEmail.Text)?? (object)DBNull.Value },
                    { "@ContactPhone",NullIfEmpty(txtContactPhone.Text)?? (object)DBNull.Value },
                    { "@Website",     NullIfEmpty(txtWebsite.Text)     ?? (object)DBNull.Value },
                    { "@Description", NullIfEmpty(txtDescription.Text) ?? (object)DBNull.Value },
                };

                var rows = DatabaseHelper.ExecuteNonQuery(sql, p);
                if (rows > 0)
                {
                    MessageBox.Show("Company profile saved.", "Saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No changes were saved.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Save failed:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- data helpers (match Models.CompanyModel)
        private CompanyModel GetCompanyById(int companyId)
        {
            const string sql = @"
SELECT CompanyID, CompanyName, Industry, Location,
       ContactEmail, ContactPhone, Description, Website, IsActive, CreatedDate
FROM dbo.Companies
WHERE CompanyID = @CompanyID;";

            var p = new Dictionary<string, object> { { "@CompanyID", companyId } };
            var dt = DatabaseHelper.ExecuteQuery(sql, p);
            if (dt.Rows.Count == 0) return null;

            var r = dt.Rows[0];
            return new CompanyModel
            {
                CompanyId = companyId,
                CompanyName = r["CompanyName"] as string,
                Industry = r["Industry"] as string,
                Location = r["Location"] as string,
                ContactEmail = r["ContactEmail"] as string,
                ContactPhone = r["ContactPhone"] as string,
                Description = r["Description"] as string,
                Website = r["Website"] as string,
                IsActive = r["IsActive"] != DBNull.Value && Convert.ToBoolean(r["IsActive"]),
                CreatedDate = r["CreatedDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(r["CreatedDate"])
            };
        }

        // --- UI helpers
        private static void Set(TextBox tb, string value) => tb.Text = value ?? string.Empty;
        private static string NullIfEmpty(string s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();
        private static void Warn(string msg) => MessageBox.Show(msg, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtWebsite_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblLocation_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void txtContactEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
