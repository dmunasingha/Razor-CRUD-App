using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorCrudApp.Pages.Users;

[Authorize(AuthenticationSchemes = "MyCookieAuth")]
public class UserModel : PageModel
{
    [TempData]
    public string ToastMessage { get; set; }

    [TempData]
    public string ToastType { get; set; }

    public void OnGet()
    {
        // TODO: Implement this method
    }
}