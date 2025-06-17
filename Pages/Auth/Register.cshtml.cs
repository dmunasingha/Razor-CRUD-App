using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrudApp.Data;
using RazorCrudApp.Models;

namespace RazorCrudApp.Pages.Auth;

public class RegisterModel : PageModel
{

    private readonly AppDbContext _db;
    public RegisterModel(AppDbContext db) => _db = db;

    [TempData]
    public string ToastMessage { get; set; }
    public string ErrorMessage { get; set; } = "";

    [TempData]
    public string ToastType { get; set; }
    [BindProperty] public string Name { get; set; } = "";
    [BindProperty] public string Email { get; set; } = "";
    [BindProperty] public string Password { get; set; } = "";


    public IActionResult OnGet()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToPage("/Dashboard");
        }
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        var isExistingUser = _db.Users.FirstOrDefault(u => u.Email == Email);
        if (isExistingUser != null)
        {
            ErrorMessage = "User already exists, please login";
            return Page();
        }

        var hashed = BCrypt.Net.BCrypt.HashPassword(Password);
        var user = new User { Name = Name, Email = Email, PasswordHash = hashed, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };

        _db.Users.Add(user);
        _db.SaveChanges();

        ToastMessage = "Registration successful!";
        ToastType = "success";

        return RedirectToPage("/Auth/Login");
    }
}