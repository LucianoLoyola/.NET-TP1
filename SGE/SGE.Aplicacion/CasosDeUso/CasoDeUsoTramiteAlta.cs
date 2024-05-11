namespace SGE.Aplicacion;
public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, TramiteValidador validador){
    public void Ejecutar(Tramite tramite, int idExpediente){
        //validacion de permiso de usuario
        if(!validador.Validar(tramite, out string mensajeError)){
           throw new Exception(mensajeError); 
        }
        tramite.fechaHoraCreacion = DateTime.Now;
        repo.AgregarTramite(tramite,idExpediente);
    }
}
