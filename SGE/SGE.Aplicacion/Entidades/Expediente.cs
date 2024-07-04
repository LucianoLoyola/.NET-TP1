using System.Runtime.CompilerServices;

namespace SGE.Aplicacion.Entidades;

public class Expediente
{
    public int Id { get; set; } //debe ser un entero valido mayor a 0 (lo asigna el EF)
    public string caratula { get; set; } = ""; //no puede estar vacia 
    public DateTime fechaHoraCreacion { get; set; }
    public DateTime? fechaHoraUModificacion { get; set; }
    public int IdUsuarioMod { get; set; }
    public Estado estado { get; set; }
    public List<Tramite>? listaTramites { get; set; }
    public override string ToString()
    {
        return $"Datos del expediente:\n" +
            $"  - ID: {Id}\n" +
            $"  - Carátula: {caratula}\n" +
            $"  - Fecha y hora de creación: {fechaHoraCreacion}\n" +
            $"  - Fecha y hora de última modificación: {fechaHoraUModificacion}\n" +
            $"  - ID de usuario de modificación: {IdUsuarioMod}\n" +
            $"  - Estado: {estado}\n";
    }

    
    public void ModificarTramiteDeLista(Expediente expediente, Tramite tramiteModificado){ //método para modificar lista de trámites
        if (expediente.listaTramites != null){
            for (int i = 0; i < expediente.listaTramites.Count; i++){
                if (expediente.listaTramites[i].Id == tramiteModificado.Id){
                    expediente.listaTramites[i] = tramiteModificado;
                }
            }
        }
    }
    public void EliminarTramiteDeLista(Expediente expediente, int tramiteId){//método para eliminar un tramite de la lista
        if (expediente.listaTramites != null){
            for (int i = 0; i < expediente.listaTramites.Count; i++){
                if (expediente.listaTramites[i].Id == tramiteId){
                    expediente.listaTramites.RemoveAt(i);
                }
            }
        }
    }

    public void AgregarTramiteALista(Expediente expediente, Tramite nuevoTramite){//método para agregar un tramite a la lista
        if (expediente.listaTramites == null){
            expediente.listaTramites = new List<Tramite>();
        }
        expediente.listaTramites.Add(nuevoTramite);
    }

    public void EliminarTodosLosTramites(){
        if (listaTramites != null){
            listaTramites.Clear(); // Elimina todos los trámites de la lista
        }
    }

}
