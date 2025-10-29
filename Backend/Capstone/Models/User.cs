using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }

        public Teacher? Teacher { get; set; }
    }
}
