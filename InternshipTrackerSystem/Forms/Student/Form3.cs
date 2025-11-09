using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using System.Data.SqlClient;

namespace assignment_student
{ 
    public partial class Form3 : Form
    {
        private void LoadStudentsData()
        {
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Password123!;Database=InternshipTracker;";

            string query = "SELECT * FROM internshippositions;";

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvStudents.DataSource = dt;
                }
            }
        }
        public BindingList<Student> Students { get; set; }
        public Form3()
        {
            InitializeComponent();
            Students = new BindingList<Student>()
        {
            new Student(){ ID = 1, Name = "Alice", Age = 20 },
            new Student(){ ID = 2, Name = "Bob", Age = 25 }
        };
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dgvStudents.DataSource = Students;
            LoadStudentsData();
        }
        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        
        }
    }
}
