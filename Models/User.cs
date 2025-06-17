
using System.ComponentModel.DataAnnotations;

namespace RazorCrudApp.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Name is too long")]
    [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Only letters and white space allowed")]
    [Display(Name = "Name")]
    public required string Name { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public required string Email { get; set; }

    [Required]
    public required string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Deleted { get; set; }
}