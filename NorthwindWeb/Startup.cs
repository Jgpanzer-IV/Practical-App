using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Routing;

using System.IO;
using Suntrack.Shared;
using Microsoft.EntityFrameworkCore;

namespace NorthwindWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add a service for Razor page and its related services.
            services.AddRazorPages();


            string path = Path.Combine("..","Northwind.db");
            // Add a service to use SQlite
            services.AddDbContext<Northwind>(options => options.UseSqlite($"Data Source={path}"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // If run in development mode. Any unhandled exception will show in browser for details.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }else{
                app.UseHsts();
            }
         
            app.UseRouting();   //Use routing

            app.Use( async (HttpContext context,Func<Task> next) => { 
                
                // Get Endpoint Information from HTTP pipline 
                var requestRouting = context.GetEndpoint() as RouteEndpoint;

                // Display Information for the request
                if (requestRouting != null){
                    Console.WriteLine("---------------------------- {0:h/mm/ss tt} ----------------------------",DateTime.Now);
                    Console.WriteLine("  EndPoint Name : {0}",requestRouting.DisplayName); 
                    Console.WriteLine("  EndPoint Route Pattern : {0}",requestRouting.RoutePattern.RawText);
                    
                }

                if (context.Request.Path == "/bonjour"){
                    // If match this URL path, Then terminate the pipline by retrun a text and 
                    // not call to next delegate
                    await context.Response.WriteAsync("Bonjour Monde");
                    return;
                }

                // We can modify pipline HTTP before call to next delegate
                await next();
                // Also we can modify pipline HTTP after finished the delegate called
                
            });
            

            app.UseHttpsRedirection();  // Redirect from HTTP request to HTTPS.
            app.UseDefaultFiles(); // index.html, default.html, and so on
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                // Mapping any request for Razor page.
                //By convenience it will search for the file in 'pages' folder in ASP.NET COER app
                endpoints.MapRazorPages();

                endpoints.MapGet("/hello", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
