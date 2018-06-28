using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RCPartPickerAPI.Models;

namespace RCPartPickerAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/PartCategories")]
    public class PartCategoriesController : Controller
    {
        private readonly PartPickerDBContext _context;

        public PartCategoriesController(PartPickerDBContext context)
        {
            _context = context;
        }

        // GET: api/PartCategories
        [HttpGet]
        public IEnumerable<PartCategory> GetPartCategory()
        {
            return _context.PartCategory;
        }

        // GET: api/PartCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partCategory = await _context.PartCategory.SingleOrDefaultAsync(m => m.Id == id);

            if (partCategory == null)
            {
                return NotFound();
            }

            return Ok(partCategory);
        }

        // PUT: api/PartCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartCategory([FromRoute] int id, [FromBody] PartCategory partCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(partCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartCategoryExists(id))
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

        // POST: api/PartCategories
        [HttpPost]
        public async Task<IActionResult> PostPartCategory([FromBody] PartCategory partCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PartCategory.Add(partCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartCategory", new { id = partCategory.Id }, partCategory);
        }

        // DELETE: api/PartCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partCategory = await _context.PartCategory.SingleOrDefaultAsync(m => m.Id == id);
            if (partCategory == null)
            {
                return NotFound();
            }

            _context.PartCategory.Remove(partCategory);
            await _context.SaveChangesAsync();

            return Ok(partCategory);
        }

        private bool PartCategoryExists(int id)
        {
            return _context.PartCategory.Any(e => e.Id == id);
        }
    }
}