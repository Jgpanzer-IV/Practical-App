using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using IdentityServerAspNetIdentity.Models;
using Microsoft.AspNetCore.Authorization;

namespace IdentityServerAspNetIdentity.Pages.EmailConfirmation
{

    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public IndexModel(ILogger<IndexModel> logger, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
        }

        public void OnGet()
        {
            ViewData["Message"] = "We've sent the email confirmation link to your email, Please check your email and click the confirmation link.";
        }

        public async Task<IActionResult> OnGetConfirmAsync(string id, string token, string ReturnUrl){

            var user = await _userManager.FindByIdAsync(id);

            if (user != null){
                
                var result = await _userManager.ConfirmEmailAsync(user,token);
                
                if(result.Succeeded){
                    // return RedirectPermanent("/Account/Login/Index?ReturnUrl=" + ReturnUrl);
                    return RedirectPermanent(_configuration.GetSection("ClientUrl")["Web"]);
                }

                ViewData["Message"] = "Cannot validate the token. ";
                return Page();
            }else{
                ViewData["Message"] = "Error finding the user using id.";
                return Page();
            }

        }
    }
}