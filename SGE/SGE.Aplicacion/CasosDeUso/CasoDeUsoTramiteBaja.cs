namespace SGE.Aplicacion;


public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, IServicioAutorizacion servicioAuth){
    public void Ejecutar(int idTramite, int idUsuario, Permiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar la baja");
        }
        else {//realiza el agregado
                repo.EliminarTramite(idTramite);
        }
    }
}