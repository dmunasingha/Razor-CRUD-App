using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace RazorCrudApp.Pages;

public class IndexModel : PageModel
{
    public IActionResult OnGet()
    {
        if (User.Identity is null || !User.Identity.IsAuthenticated)
        {
            return RedirectToPage("/Dashboard");
        }
        return RedirectToPage("/Auth/Login");
    }
}
