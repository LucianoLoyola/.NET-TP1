namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void AgregarTramite(Tramite tramite);
    void ModificarTramite(Tramite tramite);
    void EliminarTramite(int id);
    List<Tramite> ListarTramite();
}
