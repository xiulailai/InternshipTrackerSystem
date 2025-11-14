namespace InternshipTrackerSystem.Forms.Student_Lai
{
    partial class frmSearchInternship
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
            lblTitle = new Label();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblLocation = new Label();
            cmbLocation = new ComboBox();
            lblCompany = new Label();
            cmbCompany = new ComboBox();
            btnSearch = new Button();
            dgvInternships = new DataGridView();
            colPosition = new DataGridViewTextBoxColumn();
            colCompany = new DataGridViewTextBoxColumn();
            colLocation = new DataGridViewTextBoxColumn();
            colDeadline = new DataGridViewTextBoxColumn();
            colView = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgvInternships).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(16, 14);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1280, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SEARCH INTERNSHIPS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F);
            lblSearch.Location = new Point(40, 108);
            lblSearch.Margin = new Padding(4, 0, 4, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(65, 23);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(120, 103);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(399, 30);
            txtSearch.TabIndex = 2;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI", 10F);
            lblLocation.Location = new Point(560, 108);
            lblLocation.Margin = new Padding(4, 0, 4, 0);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(79, 23);
            lblLocation.TabIndex = 3;
            lblLocation.Text = "Location:";
            // 
            // cmbLocation
            // 
            cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocation.Font = new Font("Segoe UI", 10F);
            cmbLocation.FormattingEnabled = true;
            cmbLocation.Items.AddRange(new object[] { "All", "Kuala Lumpur", "Penang", "Johor Bahru", "Shah Alam", "Petaling Jaya" });
            cmbLocation.Location = new Point(657, 103);
            cmbLocation.Margin = new Padding(4, 5, 4, 5);
            cmbLocation.Name = "cmbLocation";
            cmbLocation.Size = new Size(239, 31);
            cmbLocation.TabIndex = 4;
            // 
            // lblCompany
            // 
            lblCompany.AutoSize = true;
            lblCompany.Font = new Font("Segoe UI", 10F);
            lblCompany.Location = new Point(560, 169);
            lblCompany.Margin = new Padding(4, 0, 4, 0);
            lblCompany.Name = "lblCompany";
            lblCompany.Size = new Size(87, 23);
            lblCompany.TabIndex = 5;
            lblCompany.Text = "Company:";
            // 
            // cmbCompany
            // 
            cmbCompany.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCompany.Font = new Font("Segoe UI", 10F);
            cmbCompany.FormattingEnabled = true;
            cmbCompany.Items.AddRange(new object[] { "All" });
            cmbCompany.Location = new Point(657, 165);
            cmbCompany.Margin = new Padding(4, 5, 4, 5);
            cmbCompany.Name = "cmbCompany";
            cmbCompany.Size = new Size(239, 31);
            cmbCompany.TabIndex = 6;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.Location = new Point(947, 123);
            btnSearch.Margin = new Padding(4, 5, 4, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(160, 62);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // dgvInternships
            // 
            dgvInternships.AllowUserToAddRows = false;
            dgvInternships.AllowUserToDeleteRows = false;
            dgvInternships.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInternships.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInternships.Columns.AddRange(new DataGridViewColumn[] { colPosition, colCompany, colLocation, colDeadline, colView });
            dgvInternships.Location = new Point(40, 246);
            dgvInternships.Margin = new Padding(4, 5, 4, 5);
            dgvInternships.Name = "dgvInternships";
            dgvInternships.ReadOnly = true;
            dgvInternships.RowHeadersVisible = false;
            dgvInternships.RowHeadersWidth = 51;
            dgvInternships.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInternships.Size = new Size(1227, 585);
            dgvInternships.TabIndex = 8;
            // 
            // colPosition
            // 
            colPosition.HeaderText = "Position Title";
            colPosition.MinimumWidth = 6;
            colPosition.Name = "colPosition";
            colPosition.ReadOnly = true;
            // 
            // colCompany
            // 
            colCompany.HeaderText = "Company";
            colCompany.MinimumWidth = 6;
            colCompany.Name = "colCompany";
            colCompany.ReadOnly = true;
            // 
            // colLocation
            // 
            colLocation.HeaderText = "Location";
            colLocation.MinimumWidth = 6;
            colLocation.Name = "colLocation";
            colLocation.ReadOnly = true;
            // 
            // colDeadline
            // 
            colDeadline.HeaderText = "Deadline";
            colDeadline.MinimumWidth = 6;
            colDeadline.Name = "colDeadline";
            colDeadline.ReadOnly = true;
            // 
            // colView
            // 
            colView.FillWeight = 60F;
            colView.HeaderText = "";
            colView.MinimumWidth = 6;
            colView.Name = "colView";
            colView.ReadOnly = true;
            colView.Text = "View";
            colView.UseColumnTextForButtonValue = true;
            // 
            // frmSearchInternship
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1312, 863);
            Controls.Add(dgvInternships);
            Controls.Add(btnSearch);
            Controls.Add(cmbCompany);
            Controls.Add(lblCompany);
            Controls.Add(cmbLocation);
            Controls.Add(lblLocation);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmSearchInternship";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Search Internships";
            ((System.ComponentModel.ISupportInitialize)dgvInternships).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvInternships;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeadline;
        private System.Windows.Forms.DataGridViewButtonColumn colView;
    }

    #endregion
}
