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
    public class GroupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Group
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupModel>>> GetGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        // GET: api/Group/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupModel>> GetGroupModel(int id)
        {
            var groupModel = await _context.Groups.FindAsync(id);

            if (groupModel == null)
            {
                return NotFound();
            }

            return groupModel;
        }

        // PUT: api/Group/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupModel(int id, GroupModel groupModel)
        {
            if (id != groupModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(groupModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupModelExists(id))
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

        // POST: api/Group
        [HttpPost]
        public async Task<ActionResult<GroupModel>> PostGroupModel(GroupModel groupModel)
        {
            _context.Groups.Add(groupModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupModel", new { id = groupModel.Id }, groupModel);
        }

        // DELETE: api/Group/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupModel>> DeleteGroupModel(int id)
        {
            var groupModel = await _context.Groups.FindAsync(id);
            if (groupModel == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(groupModel);
            await _context.SaveChangesAsync();

            return groupModel;
        }

        private bool GroupModelExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}
