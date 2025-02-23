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
    public class SalesLineController : ControllerBase
    {
        private readonly TroskySneakersContext _context;

        public SalesLineController(TroskySneakersContext context)
        {
            _context = context;
        }

        // GET: api/SalesLine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesLine>>> GetSalesLines()
        {
            return await _context.SalesLines.ToListAsync();
        }

        // GET: api/SalesLine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesLine>> GetSalesLine(int id)
        {
            var salesLine = await _context.SalesLines.FindAsync(id);

            if (salesLine == null)
            {
                return NotFound();
            }

            return salesLine;
        }

        // PUT: api/SalesLine/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesLine(int id, SalesLine salesLine)
        {
            if (id != salesLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(salesLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesLineExists(id))
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

        // POST: api/SalesLine
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesLine>> PostSalesLine(SalesLine salesLine)
        {
            _context.SalesLines.Add(salesLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesLine", new { id = salesLine.Id }, salesLine);
        }

        // DELETE: api/SalesLine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesLine(int id)
        {
            var salesLine = await _context.SalesLines.FindAsync(id);
            if (salesLine == null)
            {
                return NotFound();
            }

            _context.SalesLines.Remove(salesLine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesLineExists(int id)
        {
            return _context.SalesLines.Any(e => e.Id == id);
        }
    }
}
