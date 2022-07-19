using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsIlaniOtomasyonu.Is_Veren
{
    public class IsVerenKod
    {

        SqlConnection _connection = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB; initial catalog=IsIlaniOtomasyonu;integrated security=true");
            private void ConnectionControl()
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
            }
            public List<IsVeren> GetAll()
            {
                ConnectionControl();
                SqlCommand command = new SqlCommand("Select * from IsVeren", _connection);

                SqlDataReader reader = command.ExecuteReader();
                List<IsVeren> isVerenler = new List<IsVeren>();
                while (reader.Read())
                {
                    IsVeren isVeren = new IsVeren
                    {
                        IsverenId = Convert.ToInt32(reader["IsverenId"]),
                        Ad = reader["Ad"].ToString(),
                        Soyad = reader["Soyad"].ToString(),
                        SirketAd = reader["SirketAd"].ToString(),
                        Tc = reader["Tc"].ToString(),
                        Sifre = reader["Sifre"].ToString(),
                        IlanSayi = Convert.ToInt32(reader["IlanSayi"]),
                    };
                    isVerenler.Add(isVeren);
                }
                reader.Close();
                _connection.Close();
                return isVerenler;
            }
            public List<IsVeren> Search(string key)
            {
                ConnectionControl();
                SqlCommand command = new SqlCommand("Select * from IsVeren where Ad like '%" + key + "%'", _connection);

                SqlDataReader reader = command.ExecuteReader();
                List<IsVeren> isVerenler = new List<IsVeren>();
                while (reader.Read())
                {
                    IsVeren isVeren = new IsVeren
                    {
                        IsverenId = Convert.ToInt32(reader["IsverenId"]),
                        Ad = reader["Ad"].ToString(),
                        Soyad = reader["Soyad"].ToString(),
                        SirketAd = reader["SirketAd"].ToString(),
                        Tc = reader["Tc"].ToString(),
                        Sifre = reader["Sifre"].ToString(),
                        IlanSayi = Convert.ToInt32(reader["IlanSayi"]),
                    };
                    isVerenler.Add(isVeren);
                }
                reader.Close();
                _connection.Close();
                return isVerenler;
            }
            public void Add(IsVeren isVeren)
            {
                ConnectionControl();
                SqlCommand command = new SqlCommand("insert into IsVeren values(@Ad,@Soyad,@SirketAd ,@Tc , @Sifre, @IlanSayi)", _connection);
                command.Parameters.AddWithValue("@Ad", isVeren.Ad);
                command.Parameters.AddWithValue("@Soyad", isVeren.Soyad);
                command.Parameters.AddWithValue("@SirketAd", isVeren.SirketAd);
                command.Parameters.AddWithValue("@Tc", isVeren.Tc);
                command.Parameters.AddWithValue("@Sifre", isVeren.Sifre);
                command.Parameters.AddWithValue("@IlanSayi", isVeren.IlanSayi);
                command.ExecuteNonQuery();

                _connection.Close();

            }
            public void Update(IsVeren isVeren)
            {
                ConnectionControl();
                SqlCommand command = new SqlCommand("Update IsVeren set Ad=@Ad, Soyad=@Soyad,SirketAd=@SirketAd, Tc=@Tc ,Sifre=@Sifre, IlanSayi=@IlanSayi where IsverenId=@IsverenId", _connection);
                command.Parameters.AddWithValue("@Ad", isVeren.Ad);
                command.Parameters.AddWithValue("@Soyad", isVeren.Soyad);
                command.Parameters.AddWithValue("@SirketAd", isVeren.SirketAd);
                command.Parameters.AddWithValue("@Tc", isVeren.Tc);
                command.Parameters.AddWithValue("@Sifre", isVeren.Sifre);
                command.Parameters.AddWithValue("@IlanSayi", isVeren.IlanSayi);
                command.Parameters.AddWithValue("@IsverenId", isVeren.IsverenId);
                command.ExecuteNonQuery();

                _connection.Close();

            }
            public void Delete(int id)
            {
                ConnectionControl();
                SqlCommand command = new SqlCommand("Delete from IsVeren where IsverenId=@IsverenId", _connection);

                command.Parameters.AddWithValue("@IsverenId", id);
                command.ExecuteNonQuery();

                _connection.Close();

            }

        }
    }

