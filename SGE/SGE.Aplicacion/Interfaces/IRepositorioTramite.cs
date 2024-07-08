using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Interfaces;
public interface IRepositorioTramite
{
    void AgregarTramite(Tramite tramite); //el idExpediente debería ser seteado antes (creo que lo setea el EF)
    void ModificarTramite(Tramite tramite);
    void EliminarTramite(int id);
    List<Tramite> ListarTramites();
    List<Tramite> ListarTramitesPorIdExp(int idExpediente);
    Tramite GetTramitePorEtiqueta(Tramite tramite, Etiqueta etiqueta); //etiqueta quizá entre como string
    Tramite GetTramitePorId(int id);

}
