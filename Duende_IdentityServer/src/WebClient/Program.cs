using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

builder.Services.AddAuthentication( 
    option => {
        option.DefaultScheme = "Cookies"; // This scheme will be used when the client already have the cookie to authenticate.
        option.DefaultChallengeScheme = "oidc"; // this scheme will be used when unauthenticate user must login.
    })
    .AddCookie("Cookies") // Add cookie authentication handler and named scheme 'Cookies'.
    .AddOpenIdConnect("oidc",  // Add OpenID connect Authentication handler and named scheme 'oidc' to perform the openid connect potocal.
        option => { // Configure openID connect potocal that be begins by the challenge scheme.

            // The authority use when making OpenIdConnect call.
            // This indicate where trusted token service is located.
            option.Authority = "https://localhost:5001";

            // Client credencial to indentify the client
            option.ClientId = "web";
            option.ClientSecret = "secretWeb";
            option.ResponseType = "code";
            
            // Manage require scope 
            option.Scope.Clear();
            option.Scope.Add("openid");
            option.Scope.Add("profile");
            option.Scope.Add("identity"); // Api scope
            option.Scope.Add("job"); // Request job scope (custom identity scope)
            option.Scope.Add("offline_access"); // Request access token.
            option.GetClaimsFromUserInfoEndpoint = true; // Ensure that the client will get every requested claim
            
            // Select the value using json user data's key and create it as a claim.
            // The name of both value (json user data key and claim) must be the same name.
            option.ClaimActions.MapUniqueJsonKey("Job_Title","Job_Title"); 

            // SaveTokens will indicate the access and refresh token will be stored in the cookie.
            option.SaveTokens = true;
        });






// ------------------------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// To ensure that entire application will need authenticate user.
app.MapRazorPages().RequireAuthorization();

app.Run();
