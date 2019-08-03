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
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseModel>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseModel>> GetCourseModel(int id)
        {
            var courseModel = await _context.Courses.FindAsync(id);

            if (courseModel == null)
            {
                return NotFound();
            }

            return courseModel;
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseModel(int id, CourseModel courseModel)
        {
            if (id != courseModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(courseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseModelExists(id))
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

        // POST: api/Course
        [HttpPost]
        public async Task<ActionResult<CourseModel>> PostCourseModel(CourseModel courseModel)
        {
            _context.Courses.Add(courseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseModel", new { id = courseModel.Id }, courseModel);
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CourseModel>> DeleteCourseModel(int id)
        {
            var courseModel = await _context.Courses.FindAsync(id);
            if (courseModel == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(courseModel);
            await _context.SaveChangesAsync();

            return courseModel;
        }

        private bool CourseModelExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
