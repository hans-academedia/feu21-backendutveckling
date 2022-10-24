using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _03_DatabaseFirst.WebApi.Models
{
    public partial class Product
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Modified { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
