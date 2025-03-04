using System;
using System.ComponentModel.DataAnnotations;

namespace StudentAdvisor.Models;

public class Course
{
    
    public int CourseId { get; set; }

    [Required]
    public string CourseName { get; set; } = "";

    [Required]
    public string CourseCode { get; set; } = ""; // Example: CS101

    public int Credits { get; set; }

    // Navigation Property (One-to-Many)
    public List<CourseGrade>? CourseGrades { get; set; }

}
