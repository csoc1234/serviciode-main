using APIGenerateUBL.Application.Interface;
using APIGenerateUBL.Application.Main;
using APIGenerateUBL.Domain.Core;
using APIGenerateUBL.Domain.DocumentFill;
using APIGenerateUBL.Domain.Interface;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Reflection;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

//Health Check
builder.Services.AddHealthChecks();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped<IBuildXml, BuildXml>();
builder.Services.AddScoped<ICreateDomain, CreateDomain>();
builder.Services.AddScoped<IDocumentUbl, DocumentUbl>();
builder.Services.AddScoped<IInvoiceFill, InvoiceFill>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = $"v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}",
            Title = "API Generate UBL - " + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
            Description = "Web API to generate UBL.",
        });
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
    options.DocumentTitle = "API Generate UBL";
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
