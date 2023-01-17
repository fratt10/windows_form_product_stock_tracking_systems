using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace _212701061_FiratAltin
{
    public partial class Form4 : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string yonetici_tc = textBox1.Text;
            string sifre = textBox2.Text;
            con = new SqlConnection("Data Source=FIRAT\\SQLEXPRESS;Initial Catalog=212701061;Integrated Security=True");
            com = new SqlCommand(); 
            con.Open();
            com.Connection = con;

            com.CommandText = "Select*From calisan_ekle where calisan_tc='" + textBox1.Text + "'And calisan_sicil ='" + textBox2.Text + "'";
             dr = com.ExecuteReader();

            if (dr.Read())
            {
             Form5 frm = new Form5();
            frm.Show();
            this.Hide();
                 
            }
            else
            {
                MessageBox.Show("Hatali Giriş");
            }
            con.Close();
            
        }
    }
}
