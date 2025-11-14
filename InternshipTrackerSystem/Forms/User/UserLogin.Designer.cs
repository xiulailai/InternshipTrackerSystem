namespace InternshipTrackerSystem.Forms
{
    partial class frmUserLogin
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
            lblEmail = new Label();
            lblPassword = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            lblTitle = new Label();
            lblLogin = new Label();
            SuspendLayout();
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(30, 100);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(60, 23);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email: ";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(30, 170);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(84, 23);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(30, 130);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 27);
            txtEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.Location = new Point(30, 200);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 27);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(30, 250);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 30);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(140, 250);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 30);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(30, 55);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(228, 23);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "to Internship Tracker System";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogin.Location = new Point(30, 20);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(82, 32);
            lblLogin.TabIndex = 5;
            lblLogin.Text = "Log In";
            // 
            // frmUserLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(245, 248, 250);
            ClientSize = new Size(312, 303);
            Controls.Add(lblLogin);
            Controls.Add(lblTitle);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblPassword);
            Controls.Add(lblEmail);
            Font = new Font("Segoe UI", 10F);
            MaximizeBox = false;
            Name = "frmUserLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Internship Tracker System";
            FormClosed += frmUserLogin_FormClosed;
            Load += frmUserLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmail;
        private Label lblPassword;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private Label lblTitle;
        private Label lblLogin;
    }
}