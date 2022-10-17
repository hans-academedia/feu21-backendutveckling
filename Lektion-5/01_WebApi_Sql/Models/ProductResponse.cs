namespace _01_WebApi_Sql.Models
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VendorArticleNumber { get; set; }
        public decimal Price { get; set; }
        public string SubCategory { get; set; }
        public string Category { get; set; }
    }
}
