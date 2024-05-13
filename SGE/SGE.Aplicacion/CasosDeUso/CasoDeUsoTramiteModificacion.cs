namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, TramiteValidador validador, IServicioAutorizacion servicioAuth){
    public void Ejecutar(Tramite tramite ,int idUsuario, Permiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar la modificacion");
        }
        else if(!validador.Validar(tramite,idUsuario, out string mensajeError)){//valida el tramite
                throw new ValidacionException(mensajeError); 
            }
            else {//realiza la modificacion
                tramite.fechaHoraUltimaModificacion = DateTime.Now;
                repo.ModificarTramite(tramite);
            }
    }
}
