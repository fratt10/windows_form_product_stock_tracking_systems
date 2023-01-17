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
    public partial class Form6 : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string yonetici_tc = textBox1.Text; // textbox1 den gelen degeri yönetici tc'ye eşitlendi
            string sifre = textBox2.Text;       // textbox2 den gelen degeri yönetici tc'ye eşitlendi
            con = new SqlConnection("Data Source=FIRAT\\SQLEXPRESS;Initial Catalog=212701061;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection=con;
            com.CommandText = "Select*From yonetici_tablo where yonetici_tc='" + textBox1.Text + "'And sifre='" + textBox2.Text + "'";
            dr = com.ExecuteReader();

    
            if (dr.Read())
            {
                // veri tabanında ki bilgiler karşılaştırıldığında bilgiler eşleşiyorsa if blogu çalışır 
            Form7 frm = new Form7();  
            frm.Show();    // yeni form açılır
            this.Hide();   // bu form kapanır 
            }
            else
            {
                MessageBox.Show("Hatali Giriş");
                // veri tabanında ki bilgiler karşılaştırıldığında bilgiler eşleşmiyorsa  kullanıcıya bigi verilir  
            }
            con.Close(); 
            
        }
    }
}
