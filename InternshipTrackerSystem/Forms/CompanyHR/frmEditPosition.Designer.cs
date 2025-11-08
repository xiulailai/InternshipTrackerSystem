namespace InternshipTrackerSystem.Forms.CompanyHR
{
    partial class frmEditPosition
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
            label1 = new Label();
            lblCompanyName = new Label();
            label2 = new Label();
            txtPositionId = new TextBox();
            txtRequirements = new TextBox();
            label5 = new Label();
            txtDescription = new TextBox();
            label4 = new Label();
            txtTitle = new TextBox();
            label3 = new Label();
            cboStatus = new ComboBox();
            label6 = new Label();
            lblPostedDate = new Label();
            btnUpdate = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(105, 20);
            label1.TabIndex = 0;
            label1.Text = "Edit Position - ";
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(114, 9);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(69, 20);
            lblCompanyName.TabIndex = 1;
            lblCompanyName.Text = "loading...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 2;
            label2.Text = "Position ID:";
            // 
            // txtPositionId
            // 
            txtPositionId.Enabled = false;
            txtPositionId.Location = new Point(101, 49);
            txtPositionId.Name = "txtPositionId";
            txtPositionId.ReadOnly = true;
            txtPositionId.Size = new Size(125, 27);
            txtPositionId.TabIndex = 3;
            // 
            // txtRequirements
            // 
            txtRequirements.Location = new Point(12, 303);
            txtRequirements.Multiline = true;
            txtRequirements.Name = "txtRequirements";
            txtRequirements.Size = new Size(381, 92);
            txtRequirements.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 280);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 12;
            label5.Text = "Requirements:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(12, 169);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(381, 92);
            txtDescription.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 146);
            label4.Name = "label4";
            label4.Size = new Size(115, 20);
            label4.TabIndex = 10;
            label4.Text = "Job Description:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 102);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(381, 27);
            txtTitle.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 79);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 8;
            label3.Text = "Position Title:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Open", "Closed" });
            cboStatus.Location = new Point(12, 432);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(151, 28);
            cboStatus.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 409);
            label6.Name = "label6";
            label6.Size = new Size(52, 20);
            label6.TabIndex = 14;
            label6.Text = "Status:";
            // 
            // lblPostedDate
            // 
            lblPostedDate.AutoSize = true;
            lblPostedDate.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPostedDate.Location = new Point(14, 472);
            lblPostedDate.Name = "lblPostedDate";
            lblPostedDate.Size = new Size(37, 20);
            lblPostedDate.TabIndex = 16;
            lblPostedDate.Text = "date";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(12, 499);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(121, 29);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(139, 499);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(121, 29);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmEditPosition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 540);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdate);
            Controls.Add(lblPostedDate);
            Controls.Add(cboStatus);
            Controls.Add(label6);
            Controls.Add(txtRequirements);
            Controls.Add(label5);
            Controls.Add(txtDescription);
            Controls.Add(label4);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(txtPositionId);
            Controls.Add(label2);
            Controls.Add(lblCompanyName);
            Controls.Add(label1);
            Name = "frmEditPosition";
            Text = "Edit Position";
            Load += frmEditPosition_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblCompanyName;
        private Label label2;
        private TextBox txtPositionId;
        private TextBox txtRequirements;
        private Label label5;
        private TextBox txtDescription;
        private Label label4;
        private TextBox txtTitle;
        private Label label3;
        private ComboBox cboStatus;
        private Label label6;
        private Label lblPostedDate;
        private Button btnUpdate;
        private Button btnCancel;
    }
}