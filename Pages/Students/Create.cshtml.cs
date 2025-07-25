using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentAdvisor.Data;
using StudentAdvisor.Models;

namespace StudentAdvisor.Pages_Students
{
    public class CreateModel : PageModel
    {
        private readonly StudentAdvisor.Data.AppDbcontext2 _context;

        public CreateModel(StudentAdvisor.Data.AppDbcontext2 context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["StudentProgramId"] = new SelectList(_context.StudentPrograms, "StudentProgramId", "StudentProgramId");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
