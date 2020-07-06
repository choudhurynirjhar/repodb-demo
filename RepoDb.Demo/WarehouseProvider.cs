using Microsoft.Data.SqlClient;
using System.Linq;

namespace RepoDb.Demo
{
    public class WarehouseProvider : IWarehouseProvider
    {
        private readonly string connectionString;

        public WarehouseProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Warehouse[] Get()
        {
            using var connection = new SqlConnection(connectionString);
            return connection.QueryAll<Warehouse>().ToArray();
        }

        public Warehouse Get(int id)
        {
            using var connection = new SqlConnection(connectionString);
            return connection.Query<Warehouse>(w => w.Id == id).FirstOrDefault();
        }
    }
}
