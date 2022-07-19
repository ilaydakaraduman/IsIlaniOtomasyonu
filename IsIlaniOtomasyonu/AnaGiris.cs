using IsIlaniOtomasyonu.Girisler;
using IsIlaniOtomasyonu.Is_Veren;
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

namespace IsIlaniOtomasyonu
{
    public partial class AnaGiris : Form
    {
        public AnaGiris()
        {
            InitializeComponent();
        }
        ArayanGiris arayangiris = new ArayanGiris();
        IsVerenGiris IsVeren = new IsVerenGiris();
        YoneticiGiris yonetici = new YoneticiGiris();
        IsVerenKayit IsVerenKayit = new IsVerenKayit();
        IsArayanCv ArayanCv = new IsArayanCv();
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            IsVeren.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            IsVerenKayit.Show();
        }

        private void gİRİŞYAPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            arayangiris.Show();
        }

        private void üYEOLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ArayanCv.Show();
        }

        private void gİRİŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            yonetici.Show();
        }

        private void btnIsGoruntule_Click(object sender, EventArgs e)
        {
            Fiyatlandirma fiyatlandirma = new Fiyatlandirma();
            fiyatlandirma.Show();
        }

       
    }
}
