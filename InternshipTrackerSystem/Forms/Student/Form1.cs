using System.Data.SqlClient;
using System.Data;
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

            if (username == "" || password == "")
            {
                MessageBox.Show("Please Emter Your Email and Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string sql = "SELECT passwordhash FROM users WHERE email = @e";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@e", username);

                        object result = cmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("User Haven't Sign Up Yet?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string dbPassword = result.ToString();

                        if (dbPassword != password)
                        {
                            MessageBox.Show("Wrong Password?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        MessageBox.Show("Login Successful", "Wellcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form3 mainPage = new Form3();
                        mainPage.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("404 Not Found?\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmStuSignUp mainPage = new frmStuSignUp();
            mainPage.Show();
            this.Hide();
        }
    }
}
