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
            lblCompany = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            comboBox2 = new ComboBox();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            lblSkills = new Label();
            lblAppliedDate = new Label();
            lblPositionApplied = new Label();
            label3 = new Label();
            lblCGPA = new Label();
            lblStudentID = new Label();
            lblContact = new Label();
            lblProgram = new Label();
            lblStudent = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblCompany
            // 
            lblCompany.AutoSize = true;
            lblCompany.Location = new Point(26, 25);
            lblCompany.Name = "lblCompany";
            lblCompany.Size = new Size(75, 20);
            lblCompany.TabIndex = 0;
            lblCompany.Text = "Company:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(26, 99);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 76);
            label1.Name = "label1";
            label1.Size = new Size(190, 20);
            label1.TabIndex = 2;
            label1.Text = "Filter by Application Status:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(268, 76);
            label2.Name = "label2";
            label2.Size = new Size(148, 20);
            label2.TabIndex = 3;
            label2.Text = "Filter by Job Position:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(268, 99);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(26, 149);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(476, 188);
            dataGridView1.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblSkills);
            groupBox1.Controls.Add(lblAppliedDate);
            groupBox1.Controls.Add(lblPositionApplied);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblCGPA);
            groupBox1.Controls.Add(lblStudentID);
            groupBox1.Controls.Add(lblContact);
            groupBox1.Controls.Add(lblProgram);
            groupBox1.Controls.Add(lblStudent);
            groupBox1.Location = new Point(26, 353);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(476, 228);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Selected Applicant Details";
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(242, 94);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 7;
            label3.Text = "Email:";
            // 
            // lblCGPA
            // 
            lblCGPA.AutoSize = true;
            lblCGPA.Location = new Point(242, 63);
            lblCGPA.Name = "lblCGPA";
            lblCGPA.Size = new Size(48, 20);
            lblCGPA.TabIndex = 7;
            lblCGPA.Text = "CGPA:";
            // 
            // lblStudentID
            // 
            lblStudentID.AutoSize = true;
            lblStudentID.Location = new Point(242, 32);
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
            // frmReviewApplications
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 717);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(lblCompany);
            Name = "frmReviewApplications";
            Text = "Review Applications";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCompany;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private ComboBox comboBox2;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Label lblStudent;
        private Label lblSkills;
        private Label lblAppliedDate;
        private Label lblPositionApplied;
        private Label label3;
        private Label lblCGPA;
        private Label lblStudentID;
        private Label lblContact;
        private Label lblProgram;
    }
}