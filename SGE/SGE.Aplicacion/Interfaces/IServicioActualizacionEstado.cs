namespace SGE.Aplicacion;

public interface IServicioActualizacionEstado
{
    void actualizarExpediente(int idExpediente, IExpedienteRepositorio repo);
}