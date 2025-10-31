namespace InternshipTrackerSystem.Forms.Supervisor
{
    partial class frmSupvEvaluation
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
            components = new System.ComponentModel.Container();
            databaseHelperBindingSource = new BindingSource(components);
            lblStudent = new Label();
            lblInternship = new Label();
            txtCompanyName = new TextBox();
            lblPeroformance = new Label();
            lblPunctuality = new Label();
            lblComunication = new Label();
            lblOverall = new Label();
            numPerformance = new NumericUpDown();
            numPunctuality = new NumericUpDown();
            numCommunication = new NumericUpDown();
            txtOverallScore = new TextBox();
            lblComments = new Label();
            txtComments = new TextBox();
            lblRecommend = new Label();
            txtRecommendations = new TextBox();
            btnSave = new Button();
            btnBack = new Button();
            lblComapny = new Label();
            txtInternship = new TextBox();
            txtStudents = new TextBox();
            btnUpdate = new Button();
            btnLoadExisting = new Button();
            lblRating = new Label();
            ((System.ComponentModel.ISupportInitialize)databaseHelperBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPerformance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPunctuality).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCommunication).BeginInit();
            SuspendLayout();
            // 
            // databaseHelperBindingSource
            // 
            databaseHelperBindingSource.DataSource = typeof(Data.DatabaseHelper);
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Font = new Font("Segoe UI", 10F);
            lblStudent.Location = new Point(30, 20);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new Size(78, 23);
            lblStudent.TabIndex = 1;
            lblStudent.Text = "Student: ";
            // 
            // lblInternship
            // 
            lblInternship.AutoSize = true;
            lblInternship.Font = new Font("Segoe UI", 10F);
            lblInternship.Location = new Point(30, 100);
            lblInternship.Name = "lblInternship";
            lblInternship.Size = new Size(96, 23);
            lblInternship.TabIndex = 2;
            lblInternship.Text = "Internship: ";
            // 
            // txtCompanyName
            // 
            txtCompanyName.Font = new Font("Segoe UI", 10F);
            txtCompanyName.Location = new Point(130, 58);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.ReadOnly = true;
            txtCompanyName.Size = new Size(125, 30);
            txtCompanyName.TabIndex = 3;
            // 
            // lblPeroformance
            // 
            lblPeroformance.AutoSize = true;
            lblPeroformance.Font = new Font("Segoe UI", 10F);
            lblPeroformance.Location = new Point(30, 147);
            lblPeroformance.Name = "lblPeroformance";
            lblPeroformance.Size = new Size(157, 23);
            lblPeroformance.TabIndex = 1;
            lblPeroformance.Text = "Performance Score:";
            // 
            // lblPunctuality
            // 
            lblPunctuality.AutoSize = true;
            lblPunctuality.Font = new Font("Segoe UI", 10F);
            lblPunctuality.Location = new Point(30, 187);
            lblPunctuality.Name = "lblPunctuality";
            lblPunctuality.Size = new Size(146, 23);
            lblPunctuality.TabIndex = 2;
            lblPunctuality.Text = "Punctuality Score:";
            // 
            // lblComunication
            // 
            lblComunication.AutoSize = true;
            lblComunication.Font = new Font("Segoe UI", 10F);
            lblComunication.Location = new Point(30, 227);
            lblComunication.Name = "lblComunication";
            lblComunication.Size = new Size(168, 23);
            lblComunication.TabIndex = 1;
            lblComunication.Text = "Comunication Score:";
            // 
            // lblOverall
            // 
            lblOverall.AutoSize = true;
            lblOverall.Font = new Font("Segoe UI", 10F);
            lblOverall.Location = new Point(30, 270);
            lblOverall.Name = "lblOverall";
            lblOverall.Size = new Size(114, 23);
            lblOverall.TabIndex = 2;
            lblOverall.Text = "Overall Score:";
            // 
            // numPerformance
            // 
            numPerformance.Font = new Font("Segoe UI", 10F);
            numPerformance.Location = new Point(200, 142);
            numPerformance.Name = "numPerformance";
            numPerformance.Size = new Size(150, 30);
            numPerformance.TabIndex = 4;
            // 
            // numPunctuality
            // 
            numPunctuality.Font = new Font("Segoe UI", 10F);
            numPunctuality.Location = new Point(200, 182);
            numPunctuality.Name = "numPunctuality";
            numPunctuality.Size = new Size(150, 30);
            numPunctuality.TabIndex = 4;
            // 
            // numCommunication
            // 
            numCommunication.Font = new Font("Segoe UI", 10F);
            numCommunication.Location = new Point(200, 222);
            numCommunication.Name = "numCommunication";
            numCommunication.Size = new Size(150, 30);
            numCommunication.TabIndex = 4;
            // 
            // txtOverallScore
            // 
            txtOverallScore.Font = new Font("Segoe UI", 10F);
            txtOverallScore.Location = new Point(150, 265);
            txtOverallScore.Name = "txtOverallScore";
            txtOverallScore.ReadOnly = true;
            txtOverallScore.Size = new Size(64, 30);
            txtOverallScore.TabIndex = 5;
            // 
            // lblComments
            // 
            lblComments.AutoSize = true;
            lblComments.Font = new Font("Segoe UI", 10F);
            lblComments.Location = new Point(30, 340);
            lblComments.Name = "lblComments";
            lblComments.Size = new Size(97, 23);
            lblComments.TabIndex = 6;
            lblComments.Text = "Comments:";
            // 
            // txtComments
            // 
            txtComments.Location = new Point(30, 370);
            txtComments.Name = "txtComments";
            txtComments.Size = new Size(400, 27);
            txtComments.TabIndex = 7;
            // 
            // lblRecommend
            // 
            lblRecommend.AutoSize = true;
            lblRecommend.Font = new Font("Segoe UI", 10F);
            lblRecommend.Location = new Point(30, 420);
            lblRecommend.Name = "lblRecommend";
            lblRecommend.Size = new Size(154, 23);
            lblRecommend.TabIndex = 6;
            lblRecommend.Text = "Recommendation: ";
            // 
            // txtRecommendations
            // 
            txtRecommendations.Location = new Point(30, 450);
            txtRecommendations.Name = "txtRecommendations";
            txtRecommendations.Size = new Size(400, 27);
            txtRecommendations.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(30, 500);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(330, 500);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 9;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lblComapny
            // 
            lblComapny.AutoSize = true;
            lblComapny.Font = new Font("Segoe UI", 10F);
            lblComapny.Location = new Point(30, 60);
            lblComapny.Name = "lblComapny";
            lblComapny.Size = new Size(87, 23);
            lblComapny.TabIndex = 2;
            lblComapny.Text = "Company:";
            // 
            // txtInternship
            // 
            txtInternship.Font = new Font("Segoe UI", 10F);
            txtInternship.Location = new Point(130, 98);
            txtInternship.Name = "txtInternship";
            txtInternship.ReadOnly = true;
            txtInternship.Size = new Size(125, 30);
            txtInternship.TabIndex = 3;
            // 
            // txtStudents
            // 
            txtStudents.Font = new Font("Segoe UI", 10F);
            txtStudents.Location = new Point(130, 17);
            txtStudents.Name = "txtStudents";
            txtStudents.ReadOnly = true;
            txtStudents.Size = new Size(125, 30);
            txtStudents.TabIndex = 3;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(130, 500);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 30);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnLoadExisting
            // 
            btnLoadExisting.Location = new Point(230, 500);
            btnLoadExisting.Name = "btnLoadExisting";
            btnLoadExisting.Size = new Size(100, 30);
            btnLoadExisting.TabIndex = 11;
            btnLoadExisting.Text = "Load Existing";
            btnLoadExisting.UseVisualStyleBackColor = true;
            btnLoadExisting.Click += btnLoadExisting_Click;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.Font = new Font("Segoe UI", 10F);
            lblRating.Location = new Point(30, 310);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(59, 23);
            lblRating.TabIndex = 12;
            lblRating.Text = "Rating";
            // 
            // frmSupvEvaluation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 548);
            Controls.Add(lblRating);
            Controls.Add(btnLoadExisting);
            Controls.Add(btnUpdate);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(txtRecommendations);
            Controls.Add(lblRecommend);
            Controls.Add(txtComments);
            Controls.Add(lblComments);
            Controls.Add(txtOverallScore);
            Controls.Add(numCommunication);
            Controls.Add(numPunctuality);
            Controls.Add(numPerformance);
            Controls.Add(txtStudents);
            Controls.Add(txtInternship);
            Controls.Add(txtCompanyName);
            Controls.Add(lblOverall);
            Controls.Add(lblPunctuality);
            Controls.Add(lblComunication);
            Controls.Add(lblPeroformance);
            Controls.Add(lblComapny);
            Controls.Add(lblInternship);
            Controls.Add(lblStudent);
            Name = "frmSupvEvaluation";
            Text = "Student Evaluation Form";
            Load += frmSupvEvaluation_Load;
            ((System.ComponentModel.ISupportInitialize)databaseHelperBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPerformance).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPunctuality).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCommunication).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblStudent;
        private BindingSource databaseHelperBindingSource;
        private Label lblInternship;
        private TextBox txtCompanyName;
        private Label lblPeroformance;
        private Label lblPunctuality;
        private Label lblComunication;
        private Label lblOverall;
        private NumericUpDown numPerformance;
        private NumericUpDown numPunctuality;
        private NumericUpDown numCommunication;
        private TextBox txtOverallScore;
        private Label lblComments;
        private TextBox txtComments;
        private Label lblRecommend;
        private TextBox txtRecommendations;
        private Button btnSave;
        private Button btnBack;
        private Label lblComapny;
        private TextBox txtInternship;
        private TextBox txtStudents;
        private Button btnUpdate;
        private Button btnLoadExisting;
        private Label lblRating;
    }
}