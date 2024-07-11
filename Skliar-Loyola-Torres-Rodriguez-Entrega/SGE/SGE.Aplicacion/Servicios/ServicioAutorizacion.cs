using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion;

public class ServicioAutorizacion : IServicioAutorizacion
{
    private readonly IRepositorioUsuario _repositorio;

    public ServicioAutorizacion(IRepositorioUsuario repositorioUsuario)
    {
        _repositorio = repositorioUsuario;
    }
    //busca un usuario por id en la base de datos
    public bool PoseeElPermiso(int IdUsuario, TipoPermiso permiso){
        var usuario = _repositorio.GetUsuario(IdUsuario); //hay que implementar el metodo
        if (usuario == null) return false;

        // Comparar los permisos del usuario con el permiso recibido
        return usuario.Permisos.Any(p => p.tipoPermiso == permiso);
    } 

    //habría que implementar este otro método que no acceda a la base de datos (que acceda al usuario por el conexto)
    public bool PoseeElPermiso(UserAccount usuario, TipoPermiso permiso){
        if (usuario == null) return false;

        // Comparar los permisos del usuario con el permiso recibido
        return usuario.Permisos.Any(p => p.tipoPermiso == permiso);    
    } 

}

