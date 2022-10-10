using _01_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public IActionResult Create()
        {







            var product1 = new Product();
            var product2 = new Product("Product 2", 2000);
            var product3 = new Product(Guid.NewGuid(), "Product 3", 3000);







            var user = new User();
            user.GeneratePassword("BytMig123!");

        }

    }
}
