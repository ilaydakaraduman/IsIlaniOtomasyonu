using IsIlaniOtomasyonu.IsBilgiler;
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

namespace IsIlaniOtomasyonu.Is_Veren
{
    public partial class IsVerenKayit : Form
    {
        public IsVerenKayit()
        {
            InitializeComponent();
        }
        string ResimYer = "";
        string ResimDestination = "";
        string Path = "";
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        bool ResimSecildiMi;
        int IsVerenId;
        bool fiyatOdendiMi = false;
        Regex regex = new Regex(@"^(\d{11,11}$)");
        Regex regex2 = new Regex(@"^(?=.{6,15}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[@#$%*?^:;+-._,])(?=.*[0-9]).*");
        IsVerenKod IsVeren = new IsVerenKod();
        int fiyat = 0;
       
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (regex2.Match(tbxSifre.Text).Success)//şifre oluşturma kuralı
                {


                    if (regex.Match(tbxTc.Text).Success)//tc kimlik hane kontrol
                    {

                        if (MessageBox.Show(" bütün bilgilerinin doğruluğundan emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            IsVeren.Add(new IsVeren
                            {
                                IsverenId = IsVerenId,
                                Ad = tbxAd.Text,
                                Soyad = tbxSoyad.Text,
                                SirketAd = tbxSirket.Text,
                                Tc = tbxTc.Text,
                                Sifre = tbxSifre.Text,
                                IlanSayi = Convert.ToInt32(tbxIlanSay.Text)

                            });
                            if (ResimSecildiMi)
                            {
                                File.Delete(Path + tbxTc.Text + ".jpg");
                                ResimSec(tbxTc.Text);
                            }

                            MessageBox.Show("Başvurunuz Başarıyla Eklenmiştir");
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

        private void IsVerenKayit_Load(object sender, EventArgs e)
        {
            Path = directory + @"IsverenResim\";
        }

        private void btnResimEkle_Click_1(object sender, EventArgs e)
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

        private void btnResimGuncelle_Click_1(object sender, EventArgs e)
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

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (regex2.Match(tbxSifre.Text).Success)//şifre oluşturma kuralı
                {


                    if (regex.Match(tbxTc.Text).Success)//tc kimlik hane kontrol
                    {
                        if (tbxIlanSay.Text != "" && tbxIlanSay.Text != "0")
                        {
                            if (fiyatOdendiMi)
                            {
                                if (MessageBox.Show(" bütün bilgilerinin doğruluğundan emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    IsVeren.Add(new IsVeren
                                    {
                                        Ad = tbxAd.Text,
                                        Soyad = tbxSoyad.Text,
                                        SirketAd = tbxSirket.Text,
                                        Tc = tbxTc.Text,
                                        Sifre = tbxSifre.Text,
                                        IlanSayi = Convert.ToInt32(tbxIlanSay.Text)

                                    });
                                    ResimSec();

                                    MessageBox.Show("CV niz Başarıyla Eklenmiştir");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ödemeyi henüz gerçekleştirmediniz.");
                            }

                        }
                        else
                        {
                            MessageBox.Show("İlan sayısı 0'dan farklı olmalıdır ya da boş bırakılamaz");
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

        private void btnOde_Click_1(object sender, EventArgs e)
        {
            fiyatOdendiMi = true;
            MessageBox.Show(lblBorc.Text + " tl ödeme gerçekleşti");
        }

        private void tbxIlanSay_TextChanged_2(object sender, EventArgs e)
        {
            if (tbxIlanSay.Text != "")
            {
                lblBorc.Text = (Convert.ToInt32(tbxIlanSay.Text) * fiyat).ToString();
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            AnaGiris giris = new AnaGiris();
            this.Hide();
            giris.Show();
        }

        private void btnpaket1_Click(object sender, EventArgs e)
        {
            fiyat = 52;
            if (tbxIlanSay.Text != "")
            {
                lblBorc.Text = (Convert.ToInt32(tbxIlanSay.Text) * fiyat).ToString();
            }
        }

        private void btnPaket2_Click(object sender, EventArgs e)
        {
            fiyat = 100;
            if (tbxIlanSay.Text != "")
            {
                lblBorc.Text = (Convert.ToInt32(tbxIlanSay.Text) * fiyat).ToString();
            }
        }

        private void btnPaket3_Click(object sender, EventArgs e)
        {
            fiyat = 300;
            if (tbxIlanSay.Text != "")
            {
                lblBorc.Text = (Convert.ToInt32(tbxIlanSay.Text) * fiyat).ToString();
            }
        }
    }
}
