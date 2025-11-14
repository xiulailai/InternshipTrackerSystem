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
        // 数据库连接字符串
        private string connectionString = @"Server=localhost\SQLEXPRESS;Database=InternshipDB;Trusted_Connection=True";

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
            frmManageUsers form = new frmManageUsers(@"Server=localhost\SQLEXPRESS;Database=InternshipDB;Trusted_Connection=True");
            form.Show();
        }

        private void btnManageCompanies_Click(object sender, EventArgs e)
        {
            frmManageCompanies form = new frmManageCompanies(@"Server=localhost\SQLEXPRESS;Database=InternshipDB;Trusted_Connection=True");
            form.Show();
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            frmViewReports form = new frmViewReports(@"Server=localhost\SQLEXPRESS;Database=InternshipDB;Trusted_Connection=True");
            form.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logging out...");
            this.Close();
        }

    }
}