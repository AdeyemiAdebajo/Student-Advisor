


using System.ComponentModel.DataAnnotations;

using StudentAdvisor.Models;
namespace StudentAdvisor.Models;
public class Logins
{
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
     [Required(ErrorMessage = "Password is required")]
     [DataType(DataType.Password)]
    public string Password { get; set; }

}
