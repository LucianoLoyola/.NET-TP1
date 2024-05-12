namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpedienteRepositorio repo)
{
    public void Ejecutar(Expediente expediente, int idUsuario){
        //validacion del permiso de usuario
        expediente.fechaHoraUModificacion = DateTime.Now;
        repo.ModificarExpediente(expediente);
    }
}
