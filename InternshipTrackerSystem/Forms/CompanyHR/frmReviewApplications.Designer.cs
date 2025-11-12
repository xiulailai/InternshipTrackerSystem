namespace InternshipTrackerSystem.Forms.CompanyHR
{
    partial class frmReviewApplications
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
            lblCompanyName = new Label();
            cboStatusFilter = new ComboBox();
            lblStatusFilter = new Label();
            lblPositionFilter = new Label();
            cboPositionFilter = new ComboBox();
            dgvApplications = new DataGridView();
            grpApplicantDetails = new GroupBox();
            lblRemarks = new Label();
            lblSkills = new Label();
            lblAppliedDate = new Label();
            lblPositionApplied = new Label();
            lblEmail = new Label();
            lblCGPA = new Label();
            lblStudentID = new Label();
            lblContact = new Label();
            lblProgram = new Label();
            lblStudent = new Label();
            btnAccept = new Button();
            btnReject = new Button();
            btnRefresh = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).BeginInit();
            grpApplicantDetails.SuspendLayout();
            SuspendLayout();
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(26, 25);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(75, 20);
            lblCompanyName.TabIndex = 0;
            lblCompanyName.Text = "Company:";
            // 
            // cboStatusFilter
            // 
            cboStatusFilter.FormattingEnabled = true;
            cboStatusFilter.Location = new Point(26, 69);
            cboStatusFilter.Name = "cboStatusFilter";
            cboStatusFilter.Size = new Size(220, 28);
            cboStatusFilter.TabIndex = 1;
            cboStatusFilter.SelectedIndexChanged += cboStatusFilter_SelectedIndexChanged;
            // 
            // lblStatusFilter
            // 
            lblStatusFilter.AutoSize = true;
            lblStatusFilter.Location = new Point(26, 46);
            lblStatusFilter.Name = "lblStatusFilter";
            lblStatusFilter.Size = new Size(190, 20);
            lblStatusFilter.TabIndex = 2;
            lblStatusFilter.Text = "Filter by Application Status:";
            // 
            // lblPositionFilter
            // 
            lblPositionFilter.AutoSize = true;
            lblPositionFilter.Location = new Point(268, 46);
            lblPositionFilter.Name = "lblPositionFilter";
            lblPositionFilter.Size = new Size(148, 20);
            lblPositionFilter.TabIndex = 3;
            lblPositionFilter.Text = "Filter by Job Position:";
            // 
            // cboPositionFilter
            // 
            cboPositionFilter.FormattingEnabled = true;
            cboPositionFilter.Location = new Point(268, 69);
            cboPositionFilter.Name = "cboPositionFilter";
            cboPositionFilter.Size = new Size(220, 28);
            cboPositionFilter.TabIndex = 4;
            cboPositionFilter.SelectedIndexChanged += cboPositionFilter_SelectedIndexChanged;
            // 
            // dgvApplications
            // 
            dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplications.Location = new Point(26, 103);
            dgvApplications.Name = "dgvApplications";
            dgvApplications.RowHeadersWidth = 51;
            dgvApplications.Size = new Size(673, 188);
            dgvApplications.TabIndex = 5;
            dgvApplications.CellDoubleClick += dgvApplications_CellDoubleClick;
            dgvApplications.SelectionChanged += dgvApplications_SelectionChanged;
            // 
            // grpApplicantDetails
            // 
            grpApplicantDetails.Controls.Add(lblRemarks);
            grpApplicantDetails.Controls.Add(lblSkills);
            grpApplicantDetails.Controls.Add(lblAppliedDate);
            grpApplicantDetails.Controls.Add(lblPositionApplied);
            grpApplicantDetails.Controls.Add(lblEmail);
            grpApplicantDetails.Controls.Add(lblCGPA);
            grpApplicantDetails.Controls.Add(lblStudentID);
            grpApplicantDetails.Controls.Add(lblContact);
            grpApplicantDetails.Controls.Add(lblProgram);
            grpApplicantDetails.Controls.Add(lblStudent);
            grpApplicantDetails.Location = new Point(26, 297);
            grpApplicantDetails.Name = "grpApplicantDetails";
            grpApplicantDetails.Size = new Size(673, 271);
            grpApplicantDetails.TabIndex = 6;
            grpApplicantDetails.TabStop = false;
            grpApplicantDetails.Text = "Selected Applicant Details";
            // 
            // lblRemarks
            // 
            lblRemarks.AutoSize = true;
            lblRemarks.Location = new Point(15, 223);
            lblRemarks.Name = "lblRemarks";
            lblRemarks.Size = new Size(68, 20);
            lblRemarks.TabIndex = 11;
            lblRemarks.Text = "Remarks:";
            // 
            // lblSkills
            // 
            lblSkills.AutoSize = true;
            lblSkills.Location = new Point(15, 193);
            lblSkills.Name = "lblSkills";
            lblSkills.Size = new Size(45, 20);
            lblSkills.TabIndex = 10;
            lblSkills.Text = "Skills:";
            // 
            // lblAppliedDate
            // 
            lblAppliedDate.AutoSize = true;
            lblAppliedDate.Location = new Point(15, 163);
            lblAppliedDate.Name = "lblAppliedDate";
            lblAppliedDate.Size = new Size(101, 20);
            lblAppliedDate.TabIndex = 9;
            lblAppliedDate.Text = "Applied Date:";
            // 
            // lblPositionApplied
            // 
            lblPositionApplied.AutoSize = true;
            lblPositionApplied.Location = new Point(15, 133);
            lblPositionApplied.Name = "lblPositionApplied";
            lblPositionApplied.Size = new Size(121, 20);
            lblPositionApplied.TabIndex = 8;
            lblPositionApplied.Text = "Position Applied:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(343, 93);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email:";
            // 
            // lblCGPA
            // 
            lblCGPA.AutoSize = true;
            lblCGPA.Location = new Point(342, 63);
            lblCGPA.Name = "lblCGPA";
            lblCGPA.Size = new Size(48, 20);
            lblCGPA.TabIndex = 7;
            lblCGPA.Text = "CGPA:";
            // 
            // lblStudentID
            // 
            lblStudentID.AutoSize = true;
            lblStudentID.Location = new Point(342, 32);
            lblStudentID.Name = "lblStudentID";
            lblStudentID.Size = new Size(82, 20);
            lblStudentID.TabIndex = 7;
            lblStudentID.Text = "Student ID:";
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(15, 93);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(63, 20);
            lblContact.TabIndex = 7;
            lblContact.Text = "Contact:";
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Location = new Point(15, 63);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(69, 20);
            lblProgram.TabIndex = 1;
            lblProgram.Text = "Program:";
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Location = new Point(15, 33);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(63, 20);
            lblStudent.TabIndex = 0;
            lblStudent.Text = "Student:";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(26, 588);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(136, 29);
            btnAccept.TabIndex = 7;
            btnAccept.Text = "Accept Applicant";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(168, 588);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(136, 29);
            btnReject.TabIndex = 8;
            btnReject.Text = "Reject Applicant";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(310, 588);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(136, 29);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(563, 588);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(136, 29);
            btnBack.TabIndex = 10;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // frmReviewApplications
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 663);
            Controls.Add(btnBack);
            Controls.Add(btnRefresh);
            Controls.Add(btnReject);
            Controls.Add(btnAccept);
            Controls.Add(grpApplicantDetails);
            Controls.Add(dgvApplications);
            Controls.Add(cboPositionFilter);
            Controls.Add(lblPositionFilter);
            Controls.Add(lblStatusFilter);
            Controls.Add(cboStatusFilter);
            Controls.Add(lblCompanyName);
            Name = "frmReviewApplications";
            Text = "Review Applications";
            Load += frmReviewApplications_Load;
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            grpApplicantDetails.ResumeLayout(false);
            grpApplicantDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCompanyName;
        private ComboBox cboStatusFilter;
        private Label lblStatusFilter;
        private Label lblPositionFilter;
        private ComboBox cboPositionFilter;
        private DataGridView dgvApplications;
        private GroupBox grpApplicantDetails;
        private Label lblStudent;
        private Label lblSkills;
        private Label lblAppliedDate;
        private Label lblPositionApplied;
        private Label lblEmail;
        private Label lblCGPA;
        private Label lblStudentID;
        private Label lblContact;
        private Label lblProgram;
        private Label lblRemarks;
        private Button btnAccept;
        private Button btnReject;
        private Button btnRefresh;
        private Button btnBack;
    }
}