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
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblRequirements = new Label();
            txtRequirements = new TextBox();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            btnSave = new Button();
            btnClear = new Button();
            btnCancel = new Button();
            lblLocation = new Label();
            txtLocation = new TextBox();
            txtStipend = new TextBox();
            lblStipend = new Label();
            lblStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            lblEndDate = new Label();
            lblApplicationDeadline = new Label();
            dtpApplicationDeadline = new DateTimePicker();
            lblAvailableSlots = new Label();
            numAvailableSlots = new NumericUpDown();
            numDuration = new NumericUpDown();
            lblDuration = new Label();
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
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 53);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(97, 20);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Position Title:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(12, 76);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(503, 27);
            txtTitle.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(12, 120);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(115, 20);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Job Description:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(12, 143);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(503, 62);
            txtDescription.TabIndex = 5;
            // 
            // lblRequirements
            // 
            lblRequirements.AutoSize = true;
            lblRequirements.Location = new Point(12, 220);
            lblRequirements.Name = "lblRequirements";
            lblRequirements.Size = new Size(103, 20);
            lblRequirements.TabIndex = 6;
            lblRequirements.Text = "Requirements:";
            // 
            // txtRequirements
            // 
            txtRequirements.Location = new Point(12, 243);
            txtRequirements.Multiline = true;
            txtRequirements.Name = "txtRequirements";
            txtRequirements.Size = new Size(503, 63);
            txtRequirements.TabIndex = 7;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(364, 318);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Status:";
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
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(14, 318);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(69, 20);
            lblLocation.TabIndex = 13;
            lblLocation.Text = "Location:";
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
            // lblStipend
            // 
            lblStipend.AutoSize = true;
            lblStipend.Location = new Point(191, 318);
            lblStipend.Name = "lblStipend";
            lblStipend.Size = new Size(63, 20);
            lblStipend.TabIndex = 15;
            lblStipend.Text = "Stipend:";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(14, 380);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(79, 20);
            lblStartDate.TabIndex = 17;
            lblStartDate.Text = "Start Date:";
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
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(274, 380);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(73, 20);
            lblEndDate.TabIndex = 19;
            lblEndDate.Text = "End Date:";
            // 
            // lblApplicationDeadline
            // 
            lblApplicationDeadline.AutoSize = true;
            lblApplicationDeadline.Location = new Point(14, 453);
            lblApplicationDeadline.Name = "lblApplicationDeadline";
            lblApplicationDeadline.Size = new Size(153, 20);
            lblApplicationDeadline.TabIndex = 21;
            lblApplicationDeadline.Text = "Application Deadline:";
            // 
            // dtpApplicationDeadline
            // 
            dtpApplicationDeadline.Location = new Point(12, 476);
            dtpApplicationDeadline.Name = "dtpApplicationDeadline";
            dtpApplicationDeadline.Size = new Size(242, 27);
            dtpApplicationDeadline.TabIndex = 22;
            // 
            // lblAvailableSlots
            // 
            lblAvailableSlots.AutoSize = true;
            lblAvailableSlots.Location = new Point(274, 453);
            lblAvailableSlots.Name = "lblAvailableSlots";
            lblAvailableSlots.Size = new Size(110, 20);
            lblAvailableSlots.TabIndex = 23;
            lblAvailableSlots.Text = "Available Slots:";
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
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Location = new Point(390, 453);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(124, 20);
            lblDuration.TabIndex = 25;
            lblDuration.Text = "Duration (weeks):";
            // 
            // frmCreatePosition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 594);
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
            Controls.Add(btnCancel);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(cboStatus);
            Controls.Add(lblStatus);
            Controls.Add(txtRequirements);
            Controls.Add(lblRequirements);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtTitle);
            Controls.Add(lblTitle);
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
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblRequirements;
        private TextBox txtRequirements;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Button btnSave;
        private Button btnClear;
        private Button btnCancel;
        private Label lblLocation;
        private TextBox txtLocation;
        private TextBox txtStipend;
        private Label lblStipend;
        private Label lblStartDate;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label lblEndDate;
        private Label lblApplicationDeadline;
        private DateTimePicker dtpApplicationDeadline;
        private Label lblAvailableSlots;
        private NumericUpDown numAvailableSlots;
        private NumericUpDown numDuration;
        private Label lblDuration;
    }
}