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
    public class VehicleController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public VehicleController(ApplicationDbContext context)
        public VehicleController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Vehicle
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicle()
        public async Task<IActionResult> GetVehicle()
        {
            //Refactored
            //return await _context.Vehicle.ToListAsync();
            var Vehicle = await _unitOfWork.Vehicles.GetAll();
            return Ok(Vehicle);
        }

        // GET: api/Vehicle/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        public async Task<IActionResult> GetMake(int Id)
        {
            //Refactored
            //var Vehicle = await _context.Vehicle.FindAsync(id);
            var Vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == Id);

            if (Vehicle == null)
            {
                return NotFound();
            }
            //Refactored
            return Ok(Vehicle);
        }

        // PUT: api/Vehicle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle Vehicle)
        {
            if (id != Vehicle.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(Vehicle).State = EntityState.Modified;
            await _unitOfWork.Save(HttpContext);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!VehicleExists(id))
                if (!await VehicleExists(id))
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

        // POST: api/Vehicle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle Vehicle)
        {
            //Refactored
            //_context.Vehicle.Add(Vehicle);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Vehicles.Insert(Vehicle);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetVehicle", new { id = Vehicle.Id }, Vehicle);
        }

        // DELETE: api/Vehicle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            //Refactored
            //var Vehicle = await _context.Vehicle.FindAsync(id);
            var Vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id);
            if (Vehicle == null)
            {
                return NotFound();
            }

            //_context.Vehicle.Remove(Vehicle);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Vehicles.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool VehicleExists(int id)
        private async Task<bool> VehicleExists(int id)
        {
            //Refactored
            //return _context.Vehicle.Any(e => e.Id == id);
            var Vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id);
            return Vehicle != null;
        }
    }
}
