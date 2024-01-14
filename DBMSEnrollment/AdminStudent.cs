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
    public partial class AdminStudent : Form
    {
        int studid;
        int? adminId;
        public AdminStudent(int? adminID)
        {
            InitializeComponent();
            dataGridView1.DataSource = db.STUDENT_VIEW_SP();
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
            var searchResult = db.STUDENT_SEARCH_SP(search);

            dataGridView1.DataSource = searchResult.ToList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            db.STUDENT_UPDATE_SP(studid, tbFName.Text, tbMName.Text, tbLName.Text, dtpBDay.Value, tbEmail.Text, tbPhone.Text, Convert.ToInt32(cbYrLvl.Text), cbSched.Text);
            MessageBox.Show("Information successfully update!", "Information Update");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this student?", "Delete Student", MessageBoxButtons.OKCancel);

            if (!string.IsNullOrEmpty(tbFName.Text) &&
            !string.IsNullOrEmpty(tbLName.Text) &&
            !string.IsNullOrEmpty(dtpBDay.Text) &&
            !string.IsNullOrEmpty(tbEmail.Text) &&
            !string.IsNullOrEmpty(tbPhone.Text) &&
            !string.IsNullOrEmpty(cbYrLvl.Text) &&
            !string.IsNullOrEmpty(cbSched.Text))
            {
                if (result == DialogResult.OK)
                {
                    db.STUDENT_DELETE_SP(studid);
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
            cbYrLvl.Text = string.Empty;
            cbSched.Text = string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the values from the clicked row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Update textboxes based on the column index
                studid = Convert.ToInt16(selectedRow.Cells[0].Value);
                tbFName.Text = selectedRow.Cells[2].Value.ToString();
                tbMName.Text = selectedRow.Cells[3].Value.ToString();
                tbLName.Text = selectedRow.Cells[4].Value.ToString();
                dtpBDay.Text = selectedRow.Cells[6].Value.ToString();
                tbEmail.Text = selectedRow.Cells[9].Value.ToString();
                tbPhone.Text = selectedRow.Cells[8].Value.ToString();
                cbYrLvl.Text = selectedRow.Cells[11].Value.ToString();
                cbSched.Text = selectedRow.Cells[12].Value.ToString();
            }
        }


    }
}
