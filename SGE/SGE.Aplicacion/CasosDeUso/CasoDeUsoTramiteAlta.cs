namespace SGE.Aplicacion;
public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, TramiteValidador validador, IServicioAutorizacion servicioAuth){
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
                repo.AgregarTramite(tramite,idExpediente);
            }
    }
}

