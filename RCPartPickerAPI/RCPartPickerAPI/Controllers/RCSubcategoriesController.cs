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
    [Route("api/RCSubcategories")]
    public class RCSubcategoriesController : Controller
    {
        private readonly PartPickerDBContext _context;

        public RCSubcategoriesController(PartPickerDBContext context)
        {
            _context = context;
        }

        // GET: api/RCSubcategories
        [HttpGet]
        public IEnumerable<RCSubcategory> GetRCSubcategory()
        {
            return _context.RCSubcategory;
        }

        // GET: api/RCSubcategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRCSubcategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var RCSubcategory = await _context.RCSubcategory.SingleOrDefaultAsync(m => m.Id == id);

            if (RCSubcategory == null)
            {
                return NotFound();
            }

            return Ok(RCSubcategory);
        }

        // PUT: api/RCSubcategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRCSubcategory([FromRoute] int id, [FromBody] RCSubcategory RCSubcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != RCSubcategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(RCSubcategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RCSubcategoryExists(id))
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

        // POST: api/RCSubcategories
        [HttpPost]
        public async Task<IActionResult> PostRCSubcategory([FromBody] RCSubcategory RCSubcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RCSubcategory.Add(RCSubcategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRCSubcategory", new { id = RCSubcategory.Id }, RCSubcategory);
        }

        // DELETE: api/RCSubcategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRCSubcategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var RCSubcategory = await _context.RCSubcategory.SingleOrDefaultAsync(m => m.Id == id);
            if (RCSubcategory == null)
            {
                return NotFound();
            }

            _context.RCSubcategory.Remove(RCSubcategory);
            await _context.SaveChangesAsync();

            return Ok(RCSubcategory);
        }

        private bool RCSubcategoryExists(int id)
        {
            return _context.RCSubcategory.Any(e => e.Id == id);
        }
    }
}