namespace SGE.Aplicacion;

public class CasoDeUsoListarTramites(ITramiteRepositorio repo){
    public List<Tramite> Ejecutar(){
        List<Tramite> listaTramites = repo.ListarTramites();
        
        if (listaTramites.Count == 0)
        {
            Console.WriteLine("No existen tramites en el repositorio");
        }
        
        return listaTramites;
    }
}