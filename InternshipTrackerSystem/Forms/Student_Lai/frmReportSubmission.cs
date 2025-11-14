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
    public partial class frmReportSubmission : Form
    {
        private int studentId;
        private string selectedFilePath = "";

        public frmReportSubmission(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            LoadInternships();
            cmbReportType.SelectedIndex = 0;
        }

        private void LoadInternships()
        {
            try
            {
                DataTable internships = StudentClass.GetActiveInternships(studentId);

                cmbInternship.Items.Clear();
                cmbInternship.DisplayMember = "Display";
                cmbInternship.ValueMember = "internshipid";

                foreach (DataRow row in internships.Rows)
                {
                    string display = $"{row["positiontitle"]} - {row["companyname"]}";
                    cmbInternship.Items.Add(new { Display = display, InternshipId = row["internshipid"] });
                }

                if (cmbInternship.Items.Count > 0)
                    cmbInternship.SelectedIndex = 0;
                else
                    MessageBox.Show("You don't have any active internships to submit reports for.",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading internships: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    txtFilePath.Text = selectedFilePath;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validation
            if (cmbInternship.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an internship!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbReportType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a report type!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContent.Text) || txtContent.Text.Length < 50)
            {
                MessageBox.Show("Report content must be at least 50 characters!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContent.Focus();
                return;
            }

            try
            {
                dynamic selected = cmbInternship.SelectedItem;
                int internshipId = selected.InternshipId;
                string reportType = cmbReportType.SelectedItem.ToString();

                bool success = StudentClass.SubmitReport(
                    internshipId,
                    studentId,
                    reportType,
                    txtContent.Text,
                    selectedFilePath
                );

                if (success)
                {
                    MessageBox.Show("Report submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to submit report!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
