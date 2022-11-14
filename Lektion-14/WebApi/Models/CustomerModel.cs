namespace WebApi.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public int CustomerTypeId { get; set; }
        public string? CustomerType { get; set; }
    }
}
