namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class CasoDeUsoTramiteModificacion(IRepositorioTramite repoT, IRepositorioExpediente repoE, TramiteValidador validador, IServicioAutorizacion servicioAuth, IServicioActualizacionEstado servicioUpdate){
    public void Ejecutar(Tramite tramite ,Expediente expediente, int idUsuario, TipoPermiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso)){//verifica la autorizacion del usuario
            throw new AutorizacionException("El usuario no tiene permiso para realizar la modificacion");
        }
        else if(!validador.Validar(tramite,idUsuario, out string mensajeError)){//valida el tramite
                throw new ValidacionException(mensajeError); 
            }
            else {//realiza la modificacion
                tramite.fechaHoraUltimaModificacion = DateTime.Now;
                // expediente.ModificarTramiteDeLista(expediente,tramite);
                repoT.ModificarTramite(tramite);
                servicioUpdate.actualizarEstadoExpediente(expediente.Id, repoE, expediente.listaTramites);
            }
    }

}
