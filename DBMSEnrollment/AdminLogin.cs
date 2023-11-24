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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Check acc in db
            /*string email = tbEmail.Text;
            string password = tbPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Email and password cannot be empty.", "Validation Error");
                return; 
            }

            var result = db.ADMIN_ACCOUNT_EXIST_SP(email, password).SingleOrDefault();

            if (result != null && result.AccountExists == 1)
            {
                int adminID = result.AdminID;

                // Pass admin information to the Main 
                AdminMain adminMain = new AdminMain();
                this.Hide();
                adminMain.Show();
            }
            else
            {
                MessageBox.Show("Account not found!", "Problem Occurred");
            }*/

            AdminMain adminMain = new AdminMain();
            this.Hide();
            adminMain.Show();
        }

        private void btnForgotPass_Click(object sender, EventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            LandingPage landpage = new LandingPage();
            this.Hide();
            landpage.ShowDialog();
        }

        private void btnMain_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
