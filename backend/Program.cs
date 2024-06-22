using MyUniversityAPP.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte para controllers (não precisamos de ControllersWithViews pois você está servindo uma SPA)
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Mantém PascalCase
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configurar o pipeline de requisição HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Para servir os arquivos estáticos do Angular.

app.UseRouting(); // Configura o roteamento.

app.UseAuthorization();

// Configura os endpoints para usar os controllers
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Servir o arquivo index.html para todas as rotas não API
//app.MapFallbackToFile("index.html");

app.Run();
