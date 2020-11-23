using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DisasterManagement
{
    public partial class retriveOrDelete : Form
    {
        public retriveOrDelete()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            displayData dD = new displayData();
            this.Hide();
            dD.Show();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            sanctionAmount sA = new sanctionAmount();
            this.Hide();
            sA.Show();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            displaySanctionedData dD = new displaySanctionedData();
            this.Hide();
            dD.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            administratorTransition ad = new administratorTransition();
            this.Hide();
            ad.Show();
        }
    }
}
