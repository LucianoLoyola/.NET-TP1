namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;
public class CasoDeUsoExpedienteAlta(IRepositorioExpediente repo, ExpedienteValidador validador, IServicioAutorizacion servicioAuth){
    public void Ejecutar(Expediente expediente,int idUsuario, TipoPermiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario
        {
            throw new AutorizacionException("No tiene permiso para realizar el alta de un expediente");
        }
        else if(!validador.Validar(expediente,idUsuario, out string mensajeError)){//valida el expediente
                throw new ValidacionException(mensajeError); 
            }
            else {//realiza el agregado
                expediente.fechaHoraCreacion = DateTime.Now;
                expediente.IdUsuarioMod = idUsuario;
                expediente.fechaHoraUModificacion = DateTime.Now;
                repo.AgregarExpediente(expediente,idUsuario);
            }
    }
    
}
