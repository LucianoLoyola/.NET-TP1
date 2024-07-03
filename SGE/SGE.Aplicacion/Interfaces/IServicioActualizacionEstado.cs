namespace SGE.Aplicacion.Interfaces;

using SGE.Aplicacion.Entidades;
public interface IServicioActualizacionEstado
{
    void actualizarEstadoExpediente(int idExpediente, IRepositorioExpediente repo, List<Tramite>? listaTramites);
}