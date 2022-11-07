﻿using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        public int CustomerId { get; set; }
    }
}
