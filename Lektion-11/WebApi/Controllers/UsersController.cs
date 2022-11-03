using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Create(UserRequest req)
        {
            var userEntity = new UserEntity
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                Email = req.Email,
                Password = req.Password
            };

            _context.Add(userEntity);
            await _context.SaveChangesAsync();

            return new OkResult();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = new List<User>();
            foreach (var u in await _context.Users.ToListAsync())
                users.Add(new User
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email
                });

            return new OkObjectResult(users);
        }

    }
}
