namespace _01_WebApi_Sql.Models
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VendorArticleNumber { get; set; }
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }

    }
}