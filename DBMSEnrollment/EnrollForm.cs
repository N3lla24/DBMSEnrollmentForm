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

        int? UserID;
        public EnrollmentForm(int? id)
        {
            UserID = id;
            try
            {
                var studid = db.STUDENT_VIEW_SP().SingleOrDefault(r => r.US_ID == UserID);
                var existenroll = db.CheckExistingEnrollment(studid.STUD_ID).SingleOrDefault();
                if (existenroll.EnrollmentCount != 0)
                {
                    MessageBox.Show("You Currently Have Exising Enrollment. Check your to enrollment tracker", "Existing Enrollment");
                    formload();
                }
            }
            catch
            {

            }
            InitializeComponent();
        }

        private void EnrollmentForm_Load(object sender, EventArgs e)
        {
            var user = db.USER_INFO().SingleOrDefault(r => r.US_ID == UserID);
            tbFName.Text = user.US_FNAME;
            tbMName.Text = user.US_MNAME;
            tbLName.Text = user.US_LNAME;
            dtpBDay.Value = user.US_BDAY;
            tbMobile.Text = user.US_PHONE;
            tbEmail.Text = user.US_EMAIL;
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
                string.IsNullOrWhiteSpace(tbAddress.Text) ||
                string.IsNullOrWhiteSpace(cbYearLvl.Text) ||
                string.IsNullOrWhiteSpace(cbSched.Text) ||
                string.IsNullOrWhiteSpace(cbCourse.Text))
            {
                MessageBox.Show("Please fill in all required fields before submitting.", "Validation Error");
                return;
            }
            int progid = 0;
            int courseid = 0;
            int insid = 0;
            if (cbCourse.Text == "BSIT") { progid = 2; courseid = 5; insid = 3; }
            if (cbCourse.Text == "BSIS") { progid = 3; courseid = 6; insid = 4; }
            if (cbCourse.Text == "BIT") { progid = 4; courseid = 7; insid = 5; }
            if (cbCourse.Text == "BScPE") { progid = 5; courseid = 8; insid = 6; }

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
                try
                {
                    db.STUDENT_SAVE_SP(tbFName.Text, tbMName.Text, tbLName.Text, cbGender.Text, dtpBDay.Value, tbMobile.Text, tbEmail.Text, tbAddress.Text, Convert.ToInt16(cbYearLvl.Text), cbSched.Text, UserID);
                    var studid = db.STUDENT_VIEW_SP().SingleOrDefault(r => r.US_ID == UserID);
                    db.ENROLLMENT_SAVE_SP(DateTime.Now, DateTime.Now.TimeOfDay, "Pending", studid.STUD_ID, progid, courseid);

                    clear();
                    tbReminder.Visible = false;
                    formload();
                    MessageBox.Show("Enrollment Form Submitted\nTrack your enrollment process by using the Enrollment Process Tracker in the Main Page", "Submission Complete", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
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
            Main main = new Main(UserID);
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
