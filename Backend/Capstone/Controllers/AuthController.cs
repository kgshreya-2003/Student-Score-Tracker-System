using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null)
                return BadRequest("Request body is required.");

            // ✅ Admin login
            if (!string.IsNullOrEmpty(request.Email) && !string.IsNullOrEmpty(request.Password))
            {
                if (request.Email == "admin@gmail.com" && request.Password == "admin")
                {
                    return Ok(new
                    {
                        Email = request.Email,
                        Role = "Admin",
                        Id = 0,
                        Name = "Administrator"
                    });
                }
            }

            // ✅ Teacher login
            if (!string.IsNullOrEmpty(request.Email) && !string.IsNullOrEmpty(request.Password))
            {
                var teacher = await _context.Teachers
                    .FirstOrDefaultAsync(t => t.Email == request.Email && t.Password == request.Password);

                if (teacher != null)
                {
                    return Ok(new
                    {
                        Email = teacher.Email,
                        Role = "Teacher",
                        Id = teacher.TeacherId,
                        Name = teacher.Name
                    });
                }
            }

            // ✅ Student login using Email + Pass
            if (!string.IsNullOrEmpty(request.Email) && !string.IsNullOrEmpty(request.Password))
            {
                var student = await _context.Students
                    .FirstOrDefaultAsync(s => s.Email == request.Email && s.Password == request.Password);

                if (student != null)
                {
                    return Ok(new
                    {
                        Email = student.Email,
                        Role = "Student",
                        Id = student.Id,
                        Name = student.Name,
                        Class = student.Class,
                        Section = student.Section
                    });
                }
            }

            return Unauthorized("Invalid credentials");
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }     // For admin, teacher, and student
        public string Password { get; set; }
    }
}
