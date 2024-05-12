namespace SGE.Aplicacion;

public class CasoDeUsoListarTramites(ITramiteRepositorio repo)
{
    public List<Tramite> Ejecutar(){
        return repo.ListarTramites();
    }
}
