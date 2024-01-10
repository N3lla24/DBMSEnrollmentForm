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
    public partial class AdminUser : Form
    {
        public AdminUser()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();

        string userno = "";

        private void AdminUser_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void btnEnrollForm_Return_Click(object sender, EventArgs e)
        {
            AdminMain adminMain = new AdminMain();
            this.Hide();
            adminMain.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Delete User", MessageBoxButtons.OKCancel);

            if (!string.IsNullOrEmpty(tbFName.Text) &&
            !string.IsNullOrEmpty(tbLName.Text) &&
            !string.IsNullOrEmpty(dtpBDay.Text) &&
            !string.IsNullOrEmpty(tbEmail.Text) &&
            !string.IsNullOrEmpty(tbPhone.Text) &&
            !string.IsNullOrEmpty(cbRole.Text))
            {
                if (result == DialogResult.OK)
                {
                    db.USER_DELETE_SP(userno);
                    MessageBox.Show("User Deleted from the Database", "User Deleted");
                    LoadUserData();
                }
            }
            else
            {
                MessageBox.Show("Select a user first", "Info");
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
            cbRole.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = tbSearch.Text;
            dataGridView1.DataSource = db.USER_SEARCH_SP(search);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbFName.Text) &&
            !string.IsNullOrEmpty(tbLName.Text) &&
            !string.IsNullOrEmpty(dtpBDay.Text) &&
            !string.IsNullOrEmpty(tbEmail.Text) &&
            !string.IsNullOrEmpty(tbPhone.Text) &&
            !string.IsNullOrEmpty(cbRole.Text))
            {
                try
                {
                    db.USER_UPDATE_SP(userno, tbFName.Text, tbMName.Text, tbLName.Text, dtpBDay.Value, tbEmail.Text, tbPhone.Text, cbRole.Text);
                    MessageBox.Show("Information successfully update!", "Information Update");
                    LoadUserData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Update Error");
                }
            }
            else
            {
                MessageBox.Show("Select a user first", "Info");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the values from the clicked row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Update textboxes based on the column index
                userno = selectedRow.Cells[0].Value.ToString();
                tbFName.Text = selectedRow.Cells[1].Value.ToString();
                tbMName.Text = selectedRow.Cells[2].Value.ToString();
                tbLName.Text = selectedRow.Cells[3].Value.ToString();
                dtpBDay.Text = selectedRow.Cells[4].Value.ToString();
                tbEmail.Text = selectedRow.Cells[5].Value.ToString();
                tbPhone.Text = selectedRow.Cells[6].Value.ToString();
                cbRole.Text = selectedRow.Cells[7].Value.ToString();
            }
        }
        private void LoadUserData()
        {
            // Assuming db is an instance of your data context or repository
            dataGridView1.DataSource = db.USER_VIEW_SP();
        }
    }
}
