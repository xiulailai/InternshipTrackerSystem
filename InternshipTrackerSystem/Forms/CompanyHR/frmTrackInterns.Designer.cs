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
            lblStatus.Location = new Point(47, 62);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 32);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status";
            
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(435, 62);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(85, 32);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search";
            // 
            // dgvInterns
            // 
            dgvInterns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInterns.Location = new Point(59, 162);
            dgvInterns.Name = "dgvInterns";
            dgvInterns.RowHeadersWidth = 82;
            dgvInterns.Size = new Size(1038, 442);
            dgvInterns.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(961, 66);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(146, 54);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // cboStatus
            // 
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "All", "ongoing", "Completed", "Terminated" });
            cboStatus.Location = new Point(171, 66);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(186, 40);
            cboStatus.TabIndex = 4;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(533, 66);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(400, 39);
            txtSearch.TabIndex = 5;
            // 
            // frmTrackInterns
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1142, 690);
            Controls.Add(txtSearch);
            Controls.Add(cboStatus);
            Controls.Add(btnRefresh);
            Controls.Add(dgvInterns);
            Controls.Add(lblSearch);
            Controls.Add(lblStatus);
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