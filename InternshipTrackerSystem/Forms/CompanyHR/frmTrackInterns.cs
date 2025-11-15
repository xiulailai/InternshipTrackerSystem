using InternshipTrackerSystem.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InternshipTrackerSystem.Forms.CompanyHR
{
    public partial class frmTrackInterns : Form
    {
        private readonly int _companyId;   // company identifier
        private DataTable _buffer;

        public frmTrackInterns(int companyId)
        {
            InitializeComponent();
            _companyId = companyId;

            // build grid columns once
            BuildGridColumns();

            // wire events
            this.Load += frmTrackInterns_Load;
            cboStatus.SelectedIndexChanged += FilterChanged;
            txtSearch.TextChanged += FilterChanged;
            btnRefresh.Click += (_, __) => LoadData();
            dgvInterns.CellDoubleClick += DgvInterns_CellDoubleClick;
        }

        private void frmTrackInterns_Load(object sender, EventArgs e)
        {
            if (cboStatus.Items.Count == 0)
            {
                cboStatus.Items.AddRange(new object[]
                {
                    "All",
                    "Ongoing",
                    "Completed",
                    "Terminated"
                });
            }

            cboStatus.SelectedItem = "All";
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string status = (cboStatus.SelectedItem?.ToString() ?? "All").Trim();
                string search = (txtSearch.Text ?? string.Empty).Trim();

                // 🔗 Form → CompanyHRClass → DB
                _buffer = CompanyHRClass.GetInternsForHR(
                    _companyId,
                    status,
                    search);

                BindGrid(_buffer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to load interns.\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BindGrid(DataTable dt)
        {
            dgvInterns.AutoGenerateColumns = false;
            dgvInterns.DataSource = dt;

            // set date formats safely (works whether Name or DataPropertyName matches)
            SetDateFormat("StartDate");
            SetDateFormat("EndDate");
        }

        private void SetDateFormat(string prop)
        {
            var col = dgvInterns.Columns
                .Cast<DataGridViewColumn>()
                .FirstOrDefault(c =>
                    string.Equals(c.Name, prop, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(c.DataPropertyName, prop, StringComparison.OrdinalIgnoreCase));

            if (col != null)
            {
                col.DefaultCellStyle.Format = "yyyy-MM-dd";
            }
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DgvInterns_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = ((DataRowView)dgvInterns.Rows[e.RowIndex].DataBoundItem).Row;
            int internshipId = Convert.ToInt32(row["InternshipID"]); // identifier

            MessageBox.Show(
                $"Open details for Internship Identifier: {internshipId}",
                "Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // TODO: hook actual details form here
            // new frmInternshipDetails(internshipId).ShowDialog();
        }

        // === Columns (runtime) ===
        private void BuildGridColumns()
        {
            dgvInterns.Columns.Clear();
            dgvInterns.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn Col(string header, string prop, int fill = 100)
            {
                return new DataGridViewTextBoxColumn
                {
                    HeaderText = header,
                    DataPropertyName = prop,
                    Name = prop,   // critical: match name to property
                    FillWeight = fill,
                    ReadOnly = true,
                    SortMode = DataGridViewColumnSortMode.Automatic
                };
            }

            dgvInterns.Columns.AddRange(new DataGridViewColumn[]
            {
                Col("Student Name",                "StudentName",        140),
                Col("Student Identification Number","StudentIDNumber",   140),
                Col("Program",                     "Program",            110),
                Col("Position Title",              "PositionTitle",      140),
                Col("Status",                      "Status",             80),
                Col("Start Date",                  "StartDate",          95),
                Col("End Date",                    "EndDate",            95),
                Col("Supervisor Name",             "SupervisorName",     130),
            });

            dgvInterns.ReadOnly = true;
            dgvInterns.AllowUserToAddRows = false;
            dgvInterns.AllowUserToDeleteRows = false;
            dgvInterns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInterns.RowHeadersVisible = false;
            dgvInterns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
         
        }

        private void frmTrackInterns_Load_1(object sender, EventArgs e)
        {
            
        }
    }
}
