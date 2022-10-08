using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace IdentityAPI.Areas.Account.Login
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly SignInManager<IdentityUser> _signInManager; 
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        
        [BindProperty]
        public CredentialUser CredentialUser {get;set;} = new();

        public LoginModel(
            ILogger<LoginModel> logger,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IConfiguration configuration)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        public void OnGet()
        {}

        public async Task<IActionResult> OnPostAsync()
        {
            // Find user using user name
            var user = await _userManager.FindByNameAsync(CredentialUser.UserName);
            if (user == null){
                ViewData["Message"] = "There is no specified user name.";
                return Page();
            }

            // Sign in the user by credencial informarion
            var result = await _signInManager.PasswordSignInAsync(
                CredentialUser.UserName,
                CredentialUser.Password,
                CredentialUser.RememberMe,
                false);

            if(result.Succeeded){
                return RedirectToPage("/Index", new {id = user.Id});
                //return RedirectPermanent(_configuration.GetSection("ServerUrl")["ClientWeb"]);
            }
            else{
                ViewData["Message"] = "Sign in fail, Please check your password or may be you are not enable your account.";
                return Page();
            }
        }
    }


    public class CredentialUser{
        
        [Required (ErrorMessage = "Please enter your email address.")]
        public string UserName {get;set;} = string.Empty;

        [Required (ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        public string Password {get;set;} = string.Empty;
        
        public bool RememberMe {get;set;} = false;
    }
}