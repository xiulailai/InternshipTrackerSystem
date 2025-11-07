namespace InternshipTrackerSystem.Forms.Supervisor
{
    partial class frmViewInterns
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
            components = new System.ComponentModel.Container();
            databaseHelperBindingSource = new BindingSource(components);
            dgvInterns = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnViewDetails = new Button();
            label1 = new Label();
            btnEvaluate = new Button();
            btnReports = new Button();
            btnRefresh = new Button();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)databaseHelperBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInterns).BeginInit();
            SuspendLayout();
            // 
            // databaseHelperBindingSource
            // 
            databaseHelperBindingSource.DataSource = typeof(Data.DatabaseHelper);
            // 
            // dgvInterns
            // 
            dgvInterns.AllowUserToAddRows = false;
            dgvInterns.AllowUserToDeleteRows = false;
            dgvInterns.AutoGenerateColumns = false;
            dgvInterns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInterns.DataSource = databaseHelperBindingSource;
            dgvInterns.Location = new Point(30, 70);
            dgvInterns.Name = "dgvInterns";
            dgvInterns.ReadOnly = true;
            dgvInterns.RowHeadersWidth = 51;
            dgvInterns.Size = new Size(553, 188);
            dgvInterns.TabIndex = 0;
            dgvInterns.CellFormatting += dgvInterns_CellFormatting;
            dgvInterns.SelectionChanged += dgvInterns_SelectionChanged;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10.2F);
            txtSearch.Location = new Point(170, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 30);
            txtSearch.TabIndex = 1;
            txtSearch.KeyPress += txtSearch_KeyPress;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(390, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnViewDetails
            // 
            btnViewDetails.Location = new Point(30, 300);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(115, 30);
            btnViewDetails.TabIndex = 2;
            btnViewDetails.Text = "View Details";
            btnViewDetails.UseVisualStyleBackColor = true;
            btnViewDetails.Click += btnViewDetails_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F);
            label1.Location = new Point(30, 20);
            label1.Name = "label1";
            label1.Size = new Size(129, 23);
            label1.TabIndex = 3;
            label1.Text = "Search Student:";
            // 
            // btnEvaluate
            // 
            btnEvaluate.Location = new Point(150, 300);
            btnEvaluate.Name = "btnEvaluate";
            btnEvaluate.Size = new Size(115, 30);
            btnEvaluate.TabIndex = 2;
            btnEvaluate.Text = "Evaluate";
            btnEvaluate.UseVisualStyleBackColor = true;
            btnEvaluate.Click += btnEvaluate_Click;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(270, 300);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(115, 30);
            btnReports.TabIndex = 2;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(490, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10.2F);
            lblStatus.Location = new Point(30, 270);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(56, 23);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status";
            // 
            // frmViewInterns
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 353);
            Controls.Add(lblStatus);
            Controls.Add(btnRefresh);
            Controls.Add(label1);
            Controls.Add(btnReports);
            Controls.Add(btnEvaluate);
            Controls.Add(btnViewDetails);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvInterns);
            Name = "frmViewInterns";
            Text = "View Assigned Interns";
            Load += frmViewInterns_Load;
            ((System.ComponentModel.ISupportInitialize)databaseHelperBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInterns).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Data.SqlClient.SqlDataAdapter npgsqlDataAdapter1;
        private BindingSource databaseHelperBindingSource;
        private DataGridView dgvInterns;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnViewDetails;
        private Label label1;
        private Button btnEvaluate;
        private Button btnReports;
        private Button btnRefresh;
        private Label lblStatus;
    }
}