namespace _01_WebApi_Sql.Models
{
    public class SubCategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
