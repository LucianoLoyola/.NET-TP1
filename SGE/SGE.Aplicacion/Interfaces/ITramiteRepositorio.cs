namespace SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
public interface ITramiteRepositorio
{
    void AgregarTramite(Tramite tramite, int idExpediente);
    void ModificarTramite(Tramite tramite);
    void EliminarTramite(int id);
    List<Tramite> ListarTramites();
}
