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
    public class BusTripLocationsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BusTripLocationsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/BusTripLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusTripLocation>>> GetBusTripLocations()
        {
            return await _context.BusTripLocations.ToListAsync();
        }
    }
}
