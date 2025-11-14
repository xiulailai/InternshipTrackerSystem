using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InternshipTrackerSystem.Forms.Admin
{
    public partial class frmManageUsers : Form
    {
        private string connectionString;
        private int adminUserID = 1; // 可以改成登录用户ID

        public frmManageUsers(string connStr)
        {
            InitializeComponent();
            connectionString = connStr;
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            lblManageUsersTitle.Text = "Manage Users";
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT UserID, Name, Role, Email FROM Users";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AdminAddStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // 弹窗输入用户信息
                string fullName = Microsoft.VisualBasic.Interaction.InputBox("Enter Full Name:", "Add User");
                string program = Microsoft.VisualBasic.Interaction.InputBox("Enter Program:", "Add User");
                decimal gpa = Convert.ToDecimal(Microsoft.VisualBasic.Interaction.InputBox("Enter GPA:", "Add User"));
                string contact = Microsoft.VisualBasic.Interaction.InputBox("Enter Contact Number:", "Add User");
                int userID = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Enter UserID:", "Add User"));

                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Program", program);
                cmd.Parameters.AddWithValue("@GPA", gpa);
                cmd.Parameters.AddWithValue("@ContactNumber", contact);
                cmd.Parameters.AddWithValue("@AdminUserID", adminUserID);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User added successfully!");
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding user: " + ex.Message);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.");
                return;
            }

            DataGridViewRow row = dgvUsers.SelectedRows[0];
            int userID = Convert.ToInt32(row.Cells["UserID"].Value);

            string newName = Microsoft.VisualBasic.Interaction.InputBox("Enter new Name:", "Edit User", row.Cells["Name"].Value.ToString());
            string newRole = Microsoft.VisualBasic.Interaction.InputBox("Enter new Role:", "Edit User", row.Cells["Role"].Value.ToString());
            string newEmail = Microsoft.VisualBasic.Interaction.InputBox("Enter new Email:", "Edit User", row.Cells["Email"].Value.ToString());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE Users SET Name=@Name, Role=@Role, Email=@Email WHERE UserID=@UserID";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@Name", newName);
                cmd.Parameters.AddWithValue("@Role", newRole);
                cmd.Parameters.AddWithValue("@Email", newEmail);
                cmd.Parameters.AddWithValue("@UserID", userID);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User updated successfully!");
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating user: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            DataGridViewRow row = dgvUsers.SelectedRows[0];
            int userID = Convert.ToInt32(row.Cells["UserID"].Value);

            if (MessageBox.Show($"Are you sure you want to delete UserID {userID}?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string deleteQuery = "DELETE FROM Users WHERE UserID=@UserID";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User deleted successfully!");
                        LoadUsers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting user: " + ex.Message);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
