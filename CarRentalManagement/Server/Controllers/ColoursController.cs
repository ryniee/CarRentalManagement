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
    public class ColoursController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public ColoursController(ApplicationDbContext context)
        public ColoursController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Colours
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Colours>>> GetColours()
        public async Task<IActionResult> GetColours()
        {
            //Refactored
            //return await _context.Colours.ToListAsync();
            var Colours = await _unitOfWork.Colours.GetAll();
            return Ok(Colours);
        }

        // GET: api/Colours/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Colours>> GetColours(int id)
        public async Task<IActionResult> GetMake(int Id)
        {
            //Refactored
            //var Colours = await _context.Colours.FindAsync(id);
            var Colours = await _unitOfWork.Colours.Get(q => q.Id == Id);

            if (Colours == null)
            {
                return NotFound();
            }
            //Refactored
            return Ok(Colours);
        }

        // PUT: api/Colours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColours(int id, Colour Colours)
        {
            if (id != Colours.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(Colours).State = EntityState.Modified;
            await _unitOfWork.Save(HttpContext);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!ColoursExists(id))
                if (!await ColoursExists(id))
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

        // POST: api/Colours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Colour>> PostColours(Colour Colours)
        {
            //Refactored
            //_context.Colours.Add(Colours);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Colours.Insert(Colours);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetColours", new { id = Colours.Id }, Colours);
        }

        // DELETE: api/Colours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColours(int id)
        {
            //Refactored
            //var Colours = await _context.Colours.FindAsync(id);
            var Colours = await _unitOfWork.Colours.Get(q => q.Id == id);
            if (Colours == null)
            {
                return NotFound();
            }

            //_context.Colours.Remove(Colours);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Colours.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool ColoursExists(int id)
        private async Task<bool> ColoursExists(int id)
        {
            //Refactored
            //return _context.Colours.Any(e => e.Id == id);
            var Colours = await _unitOfWork.Colours.Get(q => q.Id == id);
            return Colours != null;
        }
    }
}
