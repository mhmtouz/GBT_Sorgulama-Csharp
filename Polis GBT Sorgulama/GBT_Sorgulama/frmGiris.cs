using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace GBT_Sorgulama
{
    public partial class frmGiris : Form
    {
        frmKayitEkleSilDegis frmKayit;
        public frmGiris()
        {
            InitializeComponent();

        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=GBT_Sorgulama; Integrated Security=TRUE;");

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sorgu = "select * from Kullanici where kullaniciTC=@1 and kullaniciSifre=@2";
            SqlCommand cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.Add("@1", txtTcno.Text);
            cmd.Parameters.Add("@2", txtSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (frmKayit == null || frmKayit.IsDisposed)
                {
                    frmKayit = new frmKayitEkleSilDegis();
                    frmKayit.lblKullanici.Text = txtTcno.Text;
                    frmKayit.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Yanlış TC ve/veya Şifre Girdiniz!");
                }
            }
            else
            {
                MessageBox.Show("Yanlış TC ve/veya Şifre Girdiniz!");
                con.Close();
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void txtTcno_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {
            BackColor = Color.Orange;
            TransparencyKey = Color.Orange;
            FormBorderStyle = FormBorderStyle.None;
        }
    }
}
