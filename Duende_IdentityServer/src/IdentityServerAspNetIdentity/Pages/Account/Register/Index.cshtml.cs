using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using IdentityServerAspNetIdentity.Models;


#nullable enable

namespace IdentityServerAspNetIdentity.Pages.Register
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class IndexModel : PageModel
    {

        [BindProperty]
        public RegisterCredencial RegisterCredencial {get;set;} = new();

        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl {get;set;}

        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public IndexModel(ILogger<IndexModel> logger, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public void OnGet()
        {

        }


        public async Task<IActionResult> OnPostAsync(){

            if (!ModelState.IsValid){
                return Page();
            }

            var User = new ApplicationUser(){
                UserName = RegisterCredencial.UserName,
                Email = RegisterCredencial.Email
            };

            var result = await _userManager.CreateAsync(User,RegisterCredencial.Password);

            if (result.Succeeded){
                string confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(User);
                string? confirmationLink = Url.PageLink("/Account/Email/Index",pageHandler: "Confirm",values: new {id = User.Id , token = confirmationToken, ReturnUrl = ReturnUrl});

                // Send the confirm link to the client, Once the client click the link, It will redirect the client to confirm email page.

                // Redirect to confirm automatically
                if(!string.IsNullOrEmpty(confirmationLink))
                    return RedirectPermanent(confirmationLink);
                else
                    return Page();
            }
            else{
                foreach(var error in result.Errors){
                    ModelState.AddModelError(error.Code ,error.Description);
                }
                return Page();
            }

        }



    }

    public class RegisterCredencial{

        [Required(ErrorMessage = "Please enter your username.")]
        [StringLength(24,ErrorMessage = "String length must below 24 charactor.")]
        public string UserName {get;set;} = string.Empty;

        [Required(ErrorMessage = "Plase enter your email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email {get;set;} = string.Empty;

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        public string Password {get;set;} = string.Empty;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPass {get;set;} = string.Empty;
    }

}