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
    public class TaxesController : ControllerBase
    {
        private readonly TroskySneakersContext _context;

        public TaxesController(TroskySneakersContext context)
        {
            _context = context;
        }

        // GET: api/Taxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taxes>>> GetTaxes()
        {
            return await _context.Taxes.ToListAsync();
        }

        // GET: api/Taxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taxes>> GetTaxes(int id)
        {
            var taxes = await _context.Taxes.FindAsync(id);

            if (taxes == null)
            {
                return NotFound();
            }

            return taxes;
        }

        // PUT: api/Taxes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxes(int id, Taxes taxes)
        {
            if (id != taxes.Id)
            {
                return BadRequest();
            }

            _context.Entry(taxes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxesExists(id))
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

        // POST: api/Taxes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Taxes>> PostTaxes(Taxes taxes)
        {
            _context.Taxes.Add(taxes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaxes", new { id = taxes.Id }, taxes);
        }

        // DELETE: api/Taxes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxes(int id)
        {
            var taxes = await _context.Taxes.FindAsync(id);
            if (taxes == null)
            {
                return NotFound();
            }

            _context.Taxes.Remove(taxes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaxesExists(int id)
        {
            return _context.Taxes.Any(e => e.Id == id);
        }
    }
}
