using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    private readonly IRepositorioUserAccount _repositorio;

    public ServicioAutorizacionProvisorio(IRepositorioUserAccount repositorioUsuario)
    {
        _repositorio = repositorioUsuario;
    }
    //busca un usuario por id en la base de datos
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso){
        var usuario = _repositorio.GetUserAccount(IdUsuario); //hay que implementar el metodo
        return usuario?.Permisos.Contains(permiso) ?? false;  //quiza no funcione porque trae un string de la base de datos
                                                    // (aunque podría funcionar porque está implementada la conversión en el user context).
    } 

    //habría que implementar este otro método que no acceda a la base de datos (que acceda al usuario por el conexto)
    public bool PoseeElPermiso(UserAccount usuario, Permiso permiso){
        return usuario?.Permisos.Contains(permiso) ?? false;
    } 

}

