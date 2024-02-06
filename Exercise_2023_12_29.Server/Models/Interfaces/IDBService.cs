using System.Data;
using System.Data.SqlClient;

namespace Exercise_2023_12_29.Server.Models.Interfaces
{
    public interface IDBService
    {
        public DataTable ExecuteQuery(string query);
    }
}
