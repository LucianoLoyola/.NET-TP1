namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void AgregarExpediente(Expediente expediente);
    List<Expediente> ListarExpediente();
}
