using SGE.Aplicacion.CasosDeUso;
using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Interfaces;

public interface IRepositorioExpediente
{
    void AgregarExpediente(Expediente expediente, int idUsuario);
    void ModificarExpediente(Expediente expediente);
    // void EliminarExpediente(int id,List<Tramite> listaT,CasoDeUsoTramiteBaja EliminarTramite);
    List<Expediente> ListarExpedientes();
    void EliminarExpediente(int idExpediente);
    Expediente GetExpedientePorId(int id);
}
