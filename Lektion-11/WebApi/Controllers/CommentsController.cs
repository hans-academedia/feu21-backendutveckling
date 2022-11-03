using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly DataContext _context;

        public CommentsController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CommentRequest req)
        {
            var commentEntity = new CommentEntity
            {
                UserId = req.UserId,
                IssueId = req.IssueId,
                Message = req.Message
            };

            _context.Add(commentEntity);
            await _context.SaveChangesAsync();

            return new OkObjectResult(commentEntity);
        }
    }
}
