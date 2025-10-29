using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignTeacherController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssignTeacherController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Get all assignments (with teacher details)
        [HttpGet]
        public async Task<IActionResult> GetAssignments()
        {
            var assignments = await _context.AssignTeachers
                .Include(a => a.Teacher)
                .ToListAsync();

            return Ok(assignments);
        }

        // ✅ Add new assignment
        [HttpPost]
        public async Task<IActionResult> AddAssignment([FromBody] AssignTeacher assignTeacher)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.AssignTeachers.Add(assignTeacher);
            await _context.SaveChangesAsync();

            // Return the saved record with included teacher
            var result = await _context.AssignTeachers
                .Include(a => a.Teacher)
                .FirstOrDefaultAsync(a => a.Id == assignTeacher.Id);

            return Ok(result);
        }

        // ✅ Update existing assignment
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(int id, [FromBody] AssignTeacher updatedAssignment)
        {
            var existing = await _context.AssignTeachers.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.ClassName = updatedAssignment.ClassName;
            existing.Section = updatedAssignment.Section;
            existing.Subject = updatedAssignment.Subject;
            existing.TeacherId = updatedAssignment.TeacherId;

            await _context.SaveChangesAsync();

            var result = await _context.AssignTeachers
                .Include(a => a.Teacher)
                .FirstOrDefaultAsync(a => a.Id == id);

            return Ok(result);
        }

        // ✅ Delete assignment
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var assignment = await _context.AssignTeachers.FindAsync(id);
            if (assignment == null)
                return NotFound();

            _context.AssignTeachers.Remove(assignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
