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
    public partial class AdminAdmin : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        int? adminId;
        int userid;
        public AdminAdmin(int? adminID)
        {
            InitializeComponent();
            dataGridView1.DataSource = db.ADMIN_VIEW_SP();
            adminId = adminID;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = tbSearch.Text;
            var searchResult = db.ADMIN_SEARCH_SP(search);

            dataGridView1.DataSource = searchResult.ToList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            db.ADMIN_UPDATE_SP(userid, tbFName.Text, tbMName.Text, tbLName.Text, tbEmail.Text, tbPhone.Text);
            MessageBox.Show("Information successfully update!", "Information Update");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this admin?", "Delete Admin", MessageBoxButtons.OKCancel);

            if (!string.IsNullOrEmpty(tbFName.Text) &&
            !string.IsNullOrEmpty(tbLName.Text) &&
            !string.IsNullOrEmpty(tbEmail.Text) &&
            !string.IsNullOrEmpty(tbPhone.Text))
            {
                if (result == DialogResult.OK)
                {
                    /*db.ADMIN_DELETE_SP();*/
                    AdminMain adminMain = new AdminMain(adminId);
                    this.Hide();
                    adminMain.Show();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbFName.Text = string.Empty;
            tbMName.Text = string.Empty;
            tbLName.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbPhone.Text = string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEnrollForm_Return_Click(object sender, EventArgs e)
        {
            AdminMain adminMain = new AdminMain(adminId);
            this.Hide();
            adminMain.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the values from the clicked row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Update textboxes based on the column index
                userid = Convert.ToInt32(selectedRow.Cells[0].Value);
                tbFName.Text = selectedRow.Cells[1].Value.ToString();
                tbMName.Text = selectedRow.Cells[2].Value.ToString();
                tbLName.Text = selectedRow.Cells[3].Value.ToString();
                tbEmail.Text = selectedRow.Cells[5].Value.ToString();
                tbPhone.Text = selectedRow.Cells[4].Value.ToString();
            }
        }
    }
}
