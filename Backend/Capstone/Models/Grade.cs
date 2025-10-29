using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Capstone.Models;

public class Grade
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int StudentId { get; set; }

    [ForeignKey("StudentId")]
    public Student? Student { get; set; }  // Navigation property

    [Required]
    [MaxLength(50)]
    public string Subject { get; set; }

    [Required]
    [Range(0, 100)]
    public int Marks { get; set; }

    [Required]
    [MaxLength(2)]
    public string GradeLetter { get; set; }  // A+, A, B+, etc.

    [Required]
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
