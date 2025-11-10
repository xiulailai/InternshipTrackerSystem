using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment_student
{
    public partial class frmHomePage : Form
    {
        public frmHomePage()
        {
            InitializeComponent();
        }

        private void btnApplication_Click(object sender, EventArgs e)
        {
            Form3 mainPage = new Form3();
            mainPage.Show();
            this.Hide();
        }

        private void btnInternPosition_Click(object sender, EventArgs e)
        {
            frmInternshipposition mainPage = new frmInternshipposition();
            mainPage.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "Are you sure you want to exit the application?",
              "Exit",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question
             );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Form6 mainPage = new Form6();
            mainPage.Show();
            this.Hide();
        }
    }
}

