﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApi.Sql.Models;

namespace WebApi.Sql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly DataContext _context;

        public StatusesController(DataContext context)
        {
            _context = context;
        }




        [HttpPost]
        public async Task<IActionResult> Create(StatusRequest req)
        {
            try
            {
                var status = new Status { Name = req.StatusName };
                _context.Add(status);
                await _context.SaveChangesAsync();

                return new OkResult();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var statues = new List<StatusResponse>();
                foreach (var status in await _context.Statuses.ToListAsync())
                    statues.Add(new StatusResponse { Id = status.Id, Name = status.Name });

                return new OkObjectResult(statues);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }


    }
}
