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
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudentModel(int id)
        {
            var studentModel = await _context.Students.FindAsync(id);

            if (studentModel == null)
            {
                return NotFound();
            }

            return studentModel;
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentModel(int id, StudentModel studentModel)
        {
            if (id != studentModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(id))
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

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<StudentModel>> PostStudentModel(StudentModel studentModel)
        {
            _context.Students.Add(studentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentModel", new { id = studentModel.Id }, studentModel);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentModel>> DeleteStudentModel(int id)
        {
            var studentModel = await _context.Students.FindAsync(id);
            if (studentModel == null)
            {
                return NotFound();
            }

            _context.Students.Remove(studentModel);
            await _context.SaveChangesAsync();

            return studentModel;
        }

        private bool StudentModelExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
