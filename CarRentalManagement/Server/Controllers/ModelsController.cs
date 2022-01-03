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
    public class ModelController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public ModelController(ApplicationDbContext context)
        public ModelController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Model
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Model>>> GetModel()
        public async Task<IActionResult> GetModel()
        {
            //Refactored
            //return await _context.Model.ToListAsync();
            var Model = await _unitOfWork.Models.GetAll();
            return Ok(Model);
        }

        // GET: api/Model/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Model>> GetModel(int id)
        public async Task<IActionResult> GetMake(int Id)
        {
            //Refactored
            //var Model = await _context.Model.FindAsync(id);
            var Model = await _unitOfWork.Models.Get(q => q.Id == Id);

            if (Model == null)
            {
                return NotFound();
            }
            //Refactored
            return Ok(Model);
        }

        // PUT: api/Model/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel(int id, Model Model)
        {
            if (id != Model.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(Model).State = EntityState.Modified;
            await _unitOfWork.Save(HttpContext);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!ModelExists(id))
                if (!await ModelExists(id))
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

        // POST: api/Model
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Model>> PostModel(Model Model)
        {
            //Refactored
            //_context.Model.Add(Model);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Models.Insert(Model);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetModel", new { id = Model.Id }, Model);
        }

        // DELETE: api/Model/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            //Refactored
            //var Model = await _context.Model.FindAsync(id);
            var Model = await _unitOfWork.Models.Get(q => q.Id == id);
            if (Model == null)
            {
                return NotFound();
            }

            //_context.Model.Remove(Model);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Models.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool ModelExists(int id)
        private async Task<bool> ModelExists(int id)
        {
            //Refactored
            //return _context.Model.Any(e => e.Id == id);
            var Model = await _unitOfWork.Models.Get(q => q.Id == id);
            return Model != null;
        }
    }
}
