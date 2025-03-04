using System;

namespace StudentAdvisor.Models;

public class CourseHistory
{
    
    public ushort CourseHistoryId { get; set; }
    public ushort StudentId  { get; set; }
    
    public Student? Students { get; set; } // Navigation Property (Many-to-One)

    public string CourseName { get; set; } = "";

    public string CourseCode { get; set; } = "";

    public string Grade { get; set; } = ""; // Default grade

    public int Credits { get; set; }


}
