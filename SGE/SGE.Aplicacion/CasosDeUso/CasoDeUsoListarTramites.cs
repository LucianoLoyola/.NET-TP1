namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoListarTramites(IRepositorioTramite repo){
    public List<Tramite> Ejecutar(){
        List<Tramite> listaTramites = repo.ListarTramites();
        
        if (listaTramites.Count == 0)
        {
            Console.WriteLine("No existen tramites en el repositorio");
        }
        
        return listaTramites;
    }
}