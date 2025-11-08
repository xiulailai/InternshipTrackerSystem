namespace InternshipTrackerSystem.Forms.CompanyHR
{
    partial class frmCreatePosition
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
            label3 = new Label();
            txtTitle = new TextBox();
            label4 = new Label();
            txtDescription = new TextBox();
            label5 = new Label();
            txtRequirements = new TextBox();
            label6 = new Label();
            cboStatus = new ComboBox();
            btnSave = new Button();
            btnClear = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(211, 20);
            label1.TabIndex = 0;
            label1.Text = "Create New Internship Position";
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(12, 39);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(79, 20);
            lblCompanyName.TabIndex = 1;
            lblCompanyName.Text = "Company: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 72);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 2;
            label3.Text = "Position Title:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 95);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(381, 27);
            txtTitle.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 139);
            label4.Name = "label4";
            label4.Size = new Size(115, 20);
            label4.TabIndex = 4;
            label4.Text = "Job Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(12, 162);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(381, 92);
            txtDescription.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 273);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 6;
            label5.Text = "Requirements:";
            // 
            // txtRequirements
            // 
            txtRequirements.Location = new Point(12, 296);
            txtRequirements.Multiline = true;
            txtRequirements.Name = "txtRequirements";
            txtRequirements.Size = new Size(381, 92);
            txtRequirements.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 410);
            label6.Name = "label6";
            label6.Size = new Size(52, 20);
            label6.TabIndex = 8;
            label6.Text = "Status:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Open", "Closed" });
            cboStatus.Location = new Point(12, 433);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(151, 28);
            cboStatus.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 485);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(121, 29);
            btnSave.TabIndex = 10;
            btnSave.Text = "Create Position";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(139, 485);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(121, 29);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear All";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(266, 485);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(121, 29);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // frmCreatePosition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 538);
            Controls.Add(btnCancel);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(cboStatus);
            Controls.Add(label6);
            Controls.Add(txtRequirements);
            Controls.Add(label5);
            Controls.Add(txtDescription);
            Controls.Add(label4);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(lblCompanyName);
            Controls.Add(label1);
            Name = "frmCreatePosition";
            Text = "Create Position";
            Load += frmCreatePosition_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblCompanyName;
        private Label label3;
        private TextBox txtTitle;
        private Label label4;
        private TextBox txtDescription;
        private Label label5;
        private TextBox txtRequirements;
        private Label label6;
        private ComboBox cboStatus;
        private Button btnSave;
        private Button btnClear;
        private Button btnCancel;
    }
}