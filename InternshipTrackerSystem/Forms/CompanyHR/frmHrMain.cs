using InternshipTrackerSystem.Class;
using InternshipTrackerSystem.Forms.Supervisor;
using InternshipTrackerSystem.Model;
using InternshipTrackerSystem.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer; 


namespace InternshipTrackerSystem.Forms.CompanyHR
{
    public partial class frmHrMain : Form
    {
        private int userId;
        private int hrId;
        private int companyId;
        private CompanyHRModel hrModel;
        private Timer refreshTimer;
        private bool isLoggingOut = false;
        public frmHrMain(int userId)
        {
            InitializeComponent();
            this.userId = userId;

            // Set form properties
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Initialize refresh timer for auto-refresh every 30 seconds
            InitializeRefreshTimer();
        }

        private void frmHrMain_Load(object sender, EventArgs e)
        {
            try
            {
                LoadHRData();
                LoadStatistics();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadHRData()
        {
            try
            {
                // Fetch HR details using CompanyHRClass
                hrModel = CompanyHRClass.GetHRByUserId(userId);

                if (hrModel == null)
                {
                    MessageBox.Show("HR profile not found!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Store IDs for later use
                hrId = hrModel.HRId;
                companyId = hrModel.CompanyId;

                // Display HR information
                lblHRName.Text = hrModel.FullName;
                txtCompany.Text = hrModel.CompanyName;
                txtEmail.Text = hrModel.Email;

                // Update form title
                this.Text = $"Company HR Dashboard - {hrModel.FullName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading HR data: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void LoadStatistics()
        {
            try
            {
                // Fetch statistics using CompanyHRClass
                HRStatisticsModel stats = CompanyHRClass.GetHRStatistics(companyId);

                if (stats != null)
                {
                    // Display statistics
                    txtActivePositions.Text = stats.ActivePositions.ToString();
                    txtTotalApplications.Text = stats.TotalApplications.ToString();
                    txtPendingReviews.Text = stats.PendingReviews.ToString();
                    txtActiveInterns.Text = stats.ActiveInterns.ToString();

                    // Highlight pending reviews if any
                    HighlightPendingItems(stats);
                }
                else
                {
                    // Set all to zero if no data
                    SetStatisticsToZero();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                SetStatisticsToZero();
            }
        }
        private void btnManagePositions_Click(object sender, EventArgs e)
        {
            try
            {
                frmManagePositions managePositionsForm = new frmManagePositions(hrId, companyId);
                managePositionsForm.ShowDialog();

                // Refresh statistics when returning
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Manage Positions form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void btnReviewApplications_Click(object sender, EventArgs e)
        {
            try
            {
                frmReviewApplications reviewApplicationsForm = new frmReviewApplications(hrId, companyId);
                reviewApplicationsForm.ShowDialog();

                // Refresh statistics when returning
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Review Applications form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            try
            {
                // frmHRProfile profileForm = new frmHRProfile(userId);
                // profileForm.ShowDialog();

                // Refresh HR data when returning (in case profile was updated)
                LoadHRData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Profile form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadStatistics();
                MessageBox.Show("Dashboard refreshed successfully!",
                    "Refresh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing dashboard: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnTrackInterns_Click(object sender, EventArgs e)
        {
            try
            {
                // frmTrackInterns trackInternsForm = new frmTrackInterns(companyId);
                // trackInternsForm.ShowDialog();

                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Track Interns form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                // Confirm logout
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to logout?",
                    "Confirm Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Stop timer
                    isLoggingOut = true;
                    if (refreshTimer != null)
                    {
                        refreshTimer.Stop();
                    }

                    // Close this form and return to login
                    this.DialogResult = DialogResult.OK;
                    this.Hide();

                    // Show login form
                    frmUserLogin loginForm = new frmUserLogin();
                    loginForm.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during logout: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void InitializeRefreshTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 30000; // 30 seconds
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                LoadStatistics();
            }
            catch
            {
                // Silently fail for auto-refresh
            }
        }
        private void SetStatisticsToZero()
        {
            txtActivePositions.Text = "0";
            txtTotalApplications.Text = "0";
            txtPendingReviews.Text = "0";
            txtActiveInterns.Text = "0";
        }
        private void HighlightPendingItems(HRStatisticsModel stats)
        {
            // Highlight pending reviews if any
            if (stats.PendingReviews > 0)
            {
                txtPendingReviews.ForeColor = Color.Red;
                txtPendingReviews.Font = new Font(txtPendingReviews.Font, FontStyle.Bold);
            }
            else
            {
                txtPendingReviews.ForeColor = Color.Green;
                txtPendingReviews.Font = new Font(txtPendingReviews.Font, FontStyle.Regular);
            }
        }

        private void frmHrMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isLoggingOut) Application.Exit();
        }

        private void frmHrMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (refreshTimer != null)
            {
                refreshTimer.Tick -= RefreshTimer_Tick;
                refreshTimer.Stop();
                refreshTimer.Dispose();
            }
        }
    }
}
