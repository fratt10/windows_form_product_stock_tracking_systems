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
using System.Data.Sql;
using System.Data.SqlClient;

namespace _212701061_FiratAltin
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        //Ürünlistesini görüntülemek için fonksiyon oloşturdum
        public void kayit_listele()
        {
             
            da = new SqlDataAdapter("Select * From urun_ekle", baglan);
            ds = new DataSet();
            baglan.Open();
             
            da.Fill(ds, "model_no");
            dataGridView1.DataSource = ds.Tables["model_no"];
            baglan.Close();
        }

        
        DataTable yenile()
        {
            baglan.Open();
            
            SqlDataAdapter adtr = new SqlDataAdapter("select *from urun_ekle", baglan);
            DataTable tablo = new DataTable();
            
            adtr.Fill(tablo);
            baglan.Close();
            return tablo;
        }
        SqlConnection baglan = new SqlConnection("Data Source=FIRAT\\SQLEXPRESS;Initial Catalog=212701061;Integrated Security=True");
        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {   //Veri tabanına bağlandık
                baglan.Open();             
                SqlCommand komut = new SqlCommand("delete from urun_ekle where model_no='" + dataGridView1.SelectedRows[i].Cells["model_no"].Value.ToString() + "'", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            MessageBox.Show("Kayıt Silindi");
            //Listeyi Silindiktenn sonra güncelledik
            dataGridView1.DataSource = yenile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // texboxların boş olmadğı zamanki durumu 
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {      // textboxlar dolduruldugunda komut ile ürün tablosuna bilgile eklendi 
                baglan.Open();
                 
                SqlCommand komut = new SqlCommand("Insert into urun_ekle (model_no,urun_rengi,toplam_hacim,enerji_sinifi) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            else
            { 
                // textboxlar boş aklıdıgında ekrana gelecek uyarı mesajı 
                MessageBox.Show("Boş Alan Bırakamazsınız!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Burda tabloda ki model noyu kayit string değişkneine atıyıyoruz
            string kayit = "Select * From urun_ekle Where model_no=@model_no";
            //Aratma işlemi için
            SqlCommand komut = new SqlCommand(kayit, baglan);

            //textboxa model noyu yazarak tablodan aratıyoruz
            komut.Parameters.AddWithValue("@model_no", textBox5.Text);

            SqlDataAdapter da = new SqlDataAdapter(komut);

            
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kayit_listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string sil = "UPDATE urun_ekle SET  model_no= '" + textBox1.Text + "',urun_rengi='" + textBox2.Text + "',toplam_hacim='" + textBox3.Text + "',enerji_sinifi='" + textBox4.Text + "' WHERE model_no='" + textBox5.Text + "'";
            SqlCommand komut = new SqlCommand(sil, baglan);
            komut.Parameters.AddWithValue("@model_no", textBox5.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Başarıyla güncellendi.");
        }
    }
}
