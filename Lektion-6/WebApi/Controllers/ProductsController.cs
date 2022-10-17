using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SqlHandler<Product> productHandler = new SqlHandler<Product>();


        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest product)
        {
            try
            {
                await productHandler.CreateAsync("INSERT INTO Products VALUES (@Name, @Price, @CategoryId)", new Product { Name = product.Name, Price = product.Price, CategoryId = product.CategoryId });
                return new OkResult();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await productHandler.GetAsync("SELECT P.Id, Name, Price, C.Id as CategoryId, CategoryName FROM Products P JOIN Categories C ON P.CategoryId = C.Id");
                return new OkObjectResult(products);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

    }
}
