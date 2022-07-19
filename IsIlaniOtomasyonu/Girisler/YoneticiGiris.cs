using IsIlaniOtomasyonu.Yonetici;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsIlaniOtomasyonu.Girisler
{
    public partial class YoneticiGiris : Form
    {
        public YoneticiGiris()
        {
            InitializeComponent();
        }
        YoneticiKod yoneticiKod = new YoneticiKod();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            foreach (var yonetici in yoneticiKod.GetAll())
            {
                if(yonetici.TC == tbxTc.Text && yonetici.Sifre == tbxSifre.Text)
                {
                    YoneticiIsler yoneticiIsler = new YoneticiIsler();
                    yoneticiIsler.Show();
                    this.Hide();
                }
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            AnaGiris giris = new AnaGiris();
            this.Hide();
            giris.Show();
        }

        private void YoneticiGiris_Load(object sender, EventArgs e)
        {
            tbxSifre.PasswordChar = '*';
        }
    }
}
