using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.CasosDeUso;

namespace SGE.Repositorios;
public class RepositorioExpediente : IRepositorioExpediente
{
    private readonly SGEContext db;

    public RepositorioExpediente(SGEContext context)
    {
        db = context;
    }

    public void AgregarExpediente(Expediente expediente, int idUsuario){
        if (expediente.caratula == null) throw new Exception("El expediente debe tener una caratula");
        expediente.IdUsuarioMod = idUsuario;
        expediente.fechaHoraCreacion = DateTime.Now;
        expediente.fechaHoraUModificacion = DateTime.Now;
        db.Add(expediente);
        db.SaveChanges();
    }

    public void ModificarExpediente(Expediente expediente){
        //La busca por Id
        var exp_existente = db.Expedientes.Find(expediente.Id);

        if (exp_existente == null) throw new Exception("No se encontro un expediente con ese id\n");

        exp_existente.caratula = expediente.caratula;
        exp_existente.fechaHoraCreacion = expediente.fechaHoraCreacion;
        exp_existente.fechaHoraUModificacion = expediente.fechaHoraUModificacion;
        exp_existente.IdUsuarioMod = expediente.IdUsuarioMod;
        exp_existente.estado = expediente.estado;
        exp_existente.listaTramites = expediente.listaTramites;

        db.SaveChanges();
    }
    public List<Expediente> ListarExpedientes(){
        return db.Expedientes.ToList();
    }

    public void EliminarExpediente(int idExpediente){
        var exp_existente = db.Expedientes.Find(idExpediente);
        if (exp_existente == null) throw new Exception("No se encontro el expediente con ese id");

        db.Remove(exp_existente); //se borra realmente con el db.SaveChanges()
        db.SaveChanges();
    }

    public Expediente GetExpedientePorId(int id){
        return db.Expedientes.Where(e => e.Id == id).SingleOrDefault();
    }

}