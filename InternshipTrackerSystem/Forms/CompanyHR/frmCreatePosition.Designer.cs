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
            label2 = new Label();
            txtLocation = new TextBox();
            txtStipend = new TextBox();
            label7 = new Label();
            label8 = new Label();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            label9 = new Label();
            label10 = new Label();
            dtpApplicationDeadline = new DateTimePicker();
            label11 = new Label();
            numAvailableSlots = new NumericUpDown();
            numDuration = new NumericUpDown();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numAvailableSlots).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            SuspendLayout();
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(12, 20);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(79, 20);
            lblCompanyName.TabIndex = 1;
            lblCompanyName.Text = "Company: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 53);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 2;
            label3.Text = "Position Title:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 76);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(503, 27);
            txtTitle.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 120);
            label4.Name = "label4";
            label4.Size = new Size(115, 20);
            label4.TabIndex = 4;
            label4.Text = "Job Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(12, 143);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(503, 62);
            txtDescription.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 220);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 6;
            label5.Text = "Requirements:";
            // 
            // txtRequirements
            // 
            txtRequirements.Location = new Point(12, 243);
            txtRequirements.Multiline = true;
            txtRequirements.Name = "txtRequirements";
            txtRequirements.Size = new Size(503, 63);
            txtRequirements.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(364, 318);
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
            cboStatus.Location = new Point(364, 341);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(151, 28);
            cboStatus.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(73, 534);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(121, 29);
            btnSave.TabIndex = 10;
            btnSave.Text = "Create Position";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(200, 534);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(121, 29);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear All";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(327, 534);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(121, 29);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 318);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 13;
            label2.Text = "Location:";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(12, 341);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(151, 27);
            txtLocation.TabIndex = 14;
            // 
            // txtStipend
            // 
            txtStipend.Location = new Point(189, 341);
            txtStipend.Name = "txtStipend";
            txtStipend.Size = new Size(151, 27);
            txtStipend.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(191, 318);
            label7.Name = "label7";
            label7.Size = new Size(63, 20);
            label7.TabIndex = 15;
            label7.Text = "Stipend:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 380);
            label8.Name = "label8";
            label8.Size = new Size(79, 20);
            label8.TabIndex = 17;
            label8.Text = "Start Date:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(12, 403);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(242, 27);
            dtpStartDate.TabIndex = 18;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(272, 403);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(242, 27);
            dtpEndDate.TabIndex = 20;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(274, 380);
            label9.Name = "label9";
            label9.Size = new Size(73, 20);
            label9.TabIndex = 19;
            label9.Text = "End Date:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(14, 453);
            label10.Name = "label10";
            label10.Size = new Size(153, 20);
            label10.TabIndex = 21;
            label10.Text = "Application Deadline:";
            // 
            // dtpApplicationDeadline
            // 
            dtpApplicationDeadline.Location = new Point(12, 476);
            dtpApplicationDeadline.Name = "dtpApplicationDeadline";
            dtpApplicationDeadline.Size = new Size(242, 27);
            dtpApplicationDeadline.TabIndex = 22;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(274, 453);
            label11.Name = "label11";
            label11.Size = new Size(110, 20);
            label11.TabIndex = 23;
            label11.Text = "Available Slots:";
            // 
            // numAvailableSlots
            // 
            numAvailableSlots.Location = new Point(274, 476);
            numAvailableSlots.Name = "numAvailableSlots";
            numAvailableSlots.Size = new Size(110, 27);
            numAvailableSlots.TabIndex = 24;
            // 
            // numDuration
            // 
            numDuration.Location = new Point(404, 476);
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(110, 27);
            numDuration.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(390, 453);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 25;
            label1.Text = "Duration (weeks):";
            // 
            // frmCreatePosition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 594);
            Controls.Add(numDuration);
            Controls.Add(label1);
            Controls.Add(numAvailableSlots);
            Controls.Add(label11);
            Controls.Add(dtpApplicationDeadline);
            Controls.Add(label10);
            Controls.Add(dtpEndDate);
            Controls.Add(label9);
            Controls.Add(dtpStartDate);
            Controls.Add(label8);
            Controls.Add(txtStipend);
            Controls.Add(label7);
            Controls.Add(txtLocation);
            Controls.Add(label2);
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
            Name = "frmCreatePosition";
            Text = "Create Position";
            Load += frmCreatePosition_Load;
            ((System.ComponentModel.ISupportInitialize)numAvailableSlots).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private Label label2;
        private TextBox txtLocation;
        private TextBox txtStipend;
        private Label label7;
        private Label label8;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label label9;
        private Label label10;
        private DateTimePicker dtpApplicationDeadline;
        private Label label11;
        private NumericUpDown numAvailableSlots;
        private NumericUpDown numDuration;
        private Label label1;
    }
}