using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlamingoServices.Data;
using FlamingoServices.Data.Models;

namespace FlamingoServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightDetailsController : ControllerBase
    {
        private readonly FlamingoDbContext _context;

        public FlightDetailsController(FlamingoDbContext context)
        {
            _context = context;
        }

        // GET: api/FlightDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDetail>>> GetFlightDetails()
        {
            return await _context.FlightDetails.ToListAsync();
        }

        // GET: api/FlightDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDetail>> GetFlightDetail(string id)
        {
            var flightDetail = await _context.FlightDetails.FindAsync(id);

            if (flightDetail == null)
            {
                return NotFound();
            }

            return flightDetail;
        }

        // PUT: api/FlightDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightDetail(string id, FlightDetail flightDetail)
        {
            if (id != flightDetail.FlightId)
            {
                return BadRequest();
            }

            _context.Entry(flightDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightDetailExists(id))
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

        // POST: api/FlightDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightDetail>> PostFlightDetail(FlightDetail flightDetail)
        {
            _context.FlightDetails.Add(flightDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlightDetailExists(flightDetail.FlightId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFlightDetail", new { id = flightDetail.FlightId }, flightDetail);
        }

        // DELETE: api/FlightDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightDetail(string id)
        {
            var flightDetail = await _context.FlightDetails.FindAsync(id);
            if (flightDetail == null)
            {
                return NotFound();
            }

            _context.FlightDetails.Remove(flightDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightDetailExists(string id)
        {
            return _context.FlightDetails.Any(e => e.FlightId == id);
        }
    }
}
