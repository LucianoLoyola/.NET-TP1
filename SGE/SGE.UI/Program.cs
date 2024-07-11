using Microsoft.EntityFrameworkCore;
using SGE.UI.Components;
using SGE.Repositorios;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion;

var connectionString = "Data Source=SGE.sqlite";
var options = new DbContextOptionsBuilder<SGEContext>()
    .UseSqlite(connectionString)
    .Options;

// Inicializar la base de datos si es necesario
SGESqlite.Inicializar(options);

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios y middleware
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddTransient<AgregarUsuarioUseCase>()
    .AddTransient<EliminarUserAccountUseCase>()
    .AddTransient<ListarUserAccountUseCase>()
    .AddTransient<LoginUseCase>()
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
builder.Services.AddSingleton<IServicioSession, ServicioSession>();
builder.Services.AddScoped<IServicioEvento, ServicioEvento>();

builder.Services.AddTransient<ExpedienteValidador>();
builder.Services.AddTransient<TramiteValidador>();
builder.Services.AddTransient<UsuarioValidador>();
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

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
