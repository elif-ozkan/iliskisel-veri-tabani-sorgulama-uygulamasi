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

namespace İlişkili_Veri_Tabanı_Sorgulama_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //Data Source =LAPTOP-9MADQ7Q9\SQLEXPRESS01
        //LAPTOP-9MADQ7Q9\SQLEXPRESS01
        //Bağlantı adresi=Data Source=LAPTOP-9MADQ7Q9\SQLEXPRESS01;Initial Catalog="Film Arşivim";Integrated Security=True
        SqlConnection baglantı = new SqlConnection("Data Source=LAPTOP-9MADQ7Q9\\SQLEXPRESS01;Initial Catalog=Sorgular;Integrated Security=True");
        string sorgu;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            sorgu = richTextBox1.Text;
            SqlConnection baglantı = new SqlConnection("Data Source=LAPTOP-9MADQ7Q9\\SQLEXPRESS01;Initial Catalog=Sorgular;Integrated Security=True");

            baglantı.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select*from TBLÜRÜNLER", baglantı);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch {
                MessageBox.Show("Sorgunuzu kontrol edin!");
            }
            baglantı.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            

        }

        private void BtnGetir_Click(object sender, EventArgs e)
        {
            try
            {
                baglantı.Open();
                sorgu = richTextBox1.Text;
                SqlCommand komut = new SqlCommand(sorgu, baglantı);
                komut.ExecuteNonQuery();

                SqlDataAdapter d = new SqlDataAdapter("select*from TBLFILMLER", baglantı);
                DataTable dt = new DataTable();
                d.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch
            {
                MessageBox.Show("Sorgunuzu kontrol edin", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Sql ekleme,silme ve güncellemeye dayanan veri tabanları için kullanılan" +
                "bir sorgulama dilidir";
        }
    }
}
