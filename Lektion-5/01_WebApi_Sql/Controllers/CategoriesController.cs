using _01_WebApi_Sql.Models;
using _01_WebApi_Sql.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01_WebApi_Sql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly SqlManager<CategoryEntity> categoryManager = new SqlManager<CategoryEntity>();


        [HttpPost]
        public async Task<IActionResult> Create(CategoryRequest category)
        {
            await categoryManager.CreateAsync("INSERT INTO Categories VALUES (@Name)", new CategoryEntity { Name = category.Name });
            return new OkResult();
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Read(string name)
        {
            var result = await categoryManager.ReadAsync<CategoryEntity>("SELECT * FROM Categories WHERE Name = @Name", new { Name = name });
            return new OkObjectResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var result = await categoryManager.ReadAsync<CategoryEntity>("SELECT * FROM Categories");
            return new OkObjectResult(result);
        }

    }
}
