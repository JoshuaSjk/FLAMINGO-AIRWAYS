using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlamingoServices.Data;
using FlamingoServices.Models;
using FlamingoServices.Data.Models;

namespace FlamingoServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleFlightsController : ControllerBase
    {
        private readonly FlamingoDbContext _context;

        public ScheduleFlightsController(FlamingoDbContext context)
        {
            _context = context;
        }

        // GET: api/ScheduleFlights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleFlight>>> GetScheduleFlights()
        {
            return await _context.ScheduleFlights.ToListAsync();
        }

        // GET: api/ScheduleFlights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleFlight>> GetScheduleFlight(int id)
        {
            var scheduleFlight = await _context.ScheduleFlights.FindAsync(id);

            if (scheduleFlight == null)
            {
                return NotFound();
            }

            return scheduleFlight;
        }

        // PUT: api/ScheduleFlights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduleFlight(int id, ScheduleFlight scheduleFlight)
        {
            if (id != scheduleFlight.FlightSchId)
            {
                return BadRequest();
            }

            _context.Entry(scheduleFlight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleFlightExists(id))
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

        // POST: api/ScheduleFlights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ScheduleFlight>> PostScheduleFlight(ScheduleFlight scheduleFlight)
        {
            _context.ScheduleFlights.Add(scheduleFlight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScheduleFlight", new { id = scheduleFlight.FlightSchId }, scheduleFlight);
        }

        // DELETE: api/ScheduleFlights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleFlight(int id)
        {
            var scheduleFlight = await _context.ScheduleFlights.FindAsync(id);
            if (scheduleFlight == null)
            {
                return NotFound();
            }

            _context.ScheduleFlights.Remove(scheduleFlight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleFlightExists(int id)
        {
            return _context.ScheduleFlights.Any(e => e.FlightSchId == id);
        }
    }
}
