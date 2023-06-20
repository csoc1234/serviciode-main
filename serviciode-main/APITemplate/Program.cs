using APITemplate.Application.Interface;
using APITemplate.Application.Main;
using APITemplate.Application.Mapping;
using APITemplate.Domain.Core;
using APITemplate.Domain.Interface;
using APITemplate.Infraestructure.Database;
using APITemplate.Infraestructure.Interface;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//Health Check
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"],
                    name: "BD de Factoring",
                    tags: new string[] { "Database" });

// Add services to the container.

builder.Services.AddAutoMapper(typeof(MappingProfile));
//Application
builder.Services.AddScoped<ITemplateSave, TemplateSave>();

//Domain
builder.Services.AddScoped<ICreateDomain, CreateDomain>();

//Infraestructure
builder.Services.AddScoped<ITemplateDbContext, TemplateDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
     c =>
     {
         c.SwaggerDoc("v1", new OpenApiInfo
         {
             Version = $"v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}",
             Title = "API Template  - " + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
             Description = "Permite la administracion de templates",
         });
         c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
         c.AddSecurityDefinition("Authorization", new OpenApiSecurityScheme
         {
             Description = "Authorization by API key.",
             In = ParameterLocation.Header,
             Type = SecuritySchemeType.ApiKey,
             Name = "Authorization"
         });
         c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {{
                new OpenApiSecurityScheme
        {       Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                Id = "Authorization" }},
                new List<string>()
            }});
     });

//Auth Bearer Jwt 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie()
    .AddJwtBearer(jwtBearerOptions =>
    {
        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateActor = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidAudience = builder.Configuration["Token:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"]))
        };
    });

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
    options.DocumentTitle = "API Template";
});

//HealthCheck middleware
app.UseHealthChecks("/hc", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseAuthorization();

app.MapControllers();

app.Run();
