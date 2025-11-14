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
    public partial class frmInternDetails : Form
    {
        private int positionId;
        private int studentId;
        private bool hasApplied = false;

        public frmInternDetails(int positionId, int studentId)
        {
            InitializeComponent();
            this.positionId = positionId;
            this.studentId = studentId;
            LoadDetails();
            CheckApplicationStatus();

            // Wire up event handlers
            btnApply.Click += btnApply_Click;
            btnBack.Click += btnBack_Click;
        }

        private void LoadDetails()
        {
            try
            {
                var details = StudentClass.GetInternshipDetails(positionId);
                if (details == null)
                {
                    MessageBox.Show("Position not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtPosition.Text = details.Title;
                txtCompany.Text = details.CompanyName;
                txtIndustry.Text = details.Industry;
                txtLocation.Text = details.Location;
                txtDuration.Text = $"{details.Duration} months";
                txtStipend.Text = $"RM {details.Stipend}";
                txtStartDate.Text = details.StartDate.ToString("MMM dd, yyyy");
                txtEndDate.Text = details.EndDate.ToString("MMM dd, yyyy");
                txtDeadline.Text = details.ApplicationDeadline.ToString("MMM dd, yyyy");
                txtSlots.Text = details.AvailableSlots.ToString();

                // Combine description and requirements
                txtDescription.Text = $"DESCRIPTION:\r\n{details.Description}\r\n\r\nREQUIREMENTS:\r\n{details.Requirements}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckApplicationStatus()
        {
            try
            {
                hasApplied = StudentClass.HasApplied(studentId, positionId);
                if (hasApplied)
                {
                    btnApply.Text = "ALREADY APPLIED";
                    btnApply.Enabled = false;
                    txtCoverLetter.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking application: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCoverLetter.Text))
            {
                MessageBox.Show("Please write a cover letter!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCoverLetter.Focus();
                return;
            }

            if (txtCoverLetter.Text.Length < 50)
            {
                MessageBox.Show("Cover letter must be at least 50 characters!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool success = StudentClass.ApplyForInternship(studentId, positionId, txtCoverLetter.Text);
                if (success)
                {
                    MessageBox.Show("Application submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to submit application!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
