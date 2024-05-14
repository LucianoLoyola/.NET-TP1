namespace SGE.Aplicacion;


public class CasoDeUsoTramiteBaja(ITramiteRepositorio repoT, IExpedienteRepositorio repoE, IServicioAutorizacion servicioAuth, IServicioActualizacionEstado servicioUpdate){
    public void Ejecutar(int idTramite, int idExpediente, int idUsuario, Permiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar la baja");
        }
        else {//realiza el agregado
                repoT.EliminarTramite(idTramite);
                servicioUpdate.actualizarEstadoExpediente(idExpediente,repoE);
        }
    }
}