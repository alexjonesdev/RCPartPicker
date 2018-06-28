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
    [Route("api/Parts")]
    public class PartsController : Controller
    {
        private readonly PartPickerDBContext _context;

        public PartsController(PartPickerDBContext context)
        {
            _context = context;
        }

        // GET: api/Parts
        [HttpGet]
        public IEnumerable<Part> GetPart()
        {
            return _context.Part;
        }

        // GET: api/Parts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPart([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var part = await _context.Part.SingleOrDefaultAsync(m => m.Id == id);

            if (part == null)
            {
                return NotFound();
            }

            return Ok(part);
        }

        // PUT: api/Parts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPart([FromRoute] int id, [FromBody] Part part)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != part.Id)
            {
                return BadRequest();
            }

            _context.Entry(part).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(id))
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

        // POST: api/Parts
        [HttpPost]
        public async Task<IActionResult> PostPart([FromBody] Part part)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Part.Add(part);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPart", new { id = part.Id }, part);
        }

        // DELETE: api/Parts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePart([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var part = await _context.Part.SingleOrDefaultAsync(m => m.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            _context.Part.Remove(part);
            await _context.SaveChangesAsync();

            return Ok(part);
        }

        private bool PartExists(int id)
        {
            return _context.Part.Any(e => e.Id == id);
        }
    }
}