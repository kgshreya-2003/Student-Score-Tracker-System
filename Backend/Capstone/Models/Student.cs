using System;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public byte Class { get; set; }

        [Required]
        public int RollNumber { get; set; }

        [Required]
        [MaxLength(5)]
        public string Section { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
