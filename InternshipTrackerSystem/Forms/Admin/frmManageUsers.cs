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
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            lblManageUsersTitle.Text = "Manage Users";

            // Fake database table for demo (simulate SQL data)
            DataTable table = new DataTable();
            table.Columns.Add("UserID");
            table.Columns.Add("Name");
            table.Columns.Add("Role");
            table.Columns.Add("Email");

            // Add sample rows
            table.Rows.Add("A001", "John Tan", "Student", "john@student.edu");
            table.Rows.Add("A002", "Mary Lim", "HR", "mary@company.com");
            table.Rows.Add("A003", "Alex Lee", "Supervisor", "alex@apuni.edu");
            table.Rows.Add("A004", "Admin", "Admin", "admin@careercentre.edu");

            // Bind to grid
            dgvUsers.DataSource = table;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add button clicked");
            // TODO: open add-user form or modal
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.");
                return;
            }
            MessageBox.Show("Edit button clicked for selected user");
            // TODO: open edit-user form
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }
            var confirm = MessageBox.Show("Are you sure to delete selected user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                MessageBox.Show("User deleted (demo)");
                // TODO: perform delete from database when DB is ready
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}