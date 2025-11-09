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

namespace InternshipTrackerSystem.Forms.CompanyHR
{
    public partial class frmRejectApplication : Form
    {
        private int applicationId;
        private int hrId;
        private string studentName;
        private string positionTitle;
        public frmRejectApplication(int applicationId, int hrId, string studentName, string positionTitle)
        {
            InitializeComponent();
            this.applicationId = applicationId;
            this.hrId = hrId;
            this.studentName = studentName;
            this.positionTitle = positionTitle;

            // Set form properties
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void frmRejectApplication_Load(object sender, EventArgs e)
        {
            try
            {
                // Display application information
                lblStudent.Text = $"Student: {studentName}";
                lblPosition.Text = $"Position: {positionTitle}";
                lblAction.Text = "Action: REJECT";
                lblAction.ForeColor = Color.Red;
                lblAction.Font = new Font(lblAction.Font, FontStyle.Bold);

                // Focus on remarks textbox
                txtRemarks.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string remarks = txtRemarks.Text.Trim();

                // For rejection, it's good practice to require remarks
                if (string.IsNullOrWhiteSpace(remarks))
                {
                    MessageBox.Show(
                        "Please provide a reason for rejection.\n\n" +
                        "This helps the student understand the decision and improve for future applications.",
                        "Remarks Required",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtRemarks.Focus();
                    return;
                }

                if (remarks.Length < 10)
                {
                    MessageBox.Show(
                        "Please provide a more detailed reason (at least 10 characters).",
                        "Remarks Too Short",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtRemarks.Focus();
                    return;
                }

                // Final confirmation
                DialogResult confirmResult = MessageBox.Show(
                    $"Are you sure you want to REJECT this application?\n\n" +
                    $"Student: {studentName}\n" +
                    $"Position: {positionTitle}\n\n" +
                    $"This action cannot be undone.",
                    "Confirm Rejection",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    btnConfirm.Enabled = false;
                    Cursor = Cursors.WaitCursor;

                    bool success = CompanyHRClass.UpdateApplicationStatus(
                        applicationId,
                        hrId,
                        "Rejected",
                        remarks);

                    Cursor = Cursors.Default;
                    btnConfirm.Enabled = true;

                    if (success)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to reject application. Please try again.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                btnConfirm.Enabled = true;
                MessageBox.Show($"Error rejecting application: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
