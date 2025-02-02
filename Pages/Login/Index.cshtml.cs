using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentAdvisor.Data;
using StudentAdvisor.Models;

namespace StudentAdvisor.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly StudentAdvisor.Data.AppDbcontext _context;

        public IndexModel(StudentAdvisor.Data.AppDbcontext context)
        {
            _context = context;
        }

        [BindProperty]
        public Logins Logins { get; set; } = new Logins();

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Check if user exists in the database
            var user = _context.Register.FirstOrDefault(u => u.Email == Logins.Email);

            if (user == null || user.Password != Logins.Password)
            {
                ErrorMessage = "Invalid email or password.";
                return Page();
            }

            // Redirect to a dashboard or homepage after successful login
            return RedirectToPage("/Dashboard/Index");
        }
    }
}
