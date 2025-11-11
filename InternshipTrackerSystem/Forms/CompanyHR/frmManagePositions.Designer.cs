namespace InternshipTrackerSystem.Forms.CompanyHR
{
    partial class frmManagePositions
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
            label1 = new Label();
            lblCompanyName = new Label();
            btnCreateNew = new Button();
            btnRefresh = new Button();
            cboStatusFilter = new ComboBox();
            dgvPositions = new DataGridView();
            btnView = new Button();
            btnEdit = new Button();
            btnToggleStatus = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            databaseHelperBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dgvPositions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseHelperBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 24);
            label1.Name = "label1";
            label1.Size = new Size(208, 20);
            label1.TabIndex = 0;
            label1.Text = "Manage Internship Positions - ";
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(240, 24);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(69, 20);
            lblCompanyName.TabIndex = 1;
            lblCompanyName.Text = "loading...";
            // 
            // btnCreateNew
            // 
            btnCreateNew.Location = new Point(33, 67);
            btnCreateNew.Name = "btnCreateNew";
            btnCreateNew.Size = new Size(161, 29);
            btnCreateNew.TabIndex = 2;
            btnCreateNew.Text = "Create New Positions";
            btnCreateNew.UseVisualStyleBackColor = true;
            btnCreateNew.Click += btnCreateNew_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(209, 67);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(161, 29);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // cboStatusFilter
            // 
            cboStatusFilter.FormattingEnabled = true;
            cboStatusFilter.Items.AddRange(new object[] { "All", "Open", "Closed" });
            cboStatusFilter.Location = new Point(387, 67);
            cboStatusFilter.Name = "cboStatusFilter";
            cboStatusFilter.Size = new Size(151, 28);
            cboStatusFilter.TabIndex = 4;
            cboStatusFilter.SelectedIndexChanged += cboStatusFilter_SelectedIndexChanged;
            // 
            // dgvPositions
            // 
            dgvPositions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPositions.Location = new Point(36, 118);
            dgvPositions.Name = "dgvPositions";
            dgvPositions.RowHeadersWidth = 51;
            dgvPositions.Size = new Size(927, 188);
            dgvPositions.TabIndex = 5;
            dgvPositions.CellDoubleClick += dgvPositions_CellDoubleClick;
            dgvPositions.SelectionChanged += dgvPositions_SelectionChanged;
            // 
            // btnView
            // 
            btnView.Location = new Point(36, 331);
            btnView.Name = "btnView";
            btnView.Size = new Size(111, 29);
            btnView.TabIndex = 6;
            btnView.Text = "View Details";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(153, 331);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(116, 29);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit Position";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnToggleStatus
            // 
            btnToggleStatus.Location = new Point(275, 331);
            btnToggleStatus.Name = "btnToggleStatus";
            btnToggleStatus.Size = new Size(129, 29);
            btnToggleStatus.TabIndex = 8;
            btnToggleStatus.Text = "Toggle Status";
            btnToggleStatus.UseVisualStyleBackColor = true;
            btnToggleStatus.Click += btnToggleStatus_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(410, 331);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(116, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(847, 331);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(116, 29);
            btnBack.TabIndex = 10;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // databaseHelperBindingSource
            // 
            databaseHelperBindingSource.DataSource = typeof(Data.DatabaseHelper);
            // 
            // frmManagePositions
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 434);
            Controls.Add(btnBack);
            Controls.Add(btnDelete);
            Controls.Add(btnToggleStatus);
            Controls.Add(btnEdit);
            Controls.Add(btnView);
            Controls.Add(dgvPositions);
            Controls.Add(cboStatusFilter);
            Controls.Add(btnRefresh);
            Controls.Add(btnCreateNew);
            Controls.Add(lblCompanyName);
            Controls.Add(label1);
            Name = "frmManagePositions";
            Text = "Manage Positions";
            Load += frmManagePositions_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPositions).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseHelperBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblCompanyName;
        private Button btnCreateNew;
        private Button btnRefresh;
        private ComboBox cboStatusFilter;
        private DataGridView dgvPositions;
        private Button btnView;
        private Button btnEdit;
        private Button btnToggleStatus;
        private Button btnDelete;
        private Button btnBack;
        private BindingSource databaseHelperBindingSource;
    }
}