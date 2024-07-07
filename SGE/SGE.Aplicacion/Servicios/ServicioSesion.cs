using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;


namespace SGE.Aplicacion.Servicios
{

public class ServicioSesion : IServicioSesion
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    // private readonly SGEContext _dbContext;

    public ServicioSesion(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        // _dbContext = dbContext;
    }

    public int GetUserId()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        var userIdClaim = user?.FindFirst("UserId")?.Value;

        if (int.TryParse(userIdClaim, out int userId))
        {
            return userId;
        }
        else
        {
            // Manejo de error si no se puede convertir el valor a int
            throw new InvalidOperationException("No se pudo obtener el Id de usuario.");
        }
    }

    //retorna el usuario actual (busca por id, poco eficiente)
    //  public UserAccount GetUsuario()
    //     {
    //         var userId = GetUserId();
    //         var usuario = _dbContext.Usuarios.Include(u => u.Permisos).FirstOrDefault(u => u.Id == userId);
    //         if (usuario == null)
    //         {
    //             throw new InvalidOperationException("Usuario no encontrado.");
    //         }

    //         return usuario;
    //     }
}

} 