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

namespace IsIlaniOtomasyonu.MeslekBilgi
{
    public partial class MeslekKayit : Form
    {
        public MeslekKayit()
        {
            InitializeComponent();
        }
        MeslekKod meslekKod = new MeslekKod();

        private void btnEkle_Click(object sender, EventArgs e)
        {
            meslekKod.Add(new Meslek
            {
                MeslekAdi = tbxMeslekAdi.Text,
            });
            MeslekDoldur();
        }
        public void MeslekDoldur()
        {
            dgwMeslekler.DataSource = meslekKod.GetAll();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            meslekKod.Update(new Meslek
            {
                MeslekId = Convert.ToInt32(dgwMeslekler.CurrentRow.Cells[0].Value.ToString()),
                MeslekAdi = tbxMeslekAdi.Text,
            });
            MeslekDoldur();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            meslekKod.Delete(Convert.ToInt32(dgwMeslekler.CurrentRow.Cells[0].Value.ToString()));
            MeslekDoldur();
        }

        private void MeslekKayit_Load(object sender, EventArgs e)
        {
            MeslekDoldur();
        }

        private void dgwMeslekler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxMeslekAdi.Text = dgwMeslekler.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            YoneticiIsler yonetici = new YoneticiIsler();
            this.Hide();
            yonetici.Show();
        }
    }
}
