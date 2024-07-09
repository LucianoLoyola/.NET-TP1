namespace SGE.Aplicacion.CasosDeUso;

using AL.Aplicacion.UseCases;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoExpedienteConsultaPorId(IRepositorioExpediente repo) : ExpedienteUseCase(repo)
{

    public Expediente Ejecutar(int idExpediente)
    {
        Expediente? expediente = Repositorio.GetExpedientePorId(idExpediente);
        if (expediente == null)
        {//si no se encontró expediente, excepción
            throw new RepositorioException($"No se encontró un expediente con el ID {idExpediente}");
        }
        return expediente;//devuelve el expediente con su lista de tramites

    }
}


