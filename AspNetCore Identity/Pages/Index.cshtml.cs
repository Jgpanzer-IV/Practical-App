using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace IdentityAPI.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, UserManager<IdentityUser> userManager )
        {
            _logger = logger;
            _configuration = configuration;
            _userManager = userManager;
        }

        public void OnGet()
        {}
        
    }
}