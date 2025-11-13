using InternshipTrackerSystem.Data;
using System;
using System.Collections.Generic; 
using System.Data;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

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
            
            if (Students.StudentId == 0)
            {
                MessageBox.Show("ERROR: Login expired. Please log in again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
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

            var parameters = new Dictionary<string, object>
            {
                { "@studentid", Students.StudentId }
            };

            try
            {                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                dgvStudents.AutoGenerateColumns = true;
                dgvStudents.DataSource = dt;
                dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {              
                MessageBox.Show("Loading error: " + ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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