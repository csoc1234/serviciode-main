using APILogs.Application.Interface;
using APILogs.Application.Main;
using APILogs.Application.Mapping;
using APILogs.Domain.Core;
using APILogs.Domain.Interface;
using APILogs.Infrastucture.Database;
using APILogs.Infrastucture.Interface;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//Health Check
builder.Services.AddHealthChecks()
    .AddMongoDb(builder.Configuration["MongoDB:ConnectionURI"]);

builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = $"v{Assembly.GetExecutingAssembly().GetName().Version}",
            Title = "API Logs - " + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
            Description = "Registro de Logs en MongoDB.",
        });
    });

//Application
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<ICreate, Create>();
//Domain
builder.Services.AddScoped<IContextDomain, ContextDomain>();
//Infraestructure
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<IDbContextMongo, DbContextMongo>();

WebApplication app = builder.Build();

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
    options.DocumentTitle = "API Logs";
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
