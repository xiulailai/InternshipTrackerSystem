using InternshipTrackerSystem.Forms.Supervisor;
using InternshipTrackerSystem.Forms.CompanyHR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InternshipTrackerSystem.Forms.Admin;
using assignment_student;

namespace InternshipTrackerSystem.Forms
{
    public partial class frmUserLogin : Form
    {
        private readonly Services.UserClass userService = new Services.UserClass();
        public frmUserLogin()
        {
            InitializeComponent();
        }
        private void frmUserLogin_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("⚠️ Please enter both email and password.");
                return;
            }

            DataRow user = userService.Login(email, password);

            if (user != null)
            {
                string role = user["UserRole"].ToString();
                string username = user["Username"].ToString();
                int userID = Convert.ToInt32(user["UserID"]);

                MessageBox.Show($"✅ Login successful!\nWelcome {username} ({role})");

                // 🧩 Redirect based on role
                if (role == "Supervisor")
                {
                    this.Hide();
                    frmSupvMain supervisorForm = new frmSupvMain(userID);
                    supervisorForm.ShowDialog();
                }
                else if (role == "Student")
                {
                    this.Hide();
                    frmHomePage studentForm = new frmHomePage();
                    studentForm.ShowDialog();
                }
                else if (role == "CompanyHR")
                {
                    this.Hide();
                    frmHrMain hrForm = new frmHrMain(userID);
                    hrForm.ShowDialog();
                }
                else if (role == "Admin")
                {
                    this.Hide();
                    frmAdminMain adminForm = new frmAdminMain();
                    adminForm.ShowDialog();
                }

                this.Hide(); // hide login form
            }
            else
            {
                MessageBox.Show("❌ Invalid email or password. Please try again.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); //this is to exit the form
        }

        private void frmUserLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Ensure the application exits when the login form is closed
        }
    }
}

