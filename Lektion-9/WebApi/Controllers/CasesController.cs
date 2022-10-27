using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly DataContext _context;

        public CasesController(DataContext context)
        {
            _context = context;
        }



        [HttpPost]
        public async Task<IActionResult> Create(CaseIssue caseIssue)
        {
            try
            {
                _context.Add(caseIssue);
                await _context.SaveChangesAsync();
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
                return new OkObjectResult(await _context.Cases.ToListAsync());
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return new OkObjectResult(await _context.Cases.FirstOrDefaultAsync(x => x.Id == id));
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CaseIssue caseIssue)
        {
            try
            {
                var _caseIssue = await _context.Cases.FirstOrDefaultAsync(x => x.Id == id);
                if (_caseIssue != null)
                {
                    _caseIssue.Status = caseIssue.Status;
                    _caseIssue.Description = caseIssue.Description;
                    _caseIssue.Modified = DateTime.Now;
                    _caseIssue.Subject = caseIssue.Subject;

                    _context.Update(_caseIssue);
                    await _context.SaveChangesAsync();
                    return new OkResult();
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var _caseIssue = await _context.Cases.FirstOrDefaultAsync(x => x.Id == id);
                if (_caseIssue != null)
                {
                    _context.Remove(_caseIssue);
                    await _context.SaveChangesAsync();
                    return new OkResult();
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
    }
}
