using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentAdvisor.Data;
using StudentAdvisor.Models;

namespace StudentAdvisor.Pages_Students
{
    public class IndexModel : PageModel
    {
        private readonly StudentAdvisor.Data.AppDbcontext2 _context;

        public IndexModel(StudentAdvisor.Data.AppDbcontext2 context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Students
                .Include(s => s.StudentPrograms).ToListAsync();
        }
    }
}
