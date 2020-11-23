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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

       

        
        private void Button1_Click(object sender, EventArgs e)
        {
            userTransition fs = new userTransition();
            this.Hide();
            fs.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            administratorTransition at = new administratorTransition();
            this.Hide();
            at.Show();
        }
    }
}
