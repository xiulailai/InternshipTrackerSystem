namespace InternshipTrackerSystem.Forms.Student_Lai
{
    partial class frmStudentDashboard
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
            lblTotalApps = new Label();
            txtTotalApps = new TextBox();
            lblPending = new Label();
            txtPending = new TextBox();
            lblActiveInternships = new Label();
            txtActiveInternships = new TextBox();
            lblReportsSubmitted = new Label();
            txtReportsSubmitted = new TextBox();
            btnViewProfile = new Button();
            btnSearchInternships = new Button();
            btnMyApplications = new Button();
            btnMyReports = new Button();
            btnEvaluations = new Button();
            btnSubmission = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(16, 14);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1035, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "STUDENT DASHBOARD";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalApps
            // 
            lblTotalApps.AutoSize = true;
            lblTotalApps.Font = new Font("Segoe UI", 10F);
            lblTotalApps.Location = new Point(40, 108);
            lblTotalApps.Margin = new Padding(4, 0, 4, 0);
            lblTotalApps.Name = "lblTotalApps";
            lblTotalApps.Size = new Size(148, 23);
            lblTotalApps.TabIndex = 1;
            lblTotalApps.Text = "Total Applications:";
            // 
            // txtTotalApps
            // 
            txtTotalApps.Font = new Font("Segoe UI", 10F);
            txtTotalApps.Location = new Point(227, 103);
            txtTotalApps.Margin = new Padding(4, 5, 4, 5);
            txtTotalApps.Name = "txtTotalApps";
            txtTotalApps.ReadOnly = true;
            txtTotalApps.Size = new Size(105, 30);
            txtTotalApps.TabIndex = 2;
            txtTotalApps.Text = "0";
            txtTotalApps.TextAlign = HorizontalAlignment.Center;
            // 
            // lblPending
            // 
            lblPending.AutoSize = true;
            lblPending.Font = new Font("Segoe UI", 10F);
            lblPending.Location = new Point(373, 108);
            lblPending.Margin = new Padding(4, 0, 4, 0);
            lblPending.Name = "lblPending";
            lblPending.Size = new Size(76, 23);
            lblPending.TabIndex = 3;
            lblPending.Text = "Pending:";
            // 
            // txtPending
            // 
            txtPending.Font = new Font("Segoe UI", 10F);
            txtPending.Location = new Point(468, 103);
            txtPending.Margin = new Padding(4, 5, 4, 5);
            txtPending.Name = "txtPending";
            txtPending.ReadOnly = true;
            txtPending.Size = new Size(105, 30);
            txtPending.TabIndex = 4;
            txtPending.Text = "0";
            txtPending.TextAlign = HorizontalAlignment.Center;
            // 
            // lblActiveInternships
            // 
            lblActiveInternships.AutoSize = true;
            lblActiveInternships.Font = new Font("Segoe UI", 10F);
            lblActiveInternships.Location = new Point(40, 169);
            lblActiveInternships.Margin = new Padding(4, 0, 4, 0);
            lblActiveInternships.Name = "lblActiveInternships";
            lblActiveInternships.Size = new Size(149, 23);
            lblActiveInternships.TabIndex = 5;
            lblActiveInternships.Text = "Active Internships:";
            // 
            // txtActiveInternships
            // 
            txtActiveInternships.Font = new Font("Segoe UI", 10F);
            txtActiveInternships.Location = new Point(227, 165);
            txtActiveInternships.Margin = new Padding(4, 5, 4, 5);
            txtActiveInternships.Name = "txtActiveInternships";
            txtActiveInternships.ReadOnly = true;
            txtActiveInternships.Size = new Size(105, 30);
            txtActiveInternships.TabIndex = 6;
            txtActiveInternships.Text = "0";
            txtActiveInternships.TextAlign = HorizontalAlignment.Center;
            // 
            // lblReportsSubmitted
            // 
            lblReportsSubmitted.AutoSize = true;
            lblReportsSubmitted.Font = new Font("Segoe UI", 10F);
            lblReportsSubmitted.Location = new Point(373, 169);
            lblReportsSubmitted.Margin = new Padding(4, 0, 4, 0);
            lblReportsSubmitted.Name = "lblReportsSubmitted";
            lblReportsSubmitted.Size = new Size(156, 23);
            lblReportsSubmitted.TabIndex = 7;
            lblReportsSubmitted.Text = "Reports Submitted:";
            // 
            // txtReportsSubmitted
            // 
            txtReportsSubmitted.Font = new Font("Segoe UI", 10F);
            txtReportsSubmitted.Location = new Point(559, 165);
            txtReportsSubmitted.Margin = new Padding(4, 5, 4, 5);
            txtReportsSubmitted.Name = "txtReportsSubmitted";
            txtReportsSubmitted.ReadOnly = true;
            txtReportsSubmitted.Size = new Size(105, 30);
            txtReportsSubmitted.TabIndex = 8;
            txtReportsSubmitted.Text = "0";
            txtReportsSubmitted.TextAlign = HorizontalAlignment.Center;
            // 
            // btnViewProfile
            // 
            btnViewProfile.Font = new Font("Segoe UI", 10F);
            btnViewProfile.Location = new Point(40, 262);
            btnViewProfile.Margin = new Padding(4, 5, 4, 5);
            btnViewProfile.Name = "btnViewProfile";
            btnViewProfile.Size = new Size(200, 62);
            btnViewProfile.TabIndex = 9;
            btnViewProfile.Text = "View Profile";
            btnViewProfile.UseVisualStyleBackColor = true;
            btnViewProfile.Click += btnViewProfile_Click;
            // 
            // btnSearchInternships
            // 
            btnSearchInternships.Font = new Font("Segoe UI", 10F);
            btnSearchInternships.Location = new Point(267, 262);
            btnSearchInternships.Margin = new Padding(4, 5, 4, 5);
            btnSearchInternships.Name = "btnSearchInternships";
            btnSearchInternships.Size = new Size(240, 62);
            btnSearchInternships.TabIndex = 10;
            btnSearchInternships.Text = "Search Internships";
            btnSearchInternships.UseVisualStyleBackColor = true;
            btnSearchInternships.Click += btnSearchInternships_Click;
            // 
            // btnMyApplications
            // 
            btnMyApplications.Font = new Font("Segoe UI", 10F);
            btnMyApplications.Location = new Point(533, 262);
            btnMyApplications.Margin = new Padding(4, 5, 4, 5);
            btnMyApplications.Name = "btnMyApplications";
            btnMyApplications.Size = new Size(213, 62);
            btnMyApplications.TabIndex = 11;
            btnMyApplications.Text = "My Applications";
            btnMyApplications.UseVisualStyleBackColor = true;
            btnMyApplications.Click += btnMyApplications_Click;
            // 
            // btnMyReports
            // 
            btnMyReports.Font = new Font("Segoe UI", 10F);
            btnMyReports.Location = new Point(40, 354);
            btnMyReports.Margin = new Padding(4, 5, 4, 5);
            btnMyReports.Name = "btnMyReports";
            btnMyReports.Size = new Size(200, 62);
            btnMyReports.TabIndex = 12;
            btnMyReports.Text = "My Reports";
            btnMyReports.UseVisualStyleBackColor = true;
            btnMyReports.Click += btnMyReports_Click;
            // 
            // btnEvaluations
            // 
            btnEvaluations.Font = new Font("Segoe UI", 10F);
            btnEvaluations.Location = new Point(267, 354);
            btnEvaluations.Margin = new Padding(4, 5, 4, 5);
            btnEvaluations.Name = "btnEvaluations";
            btnEvaluations.Size = new Size(240, 62);
            btnEvaluations.TabIndex = 13;
            btnEvaluations.Text = "Evaluations";
            btnEvaluations.UseVisualStyleBackColor = true;
            btnEvaluations.Click += btnEvaluations_Click;
            // 
            // btnSubmission
            // 
            btnSubmission.Location = new Point(533, 354);
            btnSubmission.Name = "btnSubmission";
            btnSubmission.Size = new Size(213, 62);
            btnSubmission.TabIndex = 14;
            btnSubmission.Text = "Submit Applications";
            btnSubmission.UseVisualStyleBackColor = true;
            btnSubmission.Click += btnSubmission_Click;
            // 
            // frmStudentDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 492);
            Controls.Add(btnSubmission);
            Controls.Add(btnEvaluations);
            Controls.Add(btnMyReports);
            Controls.Add(btnMyApplications);
            Controls.Add(btnSearchInternships);
            Controls.Add(btnViewProfile);
            Controls.Add(txtReportsSubmitted);
            Controls.Add(lblReportsSubmitted);
            Controls.Add(txtActiveInternships);
            Controls.Add(lblActiveInternships);
            Controls.Add(txtPending);
            Controls.Add(lblPending);
            Controls.Add(txtTotalApps);
            Controls.Add(lblTotalApps);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmStudentDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Dashboard";
            FormClosed += frmStudentDashboard_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotalApps;
        private System.Windows.Forms.TextBox txtTotalApps;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.TextBox txtPending;
        private System.Windows.Forms.Label lblActiveInternships;
        private System.Windows.Forms.TextBox txtActiveInternships;
        private System.Windows.Forms.Label lblReportsSubmitted;
        private System.Windows.Forms.TextBox txtReportsSubmitted;
        private System.Windows.Forms.Button btnViewProfile;
        private System.Windows.Forms.Button btnSearchInternships;
        private System.Windows.Forms.Button btnMyApplications;
        private System.Windows.Forms.Button btnMyReports;
        private System.Windows.Forms.Button btnEvaluations;
        private Button btnSubmission;
    }

    #endregion
}
