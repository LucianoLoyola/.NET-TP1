namespace SGE.Aplicacion;

public interface IServicioActualizacionEstado
{
    void actualizarEstadoExpediente(int idExpediente, IExpedienteRepositorio repo, List<Tramite>? listaTramites);
}