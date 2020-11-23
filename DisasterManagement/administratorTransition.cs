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
    public partial class administratorTransition : Form
    {
        public administratorTransition()
        {
            InitializeComponent();
        }

        private void AdministratorTransition_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }


        SqlConnection con = new SqlConnection("Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;


      private String getAdminName()
        {
            //fetch data from database
            con.Open();
            String syntax = "SELECT adminName FROM adminTable";
            cmd = new SqlCommand(syntax,con);
            dr = cmd.ExecuteReader();
            dr.Read();  
            String temp = dr[0].ToString();
            con.Close();
            return temp;
         }

       private String getAdminPassword()
        {
            //fetch data from database
            con.Open();
            String syntax = "SELECT adminPassword FROM adminTable";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String  temp =dr[0].ToString();
            con.Close();
            return temp;


        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
         
        String Aname = getAdminName(),
                Apass = getAdminPassword(), name, pass;
            name = textBox1.Text;
            pass = textBox2.Text;    

            if (name.Equals(Aname) && pass.Equals(Apass))
            {
                retriveOrDelete rd = new retriveOrDelete();
                this.Hide();
                rd.Show();
                
            }
            else
            {
               label4.Show();
            }
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
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
