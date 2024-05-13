namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo, IServicioAutorizacion servicioAuth){
    public void Ejecutar(Expediente expediente, int idUsuario, Permiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar la modificacion");
        }
        else {//realiza la modificacion
            
            expediente.fechaHoraUModificacion = DateTime.Now;
            repo.ModificarExpediente(expediente);
        }
    }
}