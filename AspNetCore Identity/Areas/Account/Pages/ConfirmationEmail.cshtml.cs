using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

namespace IdentityAPI.Areas.Account.ConfirmationEmail
{
    public class ConfirmationEmailModel : PageModel
    {
        private readonly ILogger<ConfirmationEmailModel> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public ConfirmationEmailModel(ILogger<ConfirmationEmailModel> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public void OnGet(){
            ViewData["Message"] = "We have sent email confirmation to you, Please check your email and click the link to enable your account.";
        }

        public async Task<IActionResult> OnGetConfirmAsync(string id, string token)
        {
            // Retrieve user by id
            var user = await _userManager.FindByIdAsync(id);
            
            // if the user is exists 
            if (user != null){
                
                // Generate the token by the user information and compair with the incoming token.
                var result = await _userManager.ConfirmEmailAsync(user,token);

                // If it success (the same value token)
                if (result.Succeeded){
                    
                    // Return to the login page
                    return RedirectToPage("Login",new {areas = "Account"});
                }
                
                // if fail to validate the token, then return the page and show Message error
                ViewData["Message"] = "Fail to validate the token.";
                return Page();
            }

            // if the user dose not exists
            else{

                // Return to register page
                return RedirectToPagePermanent("Register");

            }
        }

        
    }
}