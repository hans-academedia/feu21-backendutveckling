namespace _01_WebApi.Models
{
    public class Product
    {
        public Product()
        {

        }

        public Product(string name, decimal price = 0)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }

        public Product(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Guid Id { get; set; } = Guid.NewGuid();               // uuid = GUID
        public string Name { get; set; } = "";
        public decimal Price { get; set; } = 0.0m;

    }
}
