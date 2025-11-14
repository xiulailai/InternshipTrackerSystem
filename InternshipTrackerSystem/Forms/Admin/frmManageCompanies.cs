using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InternshipTrackerSystem.Forms.Admin
{
    public partial class frmManageCompanies : Form
    {
        private string connectionString;
        private int adminUserID = 1; // 可以改成登录用户ID

        public frmManageCompanies(string connStr)
        {
            InitializeComponent();
            connectionString = connStr;
        }

        private void frmManageCompanies_Load(object sender, EventArgs e)
        {
            lblCompaniesTitle.Text = "Manage Companies";
            LoadCompanies();
        }

        private void LoadCompanies()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT CompanyID, CompanyName, Industry, Location FROM Companies";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCompanies.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading companies: " + ex.Message);
            }
        }

        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter Company Name:", "Add Company");
            string industry = Microsoft.VisualBasic.Interaction.InputBox("Enter Industry:", "Add Company");
            string location = Microsoft.VisualBasic.Interaction.InputBox("Enter Location:", "Add Company");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AdminAddCompany", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyName", name);
                cmd.Parameters.AddWithValue("@Industry", industry);
                cmd.Parameters.AddWithValue("@Location", location);
                cmd.Parameters.AddWithValue("@AdminUserID", adminUserID);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Company added successfully!");
                    LoadCompanies();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding company: " + ex.Message);
                }
            }
        }

        private void btnEditCompany_Click(object sender, EventArgs e)
        {
            if (dgvCompanies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a company to edit.");
                return;
            }

            DataGridViewRow row = dgvCompanies.SelectedRows[0];
            int companyID = Convert.ToInt32(row.Cells["CompanyID"].Value);

            string newName = Microsoft.VisualBasic.Interaction.InputBox("Enter new Company Name:", "Edit Company", row.Cells["CompanyName"].Value.ToString());
            string newIndustry = Microsoft.VisualBasic.Interaction.InputBox("Enter new Industry:", "Edit Company", row.Cells["Industry"].Value.ToString());
            string newLocation = Microsoft.VisualBasic.Interaction.InputBox("Enter new Location:", "Edit Company", row.Cells["Location"].Value.ToString());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE Companies SET CompanyName=@Name, Industry=@Industry, Location=@Location WHERE CompanyID=@CompanyID";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@Name", newName);
                cmd.Parameters.AddWithValue("@Industry", newIndustry);
                cmd.Parameters.AddWithValue("@Location", newLocation);
                cmd.Parameters.AddWithValue("@CompanyID", companyID);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Company updated successfully!");
                    LoadCompanies();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating company: " + ex.Message);
                }
            }
        }

        private void btnDeleteCompany_Click(object sender, EventArgs e)
        {
            if (dgvCompanies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a company to delete.");
                return;
            }

            DataGridViewRow row = dgvCompanies.SelectedRows[0];
            int companyID = Convert.ToInt32(row.Cells["CompanyID"].Value);

            if (MessageBox.Show($"Are you sure you want to delete CompanyID {companyID}?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string deleteQuery = "DELETE FROM Companies WHERE CompanyID=@CompanyID";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@CompanyID", companyID);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Company deleted successfully!");
                        LoadCompanies();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting company: " + ex.Message);
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
