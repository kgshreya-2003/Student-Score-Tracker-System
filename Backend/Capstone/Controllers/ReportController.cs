using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;
using Capstone.Models.DTOs;
using System.Security.Cryptography.X509Certificates;  // Add this

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetReport(int classNumber, string section)
        {
            if (string.IsNullOrEmpty(section))
                return BadRequest("Section is required");

            var students = await _context.Students
                .Where(s => s.Class == classNumber && s.Section == section)
                .ToListAsync();

            var report = students.Select(s => new ReportDto
            {
                StudentId = s.Id,
                Name = s.Name,
                RollNumber = s.RollNumber,
                Class = s.Class,
                Section = s.Section,
                Attendance = _context.Attendances
                    .Where(a => a.StudentId == s.Id)
                    .Select(a => new AttendanceDto
                    {
                        Subject = a.Subject,
                        Date = a.Date,
                        IsPresent = a.IsPresent
                    }).ToList(),
                Grades = _context.Grades
                    .Where(g => g.StudentId == s.Id)
                    .Select(g => new GradeDto
                    {
                        Subject = g.Subject,
                        Marks = g.Marks,
                        GradeLetter = g.GradeLetter
                    }).ToList(),
                Feedbacks = _context.Feedbacks
                    .Where(f => f.StudentId == s.Id)
                    .Select(f => new FeedbackDto
                    {
                        Subject = f.Subject,    // <-- Make sure this is mapped
                        Comments = f.Comments,
                        Date = f.Date
                    }).ToList()
            }).ToList();

            return Ok(report);
        }
    }
}