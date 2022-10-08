using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add swagger gen UI provider and config the display text for security information
builder.Services.AddSwaggerGen(config => {

    // Add Documentation of the admin server
    config.SwaggerDoc("v1", new OpenApiInfo(){

        Title = "Example Protecting API",
        Version = "v1",
        Description = "An example api to perform authorization with Duende identity server",
        TermsOfService = new Uri("https://localhost:7168/services"),

        Contact = new OpenApiContact(){
            Name = "Karnchai Sakkarnjna",
            Email = "sakkarnjana@gmail.com",
            Url = new Uri("https://www.facebook.com/profile.php?id=100034009912914")
        }
    });
    
    // Add documentation Security definition 
    config.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme(){
        Name = "Authorization",
        Description = @"Enter the following : Brearer [token]",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Enable security requirement in swagger gen
    config.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

// Add the authentication system to the ASP.NET core Service which are done the following task.
//      - Find and parse a JWT sent with incoming request as an Authorization: Bearer in the http header.
//      - Validate the JWT's signature to ensure that it was issued by identity server.
//      - Validate the JWT is not expired.
builder.Services
    .AddAuthentication("Bearer")        // - Setting scheme name 'Bearer' to be used as a default scheme to be authenticate
    .AddJwtBearer("Bearer",config => { // - Add Jwt authentication handler named as 'Bearer'
    
    //  - Set the authority to the address of identity server ot define the Owner token
        config.Authority = "https://localhost:5001";

    //  - Set validate audience to 'false' because this senario only use the api scope only. 
        config.TokenValidationParameters = new TokenValidationParameters{
            ValidateAudience = false
        };
    });


//---------------------------------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

// adds the authentication middleware to the pipeline so authentication will be performed automatically on every call into the host.
app.UseAuthentication();

// adds the authorization middleware to make sure our API endpoint cannot be accessed by anonymous clients.
app.UseAuthorization();

app.MapControllers();

app.Run();
