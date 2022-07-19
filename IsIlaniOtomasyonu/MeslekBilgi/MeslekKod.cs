using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsIlaniOtomasyonu.MeslekBilgi
{
    public class MeslekKod
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
            SqlCommand command = new SqlCommand("Delete from Meslekler where MeslekId=@MeslekId", _connection);

            command.Parameters.AddWithValue("@MeslekId", id);
            command.ExecuteNonQuery();

            _connection.Close();

        }

        public void Add(Meslek meslek)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into Meslekler values(@MeslekAdi)", _connection);
            command.Parameters.AddWithValue("@MeslekAdi", meslek.MeslekAdi);
            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(Meslek meslek)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Meslekler set MeslekAdi=@MeslekAdi where MeslekId=@MeslekId", _connection);
            command.Parameters.AddWithValue("@MeslekId", meslek.MeslekId);
            command.Parameters.AddWithValue("@MeslekAdi", meslek.MeslekAdi);

            command.ExecuteNonQuery();

            _connection.Close();

        }

        public List<Meslek> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Meslekler", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Meslek> meslekler = new List<Meslek>();
            while (reader.Read())
            {
                Meslek meslek = new Meslek
                {
                    MeslekId = Convert.ToInt32(reader["MeslekId"]),
                    MeslekAdi = reader["MeslekAdi"].ToString(),
                };
                meslekler.Add(meslek);
            }
            reader.Close();
            _connection.Close();
            return meslekler;
        }
    }
}
