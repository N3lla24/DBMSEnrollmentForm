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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        DataClasses1DataContext db = new DataClasses1DataContext();

        private void btnLogin_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Check acc in db
            string email = tbEmail.Text;
            string password = tbPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Email and password cannot be empty.", "Validation Error");
                return;
            }

            var result = db.USER_ACCOUNT_EXIST_SP(email, password).SingleOrDefault();

            if (result != null && result.AccountExists == 1)
            {
                int? userID = result.UserID;

                // Pass user information to the Main
                if(result.UserRole == "User")
                {
                    Main main = new Main(userID);
                    this.Hide();
                    main.ShowDialog();
                }
                if (result.UserRole == "Admin")
                {
                    AdminMain adminMain = new AdminMain(userID);
                    this.Hide();
                    adminMain.Show();
                }   
            }
            else
            {
                MessageBox.Show("Account not found!", "Problem Occurred");
            }

            /*Main main = new Main();
            this.Hide();
            main.ShowDialog();*/
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            UserRegistration userRegistration = new UserRegistration();
            this.Hide();
            userRegistration.ShowDialog();
        }

        private void btnForgotPass_Click(object sender, EventArgs e)
        {
            //code to open forgotpass form
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            LandingPage landpage = new LandingPage();
            this.Hide();
            landpage.ShowDialog();
        }
    }
}
