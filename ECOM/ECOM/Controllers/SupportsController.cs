using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOM.DbContext;
using ECOM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ECOM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportsController : ControllerBase
    {
        private readonly EcomdbContext _context;

        public SupportsController(EcomdbContext context)
        {
            _context = context;
        }

        // GET: api/Supports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Support>>> Getsupports()
        {
            return await _context.supports.ToListAsync();
        }

        // GET: api/Supports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Support>> GetSupport(int id)
        {
            var support = await _context.supports.FindAsync(id);

            if (support == null)
            {
                return NotFound();
            }

            return support;
        }

        // PUT: api/Supports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupport(int id, Support support)
        {
            if (id != support.supportId)
            {
                return BadRequest();
            }

            _context.Entry(support).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportExists(id))
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

        // POST: api/Supports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Support>> PostSupport(Support support)
        {
            _context.supports.Add(support);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupport", new { id = support.supportId }, support);
        }

        // DELETE: api/Supports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupport(int id)
        {
            var support = await _context.supports.FindAsync(id);
            if (support == null)
            {
                return NotFound();
            }

            _context.supports.Remove(support);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupportExists(int id)
        {
            return _context.supports.Any(e => e.supportId == id);
        }
    }
}
