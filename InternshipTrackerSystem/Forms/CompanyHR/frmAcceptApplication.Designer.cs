namespace InternshipTrackerSystem.Forms.CompanyHR
{
    partial class frmAcceptApplication
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
            grpDetails = new GroupBox();
            lblAction = new Label();
            lblPosition = new Label();
            lblStudent = new Label();
            grpRemarks = new GroupBox();
            txtRemarks = new TextBox();
            lblRemarks = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            grpDetails.SuspendLayout();
            grpRemarks.SuspendLayout();
            SuspendLayout();
            // 
            // grpDetails
            // 
            grpDetails.Controls.Add(lblAction);
            grpDetails.Controls.Add(lblPosition);
            grpDetails.Controls.Add(lblStudent);
            grpDetails.Location = new Point(12, 12);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(354, 116);
            grpDetails.TabIndex = 0;
            grpDetails.TabStop = false;
            // 
            // lblAction
            // 
            lblAction.AutoSize = true;
            lblAction.Location = new Point(16, 81);
            lblAction.Name = "lblAction";
            lblAction.Size = new Size(111, 20);
            lblAction.TabIndex = 2;
            lblAction.Text = "Action: ACCEPT";
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
            // grpRemarks
            // 
            grpRemarks.Controls.Add(txtRemarks);
            grpRemarks.Controls.Add(lblRemarks);
            grpRemarks.Location = new Point(12, 145);
            grpRemarks.Name = "grpRemarks";
            grpRemarks.Size = new Size(354, 143);
            grpRemarks.TabIndex = 1;
            grpRemarks.TabStop = false;
            // 
            // txtRemarks
            // 
            txtRemarks.Location = new Point(16, 37);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(323, 100);
            txtRemarks.TabIndex = 1;
            // 
            // lblRemarks
            // 
            lblRemarks.AutoSize = true;
            lblRemarks.Location = new Point(16, 14);
            lblRemarks.Name = "lblRemarks";
            lblRemarks.Size = new Size(140, 20);
            lblRemarks.TabIndex = 0;
            lblRemarks.Text = "Remarks (Optional):";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(28, 301);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(140, 29);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "Confirm Accept";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(211, 301);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 29);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmAcceptApplication
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 342);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(grpRemarks);
            Controls.Add(grpDetails);
            Name = "frmAcceptApplication";
            Text = "Accept Application";
            Load += frmAcceptApplication_Load;
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            grpRemarks.ResumeLayout(false);
            grpRemarks.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDetails;
        private Label lblAction;
        private Label lblPosition;
        private Label lblStudent;
        private GroupBox grpRemarks;
        private TextBox txtRemarks;
        private Label lblRemarks;
        private Button btnConfirm;
        private Button btnCancel;
    }
}