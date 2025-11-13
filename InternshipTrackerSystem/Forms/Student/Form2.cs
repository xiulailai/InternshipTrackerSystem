//using InternshipTrackerSystem.Data;
//using InternshipTrackerSystem.Models;
//using System;
//using System.Windows.Forms;

//namespace assignment_student
//{
//    public partial class frmStuSignUp : Form
//    {
//        public frmStuSignUp()
//        {
//            InitializeComponent();
//        }

//        private void btnSignUp_Click(object sender, EventArgs e)
//        {
           
//            string studentId = txtStudentID.Text.Trim();
//            string username = txtUserName.Text.Trim();
//            string fullName = txtFullName.Text.Trim();
//            string program = txtProgram.Text.Trim();
//            string contact = txtContact.Text.Trim();
//            string address = txtAddress.Text.Trim();
//            string email = txtEmail.Text.Trim();
//            string password = txtPassword.Text.Trim();
//            string confirmPassword = txtConfirmPassword.Text.Trim();

           
//            if (studentId == "" || fullName == "" || program == "" || contact == "" ||
//                address == "" || email == "" || password == "" || confirmPassword == "" || username == "")
//            {
//                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (password != confirmPassword)
//            {
//                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            Student newStudent = new Student
//            {
//                StudentIdNumber = studentId,
//                Username = username,
//                FullName = fullName,
//                Program = program,
//                ContactNumber = contact,
//                Address = address,
//                Email = email
//            };

//            try
//            {
                
//                RegistrationResult result = DatabaseHelper.RegisterStudent(newStudent, password);

//                switch (result)
//                {
//                    case RegistrationResult.Success:
//                        MessageBox.Show("Successfully Signed Up. Please Login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        this.Hide();
//                        frmStuLogin loginForm = new frmStuLogin();
//                        loginForm.Show();
//                        break;

//                    case RegistrationResult.EmailExists:
//                        MessageBox.Show("This email address is already in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                        break;

//                    case RegistrationResult.StudentIdExists:
//                        MessageBox.Show("This Student ID Number already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                        break;

//                    case RegistrationResult.UnknownError:
//                        MessageBox.Show("An unexpected database error occurred. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                        break;
//                }
//            }
//            catch (Exception ex)
//            {
              
//                MessageBox.Show("An application error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//    }
//}