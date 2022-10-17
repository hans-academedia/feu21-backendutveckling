using Dapper;
using Microsoft.Data.SqlClient;

namespace WebApi.Services
{
    public class SqlHandler<T> where T : class
    {
        private readonly string connectionString = @"Server=tcp:feu21-sqlserver.database.windows.net,1433;Initial Catalog=azure_db;Persist Security Info=False;User ID=SqlAdmin;Password=BytMig123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // skapa ett nytt record i databasen
        public async Task CreateAsync(string query, T entity)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.ExecuteAsync(query, entity);
        }

        // hämta ut record(s) från databasen
        public async Task<IEnumerable<object>> GetAsync(string query)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<object>(query);
        }
    }
}
