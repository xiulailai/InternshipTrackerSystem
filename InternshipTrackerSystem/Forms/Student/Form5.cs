
using InternshipTrackerSystem.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic; 
using System.Data;
using System.Windows.Forms;

namespace assignment_student
{
    public partial class frmInternshipposition : Form
    {
        public frmInternshipposition()
        {
            InitializeComponent();
            dgvInternPosition.CellContentClick += dgvInternPosition_CellContentClick;
        }

        private void LoadInternshipData()
        {
            string query = "SELECT * FROM internshippositions;";

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query, null);

                dgvInternPosition.AutoGenerateColumns = true;
                dgvInternPosition.DataSource = dt;
                dgvInternPosition.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvInternPosition.RowTemplate.Height = 25;
                dgvInternPosition.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dgvInternPosition.ScrollBars = ScrollBars.Both;

                if (!dgvInternPosition.Columns.Contains("Apply"))
                {
                    DataGridViewButtonColumn applyCol = new DataGridViewButtonColumn();
                    applyCol.HeaderText = "Apply";
                    applyCol.Text = "Apply";
                    applyCol.UseColumnTextForButtonValue = true;
                    applyCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvInternPosition.Columns.Add(applyCol);
                }

                dgvInternPosition.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvInternPosition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dgvInternPosition.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    DataGridViewRow row = dgvInternPosition.Rows[e.RowIndex];
                    int positionId = Convert.ToInt32(row.Cells["PositionID"].Value);
                    string positionTitle = row.Cells["Title"].Value.ToString();
                    int studentId = Students.StudentId;

                    if (studentId == 0)
                    {
                        MessageBox.Show("ERROR, login expired.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string coverLetter = Interaction.InputBox(
                        $"please enter your {positionTitle}  Cover Letter：",
                        "Cover Letter",
                        "");

                    if (string.IsNullOrWhiteSpace(coverLetter))
                    {
                        MessageBox.Show("Cover Letter can not be blank.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string checkSql = "SELECT COUNT(*) FROM applications WHERE studentid = @studentid AND positionid = @positionid;";
                    var checkParams = new Dictionary<string, object>
                    {
                        { "@studentid", studentId },
                        { "@positionid", positionId }
                    };

                    int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkSql, checkParams));

                    if (count > 0)
                    {
                        MessageBox.Show("you already apply this position", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string insertSql = @"INSERT INTO applications 
                        (studentid, positionid, applicationdate, status, coverletter) 
                        VALUES 
                        (@studentid, @positionid, @applicationdate, @status, @coverletter);";

                    var insertParams = new Dictionary<string, object>
                    {
                        { "@studentid", studentId },
                        { "@positionid", positionId },
                        { "@applicationdate", DateTime.Now },
                        { "@status", "Pending" },
                        { "@coverletter", coverLetter }
                    };

                    int rowsAffected = DatabaseHelper.ExecuteNonQuery(insertSql, insertParams);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"successful apply: {positionTitle}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Application failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing application: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            LoadInternshipData();
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            frmHomePage mainPage = new frmHomePage();
            mainPage.Show();
            this.Hide();
        }
    }
}