using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityAPI.Areas.Account.Register
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;
        private readonly UserManager<IdentityUser> _userManager; 

        [BindProperty]
        public UserRegistering UserSignUp {get;set;} = new();
        
        public RegisterModel(ILogger<RegisterModel> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public void OnGet()
        { }

        public async Task<IActionResult> OnPostAsync()
        {
            // Create identity user from User sign up information
            IdentityUser newUser = new(){
                UserName = UserSignUp.UserName,
                Email = UserSignUp.Email,
            };

            // Register the new user into identity data store 
            var result = await _userManager.CreateAsync(newUser,UserSignUp.Password);
            
            
            if (result.Succeeded){
                // generate confirm email token 
                string confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                string confirmationUrl = Url.PageLink("ConfirmationEmail",pageHandler: "Confirm",values: new{id = newUser.Id, token = confirmationToken}) ?? "Cannot generate confirmation link, Please contect the admin server.";
                
                // Send email confirmation to the user.



                return RedirectPermanent(confirmationUrl);
            }

            // Server side validation
            else{
                
                foreach(var error in result.Errors){
                    this.ModelState.AddModelError("Register : "+error.Code,error.Description);
                }
                return Page();
            }

        }

    }

    public class UserRegistering{
        
        [Required(ErrorMessage = "Please enter your User nane")]
        [Display(Name = "User name")]
        public string UserName {get;set;} = string.Empty;
        
        [Required(ErrorMessage = "Please enter your email")]
        public string Email {get;set;} = string.Empty;

        [Required]
        [DataType(DataType.Currency)]
        public decimal InitialSaving {get;set;}
        
        [Display(Name = "Job title")]
        public string? JobTitle {get;set;}   

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string? Password {get;set;}
        
        [Required]
        [Compare(nameof(Password), ErrorMessage = "The Confirm password field not match to the password field")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword {get;set;}

    }
}