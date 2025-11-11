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
            label2 = new Label();
            txtCompany = new TextBox();
            label1 = new Label();
            lblHRName = new Label();
            groupBox1 = new GroupBox();
            txtActiveInterns = new TextBox();
            label6 = new Label();
            txtPendingReviews = new TextBox();
            txtTotalApplications = new TextBox();
            label3 = new Label();
            txtActivePositions = new TextBox();
            label4 = new Label();
            label5 = new Label();
            groupBox2 = new GroupBox();
            btnTrackInterns = new Button();
            btnLogout = new Button();
            btnRefresh = new Button();
            btnProfile = new Button();
            btnReviewApplications = new Button();
            btnManagePositions = new Button();
            grpHRInfo.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // grpHRInfo
            // 
            grpHRInfo.Controls.Add(txtEmail);
            grpHRInfo.Controls.Add(label2);
            grpHRInfo.Controls.Add(txtCompany);
            grpHRInfo.Controls.Add(label1);
            grpHRInfo.Controls.Add(lblHRName);
            grpHRInfo.Location = new Point(42, 38);
            grpHRInfo.Margin = new Padding(5);
            grpHRInfo.Name = "grpHRInfo";
            grpHRInfo.Padding = new Padding(5);
            grpHRInfo.Size = new Size(593, 200);
            grpHRInfo.TabIndex = 0;
            grpHRInfo.TabStop = false;
            grpHRInfo.Enter += grpHRInfo_Enter;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(266, 130);
            txtEmail.Margin = new Padding(5);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(201, 39);
            txtEmail.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 134);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(76, 32);
            label2.TabIndex = 3;
            label2.Text = "Email:";
            // 
            // txtCompany
            // 
            txtCompany.Location = new Point(266, 74);
            txtCompany.Margin = new Padding(5);
            txtCompany.Name = "txtCompany";
            txtCompany.ReadOnly = true;
            txtCompany.Size = new Size(201, 39);
            txtCompany.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 85);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(121, 32);
            label1.TabIndex = 1;
            label1.Text = "Company:";
            // 
            // lblHRName
            // 
            lblHRName.AutoSize = true;
            lblHRName.Location = new Point(28, 37);
            lblHRName.Margin = new Padding(5, 0, 5, 0);
            lblHRName.Name = "lblHRName";
            lblHRName.Size = new Size(125, 32);
            lblHRName.TabIndex = 0;
            lblHRName.Text = "Welcome, ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtActiveInterns);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtPendingReviews);
            groupBox1.Controls.Add(txtTotalApplications);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtActivePositions);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(42, 264);
            groupBox1.Margin = new Padding(5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5);
            groupBox1.Size = new Size(593, 232);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // txtActiveInterns
            // 
            txtActiveInterns.Location = new Point(266, 179);
            txtActiveInterns.Margin = new Padding(5);
            txtActiveInterns.Name = "txtActiveInterns";
            txtActiveInterns.ReadOnly = true;
            txtActiveInterns.Size = new Size(201, 39);
            txtActiveInterns.TabIndex = 7;
            txtActiveInterns.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 184);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(164, 32);
            label6.TabIndex = 6;
            label6.Text = "Active Interns:";
            // 
            // txtPendingReviews
            // 
            txtPendingReviews.Location = new Point(266, 130);
            txtPendingReviews.Margin = new Padding(5);
            txtPendingReviews.Name = "txtPendingReviews";
            txtPendingReviews.ReadOnly = true;
            txtPendingReviews.Size = new Size(201, 39);
            txtPendingReviews.TabIndex = 5;
            txtPendingReviews.Text = "0";
            // 
            // txtTotalApplications
            // 
            txtTotalApplications.Location = new Point(266, 80);
            txtTotalApplications.Margin = new Padding(5);
            txtTotalApplications.Name = "txtTotalApplications";
            txtTotalApplications.ReadOnly = true;
            txtTotalApplications.Size = new Size(201, 39);
            txtTotalApplications.TabIndex = 4;
            txtTotalApplications.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 134);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(197, 32);
            label3.TabIndex = 3;
            label3.Text = "Pending Reviews:";
            // 
            // txtActivePositions
            // 
            txtActivePositions.Location = new Point(266, 32);
            txtActivePositions.Margin = new Padding(5);
            txtActivePositions.Name = "txtActivePositions";
            txtActivePositions.ReadOnly = true;
            txtActivePositions.Size = new Size(201, 39);
            txtActivePositions.TabIndex = 2;
            txtActivePositions.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 85);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(207, 32);
            label4.TabIndex = 1;
            label4.Text = "Total Applications:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 37);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(185, 32);
            label5.TabIndex = 0;
            label5.Text = "Active Positions:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnTrackInterns);
            groupBox2.Controls.Add(btnLogout);
            groupBox2.Controls.Add(btnRefresh);
            groupBox2.Controls.Add(btnProfile);
            groupBox2.Controls.Add(btnReviewApplications);
            groupBox2.Controls.Add(btnManagePositions);
            groupBox2.Location = new Point(42, 531);
            groupBox2.Margin = new Padding(5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5);
            groupBox2.Size = new Size(593, 221);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            // 
            // btnTrackInterns
            // 
            btnTrackInterns.Location = new Point(28, 154);
            btnTrackInterns.Margin = new Padding(5);
            btnTrackInterns.Name = "btnTrackInterns";
            btnTrackInterns.Size = new Size(247, 46);
            btnTrackInterns.TabIndex = 7;
            btnTrackInterns.Text = "Track Interns";
            btnTrackInterns.UseVisualStyleBackColor = true;
            btnTrackInterns.Click += btnTrackInterns_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(310, 154);
            btnLogout.Margin = new Padding(5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(247, 46);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(310, 98);
            btnRefresh.Margin = new Padding(5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(247, 46);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh Dashboard";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnProfile
            // 
            btnProfile.Location = new Point(28, 98);
            btnProfile.Margin = new Padding(5);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(247, 46);
            btnProfile.TabIndex = 4;
            btnProfile.Text = "My Profile";
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnReviewApplications
            // 
            btnReviewApplications.Location = new Point(310, 42);
            btnReviewApplications.Margin = new Padding(5);
            btnReviewApplications.Name = "btnReviewApplications";
            btnReviewApplications.Size = new Size(247, 46);
            btnReviewApplications.TabIndex = 1;
            btnReviewApplications.Text = "Review Applications";
            btnReviewApplications.UseVisualStyleBackColor = true;
            btnReviewApplications.Click += btnReviewApplications_Click;
            // 
            // btnManagePositions
            // 
            btnManagePositions.Location = new Point(28, 42);
            btnManagePositions.Margin = new Padding(5);
            btnManagePositions.Name = "btnManagePositions";
            btnManagePositions.Size = new Size(247, 46);
            btnManagePositions.TabIndex = 0;
            btnManagePositions.Text = "Manage Positions";
            btnManagePositions.UseVisualStyleBackColor = true;
            btnManagePositions.Click += btnManagePositions_Click;
            // 
            // frmHrMain
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 770);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(grpHRInfo);
            Margin = new Padding(5);
            Name = "frmHrMain";
            Text = "Company HR Dashboard";
            FormClosing += frmHrMain_FormClosing;
            FormClosed += frmHrMain_FormClosed;
            Load += frmHrMain_Load;
            grpHRInfo.ResumeLayout(false);
            grpHRInfo.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpHRInfo;
        private Label lblHRName;
        private TextBox txtEmail;
        private Label label2;
        private TextBox txtCompany;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtTotalApplications;
        private Label label3;
        private TextBox txtActivePositions;
        private Label label4;
        private Label label5;
        private TextBox txtActiveInterns;
        private Label label6;
        private TextBox txtPendingReviews;
        private GroupBox groupBox2;
        private Button btnReviewApplications;
        private Button btnManagePositions;
        private Button btnLogout;
        private Button btnRefresh;
        private Button btnProfile;
        private Button btnTrackInterns;
    }
}