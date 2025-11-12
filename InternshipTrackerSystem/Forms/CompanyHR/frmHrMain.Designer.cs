namespace InternshipTrackerSystem.Forms.CompanyHR
{
    partial class frmHrMain
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
            grpHRInfo = new GroupBox();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtCompany = new TextBox();
            lblCompany = new Label();
            lblHRName = new Label();
            grpHRStatistics = new GroupBox();
            txtActiveInterns = new TextBox();
            lblActiveInterns = new Label();
            txtPendingReviews = new TextBox();
            txtTotalApplications = new TextBox();
            lblPendingRev = new Label();
            txtActivePositions = new TextBox();
            lblTotalApp = new Label();
            lblActivePos = new Label();
            grpHRButtons = new GroupBox();
            btnTrackInterns = new Button();
            btnLogout = new Button();
            btnRefresh = new Button();
            btnProfile = new Button();
            btnReviewApplications = new Button();
            btnManagePositions = new Button();
            grpHRInfo.SuspendLayout();
            grpHRStatistics.SuspendLayout();
            grpHRButtons.SuspendLayout();
            SuspendLayout();
            // 
            // grpHRInfo
            // 
            grpHRInfo.Controls.Add(txtEmail);
            grpHRInfo.Controls.Add(lblEmail);
            grpHRInfo.Controls.Add(txtCompany);
            grpHRInfo.Controls.Add(lblCompany);
            grpHRInfo.Controls.Add(lblHRName);
            grpHRInfo.Location = new Point(26, 24);
            grpHRInfo.Name = "grpHRInfo";
            grpHRInfo.Size = new Size(365, 125);
            grpHRInfo.TabIndex = 0;
            grpHRInfo.TabStop = false;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(135, 81);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(208, 27);
            txtEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(17, 84);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // txtCompany
            // 
            txtCompany.Location = new Point(135, 46);
            txtCompany.Name = "txtCompany";
            txtCompany.ReadOnly = true;
            txtCompany.Size = new Size(208, 27);
            txtCompany.TabIndex = 2;
            // 
            // lblCompany
            // 
            lblCompany.AutoSize = true;
            lblCompany.Location = new Point(17, 53);
            lblCompany.Name = "lblCompany";
            lblCompany.Size = new Size(75, 20);
            lblCompany.TabIndex = 1;
            lblCompany.Text = "Company:";
            // 
            // lblHRName
            // 
            lblHRName.AutoSize = true;
            lblHRName.Location = new Point(17, 23);
            lblHRName.Name = "lblHRName";
            lblHRName.Size = new Size(78, 20);
            lblHRName.TabIndex = 0;
            lblHRName.Text = "Welcome, ";
            // 
            // grpHRStatistics
            // 
            grpHRStatistics.Controls.Add(txtActiveInterns);
            grpHRStatistics.Controls.Add(lblActiveInterns);
            grpHRStatistics.Controls.Add(txtPendingReviews);
            grpHRStatistics.Controls.Add(txtTotalApplications);
            grpHRStatistics.Controls.Add(lblPendingRev);
            grpHRStatistics.Controls.Add(txtActivePositions);
            grpHRStatistics.Controls.Add(lblTotalApp);
            grpHRStatistics.Controls.Add(lblActivePos);
            grpHRStatistics.Location = new Point(26, 165);
            grpHRStatistics.Name = "grpHRStatistics";
            grpHRStatistics.Size = new Size(365, 145);
            grpHRStatistics.TabIndex = 5;
            grpHRStatistics.TabStop = false;
            // 
            // txtActiveInterns
            // 
            txtActiveInterns.Location = new Point(218, 108);
            txtActiveInterns.Name = "txtActiveInterns";
            txtActiveInterns.ReadOnly = true;
            txtActiveInterns.Size = new Size(125, 27);
            txtActiveInterns.TabIndex = 7;
            txtActiveInterns.Text = "0";
            // 
            // lblActiveInterns
            // 
            lblActiveInterns.AutoSize = true;
            lblActiveInterns.Location = new Point(17, 115);
            lblActiveInterns.Name = "lblActiveInterns";
            lblActiveInterns.Size = new Size(101, 20);
            lblActiveInterns.TabIndex = 6;
            lblActiveInterns.Text = "Active Interns:";
            // 
            // txtPendingReviews
            // 
            txtPendingReviews.Location = new Point(218, 77);
            txtPendingReviews.Name = "txtPendingReviews";
            txtPendingReviews.ReadOnly = true;
            txtPendingReviews.Size = new Size(125, 27);
            txtPendingReviews.TabIndex = 5;
            txtPendingReviews.Text = "0";
            // 
            // txtTotalApplications
            // 
            txtTotalApplications.Location = new Point(218, 46);
            txtTotalApplications.Name = "txtTotalApplications";
            txtTotalApplications.ReadOnly = true;
            txtTotalApplications.Size = new Size(125, 27);
            txtTotalApplications.TabIndex = 4;
            txtTotalApplications.Text = "0";
            // 
            // lblPendingRev
            // 
            lblPendingRev.AutoSize = true;
            lblPendingRev.Location = new Point(17, 84);
            lblPendingRev.Name = "lblPendingRev";
            lblPendingRev.Size = new Size(122, 20);
            lblPendingRev.TabIndex = 3;
            lblPendingRev.Text = "Pending Reviews:";
            // 
            // txtActivePositions
            // 
            txtActivePositions.Location = new Point(218, 16);
            txtActivePositions.Name = "txtActivePositions";
            txtActivePositions.ReadOnly = true;
            txtActivePositions.Size = new Size(125, 27);
            txtActivePositions.TabIndex = 2;
            txtActivePositions.Text = "0";
            // 
            // lblTotalApp
            // 
            lblTotalApp.AutoSize = true;
            lblTotalApp.Location = new Point(17, 53);
            lblTotalApp.Name = "lblTotalApp";
            lblTotalApp.Size = new Size(132, 20);
            lblTotalApp.TabIndex = 1;
            lblTotalApp.Text = "Total Applications:";
            // 
            // lblActivePos
            // 
            lblActivePos.AutoSize = true;
            lblActivePos.Location = new Point(17, 23);
            lblActivePos.Name = "lblActivePos";
            lblActivePos.Size = new Size(115, 20);
            lblActivePos.TabIndex = 0;
            lblActivePos.Text = "Active Positions:";
            // 
            // grpHRButtons
            // 
            grpHRButtons.Controls.Add(btnTrackInterns);
            grpHRButtons.Controls.Add(btnLogout);
            grpHRButtons.Controls.Add(btnRefresh);
            grpHRButtons.Controls.Add(btnProfile);
            grpHRButtons.Controls.Add(btnReviewApplications);
            grpHRButtons.Controls.Add(btnManagePositions);
            grpHRButtons.Location = new Point(26, 332);
            grpHRButtons.Name = "grpHRButtons";
            grpHRButtons.Size = new Size(365, 138);
            grpHRButtons.TabIndex = 6;
            grpHRButtons.TabStop = false;
            // 
            // btnTrackInterns
            // 
            btnTrackInterns.Location = new Point(17, 96);
            btnTrackInterns.Name = "btnTrackInterns";
            btnTrackInterns.Size = new Size(152, 29);
            btnTrackInterns.TabIndex = 7;
            btnTrackInterns.Text = "Track Interns";
            btnTrackInterns.UseVisualStyleBackColor = true;
            btnTrackInterns.Click += btnTrackInterns_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(191, 96);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(152, 29);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(191, 61);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(152, 29);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh Dashboard";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnProfile
            // 
            btnProfile.Location = new Point(17, 61);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(152, 29);
            btnProfile.TabIndex = 4;
            btnProfile.Text = "My Profile";
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnReviewApplications
            // 
            btnReviewApplications.Location = new Point(191, 26);
            btnReviewApplications.Name = "btnReviewApplications";
            btnReviewApplications.Size = new Size(152, 29);
            btnReviewApplications.TabIndex = 1;
            btnReviewApplications.Text = "Review Applications";
            btnReviewApplications.UseVisualStyleBackColor = true;
            btnReviewApplications.Click += btnReviewApplications_Click;
            // 
            // btnManagePositions
            // 
            btnManagePositions.Location = new Point(17, 26);
            btnManagePositions.Name = "btnManagePositions";
            btnManagePositions.Size = new Size(152, 29);
            btnManagePositions.TabIndex = 0;
            btnManagePositions.Text = "Manage Positions";
            btnManagePositions.UseVisualStyleBackColor = true;
            btnManagePositions.Click += btnManagePositions_Click;
            // 
            // frmHrMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 481);
            Controls.Add(grpHRButtons);
            Controls.Add(grpHRStatistics);
            Controls.Add(grpHRInfo);
            Name = "frmHrMain";
            Text = "Company HR Dashboard";
            FormClosing += frmHrMain_FormClosing;
            FormClosed += frmHrMain_FormClosed;
            Load += frmHrMain_Load;
            grpHRInfo.ResumeLayout(false);
            grpHRInfo.PerformLayout();
            grpHRStatistics.ResumeLayout(false);
            grpHRStatistics.PerformLayout();
            grpHRButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpHRInfo;
        private Label lblHRName;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtCompany;
        private Label lblCompany;
        private GroupBox grpHRStatistics;
        private TextBox txtTotalApplications;
        private Label lblPendingRev;
        private TextBox txtActivePositions;
        private Label lblTotalApp;
        private Label lblActivePos;
        private TextBox txtActiveInterns;
        private Label lblActiveInterns;
        private TextBox txtPendingReviews;
        private GroupBox grpHRButtons;
        private Button btnReviewApplications;
        private Button btnManagePositions;
        private Button btnLogout;
        private Button btnRefresh;
        private Button btnProfile;
        private Button btnTrackInterns;
    }
}