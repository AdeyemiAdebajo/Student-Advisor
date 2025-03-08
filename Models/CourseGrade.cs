
using System.ComponentModel.DataAnnotations;

namespace StudentAdvisor.Models;
using StudentAdvisor.Models;

public class CourseGrade
{
    public ushort CourseGradeId { get; set; }

    public ushort StudentId { get; set; }
    public Student? Students { get; set; }

    public ushort CourseId { get; set; }

    public Course? Courses { get; set; }
    [Required]
    public string Grade { get; set; } = ""; 
    public double GradePoint { get; set; } 

   


}
