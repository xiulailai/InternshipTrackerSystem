using InternshipTrackerSystem.Models;
using InternshipTrackerSystem.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Windows.Forms.Timer;

namespace InternshipTrackerSystem.Forms.Supervisor
{
    public partial class frmSupvMain : Form
    {
        private int userId;
        private int supervisorId;
        private SupervisorModel supervisor;
        private Timer refreshTimer;
        private bool isLoggingOut = false;

        public frmSupvMain(int userId)
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

        private void frmSupvMain_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSupervisorData();
                LoadStatistics();
                UpdateUnreadNotificationBadge();

                // Optional: Show welcome message
                ShowWelcomeMessage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void frmSupvMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (refreshTimer != null)
            {
                refreshTimer.Tick -= RefreshTimer_Tick;
                refreshTimer.Stop();
                refreshTimer.Dispose();
            }
        }

        private void LoadSupervisorData()
        {
            try
            {
                // Fetch supervisor details
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

                // Store supervisor ID for later use
                supervisorId = supervisor.SupervisorId;

                // Display supervisor information
                lblSupervisorName.Text = supervisor.FullName;
                txtDepartment.Text = supervisor.Department ?? "Not Specified";
                txtEmail.Text = supervisor.Email;

                // Update form title
                this.Text = $"Supervisor Dashboard - {supervisor.FullName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading supervisor data: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                // Fetch statistics
                SupervisorStatisticsModel stats = SupervisorService.GetSupervisorStatistics(supervisorId);

                if (stats != null)
                {
                    // Display statistics
                    txtTotalInternships.Text = stats.TotalInternships.ToString();
                    txtOngoing.Text = stats.OngoingInternships.ToString();
                    txtCompleted.Text = stats.CompletedInternships.ToString();
                    txtPendingReports.Text = stats.PendingReports.ToString();
                    txtPendingEvaluations.Text = stats.PendingEvaluations.ToString();
                    txtTotalStudents.Text = stats.TotalStudentsSupervised.ToString();

                    // Optional: Highlight pending items if any
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

        private void UpdateUnreadNotificationBadge()
        {
            try
            {
                int unreadCount = SupervisorService.GetUnreadNotificationCount(userId);

                if (unreadCount > 0)
                {
                    btnNotifications.Text = $"Notifications ({unreadCount})";
                    btnNotifications.BackColor = Color.Orange;
                }
                else
                {
                    btnNotifications.Text = "Notifications";
                    btnNotifications.BackColor = SystemColors.Control;
                }
            }
            catch (Exception ex)
            {
                // Silently fail - not critical
                System.Diagnostics.Debug.WriteLine($"Error updating notification badge: {ex.Message}");
            }
        }

        private void btnViewInterns_Click(object sender, EventArgs e)
        {
            try
            {
                frmViewInterns viewInternsForm = new frmViewInterns(supervisorId);
                viewInternsForm.ShowDialog();

                // Refresh statistics when returning
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening View Interns form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            try
            {
                frmSupvProfile profileForm = new frmSupvProfile(userId);
                profileForm.ShowDialog();

                // Refresh supervisor data when returning (in case profile was updated)
                LoadSupervisorData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Profile form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            try
            {
                frmViewReports viewReportsForm = new frmViewReports(supervisorId);
                viewReportsForm.ShowDialog();

                // Refresh statistics when returning
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening View Reports form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            try
            {
                frmSupvNotification notificationForm = new frmSupvNotification(userId);
                notificationForm.ShowDialog();

                // Refresh notification badge when returning
                UpdateUnreadNotificationBadge();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Notifications form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEvaluation_Click(object sender, EventArgs e)
        {
            try
            {
                frmSupvEvaluation evaluationForm = new frmSupvEvaluation(supervisorId);
                evaluationForm.ShowDialog();

                // Refresh statistics when returning
                LoadStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Evaluation form: {ex.Message}",
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

                    // Show login form (assumes you have UserLogin form)
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
                UpdateUnreadNotificationBadge();
            }
            catch
            {
                // Silently fail for auto-refresh
            }
        }

        private void SetStatisticsToZero()
        {
            txtTotalInternships.Text = "0";
            txtOngoing.Text = "0";
            txtCompleted.Text = "0";
            txtPendingReports.Text = "0";
            txtPendingEvaluations.Text = "0";
            txtTotalStudents.Text = "0";
        }

        private void HighlightPendingItems(SupervisorStatisticsModel stats)
        {
            // Highlight pending reports if any
            if (stats.PendingReports > 0)
            {
                txtPendingReports.ForeColor = Color.Red;
                txtPendingReports.Font = new Font(txtPendingReports.Font, FontStyle.Bold);
            }
            else
            {
                txtPendingReports.ForeColor = Color.Green;
                txtPendingReports.Font = new Font(txtPendingReports.Font, FontStyle.Regular);
            }

            // Highlight pending evaluations if any
            if (stats.PendingEvaluations > 0)
            {
                txtPendingEvaluations.ForeColor = Color.Red;
                txtPendingEvaluations.Font = new Font(txtPendingEvaluations.Font, FontStyle.Bold);
            }
            else
            {
                txtPendingEvaluations.ForeColor = Color.Green;
                txtPendingEvaluations.Font = new Font(txtPendingEvaluations.Font, FontStyle.Regular);
            }
        }

        private void ShowWelcomeMessage()
        {
            if (supervisor != null)
            {
                string message = $"Welcome back, {supervisor.FullName}!\n\n";

                // Add contextual messages based on statistics
                var stats = SupervisorService.GetSupervisorStatistics(supervisorId);

                if (stats.PendingReports > 0)
                {
                    message += $"You have {stats.PendingReports} pending report(s) to review.\n";
                }

                if (stats.PendingEvaluations > 0)
                {
                    message += $"You have {stats.PendingEvaluations} internship(s) pending evaluation.\n";
                }

                if (stats.PendingReports == 0 && stats.PendingEvaluations == 0)
                {
                    message += "All tasks are up to date!";
                }

                // Only show if there are pending items
                if (stats.PendingReports > 0 || stats.PendingEvaluations > 0)
                {
                    MessageBox.Show(message,
                        "Dashboard Summary",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadStatistics();
                UpdateUnreadNotificationBadge();
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

        private void frmSupvMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isLoggingOut) Application.Exit(); 
        }
    }
}
