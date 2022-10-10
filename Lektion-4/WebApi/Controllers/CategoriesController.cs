using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApi.Models;
using Dapper;
using WebApi.Models.ProductEntity;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        /* CRUD - Create Read Update Delete (POST, GET, PUT, DELETE) */
        /* IActionResult - 200, 201, 204, 400, 401, 403, 404, 409, 500 */

        private readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HansMattin-Lassei\\Documents\\Utbildning\\FEU21\\Lektion-4\\WebApi\\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

        [HttpPost]
        public IActionResult Create(CategoryRequest categoryName)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Execute("INSERT INTO Categories (Name) VALUES(@Name)", categoryName);
            return new OkResult();
        }

        [HttpGet]
        public IActionResult Read()
        {
            using var conn = new SqlConnection(connectionString);
            var result = conn.Query<CategoryEntity>("SELECT * FROM Categories");
            return new OkObjectResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            using var conn = new SqlConnection(connectionString);
            var result = conn.QueryFirstOrDefault<CategoryEntity>("SELECT * FROM Categories WHERE Id = @Id", new { Id = id });
            return new OkObjectResult(result);
        }

    }
}
