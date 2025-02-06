namespace StudentAdvisor.Models;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using StudentAdvisor.Models;

public class Register : IdentityUser
{
    [Required(ErrorMessage = "First Name is required.")]
    [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";  // Optional helper property
}
