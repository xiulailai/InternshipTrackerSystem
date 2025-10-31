using InternshipTrackerSystem.Data;
using InternshipTrackerSystem.Models;
using InternshipTrackerSystem.Service;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Windows.Forms.Timer;


namespace InternshipTrackerSystem.Forms.Supervisor
{
    public partial class frmSupvNotification : Form
    {
        private int userId;
        private List<NotificationModel> allNotifications;
        private NotificationModel selectedNotification;
        private bool showUnreadOnly = false;
        private Timer refreshTimer;


        public frmSupvNotification(int userId)
        {
            InitializeComponent();
            this.userId = userId;

            ConfigureForm();
        }

        private void ConfigureForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void frmSupvNotification_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeDataGridView();
                InitializeFilterControls();
                LoadNotifications();
                UpdateUnreadCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading notifications: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void InitializeFilterControls()
        {
            // You can add a checkbox to filter unread only
            // For now, we'll load all notifications
            showUnreadOnly = false;
        }

        private void InitializeDataGridView()
        {
            try
            {
                // Clear existing columns
                dgvNotifications.Columns.Clear();

                // Configure DataGridView properties
                dgvNotifications.AutoGenerateColumns = false;
                dgvNotifications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvNotifications.MultiSelect = false;
                dgvNotifications.AllowUserToAddRows = false;
                dgvNotifications.AllowUserToDeleteRows = false;
                dgvNotifications.ReadOnly = true;
                dgvNotifications.RowHeadersVisible = false;
                dgvNotifications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvNotifications.BackgroundColor = Color.White;

                // Define columns

                // Hidden NotificationId column
                dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "NotificationId",
                    DataPropertyName = "NotificationId",
                    HeaderText = "ID",
                    Visible = false
                });

                // Read Status Icon (visual indicator)
                DataGridViewTextBoxColumn readIconColumn = new DataGridViewTextBoxColumn
                {
                    Name = "ReadIcon",
                    HeaderText = "",
                    Width = 40,
                    FillWeight = 5
                };
                dgvNotifications.Columns.Add(readIconColumn);

