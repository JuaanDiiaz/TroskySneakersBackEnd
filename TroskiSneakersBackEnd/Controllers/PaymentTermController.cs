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
    public class PaymentTermController : ControllerBase
    {
        private readonly TroskySneakersContext _context;

        public PaymentTermController(TroskySneakersContext context)
        {
            _context = context;
        }

        // GET: api/PaymentTerm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentTerm>>> GetPaymentTerms()
        {
            return await _context.PaymentTerms.ToListAsync();
        }

        // GET: api/PaymentTerm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentTerm>> GetPaymentTerm(int id)
        {
            var paymentTerm = await _context.PaymentTerms.FindAsync(id);

            if (paymentTerm == null)
            {
                return NotFound();
            }

            return paymentTerm;
        }

        // PUT: api/PaymentTerm/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentTerm(int id, PaymentTerm paymentTerm)
        {
            if (id != paymentTerm.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentTerm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTermExists(id))
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

        // POST: api/PaymentTerm
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentTerm>> PostPaymentTerm(PaymentTerm paymentTerm)
        {
            _context.PaymentTerms.Add(paymentTerm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentTerm", new { id = paymentTerm.Id }, paymentTerm);
        }

        // DELETE: api/PaymentTerm/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentTerm(int id)
        {
            var paymentTerm = await _context.PaymentTerms.FindAsync(id);
            if (paymentTerm == null)
            {
                return NotFound();
            }

            _context.PaymentTerms.Remove(paymentTerm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentTermExists(int id)
        {
            return _context.PaymentTerms.Any(e => e.Id == id);
        }
    }
}
