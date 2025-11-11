using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace assignment_student
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void LoadStudentsData()
        {
            if (Session.StudentId == 0)
            {
                MessageBox.Show("ERROR: login expired", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Password123!;Database=InternshipTracker;";

            string query = @"
                SELECT 
                    p.Title AS PositionTitle, 
                    a.applicationdate AS ApplicationDate, 
                    a.status AS Status,
                    a.coverletter AS CoverLetter
                FROM applications a
                JOIN internshippositions p ON a.positionid = p.positionid
                WHERE a.studentid = @studentid;
            ";

            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentid", Session.StudentId);

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvStudents.AutoGenerateColumns = true;
                            dgvStudents.DataSource = dt;
                            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadStudentsData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmHomePage mainPage = new frmHomePage();
            mainPage.Show();
            this.Hide();
        }
    }
}