using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion;

namespace SGE.Repositorios;
public class RepositorioTramite : IRepositorioTramite
{
    private readonly SGEContext db;

    public RepositorioTramite(SGEContext context)
    {
        db = context;
    }

    public void AgregarTramite(Tramite tramite){
        if (tramite.Contenido == null) throw new RepositorioException("El trámite debe tener contenido");
        db.Add(tramite);
        db.SaveChanges();
    }

    public void ModificarTramite(Tramite tramite){
        //La busca por Id
        var tr_existente = db.Tramites.Find(tramite.Id);

        if (tr_existente == null) throw new RepositorioException("No se encontró el tramite\n");

        tr_existente.ExpedienteId = tramite.ExpedienteId;
        tr_existente. Etiqueta = tramite.Etiqueta;
        tr_existente.Contenido = tramite.Contenido;
        tr_existente.fechaHoraCreacion = tramite.fechaHoraCreacion;
        tr_existente.fechaHoraUltimaModificacion = tramite.fechaHoraUltimaModificacion;
        tr_existente.IdUsuarioMod = tramite.IdUsuarioMod;

        db.SaveChanges();
    }
    public List<Tramite> ListarTramites(){
        return db.Tramites.ToList();
    }

    public void EliminarTramite(int id){
        var tr_existente = db.Tramites.Find(id);
        if (tr_existente == null) throw new RepositorioException("No se encontró el trámite con ese id");

        db.Remove(tr_existente); //se borra realmente con el db.SaveChanges()
        db.SaveChanges();
    }

    public Tramite GetTramitePorEtiqueta(Tramite tramite, Etiqueta etiqueta){ //quizá reciba un string
        tramite = db.Tramites.Where(e => e.Etiqueta == etiqueta).SingleOrDefault();
        if(tramite == null) return null;
        else return tramite;
    }

    public Tramite GetTramitePorId(int id) => db.Tramites.Where(t => t.Id == id).SingleOrDefault();

    List<Tramite> IRepositorioTramite.ListarTramitesPorIdExp(int idExpediente)
    {
        return db.Tramites.Where(t => t.ExpedienteId == idExpediente).ToList();
    }
}