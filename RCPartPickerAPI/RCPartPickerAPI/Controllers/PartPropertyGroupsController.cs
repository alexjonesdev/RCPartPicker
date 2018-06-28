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
    [Route("api/PartPropertyGroups")]
    public class PartPropertyGroupsController : Controller
    {
        private readonly PartPickerDBContext _context;

        public PartPropertyGroupsController(PartPickerDBContext context)
        {
            _context = context;
        }

        // GET: api/PartPropertyGroups
        [HttpGet]
        public IEnumerable<PartPropertyGroup> GetPartPropertyGroup()
        {
            return _context.PartPropertyGroup;
        }

        // GET: api/PartPropertyGroups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartPropertyGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partPropertyGroup = await _context.PartPropertyGroup.SingleOrDefaultAsync(m => m.Id == id);

            if (partPropertyGroup == null)
            {
                return NotFound();
            }

            return Ok(partPropertyGroup);
        }

        // PUT: api/PartPropertyGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartPropertyGroup([FromRoute] int id, [FromBody] PartPropertyGroup partPropertyGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partPropertyGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(partPropertyGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartPropertyGroupExists(id))
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

        // POST: api/PartPropertyGroups
        [HttpPost]
        public async Task<IActionResult> PostPartPropertyGroup([FromBody] PartPropertyGroup partPropertyGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PartPropertyGroup.Add(partPropertyGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartPropertyGroup", new { id = partPropertyGroup.Id }, partPropertyGroup);
        }

        // DELETE: api/PartPropertyGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartPropertyGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var partPropertyGroup = await _context.PartPropertyGroup.SingleOrDefaultAsync(m => m.Id == id);
            if (partPropertyGroup == null)
            {
                return NotFound();
            }

            _context.PartPropertyGroup.Remove(partPropertyGroup);
            await _context.SaveChangesAsync();

            return Ok(partPropertyGroup);
        }

        private bool PartPropertyGroupExists(int id)
        {
            return _context.PartPropertyGroup.Any(e => e.Id == id);
        }
    }
}