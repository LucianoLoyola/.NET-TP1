namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId()
{
    public Expediente Ejecutar(int id, List<Expediente> listaE,List<Tramite> listaT)
    {
        List<Tramite> nuevaLista = new List<Tramite>();
        Expediente expediente = new Expediente();
        foreach (Expediente exp in listaE)  
        {
            if (exp.Id == id)
            {
                Console.WriteLine("Encontre expediente");
                expediente = exp;
            }
        }
        foreach (Tramite tramite in listaT)
        {
            Console.WriteLine($"Procesando trámite con expediente id: {tramite.ExpedienteId}");
            if (tramite.ExpedienteId == id)
            {
                Console.WriteLine("Encontre un tramite");
                
                nuevaLista.Add(tramite);
            }
        }
        expediente.listaTramites = nuevaLista;
        return expediente;
    }
}
