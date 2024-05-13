namespace SGE.Aplicacion;
public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo, ExpedienteValidador validador, IServicioAutorizacion servicioAuth){
    public void Ejecutar(Expediente expediente ,int idUsuario, Permiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar la modificacion");
        }
        else if(!validador.Validar(expediente,idUsuario, out string mensajeError)){//valida el expediente
                throw new ValidacionException(mensajeError); 
            }
            else try {//realiza la modificacion
                expediente.fechaHoraUModificacion = DateTime.Now;
                repo.ModificarExpediente(expediente);
            }
             catch(RepositorioException repoException) {
                Console.WriteLine($"Operación cancelada - Objeto Inexistente\n{repoException.Message}");
            }
    }
}