using SGE.Aplicacion.Entidades;

namespace SGE.Aplicacion.Interfaces;
public interface IRepositorioTramite
{
    void AgregarTramite(Tramite tramite, int idExpediente); //el idExpediente debería ser seteado antes (creo que lo setea el EF)
    void ModificarTramite(Tramite tramite);
    void EliminarTramite(int id);
    List<Tramite> ListarTramites();
    Tramite GetTramitePorEtiqueta(Tramite tramite, Etiqueta etiqueta); //etiqueta quizá entre como string

}
