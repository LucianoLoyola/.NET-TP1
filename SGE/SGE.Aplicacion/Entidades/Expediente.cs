using System.Runtime.CompilerServices;

namespace SGE.Aplicacion;

public class Expediente
{
    public int Id { get; set; } //debe ser un entero valido mayor a 0 
    public string caratula { get; set; } = ""; //no puede estar vacia 
    public DateTime fechaHoraCreacion { get; set; }
    public DateTime fechaHoraUModificacion { get; set; }
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

}
