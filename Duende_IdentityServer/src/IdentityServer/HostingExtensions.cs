using Serilog;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;

namespace IdentityServer;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // uncomment if you want to add a UI
        builder.Services.AddRazorPages();

        /*
            builder.Services.AddIdentityServer(options =>
                {
                    // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
                    options.EmitStaticAudienceClaim = true;
                })
                .AddInMemoryIdentityResources(Config.IdentityResources) // Register the identity resource
                .AddInMemoryApiScopes(Config.ApiScopes) // Register the api resource
                .AddInMemoryClients(Config.Clients) // Register the client defined
                .AddTestUsers(TestUsers.Users); // Register a in-memory test user
        */


        // Using Entityframework core to store configuration as well as resource and client.
            
            // Get assembly's name where the migration are maintained for this context or server
            string migrationAssembly = typeof(Program).Assembly.GetName().Name;

            // Connection string for duende ef store 
            const string connectionString = @"Data Source=Duende.IdentityServer.Quickstart.EntityFramework.db";

            builder.Services.AddIdentityServer()

                // Add Configuration data store resource such as client, resource and scopes. 
                .AddConfigurationStore(config => {
                    config.ConfigureDbContext = b => b.UseSqlite(
                        // Set connection string to Database provider.
                        connectionString, 

                        // Configure the assembly where the migration are maintained.
                        // The call to MigrationAssembly() tells EntityFramework that the host project will contain the migration
                        // This is necessary sicn the host project is in difference assembly then one that contain the Dbcontext.
                        sqlite => sqlite.MigrationsAssembly(migrationAssembly)); 
                })

                //Add Operational data store such as authorization code and refresh tokens  
                .AddOperationalStore( config => {
                    config.ConfigureDbContext = b => b.UseSqlite(
                        connectionString,
                        sql => sql.MigrationsAssembly(migrationAssembly));
                })

                .AddTestUsers(TestUsers.Users);






        return builder.Build();
    }
    
    /// <summary>
    /// This is a convenient way to seed the database
    /// </summary>
    /// <param name="app"></param>
    private static void InitializeDatabase(IApplicationBuilder app){

        using(var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()){

            serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

            var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

            context.Database.Migrate();

            // Check for client definition 
            if(!context.Clients.Any()){
                
                // loop for element in Client definition to add to the Client table in Dbcontext. 
                foreach(var client in Config.Clients){
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }


            if(!context.IdentityResources.Any()){
                
                foreach(var identity in Config.IdentityResources){
                    context.IdentityResources.Add(identity.ToEntity());
                }
                context.SaveChanges();
            }

            if(!context.ApiScopes.Any()){

                foreach(var scope in Config.ApiScopes){
                    context.ApiScopes.Add(scope.ToEntity());
                }
                context.SaveChanges();
            }

        }

    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        InitializeDatabase(app);

        // uncomment if you want to add a UI
        app.UseStaticFiles();
        app.UseRouting();
            
        app.UseIdentityServer();

        // uncomment if you want to add a UI
        app.UseAuthorization();
        app.MapRazorPages().RequireAuthorization();

        return app;
    }
}
