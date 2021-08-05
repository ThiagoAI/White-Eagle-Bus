using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBus.Data;
using WhiteEagleBus.Models;

namespace WEBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusTripSeatBookingsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BusTripSeatBookingsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/BusTripSeatBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusTripSeatBooking>>> GetBusSeatBookings()
        {
            return await _context.BusTripSeatBooking.ToListAsync();
        }

        // GET: api/BusTripSeatBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusTripSeatBooking>> GetBusTripSeatBooking(int id)
        {
            var busTripSeatBooking = await _context.BusTripSeatBooking.FindAsync(id);

            if (busTripSeatBooking == null)
            {
                return NotFound();
            }

            return busTripSeatBooking;
        }

        // POST: api/BusTripSeatBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusTripSeatBooking>> PostBusTripSeatBooking(BusTripSeatBooking busTripSeatBooking)
        {
            try
            {
                //Get trip and seat
                BusTrip busTrip;
                try
                {
                    busTrip = _context.BusTrips.Include(b => b.Bus).First(t => t.ID == busTripSeatBooking.BusTripId);
                }
                catch (Exception)
                {
                    return BadRequest("The selected trip could not be found.");
                }
                BusSeat busSeat;
                try
                {
                    busSeat = _context.BusSeats.Include(b => b.Bus).First(s => s.ID == busTripSeatBooking.BusSeatId);
                }
                catch (Exception)
                {
                    return BadRequest("The selected seat could not be found.");
                }
                // Checks for seat-bus
                if (!busTrip.Bus.Equals(busSeat.Bus))
                    return BadRequest("The selected seat does not belong to the trip's bus.");
                // Checks for same seat
                if (_context.BusTripSeatBooking.Any(r =>
                    (r.BusSeatId == busTripSeatBooking.BusSeatId) && (r.BusTripId == busTripSeatBooking.BusTripId)))
                {
                    return BadRequest("The selected seat is not available.");
                }
                //Create booking
                _context.BusTripSeatBooking.Add(busTripSeatBooking);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                //This might happen if the DB experiences an issue or if two users try to book the same seat at the same time
                return BadRequest("An error has ocorurred while booking your trip, the selected seat may not be available. Update the page and try again.");
            }
            catch (Exception)
            {
                throw;
            }

            return CreatedAtAction("GetBusTripSeatBooking", new { id = busTripSeatBooking.ID }, busTripSeatBooking);
        }

        // DELETE: api/BusTripSeatBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusTripSeatBooking(int id)
        {
            var busTripSeatBooking = await _context.BusTripSeatBooking.FindAsync(id);
            if (busTripSeatBooking == null)
            {
                return NotFound();
            }

            _context.BusTripSeatBooking.Remove(busTripSeatBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool BusTripSeatBookingExists(int id)
        //{
        //    return _context.BusTripSeatBooking.Any(e => e.ID == id);
        //}
    }
}
