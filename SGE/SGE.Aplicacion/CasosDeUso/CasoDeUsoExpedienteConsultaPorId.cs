namespace SGE.Aplicacion
{
    public class CasoDeUsoExpedienteConsultaPorId
    {
        public Expediente Ejecutar(int id, List<Expediente> listaE, List<Tramite> listaT)
        {
            List<Tramite> nuevaLista = new List<Tramite>();
            Expediente expediente = null; // Inicializamos a null para verificar si se encontró algún expediente
            foreach (Expediente exp in listaE)
            {
                if (exp.Id == id)
                {
                    Console.WriteLine("Encontré expediente");
                    expediente = exp;
                    break; // Si encontramos el expediente, salimos del bucle
                }
            }

            if (expediente == null)
            {
                throw new RepositorioException($"No se encontró un expediente con el ID {id}");
            }

            foreach (Tramite tramite in listaT)
            {
                Console.WriteLine($"Procesando trámite con expediente id: {tramite.ExpedienteId}");
                if (tramite.ExpedienteId == id)
                {
                    Console.WriteLine("Encontré un trámite");
                    nuevaLista.Add(tramite);
                }
            }
            expediente.listaTramites = nuevaLista;
            return expediente;
        }
    }
}
