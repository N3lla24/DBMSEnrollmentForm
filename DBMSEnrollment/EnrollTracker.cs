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
    public partial class EnrollTracker : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public EnrollTracker()
        {
            InitializeComponent();
            /*db.ENROLLMENT_DISPLAY_SP();*/
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Main form1 = new Main();
            this.Hide();
            form1.ShowDialog();
        }

        private void EnrollTracker_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
