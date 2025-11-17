namespace InternshipTrackerSystem.Forms.Student_Lai
{
    partial class frmReportDetails
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
            lblReportID = new Label();
            txtReportID = new TextBox();
            lblInternship = new Label();
            txtInternship = new TextBox();
            lblReportType = new Label();
            txtReportType = new TextBox();
            lblSubmissionDate = new Label();
            txtSubmissionDate = new TextBox();
            lblStatus = new Label();
            txtStatus = new TextBox();
            lblFile = new Label();
            btnDownload = new Button();
            lblContent = new Label();
            txtContent = new TextBox();
            pnlResubmit = new Panel();
            btnResubmit = new Button();
            btnChooseFile = new Button();
            txtNewFilePath = new TextBox();
            lblNewFile = new Label();
            txtNewContent = new TextBox();
            lblNewContent = new Label();
            lblResubmitTitle = new Label();
            pnlResubmit.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(16, 14);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1013, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "REPORT DETAILS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblReportID
            // 
            lblReportID.AutoSize = true;
            lblReportID.Font = new Font("Segoe UI", 10F);
            lblReportID.Location = new Point(45, 86);
            lblReportID.Margin = new Padding(4, 0, 4, 0);
            lblReportID.Name = "lblReportID";
            lblReportID.Size = new Size(87, 23);
            lblReportID.TabIndex = 1;
            lblReportID.Text = "Report ID:";
            // 
            // txtReportID
            // 
            txtReportID.Font = new Font("Segoe UI", 10F);
            txtReportID.Location = new Point(245, 81);
            txtReportID.Margin = new Padding(4, 5, 4, 5);
            txtReportID.Name = "txtReportID";
            txtReportID.ReadOnly = true;
            txtReportID.Size = new Size(199, 30);
            txtReportID.TabIndex = 2;
            // 
            // lblInternship
            // 
            lblInternship.AutoSize = true;
            lblInternship.Font = new Font("Segoe UI", 10F);
            lblInternship.Location = new Point(45, 147);
            lblInternship.Margin = new Padding(4, 0, 4, 0);
            lblInternship.Name = "lblInternship";
            lblInternship.Size = new Size(91, 23);
            lblInternship.TabIndex = 3;
            lblInternship.Text = "Internship:";
            // 
            // txtInternship
            // 
            txtInternship.Font = new Font("Segoe UI", 10F);
            txtInternship.Location = new Point(245, 143);
            txtInternship.Margin = new Padding(4, 5, 4, 5);
            txtInternship.Name = "txtInternship";
            txtInternship.ReadOnly = true;
            txtInternship.Size = new Size(732, 30);
            txtInternship.TabIndex = 4;
            // 
            // lblReportType
            // 
            lblReportType.AutoSize = true;
            lblReportType.Font = new Font("Segoe UI", 10F);
            lblReportType.Location = new Point(45, 209);
            lblReportType.Margin = new Padding(4, 0, 4, 0);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new Size(105, 23);
            lblReportType.TabIndex = 5;
            lblReportType.Text = "Report Type:";
            // 
            // txtReportType
            // 
            txtReportType.Font = new Font("Segoe UI", 10F);
            txtReportType.Location = new Point(245, 204);
            txtReportType.Margin = new Padding(4, 5, 4, 5);
            txtReportType.Name = "txtReportType";
            txtReportType.ReadOnly = true;
            txtReportType.Size = new Size(265, 30);
            txtReportType.TabIndex = 6;
            // 
            // lblSubmissionDate
            // 
            lblSubmissionDate.AutoSize = true;
            lblSubmissionDate.Font = new Font("Segoe UI", 10F);
            lblSubmissionDate.Location = new Point(45, 270);
            lblSubmissionDate.Margin = new Padding(4, 0, 4, 0);
            lblSubmissionDate.Name = "lblSubmissionDate";
            lblSubmissionDate.Size = new Size(141, 23);
            lblSubmissionDate.TabIndex = 7;
            lblSubmissionDate.Text = "Submission Date:";
            // 
            // txtSubmissionDate
            // 
            txtSubmissionDate.Font = new Font("Segoe UI", 10F);
            txtSubmissionDate.Location = new Point(245, 266);
            txtSubmissionDate.Margin = new Padding(4, 5, 4, 5);
            txtSubmissionDate.Name = "txtSubmissionDate";
            txtSubmissionDate.ReadOnly = true;
            txtSubmissionDate.Size = new Size(265, 30);
            txtSubmissionDate.TabIndex = 8;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.Location = new Point(45, 332);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 23);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            txtStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtStatus.Location = new Point(245, 327);
            txtStatus.Margin = new Padding(4, 5, 4, 5);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(265, 30);
            txtStatus.TabIndex = 10;
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.Font = new Font("Segoe UI", 10F);
            lblFile.Location = new Point(45, 393);
            lblFile.Margin = new Padding(4, 0, 4, 0);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(39, 23);
            lblFile.TabIndex = 11;
            lblFile.Text = "File:";
            // 
            // btnDownload
            // 
            btnDownload.Font = new Font("Segoe UI", 9F);
            btnDownload.Location = new Point(245, 389);
            btnDownload.Margin = new Padding(4, 5, 4, 5);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(133, 43);
            btnDownload.TabIndex = 12;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblContent.Location = new Point(45, 450);
            lblContent.Margin = new Padding(4, 0, 4, 0);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(79, 23);
            lblContent.TabIndex = 13;
            lblContent.Text = "Content:";
            // 
            // txtContent
            // 
            txtContent.Font = new Font("Segoe UI", 9F);
            txtContent.Location = new Point(45, 480);
            txtContent.Margin = new Padding(4, 5, 4, 5);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.ReadOnly = true;
            txtContent.ScrollBars = ScrollBars.Vertical;
            txtContent.Size = new Size(959, 100);
            txtContent.TabIndex = 14;
            // 
            // pnlResubmit
            // 
            pnlResubmit.BackColor = Color.FromArgb(245, 245, 245);
            pnlResubmit.Controls.Add(btnResubmit);
            pnlResubmit.Controls.Add(btnChooseFile);
            pnlResubmit.Controls.Add(txtNewFilePath);
            pnlResubmit.Controls.Add(lblNewFile);
            pnlResubmit.Controls.Add(txtNewContent);
            pnlResubmit.Controls.Add(lblNewContent);
            pnlResubmit.Controls.Add(lblResubmitTitle);
            pnlResubmit.Location = new Point(45, 600);
            pnlResubmit.Margin = new Padding(4, 5, 4, 5);
            pnlResubmit.Name = "pnlResubmit";
            pnlResubmit.Size = new Size(960, 340);
            pnlResubmit.TabIndex = 15;
            pnlResubmit.Visible = false;
            // 
            // btnResubmit
            // 
            btnResubmit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnResubmit.Location = new Point(373, 257);
            btnResubmit.Margin = new Padding(4, 5, 4, 5);
            btnResubmit.Name = "btnResubmit";
            btnResubmit.Size = new Size(200, 62);
            btnResubmit.TabIndex = 6;
            btnResubmit.Text = "RESUBMIT";
            btnResubmit.UseVisualStyleBackColor = true;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Font = new Font("Segoe UI", 9F);
            btnChooseFile.Location = new Point(760, 207);
            btnChooseFile.Margin = new Padding(4, 5, 4, 5);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(160, 43);
            btnChooseFile.TabIndex = 5;
            btnChooseFile.Text = "Choose File";
            btnChooseFile.UseVisualStyleBackColor = true;
            // 
            // txtNewFilePath
            // 
            txtNewFilePath.Font = new Font("Segoe UI", 9F);
            txtNewFilePath.Location = new Point(200, 217);
            txtNewFilePath.Margin = new Padding(4, 5, 4, 5);
            txtNewFilePath.Name = "txtNewFilePath";
            txtNewFilePath.ReadOnly = true;
            txtNewFilePath.Size = new Size(545, 27);
            txtNewFilePath.TabIndex = 4;
            // 
            // lblNewFile
            // 
            lblNewFile.AutoSize = true;
            lblNewFile.Font = new Font("Segoe UI", 10F);
            lblNewFile.Location = new Point(20, 217);
            lblNewFile.Margin = new Padding(4, 0, 4, 0);
            lblNewFile.Name = "lblNewFile";
            lblNewFile.Size = new Size(156, 23);
            lblNewFile.TabIndex = 3;
            lblNewFile.Text = "New File (optional):";
            // 
            // txtNewContent
            // 
            txtNewContent.Font = new Font("Segoe UI", 9F);
            txtNewContent.Location = new Point(25, 95);
            txtNewContent.Margin = new Padding(4, 5, 4, 5);
            txtNewContent.Multiline = true;
            txtNewContent.Name = "txtNewContent";
            txtNewContent.ScrollBars = ScrollBars.Vertical;
            txtNewContent.Size = new Size(905, 100);
            txtNewContent.TabIndex = 2;
            // 
            // lblNewContent
            // 
            lblNewContent.AutoSize = true;
            lblNewContent.Font = new Font("Segoe UI", 10F);
            lblNewContent.Location = new Point(20, 65);
            lblNewContent.Margin = new Padding(4, 0, 4, 0);
            lblNewContent.Name = "lblNewContent";
            lblNewContent.Size = new Size(115, 23);
            lblNewContent.TabIndex = 1;
            lblNewContent.Text = "New Content:";
            // 
            // lblResubmitTitle
            // 
            lblResubmitTitle.AutoSize = true;
            lblResubmitTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblResubmitTitle.ForeColor = Color.FromArgb(192, 0, 0);
            lblResubmitTitle.Location = new Point(20, 20);
            lblResubmitTitle.Margin = new Padding(4, 0, 4, 0);
            lblResubmitTitle.Name = "lblResubmitTitle";
            lblResubmitTitle.Size = new Size(223, 28);
            lblResubmitTitle.TabIndex = 0;
            lblResubmitTitle.Text = "If Rejected - Resubmit";
            // 
            // frmReportDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1045, 953);
            Controls.Add(pnlResubmit);
            Controls.Add(txtContent);
            Controls.Add(lblContent);
            Controls.Add(btnDownload);
            Controls.Add(lblFile);
            Controls.Add(txtStatus);
            Controls.Add(lblStatus);
            Controls.Add(txtSubmissionDate);
            Controls.Add(lblSubmissionDate);
            Controls.Add(txtReportType);
            Controls.Add(lblReportType);
            Controls.Add(txtInternship);
            Controls.Add(lblInternship);
            Controls.Add(txtReportID);
            Controls.Add(lblReportID);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmReportDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Report Details";
            pnlResubmit.ResumeLayout(false);
            pnlResubmit.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblReportID;
        private System.Windows.Forms.TextBox txtReportID;
        private System.Windows.Forms.Label lblInternship;
        private System.Windows.Forms.TextBox txtInternship;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.TextBox txtReportType;
        private System.Windows.Forms.Label lblSubmissionDate;
        private System.Windows.Forms.TextBox txtSubmissionDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Panel pnlResubmit;
        private System.Windows.Forms.Button btnResubmit;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.TextBox txtNewFilePath;
        private System.Windows.Forms.Label lblNewFile;
        private System.Windows.Forms.TextBox txtNewContent;
        private System.Windows.Forms.Label lblNewContent;
        private System.Windows.Forms.Label lblResubmitTitle;
    }

    #endregion
}
