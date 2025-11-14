using InternshipTrackerSystem.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternshipTrackerSystem.Forms.Student_Lai
{
    public partial class frmStudentProfile : Form
    {
        private int userId;

        public frmStudentProfile(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void LoadProfile()
        {
            try
            {
                var profile = StudentClass.GetStudentProfile(userId);
                if (profile == null)
                {
                    MessageBox.Show("Profile not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtStudentID.Text = profile.StudentIdNumber;
                txtFullName.Text = profile.FullName;
                txtProgram.Text = profile.Program;
                txtContact.Text = profile.ContactNumber;
                txtAddress.Text = profile.Address;
                txtGPA.Text = profile.GPA.ToString("0.00");
                txtSkills.Text = profile.Skills;
                txtResumePath.Text = profile.Resume;
                txtEmail.Text = profile.Email;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetReadOnly()
        {
            // Make all fields read-only as per requirement
            txtStudentID.ReadOnly = true;
            txtFullName.ReadOnly = true;
            txtProgram.ReadOnly = true;
            txtContact.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtGPA.ReadOnly = true;
            txtSkills.ReadOnly = true;
            txtResumePath.ReadOnly = true;
            txtEmail.ReadOnly = true;
        }

        private void frmStudentProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void frmStudentProfile_Load(object sender, EventArgs e)
        {
            LoadProfile();
            SetReadOnly();
        }
    }
}
