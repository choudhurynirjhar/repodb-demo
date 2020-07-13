using Microsoft.Data.SqlClient;

namespace RepoDb.Demo
{
    public class WareHouseDeletor : IWareHouseDeletor
    {
        private readonly string connectionString;

        public WareHouseDeletor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Delete<Warehouse>(id);
        }
    }
}
