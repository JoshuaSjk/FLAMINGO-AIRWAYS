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
    public class TicketAvailabilitiesController : ControllerBase
    {
        private readonly FlamingoDbContext _context;

        public TicketAvailabilitiesController(FlamingoDbContext context)
        {
            _context = context;
        }

        // GET: api/TicketAvailabilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketAvailability>>> GetTicketAvailabilities()
        {
            return await _context.TicketAvailabilities.ToListAsync();
        }

        // GET: api/TicketAvailabilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketAvailability>> GetTicketAvailability(int id)
        {
            var ticketAvailability = await _context.TicketAvailabilities.FindAsync(id);

            if (ticketAvailability == null)
            {
                return NotFound();
            }

            return ticketAvailability;
        }

        // PUT: api/TicketAvailabilities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketAvailability(int id, TicketAvailability ticketAvailability)
        {
            if (id != ticketAvailability.Slno)
            {
                return BadRequest();
            }

            _context.Entry(ticketAvailability).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketAvailabilityExists(id))
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

        // POST: api/TicketAvailabilities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TicketAvailability>> PostTicketAvailability(TicketAvailability ticketAvailability)
        {
            _context.TicketAvailabilities.Add(ticketAvailability);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicketAvailability", new { id = ticketAvailability.Slno }, ticketAvailability);
        }

        // DELETE: api/TicketAvailabilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketAvailability(int id)
        {
            var ticketAvailability = await _context.TicketAvailabilities.FindAsync(id);
            if (ticketAvailability == null)
            {
                return NotFound();
            }

            _context.TicketAvailabilities.Remove(ticketAvailability);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketAvailabilityExists(int id)
        {
            return _context.TicketAvailabilities.Any(e => e.Slno == id);
        }
    }
}
