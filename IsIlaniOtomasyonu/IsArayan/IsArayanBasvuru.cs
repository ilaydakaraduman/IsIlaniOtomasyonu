using IsIlaniOtomasyonu.Girisler;
using IsIlaniOtomasyonu.IsBilgiler;
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

namespace IsIlaniOtomasyonu.IsArayan
{
    public partial class IsArayanBasvuru : Form
    {
        public IsArayanBasvuru()
        {
            InitializeComponent();
        }
        List<Is> isler = new List<Is>();
        IsKod ısKod = new IsKod();
        MeslekKod meslekKod = new MeslekKod();
        SektorKod sektorKod = new SektorKod();
        public Arayan arayan;
        private void IsArayanBasvuru_Load(object sender, EventArgs e)
        {
            isler = ısKod.GetAll();
            IlanDoldur();
            MeslekDoldur();
            SektorDoldur();
        }
        public void MeslekDoldur()
        {
            cbxMeslek.DataSource = meslekKod.GetAll();
            cbxMeslek.DisplayMember = "MeslekAdi";
            cbxMeslek.ValueMember = "MeslekId";
        }
        public void SektorDoldur()
        {
            cbxSektor.DataSource = sektorKod.GetAll();
            cbxSektor.DisplayMember = "SektorIsım";
            cbxSektor.ValueMember = "SektorId";
        }
        public void IlanDoldur()
        {
            dgwIlanlar.DataSource = ısKod.GetAll();
           
        }
        public void filtreliIlanDoldur()
        {
            dgwIlanlar.DataSource = isler;
        }
        public void İlanlarıSıfırla()
        {
            isler.Clear();
            isler = ısKod.GetAll();
        }
        public List<Is> Cinsiyetfiltrele(List<Is> isler)
        {
            List<Is> cinsiyetFiltre = new List<Is>();
            if (cbxCinsiyetFilt.Text == "" || cbxCinsiyetFilt.Text == "FARKETMEZ")
            {
                return isler;
            }
            foreach (var ıs in isler)
            {
                if (cbxCinsiyetFilt.Text == ıs.Cinsiyet)
                {
                    cinsiyetFiltre.Add(ıs);
                }
            }
            return cinsiyetFiltre;
        }
        public List<Is> AskerFiltrele(List<Is> isler)
        {
            List<Is> askerFiltre = new List<Is>();

            if (cbxAskerFiltr.Text == "" || cbxAskerFiltr.Text == "ÖNEMSİZ")
            {
                return isler;
            }
            foreach (var ıs in isler)
            {
                if (cbxAskerFiltr.Text == "ÖNEMLİ")
                {
                    if (ıs.AskerlikDurumu == "YAPTI" || ıs.AskerlikDurumu == "MUAF")
                    {
                        askerFiltre.Add(ıs);
                    }
                }
            }

            return askerFiltre;

        }
        public List<Is> MaasFiltre(List<Is> isler)
        {
            List<Is> maasFiltre = new List<Is>();
            if (tbxMaasFilt.Text == "")
            {
                return isler;
            }
            else
            {
                foreach (var ıs in isler)
                {
                    if (ıs.Maas > Convert.ToDecimal(tbxMaasFilt.Text))
                    {
                        maasFiltre.Add(ıs);
                    }
                }
            }
            return maasFiltre;
        }
        public List<Is> TecrubeFiltre(List<Is> isler)
        {
            List<Is> tecrubeFiltre = new List<Is>();
            if (cbxTecrubeFilt.Text == "" || cbxTecrubeFilt.Text == "0")
            {
                return isler;
            }
            else
            {
                foreach (var ıs in isler)
                {
                    if (cbxTecrubeFilt.SelectedIndex == 1 && Convert.ToInt32(ıs.IstenilenTecrubeId) > 0)
                    {
                        tecrubeFiltre.Add(ıs);
                    }

                    else if (cbxTecrubeFilt.SelectedIndex == 2 && Convert.ToInt32(ıs.IstenilenTecrubeId) >= 2)
                    {
                        tecrubeFiltre.Add(ıs);
                    }
                    else if (cbxTecrubeFilt.SelectedIndex == 3 && Convert.ToInt32(ıs.IstenilenTecrubeId) >= 5)
                    {
                        tecrubeFiltre.Add(ıs);
                    }
                    else if (cbxTecrubeFilt.SelectedIndex == 4 && Convert.ToInt32(ıs.IstenilenTecrubeId) >= 10)
                    {
                        tecrubeFiltre.Add(ıs);
                    }
                }
            }
            return tecrubeFiltre;
        }
        public List<Is> OkulDurumuFiltre(List<Is> isler)
        {
            List<Is> okulFiltre = new List<Is>();
            if (cbxOkulFilt.Text == "" || cbxOkulFilt.Text == "İlkokul")
            {
                return isler;
            }

            foreach (var ıs in isler)
            {
                if (cbxOkulFilt.SelectedIndex <= cbxOkulFilt.FindString(ıs.OkulDurumu))
                {
                    okulFiltre.Add(ıs);
                }
            }

            return okulFiltre;
        }
        public List<Is> CalısmaDurumu(List<Is> isler)
        {
            List<Is> calismaFiltre = new List<Is>();
            if (cbxCalısmaFilt.Text == "")
            {
                return isler;
            }
            foreach (var ıs in isler)
            {
                if (ıs.CalismaSekli == cbxCalısmaFilt.Text)
                {
                    calismaFiltre.Add(ıs);
                }
            }
            return calismaFiltre;
        }
        public List<Is> Konum(List<Is> isler)
        {
            List<Is> konumFiltre = new List<Is>();
            if(cbxKonum.Text == "" || cbxKonum.Text == "FARKETMEZ")
            {
                return isler;
            }
            foreach (var ıs in isler)
            {
                if(ıs.Konum == cbxKonum.Text)
                {
                    konumFiltre.Add(ıs);
                }
            }
            return konumFiltre;
        }
        public List<Is> MeslekFilt(List<Is> isler)
        {
            List<Is> meslekFilt = new List<Is>();
            if ( cbxMeslek.Text == "FARKETMEZ")
            {
                return isler;
            }
            foreach (var ıs in isler)
            {
                if (ıs.MeslekAdi == cbxMeslek.Text)
                {
                    meslekFilt.Add(ıs);
                }
            }
            return meslekFilt;
        }
        public List<Is> SektorFilt(List<Is> isler)
        {
            List<Is> sektorFiltre = new List<Is>();
            if (cbxSektor.Text == "FARKETMEZ")
            {
                return isler;
            }
            foreach (var ıs in isler)
            {
                if (ıs.SektorAdi == cbxSektor.Text)
                {
                    sektorFiltre.Add(ıs);
                }
            }
            return sektorFiltre;
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            İlanlarıSıfırla();
            isler = Cinsiyetfiltrele(isler);
            isler = AskerFiltrele(isler);
            isler = MaasFiltre(isler);
            isler = TecrubeFiltre(isler);
            isler = OkulDurumuFiltre(isler);
            isler = CalısmaDurumu(isler);
            isler = Konum(isler);
            isler = MeslekFilt(isler);
            isler = SektorFilt(isler);
            filtreliIlanDoldur();
        }

        private void btnBasvuruYap_Click(object sender, EventArgs e)
        {
            Is ısIlan = new Is(); 
            foreach (var ıs in ısKod.GetAll())
            {
                if(ıs.IsId == Convert.ToInt32(dgwIlanlar.CurrentRow.Cells[0].Value))
                {
                    ısIlan = ıs;
                    break;
                }
            }
            if(ısIlan.IsId != 0)
            {
                if (!ısIlan.BasvuranlarId.Contains(arayan.ArayanId.ToString()))
                {
                    ısIlan.BasvuranlarId += arayan.ArayanId + ",";
                    ısKod.Update(ısIlan);
                    IlanDoldur();
                    MessageBox.Show("Başvurunuz gerçekleşti");
                }
                else
                {
                    MessageBox.Show("Daha önce başvuru yaptınız başvurunuz beklemede");
                }
            }
               
            else
            {
                MessageBox.Show("Tablodan bir ilan seçiniz");
            }
        }

        private void btnSıfırla_Click(object sender, EventArgs e)
        {
            IlanDoldur();
        }

        private void cbxMeslek_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbxMaasFilt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            ArayanGiris arayan = new ArayanGiris();
            this.Hide();
            arayan.Show();
        }
    }
}
