using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentAdvisor.Data;
using StudentAdvisor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdvisor.Pages_Students
{
    public class GraduatingModel : PageModel
    {
        private readonly AppDbcontext2 _context;

        public GraduatingModel(AppDbcontext2 context)
        {
            _context = context;
        }

        public List<Student> GraduatingStudents { get; set; } = new();

        public async Task OnGetAsync()
        {
            var students = await _context.Students
                .Include(s => s.StudentPrograms)
                .Include(s => s.CourseHistories)
                .ToListAsync();

            GraduatingStudents = students.Where(s =>
            {
                var failedCourses = s.CourseHistories.Where(c => c.Grade == "F").Count();
                return s.GPA > 2.0 &&
                       s.CreditsCompleted >= 70 &&
                       (s.AcademicStanding == "Good" || s.AcademicStanding == "Probation") &&
                       failedCourses < 2;
            }).ToList();
        }
    }
}
