using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustinRESTAPISQLServerEFDemo.Models;
using Microsoft.AspNetCore.Cors;

namespace JustinRESTAPISQLServerEFDemo.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PipelinesController : ControllerBase
    {
        private readonly JustinDemoContext _context;

        public PipelinesController(JustinDemoContext context)
        {
            _context = context;
        }

        // GET: api/Pipelines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pipelines>>> GetPipelines()
        {
            return await _context.Pipelines.ToListAsync();
        }

        // GET: api/Pipelines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pipelines>> GetPipelines(int id)
        {
            var pipelines = await _context.Pipelines.FindAsync(id);

            if (pipelines == null)
            {
                return NotFound();
            }

            return pipelines;
        }

        // PUT: api/Pipelines/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPipelines(int id, Pipelines pipelines)
        {
            if (id != pipelines.Id)
            {
                return BadRequest();
            }

            _context.Entry(pipelines).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PipelinesExists(id))
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

        // POST: api/Pipelines
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pipelines>> PostPipelines(Pipelines pipelines)
        {
            _context.Pipelines.Add(pipelines);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPipelines", new { id = pipelines.Id }, pipelines);
        }

        // DELETE: api/Pipelines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pipelines>> DeletePipelines(int id)
        {
            var pipelines = await _context.Pipelines.FindAsync(id);
            if (pipelines == null)
            {
                return NotFound();
            }

            _context.Pipelines.Remove(pipelines);
            await _context.SaveChangesAsync();

            return pipelines;
        }

        private bool PipelinesExists(int id)
        {
            return _context.Pipelines.Any(e => e.Id == id);
        }
    }
}
