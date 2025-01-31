namespace StudentAdvisor.Models;
using StudentAdvisor.Models;
using System.ComponentModel.DataAnnotations;

public class Register
{
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; }
    
     [Required(ErrorMessage = "Password is required")]
     [DataType(DataType.Password)]
    public string Password { get; set; }

}
