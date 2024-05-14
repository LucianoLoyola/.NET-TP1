namespace SGE.Aplicacion;
public class CasoDeUsoTramiteAlta(ITramiteRepositorio repoT,IExpedienteRepositorio repoE, TramiteValidador validador, IServicioAutorizacion servicioAuth, IServicioActualizacionEstado servicioUpdate){
    public void Ejecutar(Tramite tramite, Expediente expediente ,int idUsuario, Permiso permiso){

        if (!servicioAuth.PoseeElPermiso(idUsuario, permiso))//verifica la autorizacion del usuario
        {
            throw new AutorizacionException("El usuario no tiene permiso para realizar el alta");
        }
        else if(!validador.Validar(tramite,idUsuario, out string mensajeError)){//valida el expediente
                throw new ValidacionException(mensajeError); 
            }
            else {//realiza el agregado
                tramite.fechaHoraCreacion = DateTime.Now;
                // si la lista es null, se crea la lista
                if (expediente.listaTramites == null)
                {
                    expediente.listaTramites = new List<Tramite>();
                }
                // Agregar el trámite a la lista
                expediente.listaTramites.Add(tramite);
                //agrega el tramite al repositorio
                repoT.AgregarTramite(tramite,expediente.Id);
                //actualiza el estado del expediente
                servicioUpdate.actualizarEstadoExpediente(expediente.Id,repoE);
            }
    }
}

