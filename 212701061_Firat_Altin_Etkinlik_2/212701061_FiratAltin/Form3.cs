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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=FIRAT\\SQLEXPRESS;Initial Catalog=212701061;Integrated Security=True");

        DataTable yenile() 
        {
            
            baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from calisan_ekle", baglan);
            DataTable tablo = new DataTable();
            // yukarıdan gelen bilgiler fiil komutu ile tabloya eklenmiştir
            adtr.Fill(tablo);
            baglan.Close();
            return tablo;
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }
        public void verisil()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // parametre kullanarak çalışan ekle tablosundan gelen tc'yi kayıt a eşitledik.. 
            string kayit = "Select * From calisan_ekle Where calisan_tc=@calisan_tc";
            //yeni komut tanımlayıp kayıt ve bağlantıyı birbiri ile ilişkilendirdik.
            SqlCommand komut = new SqlCommand(kayit, baglan);

            
            komut.Parameters.AddWithValue("@calisan_tc", textBox1.Text);

            SqlDataAdapter da = new SqlDataAdapter(komut);

             // dt adlı yeni data tablosu tanımladık 
            DataTable dt = new DataTable();
            da.Fill(dt);    
            dataGridView1.DataSource = dt; 
            baglan.Close(); // bağlantıyı kapattık 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                //Veri  bağlantısını açtık 
                baglan.Open();                       
                SqlCommand komut = new SqlCommand("delete from calisan_ekle where calisan_tc='" + dataGridView1.SelectedRows[i].Cells["calisan_tc"].Value.ToString() + "'", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            MessageBox.Show("Kayıt Silindi"); 
            // çalışan silindikten sonra gerekli bilgi mesajını kullanıcıya verdik 
            
            dataGridView1.DataSource = yenile();
        }
    }
}
