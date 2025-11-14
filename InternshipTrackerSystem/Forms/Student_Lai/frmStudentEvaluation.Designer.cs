namespace InternshipTrackerSystem.Forms.Student_Lai
{
    partial class frmStudentEvaluation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            dgvEvaluations = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colCompany = new DataGridViewTextBoxColumn();
            colSupervisor = new DataGridViewTextBoxColumn();
            colOverallScore = new DataGridViewTextBoxColumn();
            colActions = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvEvaluations).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(16, 14);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1280, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SUPERVISOR EVALUATIONS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvEvaluations
            // 
            dgvEvaluations.AllowUserToAddRows = false;
            dgvEvaluations.AllowUserToDeleteRows = false;
            dgvEvaluations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvaluations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvaluations.Columns.AddRange(new DataGridViewColumn[] { colDate, colCompany, colSupervisor, colOverallScore, colActions });
            dgvEvaluations.Location = new Point(40, 123);
            dgvEvaluations.Margin = new Padding(4, 5, 4, 5);
            dgvEvaluations.Name = "dgvEvaluations";
            dgvEvaluations.ReadOnly = true;
            dgvEvaluations.RowHeadersVisible = false;
            dgvEvaluations.RowHeadersWidth = 51;
            dgvEvaluations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvaluations.Size = new Size(1227, 708);
            dgvEvaluations.TabIndex = 1;
            // 
            // colDate
            // 
            colDate.HeaderText = "Date";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colCompany
            // 
            colCompany.HeaderText = "Company";
            colCompany.MinimumWidth = 6;
            colCompany.Name = "colCompany";
            colCompany.ReadOnly = true;
            // 
            // colSupervisor
            // 
            colSupervisor.HeaderText = "Supervisor";
            colSupervisor.MinimumWidth = 6;
            colSupervisor.Name = "colSupervisor";
            colSupervisor.ReadOnly = true;
            // 
            // colOverallScore
            // 
            colOverallScore.HeaderText = "Overall Score";
            colOverallScore.MinimumWidth = 6;
            colOverallScore.Name = "colOverallScore";
            colOverallScore.ReadOnly = true;
            // 
            // colActions
            // 
            colActions.FillWeight = 80F;
            colActions.HeaderText = "Actions";
            colActions.MinimumWidth = 6;
            colActions.Name = "colActions";
            colActions.ReadOnly = true;
            colActions.Text = "View Details";
            colActions.UseColumnTextForButtonValue = true;
            // 
            // frmStudentEvaluation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1312, 863);
            Controls.Add(dgvEvaluations);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmStudentEvaluation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Supervisor Evaluations";
            ((System.ComponentModel.ISupportInitialize)dgvEvaluations).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvEvaluations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupervisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOverallScore;
        private System.Windows.Forms.DataGridViewButtonColumn colActions;
    }

    #endregion
}
