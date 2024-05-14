namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repoT, IExpedienteRepositorio repoE, TramiteValidador validador, IServicioAutorizacion servicioAuth, IServicioActualizacionEstado servicioUpdate){
    public void Ejecutar(Tramite tramite ,Expediente expediente, int idUsuario, Permiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso)){//verifica la autorizacion del usuario
            throw new AutorizacionException("El usuario no tiene permiso para realizar la modificacion");
        }
        else if(!validador.Validar(tramite,idUsuario, out string mensajeError)){//valida el tramite
                throw new ValidacionException(mensajeError); 
            }
            else {//realiza la modificacion
                tramite.fechaHoraUltimaModificacion = DateTime.Now;
                tramite.Contenido="Cambio de contenido";
                tramite.etiqueta=Etiqueta.Resolución;
                expediente.ModificarTramiteDeLista(expediente,tramite);
                repoT.ModificarTramite(tramite);
                servicioUpdate.actualizarEstadoExpediente(expediente.Id, repoE, expediente.listaTramites);
            }
    }

}
