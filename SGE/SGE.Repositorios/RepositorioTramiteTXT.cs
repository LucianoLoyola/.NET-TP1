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
