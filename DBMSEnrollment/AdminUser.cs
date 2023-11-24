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


        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnEnrollForm_Return_Click(object sender, EventArgs e)
        {
            AdminMain adminMain = new AdminMain();
            this.Hide();
            adminMain.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    /*db.USER_DELETE_SP();*/
                    AdminMain adminMain = new AdminMain();
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
            dtpBDay.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbPhone.Text = string.Empty;
            cbRole.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = tbSearch.Text;
            /*var searchResult = db.USER_SEARCH_SP();

            dataGridView1.DataSource = searchResult.ToList();*/
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*db.USER_UPDATE_SP();*/
            MessageBox.Show("Information successfully update!", "Information Update");
        }
    }
}
