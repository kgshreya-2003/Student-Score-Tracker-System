using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AttendanceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendance()
        {
            var attendances = await _context.Attendances.Include(a => a.Student).ToListAsync();
            return Ok(attendances);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAttendance([FromBody] List<Attendance> attendances)
        {
            if (attendances == null || !attendances.Any())
                return BadRequest("Attendances payload is empty");

            foreach (var attendance in attendances)
            {
                var exists = await _context.Attendances
                    .FirstOrDefaultAsync(a => a.StudentId == attendance.StudentId
                                           && a.Subject == attendance.Subject
                                           && a.Date.Date == attendance.Date.Date);
                if (exists != null)
                {
                    exists.IsPresent = attendance.IsPresent;
                    exists.UpdatedAt = DateTime.UtcNow;
                    _context.Attendances.Update(exists);
                }
                else
                {
                    _context.Attendances.Add(attendance);
                }
            }

            await _context.SaveChangesAsync();
            return Ok(attendances);
        }
    }
}
