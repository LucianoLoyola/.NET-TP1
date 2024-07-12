namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoTramiteBaja(IRepositorioTramite repoT, IRepositorioExpediente repoE, IServicioAutorizacion servicioAuth, IServicioActualizacionEstado servicioUpdate){
    public void Ejecutar(int idTramite, Expediente expediente, int idUsuario, TipoPermiso permiso){
        try {
            if (!servicioAuth.PoseeElPermiso(idUsuario, permiso)){//verifica la autorizacion del usuario
                throw new AutorizacionException("No tiene permiso para realizar la baja");
            } else {//realiza el borrado
                repoT.EliminarTramite(idTramite);
                servicioUpdate.actualizarEstadoExpediente(expediente.Id,repoE);
            }
        } catch (RepositorioException ex) {
            throw;
            // Si se genera una excepción, no es necesario llamar a los métodos de actualización
        }
    }

}
