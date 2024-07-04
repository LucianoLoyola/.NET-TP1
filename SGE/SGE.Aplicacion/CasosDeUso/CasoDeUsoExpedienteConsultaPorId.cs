namespace SGE.Aplicacion.CasosDeUso;

using AL.Aplicacion.UseCases;
using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

    public class CasoDeUsoExpedienteConsultaPorId(IRepositorioExpediente repo):ExpedienteUseCase(repo)
    {

        public Expediente Ejecutar(int idExpediente)
        {
            Expediente? expediente = Repositorio.GetExpedientePorId(idExpediente); 
            if (expediente == null){//si no se encontró expediente, excepción
                throw new RepositorioException($"No se encontró un expediente con el ID {idExpediente}");
            }
            Console.WriteLine("Se encontró el expediente");
            return expediente;//devuelve el expediente con su lista de tramites

        }

        // public Expediente EjecutarAmbiguo(int idExpediente, List<Expediente> listaE, List<Tramite> listaT)
        // {
        //     List<Tramite> nuevaLista = new List<Tramite>();
        //     Expediente? expediente = null; // Inicializamos a null para verificar si se encontró algún expediente
        //     foreach (Expediente exp in listaE){
        //         if (exp.Id == idExpediente){
        //             Console.WriteLine("Se encontró el expediente");
        //             expediente = exp;
        //             break; // Si encontramos el expediente, salimos del bucle
        //         }
        //     }
        //     if (expediente == null){//si no se encontró expediente, excepción
        //         throw new RepositorioException($"No se encontró un expediente con el ID {idExpediente}");
        //     }
        //     foreach (Tramite tramite in listaT){//si se encontró expediente, agregar tramites asociados al expediente
        //         if (tramite.ExpedienteId == idExpediente){
        //             nuevaLista.Add(tramite);
        //         }
        //     }
        //     expediente.listaTramites = nuevaLista;
        //     return expediente;//devuelve el expediente con su lista de tramites
        // }


        // public Expediente EjecutarCorreg(int idExpediente, List<Expediente> listaE)
        // {
        //     List<Tramite> nuevaLista = new List<Tramite>();
        //     Expediente? expediente = null; // Inicializamos a null para verificar si se encontró algún expediente
        //     foreach (Expediente exp in listaE){
        //         if (exp.Id == idExpediente){
        //             Console.WriteLine("Se encontró el expediente");
        //             expediente = exp;
        //             expediente.listaTramites = exp.listaTramites;
        //             break; // Si encontramos el expediente, salimos del bucle
        //         }
        //     }
        //     if (expediente == null){//si no se encontró expediente, excepción
        //         throw new RepositorioException($"No se encontró un expediente con el ID {idExpediente}");
        //     }

        //     return expediente;//devuelve el expediente con su lista de tramites
        // }

    }

