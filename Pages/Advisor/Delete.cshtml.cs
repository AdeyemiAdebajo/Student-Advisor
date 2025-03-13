using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentAdvisor.Data;
using StudentAdvisor.Models;

namespace StudentAdvisor.Pages_Advisor
{
    public class DeleteModel : PageModel
    {
        private readonly StudentAdvisor.Data.AppDbcontext2 _context;

        public DeleteModel(StudentAdvisor.Data.AppDbcontext2 context)
        {
            _context = context;
        }

        [BindProperty]
        public AdvisorsNote AdvisorsNote { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(ushort? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advisorsnote = await _context.AdvisorsNotes.FirstOrDefaultAsync(m => m.AdvisorsNoteId == id);

            if (advisorsnote == null)
            {
                return NotFound();
            }
            else
            {
                AdvisorsNote = advisorsnote;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(ushort? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advisorsnote = await _context.AdvisorsNotes.FindAsync(id);
            if (advisorsnote != null)
            {
                AdvisorsNote = advisorsnote;
                _context.AdvisorsNotes.Remove(AdvisorsNote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
