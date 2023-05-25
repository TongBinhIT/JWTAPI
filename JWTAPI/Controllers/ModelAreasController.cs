using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JWTAPI.Data;
using JWTAPI.Models;

namespace JWTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelAreasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ModelAreasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ModelAreas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelArea>>> GetModelArea()
        {
          if (_context.ModelArea == null)
          {
              return NotFound();
          }
            return await _context.ModelArea.ToListAsync();
        }

        // GET: api/ModelAreas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelArea>> GetModelArea(int id)
        {
          if (_context.ModelArea == null)
          {
              return NotFound();
          }
            var modelArea = await _context.ModelArea.FindAsync(id);

            if (modelArea == null)
            {
                return NotFound();
            }

            return modelArea;
        }

        // PUT: api/ModelAreas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelArea(int id, ModelArea modelArea)
        {
            if (id != modelArea.IdArea)
            {
                return BadRequest();
            }

            _context.Entry(modelArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelAreaExists(id))
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

        // POST: api/ModelAreas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModelArea>> PostModelArea(ModelArea modelArea)
        {
          if (_context.ModelArea == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ModelArea'  is null.");
          }
            _context.ModelArea.Add(modelArea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelArea", new { id = modelArea.IdArea }, modelArea);
        }

        // DELETE: api/ModelAreas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelArea(int id)
        {
            if (_context.ModelArea == null)
            {
                return NotFound();
            }
            var modelArea = await _context.ModelArea.FindAsync(id);
            if (modelArea == null)
            {
                return NotFound();
            }

            _context.ModelArea.Remove(modelArea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModelAreaExists(int id)
        {
            return (_context.ModelArea?.Any(e => e.IdArea == id)).GetValueOrDefault();
        }
    }
}
