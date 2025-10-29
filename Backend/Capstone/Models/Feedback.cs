using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Feedback
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Student")]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(100)]              // Subject length
    public string Subject { get; set; }   // NEW COLUMN

    [Required]
    [MaxLength(500)]
    public string Comments { get; set; }

    [Required]
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
