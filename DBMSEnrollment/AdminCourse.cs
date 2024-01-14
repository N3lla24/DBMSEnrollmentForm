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
    public partial class AdminCourse : Form
    {
        int courseid;
        int? adminId;
        public AdminCourse(int? adminID)
        {
            InitializeComponent();
            dataGridView1.DataSource = db.VW_COURSE_INFO();
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
            /*var searchResult = db.COURSE_SEARCH_SP();

            dataGridView1.DataSource = searchResult.ToList();*/
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*db.COURSE_UPDATE_SP();*/
            MessageBox.Show("Information successfully update!", "Information Update");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this course?", "Delete Course", MessageBoxButtons.OKCancel);

            if (!string.IsNullOrEmpty(tbName.Text) &&
            !string.IsNullOrEmpty(tbUnits.Text) &&
            !string.IsNullOrEmpty(cbStatus.Text))
            {
                if (result == DialogResult.OK)
                {
                    /*db.COURSE_DELETE_SP();*/
                    AdminMain adminMain = new AdminMain(adminId);
                    this.Hide();
                    adminMain.Show();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbName.Text = string.Empty;
            tbUnits.Text = string.Empty;
            cbStatus.Text = string.Empty;

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
                courseid = Convert.ToInt32(selectedRow.Cells[0].Value);
                tbName.Text = selectedRow.Cells[2].Value.ToString();
                tbUnits.Text = selectedRow.Cells[3].Value.ToString();
                cbStatus.Text = selectedRow.Cells[4].Value.ToString();
            }
        }
    }
}
