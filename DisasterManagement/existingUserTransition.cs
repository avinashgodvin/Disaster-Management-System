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
    public partial class existingUserTransition : Form
    {
        public existingUserTransition()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection("Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;



        private void Button1_Click(object sender, EventArgs e)
        {


            String name, pass;
            name = textBox1.Text;
            pass = textBox2.Text;







            if (true)
            {


                con.Open();
                String syntax = "SELECT * FROM userTable";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    if (name.Equals(dr.GetString(0).ToString()) && pass.Equals(dr.GetString(1).ToString()))
                    {

                        show_Disaster_List welcome = new show_Disaster_List();
                        this.Hide();
                        welcome.Show();
                    }
                }
                con.Close();
                label4.Show();
            }




           
            


            
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {
            userTransition ut = new userTransition();
            this.Hide();
            ut.Show();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }
    }
}
