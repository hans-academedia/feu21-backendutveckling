namespace WebApi.Models.Entities
{
    public class CustomerTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<CustomerEntity>? Customers { get; set; }
    }
}
