using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrudApp.Data;

namespace RazorCrudApp.Pages.Auth;

public class LoginModel : PageModel
{

    private readonly AppDbContext _db;

    public LoginModel(AppDbContext db) => _db = db;

    [TempData]
    public string ToastMessage { get; set; }

    [TempData]
    public string ToastType { get; set; }

    [BindProperty] public string Email { get; set; }
    [BindProperty] public string Password { get; set; }

    public string ErrorMessage { get; set; } = "";

    public IActionResult OnGet()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToPage("/Dashboard");
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {

        if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
        {
            ErrorMessage = "Email and password are required.";
            return Page();
        }

        var user = _db.Users.FirstOrDefault(u => u.Email == Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(Password, user.PasswordHash))
        {
            ErrorMessage = "Invalid email or password.";
            return Page();
        }

        // Create claims and identity
        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, user.Name),
            new (ClaimTypes.Email, user.Email),
            new (ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var identity = new ClaimsIdentity(claims, "MyCookieAuth");
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("MyCookieAuth", principal);

        ToastMessage = "Login successful!";
        ToastType = "success";

        return RedirectToPage("/Dashboard");
    }
}