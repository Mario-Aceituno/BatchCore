using LotesApp.Frontend;
using LotesApp.Models;
using LotesApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Servicios de Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configuración de LotesConfig desde appsettings.json 
builder.Services.Configure<LotesConfig>(
    builder.Configuration.GetSection("LotesConfig"));

// Registro del servicio de lotes
builder.Services.AddScoped<LoteService>();

builder.Services.AddScoped<CronogramaService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
