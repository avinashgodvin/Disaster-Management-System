using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisasterManagement
{
    public partial class userTransition : Form
    {
        public userTransition()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            newUserTransition nUT = new newUserTransition();
            this.Hide();
            nUT.Show();
        }

        private void UserTransition_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            existingUserTransition eUT = new existingUserTransition();
            this.Hide();
            eUT.Show();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
    }
}
