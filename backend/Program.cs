using MyUniversityAPP.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Mantém PascalCase
});

//Obtem connectionStringconnectionString
string? connectionString = builder.Configuration["ConnectionString"] ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);

var app = builder.Build();

// Configurar o pipeline de requisição HTTP.
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
app.UseStaticFiles(); // Para servir os arquivos estáticos do Angular.


app.UseRouting(); // Configura o roteamento.


app.UseAuthorization();

app.MapControllers();

// Servir o arquivo index.html para todas as rotas não API
app.MapFallbackToFile("index.html");

app.Run();
