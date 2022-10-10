using _02_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _02_WebApi.Controllers
{

    // https://localhost:7206/api/products
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private List<Product> _products;

        public ProductsController()
        {
            _products = new List<Product>()
            {
                new Product { Name = "Product 1", Price = 1000 },
                new Product { Name = "Product 2", Price = 2000 },
                new Product { Name = "Product 3", Price = 3000 },
            };
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new OkObjectResult(_products);
        }


        [HttpPost]
        public IActionResult Add(ProductRequest productRequest)
        {
            _products.Add(new Product
            {
                Name = productRequest.Name,
                Price = productRequest.Price
            });

            return new OkObjectResult(_products);
        }

    }
}
