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

namespace IsIlaniOtomasyonu.Girisler
{
    public partial class ArayanGiris : Form
    {
        public ArayanGiris()
        {
            InitializeComponent();
        }
        IsArayanKod arayanKod = new IsArayanKod();
        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void btnGeri_Click(object sender, EventArgs e)
        {
            AnaGiris giris = new AnaGiris();
            this.Hide();
            giris.Show();
        }

        private void btnGiris_Click_1(object sender, EventArgs e)
        {
            foreach (var arayan in arayanKod.GetAll())
            {
                if (arayan.ArayanTc == tbxTc.Text && arayan.ArayanSifre == tbxSifre.Text)
                {
                    IsArayanBasvuru arayanBasvuru = new IsArayanBasvuru();
                    arayanBasvuru.arayan = arayan;
                    this.Hide();
                    arayanBasvuru.Show();
                }
            }
        }

        private void ArayanGiris_Load(object sender, EventArgs e)
        {
            tbxSifre.PasswordChar = '*';
        }
    }
}
