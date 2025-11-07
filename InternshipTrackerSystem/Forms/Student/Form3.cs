<<<<<<< HEAD
﻿using System;
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
using Npgsql;

namespace assignment_student
{ 
    public partial class Form3 : Form
    {
        private void LoadStudentsData()
        {
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Password123!;Database=InternshipTracker;";

            string query = "SELECT * FROM internshippositions;";

            using (var conn = new NpgsqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                using (var adapter = new NpgsqlDataAdapter(cmd))
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
=======
﻿using Npgsql;
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
>>>>>>> c10db3e054d8b572567e21451c873c73d3972970
