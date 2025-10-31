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

namespace InternshipTrackerSystem.Forms.Supervisor
{
    public partial class frmViewInterns : Form
    {
        private int supervisorId;
        private List<InternshipModel> allInternships;
        private InternshipModel selectedInternship;
        public frmViewInterns(int supervisorId)
        {
            InitializeComponent();
            this.supervisorId = supervisorId;

            // Set form properties
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void frmViewInterns_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeContextMenu();
                InitializeDataGridView();
                LoadAllInternships();

                // Set initial state for buttons
                UpdateButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading interns: {ex.Message}",
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
                dgvInterns.Columns.Clear();

                // Configure DataGridView properties
                dgvInterns.AutoGenerateColumns = false;
                dgvInterns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvInterns.MultiSelect = false;
                dgvInterns.AllowUserToAddRows = false;
                dgvInterns.AllowUserToDeleteRows = false;
                dgvInterns.ReadOnly = true;
                dgvInterns.RowHeadersVisible = false;
                dgvInterns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvInterns.BackgroundColor = Color.White;

                // Define columns manually for better control

                // Hidden column for InternshipId (for reference)
                dgvInterns.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "InternshipId",
                    DataPropertyName = "InternshipId",
                    HeaderText = "ID",
                    Visible = false
                });

                // Hidden column for StudentId (for reference)
                dgvInterns.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "StudentId",
                    DataPropertyName = "StudentId",
                    HeaderText = "StudentID",
                    Visible = false
                });

                // Student Name
                dgvInterns.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "StudentName",
                    DataPropertyName = "StudentName",
                    HeaderText = "Student Name",
                    Width = 150,
                    FillWeight = 20
                });

                // Student ID Number
                dgvInterns.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "StudentIdNumber",
                    DataPropertyName = "StudentIdNumber",
                    HeaderText = "Student ID",
                    Width = 100,
                    FillWeight = 15
                });

                // Company Name
                dgvInterns.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "CompanyName",
                    DataPropertyName = "CompanyName",
                    HeaderText = "Company",
                    Width = 150,
                    FillWeight = 20
                });

                // Position Title
                dgvInterns.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "PositionTitle",
                    DataPropertyName = "PositionTitle",
                    HeaderText = "Position",
                    Width = 130,
                    FillWeight = 18
                });

                // Start Date
                dgvInterns.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "StartDate",
                    DataPropertyName = "StartDate",
                    HeaderText = "Start Date",
                    Width = 100,
                    FillWeight = 12,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
                });

                // End Date
                dgvInterns.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "EndDate",
                    DataPropertyName = "EndDate",
                    HeaderText = "End Date",
                    Width = 100,
                    FillWeight = 12,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
                });

                // Status
                dgvInterns.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    DataPropertyName = "Status",
                    HeaderText = "Status",
                    Width = 90,
                    FillWeight = 13
                });

                // Style header
                dgvInterns.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                dgvInterns.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvInterns.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                dgvInterns.ColumnHeadersHeight = 35;

                // Alternating row colors
                dgvInterns.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
                dgvInterns.RowsDefaultCellStyle.BackColor = Color.White;

                // Selection color
                dgvInterns.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                dgvInterns.DefaultCellStyle.SelectionForeColor = Color.White;

                // Row height
                dgvInterns.RowTemplate.Height = 30;

                // Add selection changed event
                dgvInterns.SelectionChanged += dgvInterns_SelectionChanged;

                // Add cell formatting event for status colors
                dgvInterns.CellFormatting += dgvInterns_CellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing grid: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadAllInternships()
        {
            try
            {
                // Show loading message
                this.Cursor = Cursors.WaitCursor;

                // Fetch internships from database
                allInternships = SupervisorService.GetInternshipsBySupervisor(supervisorId);

                // Bind to DataGridView
                dgvInterns.DataSource = null;
                dgvInterns.DataSource = allInternships;

                // Update status label
                UpdateStatusLabel();

                // Clear search box
                txtSearch.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading internships: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void SearchInternships()
        {
            try
            {
                string searchTerm = txtSearch.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    // If search is empty, load all
                    LoadAllInternships();
                    return;
                }

                // Show loading message
                this.Cursor = Cursors.WaitCursor;

                // Search using service
                List<InternshipModel> searchResults = SupervisorService.SearchInternships(supervisorId, searchTerm);

                // Update display
                dgvInterns.DataSource = null;
                dgvInterns.DataSource = searchResults;

                // Update status
                lblStatus.Text = $"Found {searchResults.Count} result(s) for '{searchTerm}'";

                if (searchResults.Count == 0)
                {
                    MessageBox.Show($"No internships found matching '{searchTerm}'",
                        "Search Results",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching internships: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchInternships();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedInternship == null)
                {
                    MessageBox.Show("Please select an internship to view reports.",
                        "No Selection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Open reports form with internship filter
                frmViewReports reportsForm = new frmViewReports(supervisorId, selectedInternship.InternshipId);
                reportsForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening reports form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = dgvInterns.SelectedRows.Count > 0;

            btnViewDetails.Enabled = hasSelection;
            btnEvaluate.Enabled = hasSelection;
            btnReports.Enabled = hasSelection;
        }

        private void UpdateStatusLabel()
        {
            if (allInternships != null)
            {
                int total = allInternships.Count;
                int ongoing = allInternships.Count(i => i.Status == "Ongoing");
                int completed = allInternships.Count(i => i.Status == "Completed");

                lblStatus.Text = $"Total: {total} | Ongoing: {ongoing} | Completed: {completed}";
            }
            else
            {
                lblStatus.Text = "No data loaded";
            }
        }

        private void ShowStudentDetailsDialog(StudentModel student, InternshipModel internship)
        {
            // Create a custom dialog form
            Form detailsForm = new Form
            {
                Text = "Student Details",
                Size = new Size(500, 550),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // Create panel for content
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                AutoScroll = true
            };

            // Build details text
            string details = $@"STUDENT INFORMATION
=====================================

Student ID: {student.StudentIdNumber}
Full Name: {student.FullName}
Program: {student.Program ?? "N/A"}
GPA: {student.GPADisplay}

Contact Information:
Phone: {student.ContactNumber ?? "N/A"}
Email: {student.Email}
Address: {student.Address ?? "N/A"}

Skills: 
{student.Skills ?? "Not specified"}

INTERNSHIP DETAILS
=====================================

Company: {internship.CompanyName}
Position: {internship.PositionTitle}
Location: {internship.CompanyLocation ?? "N/A"}
Industry: {internship.CompanyIndustry ?? "N/A"}

Duration: {internship.StartDate:dd/MM/yyyy} - {internship.EndDate:dd/MM/yyyy}
Status: {internship.Status}
Days: {internship.DurationInDays} days

Program: {student.Program ?? "N/A"}
";

            // Create TextBox to display details
            TextBox txtDetails = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Font = new Font("Consolas", 9F),
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Text = details,
                BackColor = Color.White
            };

            // Create OK button
            Button btnOk = new Button
            {
                Text = "Close",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Bottom,
                Height = 35,
                Font = new Font("Segoe UI", 10F)
            };

            // Add controls
            panel.Controls.Add(txtDetails);
            detailsForm.Controls.Add(panel);
            detailsForm.Controls.Add(btnOk);

            // Show dialog
            detailsForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllInternships();
            MessageBox.Show("Internship list refreshed successfully!",
                "Refresh",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedInternship == null)
                {
                    MessageBox.Show("Please select an internship first.",
                        "No Selection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Get student details
                StudentModel student = SupervisorService.GetStudentById(selectedInternship.StudentId);

                if (student == null)
                {
                    MessageBox.Show("Student details not found.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Display student details in a message box or custom dialog
                ShowStudentDetailsDialog(student, selectedInternship);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error viewing student details: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedInternship == null)
                {
                    MessageBox.Show("Please select an internship to evaluate.",
                        "No Selection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Check if internship is ongoing
                if (selectedInternship.Status != "Ongoing" && selectedInternship.Status != "Completed")
                {
                    MessageBox.Show("You can only evaluate ongoing or completed internships.",
                        "Invalid Status",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Open evaluation form with selected internship
                frmSupvEvaluation evaluationForm = new frmSupvEvaluation(supervisorId, selectedInternship.InternshipId);
                evaluationForm.ShowDialog();

                // Refresh list after evaluation
                LoadAllInternships();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening evaluation form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvInterns_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();

            // Store selected internship
            if (dgvInterns.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvInterns.SelectedRows[0];
                int internshipId = Convert.ToInt32(row.Cells["InternshipId"].Value);

                selectedInternship = allInternships?.FirstOrDefault(i => i.InternshipId == internshipId);
            }
            else
            {
                selectedInternship = null;
            }
        }

        private void dgvInterns_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                // Color-code the Status column
                if (dgvInterns.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
                {
                    string status = e.Value.ToString();

                    switch (status)
                    {
                        case "Ongoing":
                            e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.ForeColor = Color.DarkGreen;
                            e.CellStyle.Font = new Font(dgvInterns.Font, FontStyle.Bold);
                            break;
                        case "Completed":
                            e.CellStyle.BackColor = Color.LightBlue;
                            e.CellStyle.ForeColor = Color.DarkBlue;
                            break;
                        case "Terminated":
                            e.CellStyle.BackColor = Color.LightCoral;
                            e.CellStyle.ForeColor = Color.DarkRed;
                            break;
                    }
                }
            }
            catch
            {
                // Silently fail for formatting issues
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchInternships();
                e.Handled = true;
            }
        }
        private void InitializeContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem viewDetailsMenu = new ToolStripMenuItem("View Student Details");
            viewDetailsMenu.Click += (s, e) => btnViewDetails_Click(s, e);

            ToolStripMenuItem evaluateMenu = new ToolStripMenuItem("Create/View Evaluation");
            evaluateMenu.Click += (s, e) => btnEvaluate_Click(s, e);

            ToolStripMenuItem reportsMenu = new ToolStripMenuItem("View Reports");
            reportsMenu.Click += (s, e) => btnReports_Click(s, e);

            contextMenu.Items.Add(viewDetailsMenu);
            contextMenu.Items.Add(evaluateMenu);
            contextMenu.Items.Add(reportsMenu);

            dgvInterns.ContextMenuStrip = contextMenu;
        }
    }
}

