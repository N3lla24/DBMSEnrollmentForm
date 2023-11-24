using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMSEnrollment
{
    public partial class AdminProgram : Form
    {
        public AdminProgram()
        {
            InitializeComponent();
        }

        private void btnEnrollForm_Return_Click(object sender, EventArgs e)
        {
            AdminMain adminMain = new AdminMain();
            this.Hide();
            adminMain.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = tbSearch.Text;
            /*var searchResult = db.PROGRAM_SEARCH_SP();

            dataGridView1.DataSource = searchResult.ToList();*/
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*db.PROGRAM_UPDATE_SP();*/
            MessageBox.Show("Information successfully update!", "Information Update");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this program?", "Delete Program", MessageBoxButtons.OKCancel);

            if (!string.IsNullOrEmpty(tbDesc.Text) &&
            !string.IsNullOrEmpty(tbCredits.Text) &&
            !string.IsNullOrEmpty(cbStatus.Text))
            {
                if (result == DialogResult.OK)
                {
                    /*db.PROGRAM_DELETE_SP();*/
                    AdminMain adminMain = new AdminMain();
                    this.Hide();
                    adminMain.Show();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbDesc.Text = string.Empty;
            tbCredits.Text = string.Empty;
            cbStatus.Text = string.Empty;
        }
    }
}
