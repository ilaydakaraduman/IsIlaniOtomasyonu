using IsIlaniOtomasyonu.SektorBilgi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsIlaniOtomasyonu.Yonetici
{
   public class YoneticiKod
    {
        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=IsIlaniOtomasyonu;integrated security=true");
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public List<Yonetici> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Yonetici", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Yonetici> yoneticiler = new List<Yonetici>();
            while (reader.Read())
            {
                Yonetici yonetici = new Yonetici
                {
                    YoneticiId = Convert.ToInt32(reader["YoneticiId"]),
                    Sifre = reader["YoneticiSifre"].ToString(),
                    TC = reader["YoneticiTc"].ToString(),
                    Ad = reader["YoneticiAd"].ToString(),
                    Soyad = reader["YoneticiSoyad"].ToString(),
                };
                yoneticiler.Add(yonetici);
            }
            reader.Close();
            _connection.Close();
            return yoneticiler;
        }
    }
}
