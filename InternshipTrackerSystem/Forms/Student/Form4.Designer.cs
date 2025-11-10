namespace assignment_student
{
    partial class frmHomePage
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
            btnApplication = new Button();
            btnInternPosition = new Button();
            btnReport = new Button();
            btnLogOut = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnApplication
            // 
            btnApplication.Location = new Point(51, 162);
            btnApplication.Name = "btnApplication";
            btnApplication.Size = new Size(199, 44);
            btnApplication.TabIndex = 0;
            btnApplication.Text = "My Application Page";
            btnApplication.UseVisualStyleBackColor = true;
            btnApplication.Click += btnApplication_Click;
            // 
            // btnInternPosition
            // 
            btnInternPosition.Location = new Point(51, 101);
            btnInternPosition.Name = "btnInternPosition";
            btnInternPosition.Size = new Size(199, 44);
            btnInternPosition.TabIndex = 1;
            btnInternPosition.Text = "Internship Position Page";
            btnInternPosition.UseVisualStyleBackColor = true;
            btnInternPosition.Click += btnInternPosition_Click;
            // 
            // btnReport
            // 
            btnReport.Location = new Point(51, 221);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(199, 44);
            btnReport.TabIndex = 2;
            btnReport.Text = "Report Page";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(51, 281);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(199, 44);
            btnLogOut.TabIndex = 3;
            btnLogOut.Text = "Log out";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(51, 44);
            label1.Name = "label1";
            label1.Size = new Size(172, 41);
            label1.TabIndex = 4;
            label1.Text = "Home Page";
            // 
            // frmHomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnLogOut);
            Controls.Add(btnReport);
            Controls.Add(btnInternPosition);
            Controls.Add(btnApplication);
            Name = "frmHomePage";
            Text = "Form4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnApplication;
        private Button btnInternPosition;
        private Button btnReport;
        private Button btnLogOut;
        private Label label1;
    }
}