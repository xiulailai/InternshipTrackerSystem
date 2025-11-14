namespace InternshipTrackerSystem.Forms.Student_Lai
{
    partial class frmStudentProfile
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
            lblStudentID = new Label();
            txtStudentID = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblProgram = new Label();
            txtProgram = new TextBox();
            lblContact = new Label();
            txtContact = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblGPA = new Label();
            txtGPA = new TextBox();
            lblSkills = new Label();
            txtSkills = new TextBox();
            lblResume = new Label();
            txtResumePath = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(16, 14);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(880, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "STUDENT PROFILE";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStudentID
            // 
            lblStudentID.AutoSize = true;
            lblStudentID.Font = new Font("Segoe UI", 10F);
            lblStudentID.Location = new Point(40, 108);
            lblStudentID.Margin = new Padding(4, 0, 4, 0);
            lblStudentID.Name = "lblStudentID";
            lblStudentID.Size = new Size(163, 23);
            lblStudentID.TabIndex = 1;
            lblStudentID.Text = "Student ID Number:";
            // 
            // txtStudentID
            // 
            txtStudentID.Font = new Font("Segoe UI", 10F);
            txtStudentID.Location = new Point(267, 103);
            txtStudentID.Margin = new Padding(4, 5, 4, 5);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.ReadOnly = true;
            txtStudentID.Size = new Size(332, 30);
            txtStudentID.TabIndex = 2;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10F);
            lblFullName.Location = new Point(40, 169);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(91, 23);
            lblFullName.TabIndex = 3;
            lblFullName.Text = "Full Name:";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(267, 165);
            txtFullName.Margin = new Padding(4, 5, 4, 5);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(532, 30);
            txtFullName.TabIndex = 4;
            // 
            // lblProgram
            // 
            lblProgram.AutoSize = true;
            lblProgram.Font = new Font("Segoe UI", 10F);
            lblProgram.Location = new Point(40, 231);
            lblProgram.Margin = new Padding(4, 0, 4, 0);
            lblProgram.Name = "lblProgram";
            lblProgram.Size = new Size(80, 23);
            lblProgram.TabIndex = 5;
            lblProgram.Text = "Program:";
            // 
            // txtProgram
            // 
            txtProgram.Font = new Font("Segoe UI", 10F);
            txtProgram.Location = new Point(267, 226);
            txtProgram.Margin = new Padding(4, 5, 4, 5);
            txtProgram.Name = "txtProgram";
            txtProgram.Size = new Size(532, 30);
            txtProgram.TabIndex = 6;
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Font = new Font("Segoe UI", 10F);
            lblContact.Location = new Point(40, 292);
            lblContact.Margin = new Padding(4, 0, 4, 0);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(142, 23);
            lblContact.TabIndex = 7;
            lblContact.Text = "Contact Number:";
            // 
            // txtContact
            // 
            txtContact.Font = new Font("Segoe UI", 10F);
            txtContact.Location = new Point(267, 288);
            txtContact.Margin = new Padding(4, 5, 4, 5);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(332, 30);
            txtContact.TabIndex = 8;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 10F);
            lblAddress.Location = new Point(40, 354);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(74, 23);
            lblAddress.TabIndex = 9;
            lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(267, 349);
            txtAddress.Margin = new Padding(4, 5, 4, 5);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(532, 90);
            txtAddress.TabIndex = 10;
            // 
            // lblGPA
            // 
            lblGPA.AutoSize = true;
            lblGPA.Font = new Font("Segoe UI", 10F);
            lblGPA.Location = new Point(40, 477);
            lblGPA.Margin = new Padding(4, 0, 4, 0);
            lblGPA.Name = "lblGPA";
            lblGPA.Size = new Size(46, 23);
            lblGPA.TabIndex = 11;
            lblGPA.Text = "GPA:";
            // 
            // txtGPA
            // 
            txtGPA.Font = new Font("Segoe UI", 10F);
            txtGPA.Location = new Point(267, 472);
            txtGPA.Margin = new Padding(4, 5, 4, 5);
            txtGPA.Name = "txtGPA";
            txtGPA.Size = new Size(132, 30);
            txtGPA.TabIndex = 12;
            // 
            // lblSkills
            // 
            lblSkills.AutoSize = true;
            lblSkills.Font = new Font("Segoe UI", 10F);
            lblSkills.Location = new Point(40, 538);
            lblSkills.Margin = new Padding(4, 0, 4, 0);
            lblSkills.Name = "lblSkills";
            lblSkills.Size = new Size(50, 23);
            lblSkills.TabIndex = 13;
            lblSkills.Text = "Skills:";
            // 
            // txtSkills
            // 
            txtSkills.Font = new Font("Segoe UI", 10F);
            txtSkills.Location = new Point(267, 534);
            txtSkills.Margin = new Padding(4, 5, 4, 5);
            txtSkills.Name = "txtSkills";
            txtSkills.Size = new Size(532, 30);
            txtSkills.TabIndex = 14;
            // 
            // lblResume
            // 
            lblResume.AutoSize = true;
            lblResume.Font = new Font("Segoe UI", 10F);
            lblResume.Location = new Point(40, 600);
            lblResume.Margin = new Padding(4, 0, 4, 0);
            lblResume.Name = "lblResume";
            lblResume.Size = new Size(74, 23);
            lblResume.TabIndex = 15;
            lblResume.Text = "Resume:";
            // 
            // txtResumePath
            // 
            txtResumePath.Font = new Font("Segoe UI", 10F);
            txtResumePath.Location = new Point(267, 595);
            txtResumePath.Margin = new Padding(4, 5, 4, 5);
            txtResumePath.Name = "txtResumePath";
            txtResumePath.ReadOnly = true;
            txtResumePath.Size = new Size(332, 30);
            txtResumePath.TabIndex = 16;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(40, 662);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(55, 23);
            lblEmail.TabIndex = 19;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(267, 657);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(532, 30);
            txtEmail.TabIndex = 20;
            // 
            // frmStudentProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 753);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtResumePath);
            Controls.Add(lblResume);
            Controls.Add(txtSkills);
            Controls.Add(lblSkills);
            Controls.Add(txtGPA);
            Controls.Add(lblGPA);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtContact);
            Controls.Add(lblContact);
            Controls.Add(txtProgram);
            Controls.Add(lblProgram);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(txtStudentID);
            Controls.Add(lblStudentID);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmStudentProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Profile";
            FormClosed += frmStudentProfile_FormClosed;
            Load += frmStudentProfile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblProgram;
        private System.Windows.Forms.TextBox txtProgram;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblGPA;
        private System.Windows.Forms.TextBox txtGPA;
        private System.Windows.Forms.Label lblSkills;
        private System.Windows.Forms.TextBox txtSkills;
        private System.Windows.Forms.Label lblResume;
        private System.Windows.Forms.TextBox txtResumePath;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
    }

    #endregion
}
