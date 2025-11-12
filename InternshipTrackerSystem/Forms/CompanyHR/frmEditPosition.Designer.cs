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
            lblPositionId = new Label();
            txtPositionId = new TextBox();
            txtTitle = new TextBox();
            lblTitle = new Label();
            lblPostedDate = new Label();
            btnUpdate = new Button();
            btnCancel = new Button();
            txtRequirements = new TextBox();
            lblRequirements = new Label();
            txtDescription = new TextBox();
            lblDescription = new Label();
            dtpApplicationDeadline = new DateTimePicker();
            lblApplicationDeadline = new Label();
            dtpEndDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblStartDate = new Label();
            txtStipend = new TextBox();
            lblStipend = new Label();
            txtLocation = new TextBox();
            lblLocation = new Label();
            cboStatus = new ComboBox();
            lblStatus = new Label();
            numDuration = new NumericUpDown();
            lblDuration = new Label();
            numAvailableSlots = new NumericUpDown();
            lblAvailableSlots = new Label();
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
            // lblPositionId
            // 
            lblPositionId.AutoSize = true;
            lblPositionId.Location = new Point(12, 52);
            lblPositionId.Name = "lblPositionId";
            lblPositionId.Size = new Size(83, 20);
            lblPositionId.TabIndex = 2;
            lblPositionId.Text = "Position ID:";
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
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 79);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(97, 20);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Position Title:";
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
            // lblRequirements
            // 
            lblRequirements.AutoSize = true;
            lblRequirements.Location = new Point(14, 242);
            lblRequirements.Name = "lblRequirements";
            lblRequirements.Size = new Size(103, 20);
            lblRequirements.TabIndex = 21;
            lblRequirements.Text = "Requirements:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(14, 165);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(503, 62);
            txtDescription.TabIndex = 20;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(14, 142);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(115, 20);
            lblDescription.TabIndex = 19;
            lblDescription.Text = "Job Description:";
            // 
            // dtpApplicationDeadline
            // 
            dtpApplicationDeadline.Location = new Point(14, 501);
            dtpApplicationDeadline.Name = "dtpApplicationDeadline";
            dtpApplicationDeadline.Size = new Size(242, 27);
            dtpApplicationDeadline.TabIndex = 36;
            // 
            // lblApplicationDeadline
            // 
            lblApplicationDeadline.AutoSize = true;
            lblApplicationDeadline.Location = new Point(16, 478);
            lblApplicationDeadline.Name = "lblApplicationDeadline";
            lblApplicationDeadline.Size = new Size(153, 20);
            lblApplicationDeadline.TabIndex = 35;
            lblApplicationDeadline.Text = "Application Deadline:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(274, 428);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(242, 27);
            dtpEndDate.TabIndex = 34;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(276, 405);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(73, 20);
            lblEndDate.TabIndex = 33;
            lblEndDate.Text = "End Date:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(14, 428);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(242, 27);
            dtpStartDate.TabIndex = 32;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(16, 405);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(79, 20);
            lblStartDate.TabIndex = 31;
            lblStartDate.Text = "Start Date:";
            // 
            // txtStipend
            // 
            txtStipend.Location = new Point(191, 366);
            txtStipend.Name = "txtStipend";
            txtStipend.Size = new Size(151, 27);
            txtStipend.TabIndex = 30;
            // 
            // lblStipend
            // 
            lblStipend.AutoSize = true;
            lblStipend.Location = new Point(193, 343);
            lblStipend.Name = "lblStipend";
            lblStipend.Size = new Size(63, 20);
            lblStipend.TabIndex = 29;
            lblStipend.Text = "Stipend:";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(14, 366);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(151, 27);
            txtLocation.TabIndex = 28;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(16, 343);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(69, 20);
            lblLocation.TabIndex = 27;
            lblLocation.Text = "Location:";
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
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(366, 343);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 25;
            lblStatus.Text = "Status:";
            // 
            // numDuration
            // 
            numDuration.Location = new Point(406, 501);
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(110, 27);
            numDuration.TabIndex = 40;
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Location = new Point(395, 478);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(124, 20);
            lblDuration.TabIndex = 39;
            lblDuration.Text = "Duration (weeks):";
            // 
            // numAvailableSlots
            // 
            numAvailableSlots.Location = new Point(276, 501);
            numAvailableSlots.Name = "numAvailableSlots";
            numAvailableSlots.Size = new Size(110, 27);
            numAvailableSlots.TabIndex = 38;
            // 
            // lblAvailableSlots
            // 
            lblAvailableSlots.AutoSize = true;
            lblAvailableSlots.Location = new Point(276, 478);
            lblAvailableSlots.Name = "lblAvailableSlots";
            lblAvailableSlots.Size = new Size(110, 20);
            lblAvailableSlots.TabIndex = 37;
            lblAvailableSlots.Text = "Available Slots:";
            // 
            // frmEditPosition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 627);
            Controls.Add(numDuration);
            Controls.Add(lblDuration);
            Controls.Add(numAvailableSlots);
            Controls.Add(lblAvailableSlots);
            Controls.Add(dtpApplicationDeadline);
            Controls.Add(lblApplicationDeadline);
            Controls.Add(dtpEndDate);
            Controls.Add(lblEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(lblStartDate);
            Controls.Add(txtStipend);
            Controls.Add(lblStipend);
            Controls.Add(txtLocation);
            Controls.Add(lblLocation);
            Controls.Add(cboStatus);
            Controls.Add(lblStatus);
            Controls.Add(txtRequirements);
            Controls.Add(lblRequirements);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdate);
            Controls.Add(lblPostedDate);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
            Controls.Add(txtPositionId);
            Controls.Add(lblPositionId);
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
        private Label lblPositionId;
        private TextBox txtPositionId;
        private TextBox txtTitle;
        private Label lblTitle;
        private Label lblPostedDate;
        private Button btnUpdate;
        private Button btnCancel;
        private TextBox txtRequirements;
        private Label lblRequirements;
        private TextBox txtDescription;
        private Label lblDescription;
        private DateTimePicker dtpApplicationDeadline;
        private Label lblApplicationDeadline;
        private DateTimePicker dtpEndDate;
        private Label lblEndDate;
        private DateTimePicker dtpStartDate;
        private Label lblStartDate;
        private TextBox txtStipend;
        private Label lblStipend;
        private TextBox txtLocation;
        private Label lblLocation;
        private ComboBox cboStatus;
        private Label lblStatus;
        private NumericUpDown numDuration;
        private Label lblDuration;
        private NumericUpDown numAvailableSlots;
        private Label lblAvailableSlots;
    }
}