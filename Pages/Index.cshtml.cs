using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentAdvisor.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    // public IActionResult OnGet()
    // {
    //     return RedirectToPage("/Login/Index"); // Redirect to Login page
    // }

    public void OnGet()
    {
      

    }
}
