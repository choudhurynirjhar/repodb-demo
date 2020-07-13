using Microsoft.Data.SqlClient;
using RepoDb.Interfaces;
using System.Linq;

namespace RepoDb.Demo
{
    public class WarehouseProvider : IWarehouseProvider
    {
        private readonly string connectionString;
        private readonly ICache cache;

        public WarehouseProvider(string connectionString, ICache cache)
        {
            this.connectionString = connectionString;
            this.cache = cache;
        }

        public Warehouse[] Get()
        {
            using var connection = new SqlConnection(connectionString);
            return connection.QueryAll<Warehouse>(cacheKey: "customAll", cache: cache).ToArray();
        }

        public Warehouse Get(int id)
        {
            using var connection = new SqlConnection(connectionString);
            return connection.Query<Warehouse>(w => w.Id == id).FirstOrDefault();
        }
    }
}
