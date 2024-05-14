namespace SGE.Aplicacion
{
    public class CasoDeUsoExpedienteConsultaPorId
    {
        public Expediente Ejecutar(int idExpediente, List<Expediente> listaE, List<Tramite> listaT)
        {
            List<Tramite> nuevaLista = new List<Tramite>();
            Expediente? expediente = null; // Inicializamos a null para verificar si se encontró algún expediente
            foreach (Expediente exp in listaE)
            {
                if (exp.Id == idExpediente)
                {
                    Console.WriteLine("Se encontró el expediente");
                    expediente = exp;
                    break; // Si encontramos el expediente, salimos del bucle
                }
            }

            if (expediente == null)
            {
                throw new RepositorioException($"No se encontró un expediente con el ID {idExpediente}");
            }

            //Console.WriteLine($"Procesando trámites con expediente id: {idExpediente}");
            foreach (Tramite tramite in listaT)
            {
                if (tramite.ExpedienteId == idExpediente)
                {
                    //Console.WriteLine($"Se encontró trámite id: {tramite.Id}");
                    nuevaLista.Add(tramite);
                }
            }
            expediente.listaTramites = nuevaLista;
            return expediente;
        }
    }
}
