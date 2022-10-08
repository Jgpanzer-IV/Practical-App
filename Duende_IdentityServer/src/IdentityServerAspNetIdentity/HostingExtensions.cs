using Duende.IdentityServer;
using IdentityServerAspNetIdentity.Data;
using IdentityServerAspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IdentityServerAspNetIdentity;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();

        // The first two adding services are done to configure asp.net core Identity
            // Add Database service for supporting the DbContext.
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Add service for Asp.Net core identity data store .
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                config => {
                    config.SignIn.RequireConfirmedEmail = true;
                    config.User.RequireUniqueEmail = true;
                }
            )
                .AddEntityFrameworkStores<ApplicationDbContext>() // Specify the DbContext to store the user database.
                .AddDefaultTokenProviders(); // Generator token for any operation

        // Add services to support for IdentityServer and configure in-menmory style for storing resources.
        builder.Services
            .AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/
                options.EmitStaticAudienceClaim = true;
            })
            // Adding in-memory style for storing resource, Those are sourses form 'Config' class.
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryClients(Config.Clients)
            // This is Adding the integration layer to allow identityServer to access the user data for the asp.net core identity database. 
            // This is nessary when identityServer must add claim from users into tokens
            .AddAspNetIdentity<ApplicationUser>()
            // Add custom profile service that responsible about claim principal.
            .AddProfileService<CustomProfileService>();  

        
        // Add google authentication handler service and configure its setting.
        builder.Services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                // register your IdentityServer with Google at https://console.developers.google.com
                // enable the Google+ API
                // set the redirect URI to https://localhost:5001/signin-google
                options.ClientId = "copy client ID from Google here";
                options.ClientSecret = "copy client secret from Google here";
            });

        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthorization();
        
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}