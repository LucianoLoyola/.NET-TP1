namespace SGE.Aplicacion.Entidades;
public class Tramite
{
    public int Id { get; set; }
    public int ExpedienteId { get; set; }

    public Etiqueta etiqueta{ get; set; }

    public string? Contenido{ get; set; }

    public DateTime fechaHoraCreacion{get; set; }

    public DateTime fechaHoraUltimaModificacion{get; set; }

    public int IdUsuarioMod { get; set; }

    public override string ToString()
    {
        return $"Datos del trámite:\n" +
            $"  - ID: {Id}\n" +
            $"  - IdExpediente: {ExpedienteId}\n" +
            $"  - Etiqueta: {etiqueta}\n" +
            $"  - Contenido: {Contenido ?? "Ningún contenido especificado"}\n" +
            $"  - Fecha y hora de creación: {fechaHoraCreacion}\n" +
            $"  - Fecha y hora de última modificación: {fechaHoraUltimaModificacion}\n" +
            $"  - ID de usuario de modificación: {IdUsuarioMod}";
    }

}
