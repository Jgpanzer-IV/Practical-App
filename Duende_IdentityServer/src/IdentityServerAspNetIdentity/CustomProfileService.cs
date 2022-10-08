using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServerAspNetIdentity.Models;

using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Models;

namespace IdentityServerAspNetIdentity
{
    public class CustomProfileService : ProfileService<ApplicationUser>
    {
        public CustomProfileService(
            UserManager<ApplicationUser> userManager,
            IUserClaimsPrincipalFactory<ApplicationUser> claimFactory) : base(userManager,claimFactory)
        {}

        protected override async Task GetProfileDataAsync(ProfileDataRequestContext context, ApplicationUser user){
            
            // Find principal (user) from database using the 'ApplicationUser' object.
            var principal = await GetUserClaimsAsync(user);

            // Get primary claim of the principal which is the identity (id) of the pricipal (user).
            var id = (ClaimsIdentity) principal.Identity;
            
            // If the value in the user entity is not empty, Then assign into the claim principal. 
            if (!string.IsNullOrEmpty(user.JobTitle)){
                // Add a new claim named it as Job_Title.
                id.AddClaim(new Claim("Job_Title",user.JobTitle));
            }

            context.AddRequestedClaims(principal.Claims);

        }
    }
}