using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SGE.UI.Components;
using SGE.Repositorios;
using SGE.Aplicacion;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;

// Crear una instancia de DbContextOptions para UserAccountContext
var connectionString = "Data Source=UserAccount.sqlite";
var options = new DbContextOptionsBuilder<UserAccountContext>()
    .UseSqlite(connectionString)
    .Options;

// Inicializar la base de datos si es necesario
ProyectoSqlite.Inicializar(options);

// Usar el contexto para mostrar los datos de UserAccount
using (var context = new UserAccountContext(options))
{
    Console.WriteLine("-- Tabla UserAccount --");
    foreach (var a in context.UserAccount)
    {
        Console.WriteLine($"{a.Id} {a.UserName}");
    }
}

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios y middleware
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<IServicioHash, ServicioHash>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/access-denied";
    });

builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

// Agregar el DbContext de UserAccountContext con la configuración de SQLite
builder.Services.AddDbContext<UserAccountContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
