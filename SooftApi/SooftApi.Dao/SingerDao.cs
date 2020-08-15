using System;
using System.Collections.Generic;
using System.Linq;
using SooftApi.Model;
using SooftApi.Data;
using System.Data.SqlClient;

namespace SooftApi.Dao
{
    public class SingerDao : BaseDao
    {
        public override List<SingerModel> GetSingers()
        {
            List<SingerModel> singers = new List<SingerModel>();
            try
            {
                using (SqlConnection connection = Conection.GetConection())
                {
                    string query = "select * from singersTable";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        singers.Add(new SingerModel 
                        {
                            Name = sqlDataReader.GetString(0),
                            KindOfMusic = sqlDataReader.GetString(1),
                            Songs = sqlDataReader.GetString(0).Split(',').ToList()
                        });
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return singers;
        }

        public override List<SingerModel> GetSingersByKindOfMusic(string kindOfMusic)
        {
            List<SingerModel> singers = new List<SingerModel>();
            try
            {
                using (SqlConnection connection = Conection.GetConection())
                {
                    string query = "select * from singersTable where kindOfMusic = @kindOfMusic";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.Parameters.AddWithValue("@kindOfMusic", kindOfMusic);
                    connection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        singers.Add(new SingerModel
                        {
                            Name = sqlDataReader.GetString(0),
                            KindOfMusic = sqlDataReader.GetString(1),
                            Songs = sqlDataReader.GetString(0).Split(',').ToList()
                        });
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return singers;
        }

        public override bool InsertSinger(SingerModel singer)
        {
            bool existSinger = false;
            bool inserted = !existSinger;
            List<SingerModel> singers = GetSingers();
            try
            {
                existSinger = singers.Any(x => x.Name == singer.Name);
                if (!existSinger)
                {
                    using (SqlConnection connection = Conection.GetConection())
                    {
                        string query = "insert into singersTable values (@name, @kindOfMusic, @songs)";
                        SqlCommand sqlCommand = new SqlCommand(query, connection);
                        sqlCommand.Parameters.AddWithValue("@name", singer.Name);
                        sqlCommand.Parameters.AddWithValue("@kindOfMusic", singer.KindOfMusic);
                        sqlCommand.Parameters.AddWithValue("@songs", string.Join(",", singer.Songs));
                        connection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return inserted;
        }
    }
}
