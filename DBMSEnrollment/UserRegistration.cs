﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBMSEnrollment
{
    public partial class UserRegistration : Form
    {
        public UserRegistration()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fname = fnametb.Text;
            string mname = mnametb.Text;
            string lname = lnametb.Text;
            DateTime bday = bdaydtp.Value;
            string email = emailtb.Text;
            string password = passwordtb.Text;
            string phone = phonetb.Text;
            string role = "User";


            Regex regexemail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$");
            Regex regexphone = new Regex(@"09\d{9}$");
            Match matchemail = regexemail.Match(email);
            Match matchphone = regexphone.Match(phone);
            string saveFail = "Saving Failed";

            if (matchemail.Success && matchphone.Success)
            {
                try
                {
                    db.USER_SAVE_SP(fname, mname, lname, bday, email, phone, password, role);
                    MessageBox.Show("Account created successfully!", "Registration Notice");
                    Login login = new Login();
                    this.Hide();
                    login.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), saveFail);
                }
            }
            else
            {
                if (matchemail.Success != true && matchphone.Success != true)
                {
                    MessageBox.Show("Phone number and email address format invalid. Try again!", saveFail);
                }
                else if (matchphone.Success != true)
                {
                    MessageBox.Show("Phone number format must be 11 digits and start with 09.", saveFail);
                }
                else if (matchemail.Success != true)
                {
                    MessageBox.Show("Email address format invalid. Try again!", saveFail);
                }
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
