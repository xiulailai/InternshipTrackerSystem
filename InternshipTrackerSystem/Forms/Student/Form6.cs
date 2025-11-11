using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Npgsql;
using NpgsqlTypes;

namespace assignment_student
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // 1. Populate the Report Type ComboBox
            cmbReportType.Items.Add("Weekly");
            cmbReportType.Items.Add("Monthly");
            cmbReportType.Items.Add("Final");
            cmbReportType.SelectedIndex = 0; // Set "Weekly" as default

            // 2. Populate the Internship ComboBox
            LoadApprovedInternships();
        }

        private void LoadApprovedInternships()
        {
            // We only want to submit reports for internships that are 'Approved'
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Password123!;Database=InternshipTracker;";
            string query = @"
                SELECT 
                    a.applicationid, 
                    p.Title 
                FROM applications a
                JOIN internshippositions p ON a.positionid = p.positionid
                WHERE a.studentid = @studentid AND a.status = 'Approved';";

            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@studentid", Session.StudentId);
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Bind the data to the ComboBox
                            cmbInternship.DataSource = dt;
                            cmbInternship.DisplayMember = "Title";         // Show the position title
                            cmbInternship.ValueMember = "applicationid"; // Store the applicationid
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading internship list: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmHomePage mainPage = new frmHomePage();
            mainPage.Show();
            this.Hide();
        }

        /// <summary>
        /// 当用户点击 "Browse..." (浏览) 按钮时触发
        /// </summary>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // 设置 OpenFileDialog 的属性
            ofdReport.Title = "Select Report File";
            // 设置文件类型过滤器，例如只允许 PDF 和 Word 文档
            ofdReport.Filter = "PDF Files (*.pdf)|*.pdf|Word Documents (*.docx)|*.docx|All Files (*.*)|*.*";
            ofdReport.FileName = ""; // 清空默认文件名

            // 显示文件选择对话框
            if (ofdReport.ShowDialog() == DialogResult.OK)
            {
                // 如果用户点击了 "OK"，将所选文件的完整路径显示在 TextBox 中
                txtFilePath.Text = ofdReport.FileName;
                lblStatus.Text = "File selected. Ready to upload.";
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // 1. Check Session
            if (Session.StudentId == 0)
            {
                MessageBox.Show("Error: Login expired.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Check FilePath
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show("Please select a file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. (NEW) Check ComboBox selections
            if (cmbInternship.SelectedValue == null)
            {
                MessageBox.Show("Please select an internship.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbReportType.SelectedItem == null)
            {
                MessageBox.Show("Please select a report type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Get all required data
            int internshipId = (int)cmbInternship.SelectedValue; // This is the applicationid
            string reportType = cmbReportType.SelectedItem.ToString();
            string filePath = txtFilePath.Text;
            string fileName = Path.GetFileName(filePath);
            byte[] fileData;

            try
            {
                fileData = File.ReadAllBytes(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 5. Database Upload
            string connStr = "Host=localhost;Port=5432;Username=postgres;Password=Password123!;Database=InternshipTracker;";
            string sql = @"
                INSERT INTO reports 
                (internshipid, studentid, reporttype, submissiondate, content, filepath, status) 
                VALUES 
                (@internshipid, @studentid, @reporttype, @submissiondate, @content, @filepath, @status)";

            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@internshipid", internshipId);
                        cmd.Parameters.AddWithValue("@studentid", Session.StudentId);
                        cmd.Parameters.AddWithValue("@reporttype", reportType);
                        cmd.Parameters.AddWithValue("@submissiondate", DateTime.Now);
                        cmd.Parameters.Add(new NpgsqlParameter("@content", NpgsqlDbType.Bytea) { Value = fileData });
                        cmd.Parameters.AddWithValue("@filepath", fileName);
                        cmd.Parameters.AddWithValue("@status", "Submitted"); // Set initial status

                        cmd.ExecuteNonQuery();

                        lblStatus.Text = $"Success: '{fileName}' submitted.";
                        MessageBox.Show("Report submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: Upload failed.";
                MessageBox.Show("Database upload error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    