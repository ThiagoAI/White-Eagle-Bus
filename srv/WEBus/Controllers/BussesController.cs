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
    public class BussesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BussesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Buses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bus>>> GetBusses()
        {
            return await _context.Busses.Include(b => b.Seats).ToListAsync();
        }

        // GET: api/Buses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bus>> GetBus(int id)
        {
            var bus = await _context.Busses.Include(b => b.Seats).FirstAsync(i => i.ID == id);

            if (bus == null)
            {
                return NotFound();
            }

            return bus;
        }

        // PUT: api/Buses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBus(int id, Bus bus)
        {
            if (id != bus.ID)
            {
                return BadRequest();
            }

            _context.Entry(bus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(id))
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

        // POST: api/Buses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bus>> PostBus(Bus bus)
        {
            _context.Busses.Add(bus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBus", new { id = bus.ID }, bus);
        }

        // DELETE: api/Buses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBus(int id)
        {
            var bus = await _context.Busses.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }

            _context.Busses.Remove(bus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusExists(int id)
        {
            return _context.Busses.Any(e => e.ID == id);
        }
    }
}
