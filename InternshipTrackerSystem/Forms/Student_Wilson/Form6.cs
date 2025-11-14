
using InternshipTrackerSystem.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace assignment_student
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            cmbReportType.Items.Add("Weekly");
            cmbReportType.Items.Add("Monthly");
            cmbReportType.Items.Add("Final");
            cmbReportType.SelectedIndex = 0;
            LoadApprovedInternships();
        }

        private void LoadApprovedInternships()
        {
            string query = @"
                SELECT 
                    a.applicationid, 
                    p.Title 
                FROM applications a
                JOIN internshippositions p ON a.positionid = p.positionid
                WHERE a.studentid = @studentid AND a.status = 'Approved';";

            var parameters = new Dictionary<string, object>
            {
                { "@studentid", Students.StudentId }
            };

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                cmbInternship.DataSource = dt;
                cmbInternship.DisplayMember = "Title";
                cmbInternship.ValueMember = "applicationid"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading internship list: " + ex.Message);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdReport.Title = "Select Report File";
            ofdReport.Filter = "PDF Files (*.pdf)|*.pdf|Word Documents (*.docx)|*.docx|All Files (*.*)|*.*";
            ofdReport.FileName = "";
            if (ofdReport.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofdReport.FileName;
                lblStatus.Text = "File selected. Ready to upload.";
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (Students.StudentId == 0)
            {
                MessageBox.Show("Error: Login expired.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show("Please select a file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbInternship.SelectedValue == null)
            {
                MessageBox.Show("Please select an internship.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbReportType.SelectedItem == null)
            {
                MessageBox.Show("Please select a report type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            int applicationId = (int)cmbInternship.SelectedValue;
            int studentId = Students.StudentId;
            string reportType = cmbReportType.SelectedItem.ToString();
            string filePath = txtFilePath.Text;
            string fileName = Path.GetFileName(filePath);
            byte[] fileData;

            try
            {
                fileData = File.ReadAllBytes(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool success = DatabaseHelper.SubmitReport(applicationId, studentId, reportType, fileData, fileName);

                if (success)
                {
                    lblStatus.Text = $"Success: '{fileName}' submitted.";
                    MessageBox.Show("Report submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblStatus.Text = "Error: Upload failed.";
                    MessageBox.Show("Database upload error: Report was not saved.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: Upload failed.";
                MessageBox.Show("Database upload error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmHomePage mainPage = new frmHomePage();
            mainPage.Show();
            this.Hide();
        }
    }
}