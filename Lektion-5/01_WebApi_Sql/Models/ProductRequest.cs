namespace _01_WebApi_Sql.Models
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SubCategoryName { get; set; }
        public string? VendorArticleNumber { get; set; } = "";
    }
}
