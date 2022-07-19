using IsIlaniOtomasyonu.HizmetBilgi;
using IsIlaniOtomasyonu.Is_Veren;
using IsIlaniOtomasyonu.IsArayan;
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

namespace IsIlaniOtomasyonu.Yonetici
{
    public partial class YoneticiIsler : Form
    {
        public YoneticiIsler()
        {
            InitializeComponent();
        }
        
        IsVerenKod isVerenKod = new IsVerenKod();
       IsArayanKod isArayanKod = new IsArayanKod();
        IsKod ısKod = new IsKod();
        public void IsArayanDoldur()
       {
            dgwIsArayan.DataSource= isArayanKod.GetAll();
        }
        public void IsVerenDoldur()
         {
            dgwIsVeren.DataSource = isVerenKod.GetAll();
        }
       private void btnIsVerenSil_Click(object sender, EventArgs e)
       {
           int id = Convert.ToInt32(dgwIsVeren.CurrentRow.Cells[0].Value);
           isVerenKod.Delete(id);
            if (MessageBox.Show("Silmek istediğine emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               MessageBox.Show("İş veren Sistemden Başarıyla Silinmiştir");
            }
           IsVerenDoldur();
        }

       private void btnAliciSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwIsArayan.CurrentRow.Cells[0].Value);
            isArayanKod.Delete(id);
            if (MessageBox.Show("Silmek istediğine emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Alıcı Sistemden Başarıyla Silinmiştir");
            }
            IsArayanDoldur();

        }

       private void YoneticiIsler_Load(object sender, EventArgs e)
       {
           IsArayanDoldur();
           IsVerenDoldur();
       }
        private void dgwIsVeren_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnIsVerenSil_Click_1(object sender, EventArgs e)
        {
            foreach (var ıs in ısKod.GetAll())
            {
                if(ıs.IsverenId == Convert.ToInt32(dgwIsVeren.CurrentRow.Cells[0].Value))
                {
                    ısKod.Delete(ıs.IsId);
                }
            }
            isVerenKod.Delete(Convert.ToInt32(dgwIsVeren.CurrentRow.Cells[0].Value));
            IsVerenDoldur();
        }

        private void btnAliciSil_Click_1(object sender, EventArgs e)
        {
            isArayanKod.Delete(Convert.ToInt32(dgwIsArayan.CurrentRow.Cells[0].Value));
            IsArayanDoldur();
        }

        private void btnHizmet_Click(object sender, EventArgs e)
        {
            HizmetKayit hizmet = new HizmetKayit();
            this.Hide();
            hizmet.Show();
        }

        private void btnMeslek_Click(object sender, EventArgs e)
        {
            MeslekKayit meslek = new MeslekKayit();
            this.Hide();
            meslek.Show();
        }

        private void btnSektor_Click(object sender, EventArgs e)
        {
            SektorKayit sektor = new SektorKayit();
            this.Hide();
            sektor.Show();
        }

        private void btnTarife_Click(object sender, EventArgs e)
        {
            Fiyatlandirma fiyatlandirma = new Fiyatlandirma();
            //this.Hide();
            fiyatlandirma.Show();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            AnaGiris giris = new AnaGiris();
            this.Hide();
            giris.Show();
        }
    }
}

