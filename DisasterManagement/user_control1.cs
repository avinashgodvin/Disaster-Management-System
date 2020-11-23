using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DisasterManagement
{   
    public partial class user_control1 : Form
    { int t = 0;
     
        public user_control1()
        {
            InitializeComponent();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void User_control1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {



            if (ssnText.Text == "enter 10 digit number")
            {
                ssnText.Text = "";
            }

            if (phoneText.Text == "enter 10 digit number")
            {
                phoneText.Text = "";
            }


            if (incomeText.Text==""||propertyText.Text==""|| ssnText.Text == "" || fnameText.Text == "" || lnameText.Text == "" || mnameText.Text == "" || addressText.Text == "" || phoneText.Text == "" || estimatedText.Text == "" || phoneText.Text == "" || dnoText.Text == "" || noText.Text == "" || descText.Text == "")
            {
                MessageBox.Show("ALL FIELDS SHOULD BE FILLED");

            }
            else
            {






                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");

                SqlCommand cmd = new SqlCommand("insertion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SSN", Convert.ToInt32(ssnText.Text));
                cmd.Parameters.AddWithValue("@FName", fnameText.Text);
                cmd.Parameters.AddWithValue("@Lname", lnameText.Text);
                cmd.Parameters.AddWithValue("@Mname", mnameText.Text);
                cmd.Parameters.AddWithValue("@Address", addressText.Text);
                cmd.Parameters.AddWithValue("@Phone", Convert.ToInt64(phoneText.Text));
                cmd.Parameters.AddWithValue("@D_no", Convert.ToInt32(dnoText.Text));
                cmd.Parameters.AddWithValue("@noOfPerson", Convert.ToInt32(noText.Text));
                cmd.Parameters.AddWithValue("@income", Convert.ToInt32(incomeText.Text));
                cmd.Parameters.AddWithValue("@property", Convert.ToInt32(propertyText.Text));



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


                SqlCommand cmd1 = new SqlCommand("insertionLoss", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@SSN", Convert.ToInt64(ssnText.Text));
                cmd1.Parameters.AddWithValue("@RequestedAmount", Convert.ToInt32(amountText.Text));
                cmd1.Parameters.AddWithValue("@EstimatedLoss", Convert.ToInt32(estimatedText.Text));
                cmd1.Parameters.AddWithValue("@DescAboutLoss", descText.Text);
                con.Open();
                try
                {
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" INVALID OPERATION : " + ex);
                }
                con.Close();



                MessageBox.Show("SUBMITTED SUCCESSFULLY");

                applyOrUpdate au = new applyOrUpdate();
                this.Hide();
                au.Show();
            }

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FnameText_TextChanged(object sender, EventArgs e)
        {
            Boolean bb = false;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");
            SqlCommand cmd5;
            SqlDataReader dr5;


            String a = ssnText.Text;
            String b;
            con.Open();
            String syntax = "SELECT * FROM person";
            cmd5 = new SqlCommand(syntax, con);
            dr5 = cmd5.ExecuteReader();

            while (dr5.Read())
            {
                b = Convert.ToString(dr5.GetInt32(0));


                if (a.Equals(b))
                {
                   bb = true;
                    break;
                }
               
            }
            con.Close();
            if (bb == true)
            {
                MessageBox.Show("SSN ALREADY EXIST");
                ssnText.Focus();
            }

        }

        private void SsnText_TextChanged(object sender, EventArgs e)
        {
            Boolean aa= false;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");
            SqlCommand cmd4;
            SqlDataReader dr4;

           
           String a= dnoText.Text;
            String b;
            con.Open();
            String syntax = "SELECT * FROM disaster";
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
                MessageBox.Show("DISASTER NUMBER DOES NOT EXIST");
                dnoText.Focus();
            }  
        }

        private void ssnEnter(object sender, EventArgs e)
        {
            if(ssnText.Text== "enter 10 digit number")
            {
                ssnText.Text = "";          
            }
        }

        private void ssnLeave(object sender, EventArgs e)
        {
            


        }

        private void ssnCheck(object sender, EventArgs e)
        {
            if(ssnText.TextLength != 10)
            {
                MessageBox.Show("ENTER A VALID SSN");
                ssnText.Focus();
            }
     
        }

        private void PhoneText_TextChanged(object sender, EventArgs e)
        {

        }

        private void phoneEnter(object sender, EventArgs e)
        {
            if (phoneText.Text == "enter 10 digit number")
            {
                phoneText.Text = "";
            }
        }

        private void phoneleave(object sender, EventArgs e)
        {
            
            Boolean bb = false;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");
            SqlCommand cmd6;
            SqlDataReader dr6;


            String a = phoneText.Text;
            String b;
            con.Open();
            String syntax = "SELECT * FROM person";
            cmd6 = new SqlCommand(syntax, con);
            dr6 = cmd6.ExecuteReader();

            while (dr6.Read())
            {
                b = Convert.ToString(dr6.GetInt32(5));


                if (a.Equals(b))
                {
                    bb = true;
                    break;
                }

            }
            con.Close();
            if (bb == true)
            {
                MessageBox.Show("PHONE NUMBER ALREADY EXIST");
                phoneText.Focus();
            }


        }

        private void phoneCheck(object sender, EventArgs e)
        {
            if (phoneText.TextLength != 10)
            {
                MessageBox.Show("ENTER A VALID PHONE NUMBER");
                phoneText.Focus();
            }
        }

        private void LnameText_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkAllFieldsAreFilled(object sender, EventArgs e)
        {
         

            


        }

        private void User_control1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DnoText_TextChanged(object sender, EventArgs e)
        {

        }

        private void DnoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ssnText.Focus();
            }
        }

        private void SsnText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fnameText.Focus();
            }
        }

        private void FnameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mnameText.Focus();
            }
        }

        private void MnameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lnameText.Focus();
            }
        }

        private void LnameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addressText.Focus();
            }
        }

        private void AddressText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                incomeText.Focus();
            }
        }

        private void IncomeText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                propertyText.Focus();
            }
        }

        private void PropertyText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                phoneText.Focus();
            }
        }

        private void PhoneText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                noText.Focus();
            }
        }

        private void EstimatedText_TextChanged(object sender, EventArgs e)
        {

        }

        private void NoText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                estimatedText.Focus();
            }
        }

        private void EstimatedText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                amountText.Focus();
            }
        }

        private void AmountText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               descText.Focus();
            }
        }
    }
    }
