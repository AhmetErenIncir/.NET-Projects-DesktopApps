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

namespace Not_Kayit_Sistemi
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BOOK-4G7189N2AI\SQLEXPRESS;Initial Catalog=db_NotKayit;Integrated Security=True");
        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_NotKayitDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.db_NotKayitDataSet.TBLDERS);
            int counter = 0;
            var records = dataGridView1.Rows;
            for (int i=0; i< records.Count ;i++)
            {
                if (records[i].Cells[8].Value != null && records[i].Cells[8].Value.ToString() == "True")
                {
                    counter++;
                }
            }
            LblGecenSayisi.Text = counter.ToString();
            LblKalanSayisi.Text = (records.Count-1 - counter).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand insert = new SqlCommand("INSERT INTO TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) VALUES (@P1,@P2,@P3)",connection);
            insert.Parameters.AddWithValue("@P1", mskNumara.Text);
            insert.Parameters.AddWithValue("@P2", txtAd.Text);
            insert.Parameters.AddWithValue("@P3", txtSoyad.Text);
            insert.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ogrenci Sisteme Eklendi.");
            this.tBLDERSTableAdapter.Fill(this.db_NotKayitDataSet.TBLDERS);
        }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            mskNumara.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
            txtAd.Text = dataGridView1.Rows[selected].Cells[2].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[selected].Cells[3].Value.ToString();
            txtsinav1.Text = dataGridView1.Rows[selected].Cells[4].Value.ToString();
            txtsinav2.Text = dataGridView1.Rows[selected].Cells[5].Value.ToString();
            txtsinav3.Text = dataGridView1.Rows[selected].Cells[6].Value.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double avg, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(txtsinav1.Text);
            s2 = Convert.ToDouble(txtsinav2.Text);
            s3 = Convert.ToDouble(txtsinav3.Text);

            avg = (s1 + s2 + s3) / 3;
            LblOrtalama.Text = avg.ToString();

            if (avg >= 60)
            {
                 durum = "True";
            }
            else
            {
                durum = "False";
            }
            
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE TBLDERS SET OGRS1=@P1,OGRS2=@P2,OGRS3=@P3,ORTALAMA=@P4,DURUM=@P5 WHERE OGRNUMARA=@P6",connection);
            
            command.Parameters.AddWithValue("@P1", txtsinav1.Text);
            command.Parameters.AddWithValue("@P2", txtsinav2.Text);
            command.Parameters.AddWithValue("@P3", txtsinav3.Text);
            command.Parameters.AddWithValue("@P4", decimal.Parse(LblOrtalama.Text));
            command.Parameters.AddWithValue("@P5", durum);
            command.Parameters.AddWithValue("@P6", mskNumara.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ogrenci Notlari Guncellendi");
            FrmOgretmenDetay_Load(sender, e);
        }

        private void btnOgrSil_Click(object sender, EventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            var id = dataGridView1.Rows[selected].Cells[0].Value.ToString();
            connection.Open();
            SqlCommand delete = new SqlCommand("DELETE FROM TBLDERS WHERE OGRID=@P1", connection);
            delete.Parameters.AddWithValue("@P1", id);
            delete.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Ogrenci Silindi");
            FrmOgretmenDetay_Load(sender, e);

        }
    }
}
