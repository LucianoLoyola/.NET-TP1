namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class CasoDeUsoExpedienteModificacion(IRepositorioExpediente repo, ExpedienteValidador validador, IServicioAutorizacion servicioAuth){

    public void Ejecutar(Expediente expediente ,int idUsuario, TipoPermiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario
        {
            throw new AutorizacionException("No tiene permiso para realizar la modificacion");
        }
        else if(!validador.Validar(expediente,idUsuario, out string mensajeError)){//valida el expediente
                throw new ValidacionException(mensajeError); 
            }
            else try {//realiza la modificacion
                expediente.fechaHoraUModificacion = DateTime.Now;
                repo.ModificarExpediente(expediente);
            }
             catch(RepositorioException repoException) {
                throw;
                //Console.WriteLine($"Operación cancelada - Objeto Inexistente\n{repoException.Message}");
            }
    }
}