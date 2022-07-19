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

namespace IsIlaniOtomasyonu.HizmetBilgi
{
    public partial class HizmetKayit : Form
    {
        public HizmetKayit()
        {
            InitializeComponent();
        }
        HizmetKod hizmetKod = new HizmetKod();
        
        public void HizmetDoldur()
        {
            dgwHizmetler.DataSource = hizmetKod.GetAll();
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            hizmetKod.Add(new Hizmet
            {
                HizmetAdi = tbxHizmetAdi.Text,
            });
            HizmetDoldur();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            hizmetKod.Update(new Hizmet
            {
                HizmetId = Convert.ToInt32(dgwHizmetler.CurrentRow.Cells[0].Value),
                HizmetAdi = tbxHizmetAdi.Text,

            }
           );
            HizmetDoldur();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            hizmetKod.Delete(Convert.ToInt32(dgwHizmetler.CurrentRow.Cells[0].Value));
            HizmetDoldur();
        }

        private void dgwHizmetler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxHizmetAdi.Text = dgwHizmetler.CurrentRow.Cells[1].Value.ToString();

        }

        private void HizmetKayit_Load(object sender, EventArgs e)
        {
            HizmetDoldur();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            YoneticiIsler yonetici = new YoneticiIsler();
            this.Hide();
            yonetici.Show();
        }
    }
}
