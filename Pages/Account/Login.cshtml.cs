using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
// using StudentAdvisor.Data;
using StudentAdvisor.Models;


namespace StudentAdvisor.Pages.Account
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        

        [BindProperty]
        public Login Login { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // _context.Courses.Add(Course);
            // await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
