namespace InternshipTrackerSystem.Forms.Admin
{
    partial class frmManageCompanies
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
            lblCompaniesTitle = new Label();
            dgvCompanies = new DataGridView();
            btnAddCompany = new Button();
            btnEditCompany = new Button();
            btnDeleteCompany = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCompanies).BeginInit();
            SuspendLayout();
            // 
            // lblCompaniesTitle
            // 
            lblCompaniesTitle.AutoSize = true;
            lblCompaniesTitle.Location = new Point(293, 9);
            lblCompaniesTitle.Name = "lblCompaniesTitle";
            lblCompaniesTitle.Size = new Size(182, 24);
            lblCompaniesTitle.TabIndex = 0;
            lblCompaniesTitle.Text = "Manage Companies";
            // 
            // dgvCompanies
            // 
            dgvCompanies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompanies.Location = new Point(12, 51);
            dgvCompanies.Name = "dgvCompanies";
            dgvCompanies.RowHeadersWidth = 62;
            dgvCompanies.Size = new Size(776, 337);
            dgvCompanies.TabIndex = 1;
            // 
            // btnAddCompany
            // 
            btnAddCompany.Location = new Point(62, 406);
            btnAddCompany.Name = "btnAddCompany";
            btnAddCompany.Size = new Size(112, 34);
            btnAddCompany.TabIndex = 2;
            btnAddCompany.Text = "Add";
            btnAddCompany.UseVisualStyleBackColor = true;
            btnAddCompany.Click += btnAddCompany_Click;
            // 
            // btnEditCompany
            // 
            btnEditCompany.Location = new Point(243, 406);
            btnEditCompany.Name = "btnEditCompany";
            btnEditCompany.Size = new Size(112, 34);
            btnEditCompany.TabIndex = 3;
            btnEditCompany.Text = "Edit";
            btnEditCompany.UseVisualStyleBackColor = true;

            // 
            // btnDeleteCompany
            // 
            btnDeleteCompany.Location = new Point(421, 406);
            btnDeleteCompany.Name = "btnDeleteCompany";
            btnDeleteCompany.Size = new Size(112, 34);
            btnDeleteCompany.TabIndex = 4;
            btnDeleteCompany.Text = "Delete";
            btnDeleteCompany.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(604, 406);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // frmManageCompanies
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(btnDeleteCompany);
            Controls.Add(btnEditCompany);
            Controls.Add(btnAddCompany);
            Controls.Add(dgvCompanies);
            Controls.Add(lblCompaniesTitle);
            Name = "frmManageCompanies";
            Text = "frmManageCompanies";
            ((System.ComponentModel.ISupportInitialize)dgvCompanies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCompaniesTitle;
        private DataGridView dgvCompanies;
        private Button btnAddCompany;
        private Button btnEditCompany;
        private Button btnDeleteCompany;
        private Button btnBack;
    }
}