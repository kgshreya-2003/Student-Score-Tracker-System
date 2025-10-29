using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Models
{
    public class AssignTeacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ClassName { get; set; }

        [Required]
        public string Section { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        // ✅ Make this optional to fix the 400 error
        public Teacher? Teacher { get; set; }
    }
}
