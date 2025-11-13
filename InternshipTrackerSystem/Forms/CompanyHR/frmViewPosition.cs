using InternshipTrackerSystem.Class;
using InternshipTrackerSystem.Model;
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
    public partial class frmViewPosition : Form
    {
        private int positionId;
        private PositionDetailsModel positionDetails;

        public frmViewPosition(int positionId)
        {
            InitializeComponent();
            this.positionId = positionId;

            // Set form properties
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void LoadPositionDetails()
        {
            try
            {
                // Fetch position details using model
                positionDetails = CompanyHRClass.GetPositionDetails(positionId);

                if (positionDetails != null)
                {
                    // Position Information
                    lblPositionIdValue.Text = positionDetails.PositionId.ToString();
                    lblTitleValue.Text = positionDetails.Title;
                    lblCompanyValue.Text = positionDetails.CompanyName;
                    lblPostedByValue.Text = positionDetails.PostedBy;
                    lblPostedDateValue.Text = positionDetails.PostedDate.ToString("dd/MM/yyyy hh:mm tt");
                    lblLocationValue.Text = positionDetails.Location;
                    lblDurationValue.Text = positionDetails.Duration.ToString() + " weeks";
                    lblStipendValue.Text = positionDetails.Stipend;
                    lblStartDateValue.Text = positionDetails.StartDate.ToString("dd/MM/yyyy");
                    lblEndDateValue.Text = positionDetails.EndDate.ToString("dd/MM/yyyy");
                    lblApplicationDeadlineValue.Text = positionDetails.ApplicationDeadline.ToString("dd/MM/yyyy");
                    lblAvailableSlotsValue.Text = positionDetails.AvailableSlots.ToString();

                    // Status with color coding
                    lblStatusValue.Text = positionDetails.Status;
                    if (positionDetails.Status == "Open")
                    {
                        lblStatusValue.ForeColor = Color.Green;
                        lblStatusValue.Font = new Font(lblStatusValue.Font, FontStyle.Bold);
                        lblStatusValue.Text = "● " + positionDetails.Status;
                    }
                    else if (positionDetails.Status == "Closed")
                    {
                        lblStatusValue.ForeColor = Color.Red;
                        lblStatusValue.Font = new Font(lblStatusValue.Font, FontStyle.Bold);
                        lblStatusValue.Text = "● " + positionDetails.Status;
                    }

                    // Description and Requirements (read-only textboxes)
                    txtDescription.Text = positionDetails.Description;
                    txtRequirements.Text = positionDetails.Requirements;

                    // Make textboxes read-only
                    txtDescription.ReadOnly = true;
                    txtRequirements.ReadOnly = true;
                    txtDescription.BackColor = SystemColors.Control;
                    txtRequirements.BackColor = SystemColors.Control;

                    // Application Statistics
                    lblTotalApplicationsValue.Text = positionDetails.TotalApplications.ToString();
                    lblPendingValue.Text = positionDetails.PendingApplications.ToString();
                    lblAcceptedValue.Text = positionDetails.AcceptedApplications.ToString();
                    lblRejectedValue.Text = positionDetails.RejectedApplications.ToString();

                    // Highlight pending applications if any
                    if (positionDetails.PendingApplications > 0)
                    {
                        lblPendingValue.ForeColor = Color.Orange;
                        lblPendingValue.Font = new Font(lblPendingValue.Font, FontStyle.Bold);
                    }

                    // Update form title
                    this.Text = $"View Position - {positionDetails.Title}";
                }
                else
                {
                    MessageBox.Show("Position not found!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading position details: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmViewPosition_Load(object sender, EventArgs e)
        {
            try
            {
                // Load position details
                LoadPositionDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading position details: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
