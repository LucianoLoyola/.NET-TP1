namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, IServicioAutorizacion servicioAuth){
    public void Ejecutar(Tramite tramite, int idUsuario, Permiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar el alta");
        }
        else {//realiza la modificacion
            tramite.fechaHoraUltimaModificacion = DateTime.Now;
            repo.ModificarTramite(tramite);
        }
    }
}
