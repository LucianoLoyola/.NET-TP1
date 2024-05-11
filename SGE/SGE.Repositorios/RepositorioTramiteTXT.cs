namespace SGE.Repositorios;
using SGE.Aplicacion;
public class RepositorioTramiteTXT : ITramiteRepositorio
{
    readonly string _nombreArch = "tramites.txt";
    int IDUnico = 0;

    public void AgregarTramite(Tramite tramite, int idExpediente){
        using var sw = new StreamWriter(_nombreArch, true);
        IDUnico++;
        tramite.Id = IDUnico; //nos aseguramos que sea unico e incremental
        sw.WriteLine(tramite.Id);
        sw.WriteLine(tramite.Contenido);
    }
    public void ModificarTramite(Tramite tramite){

    }
    public void EliminarTramite(int id){
        // Leer todas las líneas del archivo
        string relativePath = @"SGE.Consola\tramites.txt"; // Ajusta esta ruta
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string fullPath = Path.Combine(basePath, relativePath);
        List<string> lines = File.ReadAllLines(fullPath).ToList();
        // Buscar el índice de la línea que contiene el ID
        int index = lines.FindIndex(line => line.Contains((char)id));
        // Si se encuentra el ID y no es la última línea del archivo
        if (index != -1 && index < lines.Count - 1)
        {
            // Eliminar la línea del ID y la siguiente
            lines.RemoveAt(index);
            lines.RemoveAt(index); // índice sigue siendo el mismo ya que se eliminó la línea anterior
        }

        // Escribir las líneas restantes de nuevo al archivo
        File.WriteAllLines(fullPath, lines);


    }

    public List<Tramite> ListarTramites(){
        var resultado = new List<Tramite>();
        using var sr = new StreamReader(_nombreArch);
        while(!sr.EndOfStream){
            var tramite = new Tramite();
            tramite.Id = int.Parse(sr.ReadLine() ?? "");
            tramite.Contenido = sr.ReadLine() ?? "";
            resultado.Add(tramite);
        }
        return resultado;
    }
}
