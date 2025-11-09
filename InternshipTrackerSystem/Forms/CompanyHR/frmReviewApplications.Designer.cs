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
            label1 = new Label();
            label2 = new Label();
            cboPositionFilter = new ComboBox();
            dgvApplications = new DataGridView();
            groupBox1 = new GroupBox();
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
            groupBox1.SuspendLayout();
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
            cboStatusFilter.Size = new Size(151, 28);
            cboStatusFilter.TabIndex = 1;
            cboStatusFilter.SelectedIndexChanged += cboStatusFilter_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 46);
            label1.Name = "label1";
            label1.Size = new Size(190, 20);
            label1.TabIndex = 2;
            label1.Text = "Filter by Application Status:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(268, 46);
            label2.Name = "label2";
            label2.Size = new Size(148, 20);
            label2.TabIndex = 3;
            label2.Text = "Filter by Job Position:";
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
            // groupBox1
            // 
            groupBox1.Controls.Add(lblRemarks);
            groupBox1.Controls.Add(lblSkills);
            groupBox1.Controls.Add(lblAppliedDate);
            groupBox1.Controls.Add(lblPositionApplied);
            groupBox1.Controls.Add(lblEmail);
            groupBox1.Controls.Add(lblCGPA);
            groupBox1.Controls.Add(lblStudentID);
            groupBox1.Controls.Add(lblContact);
            groupBox1.Controls.Add(lblProgram);
            groupBox1.Controls.Add(lblStudent);
            groupBox1.Location = new Point(26, 297);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(673, 271);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selected Applicant Details";
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
            lblSkills.Location = new Point(15, 194);
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
            lblEmail.Location = new Point(342, 94);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email:";
            // 
            // lblCGPA
            // 
            lblCGPA.AutoSize = true;
            lblCGPA.Location = new Point(343, 63);
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
            lblContact.Location = new Point(15, 94);
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
            lblStudent.Location = new Point(15, 32);
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
            btnReject.Location = new Point(212, 588);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(136, 29);
            btnReject.TabIndex = 8;
            btnReject.Text = "Reject Applicant";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(385, 588);
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
            Controls.Add(groupBox1);
            Controls.Add(dgvApplications);
            Controls.Add(cboPositionFilter);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboStatusFilter);
            Controls.Add(lblCompanyName);
            Name = "frmReviewApplications";
            Text = "Review Applications";
            Load += frmReviewApplications_Load;
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCompanyName;
        private ComboBox cboStatusFilter;
        private Label label1;
        private Label label2;
        private ComboBox cboPositionFilter;
        private DataGridView dgvApplications;
        private GroupBox groupBox1;
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