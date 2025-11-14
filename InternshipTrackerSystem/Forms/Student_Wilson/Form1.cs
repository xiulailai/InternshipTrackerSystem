
//using assignment_student;


//using InternshipTrackerSystem.Data;
//using InternshipTrackerSystem.Models;
//using BCrypt.Net;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Windows.Forms;

//namespace assignment_student
//{
//    public partial class frmStuLogin : Form
//    {
//        public frmStuLogin()
//        {
//            InitializeComponent();
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            string email = textBox1.Text.Trim();
//            string password = textBox2.Text.Trim();

//            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
//            {
//                MessageBox.Show("Please enter your Email and Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            try
//            {
//                string sql = @"
//                    SELECT s.studentid, u.passwordhash
//                    FROM users u
//                    JOIN students s ON u.userid = s.userid
//                    WHERE u.email = @e;
//                ";

//                var parameters = new Dictionary<string, object>
//                {
//                    { "@e", email }
//                };

//                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);

//                if (dt.Rows.Count == 0)
//                {
//                    MessageBox.Show("User not found. Have you signed up?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return;
//                }

//                int studentId = Convert.ToInt32(dt.Rows[0]["studentid"]);
//                string dbPasswordHash = dt.Rows[0]["passwordhash"].ToString();

                

               
//                Students.LoginEmail = email;
//                Students.StudentId = studentId;

//                MessageBox.Show("Login Successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

//                frmHomePage mainPage = new frmHomePage();
//                mainPage.Show();
//                this.Hide();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Login failed: " + ex.Message);
//            }
//        }

//        private void button2_Click(object sender, EventArgs e)
//        {
//            frmStuSignUp signupPage = new frmStuSignUp();
//            signupPage.Show();
//            this.Hide();
//        }
//    }
//}