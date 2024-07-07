using SGE.Aplicacion.Interfaces;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.CasosDeUso;
using System.Data;

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

    // public void AgregarTramiteExp(int IdExp, Tramite tramite) {
    //     var exp_existente = db.Expedientes.Find(IdExp);

    //     if (exp_existente == null) throw new Exception("No se encontro un expediente con ese id\n");

    //     exp_existente.listaTramites = expediente.listaTramites;

    //     db.SaveChanges();

    // }


    // public void ModificarTramiteDeLista(Expediente expediente, Tramite tramiteModificado){ //método para modificar lista de trámites
    //     if (expediente.listaTramites != null){
    //         for (int i = 0; i < expediente.listaTramites.Count; i++){
    //             if (expediente.listaTramites[i].Id == tramiteModificado.Id){
    //                 expediente.listaTramites[i] = tramiteModificado;
    //             }
    //         }
    //     }
    // }
    // public void EliminarTramiteDeLista(Expediente expediente, int tramiteId){//método para eliminar un tramite de la lista
    //     if (expediente.listaTramites != null){
    //         for (int i = 0; i < expediente.listaTramites.Count; i++){
    //             if (expediente.listaTramites[i].Id == tramiteId){
    //                 expediente.listaTramites.RemoveAt(i);
    //             }
    //         }
    //     }
    // }

    // public void AgregarTramiteALista(Expediente expediente, Tramite nuevoTramite){//método para agregar un tramite a la lista
    //     if (expediente.listaTramites == null){
    //         expediente.listaTramites = new List<Tramite>();
    //     }
    //     expediente.listaTramites.Add(nuevoTramite);
    // }

    // public void EliminarTodosLosTramites(){
    //     if (listaTramites != null){
    //         listaTramites.Clear(); // Elimina todos los trámites de la lista
    //     }
    // }












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