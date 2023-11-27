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
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) //admin button
        {
            AdminLogin admin = new AdminLogin();
            this.Hide();
            admin.Show();
        }

        private void button1_Click(object sender, EventArgs e) //user button
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
        }
    }
}
