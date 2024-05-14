namespace SGE.Aplicacion;
public class CasoDeUsoTramiteAlta(ITramiteRepositorio repoT,IExpedienteRepositorio repoE, TramiteValidador validador, IServicioAutorizacion servicioAuth, IServicioActualizacionEstado servicioUpdate){
    public void Ejecutar(Tramite tramite, int idExpediente,int idUsuario, Permiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar el alta");
        }
        else if(!validador.Validar(tramite,idUsuario, out string mensajeError)){//valida el expediente
                throw new ValidacionException(mensajeError); 
            }
            else {//realiza el agregado
                tramite.fechaHoraCreacion = DateTime.Now;
                repoT.AgregarTramite(tramite,idExpediente);
                servicioUpdate.actualizarExpediente(idExpediente,repoE);
            }
    }
}

