using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAVSS.Data;
using TAVSS.Models;

namespace TAVSS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TAController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TAController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TA
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TAModel>>> GetTAs()
        {
            return await _context.TAs.ToListAsync();
        }

        // GET: api/TA/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TAModel>> GetTAModel(int id)
        {
            var tAModel = await _context.TAs.FindAsync(id);

            if (tAModel == null)
            {
                return NotFound();
            }

            return tAModel;
        }

        // PUT: api/TA/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTAModel(int id, TAModel tAModel)
        {
            if (id != tAModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(tAModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TAModelExists(id))
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

        // POST: api/TA
        [HttpPost]
        public async Task<ActionResult<TAModel>> PostTAModel(TAModel tAModel)
        {
            _context.TAs.Add(tAModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTAModel", new { id = tAModel.Id }, tAModel);
        }

        // DELETE: api/TA/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TAModel>> DeleteTAModel(int id)
        {
            var tAModel = await _context.TAs.FindAsync(id);
            if (tAModel == null)
            {
                return NotFound();
            }

            _context.TAs.Remove(tAModel);
            await _context.SaveChangesAsync();

            return tAModel;
        }

        private bool TAModelExists(int id)
        {
            return _context.TAs.Any(e => e.Id == id);
        }
    }
}
