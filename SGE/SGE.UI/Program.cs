using SGE.UI.Components;
using SGE.Repositorios;
using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Servicios;
using SGE.Aplicacion;
// using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

// Configurar servicios y middleware
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddTransient<AgregarUsuarioUseCase>()
    .AddTransient<EliminarUserAccountUseCase>()
    .AddTransient<ListarUserAccountUseCase>()
    .AddTransient<LoginUseCase>()
    .AddTransient<LogoutUseCase>()
    .AddTransient<ModificarUserAccountUseCase>()
    .AddTransient<ObtenerUserAccountUseCase>();

builder.Services.AddTransient<CasoDeUsoTramiteBaja>()
    .AddTransient<CasoDeUsoTramiteAlta>()
    .AddTransient<CasoDeUsoTramiteConsultaPorId>()
    .AddTransient<CasoDeUsoTramiteConsultaPorEtiqueta>()
    .AddTransient<CasoDeUsoTramiteModificacion>()
    .AddTransient<CasoDeUsoListarTramites>()
    .AddTransient<CasoDeUsoListarTramitesPorIdEx>();

builder.Services.AddTransient<CasoDeUsoListarExpedientes>()
    .AddTransient<CasoDeUsoExpedienteAlta>()
    .AddTransient<CasoDeUsoExpedienteConsultaPorId>()
    .AddTransient<CasoDeUsoExpedienteModificacion>()
    .AddTransient<CasoDeUsoExpedienteBaja>();

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioExpediente, RepositorioExpediente>();
builder.Services.AddScoped<IRepositorioTramite, RepositorioTramite>();

builder.Services.AddScoped<IServicioHash, ServicioHash>();
builder.Services.AddScoped<IServicioActualizacionEstado, ServicioActualizacionEstado>();
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddTransient<IServicioEvento, ServicioEvento>();

builder.Services.AddTransient<ExpedienteValidador>();
builder.Services.AddTransient<TramiteValidador>();
builder.Services.AddTransient<UsuarioValidador>();

builder.Services.AddSingleton<IServicioSession, ServicioSession>();


        // //configuraciones para las cookies
        // builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        //     .AddCookie(options =>
        //     {
        //         options.LoginPath = "/login";
        //         options.LogoutPath = "/logout";
        //         options.ExpireTimeSpan = TimeSpan.FromDays(14);
        //         options.SlidingExpiration = true;
        //     });

        // builder.Services.AddAuthorization(options =>
        // {
        //     options.AddPolicy("Authenticated", policy => policy.RequireAuthenticatedUser());
        // });

SGESqlite.Inicializar();

var app = builder.Build();

    // // Configurar el pipeline de solicitudes HTTP
    //     if (!app.Environment.IsDevelopment())
    //     {
    //         app.UseExceptionHandler("/Error");
    //         app.UseHsts();
    //     }

    //     app.UseHttpsRedirection();
    //     app.UseRouting();
    //     app.UseAuthentication();
    //     app.UseAuthorization();

app.UseAntiforgery();
app.UseStaticFiles();//

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();