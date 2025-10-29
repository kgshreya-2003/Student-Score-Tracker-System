using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string Subject { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
