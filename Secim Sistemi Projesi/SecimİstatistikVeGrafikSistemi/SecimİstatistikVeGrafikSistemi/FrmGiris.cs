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

namespace SecimİstatistikVeGrafikSistemi
{
    public partial class VTGS : Form
    {
        public VTGS()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BOOK-4G7189N2AI\SQLEXPRESS;Initial Catalog=DBSECIMPROJE;Integrated Security=True");
        private void BtnOyGiris_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand insert = new SqlCommand("INSERT INTO TBLILCE (ILCEAD,APARTI,BPARTI,CPARTI,DPARTI,EPARTI) VALUES (@P1,@P2,@P3,@P4,@P5,@P6)",connection);
            insert.Parameters.AddWithValue("@P1", TxtİlceAd.Text);
            insert.Parameters.AddWithValue("@P2", TxtA.Text);
            insert.Parameters.AddWithValue("@P3", TxtB.Text);
            insert.Parameters.AddWithValue("@P4", TxtC.Text);
            insert.Parameters.AddWithValue("@P5", TxtD.Text);
            insert.Parameters.AddWithValue("@P6", TxtE.Text);
            insert.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Oy Girişi Gerçekleştirildi");
        }

        private void BtnGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafikler fr = new FrmGrafikler();
            fr.Show();
        }
    }
}
