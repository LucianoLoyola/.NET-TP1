using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;
namespace SGE.Aplicacion.Interfaces;

public interface IExpedienteRepositorio
{
    void AgregarExpediente(Expediente expediente);
    void ModificarExpediente(Expediente expediente);
    // void EliminarExpediente(int id,List<Tramite> listaT,CasoDeUsoTramiteBaja EliminarTramite);
    List<Expediente> ListarExpedientes();
    void EliminarExpediente(int idExpediente, List<Tramite> listaT, CasoDeUsoTramiteBaja EliminarTramite);
}
