using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GradeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Grade?classNumber=10&section=A
        [HttpGet]
        public async Task<IActionResult> GetStudents(int classNumber, string section)
        {
            var students = await _context.Students
                .Where(s => s.Class == classNumber && s.Section == section)
                .ToListAsync();
            return Ok(students);
        }

        // POST: api/Grade
        [HttpPost]
        public async Task<IActionResult> SaveGrades([FromBody] List<Grade> grades)
        {
            foreach (var grade in grades)
            {
                // Validate required fields
                if (grade.Marks < 0 || string.IsNullOrEmpty(grade.Subject) || string.IsNullOrEmpty(grade.GradeLetter))
                    return BadRequest("Marks, Subject, and GradeLetter are required for all grades.");

                // Check if grade for student+subject already exists
                var exists = await _context.Grades
                    .FirstOrDefaultAsync(g => g.StudentId == grade.StudentId && g.Subject == grade.Subject);

                if (exists != null)
                {
                    exists.Marks = grade.Marks;
                    exists.GradeLetter = grade.GradeLetter;
                    exists.Date = DateTime.UtcNow;
                    _context.Grades.Update(exists);
                }
                else
                {
                    grade.Date = DateTime.UtcNow;
                    _context.Grades.Add(grade);
                }
            }

            await _context.SaveChangesAsync();
            return Ok(grades);
        }

        // GET: api/Grade/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAllGrades()
        {
            var grades = await _context.Grades.Include(g => g.Student).ToListAsync();
            return Ok(grades);
        }

        // DELETE: api/Grade/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
                return NotFound(new { message = "Grade not found" });

            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Grade deleted successfully" });
        }
    }
}
