namespace SGE.Aplicacion;
public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, ExpedienteValidador validador){
    public void Ejecutar(Expediente expediente, int idUsuario){
        //validacion de permiso de usuario
        if(!validador.Validar(expediente, out string mensajeError)){
           throw new Exception(mensajeError); 
        }
        expediente.fechaHoraCreacion = DateTime.Now;
        repo.AgregarExpediente(expediente);
    }
}
