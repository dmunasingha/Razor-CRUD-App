using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorCrudApp.Pages.Auth;

public class LogoutModel : PageModel
{
    public async Task<IActionResult> OnPost()
    {
        if (User.Identity != null || User.Identity.IsAuthenticated)
        {
            await HttpContext.SignOutAsync("MyCookieAuth");

            TempData["ToastMessage"] = "You have been logged out.";
            TempData["ToastType"] = "success";

            return RedirectToPage("/Auth/Login");
        }

        return Page();
    }
}
