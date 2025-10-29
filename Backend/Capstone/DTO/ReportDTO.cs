using System;
using System.Collections.Generic;

namespace Capstone.Models.DTOs
{
    public class ReportDto
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int RollNumber { get; set; }
        public int Class { get; set; }
        public string Section { get; set; }

        public List<AttendanceDto> Attendance { get; set; } = new();
        public List<GradeDto> Grades { get; set; } = new();
        public List<FeedbackDto> Feedbacks { get; set; } = new();
    }

    public class AttendanceDto
    {
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }

    public class GradeDto
    {
        public string Subject { get; set; }
        public int Marks { get; set; }

        public string GradeLetter { get; set; }

    }

    public class FeedbackDto
    {

        public string Subject { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }

    }
}
