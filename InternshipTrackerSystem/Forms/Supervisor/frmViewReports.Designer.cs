namespace InternshipTrackerSystem.Forms.Supervisor
{
    partial class frmViewReports
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
            cmbStatus = new ComboBox();
            dgvReports = new DataGridView();
            databaseHelperBindingSource = new BindingSource(components);
            btnApprove = new Button();
            btnReject = new Button();
            btnRefresh = new Button();
            lblFilter = new Label();
            btnLoad = new Button();
            btnViewContents = new Button();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseHelperBindingSource).BeginInit();
            SuspendLayout();
            // 
            // cmbStatus
            // 
            cmbStatus.Font = new Font("Segoe UI", 10F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "All", "Submitted", "Approved", "Rejected" });
            cmbStatus.Location = new Point(90, 16);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(130, 31);
            cmbStatus.TabIndex = 0;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // dgvReports
            // 
            dgvReports.AllowUserToAddRows = false;
            dgvReports.AllowUserToDeleteRows = false;
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(30, 70);
            dgvReports.Name = "dgvReports";
            dgvReports.ReadOnly = true;
            dgvReports.RowHeadersWidth = 51;
            dgvReports.Size = new Size(553, 188);
            dgvReports.TabIndex = 1;
            dgvReports.CellDoubleClick += dgvReports_CellDoubleClick;
            dgvReports.CellFormatting += dgvReports_CellFormatting;
            dgvReports.SelectionChanged += dgvReports_SelectionChanged;
            // 
            // databaseHelperBindingSource
            // 
            databaseHelperBindingSource.DataSource = typeof(Data.DatabaseHelper);
            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(150, 300);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(115, 30);
            btnApprove.TabIndex = 3;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = true;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(270, 300);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(115, 30);
            btnReject.TabIndex = 3;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(490, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Font = new Font("Segoe UI", 10F);
            lblFilter.Location = new Point(30, 20);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(51, 23);
            lblFilter.TabIndex = 4;
            lblFilter.Text = "Filter:";
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(390, 20);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnViewContents
            // 
            btnViewContents.Location = new Point(30, 300);
            btnViewContents.Name = "btnViewContents";
            btnViewContents.Size = new Size(115, 30);
            btnViewContents.TabIndex = 6;
            btnViewContents.Text = "View Contents";
            btnViewContents.UseVisualStyleBackColor = true;
            btnViewContents.Click += btnViewContents_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.Location = new Point(30, 270);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(56, 23);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Status";
            // 
            // frmViewReports
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 353);
            Controls.Add(lblStatus);
            Controls.Add(btnViewContents);
            Controls.Add(btnLoad);
            Controls.Add(lblFilter);
            Controls.Add(btnRefresh);
            Controls.Add(btnReject);
            Controls.Add(btnApprove);
            Controls.Add(dgvReports);
            Controls.Add(cmbStatus);
            Name = "frmViewReports";
            Text = "Student Reports";
            Load += frmViewReports_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseHelperBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbStatus;
        private DataGridView dgvReports;
        private Button btnApprove;
        private Button btnReject;
        private Button btnRefresh;
        private BindingSource databaseHelperBindingSource;
        private Label lblFilter;
        private Button btnLoad;
        private Button btnViewContents;
        private Label lblStatus;
    }
}