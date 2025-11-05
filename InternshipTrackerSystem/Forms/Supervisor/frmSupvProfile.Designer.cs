namespace InternshipTrackerSystem
{
    partial class frmSupvProfile
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            lblDepartment = new Label();
            lblContactNumber = new Label();
            lblSpecialization = new Label();
            txtName = new TextBox();
            txtDepartment = new TextBox();
            txtContacts = new TextBox();
            txtSpecialization = new TextBox();
            btnBack = new Button();
            Email = new Label();
            btnUpdate = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lblEmail = new Label();
            lblSupervisorId = new Label();
            lblUsername = new Label();
            lblUserRole = new Label();
            lblCreatedDate = new Label();
            lblStatus = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F);
            lblName.Location = new Point(20, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(65, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Name: ";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 10F);
            lblDepartment.Location = new Point(20, 65);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(106, 23);
            lblDepartment.TabIndex = 1;
            lblDepartment.Text = "Department:";
            // 
            // lblContactNumber
            // 
            lblContactNumber.AutoSize = true;
            lblContactNumber.Font = new Font("Segoe UI", 10F);
            lblContactNumber.Location = new Point(20, 100);
            lblContactNumber.Name = "lblContactNumber";
            lblContactNumber.Size = new Size(142, 23);
            lblContactNumber.TabIndex = 2;
            lblContactNumber.Text = "Contact Number:";
            // 
            // lblSpecialization
            // 
            lblSpecialization.AutoSize = true;
            lblSpecialization.Font = new Font("Segoe UI", 10F);
            lblSpecialization.Location = new Point(20, 135);
            lblSpecialization.Name = "lblSpecialization";
            lblSpecialization.Size = new Size(118, 23);
            lblSpecialization.TabIndex = 3;
            lblSpecialization.Text = "Specialization:";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 9F);
            txtName.Location = new Point(160, 30);
            txtName.Name = "txtName";
            txtName.Size = new Size(220, 27);
            txtName.TabIndex = 4;
            // 
            // txtDepartment
            // 
            txtDepartment.Font = new Font("Segoe UI", 9F);
            txtDepartment.Location = new Point(160, 65);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(220, 27);
            txtDepartment.TabIndex = 4;
            // 
            // txtContacts
            // 
            txtContacts.Font = new Font("Segoe UI", 9F);
            txtContacts.Location = new Point(160, 100);
            txtContacts.Name = "txtContacts";
            txtContacts.Size = new Size(220, 27);
            txtContacts.TabIndex = 4;
            txtContacts.TextChanged += txtContacts_TextChanged;
            txtContacts.Leave += txtContacts_Leave;
            txtContacts.Validating += txtContacts_Validating;
            // 
            // txtSpecialization
            // 
            txtSpecialization.Font = new Font("Segoe UI", 9F);
            txtSpecialization.Location = new Point(160, 135);
            txtSpecialization.Name = "txtSpecialization";
            txtSpecialization.Size = new Size(220, 27);
            txtSpecialization.TabIndex = 4;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(30, 430);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 6;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Font = new Font("Segoe UI", 10F);
            Email.Location = new Point(20, 90);
            Email.Name = "Email";
            Email.Size = new Size(55, 23);
            Email.TabIndex = 3;
            Email.Text = "Email:";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(150, 430);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 30);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(270, 430);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(20, 30);
            label1.Name = "label1";
            label1.Size = new Size(115, 23);
            label1.TabIndex = 9;
            label1.Text = "Supervisor ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(20, 60);
            label2.Name = "label2";
            label2.Size = new Size(91, 23);
            label2.TabIndex = 10;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(20, 120);
            label3.Name = "label3";
            label3.Size = new Size(86, 23);
            label3.TabIndex = 11;
            label3.Text = "User Role:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(20, 150);
            label4.Name = "label4";
            label4.Size = new Size(115, 23);
            label4.TabIndex = 12;
            label4.Text = "Created Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(20, 180);
            label5.Name = "label5";
            label5.Size = new Size(60, 23);
            label5.TabIndex = 13;
            label5.Text = "Status:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.Location = new Point(150, 90);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(0, 20);
            lblEmail.TabIndex = 3;
            // 
            // lblSupervisorId
            // 
            lblSupervisorId.AutoSize = true;
            lblSupervisorId.Font = new Font("Segoe UI", 9F);
            lblSupervisorId.Location = new Point(150, 30);
            lblSupervisorId.Name = "lblSupervisorId";
            lblSupervisorId.Size = new Size(0, 20);
            lblSupervisorId.TabIndex = 9;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F);
            lblUsername.Location = new Point(150, 60);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(0, 20);
            lblUsername.TabIndex = 10;
            // 
            // lblUserRole
            // 
            lblUserRole.AutoSize = true;
            lblUserRole.Font = new Font("Segoe UI", 9F);
            lblUserRole.Location = new Point(150, 120);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(0, 20);
            lblUserRole.TabIndex = 11;
            // 
            // lblCreatedDate
            // 
            lblCreatedDate.AutoSize = true;
            lblCreatedDate.Font = new Font("Segoe UI", 9F);
            lblCreatedDate.Location = new Point(150, 150);
            lblCreatedDate.Name = "lblCreatedDate";
            lblCreatedDate.Size = new Size(0, 20);
            lblCreatedDate.TabIndex = 12;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Location = new Point(150, 180);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 20);
            lblStatus.TabIndex = 13;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lblStatus);
            groupBox1.Controls.Add(Email);
            groupBox1.Controls.Add(lblCreatedDate);
            groupBox1.Controls.Add(lblEmail);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblUserRole);
            groupBox1.Controls.Add(lblSupervisorId);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblUsername);
            groupBox1.Font = new Font("Segoe UI", 10F);
            groupBox1.Location = new Point(30, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 220);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Account Information (Read-only)";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblName);
            groupBox2.Controls.Add(lblDepartment);
            groupBox2.Controls.Add(lblContactNumber);
            groupBox2.Controls.Add(lblSpecialization);
            groupBox2.Controls.Add(txtSpecialization);
            groupBox2.Controls.Add(txtName);
            groupBox2.Controls.Add(txtContacts);
            groupBox2.Controls.Add(txtDepartment);
            groupBox2.Font = new Font("Segoe UI", 10F);
            groupBox2.Location = new Point(30, 248);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(400, 170);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Account Information (Editable)";
            // 
            // frmSupvProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 483);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdate);
            Controls.Add(btnBack);
            Name = "frmSupvProfile";
            Text = "Supervisor Profile";
            FormClosing += frmSupvProfile_FormClosing;
            Load += frmSupvProfile_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblName;
        private Label lblDepartment;
        private Label lblContactNumber;
        private Label lblSpecialization;
        private TextBox txtName;
        private TextBox txtDepartment;
        private TextBox txtContacts;
        private TextBox txtSpecialization;
        private Button btnBack;
        private Label Email;
        private Button btnUpdate;
        private Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblEmail;
        private Label lblSupervisorId;
        private Label lblUsername;
        private Label lblUserRole;
        private Label lblCreatedDate;
        private Label lblStatus;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}
