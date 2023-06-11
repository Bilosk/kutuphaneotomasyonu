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

namespace anasayfa
{
    public partial class Form2 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BİLAL\Documents\kutuphane.mdf;Integrated Security=True;Connect Timeout=30");
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            SqlCommand veri = new SqlCommand();

            baglanti.Open(); // veritabanı aciliyor..

            veri.Connection = baglanti; //veritabans ile SQL sorgularini iliskilendirdim...

            String ad = Convert.ToString(textBox1.Text);

            string soyad = Convert.ToString(textBox2.Text);

            string kitap = Convert.ToString(textBox3.Text);

            string kadi = Convert.ToString(textBox4.Text);

            string yadi = Convert.ToString(textBox5.Text);

            int sayfa = Convert.ToInt32(textBox6.Text);


            veri.CommandText = "insert into kutuphane ( ad, soyad, kitap, kadi, yadi, sayfa ) values ('" + ad + "','" + soyad + "','" + kitap + "','" + kadi + "','" + yadi +"','" + sayfa + "')";


            veri.ExecuteNonQuery();

            MessageBox.Show("Verileriniz basarili bir sekilde kayit edildi.");
            SqlDataAdapter kutuphane = new SqlDataAdapter("select *from kutuphane", baglanti);
            DataTable tablo = new DataTable();
            kutuphane.Fill(tablo);
            dataGridView1.DataSource = tablo;

            baglanti.Close();













        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(" delete from kutuphane where ad=@ad", baglanti);
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("silindi");
            SqlDataAdapter kutuphane = new SqlDataAdapter("select *from kutuphane", baglanti);
            DataTable tablo = new DataTable();
            kutuphane.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            int satir = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[satir].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[satir].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[satir].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[satir].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[satir].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[satir].Cells[5].Value.ToString();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kutuphaneDataSet.kutuphane' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kutuphaneTableAdapter.Fill(this.kutuphaneDataSet.kutuphane);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand veri = new SqlCommand();

            baglanti.Open(); // veritabanı açılıyor...

            veri.Connection = baglanti; //veritabanı ile SQL sorgularına veri.Parameters.

            veri.Parameters.AddWithValue("@ad", textBox1.Text);

            veri.Parameters.AddWithValue("@soyad", textBox2.Text);

            veri.Parameters.AddWithValue("@kitap", textBox3.Text);

            veri.Parameters.AddWithValue("@kadi", textBox4.Text);

            veri.Parameters.AddWithValue("@yadi", textBox5.Text);

            veri.Parameters.AddWithValue("@sayfa", textBox6.Text);

            veri.CommandText = "update kutuphane SET ad=@ad, soyad=@soyad, kitap=@kitap, kadi=@kadi, yadi=@yadi, sayfa=@sayfa where ad=@ad";

            veri.ExecuteNonQuery();
            SqlDataAdapter kutuphane = new SqlDataAdapter("select *from kutuphane", baglanti);
            DataTable tablo = new DataTable();
            kutuphane.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();//veritabanini kapattim..
        }
    }
}
