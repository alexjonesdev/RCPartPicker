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
    [Route("api/RCCategories")]
    public class RCCategoriesController : Controller
    {
        private readonly PartPickerDBContext _context;

        public RCCategoriesController(PartPickerDBContext context)
        {
            _context = context;
        }

        // GET: api/RCCategories
        [HttpGet]
        public IEnumerable<RCCategory> GetRCCategory()
        {
            return _context.RCCategory;
        }

        // GET: api/RCCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRCCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var RCCategory = await _context.RCCategory.SingleOrDefaultAsync(m => m.Id == id);

            if (RCCategory == null)
            {
                return NotFound();
            }

            return Ok(RCCategory);
        }

        // PUT: api/RCCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRCCategory([FromRoute] int id, [FromBody] RCCategory RCCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != RCCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(RCCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RCCategoryExists(id))
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

        // POST: api/RCCategories
        [HttpPost]
        public async Task<IActionResult> PostRCCategory([FromBody] RCCategory RCCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RCCategory.Add(RCCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRCCategory", new { id = RCCategory.Id }, RCCategory);
        }

        // DELETE: api/RCCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRCCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var RCCategory = await _context.RCCategory.SingleOrDefaultAsync(m => m.Id == id);
            if (RCCategory == null)
            {
                return NotFound();
            }

            _context.RCCategory.Remove(RCCategory);
            await _context.SaveChangesAsync();

            return Ok(RCCategory);
        }

        private bool RCCategoryExists(int id)
        {
            return _context.RCCategory.Any(e => e.Id == id);
        }
    }
}