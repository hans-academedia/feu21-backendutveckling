using EntityFramework_WebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
