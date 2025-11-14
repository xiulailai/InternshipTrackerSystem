namespace InternshipTrackerSystem.Forms.Student_Lai
{
    partial class frmReportSubmission
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
            lblInternship = new Label();
            cmbInternship = new ComboBox();
            lblReportType = new Label();
            cmbReportType = new ComboBox();
            lblContent = new Label();
            txtContent = new TextBox();
            lblAttachFile = new Label();
            txtFilePath = new TextBox();
            btnChooseFile = new Button();
            btnSubmit = new Button();
            lblMinChars = new Label();
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
            lblTitle.Text = "SUBMIT REPORT";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblInternship
            // 
            lblInternship.AutoSize = true;
            lblInternship.Font = new Font("Segoe UI", 10F);
            lblInternship.Location = new Point(40, 108);
            lblInternship.Margin = new Padding(4, 0, 4, 0);
            lblInternship.Name = "lblInternship";
            lblInternship.Size = new Size(91, 23);
            lblInternship.TabIndex = 1;
            lblInternship.Text = "Internship:";
            // 
            // cmbInternship
            // 
            cmbInternship.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInternship.Font = new Font("Segoe UI", 10F);
            cmbInternship.FormattingEnabled = true;
            cmbInternship.Location = new Point(173, 103);
            cmbInternship.Margin = new Padding(4, 5, 4, 5);
            cmbInternship.Name = "cmbInternship";
            cmbInternship.Size = new Size(799, 31);
            cmbInternship.TabIndex = 2;
            // 
            // lblReportType
            // 
            lblReportType.AutoSize = true;
            lblReportType.Font = new Font("Segoe UI", 10F);
            lblReportType.Location = new Point(40, 177);
            lblReportType.Margin = new Padding(4, 0, 4, 0);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new Size(105, 23);
            lblReportType.TabIndex = 3;
            lblReportType.Text = "Report Type:";
            // 
            // cmbReportType
            // 
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.Font = new Font("Segoe UI", 10F);
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Items.AddRange(new object[] { "Weekly", "Monthly", "Final" });
            cmbReportType.Location = new Point(173, 172);
            cmbReportType.Margin = new Padding(4, 5, 4, 5);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(265, 31);
            cmbReportType.TabIndex = 4;
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Font = new Font("Segoe UI", 10F);
            lblContent.Location = new Point(40, 246);
            lblContent.Margin = new Padding(4, 0, 4, 0);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(76, 23);
            lblContent.TabIndex = 5;
            lblContent.Text = "Content:";
            // 
            // txtContent
            // 
            txtContent.Font = new Font("Segoe UI", 10F);
            txtContent.Location = new Point(40, 285);
            txtContent.Margin = new Padding(4, 5, 4, 5);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.ScrollBars = ScrollBars.Vertical;
            txtContent.Size = new Size(932, 382);
            txtContent.TabIndex = 6;
            // 
            // lblAttachFile
            // 
            lblAttachFile.AutoSize = true;
            lblAttachFile.Font = new Font("Segoe UI", 10F);
            lblAttachFile.Location = new Point(40, 708);
            lblAttachFile.Margin = new Padding(4, 0, 4, 0);
            lblAttachFile.Name = "lblAttachFile";
            lblAttachFile.Size = new Size(94, 23);
            lblAttachFile.TabIndex = 8;
            lblAttachFile.Text = "Attach File:";
            // 
            // txtFilePath
            // 
            txtFilePath.Font = new Font("Segoe UI", 10F);
            txtFilePath.Location = new Point(173, 703);
            txtFilePath.Margin = new Padding(4, 5, 4, 5);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(625, 30);
            txtFilePath.TabIndex = 9;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Font = new Font("Segoe UI", 9F);
            btnChooseFile.Location = new Point(813, 700);
            btnChooseFile.Margin = new Padding(4, 5, 4, 5);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(160, 43);
            btnChooseFile.TabIndex = 10;
            btnChooseFile.Text = "Choose File";
            btnChooseFile.UseVisualStyleBackColor = true;
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSubmit.Location = new Point(400, 800);
            btnSubmit.Margin = new Padding(4, 5, 4, 5);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(240, 69);
            btnSubmit.TabIndex = 11;
            btnSubmit.Text = "SUBMIT REPORT";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblMinChars
            // 
            lblMinChars.AutoSize = true;
            lblMinChars.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblMinChars.ForeColor = SystemColors.ControlDarkDark;
            lblMinChars.Location = new Point(133, 248);
            lblMinChars.Margin = new Padding(4, 0, 4, 0);
            lblMinChars.Name = "lblMinChars";
            lblMinChars.Size = new Size(101, 19);
            lblMinChars.TabIndex = 7;
            lblMinChars.Text = "(min. 50 chars)";
            // 
            // frmReportSubmission
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 909);
            Controls.Add(btnSubmit);
            Controls.Add(btnChooseFile);
            Controls.Add(txtFilePath);
            Controls.Add(lblAttachFile);
            Controls.Add(lblMinChars);
            Controls.Add(txtContent);
            Controls.Add(lblContent);
            Controls.Add(cmbReportType);
            Controls.Add(lblReportType);
            Controls.Add(cmbInternship);
            Controls.Add(lblInternship);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmReportSubmission";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Submit Report";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInternship;
        private System.Windows.Forms.ComboBox cmbInternship;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblMinChars;
        private System.Windows.Forms.Label lblAttachFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnSubmit;
    }

    #endregion
}
