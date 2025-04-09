using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentAdvisor.Data;
using StudentAdvisor.Models;

namespace StudentAdvisor.Pages_Advisor
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
        ViewData["StudentId"] = new SelectList(
                _context.Students
                    .OrderBy(s => s.FirstName)
                    .Select(s => new {
                        s.StudentId,
                        FullName = s.FirstName + " " + s.LastName
                    }),
                "StudentId",
                "FullName");

            return Page();
        }

        [BindProperty]
        public AdvisorsNote AdvisorsNote { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AdvisorsNotes.Add(AdvisorsNote);
            var adnote = await _context
            .SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
