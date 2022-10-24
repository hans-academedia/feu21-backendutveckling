using Microsoft.EntityFrameworkCore;

namespace _02_CosmosDB.WebApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Case> Cases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToContainer("Products").HasPartitionKey(x => x.Id);
            modelBuilder.Entity<Case>().ToContainer("Cases").HasPartitionKey(x => x.Id);
        }
    }
}
