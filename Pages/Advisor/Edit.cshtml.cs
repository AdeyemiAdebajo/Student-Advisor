using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentAdvisor.Data;
using StudentAdvisor.Models;

namespace StudentAdvisor.Pages_Advisor
{
    public class EditModel : PageModel
    {
        private readonly StudentAdvisor.Data.AppDbcontext2 _context;

        public EditModel(StudentAdvisor.Data.AppDbcontext2 context)
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

            var advisorsnote =  await _context.AdvisorsNotes.FirstOrDefaultAsync(m => m.AdvisorsNoteId == id);
            if (advisorsnote == null)
            {
                return NotFound();
            }
            AdvisorsNote = advisorsnote;
           ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AdvisorsNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvisorsNoteExists(AdvisorsNote.AdvisorsNoteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AdvisorsNoteExists(ushort id)
        {
            return _context.AdvisorsNotes.Any(e => e.AdvisorsNoteId == id);
        }
    }
}
