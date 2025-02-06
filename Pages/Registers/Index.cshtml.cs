// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.RazorPages;
// using Microsoft.EntityFrameworkCore;
// using StudentAdvisor.Data;
// using StudentAdvisor.Models;

// namespace StudentAdvisor.Pages.Registers
// {
//     public class IndexModel : PageModel
//     {
//         private readonly StudentAdvisor.Data.AppDbcontext _context;

//         public IndexModel(StudentAdvisor.Data.AppDbcontext context)
//         {
//             _context = context;
//         }

//         [BindProperty]
//         public Register Register { get; set; } = new Register();

//         public async Task<IActionResult> OnPostAsync()
//         {
//             if (!ModelState.IsValid)
//                 return Page();

//             // Check if email already exists
//             if (_context.Register.Any(u => u.Email == Register.Email))
//             {
//                 ModelState.AddModelError("", "Email already registered.");
//                 return Page();
//             }

//             // Hash the password
//             // string hashedPassword = HashPassword(Register.Password);

//             // Save new us
//             var user = new Register
//             {
//                 FullName = Register.FullName,
//                 Email = Register.Email,
//                 Password = Register.Password,
//                 ConfirmPassword=Register.ConfirmPassword
//             };

//             _context.Register.Add(user);
//             await _context.SaveChangesAsync();

//             return RedirectToPage("/Logins");
//         }

        
//     }
// }
