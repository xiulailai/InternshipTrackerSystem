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

namespace assignment_student
{
    public partial class frmStuSignUp : Form
    {
        public frmStuSignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentID.Text.Trim();
            string username = txtUserName.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string program = txtProgram.Text.Trim();
            string contact = txtContact.Text.Trim();
            string address = txtAddress.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Password123!;Database=InternshipTracker;";

            if (studentId == "" || fullName == "" || program == "" || contact == "" ||
                address == "" || email == "" || password == "" || confirmPassword == "")
            {
                MessageBox.Show("Please Write Down All The Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Password are Not Same！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();

                    string checkEmailSql = "SELECT COUNT(*) FROM users WHERE email = @em;";
                    using (var checkCmd = new NpgsqlCommand(checkEmailSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@em", email);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Already Have Exixting Accounr", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string checkStudentSql = "SELECT COUNT(*) FROM students WHERE studentidnumber = @id;";
                    using (var checkCmd = new NpgsqlCommand(checkStudentSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@id", studentId);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("This Student ID Number already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    int newUserId;
                    string insertUserSql = @"INSERT INTO users (username, email, passwordhash, userrole)
                         VALUES (@user, @em, @pass, @role)
                         RETURNING userid;";

                    using (var cmd2 = new NpgsqlCommand(insertUserSql, conn))
                    {
                        cmd2.Parameters.AddWithValue("@user", username);
                        cmd2.Parameters.AddWithValue("@em", email);
                        cmd2.Parameters.AddWithValue("@pass", password);
                        cmd2.Parameters.AddWithValue("@role", "Student");
                        newUserId = Convert.ToInt32(cmd2.ExecuteScalar());
                    }

                    string insertStudentSql = @"INSERT INTO students 
                        (studentidnumber, fullname, program, contactnumber, address, userid)
                        VALUES (@id, @name, @prog, @contact, @addr, @uid);";

                    using (var cmd1 = new NpgsqlCommand(insertStudentSql, conn))
                    {
                        cmd1.Parameters.AddWithValue("@id", studentId);
                        cmd1.Parameters.AddWithValue("@name", fullName);
                        cmd1.Parameters.AddWithValue("@prog", program);
                        cmd1.Parameters.AddWithValue("@contact", contact);
                        cmd1.Parameters.AddWithValue("@addr", address);
                        cmd1.Parameters.AddWithValue("@uid", newUserId); 
                        cmd1.ExecuteNonQuery();
                    }

                    MessageBox.Show("Succefully Sign Up. Please Login Again", "Succeful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    frmStuLogin loginForm = new frmStuLogin();
                    loginForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("404 NOtfound：" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
