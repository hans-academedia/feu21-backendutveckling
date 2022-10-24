using _00_Repetition.WebApiEFC.Models;
using _00_Repetition.WebApiEFC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _00_Repetition.WebApiEFC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager userManager;

        public UsersController(UserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequest req)
        {
            try
            {
                await userManager.CreateAsync(req);
                return new OkResult();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new BadRequestResult();
            }   
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try { return new OkObjectResult(await userManager.GetUsersAsync()); }
            catch { return new BadRequestResult(); }
        }

    }
}
