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

namespace inventorymanagement
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pradeep\source\repos\inventorymanagement\inventorymanagement\Database1.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

     

    

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM regrtn WHERE Username ='" + textBox1.Text + "'and Password ='" + textBox2.Text +"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("Username or Password is incorrect");
            }
            else
            {
                this.Hide();
                MDIParent1 mdi = new MDIParent1();
                mdi.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)

            {
                textBox2.UseSystemPasswordChar = true;
                var checkBox1 = (CheckBox)sender;
                checkBox1.Text = "View";

                
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
                    var checkBox1 = (CheckBox)sender;
                checkBox1.Text = "Hide";
                


            }
        }

       
    }
}
