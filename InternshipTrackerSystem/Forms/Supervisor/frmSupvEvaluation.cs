using InternshipTrackerSystem.Models;
using InternshipTrackerSystem.Service;
using InternshipTrackerSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InternshipTrackerSystem.Forms.Supervisor
{
    public partial class frmSupvEvaluation : Form
    {
        private int supervisorId;
        private int? selectedInternshipId;
        private InternshipModel currentInternship;
        private SupervisorEvaluationModel existingEvaluation;
        private bool isEditMode = false;

        public frmSupvEvaluation(int supervisorId)
        {
            InitializeComponent();
            this.supervisorId = supervisorId;
            this.selectedInternshipId = null;

            ConfigureForm();
        }

        public frmSupvEvaluation(int supervisorId, int internshipId)
        {
            InitializeComponent();
            this.supervisorId = supervisorId;
            this.selectedInternshipId = internshipId;

            ConfigureForm();
        }

        private void ConfigureForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }
        private void frmSupvEvaluation_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeNumericUpDowns();

                if (selectedInternshipId.HasValue)
                {
                    // Load specific internship
                    LoadInternshipDetails(selectedInternshipId.Value);
                    CheckForExistingEvaluation();
                }
                else
                {
                    // Show internship selector
                    ShowInternshipSelector();
                }

                UpdateButtonStates();
                WireUpEventHandlers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading evaluation form: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void InitializeNumericUpDowns()
        {
            // Configure Performance score
            numPerformance.Minimum = 1;
            numPerformance.Maximum = 10;
            numPerformance.Value = 5;
            numPerformance.DecimalPlaces = 0;

            // Configure Punctuality score
            numPunctuality.Minimum = 1;
            numPunctuality.Maximum = 10;
            numPunctuality.Value = 5;
            numPunctuality.DecimalPlaces = 0;

            // Configure Communication score
            numCommunication.Minimum = 1;
            numCommunication.Maximum = 10;
            numCommunication.Value = 5;
            numCommunication.DecimalPlaces = 0;

            // Initialize overall score display
            CalculateAndDisplayOverallScore();
        }
        private void WireUpEventHandlers()
        {
            // Auto-calculate overall score when any score changes
            numPerformance.ValueChanged += new EventHandler(NumericScore_ValueChanged);
            numPunctuality.ValueChanged += new EventHandler(NumericScore_ValueChanged);
            numCommunication.ValueChanged += new EventHandler(NumericScore_ValueChanged);
        }

        private void NumericScore_ValueChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayOverallScore();
        }

        private void ShowInternshipSelector()
        {
            try
            {
                // Get internships needing evaluation
                var internships = SupervisorService.GetInternshipsNeedingEvaluation(supervisorId);

                if (internships == null || internships.Count == 0)
                {
                    MessageBox.Show("No internships available for evaluation.",
                        "No Data",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                    return;
                }

                // Create selection form
                Form selectorForm = new Form
                {
                    Text = "Select Internship to Evaluate",
                    Size = new Size(500, 400),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                ListBox listBox = new ListBox
                {
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 10F)
                };

                // Populate list
                foreach (var internship in internships)
                {
                    listBox.Items.Add(new
                    {
                        Display = $"{internship.StudentName} - {internship.CompanyName} ({internship.PositionTitle})",
                        InternshipId = internship.InternshipId
                    });
                }
                listBox.DisplayMember = "Display";

                Button btnSelect = new Button
                {
                    Text = "Select",
                    Dock = DockStyle.Bottom,
                    Height = 40,
                    DialogResult = DialogResult.OK
                };

                selectorForm.Controls.Add(listBox);
                selectorForm.Controls.Add(btnSelect);

                if (selectorForm.ShowDialog() == DialogResult.OK && listBox.SelectedItem != null)
                {
                    dynamic selected = listBox.SelectedItem;
                    selectedInternshipId = selected.InternshipId;
                    LoadInternshipDetails(selectedInternshipId.Value);
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing internship selector: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadInternshipDetails(int internshipId)
        {
            try
            {
                currentInternship = SupervisorService.GetInternshipById(internshipId);

                if (currentInternship == null)
                {
                    MessageBox.Show("Internship not found.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Validate supervisor access
                if (!SupervisorService.ValidateSupervisorAccess(supervisorId, internshipId))
                {
                    MessageBox.Show("You do not have permission to evaluate this internship.",
                        "Access Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                // Display internship information
                txtStudents.Text = currentInternship.StudentName;
                txtCompanyName.Text = currentInternship.CompanyName;
                txtInternship.Text = internshipId.ToString();

                // Update form title
                this.Text = $"Evaluation - {currentInternship.StudentName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading internship details: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CheckForExistingEvaluation()
        {
            try
            {
                if (!selectedInternshipId.HasValue)
                    return;

                existingEvaluation = SupervisorService.GetEvaluationByInternship(selectedInternshipId.Value);

                if (existingEvaluation != null)
                {
                    isEditMode = true;
                    LoadExistingEvaluation();

                    MessageBox.Show("An evaluation already exists for this internship. You can update it.",
                        "Existing Evaluation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for existing evaluation: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadExistingEvaluation()
        {
            if (existingEvaluation == null)
                return;

            numPerformance.Value = existingEvaluation.PerformanceScore;
            numPunctuality.Value = existingEvaluation.PunctualityScore;
            numCommunication.Value = existingEvaluation.CommunicationScore;
            txtComments.Text = existingEvaluation.Comments ?? "";
            txtRecommendations.Text = existingEvaluation.Recommendations ?? "";

            CalculateAndDisplayOverallScore();
        }

        private void CalculateAndDisplayOverallScore()
        {
            decimal overall = (numPerformance.Value + numPunctuality.Value + numCommunication.Value) / 3;

            txtOverallScore.Text = overall.ToString("0.00");

            // Display rating
            string rating = GetPerformanceRating(overall);
            lblRating.Text = rating;

            // Color-code the rating
            lblRating.ForeColor = GetRatingColor(overall);
        }

        private string GetPerformanceRating(decimal score)
        {
            if (score >= 9) return "Excellent";
            if (score >= 7.5m) return "Very Good";
            if (score >= 6) return "Good";
            if (score >= 5) return "Satisfactory";
            if (score >= 3) return "Needs Improvement";
            return "Poor";
        }

        private Color GetRatingColor(decimal score)
        {
            if (score >= 9) return Color.DarkGreen;
            if (score >= 7.5m) return Color.Green;
            if (score >= 6) return Color.YellowGreen;
            if (score >= 5) return Color.Orange;
            if (score >= 3) return Color.OrangeRed;
            return Color.Red;
        }

        private bool ValidateInput()
        {
            // Check if internship is selected
            if (!selectedInternshipId.HasValue)
            {
                MessageBox.Show("Please select an internship to evaluate.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            // Validate score ranges (NumericUpDown should enforce this, but double-check)
            if (numPerformance.Value < 1 || numPerformance.Value > 10 ||
                numPunctuality.Value < 1 || numPunctuality.Value > 10 ||
                numCommunication.Value < 1 || numCommunication.Value > 10)
            {
                MessageBox.Show("All scores must be between 1 and 10.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            // Check if comments are provided (optional but recommended)
            if (string.IsNullOrWhiteSpace(txtComments.Text))
            {
                DialogResult result = MessageBox.Show(
                    "No comments provided. Do you want to continue without comments?",
                    "Missing Comments",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    txtComments.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (!ValidateInput())
                    return;

                // Check if evaluation already exists
                if (SupervisorService.HasEvaluation(selectedInternshipId.Value))
                {
                    MessageBox.Show("An evaluation already exists for this internship. Use 'Update' instead.",
                        "Duplicate Evaluation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Confirm save
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to save this evaluation for {currentInternship.StudentName}?\n\n" +
                    $"Overall Score: {txtOverallScore.Text}\n" +
                    $"Rating: {lblRating.Text}",
                    "Confirm Save",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                // Create evaluation model
                SupervisorEvaluationModel evaluation = new SupervisorEvaluationModel
                {
                    InternshipId = selectedInternshipId.Value,
                    SupervisorId = supervisorId,
                    PerformanceScore = (int)numPerformance.Value,
                    PunctualityScore = (int)numPunctuality.Value,
                    CommunicationScore = (int)numCommunication.Value,
                    Comments = txtComments.Text.Trim(),
                    Recommendations = txtRecommendations.Text.Trim()
                };

                // Calculate overall score
                evaluation.CalculateOverallScore();

                // Save to database
                int evaluationId = SupervisorService.CreateEvaluation(evaluation);

                if (evaluationId > 0)
                {
                    MessageBox.Show(
                        "Evaluation saved successfully!\n\n" +
                        $"Evaluation ID: {evaluationId}\n" +
                        $"Overall Score: {evaluation.OverallScore:0.00}\n" +
                        $"Rating: {evaluation.PerformanceRating}",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Set to edit mode
                    isEditMode = true;
                    existingEvaluation = evaluation;
                    existingEvaluation.EvaluationId = evaluationId;
                    UpdateButtonStates();
                }
                else
                {
                    MessageBox.Show("Failed to save evaluation. Please try again.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving evaluation: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateButtonStates()
        {
            if (isEditMode)
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnLoadExisting.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnLoadExisting.Enabled = true;
            }
        }
        private void ClearForm()
        {
            numPerformance.Value = 5;
            numPunctuality.Value = 5;
            numCommunication.Value = 5;
            txtComments.Clear();
            txtRecommendations.Clear();
            CalculateAndDisplayOverallScore();
        }

        private void ShowEvaluationPreview()
        {
            string preview = $@"EVALUATION SUMMARY
=====================================
Student: {txtStudents.Text}
Company: {txtCompanyName.Text}
Internship ID: {txtInternship.Text}

SCORES:
Performance: {numPerformance.Value}/10
Punctuality: {numPunctuality.Value}/10
Communication: {numCommunication.Value}/10
Overall: {txtOverallScore.Text}/10

RATING: {lblRating.Text}

COMMENTS:
{txtComments.Text}

RECOMMENDATIONS:
{txtRecommendations.Text}
";

            MessageBox.Show(preview,
                "Evaluation Preview",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                if (!ValidateInput())
                    return;

                // Check if in edit mode
                if (!isEditMode || existingEvaluation == null)
                {
                    MessageBox.Show("No existing evaluation to update. Use 'Save' instead.",
                        "No Existing Evaluation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Confirm update
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to update this evaluation for {currentInternship.StudentName}?\n\n" +
                    $"New Overall Score: {txtOverallScore.Text}\n" +
                    $"New Rating: {lblRating.Text}",
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                // Update evaluation model
                existingEvaluation.PerformanceScore = (int)numPerformance.Value;
                existingEvaluation.PunctualityScore = (int)numPunctuality.Value;
                existingEvaluation.CommunicationScore = (int)numCommunication.Value;
                existingEvaluation.Comments = txtComments.Text.Trim();
                existingEvaluation.Recommendations = txtRecommendations.Text.Trim();
                existingEvaluation.EvaluationDate = DateTime.Now;

                // Recalculate overall score
                existingEvaluation.CalculateOverallScore();

                // Update in database
                bool success = SupervisorService.UpdateEvaluation(existingEvaluation);

                if (success)
                {
                    MessageBox.Show(
                        "Evaluation updated successfully!\n\n" +
                        $"Overall Score: {existingEvaluation.OverallScore:0.00}\n" +
                        $"Rating: {existingEvaluation.PerformanceRating}",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to update evaluation. Please try again.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating evaluation: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLoadExisting_Click(object sender, EventArgs e)
        {
            try
            {
                if (!selectedInternshipId.HasValue)
                {
                    MessageBox.Show("No internship selected.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                existingEvaluation = SupervisorService.GetEvaluationByInternship(selectedInternshipId.Value);

                if (existingEvaluation != null)
                {
                    isEditMode = true;
                    LoadExistingEvaluation();
                    UpdateButtonStates();

                    MessageBox.Show("Existing evaluation loaded successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No existing evaluation found for this internship.",
                        "Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading existing evaluation: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
