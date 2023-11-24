using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DBMSEnrollment
{
    public partial class EnrollmentForm : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
       
        public EnrollmentForm()
        {
            InitializeComponent();
        }
        
        private void EnrollmentForm_Load(object sender, EventArgs e)
        {
            tbReminder.Visible = false;
        }
        
        private void btnReturn_Click(object sender, EventArgs e)
        {
            formload();
        }

        private void EnrollmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnEnrollForm_Submit_Click(object sender, EventArgs e)
        {
            // Check if any of the required textboxes (except middle name) is empty
            if (string.IsNullOrWhiteSpace(tbFName.Text) ||
                string.IsNullOrWhiteSpace(tbLName.Text) ||
                string.IsNullOrWhiteSpace(dtpBDay.Text) ||
                string.IsNullOrWhiteSpace(cbGender.Text) ||
                string.IsNullOrWhiteSpace(tbMobile.Text) ||
                string.IsNullOrWhiteSpace(tbEmail.Text) ||
                string.IsNullOrWhiteSpace(tbPassword.Text) ||
                string.IsNullOrWhiteSpace(tbAddress.Text) ||
                string.IsNullOrWhiteSpace(cbYearLvl.Text) ||
                string.IsNullOrWhiteSpace(cbSched.Text) ||
                string.IsNullOrWhiteSpace(cbCourse.Text))
            {
                MessageBox.Show("Please fill in all required fields before submitting.", "Validation Error");
                return; 
            }

            // Additional validation for email and phone number format
            Regex regexemail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$");
            Regex regexphone = new Regex(@"09\d{9}$");
            Match matchemail = regexemail.Match(tbEmail.Text);
            Match matchphone = regexphone.Match(tbMobile.Text);
            string saveFail = "Saving Failed";

            if (!matchemail.Success || !matchphone.Success)
            {
                MessageBox.Show("Please enter valid email and phone number formats.", saveFail);
                return; // Stop the enrollment process
            }

            // Continue with the enrollment process
            forminputview();
            tbReminder.Visible = true;
            DialogResult msgreview = MessageBox.Show("Before submitting, REVIEW the information as you can't edit it once submitted.\n\nPress Okay to submit, Cancel to review", "Reminder", MessageBoxButtons.OKCancel);

            if (msgreview == DialogResult.OK)
            {
                /*db.ENROLLMENT_SAVE_SP(tbFName.Text, tbMName.Text, tbLName.Text, cbGender.Text, dtpBDay.Text, tbMobile.Text, tbEmail.Text, tbPassword.Text, tbAdress.Text, cbYearLvl.Text, cbCourse.Text);*/
                MessageBox.Show("Enrollment Form Submitted\nTrack your enrollment process by using the Enrollment Process Tracker in the Main Page", "Submission Complete", MessageBoxButtons.OK);
                clear();
                tbReminder.Visible = false;
                formload();
            }
            
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void forminputview()
        {
            lblFullName.Text = tbFName.Text + " " + tbMName.Text + " " + tbLName.Text;
            lblBirthdate.Text = dtpBDay.Text ;
            lblGender.Text = cbGender.Text ;
            lblMobile.Text = tbMobile.Text ;
            lblEmail.Text = tbEmail.Text ;
            lblAddress.Text = tbAddress.Text ;
            lblCourse.Text = cbCourse.Text;
            lblYear.Text = cbYearLvl.Text ;
            lblSchedule.Text = cbSched.Text ;
        }

        private void clear()
        {
            tbFName.Text = string.Empty;
            tbMName.Text = string.Empty;
            tbLName.Text = string.Empty;
            dtpBDay.Text = DateTime.Now.ToString();
            cbGender.Text = string.Empty;
            tbMobile.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbAddress.Text = string.Empty;
            cbYearLvl.Text = string.Empty;
            cbSched.Text = string.Empty;
            cbCourse.Text = string.Empty;
            lblFullName.Text = string.Empty;
            lblBirthdate.Text = string.Empty;
            lblGender.Text = string.Empty;
            lblMobile.Text = string.Empty;
            lblEmail.Text = string.Empty;
            lblAddress.Text = string.Empty;
            lblCourse.Text = string.Empty;
            lblYear.Text = string.Empty;
            lblSchedule.Text = string.Empty;
        }

        private void formload()
        {
            Main main = new Main();
            this.Hide();
            main.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
