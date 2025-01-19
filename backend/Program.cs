using MyUniversityAPP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;

// WebApplicationBuilder
var builder = WebApplication.CreateBuilder(args);

// Configura��o do Application Insights
string telemetryKey = builder.Environment.IsDevelopment()
    ? builder.Configuration["ApplicationInsights:InstrumentationKey"] // Para desenvolvimento
    : Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY"); // Para produ��o

builder.Services.AddApplicationInsightsTelemetry(telemetryKey);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Mant�m PascalCase
});

//Obtem connectionStringconnectionString
string? connectionString = builder.Configuration["ConnectionString"] ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);

// WebApplication
var app = builder.Build();


// Configurar o pipeline de requisi��o HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "text/plain";

        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        if (exceptionHandlerPathFeature?.Error != null)
        {
            // Log the exception
            var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogError(exceptionHandlerPathFeature.Error, "Unhandled exception");

            await context.Response.WriteAsync("An unexpected error occurred!");
        }
    });
});

app.UseHttpsRedirection();
app.UseStaticFiles(); // Para servir os arquivos est�ticos do Angular.


app.UseRouting(); // Configura o roteamento.


app.UseAuthorization();

app.MapControllers();

// Servir o arquivo index.html para todas as rotas n�o API
app.MapFallbackToFile("index.html");

app.Run();
