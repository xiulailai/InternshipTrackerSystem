using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace assignment_student
{
    public partial class Form3 : Form
    {
        public static class Session
        {
            public static string LoginEmail { get; set; }
            public static int StudentId { get; set; }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void LoadStudentsData()
        {
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Password123!;Database=InternshipTracker;";
            string query = "SELECT * FROM applications WHERE studentid = @studentid;";

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
                        dgvStudents.DataSource = dt;
                    }
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadStudentsData();
        }
    }
}
