using Backend.Contexts;
using Backend.Models;
using Backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly SqlDataContext _context;

        public IssuesController(SqlDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(IssueRequest req)
        {
            try
            {
                var datetime = DateTime.Now;
                var issueEntity = new IssueEntity
                {
                    Subject = req.Subject,
                    Description = req.Description,
                    CustomerId = req.CustomerId,
                    Created = datetime,
                    Modified = datetime,
                    StatusId = 1
                };

                _context.Add(issueEntity);
                await _context.SaveChangesAsync();

                return new OkObjectResult(issueEntity);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var issues = new List<IssueModel>();
                foreach (var issueEntity in await _context.Issues.Include(x => x.Status).Include(x => x.Customer).ToListAsync())
                    issues.Add(new IssueModel 
                    { 
                        Id = issueEntity.Id,
                        Subject = issueEntity.Subject,
                        Description = issueEntity.Description,
                        Created = issueEntity.Created,
                        Modified = issueEntity.Modified,
                        Status = new StatusModel
                        {
                            Id = issueEntity.Status.Id,
                            Status = issueEntity.Status.Status
                        },
                        Customer = new CustomerModel
                        {
                            Id = issueEntity.Customer.Id,
                            FirstName = issueEntity.Customer.FirstName,
                            LastName = issueEntity.Customer.LastName,
                            Email = issueEntity.Customer.Email,
                            PhoneNumber = issueEntity.Customer.PhoneNumber
                        }
                    });

                return new OkObjectResult(issues);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var issueEntity = await _context.Issues.Include(x => x.Status).Include(x => x.Customer).Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
                if (issueEntity != null)
                {
                    var comments = new List<CommentModel>();
                    foreach (var comment in issueEntity.Comments)
                        comments.Add(new CommentModel
                        {
                            Id = comment.Id,
                            Comment = comment.Comment,
                            Created = comment.Created,
                            CustomerId = comment.CustomerId
                        });

                    return new OkObjectResult(new IssueModel
                    {
                        Id = issueEntity.Id,
                        Subject = issueEntity.Subject,
                        Description = issueEntity.Description,
                        Created = issueEntity.Created,
                        Modified = issueEntity.Modified,
                        Status = new StatusModel
                        {
                            Id = issueEntity.Status.Id,
                            Status = issueEntity.Status.Status
                        },
                        Customer = new CustomerModel
                        {
                            Id = issueEntity.Customer.Id,
                            FirstName = issueEntity.Customer.FirstName,
                            LastName = issueEntity.Customer.LastName,
                            Email = issueEntity.Customer.Email,
                            PhoneNumber = issueEntity.Customer.PhoneNumber
                        },
                        Comments = comments
                    });
                }

                    
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
    }
}

