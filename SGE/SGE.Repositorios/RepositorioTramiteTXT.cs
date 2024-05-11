namespace SGE.Repositorios;

using System.ComponentModel.DataAnnotations;
using SGE.Aplicacion;
public class RepositorioTramiteTXT : ITramiteRepositorio
{
    readonly string _nombreArch = "tramites.txt";
    int IDUnico = 1;

    public void AgregarTramite(Tramite tramite, int idExpediente){
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
            tramite.Id = max; // Nos aseguramos que sea único e incremental

            // Mover el puntero al final del archivo para escribir el nuevo trámite
            fs.Seek(0, SeekOrigin.End);
            sw.WriteLine(tramite.Id);
            sw.WriteLine(tramite.Contenido);
        }
    }
    }
    public void ModificarTramite(Tramite tramite){

    }
    public void EliminarTramite(int id){
        try
        {
            using (var sr = new StreamReader("tramites.txt"))
            using (var sw = new StreamWriter("tramitesTemp.txt"))
            {
                string line;
                bool skipNext = false;

                while ((line = sr.ReadLine()) != null)
                {
                    if (skipNext)
                    {
                        skipNext = false;
                        continue;
                    }
                    var test=id.ToString();
                    var cond=line.Contains(id.ToString());
                    if (line.Contains(id.ToString()))
                    {
                        skipNext = true; // Marcar para saltar la siguiente línea
                        continue;
                    }

                    sw.WriteLine(line); // Escribir la línea al archivo temporal
                }
            }

            File.Delete("tramites.txt"); // Eliminar el archivo original
            File.Move("tramitesTemp.txt", "tramites.txt"); // Renombrar el archivo temporal al original
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error: " + ex.Message);
            File.Delete("tramitesTemp.txt"); // Asegurarse de eliminar el archivo temporal si ocurre un error
        }


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
