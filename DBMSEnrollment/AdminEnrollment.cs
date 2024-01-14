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
    public partial class AdminEnrollment : Form
    {
        int? adminId;
        public AdminEnrollment(int? adminID)
        {
            InitializeComponent();
            dataGridView1.DataSource = db.ENROLLMENT_VIEW_SP();
            adminId = adminID;
        }
        DataClasses1DataContext db = new DataClasses1DataContext();

        private void btnEnrollForm_Return_Click(object sender, EventArgs e)
        {
            AdminMain adminMain = new AdminMain(adminId);
            this.Hide();
            adminMain.Show();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = tbSearch.Text;
            var searchResult = db.ENROLLMENT_SEARCH_SP(search);

            dataGridView1.DataSource = searchResult.ToList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            db.ENROLLMENT_UPDATE_SP(tbEnrollNo.Text, cbStatus.Text);
            
            MessageBox.Show("Information successfully update!", "Information Update");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this enrollment?", "Delete Enrollment", MessageBoxButtons.OKCancel);

            if (!string.IsNullOrEmpty(tbEnrollNo.Text) &&
            !string.IsNullOrEmpty(cbStatus.Text))
            {
                if (result == DialogResult.OK)
                {
                    db.ENROLLMENT_DELETE_SP(tbEnrollNo.Text);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbEnrollNo.Text = string.Empty;
            cbStatus.Text = string.Empty;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the values from the clicked row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Update textboxes based on the column index
                tbEnrollNo.Text = selectedRow.Cells[0].Value.ToString();
                cbStatus.Text = selectedRow.Cells[4].Value.ToString();
            }
        }
    }
}
