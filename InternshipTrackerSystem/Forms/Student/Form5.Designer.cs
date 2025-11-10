namespace assignment_student
{
    partial class frmInternshipposition
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvInternPosition = new DataGridView();
            btnBack = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvInternPosition).BeginInit();
            SuspendLayout();
            // 
            // dgvInternPosition
            // 
            dgvInternPosition.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvInternPosition.ColumnHeadersHeight = 29;
            dgvInternPosition.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvInternPosition.DefaultCellStyle = dataGridViewCellStyle2;
            dgvInternPosition.Location = new Point(12, 47);
            dgvInternPosition.Name = "dgvInternPosition";
            dgvInternPosition.RowHeadersWidth = 51;
            dgvInternPosition.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvInternPosition.Size = new Size(776, 188);
            dgvInternPosition.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 260);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(182, 48);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back to Main Menu";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(174, 28);
            label1.TabIndex = 2;
            label1.Text = "Internship Position";
            // 
            // frmInternshipposition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnBack);
            Controls.Add(dgvInternPosition);
            Name = "frmInternshipposition";
            Text = "Form5";
            Load += Form5_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInternPosition).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvInternPosition;
        private Button btnBack;
        private Label label1;
    }
}