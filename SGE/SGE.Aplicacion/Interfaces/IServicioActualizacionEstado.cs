namespace SGE.Aplicacion.Interfaces;

using SGE.Aplicacion.Entidades;
public interface IServicioActualizacionEstado
{
    void actualizarEstadoExpediente(int idExpediente, IExpedienteRepositorio repo, List<Tramite>? listaTramites);
}