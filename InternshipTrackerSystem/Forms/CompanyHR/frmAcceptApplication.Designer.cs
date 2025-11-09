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
            groupBox1 = new GroupBox();
            lblAction = new Label();
            lblPosition = new Label();
            lblStudent = new Label();
            groupBox2 = new GroupBox();
            txtRemarks = new TextBox();
            label2 = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblAction);
            groupBox1.Controls.Add(lblPosition);
            groupBox1.Controls.Add(lblStudent);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(354, 116);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
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
            // groupBox2
            // 
            groupBox2.Controls.Add(txtRemarks);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(12, 145);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(354, 143);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // txtRemarks
            // 
            txtRemarks.Location = new Point(16, 37);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(323, 100);
            txtRemarks.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 14);
            label2.Name = "label2";
            label2.Size = new Size(140, 20);
            label2.TabIndex = 0;
            label2.Text = "Remarks (Optional):";
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
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmAcceptApplication";
            Text = "Accept Application";
            Load += frmAcceptApplication_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblAction;
        private Label lblPosition;
        private Label lblStudent;
        private GroupBox groupBox2;
        private TextBox txtRemarks;
        private Label label2;
        private Button btnConfirm;
        private Button btnCancel;
    }
}