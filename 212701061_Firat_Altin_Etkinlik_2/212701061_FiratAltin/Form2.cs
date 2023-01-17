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
    public partial class Form2 : Form
    {
         
        public Form2()
        {
            InitializeComponent();
        }
        string cinsiyet; // radio buttonda kullanmak için cinsiyeti tanımladık 
        SqlConnection baglan = new SqlConnection("Data Source=FIRAT\\SQLEXPRESS;Initial Catalog=212701061;Integrated Security=True");
         // yeni bağlantı tanımladım 
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && (radioButton1.Checked || radioButton2.Checked))
            {
                baglan.Open(); // bağlantıyı açtık 

                 // radio button seçimine göre cinsiyet belirlenecek     
                if (radioButton1.Checked)
                {
                    cinsiyet = "Kadın";
                }

                if (radioButton2.Checked)
                {
                    cinsiyet = "Erkek";
                }

                //  inssert into yardımıyla tanımladığımız yeni komuta textboxlardan gelen değerleri aldık 
                SqlCommand komut = new SqlCommand("Insert into calisan_ekle (calisan_tc,calisan_sicil,calisaan_ad,calisan_soyad,calisan_cinsiyet) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + cinsiyet + "')", baglan);
                komut.ExecuteNonQuery(); 
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakamazsınız!"); // boş geçilmesi durumında uyarı mesajı gönderiliyor 
            }



        }
    }
}
