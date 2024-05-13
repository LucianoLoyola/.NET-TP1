namespace SGE.Aplicacion;
public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, ExpedienteValidador validador, IServicioAutorizacion servicioAuth){
    public void Ejecutar(Expediente expediente, int idExpediente,int idUsuario, Permiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar el alta");
        }
        else if(!validador.Validar(expediente,idUsuario, out string mensajeError)){//valida el expediente
                throw new ValidacionException(mensajeError); 
            }
            else {//realiza el agregado
                expediente.fechaHoraCreacion = DateTime.Now;
                repo.AgregarExpediente(expediente);
            }
    }
}
