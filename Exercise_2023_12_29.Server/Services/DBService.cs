using Exercise_2023_12_29.Server.Models.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace Exercise_2023_12_29.Server.Services
{
    public class DBService : IDBService
    {
        private readonly string _dbConnection;
        private readonly IConfiguration _configuration;

        public DBService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = _configuration.GetValue<string>("MySettings:DBConnection");
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = null;
            try
            {
                using SqlConnection conn = new SqlConnection(_dbConnection);
                conn.Open();
                using SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
    }
}