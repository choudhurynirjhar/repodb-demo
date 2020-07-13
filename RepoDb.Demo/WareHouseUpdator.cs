using Microsoft.Data.SqlClient;
using RepoDb.Interfaces;

namespace RepoDb.Demo
{
    public class WareHouseUpdator : IWareHouseUpdator
    {
        private readonly string connectionString;
        private readonly ITrace trace;

        public WareHouseUpdator(string connectionString,
            ITrace trace)
        {
            this.connectionString = connectionString;
            this.trace = trace;
        }

        public void Update(Warehouse warehouse)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Update(warehouse, trace: trace);
        }
    }
}
