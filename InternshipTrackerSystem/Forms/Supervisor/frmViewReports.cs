using InternshipTrackerSystem.Data;
using InternshipTrackerSystem.Models;
using InternshipTrackerSystem.Service;
using InternshipTrackerSystem.Services;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternshipTrackerSystem.Forms.Supervisor
{
    public partial class frmViewReports : Form
    {
        private int supervisorId;
        private int? filterInternshipId; // For filtering by specific internship
        private List<StudentReportModel> allReports;
        private StudentReportModel selectedReport;

        public frmViewReports(int supervisorId)
        {
            InitializeComponent();
            this.supervisorId = supervisorId;
            this.filterInternshipId = null;

            ConfigureForm();
        }

        public frmViewReports(int supervisorId, int internshipId)
        {
            InitializeComponent();
            this.supervisorId = supervisorId;
            this.filterInternshipId = internshipId;

            ConfigureForm();
        }

        private void ConfigureForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            // Update form title if filtering by internship
            if (filterInternshipId.HasValue)
            {
                this.Text = $"Student Reports - Internship ID: {filterInternshipId.Value}";
            }
        }

        private void frmViewReports_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeComboBox();
                InitializeDataGridView();
                LoadReports();
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reports: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void InitializeComboBox()
        {
            try
            {
                cmbStatus.Items.Clear();
                cmbStatus.Items.Add("All");
                cmbStatus.Items.Add("Submitted");
                cmbStatus.Items.Add("Reviewed");
                cmbStatus.Items.Add("Approved");
                cmbStatus.Items.Add("Rejected");

                // Set default selection
                cmbStatus.SelectedIndex = 0; // "All"

                // Wire up event
                cmbStatus.SelectedIndexChanged += new EventHandler(cmbStatus_SelectedIndexChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing filter: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void InitializeDataGridView()
        {
            try
            {
                // Clear existing columns
                dgvReports.Columns.Clear();

                // Configure DataGridView properties
                dgvReports.AutoGenerateColumns = false;
                dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvReports.MultiSelect = false;
                dgvReports.AllowUserToAddRows = false;
                dgvReports.AllowUserToDeleteRows = false;
                dgvReports.ReadOnly = true;
                dgvReports.RowHeadersVisible = false;
                dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvReports.BackgroundColor = Color.White;

                // Define columns

                // Hidden ReportId column
                dgvReports.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ReportId",
                    DataPropertyName = "ReportId",
                    HeaderText = "ID",
                    Visible = false,
                    Width = 2
                });

                // Hidden InternshipId column
                dgvReports.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "InternshipId",
                    DataPropertyName = "InternshipId",
                    HeaderText = "InternshipID",
                    Visible = false
                });

                // Student Name
                dgvReports.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "StudentName",
                    DataPropertyName = "StudentName",
                    HeaderText = "Student Name",
                    Width = 150,
                    FillWeight = 20
                });

                // Student ID Number
                dgvReports.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "StudentIdNumber",
                    DataPropertyName = "StudentIdNumber",
                    HeaderText = "Student ID",
                    Width = 100,
                    FillWeight = 13
                });

                // Report Type
                dgvReports.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ReportType",
                    DataPropertyName = "ReportType",
                    HeaderText = "Report Type",
                    Width = 100,
                    FillWeight = 13
                });

                // Company Name
                dgvReports.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CompanyName",
                    DataPropertyName = "CompanyName",
                    HeaderText = "Company",
                    Width = 150,
                    FillWeight = 20
                });

                // Submission Date
                dgvReports.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "SubmissionDate",
                    DataPropertyName = "SubmissionDate",
                    HeaderText = "Submission Date",
                    Width = 150,
                    FillWeight = 17,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
                    
                });

                // Status
                dgvReports.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    DataPropertyName = "Status",
                    HeaderText = "Status",
                    Width = 100,
                    FillWeight = 17
                });

                // Style header
                dgvReports.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
                dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvReports.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                dgvReports.ColumnHeadersHeight = 35;

                // Alternating row colors
                dgvReports.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender;
                dgvReports.RowsDefaultCellStyle.BackColor = Color.White;

                // Selection color
                dgvReports.DefaultCellStyle.SelectionBackColor = Color.MediumPurple;
                dgvReports.DefaultCellStyle.SelectionForeColor = Color.White;

                // Row height
                dgvReports.RowTemplate.Height = 30;

                // Wire up events
                dgvReports.SelectionChanged += new EventHandler(dgvReports_SelectionChanged);
                dgvReports.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvReports_CellFormatting);
                dgvReports.CellDoubleClick += new DataGridViewCellEventHandler(dgvReports_CellDoubleClick);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing grid: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedReport == null)
                {
                    MessageBox.Show("Please select a report to approve.",
                        "No Selection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Confirm action
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to approve this {selectedReport.ReportType} report from {selectedReport.StudentName}?",
                    "Confirm Approval",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Update status to Approved
                    bool success = SupervisorClass.UpdateReportStatus(selectedReport.ReportId, "Approved");

                    if (success)
                    {
                        MessageBox.Show("Report approved successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Reload reports to reflect changes
                        LoadReports();
                    }
                    else
                    {
                        MessageBox.Show("Failed to approve report.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error approving report: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedReport == null)
                {
                    MessageBox.Show("Please select a report to reject.",
                        "No Selection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Confirm action with reason
                string reason = PromptForRejectionReason();

                if (string.IsNullOrWhiteSpace(reason))
                {
                    // User cancelled or didn't provide reason
                    return;
                }

                // Update status to Rejected
                bool success = SupervisorClass.UpdateReportStatus(selectedReport.ReportId, "Rejected");

                if (success)
                {
                    MessageBox.Show($"Report rejected.\nReason: {reason}",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Reload reports to reflect changes
                    LoadReports();
                }
                else
                {
                    MessageBox.Show("Failed to reject report.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error rejecting report: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = dgvReports.SelectedRows.Count > 0;

            btnViewContents.Enabled = hasSelection;

            // Enable approve/reject only for submitted or reviewed reports
            if (hasSelection && selectedReport != null)
            {
                bool canModify = selectedReport.Status == "Submitted" || selectedReport.Status == "Reviewed";
                btnApprove.Enabled = canModify && selectedReport.Status != "Approved";
                btnReject.Enabled = canModify && selectedReport.Status != "Rejected";
            }
            else
            {
                btnApprove.Enabled = false;
                btnReject.Enabled = false;
            }
        }

        private void UpdateStatusLabel()
        {
            if (allReports != null)
            {
                int total = allReports.Count;
                int submitted = allReports.Count(r => r.Status == "Submitted");
                int approved = allReports.Count(r => r.Status == "Approved");
                int rejected = allReports.Count(r => r.Status == "Rejected");

                lblStatus.Text = $"Total: {total} | Pending: {submitted} | Approved: {approved} | Rejected: {rejected}";
            }
            else
            {
                lblStatus.Text = "No data loaded";
            }
        }

        private void ShowReportContentDialog(StudentReportModel report)
        {
            // Create custom dialog
            Form contentForm = new Form
            {
                Text = $"{report.ReportType} Report - {report.StudentName}",
                Size = new Size(700, 600),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.Sizable,
                MinimizeBox = false
            };

            // Create panel
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(15)
            };

            // Build header info
            string header = $@"REPORT INFORMATION
=====================================
Student: {report.StudentName} ({report.StudentIdNumber})
Company: {report.CompanyName}
Report Type: {report.ReportType}
Submission Date: {report.SubmissionDate:dd/MM/yyyy HH:mm}
Status: {report.Status}

FILE PATH: {report.FilePath ?? "Not specified"}

REPORT CONTENT:
=====================================

";

            // Create TextBox for content
            TextBox txtContent = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Font = new Font("Consolas", 9F),
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Text = header + (report.Content ?? "No content available"),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Create button panel
            Panel buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                Padding = new Padding(10)
            };

            // Create Close button
            Button btnClose = new Button
            {
                Text = "Close",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Right,
                Width = 100,
                Height = 35,
                Font = new Font("Segoe UI", 10F)
            };

            // Optional: Add Open File button if filepath exists
            if (!string.IsNullOrWhiteSpace(report.FilePath))
            {
                Button btnOpenFile = new Button
                {
                    Text = "Open File",
                    Dock = DockStyle.Left,
                    Width = 120,
                    Height = 35,
                    Font = new Font("Segoe UI", 10F)
                };

                btnOpenFile.Click += (s, e) =>
                {
                    try
                    {
                        if (System.IO.File.Exists(report.FilePath))
                        {
                            System.Diagnostics.Process.Start(report.FilePath);
                        }
                        else
                        {
                            MessageBox.Show($"File not found: {report.FilePath}",
                                "File Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening file: {ex.Message}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                };

                buttonPanel.Controls.Add(btnOpenFile);
            }

            buttonPanel.Controls.Add(btnClose);

            // Add controls to panel
            panel.Controls.Add(txtContent);

            // Add controls to form
            contentForm.Controls.Add(panel);
            contentForm.Controls.Add(buttonPanel);

            // Show dialog
            contentForm.ShowDialog();
        }

        private string PromptForRejectionReason()
        {
            // Create input dialog
            Form promptForm = new Form
            {
                Text = "Rejection Reason",
                Size = new Size(450, 250),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblPrompt = new Label
            {
                Text = "Please provide a reason for rejecting this report:",
                Location = new Point(20, 20),
                Size = new Size(400, 20),
                Font = new Font("Segoe UI", 10F)
            };

            TextBox txtReason = new TextBox
            {
                Multiline = true,
                Location = new Point(20, 50),
                Size = new Size(390, 100),
                Font = new Font("Segoe UI", 9F)
            };

            Button btnOk = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(230, 165),
                Size = new Size(90, 30)
            };

            Button btnCancel = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(330, 165),
                Size = new Size(90, 30)
            };

            promptForm.Controls.AddRange(new Control[] { lblPrompt, txtReason, btnOk, btnCancel });
            promptForm.AcceptButton = btnOk;
            promptForm.CancelButton = btnCancel;

            DialogResult result = promptForm.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(txtReason.Text))
            {
                return txtReason.Text.Trim();
            }

            return null;
        }

        private void InitializeContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem viewContentMenu = new ToolStripMenuItem("View Content");
            viewContentMenu.Click += (s, e) => btnViewContents_Click(s, e);

            ToolStripMenuItem approveMenu = new ToolStripMenuItem("Approve Report");
            approveMenu.Click += (s, e) => btnApprove_Click(s, e);

            ToolStripMenuItem rejectMenu = new ToolStripMenuItem("Reject Report");
            rejectMenu.Click += (s, e) => btnReject_Click(s, e);

            contextMenu.Items.Add(viewContentMenu);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(approveMenu);
            contextMenu.Items.Add(rejectMenu);

            dgvReports.ContextMenuStrip = contextMenu;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReports();
            MessageBox.Show("Reports refreshed successfully!",
                "Refresh",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void dgvReports_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();

            // Store selected report
            if (dgvReports.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvReports.SelectedRows[0];
                int reportId = Convert.ToInt32(row.Cells["ReportId"].Value);

                selectedReport = allReports?.FirstOrDefault(r => r.ReportId == reportId);
            }
            else
            {
                selectedReport = null;
            }
        }

        private void LoadReports()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string statusFilter = cmbStatus.SelectedItem?.ToString() ?? "All";

                // Load reports based on filter
                if (filterInternshipId.HasValue)
                {
                    // Load reports for specific internship
                    LoadReportsByInternship(filterInternshipId.Value, statusFilter);
                }
                else
                {
                    // Load all reports for supervisor
                    LoadReportsBySupervisor(statusFilter);
                }

                UpdateStatusLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reports: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LoadReportsBySupervisor(string statusFilter)
        {
            if (statusFilter == "Submitted")
            {
                // Load only pending/submitted reports
                allReports = SupervisorClass.GetPendingReports(supervisorId);
            }
            else if (statusFilter == "All")
            {
                // Load all reports
                allReports = SupervisorClass.GetAllReportsBySupervisor(supervisorId);
            }
            else
            {
                // Load all and filter by status
                allReports = SupervisorClass.GetAllReportsBySupervisor(supervisorId);
                allReports = allReports.Where(r => r.Status == statusFilter).ToList();
            }

            // Bind to DataGridView
            dgvReports.DataSource = null;
            dgvReports.DataSource = allReports;
        }

        private void LoadReportsByInternship(int internshipId, string statusFilter)
        {
            // Get reports for specific internship
            allReports = SupervisorClass.GetReportsByInternship(internshipId);

            // Apply status filter if not "All"
            if (statusFilter != "All")
            {
                allReports = allReports.Where(r => r.Status == statusFilter).ToList();
            }

            // Bind to DataGridView
            dgvReports.DataSource = null;
            dgvReports.DataSource = allReports;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadReports();
            MessageBox.Show("Reports loaded successfully!",
                "Load",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnViewContents_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedReport == null)
                {
                    MessageBox.Show("Please select a report to view.",
                        "No Selection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Display report content
                ShowReportContentDialog(selectedReport);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error viewing report content: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void dgvReports_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                // Color-code the Status column
                if (dgvReports.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
                {
                    string status = e.Value.ToString();

                    switch (status)
                    {
                        case "Submitted":
                            e.CellStyle.BackColor = Color.LightYellow;
                            e.CellStyle.ForeColor = Color.DarkGoldenrod;
                            e.CellStyle.Font = new Font(dgvReports.Font, FontStyle.Bold);
                            break;
                        case "Reviewed":
                            e.CellStyle.BackColor = Color.LightBlue;
                            e.CellStyle.ForeColor = Color.DarkBlue;
                            break;
                        case "Approved":
                            e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.ForeColor = Color.DarkGreen;
                            e.CellStyle.Font = new Font(dgvReports.Font, FontStyle.Bold);
                            break;
                        case "Rejected":
                            e.CellStyle.BackColor = Color.LightCoral;
                            e.CellStyle.ForeColor = Color.DarkRed;
                            e.CellStyle.Font = new Font(dgvReports.Font, FontStyle.Bold);
                            break;
                    }
                }

                // Highlight report type
                if (dgvReports.Columns[e.ColumnIndex].Name == "ReportType" && e.Value != null)
                {
                    string reportType = e.Value.ToString();

                    if (reportType == "Final")
                    {
                        e.CellStyle.Font = new Font(dgvReports.Font, FontStyle.Bold);
                        e.CellStyle.ForeColor = Color.DarkBlue;
                    }
                }
            }
            catch
            {
                // Silently fail for formatting issues
            }
        }

        private void dgvReports_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnViewContents_Click(sender, e);
            }
        }
    }
}
