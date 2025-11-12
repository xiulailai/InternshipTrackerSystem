namespace InternshipTrackerSystem.Forms.CompanyHR
{
    partial class frmHRProfile
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
            lblCompanyProfile = new Label();
            lblCompanyName = new Label();
            lblIndustry = new Label();
            lblContactEmail = new Label();
            lblContactPhone = new Label();
            lblWebsite = new Label();
            lblDescription = new Label();
            txtCompanyName = new TextBox();
            txtIndustry = new TextBox();
            txtContactEmail = new TextBox();
            txtContactPhone = new TextBox();
            txtWebsite = new TextBox();
            txtDescription = new TextBox();
            btnSave = new Button();
            lblLocation = new Label();
            txtLocation = new TextBox();
            SuspendLayout();
            // 
            // lblCompanyProfile
            // 
            lblCompanyProfile.AutoSize = true;
            lblCompanyProfile.Location = new Point(21, 22);
            lblCompanyProfile.Name = "lblCompanyProfile";
            lblCompanyProfile.Size = new Size(191, 32);
            lblCompanyProfile.TabIndex = 0;
            lblCompanyProfile.Text = "Company Profile";
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(25, 104);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(187, 32);
            lblCompanyName.TabIndex = 1;
            lblCompanyName.Text = "Company Name";
            lblCompanyName.Click += label1_Click;
            // 
            // lblIndustry
            // 
            lblIndustry.AutoSize = true;
            lblIndustry.Location = new Point(25, 174);
            lblIndustry.Name = "lblIndustry";
            lblIndustry.Size = new Size(100, 32);
            lblIndustry.TabIndex = 2;
            lblIndustry.Text = "Industry";
            lblIndustry.Click += label2_Click;
            // 
            // lblContactEmail
            // 
            lblContactEmail.AutoSize = true;
            lblContactEmail.Location = new Point(21, 378);
            lblContactEmail.Name = "lblContactEmail";
            lblContactEmail.Size = new Size(160, 32);
            lblContactEmail.TabIndex = 3;
            lblContactEmail.Text = "Contact Email";
            // 
            // lblContactPhone
            // 
            lblContactPhone.AutoSize = true;
            lblContactPhone.Location = new Point(21, 315);
            lblContactPhone.Name = "lblContactPhone";
            lblContactPhone.Size = new Size(171, 32);
            lblContactPhone.TabIndex = 4;
            lblContactPhone.Text = "Contact Phone";
            // 
            // lblWebsite
            // 
            lblWebsite.AutoSize = true;
            lblWebsite.Location = new Point(25, 433);
            lblWebsite.Name = "lblWebsite";
            lblWebsite.Size = new Size(99, 32);
            lblWebsite.TabIndex = 5;
            lblWebsite.Text = "Website";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(25, 498);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(135, 32);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Description";
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new Point(235, 104);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(468, 39);
            txtCompanyName.TabIndex = 7;
            // 
            // txtIndustry
            // 
            txtIndustry.Location = new Point(235, 174);
            txtIndustry.Name = "txtIndustry";
            txtIndustry.Size = new Size(468, 39);
            txtIndustry.TabIndex = 8;
            // 
            // txtContactEmail
            // 
            txtContactEmail.Location = new Point(235, 312);
            txtContactEmail.Name = "txtContactEmail";
            txtContactEmail.Size = new Size(468, 39);
            txtContactEmail.TabIndex = 9;
            // 
            // txtContactPhone
            // 
            txtContactPhone.Location = new Point(231, 375);
            txtContactPhone.Name = "txtContactPhone";
            txtContactPhone.Size = new Size(478, 39);
            txtContactPhone.TabIndex = 10;
            txtContactPhone.TextChanged += txtPhone_TextChanged;
            // 
            // txtWebsite
            // 
            txtWebsite.Location = new Point(231, 433);
            txtWebsite.Name = "txtWebsite";
            txtWebsite.Size = new Size(478, 39);
            txtWebsite.TabIndex = 11;
            txtWebsite.TextChanged += txtWebsite_TextChanged;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(231, 498);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(478, 39);
            txtDescription.TabIndex = 12;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(35, 590);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 46);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(21, 250);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(104, 32);
            lblLocation.TabIndex = 14;
            lblLocation.Text = "Location";
            lblLocation.Click += lblLocation_Click;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(231, 247);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(472, 39);
            txtLocation.TabIndex = 15;
            // 
            // frmHRProfile
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 708);
            Controls.Add(txtLocation);
            Controls.Add(lblLocation);
            Controls.Add(btnSave);
            Controls.Add(txtDescription);
            Controls.Add(txtWebsite);
            Controls.Add(txtContactPhone);
            Controls.Add(txtContactEmail);
            Controls.Add(txtIndustry);
            Controls.Add(txtCompanyName);
            Controls.Add(lblDescription);
            Controls.Add(lblWebsite);
            Controls.Add(lblContactPhone);
            Controls.Add(lblContactEmail);
            Controls.Add(lblIndustry);
            Controls.Add(lblCompanyName);
            Controls.Add(lblCompanyProfile);
            Name = "frmHRProfile";
            Text = "frmHRProfile";
            Load += frmHRProfile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCompanyProfile;
        private Label lblCompanyName;
        private Label lblIndustry;
        private Label lblContactEmail;
        private Label lblContactPhone;
        private Label lblWebsite;
        private Label lblDescription;
        private TextBox txtCompanyName;
        private TextBox txtIndustry;
        private TextBox txtContactEmail;
        private TextBox txtContactPhone;
        private TextBox txtWebsite;
        private TextBox txtDescription;
        private Button btnSave;
        private Label lblLocation;
        private TextBox txtLocation;
    }
}