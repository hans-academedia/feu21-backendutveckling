using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_WebApi.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual CategoryEntity Category { get; set; }
    }
}
