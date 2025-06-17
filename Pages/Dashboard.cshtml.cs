using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorCrudApp.Pages;

public class DashboardModel : PageModel
{

    public IActionResult OnGet()
    {
        if (User.Identity == null || !User.Identity.IsAuthenticated)
        {
            return RedirectToPage("/Auth/Login");
        }
        return Page();
    }

}