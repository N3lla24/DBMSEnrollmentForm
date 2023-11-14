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
            forminputview();
            tbReminder.Visible = true;
            DialogResult msgreview = MessageBox.Show("Before submitting REVIEW your information inputted as you can't edit it once already submitted.\nPress Okay to submit, Cancel to return", "Reminder", MessageBoxButtons.OKCancel);
            if(msgreview == DialogResult.OK)
            {
                MessageBox.Show("Enrollment Form Submitted\nTrack your enrollment process by using the Enrollment Process Tracker in the Main Page", "Sumbission Complete", MessageBoxButtons.OK);
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
            lblEnrollForm_Name.Text = tbFName.Text + " " + tbMName.Text + " " + tbLName.Text;
            lblEnrollForm_Bday.Text = dtpBDay.Text ;
            lblEnrollForm_Gender.Text = cbGender.Text ;
            lblEnrollForm_MobNum.Text = tbMobile.Text ;
            lblEnrollForm_Email.Text = tbEmail.Text ;
            lblEnrollForm_HomeAdd.Text = tbAddress.Text ;
            lblEnrollForm_Course.Text = cbCourse.Text;
            lblEnrollForm_YearLvl.Text = cbYearLvl.Text ;
            lblEnrollForm_ClassSched.Text = cbSched.Text ;
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
            lblEnrollForm_Name.Text = string.Empty;
            lblEnrollForm_Bday.Text = string.Empty;
            lblEnrollForm_Gender.Text = string.Empty;
            lblEnrollForm_MobNum.Text = string.Empty;
            lblEnrollForm_Email.Text = string.Empty;
            lblEnrollForm_HomeAdd.Text = string.Empty;
            lblEnrollForm_Course.Text = string.Empty;
            lblEnrollForm_YearLvl.Text = string.Empty;
            lblEnrollForm_ClassSched.Text = string.Empty;
        }

        private void formload()
        {
            Main main = new Main();
            this.Hide();
            main.ShowDialog();
        }
    }
}
