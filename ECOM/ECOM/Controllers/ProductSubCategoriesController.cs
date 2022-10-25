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
    public class ProductSubCategoriesController : ControllerBase
    {
        private readonly EcomdbContext _context;

        public ProductSubCategoriesController(EcomdbContext context)
        {
            _context = context;
        }

        // GET: api/ProductSubCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSubCategory>>> GetSubCategories()
        {
            return await _context.SubCategories.ToListAsync();
        }

        // GET: api/ProductSubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSubCategory>> GetProductSubCategory(int id)
        {
            var productSubCategory = await _context.SubCategories.FindAsync(id);

            if (productSubCategory == null)
            {
                return NotFound();
            }

            return productSubCategory;
        }

        // PUT: api/ProductSubCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSubCategory(int id, ProductSubCategory productSubCategory)
        {
            if (id != productSubCategory.subCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(productSubCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSubCategoryExists(id))
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

        // POST: api/ProductSubCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductSubCategory>> PostProductSubCategory(ProductSubCategory productSubCategory)
        {
            _context.SubCategories.Add(productSubCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductSubCategory", new { id = productSubCategory.subCategoryId }, productSubCategory);
        }

        // DELETE: api/ProductSubCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductSubCategory(int id)
        {
            var productSubCategory = await _context.SubCategories.FindAsync(id);
            if (productSubCategory == null)
            {
                return NotFound();
            }

            _context.SubCategories.Remove(productSubCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductSubCategoryExists(int id)
        {
            return _context.SubCategories.Any(e => e.subCategoryId == id);
        }
    }
}
