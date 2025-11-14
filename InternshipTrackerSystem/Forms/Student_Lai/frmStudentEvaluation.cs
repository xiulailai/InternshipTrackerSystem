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
    public partial class frmStudentEvaluation : Form
    {
        private int studentId;

        public frmStudentEvaluation(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            LoadEvaluations();

            // Wire up event handlers
            dgvEvaluations.CellContentClick += dgvEvaluations_CellContentClick;
        }

        private void LoadEvaluations()
        {
            try
            {
                DataTable evaluations = StudentClass.GetStudentEvaluations(studentId);

                dgvEvaluations.Rows.Clear();
                foreach (DataRow row in evaluations.Rows)
                {
                    int index = dgvEvaluations.Rows.Add();
                    dgvEvaluations.Rows[index].Cells["colDate"].Value = Convert.ToDateTime(row["evaluationdate"]).ToString("MMM dd, yyyy");
                    dgvEvaluations.Rows[index].Cells["colCompany"].Value = row["companyname"];
                    dgvEvaluations.Rows[index].Cells["colSupervisor"].Value = row["supervisorname"];
                    dgvEvaluations.Rows[index].Cells["colOverallScore"].Value = $"{row["overallscore"]}/10";
                    dgvEvaluations.Rows[index].Tag = row["evaluationid"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading evaluations: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEvaluations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvEvaluations.Columns[e.ColumnIndex].Name == "colActions")
            {
                int evaluationId = Convert.ToInt32(dgvEvaluations.Rows[e.RowIndex].Tag);
                ShowEvaluationDetails(evaluationId);
            }
        }

        private void ShowEvaluationDetails(int evaluationId)
        {
            try
            {
                // Get evaluation details from the DataGridView row
                DataGridViewRow row = null;
                foreach (DataGridViewRow r in dgvEvaluations.Rows)
                {
                    if (r.Tag != null && Convert.ToInt32(r.Tag) == evaluationId)
                    {
                        row = r;
                        break;
                    }
                }

                if (row != null)
                {
                    string message = $"EVALUATION DETAILS\n\n" +
                                   $"Date: {row.Cells["colDate"].Value}\n" +
                                   $"Company: {row.Cells["colCompany"].Value}\n" +
                                   $"Supervisor: {row.Cells["colSupervisor"].Value}\n" +
                                   $"Overall Score: {row.Cells["colOverallScore"].Value}\n\n" +
                                   $"View full evaluation details in the system.";

                    MessageBox.Show(message, "Evaluation Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing evaluation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
