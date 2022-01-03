using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Server.Data;
using CarRentalManagement.Shared.Domain;
using CarRentalManagement.Server.IRepository;

namespace CarRentalManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public CustomersController(ApplicationDbContext context)
        public CustomersController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Customers
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        public async Task<IActionResult> GetCustomers()
        {
            //Refactored
            //return await _context.Customers.ToListAsync();
            var Customers = await _unitOfWork.Customers.GetAll();
            return Ok(Customers);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Customers>> GetCustomers(int id)
        public async Task<IActionResult> GetMake(int Id)
        {
            //Refactored
            //var Customers = await _context.Customers.FindAsync(id);
            var Customers = await _unitOfWork.Customers.Get(q => q.Id == Id);

            if (Customers == null)
            {
                return NotFound();
            }
            //Refactored
            return Ok(Customers);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers(int id, Customer Customers)
        {
            if (id != Customers.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(Customers).State = EntityState.Modified;
            await _unitOfWork.Save(HttpContext);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!CustomersExists(id))
                if (!await CustomersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomers(Customer Customers)
        {
            //Refactored
            //_context.Customers.Add(Customers);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Customers.Insert(Customers);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCustomers", new { id = Customers.Id }, Customers);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            //Refactored
            //var Customers = await _context.Customers.FindAsync(id);
            var Customers = await _unitOfWork.Customers.Get(q => q.Id == id);
            if (Customers == null)
            {
                return NotFound();
            }

            //_context.Customers.Remove(Customers);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Customers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool CustomersExists(int id)
        private async Task<bool> CustomersExists(int id)
        {
            //Refactored
            //return _context.Customers.Any(e => e.Id == id);
            var Customers = await _unitOfWork.Customers.Get(q => q.Id == id);
            return Customers != null;
        }
    }
}
