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
    public partial class AdminInstructor : Form
    {
        int insID;
        int? adminId;
        string gender;
        public AdminInstructor(int? adminID)
        {
            InitializeComponent();
            dataGridView1.DataSource = db.INSTRUCTOR_VIEW_SP();
            adminId = adminID;
        }
        DataClasses1DataContext db = new DataClasses1DataContext();

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            db.INSTRUCTOR_UPDATE_SP(insID, tbFName.Text, tbMName.Text, tbLName.Text, dtpBDay.Value, tbPhone.Text, tbEmail.Text, cbStatus.Text);
            MessageBox.Show("Information successfully update!", "Information Update");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this instructor?", "Delete User", MessageBoxButtons.OKCancel);

            if (!string.IsNullOrEmpty(tbFName.Text) &&
            !string.IsNullOrEmpty(tbLName.Text) &&
            !string.IsNullOrEmpty(dtpBDay.Text) &&
            !string.IsNullOrEmpty(tbEmail.Text) &&
            !string.IsNullOrEmpty(tbPhone.Text) &&
            !string.IsNullOrEmpty(cbStatus.Text))
            {
                if (result == DialogResult.OK)
                {
                    db.INSTRUCTOR_DELETE_SP(insID);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbFName.Text = string.Empty;
            tbMName.Text = string.Empty;
            tbLName.Text = string.Empty;
            dtpBDay.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbPhone.Text = string.Empty;
            cbStatus.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = tbSearch.Text;
            var searchResult = db.INSTRUCTOR_SEARCH_SP(search);

            dataGridView1.DataSource = searchResult.ToList();
        }

        private void btnEnrollForm_Return_Click(object sender, EventArgs e)
        {
            AdminMain adminMain = new AdminMain(adminId);
            this.Hide();
            adminMain.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the values from the clicked row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Update textboxes based on the column index
                insID = Convert.ToInt32(selectedRow.Cells[0].Value);
                tbFName.Text = selectedRow.Cells[1].Value.ToString();
                tbMName.Text = selectedRow.Cells[2].Value.ToString();
                tbLName.Text = selectedRow.Cells[3].Value.ToString();
                dtpBDay.Text = selectedRow.Cells[5].Value.ToString();
                tbEmail.Text = selectedRow.Cells[7].Value.ToString();
                tbPhone.Text = selectedRow.Cells[6].Value.ToString();
                cbStatus.Text = selectedRow.Cells[8].Value.ToString();
                gender = selectedRow.Cells[4].Value.ToString();
            }
        }
    }
}
