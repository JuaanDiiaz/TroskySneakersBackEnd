using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TroskiSneakersBackEnd.Models;

namespace TroskiSneakersBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesHeaderController : ControllerBase
    {
        private readonly TroskySneakersContext _context;

        public SalesHeaderController(TroskySneakersContext context)
        {
            _context = context;
        }

        // GET: api/SalesHeader
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesHeader>>> GetSalesHeaders()
        {
            return await _context.SalesHeaders.ToListAsync();
        }

        // GET: api/SalesHeader/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesHeader>> GetSalesHeader(int id)
        {
            var salesHeader = await _context.SalesHeaders.FindAsync(id);

            if (salesHeader == null)
            {
                return NotFound();
            }

            return salesHeader;
        }

        // PUT: api/SalesHeader/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesHeader(int id, SalesHeader salesHeader)
        {
            if (id != salesHeader.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesHeaderExists(id))
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

        // POST: api/SalesHeader
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesHeader>> PostSalesHeader(SalesHeader salesHeader)
        {
            _context.SalesHeaders.Add(salesHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesHeader", new { id = salesHeader.Id }, salesHeader);
        }

        // DELETE: api/SalesHeader/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesHeader(int id)
        {
            var salesHeader = await _context.SalesHeaders.FindAsync(id);
            if (salesHeader == null)
            {
                return NotFound();
            }

            _context.SalesHeaders.Remove(salesHeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesHeaderExists(int id)
        {
            return _context.SalesHeaders.Any(e => e.Id == id);
        }
    }
}
