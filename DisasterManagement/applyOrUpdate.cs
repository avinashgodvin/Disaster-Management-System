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
    public partial class applyOrUpdate : Form
    {
        public applyOrUpdate()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            user_control1 uc1 = new user_control1();
            this.Hide();
            uc1.Show();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            user_control2 uc2 = new user_control2();
            this.Hide();
            uc2.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
    }
}
