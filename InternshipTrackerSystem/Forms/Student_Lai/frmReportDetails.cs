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
    public partial class frmReportDetails : Form
    {
        private int reportId;
        private int studentId;
        private string selectedFilePath = "";

        public frmReportDetails(int reportId, int studentId)
        {
            InitializeComponent();
            this.reportId = reportId;
            this.studentId = studentId;
            LoadReportDetails();

            // Wire up event handlers
            btnDownload.Click += btnDownload_Click;
            btnChooseFile.Click += btnChooseFile_Click;
            btnResubmit.Click += btnResubmit_Click;
        }

        private void LoadReportDetails()
        {
            try
            {
                var report = StudentClass.GetReportDetails(reportId);
                if (report == null)
                {
                    MessageBox.Show("Report not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtReportID.Text = report.ReportId.ToString();
                txtInternship.Text = $"{report.PositionTitle} - {report.CompanyName}";
                txtReportType.Text = report.ReportType;
                txtSubmissionDate.Text = report.SubmissionDate.ToString("MMM dd, yyyy HH:mm");
                txtStatus.Text = report.Status;
                txtContent.Text = report.Content;

                // Color code status
                if (report.Status == "Approved")
                    txtStatus.BackColor = System.Drawing.Color.LightGreen;
                else if (report.Status == "Rejected")
                    txtStatus.BackColor = System.Drawing.Color.LightCoral;
                else if (report.Status == "Submitted")
                    txtStatus.BackColor = System.Drawing.Color.LightYellow;

                // Show/hide resubmit panel
                pnlResubmit.Visible = report.Status == "Rejected";

                // File download
                if (!string.IsNullOrEmpty(report.FilePath))
                {
                    btnDownload.Tag = report.FilePath;
                    btnDownload.Enabled = true;
                }
                else
                {
                    btnDownload.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string filePath = btnDownload.Tag?.ToString();
            if (!string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show($"Download file from: {filePath}", "Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Implement actual file download logic here
                // Example: System.Diagnostics.Process.Start("explorer.exe", filePath);
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF Files|*.pdf|Word Documents|*.doc;*.docx|All Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = ofd.FileName;
                    txtNewFilePath.Text = selectedFilePath;
                }
            }
        }

        private void btnResubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewContent.Text) || txtNewContent.Text.Length < 50)
            {
                MessageBox.Show("New content must be at least 50 characters!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewContent.Focus();
                return;
            }

            try
            {
                bool success = StudentClass.ResubmitReport(reportId, txtNewContent.Text, selectedFilePath);
                if (success)
                {
                    MessageBox.Show("Report resubmitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReportDetails(); // Refresh
                }
                else
                {
                    MessageBox.Show("Failed to resubmit report!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
