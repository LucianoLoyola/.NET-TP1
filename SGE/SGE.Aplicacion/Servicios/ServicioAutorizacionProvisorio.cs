using SGE.Aplicacion.Interfaces;

namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso){
        if(IdUsuario==1){
            return true;
        }
        else{
            return false;
        }
    } 
}