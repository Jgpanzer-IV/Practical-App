using MQTT_WebClient.Database;
using MQTT_WebClient.Services.Interfaces;
using MQTT_WebClient.Services.Implementations;
using System.Text;
using Microsoft.EntityFrameworkCore;

using MQTTnet;
using MQTTnet.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("MessageSqlite")));

var optionDbBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
optionDbBuilder.UseSqlite(builder.Configuration.GetConnectionString("MessageSqlite"));
//builder.Services.AddTransient<ISubscriberRepository,SubscriberRepository>();

ISubscribeProcessor processor = new SubscribeProcessor(optionDbBuilder.Options);
builder.Services.AddSingleton<ISubscribeProcessor>(processor);
await processor.InitializationAsync("broker.hivemq.com",1883);






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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
