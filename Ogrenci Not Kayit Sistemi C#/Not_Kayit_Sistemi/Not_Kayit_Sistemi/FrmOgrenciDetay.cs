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
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public string numara;
        //Data Source=BOOK-4G7189N2AI\SQLEXPRESS;Initial Catalog=db_NotKayit;Integrated Security=True
        SqlConnection connection = new SqlConnection(@"Data Source=BOOK-4G7189N2AI\SQLEXPRESS;Initial Catalog=db_NotKayit;Integrated Security=True");
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;
            connection.Open();
            SqlCommand select = new SqlCommand("Select * From TBLDERS Where OGRNUMARA = @p1",connection);
            select.Parameters.AddWithValue("@p1", numara);
            SqlDataReader reader= select.ExecuteReader();
            while (reader.Read())
            {
                lblAdSoyad.Text = reader[2].ToString() + " " + reader[3].ToString();
                lblSinav1.Text = reader[4].ToString();
                lblSinav2.Text= reader[5].ToString();
                lblSinav3.Text= reader[6].ToString();
                lblOrtalama.Text = reader[7].ToString();
                lblDurum.Text = reader[8].ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblNumara_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblAdSoyad_Click(object sender, EventArgs e)
        {

        }
    }
}
