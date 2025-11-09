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
    public partial class frmAcceptApplication : Form
    {
        private int applicationId;
        private int hrId;
        private string studentName;
        private string positionTitle;
        public frmAcceptApplication(int applicationId, int hrId, string studentName, string positionTitle)
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

        private void frmAcceptApplication_Load(object sender, EventArgs e)
        {
            try
            {
                // Display application information
                lblStudent.Text = $"Student: {studentName}";
                lblPosition.Text = $"Position: {positionTitle}";
                lblAction.Text = "Action: ACCEPT";
                lblAction.ForeColor = Color.Green;
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

                // Remarks are optional, but confirm if empty
                if (string.IsNullOrWhiteSpace(remarks))
                {
                    DialogResult result = MessageBox.Show(
                        "You haven't added any remarks. Continue without remarks?",
                        "No Remarks",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        txtRemarks.Focus();
                        return;
                    }
                }

                // Final confirmation
                DialogResult confirmResult = MessageBox.Show(
                    $"Are you sure you want to ACCEPT this application?\n\n" +
                    $"Student: {studentName}\n" +
                    $"Position: {positionTitle}\n\n" +
                    $"This action cannot be undone.",
                    "Confirm Acceptance",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    btnConfirm.Enabled = false;
                    Cursor = Cursors.WaitCursor;

                    bool success = CompanyHRClass.UpdateApplicationStatus(
                        applicationId,
                        hrId,
                        "Accepted",
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
                        MessageBox.Show("Failed to accept application. Please try again.",
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
                MessageBox.Show($"Error accepting application: {ex.Message}",
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
