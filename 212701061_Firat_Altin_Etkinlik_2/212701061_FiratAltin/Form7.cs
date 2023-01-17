using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _212701061_FiratAltin
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(); // formlar arası geçişi sağladim
            frm.Show();    // yeni form ekranını açtım
            this.Hide();  // bu formu kapattım   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();  // formlar arası geçişi sağladim
            frm.Show();            // yeni form ekranını açtım
            this.Hide();          // bu formu kapattım
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
