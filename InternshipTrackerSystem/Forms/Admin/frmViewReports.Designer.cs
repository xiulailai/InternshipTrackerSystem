namespace InternshipTrackerSystem.Forms.Admin
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
            lblReportsTitle = new Label();
            dgvReports = new DataGridView();
            btnGenerateReport = new Button();
            btnExport = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            SuspendLayout();
            // 
            // lblReportsTitle
            // 
            lblReportsTitle.AutoSize = true;
            lblReportsTitle.Location = new Point(348, 23);
            lblReportsTitle.Name = "lblReportsTitle";
            lblReportsTitle.Size = new Size(123, 24);
            lblReportsTitle.TabIndex = 0;
            lblReportsTitle.Text = "View Reports";
            // 
            // dgvReports
            // 
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(12, 77);
            dgvReports.Name = "dgvReports";
            dgvReports.RowHeadersWidth = 62;
            dgvReports.Size = new Size(800, 352);
            dgvReports.TabIndex = 1;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(98, 444);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(165, 34);
            btnGenerateReport.TabIndex = 2;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(311, 444);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(176, 34);
            btnExport.TabIndex = 3;
            btnExport.Text = "Export to CSV";
            btnExport.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(530, 444);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // frmViewReports
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 490);
            Controls.Add(btnBack);
            Controls.Add(btnExport);
            Controls.Add(btnGenerateReport);
            Controls.Add(dgvReports);
            Controls.Add(lblReportsTitle);
            Name = "frmViewReports";
            Text = "frmViewReports";
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblReportsTitle;
        private DataGridView dgvReports;
        private Button btnGenerateReport;
        private Button btnExport;
        private Button btnBack;
    }
}