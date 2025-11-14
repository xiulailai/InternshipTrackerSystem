namespace InternshipTrackerSystem.Forms.Student_Lai
{
    partial class frmStudentApplication
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
            lblFilterStatus = new Label();
            cmbFilterStatus = new ComboBox();
            btnRefresh = new Button();
            dgvApplications = new DataGridView();
            colTitle = new DataGridViewTextBoxColumn();
            colCompany = new DataGridViewTextBoxColumn();
            colDateApplied = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colActions = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(16, 14);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1280, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MY INTERNSHIP APPLICATIONS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFilterStatus
            // 
            lblFilterStatus.AutoSize = true;
            lblFilterStatus.Font = new Font("Segoe UI", 10F);
            lblFilterStatus.Location = new Point(40, 108);
            lblFilterStatus.Margin = new Padding(4, 0, 4, 0);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Size = new Size(102, 23);
            lblFilterStatus.TabIndex = 1;
            lblFilterStatus.Text = "Filter Status:";
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.Font = new Font("Segoe UI", 10F);
            cmbFilterStatus.FormattingEnabled = true;
            cmbFilterStatus.Items.AddRange(new object[] { "All", "Pending", "Approved", "Rejected", "Withdrawn" });
            cmbFilterStatus.Location = new Point(168, 103);
            cmbFilterStatus.Margin = new Padding(4, 5, 4, 5);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(199, 31);
            cmbFilterStatus.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 10F);
            btnRefresh.Location = new Point(400, 97);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(133, 49);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dgvApplications
            // 
            dgvApplications.AllowUserToAddRows = false;
            dgvApplications.AllowUserToDeleteRows = false;
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplications.Columns.AddRange(new DataGridViewColumn[] { colTitle, colCompany, colDateApplied, colStatus, colActions });
            dgvApplications.Location = new Point(40, 185);
            dgvApplications.Margin = new Padding(4, 5, 4, 5);
            dgvApplications.Name = "dgvApplications";
            dgvApplications.ReadOnly = true;
            dgvApplications.RowHeadersVisible = false;
            dgvApplications.RowHeadersWidth = 51;
            dgvApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApplications.Size = new Size(1227, 646);
            dgvApplications.TabIndex = 4;
            // 
            // colTitle
            // 
            colTitle.HeaderText = "Title";
            colTitle.MinimumWidth = 6;
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            // 
            // colCompany
            // 
            colCompany.HeaderText = "Company";
            colCompany.MinimumWidth = 6;
            colCompany.Name = "colCompany";
            colCompany.ReadOnly = true;
            // 
            // colDateApplied
            // 
            colDateApplied.HeaderText = "Date Applied";
            colDateApplied.MinimumWidth = 6;
            colDateApplied.Name = "colDateApplied";
            colDateApplied.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colActions
            // 
            colActions.FillWeight = 60F;
            colActions.HeaderText = "Actions";
            colActions.MinimumWidth = 6;
            colActions.Name = "colActions";
            colActions.ReadOnly = true;
            colActions.Text = "View";
            colActions.UseColumnTextForButtonValue = true;
            // 
            // frmStudentApplication
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1312, 863);
            Controls.Add(dgvApplications);
            Controls.Add(btnRefresh);
            Controls.Add(cmbFilterStatus);
            Controls.Add(lblFilterStatus);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmStudentApplication";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "My Applications";
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateApplied;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colActions;
    }

    #endregion
}
