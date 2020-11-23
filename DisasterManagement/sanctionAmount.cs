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
    public partial class sanctionAmount : Form
    { 
        public sanctionAmount()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("ENTER AMMOUNT");
                textBox1.Focus();
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");


                SqlCommand cmd = new SqlCommand("deleteData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SSN", Convert.ToInt32(ssnText.Text));
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("AMOUNT SANCTIONED");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error occured " + ex);
                }
                con.Close();






                SqlCommand cmd1 = new SqlCommand("insertSanctionedAmount", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@SSN", Convert.ToInt32(ssnText.Text));
                cmd1.Parameters.AddWithValue("@sanctionedAmount", Convert.ToInt32(textBox1.Text));
                con.Open();
                try
                {
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error occured " + ex);
                }
                con.Close();



                retriveOrDelete rd = new retriveOrDelete();
                this.Hide();
                rd.Show();


            }




        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            



           

           
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            retriveOrDelete rd = new retriveOrDelete();
            this.Hide();
            rd.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            retriveOrDelete rd = new retriveOrDelete();
            this.Hide();
            rd.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");
           
                Boolean aa = false;
               
                SqlCommand cmd4;
                SqlDataReader dr4;


                String a = ssnText.Text;
                String b;
                con.Open();
                String syntax = "SELECT * FROM person";
                cmd4 = new SqlCommand(syntax, con);
                dr4 = cmd4.ExecuteReader();

                while (dr4.Read())
                {
                    b = Convert.ToString(dr4.GetInt32(0));


                    if (a.Equals(b))
                    {
                        aa = true;
                        break;
                    }

                }
                con.Close();
            if (aa == false)
            {
                MessageBox.Show("SSN DOES NOT EXIST");
                ssnText.Focus();
            }
            else
            {


                //SqlConnection con = new SqlConnection("Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");
                String qry = "SELECT * FROM PERSON WHERE SSN = " + int.Parse(ssnText.Text);
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("error occured " + exc);
                }
                con.Close();

                dataGridView1.DataSource = ds.Tables[0];
            }

            
        }

        private void enterAmountLeave(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                MessageBox.Show("ENTER AMMOUNT");
                textBox1.Focus();
            }
            

        }
    }
}
