using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BiblioContext;
using BiblioContext.Model;

namespace BiblioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GanresController : ControllerBase
    {
        private readonly BiblioContext.BiblioContext _context;

        public GanresController(BiblioContext.BiblioContext context)
        {
            _context = context;
        }

        // GET: api/Ganres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ganre>>> GetGanre()
        {
            return await _context.Ganre.ToListAsync();
        }

        // GET: api/Ganres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ganre>> GetGanre(int id)
        {
            var ganre = await _context.Ganre.FindAsync(id);

            if (ganre == null)
            {
                return NotFound();
            }

            return ganre;
        }

        // PUT: api/Ganres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGanre(int id, Ganre ganre)
        {
            if (id != ganre.Id)
            {
                return BadRequest();
            }

            _context.Entry(ganre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GanreExists(id))
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

        // POST: api/Ganres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ganre>> PostGanre(Ganre ganre)
        {
            _context.Ganre.Add(ganre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGanre", new { id = ganre.Id }, ganre);
        }

        // DELETE: api/Ganres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGanre(int id)
        {
            var ganre = await _context.Ganre.FindAsync(id);
            if (ganre == null)
            {
                return NotFound();
            }

            _context.Ganre.Remove(ganre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GanreExists(int id)
        {
            return _context.Ganre.Any(e => e.Id == id);
        }
    }
}
