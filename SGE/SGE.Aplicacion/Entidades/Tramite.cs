namespace SGE.Aplicacion;

public class Tramite
{
    public int Id { get; set; }
    public int ExpedienteId { get; set; }

    public Etiqueta etiqueta{ get; set; }

    public string? Contenido{ get; set; }

    public DateTime fechaHoraCreacion{get; set; }

    public DateTime fechaHoraUltimaModificacion{get; set; }

    public int IdUsuarioMod { get; set; }

    public override string ToString(){
        return $"Los datos del Tramite son: \nContenido: '{Contenido}' | Id:{Id}";
    }
}
