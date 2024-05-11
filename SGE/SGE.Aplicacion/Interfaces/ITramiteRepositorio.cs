namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void AgregarTramite(Tramite tramite);
    void ModificarExpediente(Tramite tramite);
    void EliminarExpediente(int id);
    List<Tramite> ListarTramite();
}
