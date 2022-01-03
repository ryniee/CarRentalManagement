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
    public class MakesController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
            
        //Refactored
        //public MakesController(ApplicationDbContext context)
        public MakesController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Makes
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Makes>>> GetMakes()
        public async Task<IActionResult> GetMakes()
        {
            //Refactored
            //return await _context.Makes.ToListAsync();
            var makes = await _unitOfWork.Makes.GetAll();
            return Ok(makes);
        }

        // GET: api/Makes/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Makes>> GetMakes(int id)
        public async Task<IActionResult> GetMake(int Id)
        {
            //Refactored
            //var makes = await _context.Makes.FindAsync(id);
            var makes = await _unitOfWork.Makes.Get(q => q.Id == Id);

            if (makes == null)
            {
                return NotFound();
            }
            //Refactored
            return Ok(makes);
        }

        // PUT: api/Makes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMakes(int id, Makes makes)
        {
            if (id != makes.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(makes).State = EntityState.Modified;
            await _unitOfWork.Save(HttpContext);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!MakesExists(id))
                if (!await MakesExists(id))
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

        // POST: api/Makes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Makes>> PostMakes(Makes makes)
        {
            //Refactored
            //_context.Makes.Add(makes);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Makes.Insert(makes);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetMakes", new { id = makes.Id }, makes);
        }

        // DELETE: api/Makes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMakes(int id)
        {
            //Refactored
            //var makes = await _context.Makes.FindAsync(id);
            var makes = await _unitOfWork.Makes.Get(q => q.Id == id);
            if (makes == null)
            {
                return NotFound();
            }

            //_context.Makes.Remove(makes);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Makes.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool MakesExists(int id)
        private async Task<bool> MakesExists(int id)
        {
            //Refactored
            //return _context.Makes.Any(e => e.Id == id);
            var makes = await _unitOfWork.Makes.Get(q => q.Id == id);
            return makes != null;
        }
    }
}
