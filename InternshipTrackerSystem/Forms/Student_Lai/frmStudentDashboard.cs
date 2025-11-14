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
    public partial class frmStudentDashboard : Form
    {
        private int userId;
        private int studentId;

        public frmStudentDashboard(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                // Get student profile
                var profile = StudentClass.GetStudentProfile(userId);
                if (profile == null)
                {
                    MessageBox.Show("Student profile not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                studentId = profile.StudentId;
                lblTitle.Text = $"STUDENT DASHBOARD - Welcome, {profile.FullName}";

                // Load statistics
                var stats = StudentClass.GetStudentStatistics(studentId);
                txtTotalApps.Text = stats.TotalApplications.ToString();
                txtPending.Text = stats.PendingApplications.ToString();
                txtActiveInternships.Text = stats.ActiveInternships.ToString();
                txtReportsSubmitted.Text = stats.ReportsSubmitted.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            frmStudentProfile profileForm = new frmStudentProfile(userId);
            profileForm.ShowDialog();
        }

        private void btnSearchInternships_Click(object sender, EventArgs e)
        {
            frmSearchInternship searchForm = new frmSearchInternship(studentId);
            searchForm.ShowDialog();
            LoadDashboard(); // Refresh after returning
        }

        private void btnMyApplications_Click(object sender, EventArgs e)
        {
            frmStudentApplication appForm = new frmStudentApplication(studentId);
            appForm.ShowDialog();
            LoadDashboard(); // Refresh
        }

        private void btnMyReports_Click(object sender, EventArgs e)
        {
            frmReportList reportForm = new frmReportList(studentId);
            reportForm.ShowDialog();
            LoadDashboard(); // Refresh
        }

        private void btnEvaluations_Click(object sender, EventArgs e)
        {
            frmStudentEvaluation evalForm = new frmStudentEvaluation(studentId);
            evalForm.ShowDialog();
        }

        private void btnSubmission_Click(object sender, EventArgs e)
        {
            frmReportSubmission submissionForm = new frmReportSubmission(studentId);
            submissionForm.ShowDialog();
        }

        private void frmStudentDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmUserLogin loginForm = new frmUserLogin();
            loginForm.Show();
            this.Close();
        }
    }
}

