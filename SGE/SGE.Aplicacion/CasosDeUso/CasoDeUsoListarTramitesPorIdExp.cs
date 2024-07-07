namespace SGE.Aplicacion.CasosDeUso;

using AL.Aplicacion.UseCases;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoListarTramitesPorIdEx(IRepositorioTramite repo):TramiteUseCase(repo){
    public List<Tramite> Ejecutar(int IdExp){
        List<Tramite> listaTramitesIdExp = repo.ListarTramites();
        
        if (listaTramitesIdExp.Count == 0) Console.WriteLine("No existen tramites en el repositorio");
        
        return listaTramitesIdExp;
    }

    
}