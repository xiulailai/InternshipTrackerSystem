using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternshipTrackerSystem.Forms.Admin
{
    public partial class frmAdminMain : Form
    {
        public frmAdminMain()
        {
            InitializeComponent();
        }

        private void frmAdminMain_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Admin Dashboard";
        }

        private void btnViewUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers form = new frmManageUsers();
            form.Show();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmManageUsers form = new frmManageUsers();
            form.Show();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            frmManageUsers form = new frmManageUsers();
            form.Show();
        }

        private void btnManageCompanies_Click(object sender, EventArgs e)
        {
            frmManageCompanies form = new frmManageCompanies();
            form.Show();
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            frmViewReports form = new frmViewReports();
            form.Show();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            frmViewReports form = new frmViewReports();
            form.Show();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reset Password clicked - feature not implemented yet.");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logging out...");
            this.Close();
        }


    }
}