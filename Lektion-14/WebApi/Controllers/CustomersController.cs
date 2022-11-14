using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApi.Contexts;
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomersController(DataContext context)
        {
            _context = context;
        }




        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateModel model) 
        {
            if (ModelState.IsValid)
            {
                var customerTypeEntity = await _context.CustomerTypes.FindAsync(model.CustomerTypeId);
                if (customerTypeEntity != null)
                {
                    var customerEntity = new CustomerEntity
                    {
                        CustomerTypeId = customerTypeEntity.Id,
                        Name = model.Name,
                        Email = model.Email
                    };

                    _context.Add(customerEntity);
                    await _context.SaveChangesAsync();
                    return new OkObjectResult(new CustomerModel
                    {
                        Id = customerEntity.Id,
                        Name = customerEntity.Name,
                        Email = customerEntity.Email,
                        CustomerTypeId = customerEntity.CustomerTypeId,
                        CustomerType = customerTypeEntity.Name
                    });
                }
                else
                {
                    return new BadRequestObjectResult(new { error = 400, message = "incorrect customer type" });
                }
            }

            return new BadRequestResult();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerUpdateModel model)
        {
            if (id != model.Id)
                return new BadRequestResult();

            if (ModelState.IsValid)
            {
                var customerTypeEntity = await _context.CustomerTypes.FindAsync(model.CustomerTypeId);
                if (customerTypeEntity != null)
                {
                    var customerEntity = await _context.Customers.FindAsync(model.Id);
                    if (customerEntity != null)
                    {
                        customerEntity.Name = model.Name;
                        customerEntity.Email = model.Email;
                        customerEntity.CustomerTypeId = customerTypeEntity.Id;

                        _context.Entry(customerEntity).State = EntityState.Modified;
                        await _context.SaveChangesAsync();

                        return new OkObjectResult(new CustomerModel
                        {
                            Id = customerEntity.Id,
                            Name = customerEntity.Name,
                            Email = customerEntity.Email,
                            CustomerTypeId = customerEntity.CustomerTypeId,
                            CustomerType = customerTypeEntity.Name
                        });
                    }
                }
            }

            return new BadRequestResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity != null)
                return new OkObjectResult(new CustomerModel
                {
                    Id = customerEntity.Id,
                    Name = customerEntity.Name,
                    Email = customerEntity.Email,
                    CustomerTypeId = customerEntity.CustomerTypeId,
                });

            return new NotFoundResult();
        }

    }
}
