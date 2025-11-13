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
            lblCompanyProfile.BorderStyle = BorderStyle.Fixed3D;
            lblCompanyProfile.Location = new Point(172, 20);
            lblCompanyProfile.Margin = new Padding(2, 0, 2, 0);
            lblCompanyProfile.Name = "lblCompanyProfile";
            lblCompanyProfile.Size = new Size(98, 17);
            lblCompanyProfile.TabIndex = 0;
            lblCompanyProfile.Text = "Company Profile";
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(13, 52);
            lblCompanyName.Margin = new Padding(2, 0, 2, 0);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(94, 15);
            lblCompanyName.TabIndex = 1;
            lblCompanyName.Text = "Company Name";
            lblCompanyName.Click += label1_Click;
            // 
            // lblIndustry
            // 
            lblIndustry.AutoSize = true;
            lblIndustry.Location = new Point(30, 90);
            lblIndustry.Margin = new Padding(2, 0, 2, 0);
            lblIndustry.Name = "lblIndustry";
            lblIndustry.Size = new Size(50, 15);
            lblIndustry.TabIndex = 2;
            lblIndustry.Text = "Industry";
            lblIndustry.Click += label2_Click;
            // 
            // lblContactEmail
            // 
            lblContactEmail.AutoSize = true;
            lblContactEmail.Location = new Point(19, 210);
            lblContactEmail.Margin = new Padding(2, 0, 2, 0);
            lblContactEmail.Name = "lblContactEmail";
            lblContactEmail.Size = new Size(81, 15);
            lblContactEmail.TabIndex = 3;
            lblContactEmail.Text = "Contact Email";
            // 
            // lblContactPhone
            // 
            lblContactPhone.AutoSize = true;
            lblContactPhone.Location = new Point(19, 169);
            lblContactPhone.Margin = new Padding(2, 0, 2, 0);
            lblContactPhone.Name = "lblContactPhone";
            lblContactPhone.Size = new Size(86, 15);
            lblContactPhone.TabIndex = 4;
            lblContactPhone.Text = "Contact Phone";
            // 
            // lblWebsite
            // 
            lblWebsite.AutoSize = true;
            lblWebsite.Location = new Point(31, 245);
            lblWebsite.Margin = new Padding(2, 0, 2, 0);
            lblWebsite.Name = "lblWebsite";
            lblWebsite.Size = new Size(49, 15);
            lblWebsite.TabIndex = 5;
            lblWebsite.Text = "Website";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(19, 281);
            lblDescription.Margin = new Padding(2, 0, 2, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 15);
            lblDescription.TabIndex = 6;
            lblDescription.Text = "Description";
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new Point(127, 49);
            txtCompanyName.Margin = new Padding(2, 1, 2, 1);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(316, 23);
            txtCompanyName.TabIndex = 7;
            // 
            // txtIndustry
            // 
            txtIndustry.Location = new Point(127, 82);
            txtIndustry.Margin = new Padding(2, 1, 2, 1);
            txtIndustry.Name = "txtIndustry";
            txtIndustry.Size = new Size(316, 23);
            txtIndustry.TabIndex = 8;
            // 
            // txtContactEmail
            // 
            txtContactEmail.Location = new Point(127, 202);
            txtContactEmail.Margin = new Padding(2, 1, 2, 1);
            txtContactEmail.Name = "txtContactEmail";
            txtContactEmail.Size = new Size(316, 23);
            txtContactEmail.TabIndex = 9;
            txtContactEmail.TextChanged += txtContactEmail_TextChanged;
            // 
            // txtContactPhone
            // 
            txtContactPhone.Location = new Point(127, 166);
            txtContactPhone.Margin = new Padding(2, 1, 2, 1);
            txtContactPhone.Name = "txtContactPhone";
            txtContactPhone.Size = new Size(317, 23);
            txtContactPhone.TabIndex = 10;
            txtContactPhone.TextChanged += txtPhone_TextChanged;
            // 
            // txtWebsite
            // 
            txtWebsite.Location = new Point(128, 237);
            txtWebsite.Margin = new Padding(2, 1, 2, 1);
            txtWebsite.Name = "txtWebsite";
            txtWebsite.Size = new Size(316, 23);
            txtWebsite.TabIndex = 11;
            txtWebsite.TextChanged += txtWebsite_TextChanged;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(127, 278);
            txtDescription.Margin = new Padding(2, 1, 2, 1);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(316, 23);
            txtDescription.TabIndex = 12;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(187, 330);
            btnSave.Margin = new Padding(2, 1, 2, 1);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(81, 22);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(30, 132);
            lblLocation.Margin = new Padding(2, 0, 2, 0);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(53, 15);
            lblLocation.TabIndex = 14;
            lblLocation.Text = "Location";
            lblLocation.Click += lblLocation_Click;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(127, 124);
            txtLocation.Margin = new Padding(2, 1, 2, 1);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(316, 23);
            txtLocation.TabIndex = 15;
            // 
            // frmHRProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 405);
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
            Margin = new Padding(2, 1, 2, 1);
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