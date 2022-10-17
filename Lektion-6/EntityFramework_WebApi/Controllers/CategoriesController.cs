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
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryRequest request)
        {
            try
            {
                var categoryEntity = new CategoryEntity { CategoryName = request.CategoryName };
                _context.Categories.Add(categoryEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult(categoryEntity);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return new OkObjectResult(await _context.Categories.ToListAsync());
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                return new OkObjectResult(await _context.Categories.FirstOrDefaultAsync(x => x.Id == id));
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

    }
}