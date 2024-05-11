namespace SGE.Repositorios;
using SGE.Aplicacion;
public class RepositorioExpedienteTXT : IExpedienteRepositorio
{
    readonly string _nombreArch = "expedientes.txt";
    int IDUnico = 1;

    public void AgregarExpediente(Expediente expediente){
    // Obtener la ruta completa del archivo si _nombreArch es una ruta relativa
    string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _nombreArch);
    
    // Crear un FileStream con acceso de lectura y escritura.
    using (FileStream fs = new FileStream(fullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
    {
        using (StreamReader sr = new StreamReader(fs))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            // Leer el archivo para encontrar el máximo ID existente
            string line;
            bool skipNext = false;
            int salida;
            int max = 1;

            while ((line = sr.ReadLine()) != null)
            {
                if (skipNext)
                {
                    skipNext = false;
                    continue;
                }
                if (int.TryParse(line, out salida))
                {
                    if (salida > max)
                    {
                        max = salida;
                    }
                    skipNext = true; // Marcar para saltar la siguiente línea
                    continue;
                }
            }

            // Incrementar el ID máximo encontrado para asignar un nuevo ID único
            max++;
            expediente.Id = max; // Nos aseguramos que sea único e incremental

            // Mover el puntero al final del archivo para escribir el nuevo trámite
            fs.Seek(0, SeekOrigin.End);
            sw.WriteLine(expediente.Id);
            sw.WriteLine(expediente.caratula);
        }
    }
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
