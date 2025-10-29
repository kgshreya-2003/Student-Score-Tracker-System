using Microsoft.EntityFrameworkCore;
using Capstone.Models;

namespace Capstone.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<AssignTeacher> AssignTeachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }


    }
}
