using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using System.Xml.Linq;
using WebAppRESTAPI.Data;
using WebAppRESTAPI.Function;
using WebAppRESTAPI.Models;
using WebAppRESTAPI.Models.ViewModels;
using WebAppRESTAPI.Repository;
using WebAppRESTAPI.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(service =>
{
    service.ResolveConflictingActions(x => x.First());
    service.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "WebAPI Apps",
        Description = "An ASP.NET Core Web API for test",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        { Name = "Kristanto Saptadi Nugraha", Email = "kristantosaptadi@gmail.com" },
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://login.yourdomain.com";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = configuration["JWT:ValidAudience"],
            ValidIssuer = configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
        };
    });
builder.Services.AddTransient<InitializeAppData>();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var initializeAppData = services.GetRequiredService<InitializeAppData>();

        DbInitializer.Initialize(context, initializeAppData).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
app.UseSwagger();
app.UseSwaggerUI(service =>
{
    service.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    service.RoutePrefix = string.Empty;
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(service =>
    {
        service.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        service.RoutePrefix = string.Empty;
    });
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
