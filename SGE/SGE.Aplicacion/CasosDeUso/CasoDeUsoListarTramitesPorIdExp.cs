namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoListarTramitesPorIdEx(IRepositorioTramite repo){
    public List<Tramite> Ejecutar(int IdExp){
        List<Tramite> listaTramitesIdExp = repo.ListarTramites();
        
        if (listaTramitesIdExp.Count == 0) Console.WriteLine("No existen tramites en el repositorio");
        
        return listaTramitesIdExp;
    }

    
}