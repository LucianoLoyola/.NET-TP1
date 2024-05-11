namespace SGE.Repositorios;
using SGE.Aplicacion;
public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
    readonly string _nombreArch = "expedientes.txt";
    int IDUnico = 0;

    public void AgregarExpediente(Expediente expediente){
        using var sw = new StreamWriter(_nombreArch, true);
        IDUnico++;
        expediente.Id = IDUnico; //nos aseguramos que sea unico e incremental
        sw.WriteLine(expediente.Id);
        sw.WriteLine(expediente.caratula);
    }
    public void ModificarExpediente(Expediente expediente){

    }
    public void EliminarExpediente(int id){

    }
    public List<Expediente> ListarExpedientes(){
        var resultado = new List<Expediente>();
        using var sr = new StreamReader(_nombreArch);
        while(!sr.EndOfStream){
            var expediente = new Expediente();
            expediente.Id = int.Parse(sr.ReadLine() ?? "");
            expediente.caratula = sr.ReadLine() ?? "";
            resultado.Add(expediente);
        }
        return resultado;
    }
}
