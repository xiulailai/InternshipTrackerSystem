namespace InternshipTrackerSystem.Forms.Supervisor
{
    partial class frmSupvMain
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
            btnViewInterns = new Button();
            btnReports = new Button();
            btnEvaluation = new Button();
            btnLogout = new Button();
            btnProfile = new Button();
            btnNotifications = new Button();
            lblInterns = new Label();
            lblReports = new Label();
            lblEvaluation = new Label();
            lblInternsResult = new Label();
            lblReportsResult = new Label();
            lblEvaluationResult = new Label();
            txtTotalInternships = new TextBox();
            txtPendingReports = new TextBox();
            txtPendingEvaluations = new TextBox();
            lblWelcome = new Label();
            lblSupervisorName = new Label();
            lblDepartment = new Label();
            txtDepartment = new TextBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            label1 = new Label();
            txtOngoing = new TextBox();
            label2 = new Label();
            txtCompleted = new TextBox();
            label3 = new Label();
            txtTotalStudents = new TextBox();
            btnRefresh = new Button();
            SuspendLayout();
            // 
            // btnViewInterns
            // 
            btnViewInterns.BackColor = SystemColors.ButtonFace;
            btnViewInterns.Font = new Font("Segoe UI", 9F);
            btnViewInterns.ForeColor = SystemColors.ActiveCaptionText;
            btnViewInterns.Location = new Point(20, 330);
            btnViewInterns.Name = "btnViewInterns";
            btnViewInterns.Size = new Size(140, 30);
            btnViewInterns.TabIndex = 1;
            btnViewInterns.Text = "View Interns";
            btnViewInterns.UseVisualStyleBackColor = false;
            btnViewInterns.Click += btnViewInterns_Click;
            // 
            // btnReports
            // 
            btnReports.BackColor = SystemColors.ButtonFace;
            btnReports.Font = new Font("Segoe UI", 9F);
            btnReports.ForeColor = SystemColors.ActiveCaptionText;
            btnReports.Location = new Point(175, 330);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(140, 30);
            btnReports.TabIndex = 2;
            btnReports.Text = "View Reports";
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // 
            // btnEvaluation
            // 
            btnEvaluation.BackColor = SystemColors.ButtonFace;
            btnEvaluation.Font = new Font("Segoe UI", 9F);
            btnEvaluation.ForeColor = SystemColors.ActiveCaptionText;
            btnEvaluation.Location = new Point(330, 330);
            btnEvaluation.Name = "btnEvaluation";
            btnEvaluation.Size = new Size(140, 30);
            btnEvaluation.TabIndex = 3;
            btnEvaluation.Text = "View Evaluation";
            btnEvaluation.UseVisualStyleBackColor = false;
            btnEvaluation.Click += btnEvaluation_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = SystemColors.ButtonFace;
            btnLogout.Font = new Font("Segoe UI", 9F);
            btnLogout.ForeColor = SystemColors.ActiveCaptionText;
            btnLogout.Location = new Point(175, 410);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(140, 30);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = SystemColors.ButtonFace;
            btnProfile.Font = new Font("Segoe UI", 9F);
            btnProfile.ForeColor = SystemColors.ActiveCaptionText;
            btnProfile.Location = new Point(175, 370);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(140, 30);
            btnProfile.TabIndex = 1;
            btnProfile.Text = "View Profile";
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnNotifications
            // 
            btnNotifications.BackColor = SystemColors.ButtonFace;
            btnNotifications.Font = new Font("Segoe UI", 9F);
            btnNotifications.ForeColor = SystemColors.ActiveCaptionText;
            btnNotifications.Location = new Point(20, 370);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Size = new Size(140, 30);
            btnNotifications.TabIndex = 2;
            btnNotifications.Text = "Notification";
            btnNotifications.UseVisualStyleBackColor = false;
            btnNotifications.Click += btnNotifications_Click;
            // 
            // lblInterns
            // 
            lblInterns.AutoSize = true;
            lblInterns.Font = new Font("Segoe UI", 10F);
            lblInterns.Location = new Point(30, 130);
            lblInterns.Name = "lblInterns";
            lblInterns.Size = new Size(132, 23);
            lblInterns.TabIndex = 5;
            lblInterns.Text = "Total Internship:";
            // 
            // lblReports
            // 
            lblReports.AutoSize = true;
            lblReports.Font = new Font("Segoe UI", 10F);
            lblReports.Location = new Point(30, 220);
            lblReports.Name = "lblReports";
            lblReports.Size = new Size(139, 23);
            lblReports.TabIndex = 5;
            lblReports.Text = "Pending Reports:";
            // 
            // lblEvaluation
            // 
            lblEvaluation.AutoSize = true;
            lblEvaluation.Font = new Font("Segoe UI", 10F);
            lblEvaluation.Location = new Point(30, 250);
            lblEvaluation.Name = "lblEvaluation";
            lblEvaluation.Size = new Size(160, 23);
            lblEvaluation.TabIndex = 5;
            lblEvaluation.Text = "Pending Evaluation:";
            // 
            // lblInternsResult
            // 
            lblInternsResult.AutoSize = true;
            lblInternsResult.Font = new Font("Segoe UI", 10F);
            lblInternsResult.Location = new Point(177, 199);
            lblInternsResult.Name = "lblInternsResult";
            lblInternsResult.Size = new Size(0, 23);
            lblInternsResult.TabIndex = 6;
            // 
            // lblReportsResult
            // 
            lblReportsResult.AutoSize = true;
            lblReportsResult.Font = new Font("Segoe UI", 10F);
            lblReportsResult.Location = new Point(177, 234);
            lblReportsResult.Name = "lblReportsResult";
            lblReportsResult.Size = new Size(0, 23);
            lblReportsResult.TabIndex = 6;
            // 
            // lblEvaluationResult
            // 
            lblEvaluationResult.AutoSize = true;
            lblEvaluationResult.Font = new Font("Segoe UI", 10F);
            lblEvaluationResult.Location = new Point(177, 269);
            lblEvaluationResult.Name = "lblEvaluationResult";
            lblEvaluationResult.Size = new Size(0, 23);
            lblEvaluationResult.TabIndex = 6;
            // 
            // txtTotalInternships
            // 
            txtTotalInternships.BorderStyle = BorderStyle.None;
            txtTotalInternships.Font = new Font("Segoe UI", 10F);
            txtTotalInternships.Location = new Point(250, 130);
            txtTotalInternships.Name = "txtTotalInternships";
            txtTotalInternships.ReadOnly = true;
            txtTotalInternships.Size = new Size(80, 23);
            txtTotalInternships.TabIndex = 7;
            // 
            // txtPendingReports
            // 
            txtPendingReports.BorderStyle = BorderStyle.None;
            txtPendingReports.Font = new Font("Segoe UI", 10F);
            txtPendingReports.Location = new Point(250, 220);
            txtPendingReports.Name = "txtPendingReports";
            txtPendingReports.ReadOnly = true;
            txtPendingReports.Size = new Size(80, 23);
            txtPendingReports.TabIndex = 7;
            // 
            // txtPendingEvaluations
            // 
            txtPendingEvaluations.BorderStyle = BorderStyle.None;
            txtPendingEvaluations.Font = new Font("Segoe UI", 10F);
            txtPendingEvaluations.Location = new Point(250, 250);
            txtPendingEvaluations.Name = "txtPendingEvaluations";
            txtPendingEvaluations.ReadOnly = true;
            txtPendingEvaluations.Size = new Size(80, 23);
            txtPendingEvaluations.TabIndex = 7;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 10F);
            lblWelcome.Location = new Point(30, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(84, 23);
            lblWelcome.TabIndex = 8;
            lblWelcome.Text = "Welcome,";
            // 
            // lblSupervisorName
            // 
            lblSupervisorName.AutoSize = true;
            lblSupervisorName.Font = new Font("Segoe UI", 10F);
            lblSupervisorName.Location = new Point(100, 20);
            lblSupervisorName.Name = "lblSupervisorName";
            lblSupervisorName.Size = new Size(0, 23);
            lblSupervisorName.TabIndex = 9;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 10F);
            lblDepartment.Location = new Point(30, 70);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(106, 23);
            lblDepartment.TabIndex = 8;
            lblDepartment.Text = "Department:";
            // 
            // txtDepartment
            // 
            txtDepartment.BorderStyle = BorderStyle.None;
            txtDepartment.Font = new Font("Segoe UI", 10F);
            txtDepartment.Location = new Point(250, 70);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.ReadOnly = true;
            txtDepartment.Size = new Size(150, 23);
            txtDepartment.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(250, 100);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(150, 23);
            txtEmail.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(30, 100);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(60, 23);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(30, 160);
            label1.Name = "label1";
            label1.Size = new Size(163, 23);
            label1.TabIndex = 5;
            label1.Text = "Ongoing Internship:";
            // 
            // txtOngoing
            // 
            txtOngoing.BorderStyle = BorderStyle.None;
            txtOngoing.Font = new Font("Segoe UI", 10F);
            txtOngoing.Location = new Point(250, 160);
            txtOngoing.Name = "txtOngoing";
            txtOngoing.ReadOnly = true;
            txtOngoing.Size = new Size(80, 23);
            txtOngoing.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(30, 190);
            label2.Name = "label2";
            label2.Size = new Size(180, 23);
            label2.TabIndex = 5;
            label2.Text = "Completed Internship:";
            // 
            // txtCompleted
            // 
            txtCompleted.BorderStyle = BorderStyle.None;
            txtCompleted.Font = new Font("Segoe UI", 10F);
            txtCompleted.Location = new Point(250, 190);
            txtCompleted.Name = "txtCompleted";
            txtCompleted.ReadOnly = true;
            txtCompleted.Size = new Size(80, 23);
            txtCompleted.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(30, 280);
            label3.Name = "label3";
            label3.Size = new Size(208, 23);
            label3.TabIndex = 5;
            label3.Text = "Total Students Supervised:";
            // 
            // txtTotalStudents
            // 
            txtTotalStudents.BorderStyle = BorderStyle.None;
            txtTotalStudents.Font = new Font("Segoe UI", 10F);
            txtTotalStudents.Location = new Point(250, 280);
            txtTotalStudents.Name = "txtTotalStudents";
            txtTotalStudents.ReadOnly = true;
            txtTotalStudents.Size = new Size(80, 23);
            txtTotalStudents.TabIndex = 7;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ButtonFace;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.ForeColor = SystemColors.ActiveCaptionText;
            btnRefresh.Location = new Point(330, 370);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(140, 30);
            btnRefresh.TabIndex = 10;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // frmSupvMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(492, 463);
            Controls.Add(btnRefresh);
            Controls.Add(lblSupervisorName);
            Controls.Add(lblEmail);
            Controls.Add(lblDepartment);
            Controls.Add(lblWelcome);
            Controls.Add(txtTotalStudents);
            Controls.Add(txtPendingEvaluations);
            Controls.Add(txtPendingReports);
            Controls.Add(txtEmail);
            Controls.Add(txtDepartment);
            Controls.Add(txtCompleted);
            Controls.Add(txtOngoing);
            Controls.Add(txtTotalInternships);
            Controls.Add(lblEvaluationResult);
            Controls.Add(lblReportsResult);
            Controls.Add(lblInternsResult);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(lblEvaluation);
            Controls.Add(label1);
            Controls.Add(lblReports);
            Controls.Add(lblInterns);
            Controls.Add(btnLogout);
            Controls.Add(btnNotifications);
            Controls.Add(btnEvaluation);
            Controls.Add(btnProfile);
            Controls.Add(btnReports);
            Controls.Add(btnViewInterns);
            Name = "frmSupvMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Supervisor Dashboard";
            FormClosing += frmSupvMain_FormClosing;
            Load += frmSupvMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnViewInterns;
        private Button btnReports;
        private Button btnEvaluation;
        private Button btnLogout;
        private Button btnProfile;
        private Button btnNotifications;
        private Label lblInterns;
        private Label lblReports;
        private Label lblEvaluation;
        private Label lblInternsResult;
        private Label lblReportsResult;
        private Label lblEvaluationResult;
        private TextBox txtTotalInternships;
        private TextBox txtPendingReports;
        private TextBox txtPendingEvaluations;
        private Label lblWelcome;
        private Label lblSupervisorName;
        private Label lblDepartment;
        private TextBox txtDepartment;
        private TextBox txtEmail;
        private Label lblEmail;
        private Label label1;
        private TextBox txtOngoing;
        private Label label2;
        private TextBox txtCompleted;
        private Label label3;
        private TextBox txtTotalStudents;
        private Button btnRefresh;
    }
}