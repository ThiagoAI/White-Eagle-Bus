using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBus.Data;
using WhiteEagleBus.Models;

namespace WEBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusTripsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BusTripsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/BusTrips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusTrip>>> GetBusTrips()
        {
            return await _context.BusTrips
                .Include(t => t.Bus)
                    .ThenInclude(b => b.Seats)
                .Include(t => t.Origin)
                .Include(t => t.Destination)
                .ToListAsync();
        }

        // GET: api/BusTrips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusTrip>> GetBusTrip(int id)
        {
            var busTrip = await _context.BusTrips
                .Include(t => t.Bus)
                    .ThenInclude(b => b.Seats)
                .Include(t => t.Origin)
                .Include(t => t.Destination)
                .FirstAsync(t => t.ID == id);

            if (busTrip == null)
            {
                return NotFound();
            }

            return busTrip;
        }

        // PUT: api/BusTrips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusTrip(int id, BusTrip busTrip)
        {
            if (id != busTrip.ID)
            {
                return BadRequest();
            }

            _context.Entry(busTrip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusTripExists(id))
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

        // POST: api/BusTrips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusTrip>> PostBusTrip(BusTrip busTrip)
        {
            _context.BusTrips.Add(busTrip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusTrip", new { id = busTrip.ID }, busTrip);
        }

        // DELETE: api/BusTrips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusTrip(int id)
        {
            var busTrip = await _context.BusTrips.FindAsync(id);
            if (busTrip == null)
            {
                return NotFound();
            }

            _context.BusTrips.Remove(busTrip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusTripExists(int id)
        {
            return _context.BusTrips.Any(e => e.ID == id);
        }
    }
}
