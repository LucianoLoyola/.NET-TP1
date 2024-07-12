namespace SGE.Aplicacion.CasosDeUso;

using AL.Aplicacion.UseCases;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoListarTramites(IRepositorioTramite repo):TramiteUseCase(repo){
    public List<Tramite> Ejecutar(){
        
        try{
            List<Tramite> listaTramites = repo.ListarTramites();
            return listaTramites;
        }
        catch(Exception error){
            throw;
            //Console.WriteLine(error.Message);
            return null;
        }
    }
}