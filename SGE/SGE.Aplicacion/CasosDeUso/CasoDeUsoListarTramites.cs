namespace SGE.Aplicacion.CasosDeUso;

using AL.Aplicacion.UseCases;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoListarTramites(IRepositorioTramite repo):TramiteUseCase(repo){
    public List<Tramite> Ejecutar(){
        List<Tramite> listaTramites = repo.ListarTramites();
        
        if (listaTramites.Count == 0)
        {
            Console.WriteLine("No existen tramites en el repositorio");
        }
        
        return listaTramites;
    }

    
}