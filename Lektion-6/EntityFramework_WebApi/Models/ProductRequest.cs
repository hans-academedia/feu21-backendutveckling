﻿namespace EntityFramework_WebApi.Models
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
