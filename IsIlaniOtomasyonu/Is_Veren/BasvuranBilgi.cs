using IsIlaniOtomasyonu.IsArayan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsIlaniOtomasyonu.Is_Veren
{
    public partial class BasvuranBilgi : Form
    {
        public BasvuranBilgi()
        {
            InitializeComponent();
        }
        public string basvuranlar;
        string[] basvurlanlarArr;
        List<string> basvurlanlarlist = new List<string>();
        List<Arayan> arayanlar = new List<Arayan>();
        List<Arayan> currentArayanlar = new List<Arayan>();
        IsArayanKod arayanKod = new IsArayanKod();
       
        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            ArayanlarSıfırla();
            arayanlar = Cinsiyetfiltrele(arayanlar);
            arayanlar = AskerFiltrele(arayanlar);
            arayanlar = MaasFiltre(arayanlar);
            arayanlar = TecrubeFiltre(arayanlar);
            arayanlar = OkulDurumuFiltre(arayanlar);
            arayanlar = CalısmaDurumu(arayanlar);
            BasvuranlarıGetir();
        }

        private void BasvuranBilgi_Load(object sender, EventArgs e)
        {
            ArayanlarSıfırla();
            BasvuranlarıGetir();
        }
        public void BasvuranlarıGetir()
        {
            dgwBasvuranlar.DataSource = arayanlar;
        }
        public void Sıfırla()
        {
            dgwBasvuranlar.DataSource = currentArayanlar;
        }
        public void ArayanlarSıfırla()
        {
            arayanlar.Clear();
            currentArayanlar.Clear();
            string phrase = basvuranlar;
            basvurlanlarArr = phrase.Split(',');
            foreach (var basvuran in basvurlanlarArr)
            {
                foreach (var arayan in arayanKod.GetAll())
                {
                    if(basvuran != "")
                    {
                        if (arayan.ArayanId == Convert.ToInt32(basvuran))
                        {
                            arayanlar.Add(arayan);
                            currentArayanlar.Add(arayan);
                        }
                    }
                }
            }
        }
        public List<Arayan> Cinsiyetfiltrele(List<Arayan> arayans)
        {
            List<Arayan> cinsiyetFiltre = new List<Arayan>();
            if (cbxCinsiyet.Text == "" )
            {
                return arayans;
            }
            if(cbxCinsiyet.Text == "FARKETMEZ")
            {
                return arayans;
            }
            foreach (var arayan in arayans)
            {
                if (cbxCinsiyet.Text == arayan.ArayanCinsiyet)
                {
                    cinsiyetFiltre.Add(arayan);
                }
            }
            return cinsiyetFiltre;
        }
        public List<Arayan> AskerFiltrele(List<Arayan> arayans)
        {
            List<Arayan> askerFiltre = new List<Arayan>();

            if (cbxAskerlik.Text == "" || cbxAskerlik.Text == "ÖNEMSİZ")
            {
                return arayans;
            }
            foreach (var arayan in arayans)
            {
                if (cbxAskerlik.Text == "ÖNEMLİ")
                {
                    if (arayan.AskerlikDurumu == "YAPTI" || arayan.AskerlikDurumu == "MUAF")
                    {
                        askerFiltre.Add(arayan);
                    }
                }
            }

            return askerFiltre;

        }
        public List<Arayan> MaasFiltre(List<Arayan> arayans)
        {
            List<Arayan> maasFiltre = new List<Arayan>();
            if (tbxMaas.Text == "")
            {
                return arayans;
            }
            else
            {
                foreach (var arayan in arayans)
                {
                    if (arayan.Maas < Convert.ToDecimal(tbxMaas.Text))
                    {
                        maasFiltre.Add(arayan);
                    }
                }
            }
            return maasFiltre;
        }
        public List<Arayan> TecrubeFiltre(List<Arayan> arayans)
        {
            List<Arayan> tecrubeFiltre = new List<Arayan>();
            if (cbxTecrube.Text == "" || cbxTecrube.Text == "0")
            {
                return arayans;
            }
            else
            {
                foreach (var arayan in arayans)
                {
                    if (cbxTecrube.SelectedIndex == 1 && Convert.ToInt32(arayan.Tecrube) > 0)
                    {
                        tecrubeFiltre.Add(arayan);
                    }

                    else if (cbxTecrube.SelectedIndex == 2 && Convert.ToInt32(arayan.Tecrube) >= 2)
                    {
                        tecrubeFiltre.Add(arayan);
                    }
                    else if (cbxTecrube.SelectedIndex == 3 && Convert.ToInt32(arayan.Tecrube) >= 5)
                    {
                        tecrubeFiltre.Add(arayan);
                    }
                    else if (cbxTecrube.SelectedIndex == 4 && Convert.ToInt32(arayan.Tecrube) >= 10)
                    {
                        tecrubeFiltre.Add(arayan);
                    }
                }


            }
            return tecrubeFiltre;
        }
        public List<Arayan> OkulDurumuFiltre(List<Arayan> arayans)
        {
            List<Arayan> okulFiltre = new List<Arayan>();
            if (cbxOkul.Text == "" || cbxOkul.Text == "İlkokul")
            {
                return arayans;
            }

            foreach (var arayan in arayans)
            {
                if (cbxOkul.SelectedIndex <= cbxOkul.FindString(arayan.OkulDurumu))
                {
                    okulFiltre.Add(arayan);
                }
            }

            return okulFiltre;
        }
        public List<Arayan> CalısmaDurumu(List<Arayan> arayans)
        {
            List<Arayan> calismaFiltre = new List<Arayan>();
            if (cbxCalisma.Text == "")
            {
                return arayans;
            }
            foreach (var arayan in arayans)
            {
                if (arayan.CalışmaDurumu == cbxCalisma.Text)
                {
                    calismaFiltre.Add(arayan);
                }
            }
            return calismaFiltre;
        }

        private void btnSıfırla_Click(object sender, EventArgs e)
        {
            Sıfırla();
        }
    }
}
