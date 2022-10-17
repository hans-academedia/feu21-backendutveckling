using _01_WebApi_Sql.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace _01_WebApi_Sql.Services
{
    public class SqlManager<T> where T : class
    {
        private readonly string connectionString = "Server=tcp:feu21-sqlserver.database.windows.net,1433;Initial Catalog=azure_db;Persist Security Info=False;User ID=SqlAdmin;Password=BytMig123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public async Task CreateAsync<T>(string query, T entity)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.ExecuteAsync(query, entity);
        }

        public async Task<T> ReadAsync<T>(string query, object obj)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<T>(query, obj);
        }

        public async Task<IEnumerable<T>> ReadAsync<T>(string query)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<T>(query);
        }
    }
}
