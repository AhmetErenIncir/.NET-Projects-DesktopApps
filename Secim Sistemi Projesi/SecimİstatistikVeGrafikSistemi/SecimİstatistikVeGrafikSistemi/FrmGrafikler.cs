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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BOOK-4G7189N2AI\SQLEXPRESS;Initial Catalog=DBSECIMPROJE;Integrated Security=True");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //İlçe adlarını combobox a çekme.
            connection.Open();
            SqlCommand getTown = new SqlCommand("SELECT ILCEAD FROM TBLILCE", connection);
            SqlDataReader dr = getTown.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            connection.Close();

            //Grafiğe Toplam Sonuçları Getirme
            connection.Open();
            SqlCommand sumOfRecords = new SqlCommand("SELECT SUM(APARTI),SUM(APARTI),SUM(BPARTI),SUM(CPARTI),SUM(DPARTI),SUM(EPARTI) FROM TBLILCE", connection);

            SqlDataReader dr2 = sumOfRecords.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E", dr2[4]);
            }
            connection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TBLILCE WHERE ILCEAD = @P1",connection);
            sqlCommand.Parameters.AddWithValue("@P1",comboBox1.Text);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());
                lblA.Text = dr[2].ToString();
                lblB.Text = dr[3].ToString();
                lblC.Text = dr[4].ToString();
                lblD.Text = dr[5].ToString();
                lblE.Text = dr[6].ToString();
            }
            connection.Close();
        }
    }
}
