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
    public partial class displayData : Form
    {
        public displayData()
        {
            InitializeComponent();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void Initialize()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-3CMESOM3;Initial Catalog=DisasterManagement;Integrated Security=True;Pooling=False");
            SqlCommand cmd = new SqlCommand("retriveData", con);
            cmd.CommandType = CommandType.StoredProcedure;
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
        private void DisplayData_Load(object sender, EventArgs e)
        {
                Initialize();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            retriveOrDelete rd = new retriveOrDelete();
            this.Hide();
            rd.Show();
        }
    }
}
