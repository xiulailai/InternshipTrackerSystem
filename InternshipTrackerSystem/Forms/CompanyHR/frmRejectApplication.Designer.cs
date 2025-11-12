namespace InternshipTrackerSystem.Forms.CompanyHR
{
    partial class frmRejectApplication
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
            btnCancel = new Button();
            btnConfirm = new Button();
            grpRejection = new GroupBox();
            txtRemarks = new TextBox();
            lblReject = new Label();
            grpDetails = new GroupBox();
            lblAction = new Label();
            lblPosition = new Label();
            lblStudent = new Label();
            grpRejection.SuspendLayout();
            grpDetails.SuspendLayout();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(211, 304);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(28, 304);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(140, 29);
            btnConfirm.TabIndex = 6;
            btnConfirm.Text = "Confirm Reject";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // grpRejection
            // 
            grpRejection.Controls.Add(txtRemarks);
            grpRejection.Controls.Add(lblReject);
            grpRejection.Location = new Point(12, 145);
            grpRejection.Name = "grpRejection";
            grpRejection.Size = new Size(354, 143);
            grpRejection.TabIndex = 5;
            grpRejection.TabStop = false;
            // 
            // txtRemarks
            // 
            txtRemarks.Location = new Point(16, 37);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(323, 100);
            txtRemarks.TabIndex = 1;
            // 
            // lblReject
            // 
            lblReject.AutoSize = true;
            lblReject.Location = new Point(16, 14);
            lblReject.Name = "lblReject";
            lblReject.Size = new Size(159, 20);
            lblReject.TabIndex = 0;
            lblReject.Text = "Reason for Rejection: *";
            // 
            // grpDetails
            // 
            grpDetails.Controls.Add(lblAction);
            grpDetails.Controls.Add(lblPosition);
            grpDetails.Controls.Add(lblStudent);
            grpDetails.Location = new Point(12, 12);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(354, 116);
            grpDetails.TabIndex = 4;
            grpDetails.TabStop = false;
            // 
            // lblAction
            // 
            lblAction.AutoSize = true;
            lblAction.Location = new Point(16, 81);
            lblAction.Name = "lblAction";
            lblAction.Size = new Size(106, 20);
            lblAction.TabIndex = 2;
            lblAction.Text = "Action: REJECT";
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(16, 52);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(64, 20);
            lblPosition.TabIndex = 1;
            lblPosition.Text = "Position:";
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Location = new Point(16, 23);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(63, 20);
            lblStudent.TabIndex = 0;
            lblStudent.Text = "Student:";
            // 
            // frmRejectApplication
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 347);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(grpRejection);
            Controls.Add(grpDetails);
            Name = "frmRejectApplication";
            Text = "frmRejectApplication";
            Load += frmRejectApplication_Load;
            grpRejection.ResumeLayout(false);
            grpRejection.PerformLayout();
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancel;
        private Button btnConfirm;
        private GroupBox grpRejection;
        private TextBox txtRemarks;
        private Label lblReject;
        private GroupBox grpDetails;
        private Label lblAction;
        private Label lblPosition;
        private Label lblStudent;
    }
}