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
        int? adminId;
        int progid;
        DataClasses1DataContext db = new DataClasses1DataContext();
        public AdminProgram(int? adminID)
        {
            InitializeComponent();
            dataGridView1.DataSource = db.PROGRAM_VIEW_SP();
            adminId = adminID;
        }

        private void btnEnrollForm_Return_Click(object sender, EventArgs e)
        {
            AdminMain adminMain = new AdminMain(adminId);
            this.Hide();
            adminMain.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = tbSearch.Text;
            var searchResult = db.PROGRAM_SEARCH_SP(search);

            dataGridView1.DataSource = searchResult.ToList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            db.PROGRAM_UPDATE_SP(progid, tbDesc.Text, Convert.ToInt32(tbCredits.Text), cbStatus.Text);
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
                    db.PROGRAM_DELETE_SP(progid);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the values from the clicked row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Update textboxes based on the column index
                progid = Convert.ToInt32(selectedRow.Cells[0].Value);
                tbDesc.Text = selectedRow.Cells[1].Value.ToString();
                tbCredits.Text = selectedRow.Cells[2].Value.ToString();
                cbStatus.Text = selectedRow.Cells[3].Value.ToString();
            }
        }
    }
}
