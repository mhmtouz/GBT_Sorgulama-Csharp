using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GBT_Sorgulama
{
    public partial class frmKayitEkleSilDegis : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=GBT_Sorgulama; Integrated Security=TRUE;");
        SqlDataAdapter da;
        SqlCommand cmd;
        string sahisno, tc, fis, d1, d2;
        DialogResult dia, dr;


        public frmKayitEkleSilDegis()
        {
            InitializeComponent();
        }


        private void btnKayitEkleSil_Click(object sender, EventArgs e)
        {
            textclear(this);
            pnlKayitGor.Hide();
            pnlSahisKeResim.Show();
            pnlSahisSorgu.Hide();
            pnlSahisResim.Hide();
            pnlKayitEkle.Show();
            pBoxKeResim.Image = Image.FromFile(Application.StartupPath + "\\add_user.png");
            lblTitle.Text = "Şahıs Değiştir/Ekle/Sil";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSahis_Click(object sender, EventArgs e)
        {
            textclear(this);
            pnlKayitGor.Hide();
            pnlSahisResim.Show();
            pnlKayitEkle.Hide();
            pnlSahisKeResim.Hide();
            pnlSahisSorgu.Show();
            pBoxSahisResim.Image = Image.FromFile(Application.StartupPath + "\\user.png");
            lblTitle.Text = "Şahıs Sorgulama";

        }

        private void btnEkCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGörüntüle_Click(object sender, EventArgs e)
        {
            textclear(this);
            tumKayit();
            pnlSahisKeResim.Hide();
            pnlSahisSorgu.Hide();
            pnlSahisResim.Hide();
            pnlKayitEkle.Hide();
            pnlKayitGor.Show();
            pBoxSahisResim.ImageLocation = null;
            pBoxKeResim.ImageLocation = null;
            lblTitle.Text = "Şahısları Görüntüle";
        }

        private void btnSahTemizle_Click(object sender, EventArgs e)
        {
            textclear(this);
        }
        private void textclear(Control ctl)
        {
            foreach (Control item in ctl.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
                if (item.Controls.Count > 0)
                {
                    textclear(item);
                }
            }
        }
        private void txtSahSahisNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtKeSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void frmKayitEkleSilDegis_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gBT_SorgulamaDataSet6.Orgut' table. You can move, or remove it, as needed.
            this.orgutTableAdapter.Fill(this.gBT_SorgulamaDataSet6.Orgut);
            // TODO: This line of code loads data into the 'gBT_SorgulamaDataSet5.Suc' table. You can move, or remove it, as needed.
            this.sucTableAdapter.Fill(this.gBT_SorgulamaDataSet5.Suc);
            // TODO: This line of code loads data into the 'gBT_SorgulamaDataSet4.MedeniDurum' table. You can move, or remove it, as needed.
            this.medeniDurumTableAdapter.Fill(this.gBT_SorgulamaDataSet4.MedeniDurum);
            // TODO: This line of code loads data into the 'gBT_SorgulamaDataSet3.Fis' table. You can move, or remove it, as needed.
            this.fisTableAdapter.Fill(this.gBT_SorgulamaDataSet3.Fis);
            // TODO: This line of code loads data into the 'gBT_SorgulamaDataSet2.Nufus' table. You can move, or remove it, as needed.
            this.nufusTableAdapter.Fill(this.gBT_SorgulamaDataSet2.Nufus);
            // TODO: This line of code loads data into the 'gBT_SorgulamaDataSet1.Ilce' table. You can move, or remove it, as needed.
            this.ilceTableAdapter.Fill(this.gBT_SorgulamaDataSet1.Ilce);
            // TODO: This line of code loads data into the 'gBT_SorgulamaDataSet.Il' table. You can move, or remove it, as needed.
            this.ilTableAdapter.Fill(this.gBT_SorgulamaDataSet.Il);
            // TODO: This line of code loads data into the 'gBT_SorgulamaDataSet1.Ilce' table. You can move, or remove it, as needed.
            this.ilceTableAdapter.Fill(this.gBT_SorgulamaDataSet1.Ilce);
            // TODO: This line of code loads data into the 'gBT_SorgulamaDataSet.Il' table. You can move, or remove it, as needed.
            this.ilTableAdapter.Fill(this.gBT_SorgulamaDataSet.Il);


            pnlSahisSorgu.Show();
            pnlKayitGor.Hide();
            pnlSahisResim.Show();
            pnlKayitEkle.Hide();
            pnlSahisKeResim.Hide();

            lblTitle.Text = "Şahıs Sorgulama";

        }

        private void pboxPink_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("Arkaplanlar\\arkaplanPembe.jpg");
        }

        private void pboxGreen_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("Arkaplanlar\\arkaplanYesil.jpg");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("Arkaplanlar\\arkaplanMavi.jpg");
        }


        private void cbKeil_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                da = new SqlDataAdapter("Select * From Ilce where ilId=@p1", con);
                da.SelectCommand.Parameters.Add("@p1", cbKeil.SelectedValue);
                DataTable dt = new DataTable();
                if (con.State == ConnectionState.Closed) { con.Open(); }
                da.Fill(dt);
                cbKeilce.DataSource = dt;
                cbKeilce.DisplayMember = "ilceAd";
                cbKeilce.ValueMember = "ilceID";
                con.Close();
            }
            catch (Exception)
            {

            }
        }

        private void cbKeilce_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                da = new SqlDataAdapter("Select * From MahalleKoy where ilceId=@p1", con);
                da.SelectCommand.Parameters.Add("@p1", cbKeilce.SelectedValue);
                DataTable dt = new DataTable();
                if (con.State == ConnectionState.Closed) { con.Open(); }
                da.Fill(dt);
                cbKeMahalle.DataSource = dt;
                cbKeMahalle.DisplayMember = "mkAd";
                cbKeMahalle.ValueMember = "mkId";
                con.Close();
            }
            catch (Exception)
            {

            }
        }

        private void btnKeEkle_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("insert into Nufus(tcNo,ad,ikinciAd,soyad,babaAdi,anaAdi,dogumYeri,dogumTarihi,Cinsiyet,medeniDurum,nufusaKayitliOlduguYer,yakalamaDurumu,sahisFoto) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)", con);
            SqlCommand cmd1 = new SqlCommand("insert into ikametgah(ciltNo,siraNo,aileSiraNo,il,ilce,mahalle_köy,acikAdres) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", con);
            SqlCommand cmd2 = new SqlCommand("insert into Fis(fisTarihi,sucAd,orgutAd,sucYeri,sucTarihi,tahkYapanMakam,cezaYil,cezaAy,cezaGün,sahisNo) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", con);

            try
            {
                cmd1.Parameters.AddWithValue("@p1", txtKeCilt.Text);
                cmd1.Parameters.AddWithValue("@p2", txtKeSira.Text);
                cmd1.Parameters.AddWithValue("@p3", txtKeAileSira.Text);
                cmd1.Parameters.AddWithValue("@p4", cbKeil.Text);
                cmd1.Parameters.AddWithValue("@p5", cbKeilce.Text);
                cmd1.Parameters.AddWithValue("@p6", cbKeMahalle.Text);
                cmd1.Parameters.AddWithValue("@p7", txtKeAcikAdres.Text);
                try
                {
                    cmd1.ExecuteNonQuery();
                    SqlCommand idgetir = new SqlCommand("select max(kayitNo) as id from ikametgah", con);
                    SqlDataReader oku = idgetir.ExecuteReader();
                    oku.Read();
                    string gelenmaxid = oku[0].ToString();
                    oku.Close();

                    cmd.Parameters.AddWithValue("@p1", txtKeTC.Text);
                    cmd.Parameters.AddWithValue("@p2", txtKEAd.Text);
                    cmd.Parameters.AddWithValue("@p3", txtKeİkinciAd.Text);
                    cmd.Parameters.AddWithValue("@p4", txtKeSoyad.Text);
                    cmd.Parameters.AddWithValue("@p5", txtKeBabaAd.Text);
                    cmd.Parameters.AddWithValue("@p6", txtKeAnneAd.Text);
                    cmd.Parameters.AddWithValue("@p7", cbKeil.Text);
                    cmd.Parameters.AddWithValue("@p8", dtpKeDogum.Value);
                    cmd.Parameters.AddWithValue("@p9", radioKeErkek.Checked ? "Erkek" : "Kadın");
                    cmd.Parameters.AddWithValue("@p10", cbKeMedeni.Text);
                    cmd.Parameters.AddWithValue("@p11", gelenmaxid);
                    cmd.Parameters.AddWithValue("@p12", cbKeDurumu.Text);
                    cmd.Parameters.AddWithValue("@p13", pBoxKeResim.Tag);
                }
                catch (Exception)
                {

                    MessageBox.Show("Nüfusa kayıtlı olduğu yerin bilgilerini kontrol ediniz.!!");
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    SqlCommand idgetir2 = new SqlCommand("select max(sahisNo) as id from Nufus", con);
                    SqlDataReader oku2 = idgetir2.ExecuteReader();
                    oku2.Read();
                    string gelenmaxid2 = oku2[0].ToString();
                    oku2.Close();

                    cmd2.Parameters.AddWithValue("@p1", DateTime.Now);
                    cmd2.Parameters.AddWithValue("@p2", cbKeSuc.Text);
                    cmd2.Parameters.AddWithValue("@p3", cbKeOrgut.Text);
                    cmd2.Parameters.AddWithValue("@p4", txtKeSucYeri.Text);
                    cmd2.Parameters.AddWithValue("@p5", dtpKeSucTarih.Value);
                    cmd2.Parameters.AddWithValue("@p6", cbKeTahakkuk.Text);
                    cmd2.Parameters.AddWithValue("@p7", txtKeCezaYil.Text);
                    cmd2.Parameters.AddWithValue("@p8", txtKeCezaAy.Text);
                    cmd2.Parameters.AddWithValue("@p9", txtKeCezaGun.Text);
                    cmd2.Parameters.AddWithValue("@p10", gelenmaxid2);
                }
                catch (Exception)
                {
                    MessageBox.Show("Nüfus bilgilerini kontrol ediniz.!!");
                }

                try
                {
                    cmd2.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fiş bilgilerini kontrol ediniz.!!");
                }
                dr = MessageBox.Show("Ekleme Yapılsın mı?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                    MessageBox.Show("Ekleme işlemi başarıyla tamamlandı.");
                else
                    MessageBox.Show("Ekleme işlemi iptal edildi.");
            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt işlemi yapılırken hata oluştu.!!");
            }
            con.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            d1 = dtpKeDogum.Value.ToString("yyyy - MM - dd");
            d2 = dtpKeSucTarih.Value.ToString("yyyy - MM - dd");
            sahisno = txtKeSah.Text;
            tc = txtKeTC.Text;
            fis = txtKeFis.Text;
            if (con.State == ConnectionState.Closed) { con.Open(); }
            if (!string.IsNullOrEmpty(txtKeSah.Text))
            {

                cmd = new SqlCommand("select * from Nufus,ikametgah,fis where Nufus.sahisNo=@id and Nufus.nufusaKayitliOlduguYer=ikametgah.kayitNo and fis.sahisNo=Nufus.sahisNo", con);
                cmd.Parameters.AddWithValue("@id", sahisno);

            }
            else if (!string.IsNullOrEmpty(txtKeTC.Text))
            {
                cmd = new SqlCommand("select * from Nufus,ikametgah,fis where Nufus.tcNo=@id2 and Nufus.nufusaKayitliOlduguYer=ikametgah.kayitNo and fis.sahisNo=Nufus.sahisNo", con);
                cmd.Parameters.AddWithValue("@id2", tc);
            }
            else
            {
                cmd = new SqlCommand("select * from Nufus,ikametgah,fis where Fis.fisNo=@id3 and Nufus.nufusaKayitliOlduguYer=ikametgah.kayitNo and fis.sahisNo=Nufus.sahisNo", con);
                cmd.Parameters.AddWithValue("@id3", fis);
            }
            SqlDataReader drs = cmd.ExecuteReader();
            if (drs.Read())
            {
                txtSahSahisNo.Text = drs["sahisNo"].ToString();
                txtKEAd.Text = drs["ad"].ToString();
                txtKeTC.Text = drs["tcNo"].ToString();
                txtKeİkinciAd.Text = drs["ikinciAd"].ToString();
                txtKeSoyad.Text = drs["soyad"].ToString();
                txtKeBabaAd.Text = drs["babaAdi"].ToString();
                txtKeAnneAd.Text = drs["anaAdi"].ToString();
                d1 = drs["dogumTarihi"].ToString();
                radioKeErkek.Checked = drs["Cinsiyet"].ToString() == "Erkek" ? true : false;
                cbKeDurumu.Text = drs["yakalamaDurumu"].ToString();
                txtSahMedeni.Text = drs["medeniDurum"].ToString();
                pBoxKeResim.ImageLocation = drs["sahisFoto"].ToString();
                pBoxSahisResim.Tag = drs["sahisFoto"].ToString();

                cbKeil.Text = drs["il"].ToString();
                cbKeilce.Text = drs["ilce"].ToString();
                cbKeMahalle.Text = drs["mahalle_köy"].ToString();
                txtKeCilt.Text = drs["ciltNo"].ToString();
                txtKeSira.Text = drs["siraNo"].ToString();
                txtKeAileSira.Text = drs["aileSiraNo"].ToString();
                txtKeAcikAdres.Text = drs["acikAdres"].ToString();

                label59.Tag = drs["kayitNo"].ToString();
                txtKeFis.Text = drs["fisNo"].ToString();
                lblFisTarihi.Text = drs["fisTarihi"].ToString();
                cbKeSuc.SelectedText = drs["sucAd"].ToString();
                cbKeOrgut.SelectedText = drs["orgutAd"].ToString();
                d2 = drs["sucTarihi"].ToString();
                txtKeSucYeri.SelectedText = drs["sucYeri"].ToString();
                cbKeTahakkuk.SelectedText = drs["tahkYapanMakam"].ToString();
                txtKeCezaYil.Text = drs["cezaYil"].ToString();
                txtKeCezaAy.Text = drs["cezaAy"].ToString();
                txtKeCezaGun.Text = drs["cezaGün"].ToString();

            }
            else
            {
                MessageBox.Show("Sistemde böyle bir şahıs yoktur.");
            }
            con.Close();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            sahisno = txtSahSahisNo.Text;
            tc = txtSahTC.Text;
            fis = txtSahFis.Text;
            if (con.State == ConnectionState.Closed) { con.Open(); }
            if (!string.IsNullOrEmpty(txtSahSahisNo.Text))
            {

                cmd = new SqlCommand("select * from Nufus,ikametgah,fis where Nufus.sahisNo=@id and Nufus.nufusaKayitliOlduguYer=ikametgah.kayitNo and fis.sahisNo=Nufus.sahisNo", con);
                cmd.Parameters.AddWithValue("@id", sahisno);

            }
            else if (!string.IsNullOrEmpty(txtSahTC.Text))
            {
                cmd = new SqlCommand("select * from Nufus,ikametgah,fis where Nufus.tcNo=@id2 and Nufus.nufusaKayitliOlduguYer=ikametgah.kayitNo and fis.sahisNo=Nufus.sahisNo", con);
                cmd.Parameters.AddWithValue("@id2", tc);
            }
            else
            {
                cmd = new SqlCommand("select * from Nufus,ikametgah,fis where Fis.fisNo=@id3 and Nufus.nufusaKayitliOlduguYer=ikametgah.kayitNo and fis.sahisNo=Nufus.sahisNo", con);
                cmd.Parameters.AddWithValue("@id3", fis);
            }
            SqlDataReader drek = cmd.ExecuteReader();
            if (drek.Read())
            {
                txtSahSahisNo.Text = drek["sahisNo"].ToString();
                txtSahAd.Text = drek["ad"].ToString();
                txtSahTC.Text = drek["tcNo"].ToString();
                txtSahikinAd.Text = drek["ikinciAd"].ToString();
                txtSahSoyad.Text = drek["soyad"].ToString();
                txtSahBabaAd.Text = drek["babaAdi"].ToString();
                txtSahAnneAd.Text = drek["anaAdi"].ToString();
                txtSahDogumTar.Text = drek["dogumTarihi"].ToString();
                radioBSahErkek.Checked = drek["Cinsiyet"].ToString() == "Erkek" ? true : false;
                txtSahYakalama.Text = drek["yakalamaDurumu"].ToString();
                txtSahMedeni.Text = drek["medeniDurum"].ToString();
                pBoxSahisResim.ImageLocation = drek["sahisFoto"].ToString();

                txtSahil.Tag = drek["kayitNo"].ToString();
                txtSahil.Text = drek["il"].ToString();
                txtSahilce.Text = drek["ilce"].ToString();
                txtSahMahalle.Text = drek["mahalle_köy"].ToString();
                txtSahCiltNo.Text = drek["ciltNo"].ToString();
                txtSahSiraNo.Text = drek["siraNo"].ToString();
                txtSahAileSira.Text = drek["aileSiraNo"].ToString();
                txtSahAcikAdr.Text = drek["acikAdres"].ToString();

                txtSahFis.Text = drek["fisNo"].ToString();
                lblSahFisTarih.Text = drek["fisTarihi"].ToString();
                txtSahSuc.Text = drek["sucAd"].ToString();
                txtSahOrgut.Text = drek["orgutAd"].ToString();
                txtSahSucTarih.Text = drek["sucTarihi"].ToString();
                txtSahSucYer.Text = drek["sucYeri"].ToString();
                txtSahTahak.Text = drek["tahkYapanMakam"].ToString();
                txtSahCezaYil.Text = drek["cezaYil"].ToString();
                txtSahCezaAy.Text = drek["cezaAy"].ToString();
                txtSahCezaGun.Text = drek["cezaGün"].ToString();
            }
            else
            {
                MessageBox.Show("Sistemde böyle bir şahıs yoktur.");
            }
            con.Close();
        }
        public void tumKayit()
        {
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }

                da = new SqlDataAdapter("select Nufus.sahisFoto,Nufus.sahisNo,Nufus.tcNo,Nufus.ad,Nufus.ikinciAd,Nufus.soyad,Nufus.babaAdi,Nufus.anaAdi,ikametgah.il,ikametgah.ilce,ikametgah.mahalle_köy,ikametgah.acikAdres,Nufus.dogumTarihi,Nufus.Cinsiyet,Fis.fisNo,Fis.sucAd,Fis.orgutAd,Fis.sucYeri,Fis.sucTarihi,Fis.tahkYapanMakam,Fis.cezaYil,Fis.cezaAy,Fis.cezaGün,Fis.fisTarihi from Nufus, ikametgah, fis where Nufus.nufusaKayitliOlduguYer = ikametgah.kayitNo and fis.sahisNo = Nufus.sahisNo", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridTumKayit.DataSource = dt;
                con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Bütün Kayıtlara Erişilemedi");

            }

        }
        private void btnKeSil_Click(object sender, EventArgs e)
        {
            sahisno = txtKeSah.Text;
            tc = txtKeTC.Text;
            fis = txtKeFis.Text;
            try
            {
                if (con.State == ConnectionState.Closed) { con.Open(); }
                if (!string.IsNullOrEmpty(txtKeSah.Text))
                {

                    cmd = new SqlCommand("select * from Nufus,ikametgah,fis where Nufus.sahisNo=@id and Nufus.nufusaKayitliOlduguYer=ikametgah.kayitNo and fis.sahisNo=Nufus.sahisNo", con);
                    cmd.Parameters.AddWithValue("@id", sahisno);

                }
                else if (!string.IsNullOrEmpty(txtKeTC.Text))
                {
                    cmd = new SqlCommand("select * from Nufus,ikametgah,fis where Nufus.tcNo=@id2 and Nufus.nufusaKayitliOlduguYer=ikametgah.kayitNo and fis.sahisNo=Nufus.sahisNo", con);
                    cmd.Parameters.AddWithValue("@id2", tc);
                }
                else
                {
                    cmd = new SqlCommand("select * from Nufus,ikametgah,fis where Fis.fisNo=@id3 and Nufus.nufusaKayitliOlduguYer=ikametgah.kayitNo and fis.sahisNo=Nufus.sahisNo", con);
                    cmd.Parameters.AddWithValue("@id3", fis);
                }
                SqlDataReader drsil = cmd.ExecuteReader();
                if (drsil.Read())
                {
                    dia = MessageBox.Show(txtKeSah.Text + " şahıs numaralı kayıt silinsin mi?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    drsil.Close();
                    if (dia == DialogResult.Yes)
                    {
                        string sil = "DELETE from Nufus where sahisNo=@p1";
                        SqlCommand silkmt = new SqlCommand(sil, con);
                        silkmt.Parameters.AddWithValue("@p1", txtKeSah.Text);

                        silkmt.ExecuteNonQuery();

                        MessageBox.Show(txtKeSah.Text + " 'şahıs nolu kayıt silindi...");
                        textclear(this);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt silme iptal edildi.");
                    }
                }
                else
                {
                    MessageBox.Show("Böyle bir kayıt bulunmamaktadır.");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Böyle bir kayıt .");
            }
            con.Close();

        }

        private void btnKeDegistir_Click(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand("update Nufus set tcNo=@p1,ad=@p2,ikinciAd=@p3,soyad=@p4,babaAdi=@p5,anaAdi=@p6,medeniDurum=@p7,dogumTarihi=@p9,Cinsiyet=@p10,yakalamaDurumu=@p11,sahisFoto=@p12 where sahisNo=@sNo", con);
            SqlCommand cmd1 = new SqlCommand("update ikametgah set ciltNo=@p1,siraNo=@p2,aileSiraNo=@p3,il=@p4,ilce=@p5,mahalle_köy=@p6,acikAdres=@p7 where kayitNo=@kNo", con);
            SqlCommand cmd2 = new SqlCommand("update Fis set sucAd=@p2,orgutAd=@p3,sucYeri=@p4,sucTarihi=@p5,tahkYapanMakam=@p6,cezaYil=@p7,cezaAy=@p8,cezaGün=@p9 where fisNo=@fNo", con);
            dr = MessageBox.Show("Güncelleme Yapılsın mı?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    cmd.Parameters.AddWithValue("@p1", txtKeTC.Text);
                    cmd.Parameters.AddWithValue("@p2", txtKEAd.Text);
                    cmd.Parameters.AddWithValue("@p3", txtKeİkinciAd.Text);
                    cmd.Parameters.AddWithValue("@p4", txtKeSoyad.Text);
                    cmd.Parameters.AddWithValue("@p5", txtKeBabaAd.Text);
                    cmd.Parameters.AddWithValue("@p6", txtKeAnneAd.Text);
                    cmd.Parameters.AddWithValue("@p7", cbKeDurumu.Text);
                    cmd.Parameters.AddWithValue("@p9", dtpKeDogum.Value);
                    cmd.Parameters.AddWithValue("@p10", radioKeErkek.Checked ? "Erkek" : "Kadın");
                    cmd.Parameters.AddWithValue("@p11", cbKeDurumu.Text);
                    cmd.Parameters.AddWithValue("@p12", pBoxSahisResim.Tag);
                    cmd.Parameters.AddWithValue("@sNo", txtSahSahisNo.Text);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        cmd1.Parameters.AddWithValue("@p1", txtKeCilt.Text);
                        cmd1.Parameters.AddWithValue("@p2", txtKeSira.Text);
                        cmd1.Parameters.AddWithValue("@p3", txtKeAileSira.Text);
                        cmd1.Parameters.AddWithValue("@p4", cbKeil.Text);
                        cmd1.Parameters.AddWithValue("@p5", cbKeilce.Text);
                        cmd1.Parameters.AddWithValue("@p6", cbKeMahalle.Text);
                        cmd1.Parameters.AddWithValue("@p7", txtKeAcikAdres.Text);
                        cmd1.Parameters.AddWithValue("@kNo", Convert.ToInt32(label59.Tag));
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Nufus Bilgilerini kontrol ediniz.");
                    }
                    try
                    {
                        cmd1.ExecuteNonQuery();
                        cmd2.Parameters.AddWithValue("@p2", cbKeSuc.Text);
                        cmd2.Parameters.AddWithValue("@p3", cbKeOrgut.Text);
                        cmd2.Parameters.AddWithValue("@p4", txtKeSucYeri.Text);
                        cmd2.Parameters.AddWithValue("@p5", dtpKeSucTarih.Value);
                        cmd2.Parameters.AddWithValue("@p6", cbKeTahakkuk.Text);
                        cmd2.Parameters.AddWithValue("@p7", txtKeCezaYil.Text);
                        cmd2.Parameters.AddWithValue("@p8", txtKeCezaAy.Text);
                        cmd2.Parameters.AddWithValue("@p9", txtKeCezaGun.Text);
                        cmd2.Parameters.AddWithValue("@fNo", txtKeFis.Text);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Nufusa Kayıtlı Olduğu Yer Bilgilerini kontrol ediniz.");
                    }
                    try
                    {
                        cmd2.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Fiş Bilgilerini kontrol ediniz.");
                    }
                    MessageBox.Show("Güncelleme Başarılı");
                }
                catch (Exception)
                {

                    MessageBox.Show("Güncelleme yapılırken hata oluştu.!!");
                }
                
            }
            else
            {
                MessageBox.Show("Güncelleme İptal Edildi");
            }

            con.Close();
        }

        //http://www.ahmetcansever.com/c-2/c-veritabanina-resim-yolu-ekleme-ve-pictureboxta-gosterme/ yardım alınmıştır.
        private void pBoxKeResim_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            pBoxKeResim.Tag = dosyayolu;
            pBoxKeResim.ImageLocation = dosyayolu;
        }

    }
}
