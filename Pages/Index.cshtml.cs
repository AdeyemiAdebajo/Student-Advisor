using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace StudentAdvisor.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    public IActionResult OnGet()
    
        {
            // Check if the user is logged in using session
            if (HttpContext.Session.GetString("Logins.Email") != null)
            {
                return RedirectToPage("/Dashboard/Index");
            }

            return RedirectToPage("/Login/Index"); // Redirect to login if not logged in
        }
    }

    // public IActionResult OnGet()
    // {
    //     return RedirectToPage("/Login/Index"); // Redirect to Login page
    // }

    // public void OnGet()
    // {
      

    // }

