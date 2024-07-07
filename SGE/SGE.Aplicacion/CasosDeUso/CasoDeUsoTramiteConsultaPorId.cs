namespace SGE.Aplicacion.CasosDeUso;

using AL.Aplicacion.UseCases;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoTramiteConsultaPorId(IRepositorioTramite repo) : TramiteUseCase(repo)
{

    public Tramite Ejecutar(int idTramite)
    {
        Tramite? tramite = Repositorio.GetTramitePorId(idTramite);
        if (tramite == null)
        {//si no se encontró tramite, excepción
            throw new RepositorioException($"No se encontró un tramite con el ID {idTramite}");
        }
        Console.WriteLine("Se encontró el tramite");
        return tramite;//devuelve el tramite 
    }
}