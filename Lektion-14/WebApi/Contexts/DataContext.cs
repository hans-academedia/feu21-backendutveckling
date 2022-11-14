using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;

namespace WebApi.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CustomerTypeEntity> CustomerTypes { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
