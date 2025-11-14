namespace InternshipTrackerSystem.Forms.Student_Lai
{
    partial class frmReportList
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
            lblStatusFilter = new Label();
            cmbStatusFilter = new ComboBox();
            btnRefresh = new Button();
            dgvReports = new DataGridView();
            colType = new DataGridViewTextBoxColumn();
            colCompany = new DataGridViewTextBoxColumn();
            colPosition = new DataGridViewTextBoxColumn();
            colSubmittedOn = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colAction = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(16, 14);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1413, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MY REPORTS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatusFilter
            // 
            lblStatusFilter.AutoSize = true;
            lblStatusFilter.Font = new Font("Segoe UI", 10F);
            lblStatusFilter.Location = new Point(40, 108);
            lblStatusFilter.Margin = new Padding(4, 0, 4, 0);
            lblStatusFilter.Name = "lblStatusFilter";
            lblStatusFilter.Size = new Size(102, 23);
            lblStatusFilter.TabIndex = 1;
            lblStatusFilter.Text = "Status Filter:";
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Font = new Font("Segoe UI", 10F);
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Items.AddRange(new object[] { "All", "Submitted", "Approved", "Rejected" });
            cmbStatusFilter.Location = new Point(168, 103);
            cmbStatusFilter.Margin = new Padding(4, 5, 4, 5);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(199, 31);
            cmbStatusFilter.TabIndex = 2;
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
            // dgvReports
            // 
            dgvReports.AllowUserToAddRows = false;
            dgvReports.AllowUserToDeleteRows = false;
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Columns.AddRange(new DataGridViewColumn[] { colType, colCompany, colPosition, colSubmittedOn, colStatus, colAction });
            dgvReports.Location = new Point(40, 185);
            dgvReports.Margin = new Padding(4, 5, 4, 5);
            dgvReports.Name = "dgvReports";
            dgvReports.ReadOnly = true;
            dgvReports.RowHeadersVisible = false;
            dgvReports.RowHeadersWidth = 51;
            dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReports.Size = new Size(1360, 646);
            dgvReports.TabIndex = 4;
            // 
            // colType
            // 
            colType.FillWeight = 80F;
            colType.HeaderText = "Type";
            colType.MinimumWidth = 6;
            colType.Name = "colType";
            colType.ReadOnly = true;
            // 
            // colCompany
            // 
            colCompany.HeaderText = "Company";
            colCompany.MinimumWidth = 6;
            colCompany.Name = "colCompany";
            colCompany.ReadOnly = true;
            // 
            // colPosition
            // 
            colPosition.HeaderText = "Position";
            colPosition.MinimumWidth = 6;
            colPosition.Name = "colPosition";
            colPosition.ReadOnly = true;
            // 
            // colSubmittedOn
            // 
            colSubmittedOn.HeaderText = "Submitted On";
            colSubmittedOn.MinimumWidth = 6;
            colSubmittedOn.Name = "colSubmittedOn";
            colSubmittedOn.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.FillWeight = 90F;
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colAction
            // 
            colAction.FillWeight = 70F;
            colAction.HeaderText = "Action";
            colAction.MinimumWidth = 6;
            colAction.Name = "colAction";
            colAction.ReadOnly = true;
            colAction.Text = "View";
            colAction.UseColumnTextForButtonValue = true;
            // 
            // frmReportList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1445, 863);
            Controls.Add(dgvReports);
            Controls.Add(btnRefresh);
            Controls.Add(cmbStatusFilter);
            Controls.Add(lblStatusFilter);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmReportList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "My Reports";
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubmittedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colAction;
    }

    #endregion
}
