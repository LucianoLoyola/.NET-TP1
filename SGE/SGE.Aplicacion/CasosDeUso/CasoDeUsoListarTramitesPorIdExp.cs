namespace SGE.Aplicacion.CasosDeUso;

using AL.Aplicacion.UseCases;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoListarTramitesPorIdEx(IRepositorioTramite repo):TramiteUseCase(repo){
    public List<Tramite> Ejecutar(int IdExp){
        try{
            List<Tramite> listaTramitesIdExp = repo.ListarTramitesPorIdExp(IdExp);
            return listaTramitesIdExp;
        }
        catch(Exception error){
            throw;
            //Console.WriteLine(error.Message);
            return null;
        }

    }

    
}