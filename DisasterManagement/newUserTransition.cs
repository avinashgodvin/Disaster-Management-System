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
    public partial class newUserTransition : Form
    {
        public newUserTransition()
        {
            InitializeComponent();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");
            SqlCommand cmd;
            SqlDataReader dr;


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

                    if (name.Equals(dr.GetString(0).ToString()))
                    {
                        label4.Show();
                    }
                }
                con.Close();
             
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String pass, pass1;
            pass = textBox2.Text;
            pass1 = textBox3.Text;



            if (!pass.Equals(pass1))
            {
                label7.Show();
            }
            else
            {

                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");

                SqlCommand cmd = new SqlCommand("newUserAdd_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userName", textBox1.Text);
                cmd.Parameters.AddWithValue("@userPassword", textBox2.Text);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" INVALID OPERATION : " + ex);
                }
                con.Close();


                accountCreated ac = new accountCreated();
                this.Hide();
                ac.Show();

            }
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Hide();
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

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }
    }
} 
