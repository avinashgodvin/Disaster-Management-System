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
    public partial class user_control2 : Form
    {
        public user_control2()
        {
            InitializeComponent();
        }

        private void FnameText_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");
            SqlCommand cmd;
            SqlDataReader dr;


            int ssn;
            ssn = Convert.ToInt32(ssnText.Text);
            Boolean a = false;

            if (true)
            {

                con.Open();
                String syntax = "SELECT * FROM PERSON";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    if (ssn == dr.GetInt32(0))
                    {
                        a = true;
                        break;
                    }
                    else
                    {
                        a = false;
                    }
                }
                con.Close();

                if (a ==false)
                {
                    MessageBox.Show("SSN DOES NOT EXIST IN DATABASE");
                    applyOrUpdate aou = new applyOrUpdate();
                    this.Hide();
                    aou.Show();

                }



            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand("updateDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SSN", Convert.ToInt32(ssnText.Text));
            cmd.Parameters.AddWithValue("@FName", fnameText.Text);
            cmd.Parameters.AddWithValue("@Lname", lnameText.Text);
            cmd.Parameters.AddWithValue("@Mname", mnameText.Text);
            cmd.Parameters.AddWithValue("@Address", addressText.Text);
            cmd.Parameters.AddWithValue("@Phone", Convert.ToInt64(phoneText.Text));
            cmd.Parameters.AddWithValue("@D_no", Convert.ToInt32(dnoText.Text));
            cmd.Parameters.AddWithValue("@noOfPerson", Convert.ToInt32(noText.Text));



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

            SqlCommand cmd1 = new SqlCommand("updateLoss", con);
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

            MessageBox.Show("UPDATED SUCCESSFULLY");


            applyOrUpdate au = new applyOrUpdate();
            this.Hide();
            au.Show();






        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");

            SqlCommand cmd0;
            SqlDataReader dr0;


            int ssn;
            ssn = Convert.ToInt32(ssnText.Text);
            Boolean a = false;

            if (true)
            {

                con.Open();
                String syntax = "SELECT * FROM PERSON";
                cmd0= new SqlCommand(syntax, con);
                dr0 = cmd0.ExecuteReader();

                while (dr0.Read())
                {

                    if (ssn == dr0.GetInt32(0))
                    {
                        a = true;
                        break;
                    }
                    else
                    {
                        a = false;
                    }
                }
                con.Close();

                if (a == false)
                {
                    MessageBox.Show("SSN DOES NOT EXIST IN DATABASE");
                    
                }



            }



            // SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");
            con.Open();

            String qry = "SELECT * FROM PERSON WHERE SSN = " + int.Parse(ssnText.Text);
            SqlCommand cmd = new SqlCommand(qry,con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                fnameText.Text = (dr["FName"].ToString());
                lnameText.Text = (dr["Lname"].ToString());
                mnameText.Text = (dr["Mname"].ToString());
                addressText.Text = (dr["Address"].ToString());
                phoneText.Text = (dr["Phone"].ToString());
                dnoText.Text = (dr["D_no"].ToString());

            }
            con.Close();

            con.Open();

            String qry1 = "SELECT * FROM loss WHERE SSN = " + int.Parse(ssnText.Text);
            SqlCommand cmd1 = new SqlCommand(qry1, con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                estimatedText.Text = (dr1["EstimatedLoss"].ToString());
                descText.Text = (dr1["DescAboutLoss"].ToString());
            }
            con.Close();

            con.Open();

            String qry2 = "SELECT * FROM family WHERE SSN = " + int.Parse(ssnText.Text);
            SqlCommand cmd2 = new SqlCommand(qry2, con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                noText.Text = (dr2["NoOfPerson"].ToString());
                incomeText.Text = (dr2["income"].ToString());
                propertyText.Text = (dr2["property"].ToString());


            }
            con.Close();

            con.Open();

            String qry3 = "SELECT * FROM amount WHERE SSN = " + int.Parse(ssnText.Text);
            SqlCommand cmd3 = new SqlCommand(qry3, con);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            if (dr3.Read())
            {
                amountText.Text = (dr3["RequestedAmount"].ToString());

            }
            con.Close();



        }
    }
}
