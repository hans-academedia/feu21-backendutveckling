using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _03_DatabaseFirst.WebApi.Models
{
    public partial class Case
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Subject { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
