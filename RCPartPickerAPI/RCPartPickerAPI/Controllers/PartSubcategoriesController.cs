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
    [Route("api/PartSubcategories")]
    public class PartSubcategoriesController : Controller
    {
        private readonly PartPickerDBContext _context;

        public PartSubcategoriesController(PartPickerDBContext context)
        {
            _context = context;
        }

        // GET: api/PartSubcategories
        [HttpGet]
        public IEnumerable<PartSubcategory> GetPartSubcategory()
        {
            return _context.PartSubcategory;
        }

        // GET: api/PartSubcategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartSubcategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partSubcategory = await _context.PartSubcategory.SingleOrDefaultAsync(m => m.Id == id);

            if (partSubcategory == null)
            {
                return NotFound();
            }

            return Ok(partSubcategory);
        }

        // PUT: api/PartSubcategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartSubcategory([FromRoute] int id, [FromBody] PartSubcategory partSubcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partSubcategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(partSubcategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartSubcategoryExists(id))
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

        // POST: api/PartSubcategories
        [HttpPost]
        public async Task<IActionResult> PostPartSubcategory([FromBody] PartSubcategory partSubcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PartSubcategory.Add(partSubcategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartSubcategory", new { id = partSubcategory.Id }, partSubcategory);
        }

        // DELETE: api/PartSubcategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartSubcategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partSubcategory = await _context.PartSubcategory.SingleOrDefaultAsync(m => m.Id == id);
            if (partSubcategory == null)
            {
                return NotFound();
            }

            _context.PartSubcategory.Remove(partSubcategory);
            await _context.SaveChangesAsync();

            return Ok(partSubcategory);
        }

        private bool PartSubcategoryExists(int id)
        {
            return _context.PartSubcategory.Any(e => e.Id == id);
        }
    }
}