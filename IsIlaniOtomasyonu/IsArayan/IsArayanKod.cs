using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsIlaniOtomasyonu.IsArayan
{
    public class IsArayanKod
    {
        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=IsIlaniOtomasyonu;integrated security=true");
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public List<Arayan> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from IsArayan", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Arayan> Isarayanlar = new List<Arayan>();
            while (reader.Read())
            {
                Arayan arayan = new Arayan
                {
                    ArayanId = Convert.ToInt32(reader["ArayanId"]),
                    ArayanAd = reader["ArayanAd"].ToString(),
                    ArayanSoyad = reader["ArayanSoyad"].ToString(),
                    ArayanCinsiyet = reader["ArayanCinsiyet"].ToString(),
                    ArayanTc = reader["ArayanTc"].ToString(),
                    DoğumTarihi = reader["DoğumTarihi"].ToString(),
                    Meslek = reader["Meslek"].ToString(),
                    Maas = Convert.ToDecimal(reader["Maas"]),
                    AskerlikDurumu = reader["AskerlikDurumu"].ToString(),
                    Tecrube = reader["Tecrube"].ToString(),
                    GecmisCalismaYerler = reader["GecmisCalismaYerler"].ToString(),
                    OkulDurumu = reader["OkulDurumu"].ToString(),
                    CalışmaDurumu = reader["CalışmaDurumu"].ToString(),
                    ArayanSifre = reader["ArayanSifre"].ToString(),
                    DilSayisi = Convert.ToInt32(reader["DilSayisi"])
                };
                Isarayanlar.Add(arayan);
            }
            reader.Close();
            _connection.Close();
            return Isarayanlar;
        }
        public List<Arayan> Search(string key)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from IsArayan where ArayanAd like '%" + key + "%'", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Arayan> Isarayanlar = new List<Arayan>();
            while (reader.Read())
            {
                Arayan arayan = new Arayan
                {
                    ArayanId = Convert.ToInt32(reader["ArayanId"]),
                    ArayanAd = reader["ArayanAd"].ToString(),
                    ArayanSoyad = reader["ArayanSoyad"].ToString(),
                    ArayanCinsiyet = reader["ArayanCinsiyet"].ToString(),
                    ArayanTc = reader["ArayanTc"].ToString(),
                    DoğumTarihi = reader["DoğumTarihi"].ToString(),
                    Meslek = reader["Meslek"].ToString(),
                    Maas = Convert.ToDecimal(reader["Maas"]),
                    AskerlikDurumu = reader["AskerlikDurumu"].ToString(),
                    Tecrube = reader["Tecrube"].ToString(),
                    GecmisCalismaYerler = reader["GecmisCalismaYerler"].ToString(),
                    OkulDurumu = reader["OkulDurumu"].ToString(),
                    CalışmaDurumu = reader["CalışmaDurumu"].ToString(),
                    ArayanSifre = reader["ArayanSifre"].ToString(),
                    DilSayisi = Convert.ToInt32(reader["DilSayisi"])
                };
                Isarayanlar.Add(arayan);
            }
            reader.Close();
            _connection.Close();
            return Isarayanlar;
        }
        public void Add(Arayan Isarayan)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into IsArayan values(@ArayanAd,@ArayanSoyad,@ArayanCinsiyet,@ArayanTc,@DoğumTarihi ,@Meslek,@Maas,@AskerlikDurumu ,@Tecrube , @GecmisCalismaYerler , @OkulDurumu ,@CalışmaDurumu , @ArayanSifre ,@DilSayisi)", _connection);
            command.Parameters.AddWithValue("@ArayanAd", Isarayan.ArayanAd);
            command.Parameters.AddWithValue("@ArayanSoyad", Isarayan.ArayanSoyad);
            command.Parameters.AddWithValue("@ArayanCinsiyet", Isarayan.ArayanCinsiyet);
            command.Parameters.AddWithValue("@ArayanTc", Isarayan.ArayanTc);
            command.Parameters.AddWithValue("@DoğumTarihi", Isarayan.DoğumTarihi);
            command.Parameters.AddWithValue("@Meslek", Isarayan.Meslek);
            command.Parameters.AddWithValue("@Maas", Isarayan.Maas);
            command.Parameters.AddWithValue("@AskerlikDurumu", Isarayan.AskerlikDurumu);
            command.Parameters.AddWithValue("@Tecrube", Isarayan.Tecrube);
            command.Parameters.AddWithValue("@GecmisCalismaYerler", Isarayan.GecmisCalismaYerler);
            command.Parameters.AddWithValue("@OkulDurumu", Isarayan.OkulDurumu);
            command.Parameters.AddWithValue("@CalışmaDurumu", Isarayan.CalışmaDurumu);
            command.Parameters.AddWithValue("@ArayanSifre", Isarayan.ArayanSifre);
            command.Parameters.AddWithValue("@DilSayisi", Isarayan.DilSayisi);
            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(Arayan Isarayan)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update IsArayan set ArayanAd=@ArayanAd, ArayanSoyad=@ArayanSoyad, ArayanCinsiyet=@ArayanCinsiyet, ArayanTc=@ArayanTc, DoğumTarihi=@DoğumTarihi Meslek=@Meslek, Maas=@Maas, AskerlikDurumu=@AskerlikDurumu, Tecrube=@Tecrube , GecmisCalismaYerler=@GecmisCalismaYerler ,OkulDurumu=@OkulDurumu , CalışmaDurumu=@CalışmaDurumu ,ArayanSifre=@ArayanSifre , DilSayisi=@DilSayisi where ArayanId=@ArayanId", _connection);
            command.Parameters.AddWithValue("@ArayanAd", Isarayan.ArayanAd);
            command.Parameters.AddWithValue("@ArayanSoyad", Isarayan.ArayanSoyad);
            command.Parameters.AddWithValue("@ArayanCinsiyet", Isarayan.ArayanCinsiyet);
            command.Parameters.AddWithValue("@ArayanTc", Isarayan.ArayanTc);
            command.Parameters.AddWithValue("@DoğumTarihi", Isarayan.DoğumTarihi);
            command.Parameters.AddWithValue("@Meslek", Isarayan.Meslek);
            command.Parameters.AddWithValue("@Maas", Isarayan.Maas);
            command.Parameters.AddWithValue("@AskerlikDurumu", Isarayan.AskerlikDurumu);
            command.Parameters.AddWithValue("@Tecrube", Isarayan.Tecrube);
            command.Parameters.AddWithValue("@GecmisCalismaYerler", Isarayan.GecmisCalismaYerler);
            command.Parameters.AddWithValue("@OkulDurumu", Isarayan.OkulDurumu);
            command.Parameters.AddWithValue("@CalışmaDurumu", Isarayan.CalışmaDurumu);
            command.Parameters.AddWithValue("@ArayanSifre", Isarayan.ArayanSifre);
            command.Parameters.AddWithValue("@DilSayisi", Isarayan.DilSayisi);
            command.Parameters.AddWithValue("@ArayanId", Isarayan.ArayanId);

            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Delete from IsArayan where ArayanId=@ArayanId", _connection);

            command.Parameters.AddWithValue("@ArayanId", id);
            command.ExecuteNonQuery();

            _connection.Close();

        }
    }
}
