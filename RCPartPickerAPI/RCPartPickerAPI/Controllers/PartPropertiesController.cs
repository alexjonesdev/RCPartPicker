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
    [Route("api/PartProperties")]
    public class PartPropertiesController : Controller
    {
        private readonly PartPickerDBContext _context;

        public PartPropertiesController(PartPickerDBContext context)
        {
            _context = context;
        }

        // GET: api/PartProperties
        [HttpGet]
        public IEnumerable<PartProperty> GetPartProperty()
        {
            return _context.PartProperty;
        }

        // GET: api/PartProperties/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartProperty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partProperty = await _context.PartProperty.SingleOrDefaultAsync(m => m.Id == id);

            if (partProperty == null)
            {
                return NotFound();
            }

            return Ok(partProperty);
        }

        // PUT: api/PartProperties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartProperty([FromRoute] int id, [FromBody] PartProperty partProperty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partProperty.Id)
            {
                return BadRequest();
            }

            _context.Entry(partProperty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartPropertyExists(id))
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

        // POST: api/PartProperties
        [HttpPost]
        public async Task<IActionResult> PostPartProperty([FromBody] PartProperty partProperty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PartProperty.Add(partProperty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartProperty", new { id = partProperty.Id }, partProperty);
        }

        // DELETE: api/PartProperties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartProperty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partProperty = await _context.PartProperty.SingleOrDefaultAsync(m => m.Id == id);
            if (partProperty == null)
            {
                return NotFound();
            }

            _context.PartProperty.Remove(partProperty);
            await _context.SaveChangesAsync();

            return Ok(partProperty);
        }

        private bool PartPropertyExists(int id)
        {
            return _context.PartProperty.Any(e => e.Id == id);
        }
    }
}