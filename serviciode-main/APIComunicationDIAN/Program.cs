using APIComunicationDIAN.Application.Interface;
using APIComunicationDIAN.Application.Main;
using APIComunicationDIAN.Application.Mapping;
using APIComunicationDIAN.Domain.Core;
using APIComunicationDIAN.Domain.Interface;
using APIComunicationDIAN.Infraestructure.Cache;
using APIComunicationDIAN.Infraestructure.ClientSoap;
using APIComunicationDIAN.Infraestructure.DianConnection;
using APIComunicationDIAN.Infraestructure.Interface;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using System.Reflection;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxConcurrentConnections = 1000;
});

//Health Check
builder.Services.AddHealthChecks();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MappingProfile));
//Application
builder.Services.AddScoped<IDianStatus, DianStatus>();
builder.Services.AddScoped<IDianSend, DianSend>();
builder.Services.AddScoped<IDianStatusEnable, DianStatusEnable>();
//Domain
builder.Services.AddScoped<IStatusDomain, StatusDomain>();
builder.Services.AddScoped<ISendDomain, SendDomain>();
//Infraestructure
builder.Services.AddSingleton<IDianClient, DianClient>();
builder.Services.AddSingleton<IGetStatus, GetStatus>();
builder.Services.AddSingleton<ISendTestSetAsync, SendTestSetAsync>();
builder.Services.AddSingleton<ISendBillSync, SendBillSync>();
builder.Services.AddSingleton<IGetStatusZip, GetStatusZip>();

builder.Services.AddSingleton<ICaching, Caching>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = $"v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}",
            Title = "API Comunication DIAN - " + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
            Description = "Web API to generate UBL.",
        });
        string? xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        string? xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
        c.EnableAnnotations();
    });

WebApplication? app = builder.Build();

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
    options.DocumentTitle = "API Comunication DIAN";
});

//HealthCheck middleware
app.UseHealthChecks("/hc", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
