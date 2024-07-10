namespace SGE.Aplicacion.CasosDeUso;

using SGE.Aplicacion.Entidades;
using SGE.Aplicacion.Interfaces;

public class CasoDeUsoListarExpedientes(IRepositorioExpediente repo){
    public List<Expediente> Ejecutar(){
        try{
            List<Expediente> listaExpedientes = repo.ListarExpedientes();
            return listaExpedientes;
        }
        catch(Exception error){
            Console.WriteLine(error.Message);
            return null;
        }
        
    }
}