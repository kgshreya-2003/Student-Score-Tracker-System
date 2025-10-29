using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeedbackController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Feedback?classNumber=10&section=A
        [HttpGet]
        public async Task<IActionResult> GetStudents(int classNumber, string section)
        {
            if (string.IsNullOrEmpty(section))
                return BadRequest("Section is required.");

            var students = await _context.Students
                .Where(s => s.Class == classNumber && s.Section == section)
                .ToListAsync();

            return Ok(students);
        }

        // POST: api/Feedback
        [HttpPost]
        public async Task<IActionResult> SaveFeedback([FromBody] List<Feedback> feedbackList)
        {
            if (feedbackList == null || !feedbackList.Any())
                return BadRequest("Feedback list is empty");

            foreach (var feedback in feedbackList)
            {
                feedback.Date = DateTime.UtcNow;
                _context.Feedbacks.Add(feedback);
            }

            await _context.SaveChangesAsync();
            return Ok(feedbackList);
        }

    }
}
