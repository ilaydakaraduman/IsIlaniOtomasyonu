using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsIlaniOtomasyonu.HizmetBilgi
{
    public class HizmetKod
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
            SqlCommand command = new SqlCommand("Delete from Hizmetler where HizmetId=@HizmetId", _connection);

            command.Parameters.AddWithValue("@HizmetId", id);
            command.ExecuteNonQuery();

            _connection.Close();

        }

        public void Add(Hizmet hizmet)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into Hizmetler values(@HizmetAdi)", _connection);
            command.Parameters.AddWithValue("@HizmetAdi", hizmet.HizmetAdi);
            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(Hizmet hizmet)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Hizmetler set HizmetAdi=@HizmetAdi where HizmetId=@HizmetId", _connection);
            command.Parameters.AddWithValue("@HizmetId", hizmet.HizmetId);
            command.Parameters.AddWithValue("@HizmetAdi", hizmet.HizmetAdi);

            command.ExecuteNonQuery();

            _connection.Close();

        }

        public List<Hizmet> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Hizmetler", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Hizmet> hizmetler = new List<Hizmet>();
            while (reader.Read())
            {
                Hizmet hizmet = new Hizmet
                {
                    HizmetId = Convert.ToInt32(reader["HizmetId"]),
                    HizmetAdi = reader["HizmetAdi"].ToString(),
                };
                hizmetler.Add(hizmet);
            }
            reader.Close();
            _connection.Close();
            return hizmetler;
        }
    }
}