                // Message
                dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Message",
                    DataPropertyName = "Message",
                    HeaderText = "Message",
                    Width = 400,
                    FillWeight = 50
                });

                // Notification Type
                dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "NotificationType",
                    DataPropertyName = "NotificationType",
                    HeaderText = "Type",
                    Width = 100,
                    FillWeight = 12
                });

                // Created Date with Time
                dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CreatedDate",
                    DataPropertyName = "CreatedDate",
                    HeaderText = "Date & Time",
                    Width = 140,
                    FillWeight = 18,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
                });

                // Time Ago (relative time)
                DataGridViewTextBoxColumn timeAgoColumn = new DataGridViewTextBoxColumn
                {
                    Name = "TimeAgo",
                    DataPropertyName = "TimeAgo",
                    HeaderText = "Time Ago",
                    Width = 120,
                    FillWeight = 15
                };
                dgvNotifications.Columns.Add(timeAgoColumn);

                // Read Status (Yes/No)
                DataGridViewCheckBoxColumn isReadColumn = new DataGridViewCheckBoxColumn
                {
                    Name = "IsRead",
                    DataPropertyName = "IsRead",
                    HeaderText = "Read?",
                    Width = 60,
                    FillWeight = 10
                };
                dgvNotifications.Columns.Add(isReadColumn);

                // Style header
                dgvNotifications.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkCyan;
                dgvNotifications.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvNotifications.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                dgvNotifications.ColumnHeadersHeight = 35;

                // Alternating row colors
                dgvNotifications.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvNotifications.RowsDefaultCellStyle.BackColor = Color.White;

                // Selection color
                dgvNotifications.DefaultCellStyle.SelectionBackColor = Color.CadetBlue;
                dgvNotifications.DefaultCellStyle.SelectionForeColor = Color.White;

                // Row height
                dgvNotifications.RowTemplate.Height = 35;

                // Wire up events
                dgvNotifications.SelectionChanged += new EventHandler(dgvNotifications_SelectionChanged);
                dgvNotifications.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvNotifications_CellFormatting);
                dgvNotifications.CellDoubleClick += new DataGridViewCellEventHandler(dgvNotifications_CellDoubleClick);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing grid: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvNotifications_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvNotifications.Rows.Count)
                    return;

                DataGridViewRow row = dgvNotifications.Rows[e.RowIndex];

                // Get IsRead value
                bool isRead = false;
                if (row.Cells["IsRead"].Value != null)
                {
                    isRead = Convert.ToBoolean(row.Cells["IsRead"].Value);
                }

                // Highlight unread notifications
                if (!isRead)
                {
                    // Bold font for unread
                    e.CellStyle.Font = new Font(dgvNotifications.Font, FontStyle.Bold);

                    // Light yellow background for unread
                    if (e.ColumnIndex != dgvNotifications.Columns["IsRead"].Index)
                    {
                        e.CellStyle.BackColor = Color.LightYellow;
                    }
                }

                // Add read/unread icon in ReadIcon column
                if (dgvNotifications.Columns[e.ColumnIndex].Name == "ReadIcon")
                {
                    e.Value = isRead ? "✓" : "●";
                    e.CellStyle.ForeColor = isRead ? Color.Green : Color.OrangeRed;
                    e.CellStyle.Font = new Font(dgvNotifications.Font.FontFamily, 12F, FontStyle.Bold);
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Color-code notification types
                if (dgvNotifications.Columns[e.ColumnIndex].Name == "NotificationType" && e.Value != null)
                {
                    string type = e.Value.ToString();

                    switch (type)
                    {
                        case "Application":
                            e.CellStyle.ForeColor = Color.Blue;
                            break;
                        case "Internship":
                            e.CellStyle.ForeColor = Color.Green;
                            break;
                        case "Report":
                            e.CellStyle.ForeColor = Color.Orange;
                            break;
                        case "Evaluation":
                            e.CellStyle.ForeColor = Color.Purple;
                            break;
                        default:
                            e.CellStyle.ForeColor = Color.Black;
                            break;
                    }
                }
            }
            catch
            {
                // Silently fail for formatting issues
            }
        }
        private void dgvNotifications_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNotifications.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvNotifications.SelectedRows[0];
                int notificationId = Convert.ToInt32(row.Cells["NotificationId"].Value);

                selectedNotification = allNotifications?.FirstOrDefault(n => n.NotificationId == notificationId);
            }
            else
            {
                selectedNotification = null;
            }
        }
        private void dgvNotifications_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && selectedNotification != null)
            {
                MarkNotificationAsRead(selectedNotification.NotificationId);
            }
        }
        private void LoadNotifications()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Fetch notifications from service
                allNotifications = SupervisorService.GetNotifications(userId, showUnreadOnly);

                // Sort by date (newest first)
                if (allNotifications != null)
                {
                    allNotifications = allNotifications.OrderByDescending(n => n.CreatedDate).ToList();
                }

                // Bind to DataGridView
                dgvNotifications.DataSource = null;
                dgvNotifications.DataSource = allNotifications;

                // Update status
                UpdateStatusLabel();
                UpdateUnreadCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading notifications: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void btnMarkAsRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (allNotifications == null || allNotifications.Count == 0)
                {
                    MessageBox.Show("No notifications to mark as read.",
                        "No Data",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // Count unread notifications
                int unreadCount = allNotifications.Count(n => !n.IsRead);

                if (unreadCount == 0)
                {
                    MessageBox.Show("All notifications are already marked as read.",
                        "Already Read",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // Confirm action
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to mark all {unreadCount} unread notification(s) as read?",
                    "Confirm Mark All Read",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Mark all as read
                    bool success = SupervisorService.MarkAllNotificationsAsRead(userId);

                    if (success)
                    {
                        MessageBox.Show($"Successfully marked {unreadCount} notification(s) as read.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Reload notifications
                        LoadNotifications();
                    }
                    else
                    {
                        MessageBox.Show("Failed to mark notifications as read.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking all as read: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void dgvNotifications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadNotifications();
            MessageBox.Show("Notifications refreshed successfully!",
                "Refresh",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void MarkNotificationAsRead(int notificationId)
        {
            try
            {
                // Check if already read
                var notification = allNotifications?.FirstOrDefault(n => n.NotificationId == notificationId);

                if (notification == null)
                    return;

                if (notification.IsRead)
                {
                    MessageBox.Show("This notification is already marked as read.",
                        "Already Read",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // Mark as read
                bool success = SupervisorService.MarkNotificationAsRead(notificationId);

                if (success)
                {
                    // Update local data
                    notification.IsRead = true;

                    // Refresh display
                    dgvNotifications.Refresh();
                    UpdateUnreadCount();
                    UpdateStatusLabel();

                    // Optional: Show subtle feedback
                    // MessageBox.Show("Notification marked as read.", "Success", 
                    //     MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to mark notification as read.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error marking notification as read: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateUnreadCount()
        {
            try
            {
                int unreadCount = SupervisorService.GetUnreadNotificationCount(userId);

                // Update form title
                if (unreadCount > 0)
                {
                    this.Text = $"Notifications ({unreadCount} unread)";
                }
                else
                {
                    this.Text = "Notifications";
                }

                // Update label if exists
                if (lblUnreadCount != null)
                {
                    lblUnreadCount.Text = $"Unread: {unreadCount}";
                    lblUnreadCount.ForeColor = unreadCount > 0 ? Color.Red : Color.Green;
                    lblUnreadCount.Font = new Font(lblUnreadCount.Font,
                        unreadCount > 0 ? FontStyle.Bold : FontStyle.Regular);
                }
            }
            catch
            {
                // Silently fail
            }
        }

        private void UpdateStatusLabel()
        {
            if (allNotifications != null)
            {
                int total = allNotifications.Count;
                int unread = allNotifications.Count(n => !n.IsRead);
                int read = allNotifications.Count(n => n.IsRead);

                lblStatus.Text = $"Total: {total} | Unread: {unread} | Read: {read}";
            }
            else
            {
                lblStatus.Text = "No notifications loaded";
            }
        }

        private void InitializeContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem markReadMenu = new ToolStripMenuItem("Mark as Read");
            markReadMenu.Click += (s, e) =>
            {
                if (selectedNotification != null)
                {
                    MarkNotificationAsRead(selectedNotification.NotificationId);
                }
            };

            ToolStripMenuItem viewDetailsMenu = new ToolStripMenuItem("View Details");
            viewDetailsMenu.Click += (s, e) =>
            {
                if (selectedNotification != null)
                {
                    ShowNotificationDetails(selectedNotification);
                }
            };

            ToolStripMenuItem deleteMenu = new ToolStripMenuItem("Delete");
            deleteMenu.Click += (s, e) =>
            {
                MessageBox.Show("Delete functionality not implemented yet.",
                    "Not Implemented",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            };

            contextMenu.Items.Add(markReadMenu);
            contextMenu.Items.Add(viewDetailsMenu);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(deleteMenu);

            dgvNotifications.ContextMenuStrip = contextMenu;
        }

        private void ShowNotificationDetails(NotificationModel notification)
        {
            string details = $@"NOTIFICATION DETAILS
=====================================

Type: {notification.NotificationType ?? "General"}
Date: {notification.CreatedDate:dd/MM/yyyy HH:mm:ss}
Time Ago: {notification.TimeAgo}
Status: {(notification.IsRead ? "Read" : "Unread")}

MESSAGE:
{notification.Message}
";

            MessageBox.Show(details,
                "Notification Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Mark as read when viewing details
            if (!notification.IsRead)
            {
                MarkNotificationAsRead(notification.NotificationId);
            }
        }

        private void checkUnreadOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox chk)
            {
                showUnreadOnly = chk.Checked;
                LoadNotifications();
            }
        }
        private void InitializeAutoRefresh()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 60000; // 60 seconds
            refreshTimer.Tick += (s, e) => LoadNotifications();
            refreshTimer.Start();
        }

        private void frmSupvNotification_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Dispose();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
