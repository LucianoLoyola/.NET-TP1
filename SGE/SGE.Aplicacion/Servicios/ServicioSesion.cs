using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SGE.Aplicacion.Interfaces;


namespace SGE.Aplicacion.Servicios
{

public class ServicioSesion : IServicioSesion
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ServicioSesion(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int GetUserId()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        var userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

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
}
}