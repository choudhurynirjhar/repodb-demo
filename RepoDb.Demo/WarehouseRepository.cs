using Microsoft.Data.SqlClient;

namespace RepoDb.Demo
{
    public class WarehouseRepository : BaseRepository<Warehouse, SqlConnection>
    {
        public WarehouseRepository(string connectionString) : base(connectionString)
        {
        }
    }
}