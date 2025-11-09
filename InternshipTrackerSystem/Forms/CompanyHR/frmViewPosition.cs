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
    public partial class frmViewPosition : Form
    {
        private int positionId;

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
                // Fetch position details
                DataTable dt = CompanyHRClass.GetPositionDetails(positionId);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Position Information
                    lblPositionIdValue.Text = row["positionid"].ToString();
                    lblTitleValue.Text = row["title"].ToString();
                    lblCompanyValue.Text = row["companyname"].ToString();
                    lblPostedByValue.Text = row["postedby"].ToString();
                    lblPostedDateValue.Text = Convert.ToDateTime(row["posteddate"]).ToString("dd/MM/yyyy hh:mm tt");
                    lblLocationValue.Text = row["location"].ToString();
                    lblDurationValue.Text = row["duration"].ToString();
                    lblStipendValue.Text = row["stipend"].ToString();
                    lblStartDateValue.Text = Convert.ToDateTime(row["startdate"]).ToString("dd/MM/yyyy hh:mm tt");
                    lblEndDateValue.Text = Convert.ToDateTime(row["enddate"]).ToString("dd/MM/yyyy hh:mm tt");
                    lblApplicationDeadlineValue.Text = Convert.ToDateTime(row["applicationdeadline"]).ToString("dd/MM/yyyy hh:mm tt");
                    lblAvailableSlotsValue.Text = row["availableslots"].ToString();

                    // Status with color coding
                    string status = row["status"].ToString();
                    lblStatusValue.Text = status;
                    if (status == "Open")
                    {
                        lblStatusValue.ForeColor = Color.Green;
                        lblStatusValue.Font = new Font(lblStatusValue.Font, FontStyle.Bold);
                        lblStatusValue.Text = "● " + status;
                    }
                    else if (status == "Closed")
                    {
                        lblStatusValue.ForeColor = Color.Red;
                        lblStatusValue.Font = new Font(lblStatusValue.Font, FontStyle.Bold);
                        lblStatusValue.Text = "● " + status;
                    }

                    // Description and Requirements (read-only textboxes)
                    txtDescription.Text = row["description"].ToString();
                    txtRequirements.Text = row["requirements"].ToString();

                    // Make textboxes read-only
                    txtDescription.ReadOnly = true;
                    txtRequirements.ReadOnly = true;
                    txtDescription.BackColor = SystemColors.Control;
                    txtRequirements.BackColor = SystemColors.Control;

                    // Application Statistics
                    lblTotalApplicationsValue.Text = row["totalapplications"].ToString();
                    lblPendingValue.Text = row["pendingapplications"].ToString();
                    lblAcceptedValue.Text = row["acceptedapplications"].ToString();
                    lblRejectedValue.Text = row["rejectedapplications"].ToString();

                    // Highlight pending applications if any
                    int pending = Convert.ToInt32(row["pendingapplications"]);
                    if (pending > 0)
                    {
                        lblPendingValue.ForeColor = Color.Orange;
                        lblPendingValue.Font = new Font(lblPendingValue.Font, FontStyle.Bold);
                    }

                    // Update form title
                    this.Text = $"View Position - {row["title"]}";
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
