using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace entry_data_buku
{
    public partial class Form1 : Form
    {
        string database = "server = localhost; database=buku; uid=root; pwd='';";
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;

        public Form1()
        {
            InitializeComponent();
        }

        public void Query(string query)
        {
            koneksi = new MySqlConnection(database);
            try
            {
                koneksi.Open();
                cmd = new MySqlCommand(query, koneksi);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ali)
            {
                MessageBox.Show(ali.Message);
            }
            finally
            {
                koneksi.Close();
            }
        }


       

        public void konek()
        {
            koneksi = new MySqlConnection(database);
            koneksi.Open();
        }

        public void disconek()
        {
            koneksi = new MySqlConnection(database);
            koneksi.Close();
        }

        public DataTable baca()
        {
            string sql = "select * from databuku";
            DataTable dt = new DataTable();
            try
            {
                konek();
                cmd = new MySqlCommand(sql, koneksi);
                adp = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
               
            }
            catch (Exception ali)
            {
                MessageBox.Show(ali.Message);
            }
            disconek();
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baca();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Query("INSERT INTO databuku VALUES('" + dateTimePicker1.Value.Date.ToString("yyyyMMdd") + "','" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "' WHERE id_buku='");
            MessageBox.Show("Data berhasil ditambahkan", "Berhasil!",
            MessageBoxButtons.OK);

        }
        private void button3_Click(object sender, EventArgs e)
        {
           Query("UPDATE databuku set tahun_terbit = '" + dateTimePicker1.Text + "',penulis = '" + this.textBox1.Text + "',judul_buku='" + this.textBox2.Text + "',penulis='" + this.textBox3.Text + "',penerbit='" + this.textBox4.Text + "' WHERE id_buku='" );
           MessageBox.Show("Update success");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}