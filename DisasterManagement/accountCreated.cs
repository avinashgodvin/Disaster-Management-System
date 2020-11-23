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
    public partial class accountCreated : Form
    {
        public accountCreated()
        {
            InitializeComponent();
        }

        private void AccountCreated_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            existingUserTransition eut = new existingUserTransition();
            this.Hide();
            eut.Show();
        }
    }
}
