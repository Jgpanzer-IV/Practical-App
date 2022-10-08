using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp.Namespace
{
    public class SignoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // This will tricker both handler.
            // Cookies handler will clear the local cookie.
            // oidc handler will redirect to the identity server to clear its cookie.
            return SignOut("Cookies","oidc");
        }
    }
}
