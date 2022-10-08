using Authentication_and_Authorization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization; // for [Authorize] attribute

namespace Authentication_and_Authorization.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secured() {

            return View();
        }

        /// <summary>
        ///  The Authorize's role attribute will check the claim 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public IActionResult TopSecured() {

            return View();
        }

        [HttpGet("/login")]
        public IActionResult Login(string returnUrl) {
            ViewData["existsUrl"] = returnUrl;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync();
            return RedirectToAction(actionName: "Index") ;
        }

        [HttpPost("/validation")]
        public async Task<IActionResult> Validation(string id,string password,string returnUrl) {
            // Checking for id and password to indentify user account
            if (id == "van" && password == "van123") {

                // Authentication 

                // 1. Create claim which is descript the user
                var claims = new List<Claim>()
                {
                    new Claim("id",id),
                    new Claim(ClaimTypes.NameIdentifier,id),
                    new Claim(ClaimTypes.Role,"ad")
                };
                // 2. Create identity which represent the user's identity
                ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
               
                // 3. Create certificate that indicate the user has authenticated (aka.ticket).
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
               
                // 4. send the ticket to the http request 
                await HttpContext.SignInAsync(principal);
                
                // 5. redirect http route to the secured page or resource
                return Redirect(returnUrl);
            }
            // redirec to login action with route value specified in 'route name' = {value} 
            return RedirectToAction(actionName:"Login", new {returnUrl = returnUrl});
        }



        [HttpGet("/denied")]
        public IActionResult Denied() {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
