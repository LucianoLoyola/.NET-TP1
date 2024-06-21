using Microsoft.AspNetCore.Authentication.Cookies;
using SGE.UI.Components;

using SGE.Repositorios;
using SGE.Aplicacion;

ProyectoSqlite bd = new ProyectoSqlite();
ITramiteRepositorio repoT = new RepositorioTramiteTXT();

ProyectoSqlite.Inicializar();
using (var context = new UserAccountContext())
{
    Console.WriteLine("-- Tabla UserAccount --");
    foreach (var a in context.UserAccount)
    {
    Console.WriteLine($"{a.Id} {a.UserName}");
    }
}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name="Auth_token";
        options.LoginPath="/login";
        options.Cookie.MaxAge=TimeSpan.FromMinutes(30);
        options.AccessDeniedPath="/access-denied";
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
