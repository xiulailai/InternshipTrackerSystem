namespace InternshipTrackerSystem.Forms.Supervisor
{
    partial class frmSupvNotification
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
            dgvNotifications = new DataGridView();
            databaseHelperBindingSource = new BindingSource(components);
            btnMarkAllRead = new Button();
            btnRefresh = new Button();
            lblStatus = new Label();
            chkUnreadOnly = new CheckBox();
            lblUnreadCount = new Label();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseHelperBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvNotifications
            // 
            dgvNotifications.AllowUserToAddRows = false;
            dgvNotifications.AllowUserToDeleteRows = false;
            dgvNotifications.AutoGenerateColumns = false;
            dgvNotifications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNotifications.DataSource = databaseHelperBindingSource;
            dgvNotifications.Location = new Point(30, 90);
            dgvNotifications.Name = "dgvNotifications";
            dgvNotifications.ReadOnly = true;
            dgvNotifications.RowHeadersWidth = 51;
            dgvNotifications.Size = new Size(820, 188);
            dgvNotifications.TabIndex = 0;
            dgvNotifications.CellContentClick += dgvNotifications_CellContentClick;
            dgvNotifications.CellDoubleClick += dgvNotifications_CellDoubleClick;
            dgvNotifications.CellFormatting += dgvNotifications_CellFormatting;
            dgvNotifications.SelectionChanged += dgvNotifications_SelectionChanged;
            // 
            // databaseHelperBindingSource
            // 
            databaseHelperBindingSource.DataSource = typeof(Data.DatabaseHelper);
            // 
            // btnMarkAllRead
            // 
            btnMarkAllRead.Location = new Point(150, 300);
            btnMarkAllRead.Name = "btnMarkAllRead";
            btnMarkAllRead.Size = new Size(115, 30);
            btnMarkAllRead.TabIndex = 3;
            btnMarkAllRead.Text = "Mark All Read";
            btnMarkAllRead.UseVisualStyleBackColor = true;
            btnMarkAllRead.Click += btnMarkAsRead_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(30, 300);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(115, 30);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(30, 50);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(49, 20);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Status";
            // 
            // chkUnreadOnly
            // 
            chkUnreadOnly.AutoSize = true;
            chkUnreadOnly.Location = new Point(150, 18);
            chkUnreadOnly.Name = "chkUnreadOnly";
            chkUnreadOnly.Size = new Size(79, 24);
            chkUnreadOnly.TabIndex = 8;
            chkUnreadOnly.Text = "Unread";
            chkUnreadOnly.UseVisualStyleBackColor = true;
            chkUnreadOnly.CheckedChanged += checkUnreadOnly_CheckedChanged;
            // 
            // lblUnreadCount
            // 
            lblUnreadCount.AutoSize = true;
            lblUnreadCount.Location = new Point(30, 20);
            lblUnreadCount.Name = "lblUnreadCount";
            lblUnreadCount.Size = new Size(100, 20);
            lblUnreadCount.TabIndex = 10;
            lblUnreadCount.Text = "Unread Count";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(270, 300);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(115, 30);
            btnBack.TabIndex = 11;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // frmSupvNotification
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 353);
            Controls.Add(btnBack);
            Controls.Add(lblUnreadCount);
            Controls.Add(chkUnreadOnly);
            Controls.Add(lblStatus);
            Controls.Add(btnRefresh);
            Controls.Add(btnMarkAllRead);
            Controls.Add(dgvNotifications);
            Name = "frmSupvNotification";
            Text = "Notification";
            FormClosing += frmSupvNotification_FormClosing;
            Load += frmSupvNotification_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseHelperBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvNotifications;
        private BindingSource databaseHelperBindingSource;
        private Button btnMarkAllRead;
        private Button btnRefresh;
        private Label lblStatus;
        private CheckBox chkUnreadOnly;
        private Label lblUnreadCount;
        private Button btnBack;
    }
}