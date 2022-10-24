using Microsoft.EntityFrameworkCore;

namespace _00_Repetition.WebApiEFC.Models.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
