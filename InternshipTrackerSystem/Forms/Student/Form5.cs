using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

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
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Password123!;Database=InternshipTracker;";
            string query = "SELECT * FROM internshippositions;";

            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

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
                            dgvInternPosition.Columns.Add(applyCol);
                        }

                        dgvInternPosition.Refresh();
                    }
                }
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

                    int studentId = Session.StudentId;

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
                    string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Password123!;Database=InternshipTracker;";
                    using (var conn = new NpgsqlConnection(connStr))
                    {
                        conn.Open();
                        string checkSql = "SELECT COUNT(*) FROM applications WHERE studentid = @studentid AND positionid = @positionid;";
                        using (var checkCmd = new NpgsqlCommand(checkSql, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@studentid", studentId); 
                            checkCmd.Parameters.AddWithValue("@positionid", positionId);

                            int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                            if (count > 0)
                            {
                                MessageBox.Show("you already apply this position", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        string insertSql = @"INSERT INTO applications 
                        (studentid, positionid, applicationdate, status, coverletter) 
                    VALUES 
                        (@studentid, @positionid, @applicationdate, @status, @coverletter);";

                        using (var cmd = new NpgsqlCommand(insertSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@studentid", studentId);
                            cmd.Parameters.AddWithValue("@positionid", positionId);
                            cmd.Parameters.AddWithValue("@applicationdate", DateTime.Now);
                            cmd.Parameters.AddWithValue("@status", "Pending");
                            cmd.Parameters.AddWithValue("@coverletter", coverLetter);
                            cmd.ExecuteNonQuery();
                        }
                    } 
                    MessageBox.Show($"successful apply: {positionTitle} (ID: {positionId})", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
