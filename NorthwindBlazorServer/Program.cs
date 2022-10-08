using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NorthwindBlazorServer.Data;
using Microsoft.EntityFrameworkCore;
using Suntrack.Shared;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>(); // Add dependency injection to the container.
builder.Services.AddTransient<ICustomerRepository,CustomerService>(); // Add local dependency injection to blazor component.

string path = Path.Combine("..","Northwind.db");
builder.Services.AddDbContext<Northwind>(connection => connection.UseSqlite($"Data Source={path}")); // Add Dbcontext dependency to the container
//------------------------------------------

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

// End point routing
app.MapBlazorHub(); // accept request for incoming signalR connection to blazor component   
app.MapFallbackToPage("/_Host"); // accept request for initial web page

app.Run();
