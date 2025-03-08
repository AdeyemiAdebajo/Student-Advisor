
using Microsoft.EntityFrameworkCore;
using StudentAdvisor.Models;

namespace StudentAdvisor.Data;

public class AppDbcontext2 : DbContext
{
    public AppDbcontext2(DbContextOptions<AppDbcontext2> options)
       : base(options) { }

    public virtual DbSet<Student>? Students { get; set; }
    public virtual DbSet<StudentProgram>? StudentPrograms { get; set; }
    public virtual DbSet<Course>? Courses { get; set; }
    public virtual DbSet<CourseGrade>? CourseGrades { get; set; }
    public virtual DbSet<CourseHistory>? CourseHistories { get; set; }
    public virtual DbSet<AdvisorsNote>? AdvisorsNotes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Student>().ToTable("Student");
        modelBuilder.Entity<StudentProgram>().ToTable("StudentProgram");
        modelBuilder.Entity<Course>().ToTable("Course");
        modelBuilder.Entity<CourseGrade>().ToTable("CourseGrade");
        modelBuilder.Entity<CourseHistory>().ToTable("CourseHistory");
        modelBuilder.Entity<AdvisorsNote>().ToTable("AdvisorNotes");
    }
}
