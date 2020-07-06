using System.Data.SqlClient;

namespace RepoDb.Demo
{
    public class WarehouseInlineRepo : IWarehouseInlineRepo
    {
        private readonly string connectionString;

        public WarehouseInlineRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Warehouse warehouse)
        {
            using var connection = new SqlConnection(connectionString);
            connection.ExecuteNonQuery("INSERT INTO Warehouse (Name, Address) VALUES (@Name, @Address)",
                new { warehouse.Name, warehouse.Address });
        }
    }
}
