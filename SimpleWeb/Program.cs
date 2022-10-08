using System;
using SimpleWeb;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => {

    webBuilder.Configure(app => 
    {
        app.UseHttpsRedirection();
        app.Run(context =>
            //context.Response.WriteAsync("Hello World Console Web"),
            context.Response.WriteAsync(Calculator.getTimeTable())
            
        );
    });

}).Build().Run();

