using HealthChecks.UI.Client;
using Login.Application.Interface;
using Login.Domain.Interface;
using Login.Infrastructure.DbContextData;
using Login.Infrastructure.Interface;
using Login.Infrastructure.Logger;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TFHKA.Login.Application.Main;
using TFHKA.Login.Domain.Core;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Health Check
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"],
        name: "BD de Factoring",
        tags: new string[] { "Database" });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = $"v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}",
        Title = "API Login Internal - " + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
        Description = "Permite Autenticarse",
    });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

builder.Services.AddDbContext<FacturacionDbContext>(options =>
                  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Disable Validation in Request
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

//Application
builder.Services.AddScoped<ILoginUser, LoginUser>();

//Domain
builder.Services.AddScoped<IUserDomain, UserDomain>();
builder.Services.AddScoped<ITokenJwt, TokenJwt>();

//Infraestructure
builder.Services.AddScoped<IFacturacionDbContext, FacturacionDbContext>();
builder.Services.AddScoped<ILogAzure, LogAzure>();

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger(c =>
{
    c.SerializeAsV2 = true;
});
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
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
