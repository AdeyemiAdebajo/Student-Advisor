using System;
using System.ComponentModel.DataAnnotations.Schema;
using StudentAdvisor.Migrations;

namespace StudentAdvisor.Models;

public class Student
{
    public ushort StudentId { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Gender { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Email { get; set; } = "";
    public ushort StudentProgramId { get; set; }
    [ForeignKey("StudentProgram")]
    public StudentProgram? StudentPrograms { get; set; }
    public int Semester { get; set; }

    public double GPA { get; set; }

    public int CreditsCompleted { get; set; }

    public string AcademicStanding { get; set; } = "Good Standing"; // Default value

    // Navigation Property (One-to-Many)
    public List<CourseHistory>? CourseHistories { get; set; }

    



}
