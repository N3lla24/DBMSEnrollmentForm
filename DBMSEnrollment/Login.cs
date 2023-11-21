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
            //Check acc in db
            Main main = new Main();
            this.Hide();
            main.ShowDialog();
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
