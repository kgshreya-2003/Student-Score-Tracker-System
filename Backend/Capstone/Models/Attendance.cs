using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        // Store the foreign key
        [Required]
        public int StudentId { get; set; }

        // Navigation property, optional in POST
        [ForeignKey("StudentId")]
        public Student? Student { get; set; } // Make it nullable

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsPresent { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
