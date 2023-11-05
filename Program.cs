using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();  
builder.Services.AddSwaggerGen(service =>
{
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

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer("Bearer", options =>
//    {
//        options.Authority = "https://login.yourdomain.com";

//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            //..
//        };
//    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(service => { service.RoutePrefix = string.Empty; });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(service => { 
        service.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        service.RoutePrefix = string.Empty; 
    });
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
