using System.Data.SqlClient;

namespace RepoDb.Demo
{
    public class WarehouseProcedureRepo : IWarehouseProcedureRepo
    {
        private readonly string connectionString;

        public WarehouseProcedureRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Warehouse warehouse)
        {
            using var connection = new SqlConnection(connectionString);
            connection.ExecuteNonQuery("EXEC dbo.AddWarehouse @Name, @Address",
                new { warehouse.Name, warehouse.Address });
        }
    }
}
