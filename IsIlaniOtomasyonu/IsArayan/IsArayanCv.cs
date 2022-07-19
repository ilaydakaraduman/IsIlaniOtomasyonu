using IsIlaniOtomasyonu.MeslekBilgi;
using IsIlaniOtomasyonu.Yonetici;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsIlaniOtomasyonu.IsArayan
{
    public partial class IsArayanCv : Form
    {
        public IsArayanCv()
        {
            InitializeComponent();
        }
         int ArayanId;
        string ResimYer = "";
        string ResimDestination = "";
        string Path = "";
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        public string dgwTc;
        bool ResimSecildiMi;
        Regex regex = new Regex(@"^(\d{11,11}$)");
        Regex regex2 = new Regex(@"^(?=.{6,15}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[@#$%*?^:;+-._,])(?=.*[0-9]).*");
        DateTime Tarih = new DateTime(2020, 12, 31);
        int yas;
        public Arayan arayanTutucu;
        MeslekKod meslek = new MeslekKod();

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void IsArayanCv_Load(object sender, EventArgs e)
        {
            Path = directory + @"CvResim\";
            MeslekDoldur();
        }
        void MeslekDoldur()
        {
            cbxMeslek.DataSource = meslek.GetAll();
            cbxMeslek.DisplayMember = "MeslekAdi";
            cbxMeslek.ValueMember = "MeslekId";
        }
        IsArayanKod arayan = new IsArayanKod();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TimeSpan span = Tarih.Subtract(Convert.ToDateTime(tbxDogum.Text));
            yas = Convert.ToInt32(span.TotalDays) / 360;
            try
            {
                if (regex2.Match(tbxSifre.Text).Success)//şifre oluşturma kuralı
                {


                    if (regex.Match(tbxTc.Text).Success)//tc kimlik hane kontrol
                    {
                        if (yas > 18)//yas kontrolu
                        {
                            if (MessageBox.Show(" bütün bilgilerinin doğruluğundan emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                arayan.Add(new Arayan
                            {
                                ArayanAd = tbxAd.Text,
                                ArayanSoyad = tbxSoyad.Text,
                                ArayanCinsiyet = cbxCinsiyet.Text,
                                ArayanTc = tbxTc.Text,
                                DoğumTarihi = tbxDogum.Text,
                                Meslek= cbxMeslek.Text,
                                Maas=Convert.ToDecimal(tbxMaas.Text),
                                AskerlikDurumu = cbxAsker.Text,
                                Tecrube = cbxcalDurum.Text,
                                GecmisCalismaYerler = tbxOzgecmis.Text,
                                OkulDurumu = cbxOkul.Text,
                                CalışmaDurumu=cbxcalDurum.Text,
                                ArayanSifre = tbxSifre.Text,
                                DilSayisi=Convert.ToInt32(tbxDil.Text)
                                


                            });
                            ResimSec();
                           
                                MessageBox.Show("CV niz Başarıyla Eklenmiştir");
                            }


                        }
                        else
                        {
                            MessageBox.Show("Bu site içerisinde 18 yaş altı üyeler kayıt olamazlar");
                        }
                    }

                    else
                    {
                        MessageBox.Show("TC Kimlik numaranızı eksik veya fazla yazdınız");
                    }


                }
                else
                {
                    MessageBox.Show("Site Güvenliği Açısından oluşturduğunuz Şifre '6-15 karekter arasında olması ve min 1 küçük ve buyuk harf bulundurmaktadır.Güvenliği arttırmak amacıyla @#$%*?^:;+-._, özel karakterini kullanmanız gerekmektedir.");
                }

            }
            catch (Exception _hata)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu!" + _hata.Message);
            }


        }
        public void ResimSec(string resim)
        {
            ResimDestination = Path + resim + ".jpg";
            File.Copy(ResimYer, ResimDestination);

        }
        public void ResimSec()
        {
            string resim = tbxTc.Text;
            ResimDestination = Path + resim + ".jpg";
            File.Copy(ResimYer, ResimDestination);


        }

        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "Image Files(*.JPG;)|*.JPG;";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    ResimYer = dialog.FileName;
                    pbxResim.ImageLocation = ResimYer;

                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResimGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files(*.JPG;)|*.JPG;";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ResimSecildiMi = true;
                    ResimYer = dialog.FileName;
                    pbxResim.ImageLocation = ResimYer;

                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            TimeSpan span = Tarih.Subtract(Convert.ToDateTime(tbxDogum.Text));
            yas = Convert.ToInt32(span.TotalDays) / 360;
            try
            {
                if (regex2.Match(tbxSifre.Text).Success)//şifre oluşturma kuralı
                {


                    if (regex.Match(tbxTc.Text).Success)//tc kimlik hane kontrol
                    {
                        if (yas > 18)//yas kontrolu
                        {
                            if (MessageBox.Show(" bütün bilgilerinin doğruluğundan emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                arayan.Update(new Arayan
                                {
                                    ArayanId = ArayanId,
                                    ArayanAd = tbxAd.Text,
                                    ArayanSoyad = tbxSoyad.Text,
                                    ArayanCinsiyet = cbxCinsiyet.Text,
                                    ArayanTc = tbxTc.Text,
                                    DoğumTarihi = tbxDogum.Text,
                                    Meslek = cbxMeslek.Text,
                                    Maas = Convert.ToDecimal(tbxMaas.Text),
                                    AskerlikDurumu = cbxAsker.Text,
                                    Tecrube = cbxcalDurum.Text,
                                    GecmisCalismaYerler = tbxOzgecmis.Text,
                                    OkulDurumu = cbxOkul.Text,
                                    CalışmaDurumu = cbxcalDurum.Text,
                                    ArayanSifre = tbxSifre.Text,
                                    DilSayisi = Convert.ToInt32(tbxDil.Text)



                                }) ;
                                if (ResimSecildiMi)
                                {
                                    File.Delete(Path + tbxTc.Text + ".jpg");
                                    ResimSec(tbxTc.Text);
                                }

                                MessageBox.Show("CV niz Başarıyla Eklenmiştir");
                            }


                        }
                        else
                        {
                            MessageBox.Show("Bu site içerisinde 18 yaş altı üyeler kayıt olamazlar");
                        }
                    }

                    else
                    {
                        MessageBox.Show("TC Kimlik numaranızı eksik veya fazla yazdınız");
                    }


                }
                else
                {
                    MessageBox.Show("Site Güvenliği Açısından oluşturduğunuz Şifre '6-15 karekter arasında olması ve min 1 küçük ve buyuk harf bulundurmaktadır.Güvenliği arttırmak amacıyla @#$%*?^:;+-._, özel karakterini kullanmanız gerekmektedir.");
                }

            }
            catch (Exception _hata)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu!" + _hata.Message);
            }


        }
        YoneticiIsler yonetici = new YoneticiIsler();
        //public void DgwAliciDoldur()
        //{
        //    ArayanId = Convert.ToInt32(yonetici.dgwIsArayan.CurrentRow.Cells[0].Value);
        //    tbxAd.Text= yonetici.dgwIsArayan.CurrentRow.Cells[1].Value.ToString();
        //    tbxSoyad.Text=yonetici.dgwIsArayan.CurrentRow.Cells[2].Value.ToString();
        //    cbxCinsiyet.Text= yonetici.dgwIsArayan.CurrentRow.Cells[3].Value.ToString();
        //    tbxTc.Text= yonetici.dgwIsArayan.CurrentRow.Cells[4].Value.ToString();
        //    tbxDogum.Text= yonetici.dgwIsArayan.CurrentRow.Cells[5].Value.ToString();
        //    cbxMeslek.Text= yonetici.dgwIsArayan.CurrentRow.Cells[6].Value.ToString();
        //    tbxMaas.Text= yonetici.dgwIsArayan.CurrentRow.Cells[7].Value.ToString();
        //    cbxAsker.Text= yonetici.dgwIsArayan.CurrentRow.Cells[8].Value.ToString();
        //    cbxcalDurum.Text= yonetici.dgwIsArayan.CurrentRow.Cells[9].Value.ToString();
        //    tbxOzgecmis.Text= yonetici.dgwIsArayan.CurrentRow.Cells[10].Value.ToString();
        //    cbxOkul.Text= yonetici.dgwIsArayan.CurrentRow.Cells[11].Value.ToString();
        //    cbxcalDurum.Text= yonetici.dgwIsArayan.CurrentRow.Cells[12].Value.ToString();
        //    tbxSifre.Text= yonetici.dgwIsArayan.CurrentRow.Cells[13].Value.ToString();
        //    tbxDil.Text= yonetici.dgwIsArayan.CurrentRow.Cells[14].Value.ToString();

        //}

        private void btnGeri_Click(object sender, EventArgs e)
        {
            AnaGiris giris = new AnaGiris();

            this.Hide();
            giris.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnaGiris giris = new AnaGiris();
            this.Hide();
            giris.Show();
        }
    }
}
