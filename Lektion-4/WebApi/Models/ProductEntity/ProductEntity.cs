using WebApi.Models.ProductEntity;

namespace WebApi.Models.ProductEntity
{
    /*  
        public, internal, protected, private
        getter setter - read write
     */

    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        public int CategoryId { get; set; }

    }
}
