using Microsoft.EntityFrameworkCore;

namespace _02_CosmosDB.WebApi.Models
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Case> Cases { get; set; }
    }
}
