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
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModel>> GetProjectModel(int id)
        {
            var projectModel = await _context.Projects.FindAsync(id);

            if (projectModel == null)
            {
                return NotFound();
            }

            return projectModel;
        }

        // PUT: api/Project/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectModel(int id, ProjectModel projectModel)
        {
            if (id != projectModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectModelExists(id))
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

        // POST: api/Project
        [HttpPost]
        public async Task<ActionResult<ProjectModel>> PostProjectModel(ProjectModel projectModel)
        {
            _context.Projects.Add(projectModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectModel", new { id = projectModel.Id }, projectModel);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProjectModel>> DeleteProjectModel(int id)
        {
            var projectModel = await _context.Projects.FindAsync(id);
            if (projectModel == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(projectModel);
            await _context.SaveChangesAsync();

            return projectModel;
        }

        private bool ProjectModelExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
