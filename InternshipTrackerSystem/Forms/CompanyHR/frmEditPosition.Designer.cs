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
            lblCompanyName = new Label();
            label2 = new Label();
            txtPositionId = new TextBox();
            txtTitle = new TextBox();
            label3 = new Label();
            lblPostedDate = new Label();
            btnUpdate = new Button();
            btnCancel = new Button();
            txtRequirements = new TextBox();
            label5 = new Label();
            txtDescription = new TextBox();
            label4 = new Label();
            dtpApplicationDeadline = new DateTimePicker();
            label10 = new Label();
            dtpEndDate = new DateTimePicker();
            label9 = new Label();
            dtpStartDate = new DateTimePicker();
            label8 = new Label();
            txtStipend = new TextBox();
            label7 = new Label();
            txtLocation = new TextBox();
            label1 = new Label();
            cboStatus = new ComboBox();
            label6 = new Label();
            numDuration = new NumericUpDown();
            label11 = new Label();
            numAvailableSlots = new NumericUpDown();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAvailableSlots).BeginInit();
            SuspendLayout();
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(14, 9);
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
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 102);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(507, 27);
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
            // lblPostedDate
            // 
            lblPostedDate.AutoSize = true;
            lblPostedDate.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPostedDate.Location = new Point(140, 559);
            lblPostedDate.Name = "lblPostedDate";
            lblPostedDate.Size = new Size(37, 20);
            lblPostedDate.TabIndex = 16;
            lblPostedDate.Text = "date";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(138, 586);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(121, 29);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(265, 586);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(121, 29);
            btnCancel.TabIndex = 18;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtRequirements
            // 
            txtRequirements.Location = new Point(14, 265);
            txtRequirements.Multiline = true;
            txtRequirements.Name = "txtRequirements";
            txtRequirements.Size = new Size(503, 63);
            txtRequirements.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 242);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 21;
            label5.Text = "Requirements:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(14, 165);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(503, 62);
            txtDescription.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 142);
            label4.Name = "label4";
            label4.Size = new Size(115, 20);
            label4.TabIndex = 19;
            label4.Text = "Job Description:";
            // 
            // dtpApplicationDeadline
            // 
            dtpApplicationDeadline.Location = new Point(14, 501);
            dtpApplicationDeadline.Name = "dtpApplicationDeadline";
            dtpApplicationDeadline.Size = new Size(242, 27);
            dtpApplicationDeadline.TabIndex = 36;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 478);
            label10.Name = "label10";
            label10.Size = new Size(153, 20);
            label10.TabIndex = 35;
            label10.Text = "Application Deadline:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(274, 428);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(242, 27);
            dtpEndDate.TabIndex = 34;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(276, 405);
            label9.Name = "label9";
            label9.Size = new Size(73, 20);
            label9.TabIndex = 33;
            label9.Text = "End Date:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(14, 428);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(242, 27);
            dtpStartDate.TabIndex = 32;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 405);
            label8.Name = "label8";
            label8.Size = new Size(79, 20);
            label8.TabIndex = 31;
            label8.Text = "Start Date:";
            // 
            // txtStipend
            // 
            txtStipend.Location = new Point(191, 366);
            txtStipend.Name = "txtStipend";
            txtStipend.Size = new Size(151, 27);
            txtStipend.TabIndex = 30;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(193, 343);
            label7.Name = "label7";
            label7.Size = new Size(63, 20);
            label7.TabIndex = 29;
            label7.Text = "Stipend:";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(14, 366);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(151, 27);
            txtLocation.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 343);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 27;
            label1.Text = "Location:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Open", "Closed" });
            cboStatus.Location = new Point(366, 366);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(151, 28);
            cboStatus.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(366, 343);
            label6.Name = "label6";
            label6.Size = new Size(52, 20);
            label6.TabIndex = 25;
            label6.Text = "Status:";
            // 
            // numDuration
            // 
            numDuration.Location = new Point(406, 501);
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(110, 27);
            numDuration.TabIndex = 40;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(395, 478);
            label11.Name = "label11";
            label11.Size = new Size(124, 20);
            label11.TabIndex = 39;
            label11.Text = "Duration (weeks):";
            // 
            // numAvailableSlots
            // 
            numAvailableSlots.Location = new Point(276, 501);
            numAvailableSlots.Name = "numAvailableSlots";
            numAvailableSlots.Size = new Size(110, 27);
            numAvailableSlots.TabIndex = 38;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(276, 478);
            label12.Name = "label12";
            label12.Size = new Size(110, 20);
            label12.TabIndex = 37;
            label12.Text = "Available Slots:";
            // 
            // frmEditPosition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 627);
            Controls.Add(numDuration);
            Controls.Add(label11);
            Controls.Add(numAvailableSlots);
            Controls.Add(label12);
            Controls.Add(dtpApplicationDeadline);
            Controls.Add(label10);
            Controls.Add(dtpEndDate);
            Controls.Add(label9);
            Controls.Add(dtpStartDate);
            Controls.Add(label8);
            Controls.Add(txtStipend);
            Controls.Add(label7);
            Controls.Add(txtLocation);
            Controls.Add(label1);
            Controls.Add(cboStatus);
            Controls.Add(label6);
            Controls.Add(txtRequirements);
            Controls.Add(label5);
            Controls.Add(txtDescription);
            Controls.Add(label4);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdate);
            Controls.Add(lblPostedDate);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(txtPositionId);
            Controls.Add(label2);
            Controls.Add(lblCompanyName);
            Name = "frmEditPosition";
            Text = "Edit Position";
            Load += frmEditPosition_Load;
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAvailableSlots).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblCompanyName;
        private Label label2;
        private TextBox txtPositionId;
        private TextBox txtTitle;
        private Label label3;
        private Label lblPostedDate;
        private Button btnUpdate;
        private Button btnCancel;
        private TextBox txtRequirements;
        private Label label5;
        private TextBox txtDescription;
        private Label label4;
        private DateTimePicker dtpApplicationDeadline;
        private Label label10;
        private DateTimePicker dtpEndDate;
        private Label label9;
        private DateTimePicker dtpStartDate;
        private Label label8;
        private TextBox txtStipend;
        private Label label7;
        private TextBox txtLocation;
        private Label label1;
        private ComboBox cboStatus;
        private Label label6;
        private NumericUpDown numDuration;
        private Label label11;
        private NumericUpDown numAvailableSlots;
        private Label label12;
    }
}