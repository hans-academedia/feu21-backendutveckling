using EntityFramework_WebApi.Data;
using EntityFramework_WebApi.Models;
using EntityFramework_WebApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EntityFramework_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest request)
        {
            try
            {
                var categoryEntity = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.CategoryId);
                if (categoryEntity == null)
                    return new BadRequestObjectResult("category not found");

                _context.Add(new ProductEntity
                {
                    Name = request.Name,
                    Price = request.Price,
                    CategoryId = categoryEntity.Id
                });
                await _context.SaveChangesAsync();

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
                var products = new List<ProductResponse>();
                foreach (var item in await _context.Products.ToListAsync())
                    products.Add(new ProductResponse
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        CategoryId = item.CategoryId
                    });

                return new OkObjectResult(products);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
    }
}
