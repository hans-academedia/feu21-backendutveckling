namespace WebApi.Models
{
    public class CustomerUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int CustomerTypeId { get; set; }
    }
}
