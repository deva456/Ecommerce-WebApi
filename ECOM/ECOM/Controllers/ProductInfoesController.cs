using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECOM.DbContext;
using ECOM.Models;

namespace ECOM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInfoesController : ControllerBase
    {
        private readonly EcomdbContext _context;

        public ProductInfoesController(EcomdbContext context)
        {
            _context = context;
        }

        // GET: api/ProductInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductInfo>>> GetProductInfo()
        {
            return await _context.ProductInfo.ToListAsync();
        }

        // GET: api/ProductInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductInfo>> GetProductInfo(int id)
        {
            var productInfo = await _context.ProductInfo.FindAsync(id);

            if (productInfo == null)
            {
                return NotFound();
            }

            return productInfo;
        }

        // PUT: api/ProductInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductInfo(int id, ProductInfo productInfo)
        {
            if (id != productInfo.productId)
            {
                return BadRequest();
            }

            _context.Entry(productInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductInfoExists(id))
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

        // POST: api/ProductInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductInfo>> PostProductInfo(ProductInfo productInfo)
        {
            _context.ProductInfo.Add(productInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductInfo", new { id = productInfo.productId }, productInfo);
        }

        // DELETE: api/ProductInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductInfo(int id)
        {
            var productInfo = await _context.ProductInfo.FindAsync(id);
            if (productInfo == null)
            {
                return NotFound();
            }

            _context.ProductInfo.Remove(productInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductInfoExists(int id)
        {
            return _context.ProductInfo.Any(e => e.productId == id);
        }
    }
}
