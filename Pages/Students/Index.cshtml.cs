using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentAdvisor.Data;
using StudentAdvisor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdvisor.Pages_Students
{
    public class IndexModel : PageModel
    {
        private readonly AppDbcontext2 _context;

        public IndexModel(AppDbcontext2 context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; } = default!;
        public List<string> ProgramList { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Program { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? Semester { get; set; }

        public async Task OnGetAsync()
        {
            // Load distinct program titles
            ProgramList = await _context.StudentPrograms
                .Select(p => p.programTitle)
                .Distinct()
                .OrderBy(p => p)
                .ToListAsync();

            // Build query
            var query = _context.Students
                .Include(s => s.StudentPrograms)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                query = query.Where(s =>
                    s.FirstName.Contains(SearchTerm) ||
                    s.LastName.Contains(SearchTerm));
            }

            if (!string.IsNullOrWhiteSpace(Program))
            {
                query = query.Where(s =>
                    s.StudentPrograms != null &&
                    s.StudentPrograms.programTitle == Program);
            }

            if (Semester.HasValue)
            {
                query = query.Where(s => s.Semester == Semester.Value);
            }

            Student = await query.ToListAsync();
        }
    }
}
