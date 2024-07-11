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
        var usuario = _repositorio.GetUsuario(IdUsuario); 
        if (usuario == null) return false;

        // Comparar los permisos del usuario con el permiso recibido
        return usuario.Permisos.Any(p => p.tipoPermiso == permiso);
    } 

    public bool PoseeElPermiso(UserAccount usuario, TipoPermiso permiso){
        if (usuario == null) return false;

        // Comparar los permisos del usuario con el permiso recibido
        return usuario.Permisos.Any(p => p.tipoPermiso == permiso);    
    } 

}

