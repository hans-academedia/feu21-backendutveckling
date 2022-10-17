using _01_WebApi_Sql.Models;
using _01_WebApi_Sql.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01_WebApi_Sql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly SqlManager<SubCategoryEntity> subCategoryManager = new SqlManager<SubCategoryEntity>();
        private readonly SqlManager<CategoryEntity> categoryManager = new SqlManager<CategoryEntity>();

        [HttpPost]
        public async Task<IActionResult> Create(SubCategoryRequest subCategory)
        {
            var categoryEntity = await categoryManager.ReadAsync<CategoryEntity>("SELECT * FROM Categories WHERE Name = @Name", new { Name = subCategory.CategoryName });
            if (categoryEntity != null)
            {
                await subCategoryManager.CreateAsync("INSERT INTO SubCategories VALUES (@Name, @CategoryId)", new SubCategoryEntity { Name = subCategory.Name, CategoryId = categoryEntity.Id });
                return new OkResult();
            }

            return new BadRequestObjectResult("Category Name was not found");

        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Read(string name)
        {
            var result = await subCategoryManager.ReadAsync<SubCategoryResponse>("SELECT SC.Id, SC.Name, C.Name AS CategoryName FROM SubCategories SC JOIN Categories C ON C.Id = SC.CategoryId WHERE SC.Name = @Name", new { Name = name });
            return new OkObjectResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var result = await subCategoryManager.ReadAsync<SubCategoryResponse>("SELECT SC.Id, SC.Name, C.Name AS CategoryName FROM SubCategories SC JOIN Categories C ON C.Id = SC.CategoryId");
            return new OkObjectResult(result);
        }
    }
}
