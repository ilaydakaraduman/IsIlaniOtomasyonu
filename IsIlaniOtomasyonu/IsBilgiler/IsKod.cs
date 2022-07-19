using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsIlaniOtomasyonu.IsBilgiler
{
    public class IsKod
    {
        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=IsIlaniOtomasyonu;integrated security=true");
        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Delete from Isler where IsId=@IsId", _connection);

            command.Parameters.AddWithValue("@IsId", id);
            command.ExecuteNonQuery();

            _connection.Close();

        }

        public void Add(Is ıs)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into Isler values(@MeslekAdi,@MeslekId,@SektorAdi,@SektorId,@HizmetAdi,@HizmetId,@Konum,@Maas,@IsverenId,@BasvuranlarId,@IstenilenTecrube,@IstenilenTecrubeId,@AskerlikDurumu,@OkulDurumu,@Cinsiyet,@CalismaSekli)", _connection);
            command.Parameters.AddWithValue("@MeslekAdi", ıs.MeslekAdi);
            command.Parameters.AddWithValue("@MeslekId", ıs.MeslekId);
            command.Parameters.AddWithValue("@SektorAdi", ıs.SektorAdi);
            command.Parameters.AddWithValue("@SektorId", ıs.SektorId);
            command.Parameters.AddWithValue("@HizmetAdi", ıs.HizmetAdi);
            command.Parameters.AddWithValue("@HizmetId", ıs.HizmetId);
            command.Parameters.AddWithValue("@Konum", ıs.Konum);
            command.Parameters.AddWithValue("@Maas", ıs.Maas);
            command.Parameters.AddWithValue("@IsverenId", ıs.IsverenId);
            command.Parameters.AddWithValue("@BasvuranlarId", ıs.BasvuranlarId);
            command.Parameters.AddWithValue("@IstenilenTecrube", ıs.IstenilenTecrube);
            command.Parameters.AddWithValue("@IstenilenTecrubeId", ıs.IstenilenTecrubeId);
            command.Parameters.AddWithValue("@AskerlikDurumu", ıs.AskerlikDurumu);
            command.Parameters.AddWithValue("@OkulDurumu", ıs.OkulDurumu);
            command.Parameters.AddWithValue("@Cinsiyet", ıs.Cinsiyet);
            command.Parameters.AddWithValue("@CalismaSekli", ıs.CalismaSekli);

            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(Is ıs)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Isler set MeslekAdi=@MeslekAdi,MeslekId=@MeslekId,SektorAdi=@SektorAdi,SektorId=@SektorId,HizmetAdi=@HizmetAdi,HizmetId=@HizmetId,Konum=@Konum,Maas=@Maas,IsverenId=@IsverenId,BasvuranlarId=@BasvuranlarId,IstenilenTecrube=@IstenilenTecrube,IstenilenTecrubeId=@IstenilenTecrubeId,AskerlikDurumu=@AskerlikDurumu,OkulDurumu=@OkulDurumu,Cinsiyet=@Cinsiyet,CalismaSekli=@CalismaSekli where IsId=@IsId", _connection);
            command.Parameters.AddWithValue("@IsId", ıs.IsId);
            command.Parameters.AddWithValue("@MeslekAdi", ıs.MeslekAdi);
            command.Parameters.AddWithValue("@MeslekId", ıs.MeslekId);
            command.Parameters.AddWithValue("@SektorAdi", ıs.SektorAdi);
            command.Parameters.AddWithValue("@SektorId", ıs.SektorId);
            command.Parameters.AddWithValue("@HizmetAdi", ıs.HizmetAdi);
            command.Parameters.AddWithValue("@HizmetId", ıs.HizmetId);
            command.Parameters.AddWithValue("@Konum", ıs.Konum);
            command.Parameters.AddWithValue("@Maas", ıs.Maas);
            command.Parameters.AddWithValue("@IsverenId", ıs.IsverenId);
            command.Parameters.AddWithValue("@BasvuranlarId", ıs.BasvuranlarId);
            command.Parameters.AddWithValue("@IstenilenTecrube", ıs.IstenilenTecrube);
            command.Parameters.AddWithValue("@IstenilenTecrubeId", ıs.IstenilenTecrubeId);
            command.Parameters.AddWithValue("@AskerlikDurumu", ıs.AskerlikDurumu);
            command.Parameters.AddWithValue("@OkulDurumu", ıs.OkulDurumu);
            command.Parameters.AddWithValue("@Cinsiyet", ıs.Cinsiyet);
            command.Parameters.AddWithValue("@CalismaSekli", ıs.CalismaSekli);
            command.ExecuteNonQuery();

            _connection.Close();

        }

        public List<Is> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Isler", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Is> isler = new List<Is>();
            while (reader.Read())
            {
                Is ıs = new Is
                {
                    IsId = Convert.ToInt32(reader["IsId"]),
                    MeslekAdi = reader["MeslekAdi"].ToString(),
                    MeslekId = Convert.ToInt32(reader["MeslekId"].ToString()),
                    SektorAdi = reader["SektorAdi"].ToString(),
                    SektorId = Convert.ToInt32(reader["SektorId"].ToString()),
                    HizmetAdi = reader["HizmetAdi"].ToString(),
                    HizmetId = Convert.ToInt32(reader["HizmetId"].ToString()),
                    Konum = reader["Konum"].ToString(),
                    Maas = Convert.ToDecimal(reader["Maas"].ToString()),
                    IsverenId = Convert.ToInt32(reader["IsverenId"].ToString()),
                    BasvuranlarId = reader["BasvuranlarId"].ToString(),
                    IstenilenTecrube = reader["IstenilenTecrube"].ToString(),
                    IstenilenTecrubeId = Convert.ToInt32(reader["IstenilenTecrubeId"].ToString()),
                    AskerlikDurumu = reader["AskerlikDurumu"].ToString(),
                    OkulDurumu = reader["OkulDurumu"].ToString(),
                    Cinsiyet = reader["Cinsiyet"].ToString(),
                    CalismaSekli = reader["CalismaSekli"].ToString(),
                };
                isler.Add(ıs);
            }
            reader.Close();
            _connection.Close();
            return isler;
        }
        public List<Is> KullanıcıIsIlanıGetir(int key)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Isler where IsverenId ='" + key + "'", _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Is> isler = new List<Is>();
            while (reader.Read())
            {
                Is ıs = new Is
                {
                    IsId = Convert.ToInt32(reader["IsId"]),
                    MeslekAdi = reader["MeslekAdi"].ToString(),
                    MeslekId = Convert.ToInt32(reader["MeslekId"].ToString()),
                    SektorAdi = reader["SektorAdi"].ToString(),
                    SektorId = Convert.ToInt32(reader["SektorId"].ToString()),
                    HizmetAdi = reader["HizmetAdi"].ToString(),
                    HizmetId = Convert.ToInt32(reader["HizmetId"].ToString()),
                    Konum = reader["Konum"].ToString(),
                    Maas = Convert.ToDecimal(reader["Maas"].ToString()),
                    IsverenId = Convert.ToInt32(reader["IsverenId"].ToString()),
                    BasvuranlarId = reader["BasvuranlarId"].ToString(),
                    IstenilenTecrube = reader["IstenilenTecrube"].ToString(),
                    IstenilenTecrubeId = Convert.ToInt32(reader["IstenilenTecrubeId"].ToString()),
                    AskerlikDurumu = reader["AskerlikDurumu"].ToString(),
                    OkulDurumu = reader["OkulDurumu"].ToString(),
                    Cinsiyet = reader["Cinsiyet"].ToString(),
                    CalismaSekli = reader["CalismaSekli"].ToString(),
                };
                isler.Add(ıs);
            }
            reader.Close();
            _connection.Close();
            return isler;
        }
       
    }
}
