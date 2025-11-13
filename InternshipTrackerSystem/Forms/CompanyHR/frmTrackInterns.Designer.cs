namespace InternshipTrackerSystem.Forms.CompanyHR
{
    partial class frmTrackInterns
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
            lblStatus = new Label();
            lblSearch = new Label();
            dgvInterns = new DataGridView();
            btnRefresh = new Button();
            cboStatus = new ComboBox();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvInterns).BeginInit();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(25, 29);
            lblStatus.Margin = new Padding(2, 0, 2, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(234, 29);
            lblSearch.Margin = new Padding(2, 0, 2, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(42, 15);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search";
            // 
            // dgvInterns
            // 
            dgvInterns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInterns.Location = new Point(25, 72);
            dgvInterns.Margin = new Padding(2, 1, 2, 1);
            dgvInterns.Name = "dgvInterns";
            dgvInterns.RowHeadersWidth = 82;
            dgvInterns.Size = new Size(740, 348);
            dgvInterns.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(686, 31);
            btnRefresh.Margin = new Padding(2, 1, 2, 1);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(79, 25);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // cboStatus
            // 
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "All", "ongoing", "Completed", "Terminated" });
            cboStatus.Location = new Point(92, 31);
            cboStatus.Margin = new Padding(2, 1, 2, 1);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(102, 23);
            cboStatus.TabIndex = 4;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(280, 29);
            txtSearch.Margin = new Padding(2, 1, 2, 1);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(217, 23);
            txtSearch.TabIndex = 5;
            // 
            // frmTrackInterns
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 544);
            Controls.Add(txtSearch);
            Controls.Add(cboStatus);
            Controls.Add(btnRefresh);
            Controls.Add(dgvInterns);
            Controls.Add(lblSearch);
            Controls.Add(lblStatus);
            Margin = new Padding(2, 1, 2, 1);
            Name = "frmTrackInterns";
            Text = "frmTrackInterns";
            ((System.ComponentModel.ISupportInitialize)dgvInterns).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private Label lblSearch;
        private DataGridView dgvInterns;
        private Button btnRefresh;
        private ComboBox cboStatus;
        private TextBox txtSearch;
    }
}