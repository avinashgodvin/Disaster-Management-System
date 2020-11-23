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
    public partial class show_Disaster_List : Form
    {
        public show_Disaster_List()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection("Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");
       
       
       void initialize()
        {
            SqlCommand cmd = new SqlCommand("Procedure", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }catch(Exception e)
            {
                MessageBox.Show("error occured " + e);
            }
            con.Close();

            dataGridView1.DataSource = ds.Tables[0];    
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


            

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }




        private void WelcomeUser_Load(object sender, EventArgs e)
        {
            initialize();

        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            applyOrUpdate aou = new applyOrUpdate();
            this.Hide();
            aou.Show();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
