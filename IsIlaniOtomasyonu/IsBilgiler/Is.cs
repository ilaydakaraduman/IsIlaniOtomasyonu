using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsIlaniOtomasyonu.IsBilgiler
{
    public class Is
    {
        public int IsId { get; set; }
        public string MeslekAdi { get; set; }
        public int MeslekId { get; set; }
        public string SektorAdi { get; set; }
        public int SektorId { get; set; }
        public string HizmetAdi { get; set; }
        public int HizmetId { get; set; }
        public string Konum { get; set; }
        public decimal Maas { get; set; }
        public int IsverenId { get; set; }
        public string BasvuranlarId { get; set; }
        public string IstenilenTecrube { get; set; }
        public int IstenilenTecrubeId { get; set; }
        public string AskerlikDurumu { get; set; }
        public string OkulDurumu { get; set; }
        public string Cinsiyet { get; set; }
        public string CalismaSekli { get; set; }
    }
}
