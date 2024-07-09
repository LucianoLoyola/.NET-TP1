using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SGE.UI.Components;
using SGE.Repositorios;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion;
using Microsoft.AspNetCore.Antiforgery;
using ASP.Components;
//que hace esto?? es lo mismo que no pasarle nada?
// Crear una instancia de DbContextOptions para SGEContext (le pasa las opciones al constructor)
var connectionString = "Data Source=SGE.sqlite";
var options = new DbContextOptionsBuilder<SGEContext>()
    .UseSqlite(connectionString)
    .Options;

// Inicializar la base de datos si es necesario
SGESqlite.Inicializar(options);

// Usar el contexto para mostrar los datos de UserAccount
// using (var context = new SGEContext(options))
// {
//     Console.WriteLine("-- Tabla UserAccount --");
//     foreach (var a in context.Usuarios)
//     {
//         Console.WriteLine($"{a.Id} {a.UserName}");
//     }
// }

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios y middleware
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddTransient<AgregarUsuarioUseCase>()
    .AddTransient<EliminarUserAccountUseCase>()
    .AddTransient<CasoDeUsoTramiteBaja>()
    .AddTransient<CasoDeUsoTramiteAlta>()
    .AddTransient<CasoDeUsoTramiteConsultaPorId>()
    .AddTransient<CasoDeUsoTramiteConsultaPorEtiqueta>()
    .AddTransient<CasoDeUsoTramiteModificacion>()
    .AddTransient<CasoDeUsoListarTramites>()
    .AddTransient<CasoDeUsoListarTramitesPorIdEx>()
    .AddTransient<CasoDeUsoListarExpedientes>()
    .AddTransient<CasoDeUsoExpedienteAlta>()
    .AddTransient<CasoDeUsoExpedienteConsultaPorId>()
    .AddTransient<ModificarUserAccountUseCase>()
    .AddTransient<ObtenerUserAccountUseCase>()
    .AddTransient<CasoDeUsoExpedienteModificacion>()
    .AddTransient<CasoDeUsoExpedienteBaja>();

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioExpediente, RepositorioExpediente>();
builder.Services.AddScoped<IRepositorioTramite, RepositorioTramite>();
builder.Services.AddScoped<IServicioHash, ServicioHash>();
builder.Services.AddScoped<IServicioActualizacionEstado, ServicioActualizacionEstado>();
builder.Services.AddScoped<IServicioSesion, ServicioSesion>();
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
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<ExpedienteValidador>();
builder.Services.AddTransient<TramiteValidador>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();


// Agregar el DbContext de SGEContext con la configuración de SQLite
builder.Services.AddDbContext<SGEContext>(options =>
    options.UseSqlite(connectionString));



var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}



app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
