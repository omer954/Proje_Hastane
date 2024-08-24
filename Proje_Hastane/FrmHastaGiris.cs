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

namespace Proje_Hastane
{
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl=new SqlBaglantisi();

        private void LnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr=new FrmHastaKayit();
            fr.Show();

        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",  MskTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dataReader = komut.ExecuteReader();
            if (dataReader.Read()) 
            {
                FrmHastaDetay frm = new FrmHastaDetay();
                frm.tc=MskTC.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC Kimlik Numaranız veya Şifreniz Hatalıdır, Lütfen Tekrar Deneyiniz!!");
            }
            bgl.baglanti().Close();
        }
    }
}
