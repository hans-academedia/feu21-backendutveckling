using _01_WebApi_Sql.Models;
using _01_WebApi_Sql.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01_WebApi_Sql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SqlManager<ProductEntity> productManager = new SqlManager<ProductEntity>();

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest product)
        {
            using var client = new HttpClient();
            var subcategory = await client.GetFromJsonAsync<SubCategoryResponse>($"https://localhost:7235/api/subcategories/{product.SubCategoryName}");
            if (subcategory != null)
            {
                await productManager.CreateAsync<ProductEntity>("INSERT INTO Products VALUES (@Name, @Price, @SubCategoryId, @VendorArticleNumber)", new ProductEntity
                {
                    Name = product.Name,
                    Price = product.Price,
                    SubCategoryId = subcategory.Id,
                    VendorArticleNumber = product.VendorArticleNumber
                });

                return new OkResult();
            }

            return new BadRequestResult();
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> Read(string name)
        {
            var result = await productManager.ReadAsync<ProductResponse>("SELECT P.Id, P.Name, P.Price, P.VendorArticleNumber, SC.Name AS SubCategory, C.Name AS Category FROM Products P JOIN SubCategories SC ON SC.Id = P.CategoryId JOIN Categories C ON C.Id = SC.CategoryId WHERE P.Name = @Name", new { Name = name });
            return new OkObjectResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var result = await productManager.ReadAsync<ProductResponse>("SELECT P.Id, P.Name, P.Price, P.VendorArticleNumber, SC.Name AS SubCategory, C.Name AS Category FROM Products P JOIN SubCategories SC ON SC.Id = P.CategoryId JOIN Categories C ON C.Id = SC.CategoryId");
            return new OkObjectResult(result);
        }
    }
}
