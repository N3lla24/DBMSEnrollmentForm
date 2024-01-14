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
    public partial class AdminMain : Form
    {
        int? adminId;
        public AdminMain(int? adminID)
        {
            adminId = adminID;
            InitializeComponent();
        }

        private void btnMain_Logout_Click(object sender, EventArgs e)
        {
            AdminLogin login = new AdminLogin();
            this.Hide();
            login.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            AdminUser adminUser = new AdminUser(adminId);
            this.Hide();
            adminUser.ShowDialog();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminAdmin adminAdmin = new AdminAdmin(adminId);
            this.Hide();
            adminAdmin.ShowDialog();
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            AdminCourse adminCourse = new AdminCourse(adminId);
            this.Hide();
            adminCourse.ShowDialog();
        }

        private void btnEnrollment_Click(object sender, EventArgs e)
        {
            AdminEnrollment adminEnrollment = new AdminEnrollment(adminId);
            this.Hide();
            adminEnrollment.ShowDialog();
        }

        private void btnInstructor_Click(object sender, EventArgs e)
        {
            AdminInstructor adminInstructor = new AdminInstructor(adminId);
            this.Hide();
            adminInstructor.ShowDialog();
        }

        private void btnProgram_Click(object sender, EventArgs e)
        {
            AdminProgram adminProgram = new AdminProgram(adminId);
            this.Hide();
            adminProgram.ShowDialog();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            AdminStudent adminStudent = new AdminStudent(adminId);
            this.Hide();
            adminStudent.ShowDialog();
        }
    }
}
