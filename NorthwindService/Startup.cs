using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// EF core
using Microsoft.EntityFrameworkCore;

using Suntrack.Shared;
using NorthwindService.Repository;
// API library
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// Swagger & SwaggerUI
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;

// Configuring Endpoint routing
using Microsoft.AspNetCore.Http;  // for GetEndpoint() extention method
using Microsoft.AspNetCore.Routing;  // for RouteEndpoint

namespace NorthwindService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(action => {
                action.AddPolicy("CommonPolicy", policy => {
                    policy.WithMethods("GET","POST","PUT","DELETE");
                    policy.WithOrigins("http://localhost:4200", "http://localhost:5000"); // Specify only domain of the server, Do not include relative paht.
                });
            });


            string path = System.IO.Path.Combine(Environment.CurrentDirectory,"..","Northwind.db");
            
            // Add DB-context class enable using the specify context class
            services.AddDbContext<Northwind>(option => option.UseSqlite($"Data Source={path}"));

            // Config controller to output Default supported format media type
            // Add Xml media type formatter
            services.AddControllers(option => 
                {
                    Console.WriteLine("Default output Formatter : ");
                    foreach(IOutputFormatter formatter in option.OutputFormatters){
                        
                        var mediaFormatter = formatter as OutputFormatter;

                        if (mediaFormatter == null)
                            Console.WriteLine($" {formatter.GetType().Name}");

                        else{
                            Console.WriteLine(" Formatter [{0}] has Media type : {1}",
                                formatter.GetType().Name,
                                arg1: string.Join(", ",mediaFormatter.SupportedMediaTypes));
                        }
                    }
                }
            )
            .AddXmlDataContractSerializerFormatters()
            .AddXmlSerializerFormatters();

            // Register a scoped dependency service implementation for the repository customers-cache 
            services.AddScoped<ICustomerRepository,CustomerRepository>();
            
            // Register the Swagger generator and configuration document
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc(name:"v1", info:new OpenApiInfo { Title = "NorthwindService", Version = "v1" });
            });
            
            services.AddHealthChecks().AddDbContextCheck<Northwind>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NorthwindService API v.1");

                        c.SupportedSubmitMethods(new[]{
                            SubmitMethod.Get, SubmitMethod.Post,
                            SubmitMethod.Put, SubmitMethod.Delete
                        });
                    });
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            

            // Feature cross-origin for security reason
            app.UseCors("CommonPolicy");

            // Route for heal check feature
            app.UseHealthChecks(path: "/apiheal");

            // Add a custom Route to display the request
            app.Use(next => (context) => {
                var endpoint = context.GetEndpoint();
                if (endpoint != null){
                    Console.WriteLine("\tName : {0}\n\tRoute : {1}\n\tMetadata : {2} \n-------------\n",
                        arg0: endpoint.DisplayName,
                        arg1: (endpoint as RouteEndpoint)?.RoutePattern,
                        arg2: string.Join(",", endpoint.Metadata));
                }

                // Pass the context to next middleware in pipline
                return next(context);

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
