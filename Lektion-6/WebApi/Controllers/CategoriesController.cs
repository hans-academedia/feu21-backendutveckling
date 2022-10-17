using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly SqlHandler<Category> categoryHandler = new SqlHandler<Category>();


        [HttpPost]
        public async Task<IActionResult> Create(CategoryRequest category)
        {
            try
            {
                await categoryHandler.CreateAsync("INSERT INTO Categories VALUES (@CategoryName)", new Category { CategoryName = category.CategoryName });
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
                var result = await categoryHandler.GetAsync("SELECT * FROM Categories");
                return new OkObjectResult(result);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
    }
}
