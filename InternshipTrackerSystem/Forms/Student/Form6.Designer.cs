namespace assignment_student
{
    partial class Form6
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
            ofdReport = new OpenFileDialog();
            label1 = new Label();
            label2 = new Label();
            txtFilePath = new TextBox();
            btnBrowse = new Button();
            btnUpload = new Button();
            lblStatus = new Label();
            btnBack = new Button();
            cmbReportType = new ComboBox();
            cmbInternship = new ComboBox();
            SuspendLayout();
            // 
            // ofdReport
            // 
            ofdReport.FileName = "openFileDialog1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(225, 41);
            label1.TabIndex = 0;
            label1.Text = "Submit Report";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(55, 99);
            label2.Name = "label2";
            label2.Size = new Size(136, 31);
            label2.TabIndex = 1;
            label2.Text = "selected file";
            // 
            // txtFilePath
            // 
            txtFilePath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFilePath.Location = new Point(197, 99);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(125, 34);
            txtFilePath.TabIndex = 2;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(58, 150);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(133, 40);
            btnBrowse.TabIndex = 3;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(197, 150);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(133, 40);
            btnUpload.TabIndex = 4;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BorderStyle = BorderStyle.Fixed3D;
            lblStatus.Location = new Point(55, 215);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(2, 22);
            lblStatus.TabIndex = 5;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(336, 150);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(175, 40);
            btnBack.TabIndex = 6;
            btnBack.Text = "back to main menu";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // cmbReportType
            // 
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Location = new Point(55, 240);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(151, 28);
            cmbReportType.TabIndex = 7;
            // 
            // cmbInternship
            // 
            cmbInternship.FormattingEnabled = true;
            cmbInternship.Location = new Point(238, 240);
            cmbInternship.Name = "cmbInternship";
            cmbInternship.Size = new Size(151, 28);
            cmbInternship.TabIndex = 8;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbInternship);
            Controls.Add(cmbReportType);
            Controls.Add(btnBack);
            Controls.Add(lblStatus);
            Controls.Add(btnUpload);
            Controls.Add(btnBrowse);
            Controls.Add(txtFilePath);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form6";
            Text = "Submit Report";
            Load += ReportForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog ofdReport;
        private Label label1;
        private Label label2;
        private TextBox txtFilePath;
        private Button btnBrowse;
        private Button btnUpload;
        private Label lblStatus;
        private Button btnBack;
        private ComboBox cmbReportType;
        private ComboBox cmbInternship;
    }
}