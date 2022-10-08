using IdentityAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configue Application database context
builder.Services.AddDbContext<ApplicationDBContext>(option => {
    option.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("Default"));
});

// Configure to use ASP.Net core Identity and specify the data store for the system to completed dependency injection in term of identity
builder.Services.AddIdentity<IdentityUser,IdentityRole>(configure => {
    configure.Password.RequiredLength = 8;
    configure.Password.RequireLowercase = true;
    configure.Password.RequireUppercase = true;
    configure.Password.RequireDigit = true;

    configure.Lockout.MaxFailedAccessAttempts = 4;
    configure.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

    configure.User.RequireUniqueEmail = true;
    configure.SignIn.RequireConfirmedEmail = true;
})
.AddEntityFrameworkStores<ApplicationDBContext>()
.AddDefaultTokenProviders(); // Handler for generating jwt token.  




// Configure the application cookie but not add all the cookie authentication handler
builder.Services.ConfigureApplicationCookie(option => {
    option.LoginPath = "/Account/Login";
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.ExpireTimeSpan = TimeSpan.FromDays(12);
});











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

app.MapRazorPages();

app.Run();
