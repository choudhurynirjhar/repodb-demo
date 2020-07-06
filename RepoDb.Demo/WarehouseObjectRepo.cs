using Microsoft.Data.SqlClient;

namespace RepoDb.Demo
{
    public class WarehouseObjectRepo : IWarehouseObjectRepo
    {
        private readonly string connectionString;

        public WarehouseObjectRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Warehouse warehouse)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Insert(warehouse);
        }
    }
}
