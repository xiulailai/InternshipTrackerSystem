using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace assignment_student
{
    public partial class frmStuLogin : Form
    {
        public frmStuLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Password123!;Database=InternshipTracker;";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your Email and Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    string sql = @"
                SELECT s.studentid, u.passwordhash
                FROM users u
                JOIN students s ON u.userid = s.userid
                WHERE u.email = @e;
            ";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@e", username);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("User not found. Have you signed up?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            int studentId = reader.GetInt32(0); 
                            string dbPassword = reader.GetString(1); 

                            if (dbPassword != password)
                            {
                                MessageBox.Show("Wrong password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                          
                            Session.LoginEmail = username;

                            Session.StudentId = studentId;

                            MessageBox.Show("Login Successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            frmHomePage mainPage = new frmHomePage();
                            mainPage.Show();
                            this.Hide();

                        } 
                    } 
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection or query error:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
           
            frmStuSignUp signupPage = new frmStuSignUp();
            signupPage.Show();
            this.Hide();
        }
    }
}
