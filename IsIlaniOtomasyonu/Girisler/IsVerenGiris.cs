using IsIlaniOtomasyonu.Is_Veren;
using IsIlaniOtomasyonu.IsBilgiler;
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
    public partial class IsVerenGiris : Form
    {
        public IsVerenGiris()
        {
            InitializeComponent();
        }
        IsVerenKod ısverenKod = new IsVerenKod();
        public int IsSayi;
      
       

        private void button1_Click(object sender, EventArgs e)
        {
            AnaGiris giris = new AnaGiris();
            this.Hide();
            giris.Show();
        }

        private void btnGiris_Click_1(object sender, EventArgs e)
        {
            foreach (var isveren in ısverenKod.GetAll())
            {
                if (isveren.Tc == tbxTc.Text && isveren.Sifre == tbxSifre.Text)
                {
                    IsKayit ısKayit = new IsKayit();
                    ısKayit.isveren = isveren;
                    this.Hide();
                    ısKayit.Show();
                }
            }
        }

        private void IsVerenGiris_Load(object sender, EventArgs e)
        {
            tbxSifre.PasswordChar = '*';
        }
    }
}
