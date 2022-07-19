using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsIlaniOtomasyonu.SektorBilgi
{
    public class SektorKod
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
            SqlCommand command = new SqlCommand("Delete from Sektorler where SektorId=@SektorId", _connection);

            command.Parameters.AddWithValue("@SektorId", id);
            command.ExecuteNonQuery();

            _connection.Close();

        }

        public void Add(Sektor sektör)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("insert into Sektorler values(@SektorIsım)", _connection);
            command.Parameters.AddWithValue("@SektorIsım", sektör.SektorIsım);
            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Update(Sektor sektör)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Update Sektorler set SektorIsım=@SektorIsım where SektorId=@SektorId", _connection);
            command.Parameters.AddWithValue("@SektorId", sektör.SektorId);
            command.Parameters.AddWithValue("@SektorIsım", sektör.SektorIsım);

            command.ExecuteNonQuery();

            _connection.Close();

        }

        public List<Sektor> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Sektorler", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Sektor> sektorler = new List<Sektor>();
            while (reader.Read())
            {
                Sektor sektor = new Sektor
                {
                    SektorId = Convert.ToInt32(reader["SektorId"]),
                    SektorIsım = reader["SektorIsım"].ToString(),
                };
                sektorler.Add(sektor);
            }
            reader.Close();
            _connection.Close();
            return sektorler;
        }
    }
}
