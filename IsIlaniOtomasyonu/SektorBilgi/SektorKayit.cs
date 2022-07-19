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

namespace IsIlaniOtomasyonu.SektorBilgi
{
    public partial class SektorKayit : Form
    {
        public SektorKayit()
        {
            InitializeComponent();
        }
        SektorKod sektorKod = new SektorKod();
        public void SektorDoldur()
        {
            dgwSektorler.DataSource = sektorKod.GetAll();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            sektorKod.Add(new Sektor
            {

                SektorIsım = tbxSektorAdi.Text
            });
            SektorDoldur();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            sektorKod.Update(new Sektor
            {
                SektorId = Convert.ToInt32(dgwSektorler.CurrentRow.Cells[0].Value.ToString()),
                SektorIsım = tbxSektorAdi.Text
            });
            SektorDoldur();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            sektorKod.Delete(Convert.ToInt32(dgwSektorler.CurrentRow.Cells[0].Value.ToString()));
            SektorDoldur();
        }

        private void dgwSektorler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxSektorAdi.Text = dgwSektorler.CurrentRow.Cells[1].Value.ToString();
        }

        private void SektorKayit_Load(object sender, EventArgs e)
        {
            SektorDoldur();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            YoneticiIsler yonetici = new YoneticiIsler();
            this.Hide();
            yonetici.Show();
        }
    }
}
