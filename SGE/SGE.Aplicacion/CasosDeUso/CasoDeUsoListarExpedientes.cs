namespace SGE.Aplicacion;
public class CasoDeUsoListarExpedientes(IExpedienteRepositorio repo){
    public List<Expediente> Ejecutar(){
        List<Expediente> listaExpedientes = repo.ListarExpedientes();
        
        if (listaExpedientes.Count == 0)
        {
            Console.WriteLine("No existen expedientes en el repositorio");
        }
        
        return listaExpedientes;
    }
}