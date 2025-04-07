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
    public class DetailsModel : PageModel
    {
        private readonly StudentAdvisor.Data.AppDbcontext2 _context;

        public DetailsModel(StudentAdvisor.Data.AppDbcontext2 context)
        {
            _context = context;
        }

        public Student Student { get; set; } = default!;
        public StudentProgram  StudentProgram {get; set;}= default!;
        public AdvisorsNote AdvisorsNote{get;set;}=default!;

        public async Task<IActionResult> OnGetAsync(ushort? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
            .Include(s => s.StudentPrograms)
            .Include(a=>a.AdvisorsNotes)
            // .Include(a=>a.AdvisorsNoteId)

            .Include(s => s.CourseHistories) 
            .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            return Page();
            
        }
    }
}
