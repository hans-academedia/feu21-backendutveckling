using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_WebApi.Models.Entities
{
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string CategoryName { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
