using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{

/// <summary>
///         In oidc potocal there is a Identity resource which is represent identity of user claim such as id, email, name, ect.
///     User can required claim
///     It typically protected by the credencial either in web-server it self or in identity-server (aka Authentication provider). 
/// </summary>
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };


/// <summary>
///     The api scope is the resource that need to be protected from token provided by identity server,
/// Because it will be required from any user to access to the resource.
/// 
///     These definition apiScope is represent the 'scope of access' for the resource in API-server, It typically use to
/// communicate between server to server
/// </summary>
    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope(name: "identity", displayName: "The scope of access identity of the user from API"),
                new ApiScope(name: "retrieve", displayName: "Retrieve any resource to the client")
            };


/// <summary>
/// Client in identity server is pice of software that needed services for security from Identity server.
/// This client definition contains list of defined client, Each client have the following componet
///     1. A client Id, which identifies the application to identity server so that it know which client is trying to contect to this identity server  
///     2. A client Secret, Which is represent a password for the client that trying to contecting.
///     3. The allowed scope, The list of defined scopes that client will be allowed use.
/// </summary>
    public static IEnumerable<Client> Clients =>
        new Client[] 
            { 
                // Machine to machine communication.
                new Client{
                    ClientId = "general",
                    
                    // If there is no interactive user interface or UI, use the clientID/secret  
                    // This is definitive how the client interact with this identity server.
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    
                    // Secret for authentication
                    ClientSecrets = 
                    {
                        new Secret("secretVan2001".Sha256())
                    },

                    // Define which scope the client will be allowed to access.
                    // The scope here must match to the defined scope in the scope api.
                    AllowedScopes = {"identity", "retrieve"}
                },

                // Interactive ASP.NET core web app
                new Client{
                    
                    ClientId = "web",
                    
                    ClientSecrets = 
                    {
                        new Secret("secretWeb".Sha256())
                    },
                    
                    AllowedGrantTypes = GrantTypes.Code,

                    // The address where to redirect to afer login.
                    RedirectUris = {"https://localhost:7133/signin-oidc"},

                    // The address where to redirect to afer logout.
                    PostLogoutRedirectUris = {"https://localhost:7133/signout-callback-oidc"},

                    // Enable support for refresh token
                    AllowOfflineAccess = true,

                    // Allowed scope or resource for this client
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "identity"
                    }

                    
                }

            };
}