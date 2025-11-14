namespace InternshipTrackerSystem.Forms.Admin
{
    partial class frmAdminMain
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
            dgvUsers = new DataGridView();
            btnManageUsers = new Button();
            btnLogout = new Button();
            btnManageCompanies = new Button();
            btnViewReport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblTitle.Location = new Point(395, 29);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(220, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Admin Dashboard";
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(0, 87);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.Size = new Size(1020, 489);
            dgvUsers.TabIndex = 1;
            // 
            // btnManageUsers
            // 
            btnManageUsers.Location = new Point(83, 582);
            btnManageUsers.Name = "btnManageUsers";
            btnManageUsers.Size = new Size(147, 34);
            btnManageUsers.TabIndex = 2;
            btnManageUsers.Text = "Manage Users";
            btnManageUsers.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(827, 582);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnManageCompanies
            // 
            btnManageCompanies.Location = new Point(506, 582);
            btnManageCompanies.Name = "btnManageCompanies";
            btnManageCompanies.Size = new Size(195, 34);
            btnManageCompanies.TabIndex = 8;
            btnManageCompanies.Text = "Manage Companies";
            btnManageCompanies.UseVisualStyleBackColor = true;
            // 
            // btnViewReport
            // 
            btnViewReport.Location = new Point(292, 582);
            btnViewReport.Name = "btnViewReport";
            btnViewReport.Size = new Size(154, 34);
            btnViewReport.TabIndex = 9;
            btnViewReport.Text = "View Reports";
            btnViewReport.UseVisualStyleBackColor = true;
            btnViewReport.Click += btnViewReports_Click;
            // 
            // frmAdminMain
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 628);
            Controls.Add(btnViewReport);
            Controls.Add(btnManageCompanies);
            Controls.Add(btnLogout);
            Controls.Add(btnManageUsers);
            Controls.Add(dgvUsers);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmAdminMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvUsers;
        private Button btnManageUsers;
        private Button btnLogout;
        private Button btnManageCompanies;
        private Button btnViewReport;
    }
}