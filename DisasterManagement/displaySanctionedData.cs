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
    public partial class displaySanctionedData : Form
    {
        public displaySanctionedData()
        {
            InitializeComponent();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        void initialize()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand("displaySanctionedData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("error occured " + e);
            }
            con.Close();

            dataGridView1.DataSource = ds.Tables[0];
          //  this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          //  this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void DisplaySanctionedData_Load(object sender, EventArgs e)
        {
            initialize();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");

            SqlCommand cmd = new SqlCommand("clearData", con);

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
    }
}
