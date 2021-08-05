using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBus.Models;
using WEBus.Data;

namespace WEBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusSeatsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BusSeatsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/BusSeats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusSeat>>> GetBusSeats()
        {
            return await _context.BusSeats.ToListAsync();
        }

        // GET: api/BusSeats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusSeat>> GetBusSeat(int id)
        {
            var busSeat = await _context.BusSeats.FindAsync(id);

            if (busSeat == null)
            {
                return NotFound();
            }

            return busSeat;
        }

        // PUT: api/BusSeats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusSeat(int id, BusSeat busSeat)
        {
            if (id != busSeat.ID)
            {
                return BadRequest();
            }

            _context.Entry(busSeat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusSeatExists(id))
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

        // POST: api/BusSeats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusSeat>> PostBusSeat(BusSeat busSeat)
        {
            _context.BusSeats.Add(busSeat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusSeat", new { id = busSeat.ID }, busSeat);
        }

        // DELETE: api/BusSeats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusSeat(int id)
        {
            var busSeat = await _context.BusSeats.FindAsync(id);
            if (busSeat == null)
            {
                return NotFound();
            }

            _context.BusSeats.Remove(busSeat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusSeatExists(int id)
        {
            return _context.BusSeats.Any(e => e.ID == id);
        }
    }
}
