namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoTramiteAlta(IRepositorioTramite repoT,IRepositorioExpediente repoE, TramiteValidador validador, IServicioAutorizacion servicioAuth, IServicioActualizacionEstado servicioUpdate){
    public void Ejecutar(Tramite tramite, Expediente expediente ,int idUsuario, Permiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso)){//verifica la autorizacion del usuario
            throw new AutorizacionException("El usuario no tiene permiso para realizar el alta de un Trámite");
        }
        else if(!validador.Validar(tramite,idUsuario, out string mensajeError)){//valida el expediente
                throw new ValidacionException(mensajeError); 
            }
            else {//realiza el agregado
                tramite.fechaHoraCreacion = DateTime.Now;
                // Agregar el trámite a la lista, agrega el tramite al repositorio y actualiza el estado del expediente
                expediente.AgregarTramiteALista(expediente,tramite);
                repoT.AgregarTramite(tramite,expediente.Id);
                servicioUpdate.actualizarEstadoExpediente(expediente.Id,repoE,expediente.listaTramites);
            }
    }
}

