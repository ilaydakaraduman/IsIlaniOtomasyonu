using IsIlaniOtomasyonu.Girisler;
using IsIlaniOtomasyonu.HizmetBilgi;
using IsIlaniOtomasyonu.Is_Veren;
using IsIlaniOtomasyonu.IsArayan;
using IsIlaniOtomasyonu.MeslekBilgi;
using IsIlaniOtomasyonu.SektorBilgi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsIlaniOtomasyonu.IsBilgiler
{
    public partial class IsKayit : Form
    {
        public IsKayit()
        {
            InitializeComponent();
        }
        public string basvuranlar;

        List<Is> isler = new List<Is>();
        public IsVeren isveren;
        MeslekKod meslekKod = new MeslekKod();
        SektorKod sektorKod = new SektorKod();
        HizmetKod hizmetKod = new HizmetKod();
        IsKod ısKod = new IsKod();
        IsVerenKod isVerenKod = new IsVerenKod();
        IsVerenGiris giris = new IsVerenGiris();
        string Path = "";
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        int fiyat=0;
        public void IlanDoldur()
        {
            dgwIlanlar.DataSource = ısKod.KullanıcıIsIlanıGetir(isveren.IsverenId);
            
            lblKalan.Text = isveren.IlanSayi.ToString();
        }
        void ResimDoldur()
        {
            Path = directory + @"IsverenResim\";
            pbxResim.ImageLocation = Path + isveren.Tc.ToString() + ".jpg";

        }
        public void FiltreliİlanDoldur()
        {
            dgwIlanlar.DataSource = isler;
        }
        public void MeslekDoldur()
        {
            cbxMeslekAd.DataSource = meslekKod.GetAll();
            cbxMeslekAd.DisplayMember = "MeslekAdi";
            cbxMeslekAd.ValueMember = "MeslekId";
        }
        public void SektorDoldur()
        {
            cbxSektorAd.DataSource = sektorKod.GetAll();
            cbxSektorAd.DisplayMember = "SektorIsım";
            cbxSektorAd.ValueMember = "SektorId";
        }
        public void HizmetDoldur()
        {
            cbxHizmetAd.DataSource = hizmetKod.GetAll();
            cbxHizmetAd.DisplayMember = "HizmetAdi";
            cbxHizmetAd.ValueMember = "HizmetId";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if(isveren.IlanSayi >= 0)
            {
                ısKod.Add(new Is
                {
                    AskerlikDurumu = cbxAskerlikFiltr.Text,
                    BasvuranlarId = "",
                    CalismaSekli = cbxCalismaSekli.Text,
                    Cinsiyet = cbxCinsiyet.Text,
                    HizmetAdi = cbxHizmetAd.Text,
                    HizmetId = Convert.ToInt32(cbxHizmetAd.SelectedValue),
                    IstenilenTecrube = cbxTecrube.Text,
                    IstenilenTecrubeId = cbxTecrube.SelectedIndex,
                    IsverenId = isveren.IsverenId,
                    Konum = cbxKonum.Text,
                    Maas = Convert.ToDecimal(tbxMaas.Text),
                    MeslekAdi = cbxMeslekAd.Text,
                    MeslekId = Convert.ToInt32(cbxMeslekAd.SelectedValue),
                    OkulDurumu = cbxOkul.Text,
                    SektorAdi = cbxSektorAd.Text,
                    SektorId = Convert.ToInt32(cbxSektorAd.SelectedValue),

                });
                IlanDoldur();
                lblKalan.Text = (isveren.IlanSayi - 1).ToString();
                isveren.IlanSayi = Convert.ToInt32(lblKalan.Text);
                isVerenKod.Update(isveren);
                bilgileriDoldur();
            }
            else
            {
                MessageBox.Show("İlan verme hakkınız bitmiştir lütfen tekrar satın alınız.");
            }
           


        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            ısKod.Update(new Is
            {
                IsId = Convert.ToInt32(dgwIlanlar.CurrentRow.Cells[0].Value),
                AskerlikDurumu = cbxAskerlikFiltr.Text,
                BasvuranlarId = "",
                CalismaSekli = cbxCalismaSekli.Text,
                Cinsiyet = cbxCinsiyet.Text,
                HizmetAdi = cbxHizmetAd.Text,
                HizmetId = Convert.ToInt32(cbxHizmetAd.SelectedValue),
                IstenilenTecrube = cbxTecrube.Text,
                IstenilenTecrubeId = cbxTecrube.SelectedIndex,
                IsverenId = isveren.IsverenId,
                Konum = cbxKonum.Text,
                Maas = Convert.ToDecimal(tbxMaas.Text),
                MeslekAdi = cbxMeslekAd.Text,
                MeslekId = Convert.ToInt32(cbxMeslekAd.SelectedValue),
                OkulDurumu = cbxOkul.Text,
                SektorAdi = cbxSektorAd.Text,
                SektorId = Convert.ToInt32(cbxSektorAd.SelectedValue),
            });
            IlanDoldur();
        }

        private void dgwIlanlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = cbxMeslekAd.FindString(dgwIlanlar.CurrentRow.Cells[1].Value.ToString());
            cbxMeslekAd.SelectedIndex = index;
            index = cbxSektorAd.FindString(dgwIlanlar.CurrentRow.Cells[3].Value.ToString());
            cbxSektorAd.SelectedIndex = index;
            index = cbxHizmetAd.FindString(dgwIlanlar.CurrentRow.Cells[5].Value.ToString());
            cbxHizmetAd.SelectedIndex = index;
            index = cbxKonum.FindString(dgwIlanlar.CurrentRow.Cells[7].Value.ToString());
            cbxKonum.SelectedIndex = index;
            tbxMaas.Text = dgwIlanlar.CurrentRow.Cells[8].Value.ToString();
            index = cbxTecrube.FindString(dgwIlanlar.CurrentRow.Cells[11].Value.ToString());
            cbxTecrube.SelectedIndex = index;
            index = cbxAskerlikFiltr.FindString(dgwIlanlar.CurrentRow.Cells[13].Value.ToString());
            cbxAskerlikFiltr.SelectedIndex = index;
            index = cbxOkul.FindString(dgwIlanlar.CurrentRow.Cells[14].Value.ToString());
            cbxOkul.SelectedIndex = index;
            index = cbxCinsiyet.FindString(dgwIlanlar.CurrentRow.Cells[15].Value.ToString());
            cbxCinsiyet.SelectedIndex = index;
            index = cbxCalismaSekli.FindString(dgwIlanlar.CurrentRow.Cells[16].Value.ToString());
            cbxCalismaSekli.SelectedIndex = index;
        }
        public void bilgileriDoldur()
        {
            lblAd.Text = isveren.Ad;
            lblSoyad.Text = isveren.Soyad;
            lblSirket.Text = isveren.SirketAd;
            lblTc.Text = isveren.Tc;
            lblSifre.Text = isveren.Sifre;
            lblIlanHak.Text = isveren.IlanSayi.ToString();
            lblKalan.Text = isveren.IlanSayi.ToString();
        }
        private void IsKayit_Load(object sender, EventArgs e)
        {
            ResimDoldur();
            MeslekDoldur();
            SektorDoldur();
            HizmetDoldur();
            IlanDoldur();
            bilgileriDoldur();
            isler = ısKod.KullanıcıIsIlanıGetir(isveren.IsverenId);
        }

        private void btnSatınAl_Click(object sender, EventArgs e)
        {
            if(tbxIlan.Text != "" && tbxIlan.Text != "0")
            {
                isveren.IlanSayi = isveren.IlanSayi + Convert.ToInt32(tbxIlan.Text);
                isVerenKod.Update(isveren);
                bilgileriDoldur();
                MessageBox.Show(Convert.ToInt32(tbxIlan.Text)* fiyat + " tl ödeme gerçekleşti");
            }
        }

        private void tbxIlan_TextChanged(object sender, EventArgs e)
        {
            if (tbxIlan.Text != "")
            {
                lblFiyat.Text = (Convert.ToInt32(tbxIlan.Text) * fiyat).ToString();
            }
               
        }
        
        private void btnFiltrele_Click(object sender, EventArgs e)
        {
           

        }

        private void dgwIlanlar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnIlanBak_Click(object sender, EventArgs e)
        {
            BasvuranBilgi basvuranBilgi = new BasvuranBilgi();
            basvuranBilgi.basvuranlar = dgwIlanlar.CurrentRow.Cells[10].Value.ToString();
            basvuranBilgi.Show();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            YoneticiGiris Giris = new YoneticiGiris();
            this.Hide();
            Giris.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fiyatlandirma fiyatlandirma = new Fiyatlandirma();
            fiyatlandirma.Show();
        }

        private void btnpaket1_Click(object sender, EventArgs e)
        {
            fiyat = 52;
            if (tbxIlan.Text != "")
            {
                lblFiyat.Text = (Convert.ToInt32(tbxIlan.Text) * fiyat).ToString();
            }
           
        }

        private void btnPaket2_Click(object sender, EventArgs e)
        {
            fiyat = 300;
            if (tbxIlan.Text != "")
            {
                lblFiyat.Text = (Convert.ToInt32(tbxIlan.Text) * fiyat).ToString();
            }
        }

        private void btnPaket3_Click(object sender, EventArgs e)
        {
            fiyat = 100;
            if (tbxIlan.Text != "")
            {
                lblFiyat.Text = (Convert.ToInt32(tbxIlan.Text) * fiyat).ToString();
            }
        }
    }
}
